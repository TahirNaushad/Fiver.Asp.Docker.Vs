using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiver.Asp.Docker.Web.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            this.Message = "ASP.NET Core, Razor Pages, Docker & Azure";    
        }
    }
}