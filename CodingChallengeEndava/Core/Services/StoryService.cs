using AutoMapper;
using CodingChallengeEndava.Core.IRepositories;
using CodingChallengeEndava.Core.IServices;
using CodingChallengeEndava.Core.Models;
using CodingChallengeEndava.Core.Models.QueryParams;
using CodingChallengeEndava.Shared.Dtos;
using CodingChallengeEndava.Shared.Dtos.QueryParams;

namespace CodingChallengeEndava.Core.Services
{
    public class StoryService : IStoryService
    {
        private readonly IMapper mapper;
        private readonly IHackerNewsRepository hackerNewsRepository;

        public StoryService(IHackerNewsRepository hackerNewsRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.hackerNewsRepository = hackerNewsRepository;
        }

        public async Task<PaginatedListDto<StoryDto>> GetPaginatedStoriesAsync(PaginatedQueryDto paginatedQueryDto)
        {
            PaginatedList<Story> paginatedStories = await hackerNewsRepository.GetPaginatedStoriesAsync(mapper.Map<PaginatedQuery>(paginatedQueryDto));
            return mapper.Map<PaginatedListDto<StoryDto>>(paginatedStories);
        }
    }
}
