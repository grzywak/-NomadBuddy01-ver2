using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Repositories
{
    public interface ICityExtendedRatingRepository
    {
        //CitySafetyRating
        Task<CitySafetyRating?> GetUserSafetyRatingAsync(int cityId, string nomadId);
        Task<CitySafetyStatsViewModel> GetSafetyStatsAsync(int cityId);
        Task SubmitSafetyRatingAsync(CitySafetyRating rating);

        //CityHealthcareRating
        Task<CityHealthcareRating?> GetUserHealthcareRatingAsync(int cityId, string nomadId);
        Task<CityHealthcareStatsViewModel> GetHealthcareStatsAsync(int cityId);
        Task SubmitHealthcareRatingAsync(CityHealthcareRating rating);

        //CityEntertainmentRating
        Task<CityEntertainmentRating?> GetUserEntertainmentRatingAsync(int cityId, string nomadId);
        Task<CityEntertainmentStatsViewModel> GetEntertainmentStatsAsync(int cityId);
        Task SubmitEntertainmentRatingAsync(CityEntertainmentRating rating);

        //CityTransportRating
        Task<CityTransportRating?> GetUserTransportRatingAsync(int cityId, string nomadId);
        Task<CityTransportStatsViewModel> GetTransportStatsAsync(int cityId);
        Task SubmitTransportRatingAsync(CityTransportRating rating);

        //CostOfLivingRating 
        Task<CityCostOfLivingRating?> GetUserCostOfLivingRatingAsync(int cityId, string nomadId, TravelBudget budget, bool isMonthly);
        Task<CityCostOfLivingStatsViewModel> GetCostOfLivingStatsAsync(int cityId, TravelBudget budget, bool isMonthly);
        Task SubmitCostOfLivingRatingAsync(CityCostOfLivingRating rating);
        Task<List<CityCostOfLivingStatsViewModel>> GetAllCostOfLivingStatsAsync(int cityId);

        //OverallRating
        Task SaveOrUpdateOverallRatingAsync(int cityId, double score, string nomadId);


    }
}
