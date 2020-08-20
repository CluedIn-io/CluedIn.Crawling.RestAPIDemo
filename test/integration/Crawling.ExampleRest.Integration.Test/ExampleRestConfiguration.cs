using System.Collections.Generic;
using CluedIn.Crawling.ExampleRest.Core;

namespace CluedIn.Crawling.ExampleRest.Integration.Test
{
  public static class ExampleRestConfiguration
  {
    public static Dictionary<string, object> Create()
    {
        return new Dictionary<string, object>
        {
            { ExampleRestConstants.KeyName.Url, "demo" },
            { ExampleRestConstants.KeyName.NumRetry, 4 }
        };
    }
  }
}
