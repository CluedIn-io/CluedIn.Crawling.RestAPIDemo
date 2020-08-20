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

namespace CluedIn.Crawling.ExampleRest.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class ExampleRestClient
    {
        private const string BaseUri = "https://jsonplaceholder.typicode.com";
        private readonly ILogger<ExampleRestClient> log;
        private readonly IRestClient client;
        private readonly long maxTry;

        public ExampleRestClient(ILogger<ExampleRestClient> log, ExampleRestCrawlJobData examplerestCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
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
            client.BaseUrl = new Uri(BaseUri);

            if (examplerestCrawlJobData.NumRetry > 0)
                maxTry = examplerestCrawlJobData.NumRetry;
            else
                maxTry = 1;


        }

        public IEnumerable<JObject> GetData(string url)
        {
            var request = new RestRequest(url, Method.GET);
            var tryCount = 0;

            IRestResponse response = new RestResponse();
            while (tryCount < maxTry)
            {
                response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    break;
                }

                var diagnosticMessage = $"Attempt {tryCount}/{maxTry} of request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.LogError(diagnosticMessage);

                if (tryCount == maxTry)
                {
                    log.LogError($"Reached max number of request failures");
                    yield break;
                }
            }

            JArray data;
            try
            {
                data = JArray.Parse(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error getting objects from {url}:");
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
            return new AccountInformation("", "");
        }
    }
}
