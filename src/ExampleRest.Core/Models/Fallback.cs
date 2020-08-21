using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CluedIn.Crawling.Rest.Core.Models
{

    public class Fallback
    {
        public Fallback(JObject obj)
        {
            Id = obj["id"].ToObject<string>();
        }

        public string Id { get; set; }

    }
}
