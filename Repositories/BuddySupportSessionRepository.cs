using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class BuddySupportSessionRepository : IBuddySupportSessionRepository
    {
        private readonly AppDbContext _context;

        public BuddySupportSessionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(BuddySupportSession session)
        {
            _context.BuddySupportSessions.Add(session);
            await _context.SaveChangesAsync();
        }
        public async Task<BuddySupportSession> GetByIdAsync(int Id)
        {
             return await _context.BuddySupportSessions
                .FirstOrDefaultAsync(session => session.Id == Id);
        }


        public async Task DeleteAsync(int sessionId)
        {
            var sessionToDelete = await _context.BuddySupportSessions.FindAsync(sessionId);

            if (sessionToDelete != null)
            {
                 _context.BuddySupportSessions.Remove(sessionToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BuddySupportSession>> GetAllAsync()
        {
            return await _context.BuddySupportSessions.ToListAsync();
        }

        public async Task<IEnumerable<BuddySupportSession>> GetSessionsByBuddyAsync(string buddyId)
        {
            return await _context.BuddySupportSessions
                 .Where(s => s.BuddyId == buddyId).ToListAsync();
        }

        public async Task<IEnumerable<BuddySupportSession>> GetSessionsByNomadAsync(string nomadId)
        {
            return await _context.BuddySupportSessions
                 .Where(s => s.NomadId == nomadId).ToListAsync();
        }

        public async Task UpdateAsync(BuddySupportSession session)
        {
            _context.BuddySupportSessions.Update(session);
            await _context.SaveChangesAsync();
        }
    }
}
