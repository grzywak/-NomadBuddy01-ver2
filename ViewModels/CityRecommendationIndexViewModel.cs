using NomadBuddy00.Enums;

namespace NomadBuddy00.ViewModels
{
    public class CityRecommendationIndexViewModel
    {
        public NomadType NomadType { get; set; }
        public List<CityRecommendationResult> RecommendedByType { get; set; } = new();
        public List<CityRecommendationResult> FilteredResults { get; set; } = new();
        public TravelBudget? SelectedBudget { get; set; }
        public Continent? SelectedContinent { get; set; }
        public int? SelectedCountryId { get; set; }
    }
}
