namespace NomadBuddy00.Models
{
    public class CityEntertainmentRating
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public int NightlifeScore { get; set; }              // 1–5
        public int EventsFrequencyScore { get; set; }        // 1–5
        public int YouthVibeScore { get; set; }              // 1–5
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
