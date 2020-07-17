using System;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Rest.Core;
using RuleConstants = CluedIn.Core.Constants.Validation.Rules;

namespace CluedIn.Crawling.Rest.Factories
{
    public class RestClueFactory : ClueFactory
    {
        public RestClueFactory()
            : base(RestConstants.CodeOrigin, RestConstants.ProviderRootCodeValue)
        {
        }

        protected override Clue ConfigureProviderRoot([NotNull] Clue clue)
        {
            if (clue == null)
            {
                throw new ArgumentNullException(nameof(clue));
            }

            var data = clue.Data.EntityData;
            data.Name = RestConstants.CrawlerName;
            data.Uri = new Uri(RestConstants.Uri);
            data.Description = RestConstants.CrawlerDescription;

            clue.ValidationRuleSuppressions.AddRange(new[] {RuleConstants.PROPERTIES_001_MustExist,});

            clue.ValidationRuleSuppressions.AddRange(new[]
            {
                RuleConstants.METADATA_002_Uri_MustBeSet, RuleConstants.PROPERTIES_002_Unknown_VocabularyKey_Used
            });

            return clue;
        }
    }
}
