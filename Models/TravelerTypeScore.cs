namespace NomadBuddy00.Models
{
    public class TravelerTypeScore
    {
        public int Id { get; set; }

        public int TravelerTypeId { get; set; }
        public TravelerType TravelerType { get; set; }

        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }

        public int Score { get; set; } // range 2stars to 10stars max? if all questions answered
    }
}
