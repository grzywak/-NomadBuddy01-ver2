using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class NomadProfileEditViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int NationalityId { get; set; }

        public TravelBudget TravelBudget { get; set; }

        public Language PreferredLanguage { get; set; }
        [Required]
        public NomadType NomadType { get; set; }

        public int? CurrentCityId { get; set; }        
        public int? CurrentCountryId { get; set; }



        //TravelGroupPreference
    }
}
