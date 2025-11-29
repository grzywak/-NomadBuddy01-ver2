using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class TripPin
    {
        public int Id { get; set; }
        public int NomadMatchId { get; set; }
        public NomadMatch NomadMatch { get; set; }
        public string AddedByNomadId { get; set; }
        public Nomad AddedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public TripPinStatus TripPinStatus { get; set; } = TripPinStatus.New;
    }

}
