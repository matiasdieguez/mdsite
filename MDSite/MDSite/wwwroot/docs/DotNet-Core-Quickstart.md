
# .Net Core Quickstart

- Install .NET Core [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- Install VS Code [https://code.visualstudio.com/](https://code.visualstudio.com/)
- Install VS Code "C# OmniSharp" VS Code Extension
- Install VS Code "MSSQL" VS Code Extension 
- Install "Azure Repos" VS Code Extension

Dev Certificate Config
```
    dotnet dev-certs https --trust
```

## VS Code commands

    - F5 starts Debug (selected project)
    - Ctrl+Shift+B start Build
    - Ctrl+Shift+ñ open Terminal

## .NET Command Line Interface (CLI)

Clean previous compilations, bin and obj folders
```
dotnet clean
```

Restore NuGet packages
```
dotnet restore
```

Compilation
```
dotnet build
```

Automated tests execution
```
dotnet test
```

App execution
```
dotnet run 
```
