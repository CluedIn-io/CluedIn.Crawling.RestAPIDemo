using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Rest.Core;
using CluedIn.Crawling.Rest.Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.Rest.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class RestClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger<RestClient> log;

        private readonly IRestClient client;

        public RestClient(ILogger<RestClient> log, RestCrawlJobData restCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (restCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(restCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from restCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", restCrawlJobData.Url, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.LogError(diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", "");
        }

        public IEnumerable<object> Get(string url, string token)
        {
            long cursor = -1;
            while (cursor != 0)
            {
               
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("Authorization", string.Format("bearer", token));
                request.Method = "Get";
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                }
                catch (Exception e)
                {
                    log.LogError(e.Message);
                    break;
                }
                var responseJson = string.Empty;
                using (response)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseJson = reader.ReadToEnd();
                    }
                }
                var followers = JsonConvert.DeserializeObject<User>(responseJson);
                foreach (var item in followers.users)
                {
                    yield return item;
                }
                cursor = long.Parse(followers.next_cursor);
            }
        }
}
