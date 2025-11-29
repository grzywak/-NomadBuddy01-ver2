using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class NomadMatchRepository : INomadMatchRepository
    {
        private readonly AppDbContext _context;

        public NomadMatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<NomadMatch>> GetMatchesForUserAsync(string userId, MatchMode mode)
        {
            return await _context.NomadMatches
                .Where(m =>
                    (m.Nomad1Id == userId || m.Nomad2Id == userId) &&
                    m.Mode == mode)
                .Include(m => m.Nomad1.User)
                .Include(m => m.Nomad2.User)
                .ToListAsync();
        }
    }
}
