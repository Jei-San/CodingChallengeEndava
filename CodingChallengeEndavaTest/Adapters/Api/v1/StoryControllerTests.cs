using CodingChallengeEndava.Shared.Dtos.QueryParams;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CodingChallengeEndavaTest.Adapters.Api.v1
{
    public class StoryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> factory;
        private readonly string storyUrl = "api/v1/stories?PageIndex={0}&PageSize={1}";

        public StoryControllerTests(WebApplicationFactory<Program> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async void StoryController_Get_ReturnsSuccess()
        {
            var client = factory.CreateClient();

            var paginatedQueryDto = new PaginatedQueryDto()
            { 
                PageIndex = 1,
                PageSize = 10
            };

            HttpResponseMessage response =
                await client.GetAsync(string.Format(storyUrl, paginatedQueryDto.PageIndex, paginatedQueryDto.PageSize));

            Assert.NotNull(response);
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}