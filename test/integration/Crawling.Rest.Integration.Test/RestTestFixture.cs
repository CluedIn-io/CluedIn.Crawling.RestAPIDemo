using System.IO;
using System.Reflection;
using CluedIn.Crawling.Rest.Core;
using CrawlerIntegrationTesting.Clues;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;
using DebugCrawlerHost = CrawlerIntegrationTesting.CrawlerHost.DebugCrawlerHost<CluedIn.Crawling.Rest.Core.RestCrawlJobData>;

namespace CluedIn.Crawling.Rest.Integration.Test
{
    public class RestTestFixture
    {
        public ClueStorage ClueStorage { get; }
        private readonly DebugCrawlerHost debugCrawlerHost;

        public ILogger<RestTestFixture> Log { get; }
        public RestTestFixture()
        {
            var executingFolder = new FileInfo(Assembly.GetExecutingAssembly().CodeBase.Substring(8)).DirectoryName;
            debugCrawlerHost = new DebugCrawlerHost(executingFolder, RestConstants.ProviderName);

            ClueStorage = new ClueStorage();

            Log = debugCrawlerHost.AppContext.Container.Resolve<ILogger<RestTestFixture>>();

            debugCrawlerHost.ProcessClue += ClueStorage.AddClue;

            debugCrawlerHost.Execute(RestConfiguration.Create(), RestConstants.ProviderId);
        }

        public void PrintClues(ITestOutputHelper output)
        {
            foreach(var clue in ClueStorage.Clues)
            {
                output.WriteLine(clue.OriginEntityCode.ToString());
            }
        }

        public void PrintLogs(ITestOutputHelper output)
        {
            //TODO
            //output.WriteLine(Log.PrintLogs());
        }

        public void Dispose()
        {
        }

    }
}


