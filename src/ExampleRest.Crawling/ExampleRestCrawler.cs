using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.ExampleRest.Core;
using CluedIn.Crawling.ExampleRest.Infrastructure.Factories;
using CluedIn.Crawling.Rest.Core.Models;

namespace CluedIn.Crawling.ExampleRest
{
    public class ExampleRestCrawler : ICrawlerDataGenerator
    {
        private readonly IExampleRestClientFactory clientFactory;
        public ExampleRestCrawler(IExampleRestClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            var restJobData = jobData as ExampleRestCrawlJobData;

            if (!(jobData is ExampleRestCrawlJobData examplerestcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(examplerestcrawlJobData);

            if (restJobData.CrawlUsers)
            {
                foreach (var userObj in client.GetData($"/users"))
                {
                    yield return new User(userObj);
                }
            }


            
        }       
    }
}
