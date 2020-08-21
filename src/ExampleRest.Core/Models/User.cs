using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CluedIn.Crawling.Rest.Core.Models
{

    public class User
    {
        public User(JObject obj)
        {
            Id = obj["id"].ToObject<string>();
            Name = obj["name"].ToObject<string>();
            Email = obj["email"].ToObject<string>();
            Gender = obj["gender"].ToObject<string>();
            AddressStreet = obj["address"]["street"].ToObject<string>();
            AddressZipcode = obj["address"]["zipcode"].ToObject<string>();
            AddressCity = obj["address"]["city"].ToObject<string>();
            AddressRegion = obj["address"]["region"].ToObject<string>();
            AddressCountry = obj["address"]["country"].ToObject<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string AddressStreet { get; set; }
        public string AddressZipcode { get; set; }
        public string AddressCity { get; set; }
        public string AddressRegion { get; set; }
        public string AddressCountry { get; set; }

    }
}
