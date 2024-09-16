using AutoMapper;
using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Shared.Dtos;

namespace CodingChallengeEndava.Core.Automapper.Profiles
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<Story, StoryDto>()
                .BeforeMap((src, dest) => src.Id = src.ExternalId)
                .ReverseMap()
                .ForMember(x => x.Time, opt => opt.Ignore())
                .ForMember(x => x.Descendants, opt => opt.Ignore())
                .ForMember(x => x.Type, opt => opt.Ignore())
                .ForMember(x => x.By, opt => opt.Ignore())
                .ForMember(x => x.Kids, opt => opt.Ignore());
            CreateMap<PaginatedList<Story>, PaginatedListDto<StoryDto>>().ReverseMap();
        }
    }
}
