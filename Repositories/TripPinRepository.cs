using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class TripPinRepository : ITripPinRepository
    {
        private readonly AppDbContext _context;

        public TripPinRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TripPin tripPin)
        {
            if (!await _context.NomadMatches.AnyAsync(m => m.Id == tripPin.NomadMatchId))
            {
                throw new Exception("NomadMatchId is invalid – no such match exists in DB.");
            }

            _context.TripPins.Add(tripPin);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TripPin>> GetByMatchId(int matchId)
        {
            return await _context.TripPins
                         .Where(p => p.NomadMatchId == matchId)
                         .ToListAsync();
        }

        public async Task UpdateStatusAsync(int pinId, TripPinStatus newPinStatus)
        {
            var pin = await _context.TripPins.FindAsync(pinId);

            if (pin != null)
            { 
                pin.TripPinStatus = newPinStatus;
                await _context.SaveChangesAsync();
            }
        }
    }
}
