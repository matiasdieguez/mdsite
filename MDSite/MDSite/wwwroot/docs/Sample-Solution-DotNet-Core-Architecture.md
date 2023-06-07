
## Sample Solution Architecture

## Projects

This diagram shows the relationship between the solution projects, visualizing the references among them

```
          ProjectName.App     
                  |\
                  | \-----> ProjectName.DTO
                  |  \----> ProjectName.Common
                  |   \---> ProjectName.Localization
                  |                 
                  V                 
      ProjectName.Api.Client      
                  |\                
                  | \-----> ProjectName.DTO
                  |  \----> ProjectName.Common
                  V                 
          ProjectName.Api         
                  |\
                  | \-----> ProjectName.DTO
                  |  \----> ProjectName.Common
                  |   \---> ProjectName.Localization
                  |                 
                  V
         ProjectName.Database
```

## Components

Applications and Databases to be implemented

```
          ProjectName.App
      [ASP.NET Core MVC Web App]     
                  |
                  |                 
                  V                 
          ProjectName.Api         
        [ASP.NET Core WebApi]
                  |                 
                  |                 
                  V
        ProjectName.Database
            [SQL Server]
```