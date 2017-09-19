using Fiver.Api.HttpClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Fiver.Asp.Docker.Web.Pages.Movies
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public void OnGet()
        {
            this.Movie = new MovieInputModel();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}";
            var response = await HttpRequestFactory.Post(requestUri, this.Movie);

            return RedirectToPage("./Index");
        }
    }
}