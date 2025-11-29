namespace NomadBuddy00.Models
{
    public class CityOverallRating
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public double OverallScore { get; set; }
        public bool IsSystemGenerated { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
