using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.ViewModels
{
    public class CityRecommendationResult
    {
        public City City { get; set; } = null!;
        public double? AverageRating { get; set; }
        //Filters
        public TravelBudget? BudgetLevel { get; set; }
        public bool? IsMonthly { get; set; }
        public decimal? CostOfLivingEstimate { get; set; }
    }
}
