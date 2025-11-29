using NomadBuddy00.Models;

namespace NomadBuddy00.ViewModels
{
    public class ActivityIndexViewModel
    {
        public IEnumerable<Activity> AllActivities { get; set; } = new List<Activity>();
        public IEnumerable<Activity> UserActivities { get; set; } = new List<Activity>();
        public IEnumerable<ActivityReservation> UserReservations { get; set; } = new List<ActivityReservation>();
    }
}