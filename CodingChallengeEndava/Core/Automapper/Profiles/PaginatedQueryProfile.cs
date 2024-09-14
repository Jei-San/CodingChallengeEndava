using AutoMapper;
using CodingChallengeEndava.Core.Models.QueryParams;
using CodingChallengeEndava.Shared.Dtos.QueryParams;

namespace CodingChallengeEndava.Core.Automapper.Profiles
{
    public class PaginatedQueryProfile : Profile
    {
        public PaginatedQueryProfile()
        {
            CreateMap<PaginatedQuery, PaginatedQueryDto>().ReverseMap();
        }
    }
}
