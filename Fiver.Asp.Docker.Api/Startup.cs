using Fiver.Asp.Docker.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Asp.Docker.Api
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            var connection = this.configuration["MOVIES_DB_CONN"];

            services.AddDbContext<Database>(options =>
                        options.UseSqlServer(connection));

            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            
            app.UseMvcWithDefaultRoute();
        }
    }
}
