namespace NomadBuddy00.Models
{
    public class CollabSpace
    {
        public int Id { get; set; }
        public int NomadMatchId { get; set; }
        public NomadMatch NomadMatch { get; set; }
        public string SharedGoal { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsArchived { get; set; } = false;

        public ICollection<CollabIdea> Ideas { get; set; } = new List<CollabIdea>();
/*        public ICollection<CollabSkillset> Skillsets { get; set; }
        public ICollection<CollabTask> Tasks { get; set; }
        public ICollection<CollabResource> Resources { get; set; }
        public ICollection<CollabFeedback> Feedbacks { get; set; }
        public ICollection<CollabAchievement> Achievements { get; set; }*/
    }
}
