using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.Rest;
using CluedIn.Crawling.Rest.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.Rest.Unit.Test
{
    public class RestCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public RestCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IRestClientFactory>();

            _sut = new RestCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
