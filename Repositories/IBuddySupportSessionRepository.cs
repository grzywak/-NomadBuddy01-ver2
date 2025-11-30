using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IBuddySupportSessionRepository
    {
        Task<BuddySupportSession> GetByIdAsync(int Id);
        Task<IEnumerable<BuddySupportSession>> GetAllAsync();
        Task DeleteAsync(int sessionId);
        Task AddAsync(BuddySupportSession session);
        Task UpdateAsync(BuddySupportSession session);

        //do wyszukiwania sessions po nomadach lub buddy
        Task<IEnumerable<BuddySupportSession>> GetSessionsByNomadAsync(string nomadId);
        Task<IEnumerable<BuddySupportSession>> GetSessionsByBuddyAsync(string buddyId);
    }
}
