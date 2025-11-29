using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CityTransportRatingViewModel
    {
        public int CityId { get; set; }

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

        public string? Comment { get; set; }
    }
}
