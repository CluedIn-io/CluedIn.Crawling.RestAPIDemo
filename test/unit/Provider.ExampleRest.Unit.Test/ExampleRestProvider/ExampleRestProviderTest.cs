using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.ExampleRest.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.ExampleRest.Unit.Test.ExampleRestProvider
{
    public abstract class ExampleRestProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IExampleRestClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected ExampleRestProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IExampleRestClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new ExampleRest.ExampleRestProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
