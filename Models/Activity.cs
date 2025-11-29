using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.Models
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        public int MaxParticipants { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Required]
        public string CreatedById { get; set; } = string.Empty;

        [ForeignKey(nameof(CreatedById))]
        public virtual ApplicationUser CreatedBy { get; set; } = null!;

        // One-to-Many: Activity can have multiple Assignments (Buddies leading)
        public virtual ICollection<ActivityAssignment>? ActivityAssignments { get; set; } = new List<ActivityAssignment>();

        // One-to-Many: Nomads can reserve this Activity
        public virtual ICollection<ActivityReservation>? Reservations { get; set; } = new List<ActivityReservation>();
    }
}