using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Shared.Extensions;
using CodingChallengeEndava.Shared.SharedResources;

namespace CodingChallengeEndava.Adapters.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        private readonly HttpClient httpClient;

        public HackerNewsRepository(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<int>> GetStoryIdsAsync()
        {
            string url = $"{httpClient.BaseAddress}{SharedResources.NewStoriesUrl}";
            List<int>? storyIds = await httpClient.GetAndDeserialize<List<int>>(url);

            if (storyIds == null)
                throw new Exception(SharedResources.FailedToRetrieveStoriesErrorMessage);

            return storyIds;
        }

        public async Task<Story> GetStoryAsync(int id)
        {
            string url = $"{httpClient.BaseAddress}{string.Format(SharedResources.StoryUrl, id)}";
            Story story = await httpClient.GetAndDeserialize<Story>(url) ?? new Story();

            if (story == null)
                throw new Exception(SharedResources.FailedToRetrieveStoriesErrorMessage);

            return story;
        }
    }
}
