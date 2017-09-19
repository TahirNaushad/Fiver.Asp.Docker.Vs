using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Fiver.Api.HttpClient;
using System.Threading.Tasks;

namespace Fiver.Asp.Docker.Web.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        public string Title { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}/{id}";
            var response = await HttpRequestFactory.Get(requestUri);

            var outputModel = response.ContentAsType<MovieOutputModel>();
            if (outputModel == null)
                return RedirectToPage("./Index");

            this.Id = outputModel.Id;
            this.Title = outputModel.Title;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}/{this.Id}";
            var response = await HttpRequestFactory.Delete(requestUri);
            
            return RedirectToPage("./Index");
        }
    }
}