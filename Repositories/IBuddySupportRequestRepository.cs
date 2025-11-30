using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IBuddySupportRequestRepository
    {
        Task<BuddySupportRequest> GetByIdAsync(int supportId);
        Task<IEnumerable<BuddySupportRequest>> GetAllAsync();
        Task DeleteAsync(int supportId);
        Task AddAsync(BuddySupportRequest supportRequest);
        Task UpdateAsync(BuddySupportRequest supportRequest);

        //do wyszukiwania requests po nomadach 
        Task<IEnumerable<BuddySupportRequest>> GetRequestsByNomadAsync(string nomadId);
    }
}
