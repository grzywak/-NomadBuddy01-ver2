using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Services;

namespace NomadBuddy00.Controllers
{
    [Authorize]
    public class BuddySupportController : Controller
    {
        private readonly IBuddySupportService _service;

        public BuddySupportController(IBuddySupportService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var activeSupports = await _service.GetAllActiveAsync();
            return View(activeSupports);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        { 
              var support = await _service.GetDetailsAsync(id);

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
            var result = await _service.CreateAsync(model);

            if (!result)
            {
                ModelState.AddModelError("", "went wrong");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
