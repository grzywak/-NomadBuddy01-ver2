using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface ITravelerQuizRepository
    {
        Task<List<TravelerQuestion>> GetAllQuestionsAsync();
        Task SaveAnswersAsync(string nomadId, List<TravelerAnswer> answers);
        Task<List<TravelerTypeScore>> CalculateScoresAsync(string nomadId);
        Task<List<TravelerTypeScore>> GetScoresAsync(string nomadId);
    }
}
