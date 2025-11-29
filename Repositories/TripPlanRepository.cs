using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class TripPlanRepository : ITripPlanRepository
    {
        private readonly AppDbContext _context;

        public TripPlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TripPlan>> GetTripPlansForNomadAsync(string nomadId)
        {
            return await _context.TripPlans
                .Include(tp => tp.TripStops)
                .ThenInclude(ts => ts.Country)
                .Where(tp => tp.NomadId == nomadId)
                .ToListAsync();
        }

        public async Task<TripPlan?> GetTripPlanWithStopsAsync(int tripPlanId)
        {
            return await _context.TripPlans
                .Include(tp => tp.TripStops)
                    .ThenInclude(ts => ts.Country)
                .Include(tp => tp.TripStops)
                    .ThenInclude(ts => ts.City)
                .Include(tp => tp.TripStops)
                    .ThenInclude(ts => ts.VisaPolicy)
                .FirstOrDefaultAsync(tp => tp.Id == tripPlanId);
        }

        public async Task CreateTripPlanAsync(TripPlan tripPlan)
        {
            _context.TripPlans.Add(tripPlan);
            await _context.SaveChangesAsync();
        }

        public async Task AddTripStopAsync(TripStop tripStop)
        {
            _context.TripStops.Add(tripStop);
            await _context.SaveChangesAsync();
        }
    }
}
