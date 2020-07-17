using CluedIn.Core;
using CluedIn.Crawling.Rest.Core;

using ComponentHost;

namespace CluedIn.Crawling.Rest
{
    [Component(RestConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class RestCrawlerComponent : CrawlerComponentBase
    {
        public RestCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

