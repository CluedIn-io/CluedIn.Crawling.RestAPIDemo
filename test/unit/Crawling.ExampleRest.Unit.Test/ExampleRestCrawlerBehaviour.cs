using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.ExampleRest;
using CluedIn.Crawling.ExampleRest.Infrastructure.Factories;
using Moq;
using Shouldly;
using Xunit;

namespace Crawling.ExampleRest.Unit.Test
{
    public class ExampleRestCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public ExampleRestCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IExampleRestClientFactory>();

            _sut = new ExampleRestCrawler(nameClientFactory.Object);
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
