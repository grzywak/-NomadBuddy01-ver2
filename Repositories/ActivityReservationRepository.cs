using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class ActivityReservationRepository : IActivityReservationRepository
    {
        private readonly AppDbContext _context;

        public ActivityReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ActivityReservation reservation)
        {
            _context.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<ActivityReservation>> GetAllAsync()
        {
            return await _context.ActivityReservations
                         .Include(r => r.Activity)
                         .Include(n => n.Nomad)
                         .ToListAsync();
        }

        public async Task<ActivityReservation?> GetActivityByIdAsync(int activityId)
        {
            return await _context.ActivityReservations
                .Include(r => r.Activity)
                .Include(n => n.Nomad)
                .FirstOrDefaultAsync(r => r.Id == activityId);
        }

        public async Task<IEnumerable<ActivityReservation>> GetActivityByNomadIdAsync(string nomadId)
        {
            return await _context.ActivityReservations
                         .Where(n => n.NomadId == nomadId)
                         .Include(r => r.Activity)
                         .ToListAsync();
        }

        public Task UpdateAsync(ActivityReservation reservation)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> NomadExistsAsync(string userId)
        {
            return await _context.Nomads.AnyAsync(n => n.UserId == userId);
        }

    }
}
