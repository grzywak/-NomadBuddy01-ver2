namespace NomadBuddy00.ViewModels
{
    public class CitySafetyStatsViewModel
    {
        public double AvgDaySafety { get; set; }
        public double AvgNightSafety { get; set; }
        public double HarassmentRate { get; set; }
        public double AvgOverallSafety => (AvgDaySafety + AvgNightSafety) / 2;
    }
}
