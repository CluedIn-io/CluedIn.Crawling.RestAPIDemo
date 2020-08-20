using System.Collections.Generic;
using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.ExampleRest.Core
{
    public class ExampleRestCrawlJobData : CrawlJobData
    {
        public long NumRetry { get; set; } = 1;

        public bool CrawlUsers { get; set; } = false;
        public bool CrawlTodos{ get; set; } = false;
        public bool CrawlPhotos { get; set; } = false;
        public bool CrawlAlbums { get; set; } = false;
        public bool CrawlComments { get; set; } = false;
        public bool CrawlPosts { get; set; } = false;
    }
}
