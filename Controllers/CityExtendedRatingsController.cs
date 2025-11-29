using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class CityExtendedRatingsController : Controller
    {
        private readonly ICityExtendedRatingRepository _ratingRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CityExtendedRatingsController(ICityExtendedRatingRepository ratingRepo, UserManager<ApplicationUser> userManager)
        {
            _ratingRepository = ratingRepo;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSafetyRating(CitySafetyRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"Error for {entry.Key}: {error.ErrorMessage}");
                    }
                }
                Console.WriteLine($"INVALID SUBMIT: City {rating.CityId}, Day {rating.DaySafety}, Night {rating.NightSafety}");
                return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
            }

            var newRating = new CitySafetyRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                DaySafety = rating.DaySafety,
                NightSafety = rating.NightSafety,
                FeltHarassed = rating.FeltHarassed,
            };

            await _ratingRepository.SubmitSafetyRatingAsync(newRating);

            return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
        }

/*        [HttpPost]
        public async Task<IActionResult> SubmitHealthcareRating(CityHealthcareRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Invalid healthcare rating.");
                return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
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
            return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitEntertainmentRating(CityEntertainmentRatingViewModel rating)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (!ModelState.IsValid)
            {
                Console.WriteLine("Invalid entertainment rating.");
                return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
            }

            var newRating = new CityEntertainmentRating
            {
                CityId = rating.CityId,
                NomadId = user.Id,
                NightlifeScore = rating.NightlifeScore,
                EventsFrequencyScore = rating.EventsFrequencyScore,
                YouthVibeScore = rating.YouthVibeScore,
            };

            await _ratingRepository.SubmitEntertainmentRatingAsync(newRating);

            return RedirectToAction("Details", "CityRecommendation", new { id = rating.CityId });
        }*/
    }
}
