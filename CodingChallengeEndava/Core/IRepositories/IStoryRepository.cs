using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.Data.Models.QueryParams;

namespace CodingChallengeEndava.Core.IRepositories
{
    public interface IStoryRepository
    {
        Task<PaginatedList<Story>> GetPaginatedListAsync(PaginatedQuery paginatedQuery);
        Task<List<int>> GetStoryIdsAsync(List<int> storyIds);
        Task AddRangeAsync(List<Story> story);
    }
}
