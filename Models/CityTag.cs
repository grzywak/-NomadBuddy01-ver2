namespace NomadBuddy00.Models
{
    public class CityTag
    {
            public int Id { get; set; }
            public string Text { get; set; } = string.Empty;
            public bool IsPositive { get; set; }
            public ICollection<CityTagVote> Votes { get; set; } = new List<CityTagVote>();
    }
}
