namespace NomadBuddy00.Models
{
    public class CitySafetyRating
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public int DaySafety { get; set; }        // 1–5
        public int NightSafety { get; set; }      // 1–5
        public bool FeltHarassed { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
