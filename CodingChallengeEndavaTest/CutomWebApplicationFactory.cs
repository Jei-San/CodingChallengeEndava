using CodingChallengeEndava.Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CodingChallengeEndavaTest
{
    public class CutomWebApplicationFactory<TProgram>
    : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddHttpClients();
                services.ConfigureServices();
                services.ConfigureRepositories();
                services.ConfigureCaching();
            });

            builder.UseEnvironment("Development");
        }
    }
}
