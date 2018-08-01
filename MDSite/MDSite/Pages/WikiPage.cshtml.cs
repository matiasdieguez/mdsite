using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MDSite.Pages
{
    public class WikiPageModel : PageModel
    {
        public string MarkdownText { get; set; }
        public void OnGet()
        {
            var path = HttpContext.Request.Query["path"];
            var text = System.IO.File.ReadAllText(path);
            MarkdownText = text;
        }
    }
}
