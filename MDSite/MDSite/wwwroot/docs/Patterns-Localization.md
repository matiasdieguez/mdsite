
## Localization

- Texts locatable by language must be added as resources in the project /ProjectName.Localization
- The value of the resource's name must be added in the /ProjectName.Localization/Resources.cs enumeration
- The keys of the resources must be in PascalCase
- The json records in /ProjectName.Localization/Resources.json must be added for each language for the key

> ProjectName.Localization / Resources.cs
```csharp
namespace ProjectName.Localization
{
    public enum Resources
    {
        // previous code omitted
        
        LanguageTitle

        // next code omitted
    }
}
```
> ProjectName.Localization / Resources.json
```json
[
    // previous code omitted

    {"culture": "es-ES", "key": "LanguageTitle", "value": "Languages"},
    {"culture": "en-EN", "key": "LanguageTitle", "value": "Languages"}

    // next code omitted
]
```

## Using resources in csharp code (.cs)
```csharp
using ProjectName.Localization;

// previous code omitted

var title = Localizer.Get (Resources.LanguageTitle);

```
## Using resources in razor html code (.cshtml)
```csharp
@using ProjectName.Localization

// previous code omitted

<h1> @ Localizer.Get (Resources.LanguageTitle) </ h1>
```