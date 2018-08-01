using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class WikiFile
    {
        public string Path { get; set; }
        public string Name { get; set; }
    }

    public class WikiModel : PageModel
    {
        public List<WikiFile> WikiPageFiles { get; set; }
        public void OnGet()
        {
            var list = new List<WikiFile>();

            var path = ((IHostingEnvironment)HttpContext.RequestServices.GetService(typeof(IHostingEnvironment))).ContentRootPath;
            foreach (var file in Directory.GetFiles(path + "\\wwwroot\\wiki", "*.md"))
            {
                var lastIndex = file.LastIndexOf("wiki") + 5;
                var name = file.Substring(lastIndex, file.Length - lastIndex);
                list.Add(new WikiFile { Path = file, Name = name });
            }

            WikiPageFiles = list;
        }
    }
}
