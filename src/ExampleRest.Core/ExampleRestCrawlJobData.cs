using System.Collections.Generic;
using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.ExampleRest.Core
{
    public class ExampleRestCrawlJobData : CrawlJobData
    {
        public string Url { get; set; }
        public string Token { get; set; }
        public IEnumerable<string> Endpoints { get; set; }
        public long NumRetry { get; set; } = 1;
        public long TimeBetweenRequests { get; set; }
    }
}
