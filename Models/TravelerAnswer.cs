namespace NomadBuddy00.Models
{
    public class TravelerAnswer
    {
        public int Id { get; set; }
        public int TravelerQuestionId { get; set; }
        public TravelerQuestion TravelerQuestion { get; set; }  
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public int Value { get; set; } // 1-5 stars
    }
}
