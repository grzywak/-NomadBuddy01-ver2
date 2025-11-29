namespace NomadBuddy00.Models
{
    public class BuddySupportAssignment
    {
        public int Id { get; set; }
        public int BuddySupportId { get; set; }
        public BuddySupport BuddySupport { get; set; }

        public string BuddyId { get; set; }
        public Buddy Buddy { get; set; }

        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
