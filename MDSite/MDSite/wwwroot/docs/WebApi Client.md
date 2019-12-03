
## Creating Api.Client ProxyMethods

- For each entity a class must be created in the /ProjectName.Api.Client project that will work as a proxy to invoke the Api from the client
- Must be named with the name of the entity together with the suffix ProxyMethods
- This class must access ProjectNameApiClient to access the Api services
- You must use async and await to perform the request and return a Task <> to be asynchronous

> ProjectName.Api.Client / LanguageProxyMethods.cs

```csharp
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProjectName.Dto;

namespace ProjectName.Api.Client
{
    public static class LanguageProxyMethods
    {
        public static async Task <List <LanguageDto >> Get ()
        {
            using (var client = ProjectNameApiClient.Get ())
            {
                var response = await client.GetAsync ("language");
                var json = await response.Content.ReadAsStringAsync ();
                return JsonConvert.DeserializeObject <List <LanguageDto >> (json);
            }
        }
    }
}
```