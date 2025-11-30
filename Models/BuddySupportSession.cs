namespace NomadBuddy00.Models
{
    public class BuddySupportSession
    {
        public int Id { get; set; }

        //po zaakceptowaniu request
        public int BuddySupportRequestId { get; set; }
        public BuddySupportRequest BuddySupportRequest { get; set; }

        public string NomadId { get; set; }
        public Nomad Nomad { get; set; }
        public string BuddyId { get; set; }
        public Buddy Buddy { get; set; }
        public SessionStatus SessionStatus { get; set; }

        //opcjonalnie notatki
        public string? OptionalNotes { get; set; }
    }
}
