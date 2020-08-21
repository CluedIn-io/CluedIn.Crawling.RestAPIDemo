using System;
using System.Collections.Generic;
using System.Text;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Vocabularies;

namespace CluedIn.Crawling.Rest.Vocabularies
{
    public class UserVocabulary : SimpleVocabulary
    {
        public UserVocabulary()
        {
            VocabularyName = "ExampleRest User";
            KeyPrefix = "exampleRest.user";
            KeySeparator = ".";
            Grouping = EntityType.Infrastructure.User;

            AddGroup("Rest Person Details", group =>
            {
                Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible));
                Name = group.Add(new VocabularyKey("Name", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Email = group.Add(new VocabularyKey("Email", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Gender = group.Add(new VocabularyKey("Gender", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressStreet = group.Add(new VocabularyKey("AddressStreet", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressZipcode = group.Add(new VocabularyKey("AddressZipcode", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressCity = group.Add(new VocabularyKey("AddressCity", VocabularyKeyDataType.GeographyCity, VocabularyKeyVisibility.Visible));
                AddressRegion = group.Add(new VocabularyKey("AddressRegion", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressCountry = group.Add(new VocabularyKey("AddressCountry", VocabularyKeyDataType.GeographyCountry, VocabularyKeyVisibility.Visible));
            });
            AddMapping(Name, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.FullName);
            AddMapping(Email, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Email);
            AddMapping(Gender, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Gender);
            AddMapping(AddressStreet, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.Address);
            AddMapping(AddressZipcode, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressZipCode);
            AddMapping(AddressCity, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressCity);
            AddMapping(AddressRegion, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressCountryRegion);
            AddMapping(AddressCountry, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressCountryName);

        }
        public VocabularyKey Id { get; set; }
        public VocabularyKey Name { get; set; }
        public VocabularyKey Email { get; set; }
        public VocabularyKey Gender { get; set; }
        public VocabularyKey AddressStreet { get; set; }
        public VocabularyKey AddressZipcode { get; set; }
        public VocabularyKey AddressCity { get; set; }
        public VocabularyKey AddressRegion { get; set; }
        public VocabularyKey AddressCountry { get; set; }

    }
}
