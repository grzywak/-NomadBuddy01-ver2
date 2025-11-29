using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class NomadRepository : INomadRepository
    {
        private readonly AppDbContext _context;

        public NomadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Nomad?> GetByIdAsync(string userId)
        {
            return await _context.Nomads
                .Include(n => n.User)
                .Include(n => n.Interests)
                .FirstOrDefaultAsync(n => n.UserId == userId);
        }
        public async Task UpdateAsync(Nomad nomad)
        {
            _context.Nomads.Update(nomad);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Nomad>> GetDiscoverNomadsAsync(string currentUserId, MatchMode mode)
        {
            // Pobierz ID nomadów których obecny użytkownik już polubił w danym trybie
            var likedIds = await _context.NomadLikes
                .Where(l => l.LikerId == currentUserId && l.Mode == mode)
                .Select(l => l.TargetId)
                .ToListAsync();

            // Zwróć tylko tych użytkowników którzy:
            // - są w danym trybie
            // - nie są aktualnym użytkownikiem
            // - nie zostali jeszcze przez niego polubieni
            return await _context.Nomads
                .Include(n => n.User)
                .Where(n => n.UserId != currentUserId && !likedIds.Contains(n.UserId))
                .ToListAsync();
        }
        public async Task<bool> HasTravelerTypeScoreAsync(string nomadId)
        {
            return await _context.TravelerTypeScores.AnyAsync(s => s.NomadId == nomadId);
        }
    }
}
