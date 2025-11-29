using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    [Authorize(Roles = "Nomad")]
    public class NomadLikeController : Controller
    {
        private readonly INomadLikeRepository _likeRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public NomadLikeController(INomadLikeRepository likeRepository, UserManager<ApplicationUser> userManager)
        {
            _likeRepository = likeRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Like(string id, MatchMode mode)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Unauthorized();

            await _likeRepository.LikeAsync(currentUser.Id, id, mode);

            return RedirectToAction("Discover","Nomad", new { mode });  
        }
    }
}
