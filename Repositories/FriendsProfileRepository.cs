using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class FriendsProfileRepository : IFriendsProfileRepository
    {
        private readonly AppDbContext _context;

        public FriendsProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FriendsProfile?> GetByNomadIdAsync(string nomadId)
        {
            return await _context.FriendsProfiles
                .Include(fp => fp.Nomad)
                .FirstOrDefaultAsync(fp => fp.NomadId == nomadId);
        }

        public async Task<FriendsProfile?> GetByIdAsync(int id)
        {
            return await _context.FriendsProfiles
                .Include(fp => fp.Nomad)
                .FirstOrDefaultAsync(fp => fp.Id == id);
        }

        public async Task AddAsync(FriendsProfile profile)
        {
            _context.FriendsProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FriendsProfile profile)
        {
            _context.FriendsProfiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.FriendsProfiles.AnyAsync(p => p.Id == id);
        }
        public async Task<bool> HasFriendsProfileAsync(string nomadId)
        {
            return await _context.FriendsProfiles.AnyAsync(fp => fp.NomadId == nomadId);
        }
    }
}
