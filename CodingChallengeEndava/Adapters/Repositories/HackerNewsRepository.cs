using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Core.Models;
using CodingChallengeEndava.Core.Models.QueryParams;
using CodingChallengeEndava.Shared.Extensions;
using CodingChallengeEndava.Shared.SharedResources;
using Microsoft.Extensions.Caching.Memory;

namespace CodingChallengeEndava.Adapters.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private readonly HttpClient httpClient;
        private readonly IMemoryCache memoryCache;
        
        public HackerNewsRepository(HttpClient httpClient, IMemoryCache memoryCache)
        {
            this.httpClient = httpClient;
            this.memoryCache = memoryCache;
        }

        public async Task<PaginatedList<Story>> GetPaginatedStoriesAsync(PaginatedQuery paginatedQuery)
        {
            if (!memoryCache.TryGetValue(SharedResources.CacheKey, out List<int>? storyIds))
            {
                string url = $"{httpClient.BaseAddress}{SharedResources.NewStoriesUrl}";
                storyIds = await httpClient.GetAndDeserialize<List<int>>(url);

                var cacheEntryPoints = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);

                memoryCache.Set(SharedResources.CacheKey, storyIds, cacheEntryPoints);
            }

            if (storyIds == null)
                throw new Exception(SharedResources.FailedToRetrieveStoriesErrorMessage);

            PaginatedList<int> paginatedList = storyIds.ToPaginatedList(paginatedQuery);

            if (paginatedList.Items == null)
                throw new Exception(SharedResources.FailedToRetrieveStoriesErrorMessage);

            var stories = new List<Story>();

            foreach (int storyId in paginatedList.Items)
            {
                Story story = await GetStoryAsync(storyId);
                stories.Add(story);
            }

            return new PaginatedList<Story>()
            {
                TotalItems = paginatedList.TotalItems,
                PageIndex = paginatedList.PageIndex,
                Items = stories
            };
        }

        public async Task<Story> GetStoryAsync(int id)
        {
            string url = $"{httpClient.BaseAddress}{string.Format(SharedResources.StoryUrl, id)}";
            return await httpClient.GetAndDeserialize<Story>(url) ?? new Story();
        }
    }
}
