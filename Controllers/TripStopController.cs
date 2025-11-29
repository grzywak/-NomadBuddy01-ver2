using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class TripStopController : Controller
    {
        private readonly ITripPlanRepository _tripPlanRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRecommendationRepository _cityRepository;
        private readonly IVisaPolicyRepository _visaPolicyRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TripStopController(
            ITripPlanRepository tripPlanRepository,
            ICountryRepository countryRepository,
            ICityRecommendationRepository cityRepository,
            IVisaPolicyRepository visaPolicyRepository,
            UserManager<ApplicationUser> userManager)
        {
            _tripPlanRepository = tripPlanRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
            _visaPolicyRepository = visaPolicyRepository;
            _userManager = userManager;
        }

        // GET: TripStop/Create/{tripPlanId}
/*        public async Task<IActionResult> Create(int tripPlanId)
        {
            ViewBag.TripPlanId = tripPlanId;
            ViewBag.Countries = await _countryRepository.GetAllCountriesAsync();
            ViewBag.Cities = await _cityRepository.GetAllCitiesAsync();
            return View();
        }*/

        // GET: TripStop/Create/{tripPlanId}
        public async Task<IActionResult> Create(int tripPlanId)
        {
            var viewModel = new TripStopCreateViewModel
            {
                TripPlanId = tripPlanId
            };

            ViewBag.Countries = await _countryRepository.GetAllCountriesAsync();
            ViewBag.Cities = await _cityRepository.GetAllCitiesAsync();

            return View(viewModel);
        }


        // POST: TripStop/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripStopCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Countries = await _countryRepository.GetAllCountriesAsync();
                ViewBag.Cities = await _cityRepository.GetAllCitiesAsync();
                return View(model);
            }

            var tripStop = new TripStop
            {
                TripPlanId = model.TripPlanId,
                CountryId = model.CountryId,
                CityId = model.CityId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Notes = model.Notes
            };

            // ⬇️ Automatyczne przypisanie VisaPolicy
            var userId = _userManager.GetUserId(User); // dodaj w kontrolerze UserManager<ApplicationUser>
            var visaPolicies = await _visaPolicyRepository.GetVisaPoliciesForUserNationalityAsync(userId);
            var visaPolicy = visaPolicies.FirstOrDefault(v => v.CountryId == model.CountryId);

            if (visaPolicy != null)
            {
                tripStop.VisaPolicyId = visaPolicy.Id;
            }

            await _tripPlanRepository.AddTripStopAsync(tripStop);

            return RedirectToAction("Details", "TripPlan", new { id = model.TripPlanId });
        }

        [HttpGet]
        public async Task<IActionResult> GetCitiesByCountry(int countryId)
        {
            var cities = await _cityRepository.GetCitiesByCountryAsync(countryId);
            return Json(cities.Select(c => new { c.Id, c.Name }));
        }


    }
}
