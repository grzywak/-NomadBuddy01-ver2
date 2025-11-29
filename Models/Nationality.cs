using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } // "Poland"
        [Required]
        public string IsoCode { get; set; } // "PL", "US"
        public ICollection<Nomad> Nomads { get; set; }
        public ICollection<VisaPolicy> VisaPolicies { get; set; }
    }
}
