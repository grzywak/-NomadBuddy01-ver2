using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class CollabSpaceRepository : ICollabSpaceRepository
    {
        private readonly AppDbContext _context;

        public CollabSpaceRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(CollabSpace collabSpace)
        {
            _context.AddAsync(collabSpace);
            await _context.SaveChangesAsync();
        }

        public async Task<CollabSpace?> GetByMatchIdAsync(int matchId)
        {
            return await _context.CollabSpaces
                .Include(c => c.Ideas)
                .FirstOrDefaultAsync(c => c.NomadMatchId == matchId);
        }
        public async Task AddIdeaAsync(int collabSpaceId, string content)
        {
            var idea = new CollabIdea
            {
                CollabSpaceId = collabSpaceId,
                Content = content
            };

            _context.AddAsync(idea);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
