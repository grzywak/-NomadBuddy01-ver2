using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IBuddySupportRepository
    {
        Task<BuddySupport> GetByIdAsync(int id);
        Task<IEnumerable<BuddySupport>> GetAllAsync();
        Task AddAsync(BuddySupport support);
        Task UpdateAsync(BuddySupport s);
        Task DeleteAsync(int id);

    }
}
