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
    public class CarClueProducer : BaseClueProducer<Car>
    {
        private readonly IClueFactory _factory;

        public CarClueProducer([NotNull] IClueFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            _factory = factory;
        }
        protected override Clue MakeClueImpl([NotNull] Car input, Guid accountId)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var clue = _factory.Create("/Car", input.Id.ToString(), accountId);

            var data = clue.Data.EntityData;

            if (!string.IsNullOrEmpty(input.CarMaker) && !string.IsNullOrEmpty(input.Model) && !string.IsNullOrEmpty(input.ModelYear))
                data.Name = $"{input.CarMaker} {input.Model} from {input.ModelYear}";

            if (!data.OutgoingEdges.Any())
                _factory.CreateEntityRootReference(clue, EntityEdgeType.PartOf);

            var vocab = new CarVocabulary();

            data.Properties[vocab.Id] = input.Id.PrintIfAvailable();
            data.Properties[vocab.PurchaseDate] = input.PurchaseDate.PrintIfAvailable();
            data.Properties[vocab.Color] = input.Color.PrintIfAvailable();

            if (!string.IsNullOrEmpty(input.Color))
                data.Tags.Add(new Tag(input.Color));

            data.Properties[vocab.Model] = input.Model.PrintIfAvailable();
            data.Properties[vocab.CarMaker] = input.CarMaker.PrintIfAvailable();
            data.Properties[vocab.ModelYear] = input.ModelYear.PrintIfAvailable();

            return clue;

        }
    }
}
