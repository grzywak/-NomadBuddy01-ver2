using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class VisaPolicy
    {
        public int Id { get; set; }

        // Destination country (they want to go there)
        public int CountryId { get; set; }
        public Country Country { get; set; }

        // Nationality of the nomad
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }

        public VisaAccessType AccessType { get; set; }

        public int? AllowedStayDays { get; set; }
        public int? VisaFreePeriodDays { get; set; } 
        public decimal? EstimatedCostUSD { get; set; }
        public string Notes { get; set; }
    }
}
