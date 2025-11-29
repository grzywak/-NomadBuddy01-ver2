using NomadBuddy00.Models;
using System.ComponentModel.DataAnnotations;

namespace NomadBuddy00.ViewModels
{
    public class TravelerQuizViewModel
    {
        public List<TravelerQuizQuestionViewModel> Questions { get; set; } = new();
    }

    public class TravelerQuizQuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;

        [Range(1, 5)]
        public int Answer { get; set; }
    }
}
