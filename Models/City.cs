namespace NomadBuddy00.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public double AverageInternetSpeedMbps { get; set; }
        public int NumberOfCoworkingSpaces { get; set; }
        public int HealthcareQuality { get; set; } // 1–5
        public double CostOfLiving { get; set; }
        public ICollection<CityOverallRating> Ratings { get; set; } = new List<CityOverallRating>();
        public ICollection<CitySafetyRating> SafetyRatings { get; set; } = new List<CitySafetyRating>();
        public ICollection<CityCostOfLivingRating> CostRatings { get; set; } = new List<CityCostOfLivingRating>();
        public ICollection<CityHealthcareRating> HealthcareRatings { get; set; } = new List<CityHealthcareRating>();
        public ICollection<CityTransportRating> TransportRatings { get; set; } = new List<CityTransportRating>();   
        public ICollection<CityTagVote> TagVotes { get; set; } = new List<CityTagVote>();
    }
}
