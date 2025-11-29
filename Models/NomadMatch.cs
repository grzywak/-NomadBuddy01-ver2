using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class NomadMatch
    {
        public int Id { get; set; }

        public string Nomad1Id { get; set; }
        public string Nomad2Id { get; set; }

        public MatchMode Mode { get; set; }  // Friends / Networking
        public DateTime MatchedAt { get; set; } = DateTime.UtcNow;
        public double FinalMatchScore { get; set; } = 0; // Można ustawić jako średnią ze scoringu

        [ForeignKey("Nomad1Id")]
        public Nomad Nomad1 { get; set; }

        [ForeignKey("Nomad2Id")]
        public Nomad Nomad2 { get; set; }
    }


}
