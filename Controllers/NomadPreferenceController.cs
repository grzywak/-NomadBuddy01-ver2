using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles ="Nomad")]
    public class NomadPreferenceController : Controller
    {
        private readonly INomadPreferenceRepository _nomadPreferenceRepository;
        private readonly INomadRepository _nomadRepository;
        private readonly ITravelerQuizRepository _quizRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public NomadPreferenceController(INomadPreferenceRepository nomadPreferenceRepository, INomadRepository nomadRepository,
            ITravelerQuizRepository quizRepository, UserManager<ApplicationUser> userManager)
        {
            _nomadPreferenceRepository = nomadPreferenceRepository;
            _nomadRepository = nomadRepository;
            _quizRepository = quizRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var nomad = await _nomadRepository.GetByIdAsync(user.Id);
            if (nomad == null) return NotFound();

            var scores = await _quizRepository.GetScoresAsync(nomad.UserId);
            var topTypeId = scores.OrderByDescending(s => s.Score).FirstOrDefault()?.TravelerTypeId;

            var suggested = topTypeId.HasValue
                ? await _nomadPreferenceRepository.GetSuggestedPreferencesForTravelerTypeAsync(topTypeId.Value)
                : new List<TravelerPreference>();

            var allPrefs = await _nomadPreferenceRepository.GetAllPreferencesAsync();
            var selected = await _nomadPreferenceRepository.GetSelectedPreferenceIdsAsync(nomad.UserId);

            ViewBag.Suggested = suggested;
            ViewBag.Selected = selected;

            return View(allPrefs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(List<int> selectedPreferences)
        {
            var user = await _userManager.GetUserAsync(User);
            var nomad = await _nomadRepository.GetByIdAsync(user.Id);
            if (nomad == null) return NotFound();

            await _nomadPreferenceRepository.SavePreferencesAsync(nomad.UserId, selectedPreferences);

            return RedirectToAction("Edit", new { saved = true });
        }

    }
}
