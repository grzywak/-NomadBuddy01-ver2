namespace NomadBuddy00.Models
{
    public class TravelerPreference
    {
        public int Id { get; set; }
        public string PreferenceKey { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public ICollection<TravelerType> SuggestedForTypes { get; set; } = new List<TravelerType>();
    }
}
