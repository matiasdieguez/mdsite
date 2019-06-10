
## Sample Solution Invocation Flow

The following diagram shows the simplified invocation flow between the components of a solution corresponding to the list of languages in a Web App

```
    Loads the general shared view
ProjectName.App/Views/Shared/_Layout.cshtml
                     |                 
                     V                 
         Loads the particular view
ProjectName.App/Views/Language/Index.cshtml
                     |                 
                     V                 
    Invokes the "Index" Action of the Controller
ProjectName.App/Controllers/Language.cs Index()
                     |                 
        Gets the API URL configured in  
  [ProjectName.App/appsettings.json/ApiUrl]
                     |
                     V                 
           Invokes the API using
ProjectName.Api.Client/LanguageProxyMethods.cs Get()
                     |
                     V                 
    The API receives the request in the method
  ProjectName.Api/Controllers/Language.cs Get()
                     |
                     V                 
 The method obtains the data using the EF context
ProjectName.Api/Models/Context/ProjectNameDbContext.cs Languages.ToList()
                     |
                     V                 
    EF obtains ConnectionString from
[ProjectName.Api/appsettings.json/DefaultConnection]
                     |
                     V
        EF executes a SQL query on
            ProjectName.Database
```
