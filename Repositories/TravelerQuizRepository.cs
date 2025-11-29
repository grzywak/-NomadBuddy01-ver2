using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class TravelerQuizRepository : ITravelerQuizRepository
    {
        private readonly AppDbContext _context;

        public TravelerQuizRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TravelerQuestion>> GetAllQuestionsAsync()
        {
            return await _context.TravelerQuestions.Include(q => q.TravelerType).ToListAsync();
        }
        public async Task SaveAnswersAsync(string nomadId, List<TravelerAnswer> answers)
        {
            var existing =  _context.TravelerAnswers.Where(a => a.NomadId == nomadId);
            _context.TravelerAnswers.RemoveRange(existing);

            await _context.TravelerAnswers.AddRangeAsync(answers);
            await _context.SaveChangesAsync();                            
        }

        public async Task<List<TravelerTypeScore>> CalculateScoresAsync(string nomadId)
        {
            var answers = await _context.TravelerAnswers
                          .Include(a => a.TravelerQuestion)
                          .Where(a => a.NomadId == nomadId)
                          .ToListAsync();

            var scores =  answers
                         .GroupBy(a => a.TravelerQuestion.TravelerTypeId)
                         .Select( g => new TravelerTypeScore 
                         {
                            TravelerTypeId = g.Key,
                            NomadId = nomadId,
                            Score = g.Sum(a => a.Value)
                         }).ToList();

            var existing = _context.TravelerTypeScores.Where(a => a.NomadId == nomadId);
            _context.TravelerTypeScores.RemoveRange(existing);
            await _context.TravelerTypeScores.AddRangeAsync(scores); 
            await _context.SaveChangesAsync();

            return scores;
        }


        public async Task<List<TravelerTypeScore>> GetScoresAsync(string nomadId)
        {
            return await _context.TravelerTypeScores
                .Include(s  => s.TravelerType)
                .Where(s => s.NomadId == nomadId)
                .ToListAsync();   
        }

    }
}
