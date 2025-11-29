using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadBuddy00.Models
{
    public class FriendsProfile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomadId { get; set; }
        [ForeignKey("NomadId")]
        public Nomad? Nomad { get; set; }
        public string Bio { get; set; }
        public string FunFact { get; set; }
        public bool IsPartyAnimal { get; set; }
    }
}
