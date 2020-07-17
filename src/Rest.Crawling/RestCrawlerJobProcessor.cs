using CluedIn.Crawling.Rest.Core;

namespace CluedIn.Crawling.Rest
{
    public class RestCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<RestCrawlJobData>
    {
        public RestCrawlerJobProcessor(RestCrawlerComponent component) : base(component)
        {
        }
    }
}
