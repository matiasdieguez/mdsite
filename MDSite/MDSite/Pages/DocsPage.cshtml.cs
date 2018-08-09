using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class DocsPageModel : PageModel
    {
        public string MarkdownText { get; set; }
        public void OnGet()
        {
            var name = HttpContext.Request.Query["path"];
            var path = ((IHostingEnvironment)HttpContext.RequestServices.GetService(typeof(IHostingEnvironment))).ContentRootPath;
            var text = System.IO.File.ReadAllText(path + "\\wwwroot\\docs\\" + name);
            MarkdownText = text;
        }
    }
}
