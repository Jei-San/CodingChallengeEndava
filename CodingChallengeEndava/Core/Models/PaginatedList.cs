namespace CodingChallengeEndava.Core.Models
{
    public class PaginatedList<T>
    {
        public int PageIndex { get; set; }
        public int TotalItems { get; set; }
        public List<T>? Items { get; set; }
    }
}
