using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class TripPlanCreateViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
