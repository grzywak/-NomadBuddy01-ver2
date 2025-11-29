using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CityHealthcareRatingViewModel
    {
        public int CityId { get; set; }
        [Range(1, 5)]
        public int AvailabilityScore { get; set; }
        [Range(0, 1000)]
        public decimal AvgInsuranceMonthlyCost { get; set; }
        [Range(0, 500)]
        public decimal AvgDoctorVisitCost { get; set; }
    }
}
