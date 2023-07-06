using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class DocsFile
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }

    public class DocsModel : PageModel
    {
        public List<DocsFile> DocsPageFiles { get; set; }
        public Dictionary<string, bool> Categories { get; set; } = new Dictionary<string, bool>();
        public void OnGet()
        {
            var list = new List<DocsFile>();

            var path = ((IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment))).ContentRootPath;
            foreach (var file in Directory.GetFiles(path + "\\wwwroot\\docs", "*.md"))
            {
                var lastIndex = file.LastIndexOf("docs") + 5;
                var name = file[lastIndex..];
                list.Add(new DocsFile { Path = file, Name = name });

                var category = name.Split('-')[0];
                if (!Categories.ContainsKey(category))
                    Categories.Add(category, false);
            }

            DocsPageFiles = list;
        }
    }
}
