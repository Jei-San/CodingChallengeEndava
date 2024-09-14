namespace CodingChallengeEndava.Shared.Dtos.QueryParams
{
    public class PaginatedQueryDto
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
    }
}
