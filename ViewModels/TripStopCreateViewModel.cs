using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class TripStopCreateViewModel
    {
        [Required]
        public int TripPlanId { get; set; }
        [Required]
        public int CountryId { get; set; }
        public int? CityId { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime EndDate { get; set; }
        public string? Notes { get; set; }
    }
}
