namespace CodingChallengeEndava.Core.Data.Models.QueryParams
{
    public class PaginatedQuery
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string? Search { get; set; }
    }
}
