using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface INomadPreferenceRepository
    {
        Task<List<TravelerPreference>> GetAllPreferencesAsync();
        Task<List<TravelerPreference>> GetSuggestedPreferencesForTravelerTypeAsync(int travelerTypeId);
        Task<List<int>> GetSelectedPreferenceIdsAsync(string nomadId);
        Task SavePreferencesAsync(string nomadId, List<int> selectedPreferenceIds);
        Task<bool> HasPreferencesAsync(string nomadId);
    }
}
