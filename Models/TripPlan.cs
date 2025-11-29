namespace NomadBuddy00.Models
{
    public class TripPlan
    {
        public int Id { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<TripStop> TripStops { get; set; } = new List<TripStop>();
    }
}
