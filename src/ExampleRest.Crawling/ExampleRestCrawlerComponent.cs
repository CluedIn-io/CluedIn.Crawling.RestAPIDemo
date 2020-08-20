using CluedIn.Core;
using CluedIn.Crawling.ExampleRest.Core;

using ComponentHost;

namespace CluedIn.Crawling.ExampleRest
{
    [Component(ExampleRestConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class ExampleRestCrawlerComponent : CrawlerComponentBase
    {
        public ExampleRestCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

