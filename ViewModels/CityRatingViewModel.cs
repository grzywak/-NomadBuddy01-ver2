using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CityRatingViewModel
    {
        public int CityId { get; set; }

        [Range(1, 5)]
        public int InternetScore { get; set; }

        [Range(1, 5)]
        public int CoworkingScore { get; set; }

        [Range(1, 5)]
        public int HealthcareScore { get; set; }

        [Range(1, 5)]
        public int OverallScore { get; set; }
    }
}
