using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CluedIn.Crawling.Rest.Core.Models
{
    
    public class User
    {
        public User(JObject obj)
        {
            Id = obj["id"].ToObject<string>();
            Name = obj["name"].ToObject<string>();
            Username = obj["username"].ToObject<string>();
            Email = obj["email"].ToObject<string>();
            AddressStreet = obj["address"]["street"].ToObject<string>();
            AddressSuite = obj["address"]["suite"].ToObject<string>();
            AddressCity = obj["address"]["city"].ToObject<string>();
            AddressZipcode = obj["address"]["zipcode"].ToObject<string>();
            AddressGeoLat = obj["address"]["geo"]["lat"].ToObject<string>();
            AddressGeoLng = obj["address"]["geo"]["lng"].ToObject<string>();
            Phone = obj["phone"].ToObject<string>();
            Website = obj["website"].ToObject<string>();
            CompanyName = obj["company"]["name"].ToObject<string>();
            CompanyCatchPhrase = obj["company"]["catchPhrase"].ToObject<string>();
            CompanyBs = obj["company"]["bs"].ToObject<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressSuite { get; set; }
        public string AddressCity { get; set; }
        public string AddressZipcode { get; set; }
        public string AddressGeoLat { get; set; }
        public string AddressGeoLng { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCatchPhrase { get; set; }
        public string CompanyBs { get; set; }}
}
