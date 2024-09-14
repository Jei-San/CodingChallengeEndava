using CodingChallengeEndava.Core.Models;
using CodingChallengeEndava.Core.Models.QueryParams;

namespace CodingChallengeEndava.Shared.Extensions
{
    public static class LinqExtensions
    {
        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> source, PaginatedQuery paginatedQuery)
        {
            return new PaginatedList<T>()
            {
                PageIndex = paginatedQuery.PageIndex,
                TotalItems = source.Count(),
                Items = source.Skip((paginatedQuery.PageIndex - 1) * paginatedQuery.PageSize).Take(paginatedQuery.PageSize).ToList()
            };
        }
    }
}
