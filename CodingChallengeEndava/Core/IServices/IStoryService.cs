using CodingChallengeEndava.Shared.Dtos;
using CodingChallengeEndava.Shared.Dtos.QueryParams;

namespace CodingChallengeEndava.Core.IServices
{
    public interface IStoryService
    {
        Task<PaginatedListDto<StoryDto>> GetPaginatedStoriesAsync(PaginatedQueryDto paginatedQueryDto);
    }
}
