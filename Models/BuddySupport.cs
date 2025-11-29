using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class BuddySupport
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BuddySupportCategory Category { get; set; }

        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;
        public BuddySupportDeliveryType DeliveryType { get; set; }

        //Location optional
        public int? CityId { get; set; }
        public City? City { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<BuddySupportAssignment> BuddySupportAssignments { get; set; }

    }
}
