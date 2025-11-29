using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class NomadDashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INomadRepository _nomadRepository;
        private readonly INomadPreferenceRepository _preferenceRepository;
        private readonly IFriendsProfileRepository _friendsProfileRepository;

        public NomadDashboardController(
            UserManager<ApplicationUser> userManager,
            INomadRepository nomadRepository,
            INomadPreferenceRepository preferenceRepository,
            IFriendsProfileRepository friendsProfileRepository)
        {
            _userManager = userManager;
            _nomadRepository = nomadRepository;
            _preferenceRepository = preferenceRepository;
            _friendsProfileRepository = friendsProfileRepository;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var nomadId = user.Id;

            var hasCompletedQuiz = await _nomadRepository.HasTravelerTypeScoreAsync(nomadId);
            var hasPreferences = await _preferenceRepository.HasPreferencesAsync(nomadId);
            var hasFriendsProfile = await _friendsProfileRepository.HasFriendsProfileAsync(nomadId);

            var model = new NomadDashboardViewModel
            {
                HasCompletedQuiz = hasCompletedQuiz,
                HasSetPreferences = hasPreferences,
                HasCreatedFriendsProfile = hasFriendsProfile
            };

            return View(model);
        }
    }
}
