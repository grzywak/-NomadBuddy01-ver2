using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.Services;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles ="Nomad") ]
    public class CityRecommendationController : Controller
    {
        private readonly ICityRecommendationRepository _cityRecommendationRepository;
        private readonly ICityExtendedRatingRepository _ratingRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICityOverallRatingService _overallRatingService;


        public CityRecommendationController(ICityRecommendationRepository cityRecommendationRepository, UserManager<ApplicationUser> userManager, ICountryRepository countryRepository, ICityExtendedRatingRepository ratingRepository, ICityOverallRatingService overallRatingService)
        {
            _cityRecommendationRepository = cityRecommendationRepository;
            _ratingRepository = ratingRepository;
            _countryRepository = countryRepository;
            _userManager = userManager;
            _overallRatingService = overallRatingService;
        }

        public async Task<IActionResult> Index(TravelBudget? budget, Continent? continent, int? countryId)
        {
            var user = await _userManager.Users
                        .Include(u => u.Nomad)
                        .FirstOrDefaultAsync(u => u.Id == _userManager.GetUserId(User));

            if (user == null || user.Nomad == null)
                return NotFound("User or Nomad profile not found.");

            var countries = await _countryRepository.GetAllCountriesAsync();
            ViewBag.Countries = countries;

            // Rekomendacje od użytkowników tego samego typu
            var topByType = await _cityRecommendationRepository.GetRecommendedCitiesForNomadTypeAsync(user.Nomad!.NomadType);

            // Rekomendacje filtrowane (tak jak było)
            var filtered = await _cityRecommendationRepository.GetFilteredRecommendedCitiesAsync(user.Id, budget, continent, countryId);

            var model = new CityRecommendationIndexViewModel
            {
                NomadType = user.Nomad.NomadType,
                RecommendedByType = topByType,
                FilteredResults = filtered,
                SelectedBudget = budget,
                SelectedContinent = continent,
                SelectedCountryId = countryId
            };

            return View(model);
        }


        /*        public async Task<IActionResult> Index(TravelBudget? budget, Continent? continent, int? countryId)
                {
                    var user = await _userManager.GetUserAsync(User);

                    var countries = await _countryRepository.GetAllCountriesAsync();
                    ViewBag.Countries = countries;

                    ViewBag.Continents = Enum.GetValues(typeof(Continent)).Cast<Continent>().ToList();

                    var recommendations = await _cityRecommendationRepository.GetFilteredRecommendedCitiesAsync(
                        user.Id, budget, continent, countryId);

                    return View(recommendations);
                }*/


        /*        public async Task<IActionResult> Index()
                {
                    var user = await _userManager.GetUserAsync(User);
                    var recommendations = await _cityRecommendationRepository.GetTopRecommendedCitiesAsync(user.Id);

                    return View(recommendations);
                }*/
        /*        public async Task<IActionResult> Details(int id)
                { 
                    var city = await _cityRecommendationRepository.GetCityDetailsAsync(id);
                    if (city == null) return NotFound();

                    var tags = await _cityRecommendationRepository.GetAllCityTagsAsync();

                    ViewBag.AllTags = tags;
                    return View(city);  
                }*/

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var model = await _cityRecommendationRepository.GetCityDetailsWithRatingsAsync(id, user.Id);
            if (model == null) return NotFound();

            var tags = await _cityRecommendationRepository.GetAllCityTagsAsync();
            ViewBag.AllTags = tags;
            var stats = await _ratingRepository.GetSafetyStatsAsync(id);
            ViewBag.SafetyStats = stats;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> VoteTag(int cityId, int tagId)
        {
            var user = await _userManager.GetUserAsync(User);
            var vote = new CityTagVote
            {
                CityId = cityId,
                CityTagId = tagId,
                NomadId = user.Id,
                VotedAt = DateTime.UtcNow,
            };

            await _cityRecommendationRepository.AddTagVoteAsync(vote);
            return RedirectToAction("Details", new { id = cityId });
        }

        [HttpPost]
        public async Task<IActionResult> Rate(CityRatingViewModel cityRating)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", new { id = cityRating.CityId });
            }

            var user = await _userManager.GetUserAsync(User);
            await _cityRecommendationRepository.AddOrUpdateCityRatingAsync(cityRating, user.Id);

            await _overallRatingService.CalculateAndStoreOverallScoreAsync(cityRating.CityId, user.Id);

            return RedirectToAction("Details", new { id = cityRating.CityId });
        }
    }
}
