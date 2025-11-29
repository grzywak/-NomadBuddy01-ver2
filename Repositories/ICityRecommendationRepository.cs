using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Repositories
{
    public interface ICityRecommendationRepository
    {
        Task<List<City>> GetAllCitiesAsync();
        Task<List<City>> GetAllCitiesWithRatingsAsync();
        Task<City?> GetCityDetailsAsync(int cityId);
        Task<CityDetailsViewModel> GetCityDetailsWithRatingsAsync(int cityId, string nomadId);
        Task<List<CityTag>> GetAllCityTagsAsync();
        Task AddTagVoteAsync(CityTagVote vote);
        Task<List<CityRecommendationResult>> GetTopRecommendedCitiesAsync(string nomadId);
        Task AddOrUpdateCityRatingAsync(CityRatingViewModel model, string nomadId);
        Task<List<City>> GetCitiesByCountryAsync(int countryId);
        Task<List<CityRecommendationResult>> GetFilteredRecommendedCitiesAsync(
            string nomadId,
            TravelBudget? budget,
            Continent? continent,
            int? countryId
        );
        Task<List<CityRecommendationResult>> GetRecommendedCitiesForNomadTypeAsync(NomadType nomadType, int count = 5);


    }
}
