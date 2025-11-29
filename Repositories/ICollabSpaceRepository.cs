using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface ICollabSpaceRepository
    {
            Task<CollabSpace?> GetByMatchIdAsync(int matchId);
            Task CreateAsync(CollabSpace collabSpace);
            Task AddIdeaAsync(int collabSpaceId, string content);
            Task SaveChangesAsync();
    }
}
