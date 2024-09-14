using CodingChallengeEndava.Core.IServices;
using CodingChallengeEndava.Shared.Dtos;
using CodingChallengeEndava.Shared.Dtos.QueryParams;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeEndava.Adapters.Api.v1
{
    public class StoriesController : BaseController
    {
        private readonly IStoryService storyService;

        public StoriesController(
            IStoryService storyService
            )
        {
            this.storyService = storyService;
        }

        [HttpGet]
        [ProducesResponseType<PaginatedListDto<StoryDto>>(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedListDto<StoryDto>>> Get([FromQuery] PaginatedQueryDto paginatedQueryDto)
        {
            return Ok(await storyService.GetPaginatedStoriesAsync(paginatedQueryDto));
        }
    }
}
