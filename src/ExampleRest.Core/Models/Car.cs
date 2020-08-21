using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CluedIn.Crawling.Rest.Core.Models
{

    public class Car
    {
        public Car(JObject obj)
        {
            Id = obj["id"].ToObject<string>();
            PurchaseDate = obj["purchaseDate"].ToObject<string>();
            Color = obj["color"].ToObject<string>();
            Model = obj["model"].ToObject<string>();
            CarMaker = obj["carMaker"].ToObject<string>();
            ModelYear = obj["modelYear"].ToObject<string>();
        }

        public string Id { get; set; }
        public string PurchaseDate { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public string CarMaker { get; set; }
        public string ModelYear { get; set; }

    }
}
