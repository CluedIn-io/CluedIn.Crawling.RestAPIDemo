using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.ExampleRest.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using CluedIn.Core;

namespace CluedIn.Crawling.ExampleRest.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class ExampleRestClient
    {
        private readonly ILogger<ExampleRestClient> log;
        private readonly IRestClient client;
        private readonly long maxTry;

        public ExampleRestClient(ILogger<ExampleRestClient> log, ExampleRestCrawlJobData examplerestCrawlJobData, IRestClient client)
        {
            if (examplerestCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(examplerestCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            client.BaseUrl = new Uri(examplerestCrawlJobData.Url);

            if (!string.IsNullOrEmpty(examplerestCrawlJobData.Token))
                client.AddDefaultHeader("x-api-key", examplerestCrawlJobData.Token);

            if (examplerestCrawlJobData.NumRetry > 0)
                maxTry = examplerestCrawlJobData.NumRetry;
            else
                maxTry = 1;
        }

        public IEnumerable<JObject> FetchEndpointData(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.GET);
            var tryCount = 0;

            IRestResponse response = new RestResponse();
            while (tryCount < maxTry)
            {
                try
                {
                    response = client.Execute(request);
                }
                catch (Exception e)
                {
                    tryCount++;
                    var diagnosticMessage = $"Exception encountered: {e.Message}";
                    log.LogError(diagnosticMessage);
                    continue;
                }

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    break;
                }
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Fetch new token here

                    continue;
                }
                else
                {
                    tryCount++;
                    var diagnosticMessage = $"Attempt {tryCount}/{maxTry} of request to {client.BaseUrl}{endpoint} failed, response {response.ErrorMessage} ({response.StatusCode})";
                    log.LogError(diagnosticMessage);
                }
            }

            if (tryCount == maxTry)
            {
                log.LogError($"Reached max number of request failures");
                yield break;
            }

            JArray data;
            try
            {
                data = JArray.Parse(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting objects from {endpoint}:");
                Console.WriteLine(e.Message);
                Console.WriteLine();
                yield break;
            }

            foreach (var obj in data.Children())
            {
                yield return obj.ToObject<JObject>();
            }
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            //REst call to the service and get an AccountId
            return new AccountInformation("", "");
        }
    }
}
