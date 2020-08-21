using System;
using System.Collections.Generic;
using System.Text;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.Rest.Vocabularies
{
    public class CarVocabulary : SimpleVocabulary
    {
        public CarVocabulary()
        {
            VocabularyName = "ExampleRest Car";
            KeyPrefix = "exampleRest.car";
            KeySeparator = ".";
            Grouping = "Car";

            AddGroup("Rest Person Details", group =>
            {
                Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible));
                PurchaseDate = group.Add(new VocabularyKey("PurchaseDate", VocabularyKeyDataType.DateTime, VocabularyKeyVisibility.Visible));
                Color = group.Add(new VocabularyKey("Color", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Model = group.Add(new VocabularyKey("Model", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                CarMaker = group.Add(new VocabularyKey("CarMaker", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                ModelYear = group.Add(new VocabularyKey("ModelYear", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
            });

        }
        public VocabularyKey Id { get; set; }
        public VocabularyKey PurchaseDate { get; set; }
        public VocabularyKey Color { get; set; }
        public VocabularyKey Model { get; set; }
        public VocabularyKey CarMaker { get; set; }
        public VocabularyKey ModelYear { get; set; }

    }
}
