namespace NomadBuddy00.Models
{
    public class BuddySupportRating
    {
        public int Id { get; set; }
        public int BuddySupportSessionId { get; set; }
        public BuddySupportSession BuddySupportSession { get; set; }

        //kto komu wystawia
        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public string BuddyId { get; set; }
        public Buddy Buddy { get; set; }
        public int Rating { get; set; }// 1-5?
        public string? Comment { get; set; }
        public DateTime RatedOnDate { get; set; } = DateTime.UtcNow;
    }
}
