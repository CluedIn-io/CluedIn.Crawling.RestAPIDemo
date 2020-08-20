using CluedIn.Crawling.ExampleRest.Core;

namespace CluedIn.Crawling.ExampleRest
{
    public class ExampleRestCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<ExampleRestCrawlJobData>
    {
        public ExampleRestCrawlerJobProcessor(ExampleRestCrawlerComponent component) : base(component)
        {
        }
    }
}
