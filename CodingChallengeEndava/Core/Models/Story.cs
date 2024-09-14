namespace CodingChallengeEndava.Core.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }
        public int Descendants { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string By { get; set; } = string.Empty;
        public List<int> Kids { get; set; } = new List<int>();
    }
}
