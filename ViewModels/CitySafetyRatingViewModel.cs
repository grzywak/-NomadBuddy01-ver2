using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CitySafetyRatingViewModel
    {
        public int CityId { get; set; }
        [Range(1, 5)]
        public int DaySafety { get; set; }
        [Range(1, 5)]
        public int NightSafety { get; set; }
        public bool FeltHarassed { get; set; }
    }
}
