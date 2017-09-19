using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Fiver.Api.HttpClient;
using System.Threading.Tasks;

namespace Fiver.Asp.Docker.Web.Pages.Movies
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public MovieInputModel Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}/{id}";
            var response = await HttpRequestFactory.Get(requestUri);

            var outputModel = response.ContentAsType<MovieOutputModel>();
            if (outputModel == null)
                return RedirectToPage("./Index");

            this.Movie = new MovieInputModel
            {
                Id = outputModel.Id,
                Title = outputModel.Title,
                ReleaseYear = outputModel.ReleaseYear,
                Summary = outputModel.Summary
            };
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}/{this.Movie.Id}";
            var response = await HttpRequestFactory.Put(requestUri, this.Movie);
            
            return RedirectToPage("./Index");
        }
    }
}