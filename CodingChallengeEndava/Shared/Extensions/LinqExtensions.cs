using CodingChallengeEndava.Core.Data.Models;
using CodingChallengeEndava.Core.Data.Models.QueryParams;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengeEndava.Shared.Extensions
{
    public static class LinqExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, PaginatedQuery paginatedQuery)
        {
            return new PaginatedList<T>()
            {
                PageIndex = paginatedQuery.PageIndex,
                TotalItems = await source.CountAsync(),
                Items = await source.Skip((paginatedQuery.PageIndex - 1) * paginatedQuery.PageSize).Take(paginatedQuery.PageSize).ToListAsync()
            };
        }
    }
}
