using NomadBuddy00.Models;

namespace NomadBuddy00.ViewModels
{
    public class CityDetailsViewModel
    {
        public City City { get; set; }
        public double AvgInternet { get; set; }
        public double AvgCoworking { get; set; }
        public double AvgHealthcare { get; set; }
        public double AvgOverall { get; set; }
        public CityOverallRating? UserRating { get; set; } // dla aktualnego nomada

        public CitySafetyStatsViewModel SafetyStats { get; set; } = new();
        public CitySafetyRating? UserSafetyRating { get; set; }
    }
}
