using CodingChallengeEndava.Core.Models;
using CodingChallengeEndava.Core.Models.QueryParams;

namespace CodingChallengeEndava.Core.IRepositories
{
    public interface IHackerNewsRepository
    {
        Task<PaginatedList<Story>> GetPaginatedStoriesAsync(PaginatedQuery paginatedQuery);
        Task<Story> GetStoryAsync(int id);
    }
}
