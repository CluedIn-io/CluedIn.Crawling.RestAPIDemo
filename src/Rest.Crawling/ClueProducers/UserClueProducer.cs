using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Crawling.Factories;
using CluedIn.Crawling.Helpers;
using CluedIn.Crawling.Rest.Core.Models;
using CluedIn.Crawling.Rest.Vocabularies;

namespace CluedIn.Crawling.Rest.ClueProducers
{
    public class UserClueProducer : BaseClueProducer<User>
    {
        private readonly IClueFactory _factory;

        public UserClueProducer([NotNull] IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }
        protected override Clue MakeClueImpl([NotNull] User input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create(EntityType.Infrastructure.User, input.Id.ToString(), accountId);

            var data = clue.Data.EntityData;

            var vocab = new UserVocabulary();

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.Name] = input.Name.PrintIfAvailable();
            data.Properties[vocab.Username] = input.Username.PrintIfAvailable();
            data.Properties[vocab.Email] = input.Email.PrintIfAvailable();
            data.Properties[vocab.AddressStreet] = input.AddressStreet.PrintIfAvailable();
            data.Properties[vocab.AddressSuite] = input.AddressSuite.PrintIfAvailable();
            data.Properties[vocab.AddressCity] = input.AddressCity.PrintIfAvailable();
            data.Properties[vocab.AddressZipcode] = input.AddressZipcode.PrintIfAvailable();
            data.Properties[vocab.AddressGeoLat] = input.AddressGeoLat.PrintIfAvailable();
            data.Properties[vocab.AddressGeoLng] = input.AddressGeoLng.PrintIfAvailable();
            data.Properties[vocab.Phone] = input.Phone.PrintIfAvailable();
            data.Properties[vocab.Website] = input.Website.PrintIfAvailable();
            data.Properties[vocab.CompanyName] = input.CompanyName.PrintIfAvailable();
            data.Properties[vocab.CompanyCatchPhrase] = input.CompanyCatchPhrase.PrintIfAvailable();
            data.Properties[vocab.CompanyBs] = input.CompanyBs.PrintIfAvailable();

            return clue;

        }
    }
}
