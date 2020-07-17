using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.Rest.Core
{
    public class RestCrawlJobData : CrawlJobData
    {
        public string Url { get; set; }
        public string Token { get; set; }
    }
}
