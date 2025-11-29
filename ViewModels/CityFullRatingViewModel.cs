using NomadBuddy00.Models;

namespace NomadBuddy00.ViewModels
{
    public class CityFullRatingViewModel
    {
        public City City { get; set; } = null!;

        // Safety
        public CitySafetyStatsViewModel SafetyStats { get; set; } = new();
        public CitySafetyRating? SafetyUserRating { get; set; }

        // Healthcare
        public CityHealthcareStatsViewModel HealthcareStats { get; set; } = new();
        public CityHealthcareRating? HealthcareUserRating { get; set; }

        //Entertainment
        public CityEntertainmentStatsViewModel EntertainmentStats { get; set; } = new();
        public CityEntertainmentRating? EntertainmentUserRating { get; set; }

        //Transport
        public CityTransportStatsViewModel TransportStats { get; set; }
        public CityTransportRating? TransportUserRating { get; set; }

        //CostOfLiving
        public CityCostOfLivingStatsViewModel? CostOfLivingStats { get; set; }
        public CityCostOfLivingRating? CostOfLivingUserRating { get; set; }
        public List<CityCostOfLivingStatsViewModel> CostOfLivingAllStats { get; set; }


    }
}
