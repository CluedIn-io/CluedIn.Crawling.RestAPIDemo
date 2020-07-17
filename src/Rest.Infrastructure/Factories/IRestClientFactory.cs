using CluedIn.Crawling.Rest.Core;

namespace CluedIn.Crawling.Rest.Infrastructure.Factories
{
    public interface IRestClientFactory
    {
        RestClient CreateNew(RestCrawlJobData restCrawlJobData);
    }
}
