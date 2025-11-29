using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class NomadCompatibilityScore
    {
        public int Id { get; set; }

        public string NomadId { get; set; }          // kto patrzy
        public string TargetNomadId { get; set; }    // na kogo patrzy

        public MatchMode Mode { get; set; }

        public double Score { get; set; }

        [ForeignKey("NomadId")]
        public Nomad Nomad { get; set; }

        [ForeignKey("TargetNomadId")]
        public Nomad TargetNomad { get; set; }
    }

}
