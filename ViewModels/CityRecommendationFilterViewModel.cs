using NomadBuddy00.Enums;

namespace NomadBuddy00.ViewModels
{
    public class CityRecommendationFilterViewModel
    {
        public int? CountryId { get; set; }
        public Continent? Continent { get; set; }
        public TravelBudget? Budget { get; set; }
        public bool? IsMonthly { get; set; }
    }
}
