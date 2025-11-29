namespace NomadBuddy00.ViewModels
{
    public class TravelerQuizResultViewModel
    {
        public List<TravelerTypeScoreViewModel> Scores { get; set; } = new();
    }

    public class TravelerTypeScoreViewModel
    {
        public string TravelerTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Score { get; set; } // 2–10
    }
}
