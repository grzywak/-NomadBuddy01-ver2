using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface INomadMatchRepository
    {
        Task<List<NomadMatch>> GetMatchesForUserAsync(string userId, MatchMode mode);
    }
}
