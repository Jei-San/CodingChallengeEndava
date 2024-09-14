using CodingChallengeEndava.Core.IServices;
using CodingChallengeEndava.Shared.Dtos;
using CodingChallengeEndava.Shared.Dtos.QueryParams;
using Microsoft.Extensions.DependencyInjection;

namespace CodingChallengeEndavaTest.Core.Services
{
    public class StoryServiceTests : IClassFixture<CutomWebApplicationFactory<Program>>
    {
        private readonly CutomWebApplicationFactory<Program> factory;

        public StoryServiceTests(CutomWebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async void StoryController_Get_ReturnsSuccess()
        {
            using (var scope = factory.Services.CreateScope())
            {
                var storyService = scope.ServiceProvider.GetRequiredService<IStoryService>();
                var paginatedQueryDto = new PaginatedQueryDto()
                {
                    PageIndex = 1,
                    PageSize = 10
                };

                PaginatedListDto<StoryDto>? paginatedStories = await storyService.GetPaginatedStoriesAsync(paginatedQueryDto);
            }
        }
    }
}
