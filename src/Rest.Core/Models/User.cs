using System;
using System.Collections.Generic;
using System.Text;

namespace CluedIn.Crawling.Rest.Core.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; }
    }
}
