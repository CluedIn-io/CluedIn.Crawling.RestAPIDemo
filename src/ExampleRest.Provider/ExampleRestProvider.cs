using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CluedIn.Core;
using CluedIn.Core.Crawling;
using CluedIn.Core.Data.Relational;
using CluedIn.Core.Providers;
using CluedIn.Core.Webhooks;
using System.Configuration;
using System.Linq;
using CluedIn.Core.Configuration;
using CluedIn.Crawling.ExampleRest.Core;
using CluedIn.Crawling.ExampleRest.Infrastructure.Factories;
using CluedIn.Providers.Models;
using Newtonsoft.Json;

namespace CluedIn.Provider.ExampleRest
{
    public class ExampleRestProvider : ProviderBase, IExtendedProviderMetadata
    {
        private readonly IExampleRestClientFactory _examplerestClientFactory;

        public ExampleRestProvider([NotNull] ApplicationContext appContext, IExampleRestClientFactory examplerestClientFactory)
            : base(appContext, ExampleRestConstants.CreateProviderMetadata())
        {
            _examplerestClientFactory = examplerestClientFactory;
        }

        public override async Task<CrawlJobData> GetCrawlJobData(
            ProviderUpdateContext context,
            IDictionary<string, object> configuration,
            Guid organizationId,
            Guid userId,
            Guid providerDefinitionId)
        {
            if (configuration == null)
                throw new ArgumentNullException(nameof(configuration));

            var exampleRestCrawlJobData = new ExampleRestCrawlJobData();

            if (configuration.ContainsKey(ExampleRestConstants.KeyName.NumRetry))
                exampleRestCrawlJobData.NumRetry = (long)configuration[ExampleRestConstants.KeyName.NumRetry];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlUsers))
                exampleRestCrawlJobData.CrawlUsers = (bool) configuration[ExampleRestConstants.KeyName.CrawlUsers];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlTodos))
                exampleRestCrawlJobData.CrawlTodos = (bool) configuration[ExampleRestConstants.KeyName.CrawlTodos];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlPhotos))
                exampleRestCrawlJobData.CrawlPhotos = (bool) configuration[ExampleRestConstants.KeyName.CrawlPhotos];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlAlbums))
                exampleRestCrawlJobData.CrawlAlbums = (bool) configuration[ExampleRestConstants.KeyName.CrawlAlbums];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlComments))
                exampleRestCrawlJobData.CrawlComments = (bool) configuration[ExampleRestConstants.KeyName.CrawlComments];
            if (configuration.ContainsKey(ExampleRestConstants.KeyName.CrawlPosts))
                exampleRestCrawlJobData.CrawlPosts = (bool) configuration[ExampleRestConstants.KeyName.CrawlPosts];

            return await Task.FromResult(exampleRestCrawlJobData);
        }

        public override Task<bool> TestAuthentication(
            ProviderUpdateContext context,
            IDictionary<string, object> configuration,
            Guid organizationId,
            Guid userId,
            Guid providerDefinitionId)
        {
            throw new NotImplementedException();
        }

        public override Task<ExpectedStatistics> FetchUnSyncedEntityStatistics(ExecutionContext context, IDictionary<string, object> configuration, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            throw new NotImplementedException();
        }

        public override async Task<IDictionary<string, object>> GetHelperConfiguration(
            ProviderUpdateContext context,
            [NotNull] CrawlJobData jobData,
            Guid organizationId,
            Guid userId,
            Guid providerDefinitionId)
        {
            if (jobData == null)
                throw new ArgumentNullException(nameof(jobData));

            var dictionary = new Dictionary<string, object>();

            if (jobData is ExampleRestCrawlJobData exampleRestCrawlJobData)
            {
                //TODO add the transformations from specific CrawlJobData object to dictionary
                // add tests to GetHelperConfigurationBehaviour.cs
                dictionary.Add(ExampleRestConstants.KeyName.NumRetry, exampleRestCrawlJobData.NumRetry);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlUsers, exampleRestCrawlJobData.CrawlUsers);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlTodos, exampleRestCrawlJobData.CrawlTodos);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlPhotos, exampleRestCrawlJobData.CrawlPhotos);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlAlbums, exampleRestCrawlJobData.CrawlAlbums);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlComments, exampleRestCrawlJobData.CrawlComments);
                dictionary.Add(ExampleRestConstants.KeyName.CrawlPosts, exampleRestCrawlJobData.CrawlPosts);

            }

            return await Task.FromResult(dictionary);
        }

        public override Task<IDictionary<string, object>> GetHelperConfiguration(
            ProviderUpdateContext context,
            CrawlJobData jobData,
            Guid organizationId,
            Guid userId,
            Guid providerDefinitionId,
            string folderId)
        {
            throw new NotImplementedException();
        }

        public override async Task<AccountInformation> GetAccountInformation(ExecutionContext context, [NotNull] CrawlJobData jobData, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            if (jobData == null)
                throw new ArgumentNullException(nameof(jobData));

            if (!(jobData is ExampleRestCrawlJobData examplerestCrawlJobData))
            {
                throw new Exception("Wrong CrawlJobData type");
            }

            var client = _examplerestClientFactory.CreateNew(examplerestCrawlJobData);
            return await Task.FromResult(client.GetAccountInformation());
        }

        public override string Schedule(DateTimeOffset relativeDateTime, bool webHooksEnabled)
        {
            return webHooksEnabled && ConfigurationManager.AppSettings.GetFlag("Feature.Webhooks.Enabled", false) ? $"{relativeDateTime.Minute} 0/23 * * *"
                : $"{relativeDateTime.Minute} 0/4 * * *";
        }

        public override Task<IEnumerable<WebHookSignature>> CreateWebHook(ExecutionContext context, [NotNull] CrawlJobData jobData, [NotNull] IWebhookDefinition webhookDefinition, [NotNull] IDictionary<string, object> config)
        {
            if (jobData == null)
                throw new ArgumentNullException(nameof(jobData));
            if (webhookDefinition == null)
                throw new ArgumentNullException(nameof(webhookDefinition));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            throw new NotImplementedException();
        }

        public override Task<IEnumerable<WebhookDefinition>> GetWebHooks(ExecutionContext context)
        {
            throw new NotImplementedException();
        }

        public override Task DeleteWebHook(ExecutionContext context, [NotNull] CrawlJobData jobData, [NotNull] IWebhookDefinition webhookDefinition)
        {
            if (jobData == null)
                throw new ArgumentNullException(nameof(jobData));
            if (webhookDefinition == null)
                throw new ArgumentNullException(nameof(webhookDefinition));

            throw new NotImplementedException();
        }

        public override IEnumerable<string> WebhookManagementEndpoints([NotNull] IEnumerable<string> ids)
        {
            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (!ids.Any())
            {
                throw new ArgumentException(nameof(ids));
            }

            throw new NotImplementedException();
        }

        public override async Task<CrawlLimit> GetRemainingApiAllowance(ExecutionContext context, [NotNull] CrawlJobData jobData, Guid organizationId, Guid userId, Guid providerDefinitionId)
        {
            if (jobData == null)
                throw new ArgumentNullException(nameof(jobData));


            //There is no limit set, so you can pull as often and as much as you want.
            return await Task.FromResult(new CrawlLimit(-1, TimeSpan.Zero));
        }

        // TODO Please see https://cluedin-io.github.io/CluedIn.Documentation/docs/1-Integration/build-integration.html
        public string Icon => ExampleRestConstants.IconResourceName;
        public string Domain { get; } = ExampleRestConstants.Uri;
        public string About { get; } = ExampleRestConstants.CrawlerDescription;
        public AuthMethods AuthMethods { get; } = ExampleRestConstants.AuthMethods;
        public IEnumerable<Control> Properties => null;
        public string ServiceType { get; } = JsonConvert.SerializeObject(ExampleRestConstants.ServiceType);
        public string Aliases { get; } = JsonConvert.SerializeObject(ExampleRestConstants.Aliases);
        public Guide Guide { get; set; } = new Guide
        {
            Instructions = ExampleRestConstants.Instructions,
            Value = new List<string> { ExampleRestConstants.CrawlerDescription },
            Details = ExampleRestConstants.Details

        };

        public string Details { get; set; } = ExampleRestConstants.Details;
        public string Category { get; set; } = ExampleRestConstants.Category;
        public new IntegrationType Type { get; set; } = ExampleRestConstants.Type;
    }
}
