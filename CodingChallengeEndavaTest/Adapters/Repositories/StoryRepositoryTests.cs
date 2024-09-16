using CodingChallengeEndava.Adapters.Repositories;
using CodingChallengeEndava.Core.Data;
using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.Data.Models.QueryParams;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CodingChallengeEndavaTest.Adapters.Repositories
{
    public class StoryRepositoryTests
    {
        private readonly CodingChallengeEndavaDbContext context;

        public StoryRepositoryTests()
        {
            DbContextOptionsBuilder<CodingChallengeEndavaDbContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<CodingChallengeEndavaDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());

            context = new CodingChallengeEndavaDbContext(dbContextOptionsBuilder.Options);
        }


        [Fact]
        public async void StoryRepository_GetPaginatedListAsync()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var repository = new StoryRepository(context, cache);
            var stories = new List<Story>();

            for (int i = 0; i < 100; i++)
            {
                stories.Add(new Story()
                {
                    ExternalId = i,
                    Title = $"Title{i}",
                    Url = $"Url{i}"
                }); 
            }

            await context.Stories.AddRangeAsync(stories);
            await context.SaveChangesAsync();

            PaginatedList<Story> paginatedStories = await repository.GetPaginatedListAsync(new PaginatedQuery()
            {
                PageIndex = 1,
                PageSize = 10,
                Search = string.Empty
            });

            Assert.Equal(100, paginatedStories.TotalItems);
            Assert.Equal(1, paginatedStories.PageIndex);
            Assert.Equal(10, paginatedStories.Items!.Count);
        }

        [Fact]
        public async void StoryRepository_GetStoryIdsAsync()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var repository = new StoryRepository(context, cache);
            var stories = new List<Story>();
            var countList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                stories.Add(new Story()
                {
                    ExternalId = i,
                    Title = $"Title{i}",
                    Url = $"Url{i}"
                });
                countList.Add(i);
            }

            await context.Stories.AddRangeAsync(stories);
            await context.SaveChangesAsync();

            var externalIds = await repository.GetStoryIdsAsync(countList);

            Assert.Equal(externalIds, countList);
        }

        [Fact]
        public async void StoryRepository_AddRangeAsync()
        {
            var cache = new MemoryCache(new MemoryCacheOptions());
            var repository = new StoryRepository(context, cache);
            var stories = new List<Story>();

            for (int i = 0; i < 100; i++)
            {
                stories.Add(new Story()
                {
                    ExternalId = i,
                    Title = $"Title{i}",
                    Url = $"Url{i}"
                });
            }

            await repository.AddRangeAsync(stories);
            int storyCount = context.Stories.Count();

            Assert.Equal(100, storyCount);
        }
    }
}
