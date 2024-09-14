namespace CodingChallengeEndava.Shared.Dtos
{
    public class PaginatedListDto<T>
    {
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<T>? Items { get; set; }
    }
}
