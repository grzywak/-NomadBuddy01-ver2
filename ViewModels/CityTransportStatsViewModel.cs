namespace NomadBuddy00.ViewModels
{
    public class CityTransportStatsViewModel
    {
        public double AvgPublicTransportScore { get; set; }
        public double AvgNightTransportScore { get; set; }
        public double AvgBikeFriendlyScore { get; set; }
        public double AvgWalkabilityScore { get; set; }
        public double AvgTransportCostScore { get; set; }
        public double AvgAppConvenienceScore { get; set; }
        public double AvgMotorbikeEaseScore { get; set; }
        public int TotalRatingsCount { get; set; } = 0;
    }
}
