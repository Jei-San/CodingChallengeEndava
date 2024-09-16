using CodingChallengeEndava.Adapters.Repositories;
using CodingChallengeEndava.Core.Data;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Shared.SharedResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;

namespace CodingChallengeEndava.Core.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddHttpClients(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddHttpClient<IHackerNewsRepository, HackerNewsRepository>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>(SharedResources.HackerNewsApiUrl)!);
            }).AddPolicyHandler(GetRetryPolicy());
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
             {
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.DefaultApiVersion = new ApiVersion(1, 0);
             }).AddMvc();
        }

        public static void ConfigureDbContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<CodingChallengeEndavaDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString(SharedResources.CodingChallengeEndavaConnection))
            );
        }

        public static void AddMigrationsToDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                CodingChallengeEndavaDbContext context = scope.ServiceProvider.GetRequiredService<CodingChallengeEndavaDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
