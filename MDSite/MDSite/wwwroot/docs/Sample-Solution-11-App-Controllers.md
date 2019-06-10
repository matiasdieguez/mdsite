
## Creating Controller in App

- In the /ProjectName.App project, the Controller must be added according to the MVC convention, creating a class with the name of the entity ending with the Controller suffix inside the Controllers folder

- Each Action can have two defined methods, the one that is executed when loading the page and the one that is executed when receiving a post from the page, eg: Create () and Create (LanguageDto data)

- Documentation https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/actions?view=aspnetcore-2.1

> /ProjectName.App/Controllers/LanguageController.cs

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Api.Client;
using ProjectName.App.Models;

namespace ProjectName.App.Controllers
{
    public class LanguageController: Controller
    {
        public async Task <IActionResult> Index ()
        {
            var data = await LanguageProxyMethods.Get ();
            return View (data);
        }
    }
}

```