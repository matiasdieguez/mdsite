
## Adding configurable values

- The configurable values must be added in the appsettings.json file, within the AppConfig section
- The solution has two executable components, App and Api, therefore these two projects have their appsettings.json file with their values

> /ProjectName.Api/appsettings.json
```json
{

//previous code ommited

"AppConfig": {
    "ApiKey": "dagSj28282821.dGDAdkgh/(·i9jg389u"
  },

//next code ommited

}

```

## Use of configurable values

```csharp
using ProjectName.Common.Configuration;

//previous code ommited

var apiKeyValue = ConfigurationManager.AppSettings["AppConfig:ApiKey"];

```
