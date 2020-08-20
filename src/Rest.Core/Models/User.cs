using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CluedIn.Crawling.Rest.Core.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address.street")]
        public string AddressStreet { get; set; }

        [JsonProperty("address.suite")]
        public string AddressSuite { get; set; }

        [JsonProperty("address.city")]
        public string AddressCity { get; set; }

        [JsonProperty("address.zipcode")]
        public string AddressZipcode { get; set; }

        [JsonProperty("address.geo.lat")]
        public string AddressGeoLat { get; set; }

        [JsonProperty("address.geo.lng")]
        public string AddressGeoLng { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("company.name")]
        public string CompanyName { get; set; }

        [JsonProperty("company.catchPhrase")]
        public string CompanyCatchPhrase { get; set; }

        [JsonProperty("company.bs")]
        public string CompanyBs { get; set; }
    }
}
