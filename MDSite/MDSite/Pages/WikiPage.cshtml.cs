using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class WikiPageModel : PageModel
    {
        public string MarkdownText { get; set; }
        public void OnGet()
        {
            var name = HttpContext.Request.Query["path"];
            var path = ((IHostingEnvironment)HttpContext.RequestServices.GetService(typeof(IHostingEnvironment))).ContentRootPath;
            var text = System.IO.File.ReadAllText(path + "\\wwwroot\\wiki\\" + name);
            MarkdownText = text;
        }
    }
}
