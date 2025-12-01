using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class BuddySupportRatingRepository : IBuddySupportRatingRepository
    {
        private readonly AppDbContext _context;

        public BuddySupportRatingRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(BuddySupportRating rating)
        {
            _context.BuddySupportRatings.Add(rating);
            await _context.SaveChangesAsync();
           
        }
        public async Task<BuddySupportRating> GetByIdAsync(int Id)
        {
            return await _context.BuddySupportRatings
                .FirstOrDefaultAsync(rating => rating.Id == Id);
        }

        public async Task DeleteAsync(int ratingId)
        {
            var rating = await _context.BuddySupportRatings.FindAsync(ratingId);

            if (rating != null) 
            {
                    _context.BuddySupportRatings.Remove(rating);
                await _context.SaveChangesAsync();
                
            }
        }

        public async Task<IEnumerable<BuddySupportRating>> GetAllAsync()
        {
            
            return await _context.BuddySupportRatings.ToListAsync();
        }


        public async Task<IEnumerable<BuddySupportRating>> GetRatingsForBuddyAsync(string buddyId)
        {
            return await _context.BuddySupportRatings
                  .Where(r => r.BuddyId == buddyId)
                  .ToListAsync();

        }

        public async Task<IEnumerable<BuddySupportRating>> GetRatingsForSessionAsync(int sessionId)
        {
            return await _context.BuddySupportRatings
                  .Where(r => r.BuddySupportSessionId == sessionId)
                  .ToListAsync();
        }

        public async Task UpdateAsync(BuddySupportRating rating)
        {
            _context.BuddySupportRatings.Update(rating);
            await _context.SaveChangesAsync();
        }
    }
}
