namespace NomadBuddy00.Models
{
    public class CityTagVote
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int CityTagId { get; set; }
        public CityTag CityTag { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public DateTime VotedAt { get; set; } = DateTime.UtcNow;
    }
}
