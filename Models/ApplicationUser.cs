using Microsoft.AspNetCore.Identity;
using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        // Relacje do Nomad i Buddy (Jeden użytkownik może być jednym z nich)
        public virtual Nomad? Nomad { get; set; }
        public virtual Buddy? Buddy { get; set; }
    }
}
