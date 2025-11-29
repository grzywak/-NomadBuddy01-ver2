namespace NomadBuddy00.Models
{
    public class TravelerQuestion
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int TravelerTypeId { get; set; }
        public TravelerType TravelerType { get; set; }
        public ICollection<TravelerAnswer> Answers { get; set; }
    }
}
