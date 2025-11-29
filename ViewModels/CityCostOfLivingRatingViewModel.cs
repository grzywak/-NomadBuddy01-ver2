using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class CityCostOfLivingRatingViewModel
    {
        [Required]
        public int CityId { get; set; }

        [Required]
        public bool IsMonthly { get; set; }

        [Required]
        public TravelBudget BudgetLevel { get; set; }

        [Range(0, 10000)]
        public decimal Food { get; set; }

        [Range(0, 10000)]
        public decimal Housing { get; set; }

        [Range(0, 10000)]
        public decimal Transport { get; set; }

        [Range(0, 10000)]
        public decimal Leisure { get; set; }
    }
}
