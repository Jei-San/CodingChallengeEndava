using CodingChallengeEndava.Core.Data.Models;

namespace CodingChallengeEndava.Core.IRepositories
{
    public interface IHackerNewsRepository
    {
        Task<List<int>> GetStoryIdsAsync();
        Task<Story> GetStoryAsync(int id);
    }
}
