using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Rest.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.Rest.Unit.Test.RestProvider
{
    public abstract class RestProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IRestClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected RestProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IRestClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new Rest.RestProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
