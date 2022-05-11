using System.Collections.Generic;
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
            var path = ((IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment))).ContentRootPath;
            var jsonFile = path + "\\wwwroot\\data\\dieguez.json";
            var json = System.IO.File.ReadAllText(jsonFile);

            var data = JsonConvert.DeserializeObject<List<DieguezImmigration>>(json);

            DieguezImmigrations = data;
        }
    }
}
