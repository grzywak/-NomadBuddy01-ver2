using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface ITripPlanRepository
    {
        Task<List<TripPlan>> GetTripPlansForNomadAsync(string nomadId);
        Task<TripPlan?> GetTripPlanWithStopsAsync(int tripPlanId);
        Task CreateTripPlanAsync(TripPlan tripPlan);
        Task AddTripStopAsync(TripStop tripStop);
    }
}
