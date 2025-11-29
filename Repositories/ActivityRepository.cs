using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class ActivityRepository : IRepository<Activity>
    {
        private readonly AppDbContext _context;
        public ActivityRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Activity entity)
        {
            _context.Activities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _context.Activities
                .Include(a => a.CreatedBy) // Pobiera dane twórcy aktywności
                .ToListAsync();
        }

        public async Task<Activity> GetAsync(int id)
        {
            return await _context.Activities
                 .Include(a => a.CreatedBy)
                 .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Activity entity)
        {
            _context.Activities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
