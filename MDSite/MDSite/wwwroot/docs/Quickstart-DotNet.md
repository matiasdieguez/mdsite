# .Net Core Quickstart

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

- Install Node https://nodejs.org/es/download/

  To check if it's installed, execute:

  ```
  node --version
  ```

  and

  ```
  npm --version
  ```

- Install VS Code [https://code.visualstudio.com/](https://code.visualstudio.com/)
- Install VS Code "C# OmniSharp" VS Code Extension
- Install VS Code "MSSQL" VS Code Extension

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

### Add NuGet package
```
dotnet add package PackageName
```

### Add Project reference
```
dotnet add reference /Path/Project.csproj
```
## .NET CLI project creation
### Class Library
```
dotnet new classlib
```

### ASP.NET Core Web API
```
dotnet new webapi
```

### ASP.NET Core MVC Web App
```
dotnet new mvc
```

