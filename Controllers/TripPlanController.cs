using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class TripPlanController : Controller
    {
        private readonly ITripPlanRepository _tripPlanRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TripPlanController(ITripPlanRepository tripPlanRepository, UserManager<ApplicationUser> userManager)
        {
            _tripPlanRepository = tripPlanRepository;
            _userManager = userManager;
        }

        // GET: TripPlan
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var plans = await _tripPlanRepository.GetTripPlansForNomadAsync(userId);
            return View(plans);
        }

        // GET: TripPlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TripPlan/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripPlanCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                var tripPlan = new TripPlan
                {
                    Name = model.Name,
                    NomadId = userId,
                    CreatedAt = DateTime.UtcNow
                };

                await _tripPlanRepository.CreateTripPlanAsync(tripPlan);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: TripPlan/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var plan = await _tripPlanRepository.GetTripPlanWithStopsAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }
    }
}
