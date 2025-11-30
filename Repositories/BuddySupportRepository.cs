using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;
using SQLitePCL;

namespace NomadBuddy00.Repositories
{
    public class BuddySupportRepository : IBuddySupportRepository
    {
        private readonly AppDbContext _context;

        public BuddySupportRepository(AppDbContext context)
        {
            _context = context;   
        }
        public async Task<BuddySupport> GetByIdAsync(int id)
        {
           return await _context.BuddySupports
                .FirstOrDefaultAsync(support => support.Id == id);
        }
        public async Task AddAsync(BuddySupport support)
        {
            _context.BuddySupports.Add(support);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supportToDelete = await _context.BuddySupports.FindAsync(id);

            if (supportToDelete != null)
            {
                _context.BuddySupports.Remove(supportToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BuddySupport>> GetAllAsync()
        {
            return await _context.BuddySupports.ToListAsync();
        }


        public async Task UpdateAsync(BuddySupport s)
        {
            _context.BuddySupports.Update(s);
            await _context.SaveChangesAsync();
        }
    }
}
