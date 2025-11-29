using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.Services;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class CityRatingController : Controller
    {
        private readonly ICityRecommendationRepository _cityRecommandationRepository;
        private readonly ICityExtendedRatingRepository _ratingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICityOverallRatingService _overallRatingService;


        public CityRatingController(
            ICityRecommendationRepository baseRepo,
            ICityExtendedRatingRepository extendedRepo,
            UserManager<ApplicationUser> userManager,
            ICityOverallRatingService overallRatingService)
        {
            _cityRecommandationRepository = baseRepo;
            _ratingRepository = extendedRepo;
            _userManager = userManager;
            _overallRatingService = overallRatingService;
        }

        [HttpGet]
        public async Task<IActionResult> Rate(int cityId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var city = await _cityRecommandationRepository.GetCityDetailsAsync(cityId);
            if (city == null) return NotFound();

            var model = new CityFullRatingViewModel
            {
                City = city,
                SafetyStats = await _ratingRepository.GetSafetyStatsAsync(cityId),
                SafetyUserRating = await _ratingRepository.GetUserSafetyRatingAsync(cityId, user.Id),
                HealthcareStats = await _ratingRepository.GetHealthcareStatsAsync(cityId),
                HealthcareUserRating = await _ratingRepository.GetUserHealthcareRatingAsync(cityId, user.Id),
                EntertainmentStats = await _ratingRepository.GetEntertainmentStatsAsync(cityId),
                EntertainmentUserRating = await _ratingRepository.GetUserEntertainmentRatingAsync(cityId, user.Id),
                TransportStats = await _ratingRepository.GetTransportStatsAsync(cityId),
                TransportUserRating = await _ratingRepository.GetUserTransportRatingAsync(cityId, user.Id),
                CostOfLivingStats = await _ratingRepository.GetCostOfLivingStatsAsync(cityId, TravelBudget.Midrange, true),
                CostOfLivingUserRating = await _ratingRepository.GetUserCostOfLivingRatingAsync(cityId, user.Id, TravelBudget.Midrange, true),
                CostOfLivingAllStats = await _ratingRepository.GetAllCostOfLivingStatsAsync(cityId)

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSafetyRating(CitySafetyRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Safety rating is invalid.";
                return RedirectToAction("Rate", new { cityId = rating.CityId });
            }

            var newRating = new CitySafetyRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                DaySafety = rating.DaySafety,
                NightSafety = rating.NightSafety,
                FeltHarassed = rating.FeltHarassed
            };

            await _ratingRepository.SubmitSafetyRatingAsync(newRating);
            TempData["Success"] = "Safety rating submitted!";

            await _overallRatingService.CalculateAndStoreOverallScoreAsync(rating.CityId, user.Id);

            return RedirectToAction("Rate", new { cityId = rating.CityId });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitHealthcareRating(CityHealthcareRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Healthcare rating is invalid.";
                return RedirectToAction("Rate", new { cityId = rating.CityId });
            }

            var newRating = new CityHealthcareRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                AvailabilityScore = rating.AvailabilityScore,
                AvgDoctorVisitCost = rating.AvgDoctorVisitCost,
                AvgInsuranceMonthlyCost = rating.AvgInsuranceMonthlyCost
            };

            await _ratingRepository.SubmitHealthcareRatingAsync(newRating);
            TempData["Success"] = "Healthcare rating submitted!";

            await _overallRatingService.CalculateAndStoreOverallScoreAsync(rating.CityId, user.Id);

            return RedirectToAction("Rate", new { cityId = rating.CityId });
            //return await Rate(rating.CityId);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitEntertainmentRating(CityEntertainmentRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Entertainment rating is invalid.";
                return RedirectToAction("Rate", new { cityId = rating.CityId });
            }

            var newRating = new CityEntertainmentRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                NightlifeScore = rating.NightlifeScore,
                EventsFrequencyScore = rating.EventsFrequencyScore,
                YouthVibeScore = rating.YouthVibeScore
            };

            await _ratingRepository.SubmitEntertainmentRatingAsync(newRating);
            TempData["Success"] = "Entertainment rating submitted!";
            //return await Rate(rating.CityId);
            await _overallRatingService.CalculateAndStoreOverallScoreAsync(rating.CityId, user.Id);


            return RedirectToAction("Rate", new { cityId = rating.CityId });

        }

        [HttpPost]
        public async Task<IActionResult> SubmitTransportRating(CityTransportRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Transport rating is invalid.";
                return RedirectToAction("Rate", new { cityId = rating.CityId });
            }

            var newRating = new CityTransportRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                PublicTransportScore = rating.PublicTransportScore,
                NightTransportScore = rating.NightTransportScore,
                BikeFriendlyScore = rating.BikeFriendlyScore,
                WalkabilityScore = rating.WalkabilityScore,
                TransportCostScore = rating.TransportCostScore,
                AppConvenienceScore = rating.AppConvenienceScore,
                MotorbikeEaseScore = rating.MotorbikeEaseScore,
                Comment = rating.Comment
            };

            await _ratingRepository.SubmitTransportRatingAsync(newRating);
            TempData["Success"] = "Transport rating submitted!";

            await _overallRatingService.CalculateAndStoreOverallScoreAsync(rating.CityId, user.Id);

            return RedirectToAction("Rate", new { cityId = rating.CityId });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitCostOfLivingRating(CityCostOfLivingRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Cost of Living rating is invalid.";
                return RedirectToAction("Rate", new { cityId = rating.CityId });
            }

            var newRating = new CityCostOfLivingRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                IsMonthly = rating.IsMonthly,
                BudgetLevel = rating.BudgetLevel,
                Food = rating.Food,
                Housing = rating.Housing,
                Transport = rating.Transport,
                Leisure = rating.Leisure
            };

            await _ratingRepository.SubmitCostOfLivingRatingAsync(newRating);
            TempData["Success"] = "Cost of Living rating submitted!";

            return RedirectToAction("Rate", new { cityId = rating.CityId });
        }

    }
}
