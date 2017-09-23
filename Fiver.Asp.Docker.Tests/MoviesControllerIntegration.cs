using Fiver.Api.HttpClient;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Fiver.Asp.Docker.Tests
{
    public class MoviesControllerIntegration
    {
        private readonly IConfiguration configuration;

        public MoviesControllerIntegration()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true)
                                .AddJsonFile($"appsettings.Development.json", optional: true)
                                .AddEnvironmentVariables();

            configuration = builder.Build();
        }

        [Fact(DisplayName = "Get_retruns_Ok_status_code")]
        public async Task Get_retruns_Ok_status_code()
        {
            // Arrange
            var baseUri = configuration["Api_Url"];
            var requestUri = $"{baseUri}";

            // Act
            var response = await HttpRequestFactory.Get(requestUri);

            // Assert
            Assert.Equal(expected: HttpStatusCode.OK, actual: response.StatusCode);
        }
    }
}
