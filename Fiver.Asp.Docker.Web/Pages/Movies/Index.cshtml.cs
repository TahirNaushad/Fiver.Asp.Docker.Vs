using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiver.Api.HttpClient;
using System.Threading.Tasks;

namespace Fiver.Asp.Docker.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public List<MovieOutputModel> Movies { get; set; }

        public async Task OnGetAsync()
        {
            var baseUri = Startup.Configuration["Api_Url"];
            var requestUri = $"{baseUri}";
            var response = await HttpRequestFactory.Get(requestUri);
            this.Movies = response.ContentAsType<List<MovieOutputModel>>();
        }
    }
}