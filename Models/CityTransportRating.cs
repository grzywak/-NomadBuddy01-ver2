using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.Models
{
    public class CityTransportRating
    {
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }
        [Required]
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }

        [Range(1, 5)]
        public int PublicTransportScore { get; set; }

        [Range(1, 5)]
        public int NightTransportScore { get; set; }

        [Range(1, 5)]
        public int BikeFriendlyScore { get; set; }

        [Range(1, 5)]
        public int WalkabilityScore { get; set; }

        [Range(1, 5)]
        public int TransportCostScore { get; set; }

        [Range(1, 5)]
        public int AppConvenienceScore { get; set; }

        [Range(1, 5)]
        public int MotorbikeEaseScore { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
