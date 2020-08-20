using CluedIn.Crawling.ExampleRest.Core;

namespace CluedIn.Crawling.ExampleRest.Infrastructure.Factories
{
    public interface IExampleRestClientFactory
    {
        ExampleRestClient CreateNew(ExampleRestCrawlJobData examplerestCrawlJobData);
    }
}
