using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles ="Nomad")]
    public class ActivityReservationController : Controller
    {
        private readonly IActivityReservationRepository _reservationRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public ActivityReservationController(IActivityReservationRepository reservationRepository, UserManager<ApplicationUser> userManager)
        {
            _reservationRepository = reservationRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyReservations()
        { 
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var reservation = await _reservationRepository.GetActivityByNomadIdAsync(user.Id);
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Nomad")]
        public async Task<IActionResult> Create(int activityId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var isNomad = await _reservationRepository.NomadExistsAsync(user.Id);
            if (!isNomad)
            {
                TempData["Message"] = "Your Nomad profile is incomplete. Please contact support.";
                return RedirectToAction("Index", "Activity");
            }

            // Sprawdź, czy już zarezerwował
            var existing = await _reservationRepository.GetActivityByNomadIdAsync(user.Id);
            if (existing.Any(r => r.ActivityId == activityId))
            {
                TempData["Message"] = "You have already reserved this activity.";
                return RedirectToAction("Index", "Activity");
            }

            var reservation = new ActivityReservation
            {
                ActivityId = activityId,
                NomadId = user.Id,
                ReservationDate = DateTime.Now,
                Status = ReservationStatus.Pending
            };

            await _reservationRepository.AddAsync(reservation);

            TempData["Message"] = "Reservation created successfully!";
            return RedirectToAction("MyReservations", "ActivityReservation");
        }

    }
}
