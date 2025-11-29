using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize]
    public class NomadMatchController : Controller
    {
        private readonly INomadMatchRepository _matchRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public NomadMatchController(INomadMatchRepository matchRepository, UserManager<ApplicationUser> userManager)
        {
            _matchRepository = matchRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyMatches(MatchMode mode)
        { 
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var matches = await _matchRepository.GetMatchesForUserAsync(user.Id, mode);
            ViewData["Mode"] = mode;

            return View(matches);
        }
    }
}
