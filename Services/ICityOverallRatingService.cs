namespace NomadBuddy00.Services
{
    public interface ICityOverallRatingService
    {
        Task<double> GetAverageSafetyScoreAsync(int cityId);
        Task<double> GetAverageEntertainmentScoreAsync(int cityId);
        Task<double> GetAverageHealthcareScoreAsync(int cityId);
        Task<double> GetAverageTransportScoreAsync(int cityId);
        Task CalculateAndStoreOverallScoreAsync(int cityId, string nomadId);
    }
}
