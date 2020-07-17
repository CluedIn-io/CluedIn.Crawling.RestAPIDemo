using System.Collections.Generic;
using CluedIn.Crawling.Rest.Core;

namespace CluedIn.Crawling.Rest.Integration.Test
{
  public static class RestConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { RestConstants.KeyName.Url, "demo" }
            };
    }
  }
}
