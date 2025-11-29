namespace NomadBuddy00.Models
{
    public class TripStop
    {
        public int Id { get; set; }
        public int TripPlanId { get; set; }
        public TripPlan TripPlan { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int? CityId { get; set; }  
        public City? City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? VisaPolicyId { get; set; }
        public VisaPolicy? VisaPolicy { get; set; }
        public string? Notes { get; set; }
    }
}
