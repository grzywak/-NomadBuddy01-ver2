namespace NomadBuddy00.Models
{
    public class CollabIdea
    {
        public int Id { get; set; }
        public int CollabSpaceId { get; set; }
        public CollabSpace CollabSpace { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Likes { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
