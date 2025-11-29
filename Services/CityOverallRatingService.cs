using NomadBuddy00.Repositories;

namespace NomadBuddy00.Services
{
    public class CityOverallRatingService : ICityOverallRatingService
    {
        private readonly ICityExtendedRatingRepository _ratingRepo;

        public CityOverallRatingService(ICityExtendedRatingRepository ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }

        public async Task<double> GetAverageSafetyScoreAsync(int cityId)
        {
            var stats = await _ratingRepo.GetSafetyStatsAsync(cityId);
            return (stats.AvgDaySafety + stats.AvgNightSafety) / 2.0;
        }

        public async Task<double> GetAverageEntertainmentScoreAsync(int cityId)
        {
            var stats = await _ratingRepo.GetEntertainmentStatsAsync(cityId);
            return (stats.AvgNightlifeScore + stats.AvgEventsFrequencyScore + stats.AvgYouthVibeScore) / 3.0;
        }

        public async Task<double> GetAverageHealthcareScoreAsync(int cityId)
        {
            var stats = await _ratingRepo.GetHealthcareStatsAsync(cityId);
            return stats.AvgAvailabilityScore;
        }

        public async Task<double> GetAverageTransportScoreAsync(int cityId)
        {
            var stats = await _ratingRepo.GetTransportStatsAsync(cityId);
            return (stats.AvgPublicTransportScore + stats.AvgNightTransportScore +
                    stats.AvgWalkabilityScore + stats.AvgBikeFriendlyScore) / 4.0;
        }

        public async Task CalculateAndStoreOverallScoreAsync(int cityId, string nomadId)
        {
            double total = 0;
            int count = 0;

            var safety = await GetAverageSafetyScoreAsync(cityId);
            if (safety > 0)
            {
                total += safety;
                count++;
            }

            var entertainment = await GetAverageEntertainmentScoreAsync(cityId);
            if (entertainment > 0)
            {
                total += entertainment;
                count++;
            }

            var healthcare = await GetAverageHealthcareScoreAsync(cityId);
            if (healthcare > 0)
            {
                total += healthcare;
                count++;
            }

            var transport = await GetAverageTransportScoreAsync(cityId);
            if (transport > 0)
            {
                total += transport;
                count++;
            }

            if (count == 0)
            {
                return;
            }

            var overall = total / count;

            await _ratingRepo.SaveOrUpdateOverallRatingAsync(cityId, overall, nomadId);
        }
    }
}
