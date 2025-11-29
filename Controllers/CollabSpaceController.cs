using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class CollabSpaceController : Controller
    {
        private readonly ICollabSpaceRepository _collabSpaceRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CollabSpaceController(ICollabSpaceRepository collabSpaceRepository, UserManager<ApplicationUser> userManager)
        {
            _collabSpaceRepository = collabSpaceRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> ViewByMatch(int matchId)
        {
            var collab = await _collabSpaceRepository.GetByMatchIdAsync(matchId);

            if (collab == null)
            {
                collab = new CollabSpace
                {
                    NomadMatchId = matchId,
                    SharedGoal = "Lets set our goal!"
                };
                
                await _collabSpaceRepository.CreateAsync(collab);
            }
            return View("View", collab);
        }

        [HttpPost]
        public async Task<IActionResult> AddIdea(int collabSpaceId, string content)
        { 
            await _collabSpaceRepository.AddIdeaAsync(collabSpaceId, content);
            return RedirectToAction("ViewByMatch", new { matchId = collabSpaceId });
        }
    }
}
