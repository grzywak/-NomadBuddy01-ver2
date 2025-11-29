namespace NomadBuddy00.Models
{
    public class CityHealthcareRating
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public int AvailabilityScore { get; set; }     // 1–5
        public decimal AvgInsuranceMonthlyCost { get; set; }
        public decimal AvgDoctorVisitCost { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
