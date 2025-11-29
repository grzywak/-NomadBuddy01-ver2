using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IFriendsProfileRepository
    {
        Task<FriendsProfile?> GetByNomadIdAsync(string nomadId);
        Task<FriendsProfile?> GetByIdAsync(int id);
        Task AddAsync(FriendsProfile profile);
        Task UpdateAsync(FriendsProfile profile);
        Task<bool> ExistsAsync(int id);
        Task<bool> HasFriendsProfileAsync(string nomadId);
    }
}
