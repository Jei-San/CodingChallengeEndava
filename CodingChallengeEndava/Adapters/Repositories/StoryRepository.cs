using CodingChallengeEndava.Core.Data;
using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.Data.Models.QueryParams;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Shared.Extensions;
using CodingChallengeEndava.Shared.SharedResources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CodingChallengeEndava.Adapters.Repositories
{
    public class StoryRepository : IStoryRepository
    {
        private readonly CodingChallengeEndavaDbContext context;
        private readonly IMemoryCache memoryCache;

        public StoryRepository(CodingChallengeEndavaDbContext context, IMemoryCache memoryCache)
        {
            this.context = context;
            this.memoryCache = memoryCache;
        }

        public async Task<PaginatedList<Story>> GetPaginatedListAsync(PaginatedQuery paginatedQuery)
        {
            if (!memoryCache.TryGetValue($"{SharedResources.StoryCacheKey}{paginatedQuery.PageIndex}{paginatedQuery.PageSize}{paginatedQuery.Search}", out PaginatedList<Story>? paginatedList))
            {
                IQueryable<Story> query = context.Stories.AsQueryable();

                if (!string.IsNullOrWhiteSpace(paginatedQuery.Search))
                {
                    query = query.Where(x => x.Title.Contains(paginatedQuery.Search));
                }

                paginatedList = await query
                    .AsNoTracking()
                    .OrderByDescending(x => x.ExternalId)
                    .ToPaginatedListAsync(paginatedQuery);

                var cacheEntryPoints = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
                    .SetPriority(CacheItemPriority.Normal);

                memoryCache.Set($"{SharedResources.StoryCacheKey}{paginatedQuery.PageIndex}{paginatedQuery.PageSize}{paginatedQuery.Search}", paginatedList, cacheEntryPoints);
            };

            return paginatedList ?? new PaginatedList<Story>()
            {
                PageIndex = paginatedQuery.PageIndex,
                TotalItems = 0,
                Items = new List<Story>()
            };
        }

        public async Task<List<int>> GetStoryIdsAsync(List<int> storyIds)
        {
            return await context.Stories
                .Where(x => storyIds.Contains(x.ExternalId))
                .Select(x => x.ExternalId)
                .ToListAsync();
        }

        public async Task AddRangeAsync(List<Story> story)
        {
            await context.Stories.AddRangeAsync(story);
            await context.SaveChangesAsync();
        }
    }
}
