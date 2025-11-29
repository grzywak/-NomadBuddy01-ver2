namespace NomadBuddy00.ViewModels
{
    public class NomadDashboardViewModel
    {
        public bool HasCompletedQuiz { get; set; }
        public bool HasSetPreferences { get; set; }
        public bool HasCreatedFriendsProfile { get; set; }
        public string FirstName { get; set; } = "Nomad";
    }
}
