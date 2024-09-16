using AutoMapper;
using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.Data.Models.QueryParams;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Core.IServices;
using CodingChallengeEndava.Shared.Dtos;
using CodingChallengeEndava.Shared.Dtos.QueryParams;

namespace CodingChallengeEndava.Core.Services
{
    public class StoryService : IStoryService
    {
        private readonly IMapper mapper;
        private readonly IStoryRepository storyRepository;
        private readonly IHackerNewsRepository hackerNewsRepository;

        public StoryService(IStoryRepository storyRepository, IHackerNewsRepository hackerNewsRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.storyRepository = storyRepository;
            this.hackerNewsRepository = hackerNewsRepository;
        }

        public async Task<PaginatedListDto<StoryDto>> GetPaginatedStoriesAsync(PaginatedQueryDto paginatedQueryDto)
        {
            PaginatedList<Story> paginatedStories = await storyRepository.GetPaginatedListAsync(mapper.Map<PaginatedQuery>(paginatedQueryDto));
            return mapper.Map<PaginatedListDto<StoryDto>>(paginatedStories);
        }

        public async Task SyncStoriesAsync()
        {
            List<int> storyIds = await hackerNewsRepository.GetStoryIdsAsync();
            List<int> storyIdsFromDatabase = await storyRepository.GetStoryIdsAsync(storyIds);
            List<int> storyIdsToInsert = storyIds.Except(storyIdsFromDatabase).ToList();
            var stories = new List<Story>();

            foreach (int storyId in storyIdsToInsert)
            {
                Story story = await hackerNewsRepository.GetStoryAsync(storyId);
                story.ExternalId = storyId;
                story.Id = 0;
                stories.Add(story);
            }

            await storyRepository.AddRangeAsync(stories);
        }
    }
}
