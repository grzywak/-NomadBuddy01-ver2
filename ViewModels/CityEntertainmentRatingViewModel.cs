using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CityEntertainmentRatingViewModel
    {
        public int CityId { get; set; }
        [Range(1, 5)]
        public int NightlifeScore { get; set; }
        [Range(1, 5)]
        public int EventsFrequencyScore { get; set; }
        [Range(1, 5)]
        public int YouthVibeScore { get; set; }
    }
}
