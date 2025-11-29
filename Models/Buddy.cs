using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class Buddy
    {
        [Key]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string Specialization { get; set; } = "General Guide";
        public int YearsOfExperience { get; set; } = 0;
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public virtual ICollection<BuddySupportAssignment> BuddySupportAssignments { get; set; } = new List<BuddySupportAssignment>();
        public virtual ICollection<ActivityAssignment> ActivityAssignments { get; set; } = new List<ActivityAssignment>();
    }
}
