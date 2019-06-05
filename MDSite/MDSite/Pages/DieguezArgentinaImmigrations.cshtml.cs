using System.Collections.Generic;
using System.IO;
using MDSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MDSite.Pages
{
    public class DieguezArgentinaImmigrationsModel : PageModel
    {
        public List<DieguezImmigration> DieguezImmigrations { get; set; }
        public void OnGet()
        {
            var path = ((IHostingEnvironment)HttpContext.RequestServices.GetService(typeof(IHostingEnvironment))).ContentRootPath;
            var jsonFile = path + "\\wwwroot\\data\\dieguez.json";
            var json = System.IO.File.ReadAllText(jsonFile);

            var data = JsonConvert.DeserializeObject<List<DieguezImmigration>>(json);

            DieguezImmigrations = data;
        }
    }
}
