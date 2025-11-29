using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface INomadRepository
    {
        Task<Nomad?> GetByIdAsync(string userId);
        Task UpdateAsync(Nomad nomad);
        Task<List<Nomad>> GetDiscoverNomadsAsync(string currentUserId, MatchMode mode);
        Task<bool> HasTravelerTypeScoreAsync(string nomadId);
    }
}
