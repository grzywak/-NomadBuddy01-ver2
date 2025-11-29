using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class NomadController : Controller
    {
        private readonly INomadRepository _nomadRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly INationalityRepository _nationalityRepository;
        private readonly ICityRecommendationRepository _cityRecommendationRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public NomadController(INomadRepository nomadRepository, ICountryRepository countryRepository, INationalityRepository nationalityRepository, ICityRecommendationRepository cityRecommendationRepository, UserManager<ApplicationUser> userManager)
        {
            _nomadRepository = nomadRepository;
            _countryRepository = countryRepository;
            _nationalityRepository = nationalityRepository;
            _cityRecommendationRepository = cityRecommendationRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Discover(MatchMode mode = MatchMode.Friends)
        { 
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) { return Unauthorized(); }

            var nomads = await _nomadRepository.GetDiscoverNomadsAsync(currentUser.Id, mode);
            ViewBag.Mode = mode;

            return View(nomads);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            var nomad = await _nomadRepository.GetByIdAsync(currentUser.Id);
            if (nomad == null) return NotFound();

            var model = new NomadProfileEditViewModel
            {
                UserId = nomad.UserId,
                FirstName = nomad.User.FirstName,
                LastName = nomad.User.LastName,
                Gender = nomad.User.Gender,
                CountryId = nomad.User.CountryId,
                NationalityId = nomad.NationalityId,
                TravelBudget = nomad.TravelBudget,
                PreferredLanguage = nomad.PreferredLanguage,
                NomadType = nomad.NomadType,
                CurrentCityId = nomad.CurrentCityId,
                CurrentCountryId = nomad.CurrentCountryId
            };

            ViewData["Countries"] = await _countryRepository.GetAllCountriesAsync();
            ViewData["Nationalities"] = await _nationalityRepository.GetAllNationalitiesAsync();
            ViewData["Cities"] = await _cityRecommendationRepository.GetAllCitiesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(NomadProfileEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Countries"] = await _countryRepository.GetAllCountriesAsync();
                ViewData["Nationalities"] = await _nationalityRepository.GetAllNationalitiesAsync();
                ViewData["Cities"] = await _cityRecommendationRepository.GetAllCitiesAsync();

                return View(model);
            }

            var nomad = await _nomadRepository.GetByIdAsync(model.UserId);
            if (nomad == null) return NotFound();

            nomad.User.FirstName = model.FirstName;
            nomad.User.LastName = model.LastName;
            nomad.User.Gender = model.Gender;
            nomad.User.CountryId = model.CountryId;
            nomad.NationalityId = model.NationalityId;
            nomad.TravelBudget = model.TravelBudget;
            nomad.PreferredLanguage = model.PreferredLanguage;
            nomad.NomadType = model.NomadType;
            nomad.CurrentCityId = model.CurrentCityId;
            nomad.CurrentCountryId = model.CurrentCountryId;

            await _nomadRepository.UpdateAsync(nomad);

            return RedirectToAction("Index", "NomadDashboard");
        }
    


    }
}
