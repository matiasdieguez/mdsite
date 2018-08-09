using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class DocsPageModel : PageModel
    {
        public string MarkdownText { get; set; }
        public void OnGet()
        {
            var file = HttpContext.Request.Query["path"].ToString();
            if (file.Substring(file.Length - 3, 3) != ".md")
            {
                MarkdownText = "What are you trying to read?";
                return;
            }

            var path = ((IHostingEnvironment)HttpContext.RequestServices.GetService(typeof(IHostingEnvironment))).ContentRootPath;
            var text = System.IO.File.ReadAllText(path + "\\wwwroot\\docs\\" + file);
            MarkdownText = text;
        }
    }
}
