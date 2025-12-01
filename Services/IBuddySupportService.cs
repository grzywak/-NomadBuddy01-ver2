using NomadBuddy00.Models;

namespace NomadBuddy00.Services
{
    public interface IBuddySupportService
    {
        Task<IEnumerable<BuddySupport>> GetAllActiveAsync();
        Task<BuddySupport?> GetDetailsAsync(int supportId);
        Task<bool> CreateAsync(BuddySupport model);
    }
}
