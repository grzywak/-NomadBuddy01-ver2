using NomadBuddy00.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class NomadLike
    {
        public int Id { get; set; }

        public string LikerId { get; set; }           // kto polubił
        public string TargetId { get; set; }          // kogo polubił

        public MatchMode Mode { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("LikerId")]
        public Nomad Liker { get; set; }

        [ForeignKey("TargetId")]
        public Nomad Target { get; set; }
    }

}
