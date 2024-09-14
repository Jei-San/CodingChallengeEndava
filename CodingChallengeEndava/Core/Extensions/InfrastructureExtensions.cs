using CodingChallengeEndava.Adapters.Repositories;
using CodingChallengeEndava.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Extensions.Http;

namespace CodingChallengeEndava.Core.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddHttpClients(this IServiceCollection services)
        {
            services.AddHttpClient<IHackerNewsRepository, HackerNewsRepository>(client =>
            {
                client.BaseAddress = new Uri("https://hacker-news.firebaseio.com");
            }).AddPolicyHandler(GetRetryPolicy());
        }

        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
             {
                 options.AssumeDefaultVersionWhenUnspecified = true;
                 options.DefaultApiVersion = new ApiVersion(1, 0);
             }).AddMvc();
        }
    }
}
