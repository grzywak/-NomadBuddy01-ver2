using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class NomadPreferenceRepository : INomadPreferenceRepository
    {
        private readonly AppDbContext _context;

        public NomadPreferenceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TravelerPreference>> GetAllPreferencesAsync()
        {
            return await _context.TravelerPreferences.ToListAsync();
        }

        public async Task<List<int>> GetSelectedPreferenceIdsAsync(string nomadId)
        {
            return await _context.NomadPreferences
                            .Where(np => np.NomadId == nomadId)
                            .Select(np => np.TravelerPreferenceId)
                            .ToListAsync();
        }

        public async Task<List<TravelerPreference>> GetSuggestedPreferencesForTravelerTypeAsync(int travelerTypeId)
        {
            return await _context.TravelerPreferences
                        .Where(p => p.SuggestedForTypes.Any(t => t.Id == travelerTypeId))
                        .ToListAsync();
        }

        public async Task SavePreferencesAsync(string nomadId, List<int> selectedPreferenceIds)
        {
            var existing = _context.NomadPreferences.Where(np => np.NomadId == nomadId);
            _context.NomadPreferences.RemoveRange(existing);

            var newPrefs = selectedPreferenceIds.Select(pid => new NomadPreference
            {
                NomadId = nomadId,
                TravelerPreferenceId = pid
            });

            await _context.NomadPreferences.AddRangeAsync(newPrefs);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> HasPreferencesAsync(string nomadId)
        {
            return await _context.NomadPreferences.AnyAsync(p => p.NomadId == nomadId);
        }

    }
}
