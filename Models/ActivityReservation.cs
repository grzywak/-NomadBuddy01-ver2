using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class ActivityReservation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activity Activity { get; set; } = null!;

        [Required]
        public string NomadId { get; set; }

        [ForeignKey("NomadId")]
        public virtual Nomad Nomad { get; set; } = null!;

        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Status")]
        public ReservationStatus Status { get; set; } = ReservationStatus.Pending;
    }

}