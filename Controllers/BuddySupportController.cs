using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Services;

namespace NomadBuddy00.Controllers
{
    [Authorize]
    public class BuddySupportController : Controller
    {
        private readonly IBuddySupportService _supportService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BuddySupportController(IBuddySupportService service, UserManager<ApplicationUser> userManager)
        {
            _supportService = service;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var activeSupports = await _supportService.GetAllActiveAsync();
            return View(activeSupports);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        { 
              var support = await _supportService.GetDetailsAsync(id);

            if (support == null)
                return NotFound();
 
            return View(support);
        }

        [Authorize(Roles = "Buddy,Admin")]
        public IActionResult Create(int id)
        { 
                return View(new BuddySupport());
        }

        [HttpPost]
        [Authorize(Roles = "Buddy,Admin")]
        public async Task<IActionResult> Create(BuddySupport model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var saved = await _supportService.CreateAsync(model);

            if (!saved)
            {
                ModelState.AddModelError("", "not saved");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        //requests

        [HttpPost]
        [Authorize(Roles = "Nomad")]
        public async Task<IActionResult> SendRequest(int supportId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var sentRequest = await _supportService.SendRequestAsync(supportId, user.Id);

            if (!sentRequest)
            {
                TempData["error"] = "request not sent";
                return RedirectToAction("Details", new { id = supportId });
            }
        
                TempData["success"] = "request sent";
                return RedirectToAction("Details", new { id = supportId });
        }
    }
}
