using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.Models
{
    public class ActivityAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; } = null!;

        [Required]
        public string BuddyId { get; set; }

        [ForeignKey("BuddyId")]
        public virtual Buddy Buddy { get; set; } = null!;

        public bool IsLeadBuddy { get; set; } // Similar to Lead Coach
        public decimal Compensation { get; set; } // Payment to Buddy
    }
}

