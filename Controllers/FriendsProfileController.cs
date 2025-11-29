using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class FriendsProfileController : Controller
    {
        private readonly IFriendsProfileRepository _friendsProfileRepository;
        private readonly INomadRepository _nomadRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public FriendsProfileController(
            IFriendsProfileRepository friendsProfileRepository,
            INomadRepository nomadRepository,
            UserManager<ApplicationUser> userManager)
        {
            _friendsProfileRepository = friendsProfileRepository;
            _nomadRepository = nomadRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            var nomad = await _nomadRepository.GetByIdAsync(userId);

            if (nomad == null) return NotFound();

            var existingProfile = await _friendsProfileRepository.GetByNomadIdAsync(userId);
            if (existingProfile != null)
                return RedirectToAction("Edit", new { id = existingProfile.Id });

            var profile = new FriendsProfile { NomadId = userId };
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FriendsProfile profile)
        {
            var userId = _userManager.GetUserId(User);

            Console.WriteLine($"[Create POST] NomadId z formularza: {profile.NomadId}");
            Console.WriteLine($"[Create POST] Aktualny użytkownik: {userId}");

            if (profile.NomadId != userId)
            {
                Console.WriteLine("NomadId nie zgadza się z zalogowanym użytkownikiem.");
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState INVALID:");
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        Console.WriteLine($" - {key}: {error.ErrorMessage}");
                    }
                }

                return View(profile);
            }

            Console.WriteLine("ModelState OK. Dodaję profil do repozytorium...");

            await _friendsProfileRepository.AddAsync(profile);

            Console.WriteLine("Zapisano profil! Redirect.");

            return RedirectToAction("Details", new { id = profile.Id });
        }


        public async Task<IActionResult> Edit(int id)
        {
            var profile = await _friendsProfileRepository.GetByIdAsync(id);
            var userId = _userManager.GetUserId(User);

            if (profile == null || profile.NomadId != userId)
                return Forbid();

            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FriendsProfile profile)
        {
            if (id != profile.Id) return NotFound();
            if (profile.NomadId != _userManager.GetUserId(User)) return Forbid();

            if (!ModelState.IsValid) return View(profile);

            await _friendsProfileRepository.UpdateAsync(profile);
            return RedirectToAction("Details", new { id = profile.Id });
        }

        public async Task<IActionResult> Details(int id)
        {
            var profile = await _friendsProfileRepository.GetByIdAsync(id);
            var userId = _userManager.GetUserId(User);

            if (profile == null || profile.NomadId != userId)
                return Forbid();

            return View(profile);
        }
    }
}
