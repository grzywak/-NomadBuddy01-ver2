using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } // "Poland"
        public string IsoCode { get; set; } // "PL"
        public Continent Continent { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<VisaPolicy> VisaPolicies { get; set; }
    }
}
