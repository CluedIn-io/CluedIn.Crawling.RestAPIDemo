using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.Rest.Core;
using CluedIn.Crawling.Rest.Infrastructure.Factories;

namespace CluedIn.Crawling.Rest
{
    public class RestCrawler : ICrawlerDataGenerator
    {
        private readonly IRestClientFactory clientFactory;
        public RestCrawler(IRestClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is RestCrawlJobData restcrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(restcrawlJobData);

            //retrieve data from provider and yield objects
            
        }       
    }
}
