using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface ITripPinRepository
    {
        Task<List<TripPin>> GetByMatchId(int matchId);
        Task AddAsync(TripPin tripPin); 
        Task UpdateStatusAsync(int pinId, TripPinStatus newPinStatus);
    }
}
