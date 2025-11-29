namespace NomadBuddy00.Models
{
    public class TravelerType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSystemType { get; set; } = true;
        // Navigation
        public ICollection<TravelerQuestion> Questions { get; set; }
        public ICollection<TravelerTypeScore> Scores { get; set; }
        public ICollection<TravelerPreference> SuggestedPreferences { get; set; } = new List<TravelerPreference>();

    }
}
