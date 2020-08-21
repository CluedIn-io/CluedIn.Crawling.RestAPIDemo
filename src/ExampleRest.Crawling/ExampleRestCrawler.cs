using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CluedIn.Core.Crawling;
using CluedIn.Crawling.ExampleRest.Core;
using CluedIn.Crawling.ExampleRest.Infrastructure.Factories;
using CluedIn.Crawling.Rest.Core.Models;
using CluedIn.Providers.Webhooks.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace CluedIn.Crawling.ExampleRest
{
    public class ExampleRestCrawler : ICrawlerDataGenerator
    {
        private readonly IExampleRestClientFactory clientFactory;
        private readonly ILogger<ExampleRestCrawler> log;

        public ExampleRestCrawler(IExampleRestClientFactory clientFactory, ILogger<ExampleRestCrawler> log)
        {
            this.clientFactory = clientFactory;
            this.log = log;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            var restJobData = jobData as ExampleRestCrawlJobData;

            if (!(jobData is ExampleRestCrawlJobData))
            {
                throw new ArgumentException(nameof(jobData));
            }

            var client = clientFactory.CreateNew(restJobData);

            foreach (var endpoint in restJobData.Endpoints)
            {
                var data = client.FetchEndpointData(endpoint);
                var output = new List<object>();
                foreach (var obj in data)
                {
                    try
                    {
                        output.Add(ParseJson<User>(obj));
                        continue;
                    }
                    catch { }

                    try
                    {
                        output.Add(ParseJson<Car>(obj));
                        continue;
                    }
                    catch {}

                    try
                    {
                        output.Add(ParseJson<Fallback>(obj));
                    }
                    catch
                    {   
                        log.LogError($"Entity cannot be serialized into fallback type");
                        yield break;
                    }
                }
                yield return output;

                if (restJobData.TimeBetweenRequests != 0)
                {
                    Thread.Sleep((int)restJobData.TimeBetweenRequests);
                }
            }
        }

        public object ParseJson<T>(JObject jsonObj)
        {
            // Attempt to deserialize
            var constructor = typeof(T).GetConstructor(new Type[] { typeof(JObject) });
            var obj = constructor.Invoke(new object[] { jsonObj });
            log.LogInformation($"Deserialized successfully into type {typeof(T)}");
            return obj;
        }

    }
}
