# .Net REST WebAPI Quickstart

## Pre-Requisites

- Install .NET [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)

  To check if it's installed, execute:

  ```
  dotnet --version
  ```

  To configure Developer Certificate for running local websites with HTTPS, execute:

  ```
  dotnet dev-certs https --trust
  ```

- Install VS Code [https://code.visualstudio.com/](https://code.visualstudio.com/)
- Install VS Code "C# OmniSharp" VS Code Extension
- Install VS Code "MSSQL" VS Code Extension
- Install Entity Framework Tools
  ```
   dotnet tool install --global dotnet-ef
  ```


## VS Code most common commands

    - F1            Run commands
    - F2            Rename
    - F3            Search
    - F5            Starts Debug (for selected project in Debug workbench)
    - F10           Step Over (in Debug)
    - F11           Step Into (in Debug)
    - F12           Go to definition
    - Ctrl-SPACE    Open IntelliSense suggestions
    - Ctrl-S        Save file
    - Ctrl-P        Search files
    - Ctrl-Shift-P  Run commands
    - Ctrl+Shift+B  Start Build
    - Ctrl+Shift+Ñ  Open Terminal
    - Alt+Shift+F   Auto format code
    - Ctrl+K+C      Comment/Uncomment code

## .NET Command Line Interface (CLI)

### Clean previous compilations, bin and obj folders
```
dotnet clean
```

### Restore NuGet packages
```
dotnet restore
```

### Compilation

- Debug
    ```
    dotnet build
    ```

- Release
    ```
    dotnet build -c Release
    ```

### Automated tests execution
```
dotnet test
```

### Execute

- Classic
    ```
    dotnet run 
    ```

- With HotReload
    ```
    dotnet watch 
    ```

### Publish
```
dotnet publish
```

## Solution Architecture

### Components
```
+------------+
|    API     |
+------------+
      |
      |
      V
+------------+
|  Database  |
+------------+

```

### Execution Flow
```
+------------------------------------+
|    HTTP  (GET, POST, PUT, DELETE)  |
|    +--------------+                |
|    |   Json Data  |                |
|    +--------------+                |
+------------------------------------+
      |
      V
+-------------------------------+
|      .NET WebAPI REST         |
|    +------------+             |
|    |   Swagger  |             |
|    +------------+             |
|        |                      | 
|        V                      |
|    +---------------+          |
|    |   Dto Class   |          |
|    +---------------+          |
|        |                      | 
|        V                      |
|    +----------------------+   |
|    |   Controller Class   |   |
|    +----------------------+   |
|        |                      | 
|        V                      |
|    +---------------+          |
|    |   Model Class |          |
|    +---------------+          |
|        |                      | 
|        V                      |
|    +---------------+          |
|    |   DbContext   |          |
|    +---------------+          |
|        |                      | 
|        V                      |
|    +--------------------+     |
|    |  Entity Framework  |     |
|    +--------------------+     |
+-------------------------------+
        |
        V
+------------+
|  Database  |
+------------+

```

## Step by step to add new Dummy feature

### Pre-Requisites
    - Replace 'ProjectName' with your project name each time it appears in the next code samples and file names

### Add Model class
- Add Dummy.cs class to /Api/Models
  
  Use Data Annotations to set lengths & indexes

    ```csharp
    namespace ProjectName.Api.Models
    {
        public class Dummy
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }
    ```

### Add DbSet to DbContext
- Add DbSet<Dummy> to /Api/Models/ProjectNameDataContext.cs
    ```csharp
        public DbSet<Dummy> Dummies { get; set; }
    ```
### Add Database Migration
- Add EF Migration
    ```
    dotnet ef migrations add AddDummyEntity
    ```
- Update database
    ```
    dotnet ef database update
    ```

### Add DTO class
- Add DummyDto.cs class to /Api/Dto
    ```csharp
    namespace ProjectName.Api.Models
    {
        public class DummyDto
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    }
    ```
### Add Map to convert DTO to Model class and vice-versa
- Add DummyMaps.cs class to /Api/Maps
    ```csharp
    using ProjectName.Api.Models;

    namespace ProjectName.Api.Maps
    {
        public static class DummyMaps
        {
            public static DummyDto ToDto(this Dummy model)
            {
                return new DummyDto()
                {
                    Id = model.Id,
                    Content = model.Content
                };
            }

            public static Dummy FromDto(this DummyDto dto)
            {
                return new Dummy()
                {
                    Id = dto.Id,
                    Content = dto.Content
                };
            }

            public static List<DummyDto> ToDto(this List<Dummy> model)
            {
                var list = model.Select(c => c.ToDto()).ToList();
                return list;
            }

            public static List<Dummy> FromDto(this List<DummyDto> dto)
            {
                var list = dto.Select(c => c.FromDto()).ToList();
                return list;
            }
        }
    }    
    ```
### Add Validations
- Add DummyValidator.cs class to /Api/Validators
    ```csharp
    using System.Text.RegularExpressions;
    using ProjectName.Api.Dto;
    using FluentValidation;

    namespace ProjectName.Api.Validations
    {
        public class DummyValidator : AbstractValidator<DummyDto>
        {
            public DummyValidator()
            {
                RuleFor(item => item.Content)
                    .NotEmpty()
                    .WithMessage(Resources.Required);
            }
        }    
    }    
    ```

### Add Controller
- Add DummyController.cs class to /Api/Controllers
    ```csharp
    using ProjectName.Api.Maps;
    using ProjectName.Api.Models;
    using ProjectName.Api.Filters;
    using Microsoft.AspNetCore.Mvc;

    namespace ProjectName.Api.Controllers;

    [ApiController]
    [Route("[controller]")]
    [RequireApiKey]
    public class DummyController : ControllerBase
    {
        public readonly ProjectNameDataContext _context;
        private readonly ILogger<DummyController> _logger;
        private readonly IConfiguration _config;

        public DummyController(ILogger<DummyController> logger, ProjectNmaeDataContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _config = config;
        }

        [HttpPost]
        public async Task<ActionResult<DummyDto>> Create(DummyDto request)
        {
            var dummy = request.FromDto();
            _context.Dummies.Add(dummy);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), dummy.ToDto());
        }

    }    
    ```
### Test endpoints
- Go to https://localhost:(yourProjectPort)/swagger to browse all controllers's endpoints and test them manually
