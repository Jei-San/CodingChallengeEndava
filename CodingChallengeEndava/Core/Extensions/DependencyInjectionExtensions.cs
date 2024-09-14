using CodingChallengeEndava.Adapters.Repositories;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Core.IServices;
using CodingChallengeEndava.Core.Services;
using Microsoft.Extensions.Caching.Memory;

namespace CodingChallengeEndava.Core.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IStoryService, StoryService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IHackerNewsRepository, HackerNewsRepository>();
        }

        public static void ConfigureCaching(this IServiceCollection services)
        {
            services.AddSingleton<IMemoryCache, MemoryCache>();
        }
    }
}
