using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class BuddySupportRequestRepository : IBuddySupportRequestRepository
    {
        private readonly AppDbContext _context;

        public BuddySupportRequestRepository(AppDbContext context)
        {
            _context = context;   
        }
        public async Task AddAsync(BuddySupportRequest supportRequest)
        {
            _context.Add(supportRequest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int supportId)
        {
            var support = await _context.BuddySupportRequests.FindAsync(supportId);

            if (support != null)
            {
                _context.Remove(support);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BuddySupportRequest>> GetAllAsync()
        {
            return await _context.BuddySupportRequests.ToListAsync();
        }

        public async Task<BuddySupportRequest> GetByIdAsync(int supportId)
        {
            return await _context.BuddySupportRequests
                .FirstOrDefaultAsync(x => x.Id == supportId);
        }

        public async Task<IEnumerable<BuddySupportRequest>> GetRequestsByNomadAsync(string nomadId)
        {
            return await _context.BuddySupportRequests
                .Where(request => request.NomadId == nomadId)
                 .ToListAsync();
        }

        public async Task<bool> HasPendingRequestAsync(int supportId, string nomadId)
        {
            return await _context.BuddySupportRequests.AnyAsync(r =>
                     r.BuddySupportId == supportId &&
                     r.NomadId == nomadId &&
                     r.RequestStatus == BuddySupportRequestStatus.Pending);

        }

        public async Task UpdateAsync(BuddySupportRequest supportRequest)
        {
            _context.Update(supportRequest);
            await _context.SaveChangesAsync();
        }
    }
}
