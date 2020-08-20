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
            this.VocabularyName = "Rest Person";
            this.KeyPrefix = "rest.person";
            this.KeySeparator = ".";
            this.Grouping = EntityType.Infrastructure.User;

            this.AddGroup("Rest Person Details", group =>
            {
                Id = group.Add(new VocabularyKey("Id", VocabularyKeyDataType.Identifier, VocabularyKeyVisibility.Visible));
                Name = group.Add(new VocabularyKey("Name", VocabularyKeyDataType.PersonName, VocabularyKeyVisibility.Visible));
                Username = group.Add(new VocabularyKey("Username", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                Email = group.Add(new VocabularyKey("Email", VocabularyKeyDataType.Email, VocabularyKeyVisibility.Visible));
                AddressStreet = group.Add(new VocabularyKey("AddressStreet", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressSuite = group.Add(new VocabularyKey("AddressSuite", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressCity = group.Add(new VocabularyKey("AddressCity", VocabularyKeyDataType.GeographyCity, VocabularyKeyVisibility.Visible));
                AddressZipcode = group.Add(new VocabularyKey("AddressZipcode", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                AddressGeoLat = group.Add(new VocabularyKey("AddressGeoLat", VocabularyKeyDataType.GeographyCoordinates, VocabularyKeyVisibility.Visible));
                AddressGeoLng = group.Add(new VocabularyKey("AddressGeoLng", VocabularyKeyDataType.GeographyCoordinates, VocabularyKeyVisibility.Visible));
                Phone = group.Add(new VocabularyKey("Phone", VocabularyKeyDataType.PhoneNumber, VocabularyKeyVisibility.Visible));
                Website = group.Add(new VocabularyKey("Website", VocabularyKeyDataType.Uri, VocabularyKeyVisibility.Visible));
                CompanyName = group.Add(new VocabularyKey("CompanyName", VocabularyKeyDataType.OrganizationName, VocabularyKeyVisibility.Visible));
                CompanyCatchPhrase = group.Add(new VocabularyKey("CompanyCatchPhrase", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
                CompanyBs = group.Add(new VocabularyKey("CompanyBs", VocabularyKeyDataType.Text, VocabularyKeyVisibility.Visible));
            });
            AddMapping(Name, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.FullName);
            AddMapping(Username, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.UserName);
            AddMapping(Email, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Email);
            AddMapping(AddressStreet, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.Address);
            AddMapping(AddressCity, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressCity);
            AddMapping(AddressZipcode, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressZipCode);
            AddMapping(AddressGeoLat, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressLattitude);
            AddMapping(AddressGeoLng, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInLocation.AddressLongitude);
            AddMapping(Phone, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.PhoneNumber);
            AddMapping(Website, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInUser.Website);
            AddMapping(CompanyName, CluedIn.Core.Data.Vocabularies.Vocabularies.CluedInOrganization.OrganizationName);

        }
        public VocabularyKey Id { get; set; }
        public VocabularyKey Name { get; set; }
        public VocabularyKey Username { get; set; }
        public VocabularyKey Email { get; set; }
        public VocabularyKey AddressStreet { get; set; }
        public VocabularyKey AddressSuite { get; set; }
        public VocabularyKey AddressCity { get; set; }
        public VocabularyKey AddressZipcode { get; set; }
        public VocabularyKey AddressGeoLat { get; set; }
        public VocabularyKey AddressGeoLng { get; set; }
        public VocabularyKey Phone { get; set; }
        public VocabularyKey Website { get; set; }
        public VocabularyKey CompanyName { get; set; }
        public VocabularyKey CompanyCatchPhrase { get; set; }
        public VocabularyKey CompanyBs { get; set; }

    }
}
