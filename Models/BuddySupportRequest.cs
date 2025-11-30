using NomadBuddy00.Enums;

namespace NomadBuddy00.Models
{
    public class BuddySupportRequest
    {
        public int Id { get; set; }
        public int BuddySupportId { get; set; }
        public BuddySupport BuddySupport { get; set; }
        public string NomadId { get; set;  }
        public Nomad Nomad { get; set;  }

        public DateTime RequestTime = DateTime.UtcNow;

        //opcjonalnie wiadomosc
        public string? Message { get; set; }

        public BuddySupportRequestStatus RequestStatus { get; set; } = BuddySupportRequestStatus.Pending;
    }
}
