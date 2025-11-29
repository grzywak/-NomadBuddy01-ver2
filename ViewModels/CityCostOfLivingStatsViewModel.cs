using NomadBuddy00.Enums;

namespace NomadBuddy00.ViewModels
{
    public class CityCostOfLivingStatsViewModel
    {
        public decimal AvgFood { get; set; }
        public decimal AvgHousing { get; set; }
        public decimal AvgTransport { get; set; }
        public decimal AvgLeisure { get; set; }
        public int TotalRatingsCount { get; set; } = 0;
        public TravelBudget BudgetLevel { get; set; }
        public bool IsMonthly { get; set; }
    }
}
