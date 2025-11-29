using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.Enums
{
    public enum ReservationStatus
    {
        [Display(Name = "Pending")]
        Pending,

        [Display(Name = "Confirmed")]
        Confirmed,

        [Display(Name = "Cancelled")]
        Cancelled,

        [Display(Name = "Completed")]
        Completed
    }
}
