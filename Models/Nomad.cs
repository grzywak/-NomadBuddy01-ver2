using Microsoft.AspNetCore.Identity;
using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class Nomad
    {
        [Key]
        public string UserId { get; set; } // Klucz główny = Id z ApplicationUser
        // Powiązanie z użytkownikiem
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public Language PreferredLanguage { get; set; } = Language.English;
        public TravelBudget TravelBudget { get; set; }
        public NomadType NomadType { get; set; } = NomadType.RemoteWorker;
        // Current Location (optional)
        public int? CurrentCountryId { get; set; }
        [ForeignKey("CurrentCountryId")]
        public virtual Country? CurrentCountry { get; set; }
        public int? CurrentCityId { get; set; }
        [ForeignKey("CurrentCityId")]
        public virtual City? CurrentCity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public MatchMode SelectedMode { get; set; } = MatchMode.Friends;
        public virtual FriendsProfile? FriendsProfile { get; set; }
        public virtual NetworkingProfile? NetworkingProfile { get; set; }

        // Many-to-Many: Nomads can reserve multiple Activities
        public virtual ICollection<NomadInterest> Interests { get; set; } = new List<NomadInterest>();
        public virtual ICollection<ActivityReservation> Reservations { get; set; } = new List<ActivityReservation>();
        public virtual ICollection<NomadPreference> Preferences { get; set; } = new List<NomadPreference>();

    }
}
