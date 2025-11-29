using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class CityCostOfLivingRating
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public bool IsMonthly { get; set; }
        public TravelBudget BudgetLevel { get; set; }
        public decimal Food { get; set; }
        public decimal Housing { get; set; }
        public decimal Transport { get; set; }
        public decimal Leisure { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
