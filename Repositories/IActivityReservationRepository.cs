using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IActivityReservationRepository
    {
        Task<IEnumerable<ActivityReservation>> GetAllAsync();
        Task<ActivityReservation?> GetActivityByIdAsync(int id);
        Task<IEnumerable<ActivityReservation>> GetActivityByNomadIdAsync(string nomadId);
        Task AddAsync(ActivityReservation reservation);
        Task UpdateAsync(ActivityReservation reservation);
        Task DeleteAsync(int id);
        Task<bool> NomadExistsAsync(string userId);

    }
}
