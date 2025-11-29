using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Constants;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class TripMapController : Controller
    {
        private readonly ITripPinRepository _tripPinRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public TripMapController(ITripPinRepository tripPinRepository, UserManager<ApplicationUser> userManager)
        {
            _tripPinRepository = tripPinRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Map(int matchId)
        {
            Console.WriteLine("==================== " + matchId);
            ViewData["MatchId"] = matchId;
            var pins = await _tripPinRepository.GetByMatchId(matchId);
            return View(pins);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TripPin pin)
        {
            var user = await _userManager.GetUserAsync(User);
            pin.AddedByNomadId = user.Id;
            pin.CreatedAt = DateTime.UtcNow;
            
            await _tripPinRepository.AddAsync(pin);
            return RedirectToAction("Map", new { matchId = pin.NomadMatchId });
        }
    }
}
