namespace NomadBuddy00.Models
{
    public class NomadPreference
    {
        public int Id { get; set; }
        public string NomadId { get; set; } = null!;
        public Nomad Nomad { get; set; } = null!;
        public int TravelerPreferenceId { get; set; }
        public TravelerPreference TravelerPreference { get; set; } = null!;
    }

}
