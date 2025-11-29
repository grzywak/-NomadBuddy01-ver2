using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class NomadInterest
    {
        public int Id { get; set; }

        public string NomadId { get; set; }

        [ForeignKey("NomadId")]
        public Nomad Nomad { get; set; }

        public string Tag { get; set; }
    }

}
