using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Controllers
{
    [Authorize]
    //[Route("api/activities")]
    //[Route("Activities")]
    public class ActivityController : Controller
    {
        private readonly IRepository<Activity> _repository;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActivityController(
            IRepository<Activity> repository,
            UserManager<ApplicationUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet("")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var allActivities = await _repository.GetAllAsync();

            IEnumerable<Activity> userActivities = new List<Activity>();

            if (user != null && (await _userManager.IsInRoleAsync(user, "Buddy") || await _userManager.IsInRoleAsync(user, "Admin")))
            {
                userActivities = allActivities.Where(a => a.CreatedById == user.Id);
            }

            var viewModel = new ActivityIndexViewModel
            {
                AllActivities = allActivities,
                UserActivities = userActivities,
            };

            return View(viewModel);
        }

        [HttpGet("Create")]
        [Authorize(Roles = "Admin,Buddy")]
        public IActionResult Create()
        {
            return View(new Activity());
        }
        
        [HttpPost("Create")]
        [Authorize(Roles = "Admin,Buddy")]
        public async Task<IActionResult> Create(Activity newActivity)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                Console.WriteLine("❌ Error: User not found!");
                return Unauthorized();
            }

            // ✅ Debugging Output
            Console.WriteLine($"✅ User Found: {user.Id} - {user.UserName}");

            newActivity.CreatedById = user.Id;  // ✅ Assign CreatedById
            newActivity.CreatedBy = user;

            ModelState.Clear();  // ✅ Clear errors related to CreatedById
            TryValidateModel(newActivity);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine("❌ Validation Errors: " + string.Join(", ", errors));
                return View(newActivity);
            }

            await _repository.AddAsync(newActivity);

            return RedirectToAction("Index");
        }

        [HttpGet("Edit/{id}")]
        [Authorize(Roles = "Admin,Buddy")]
        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _repository.GetAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && activity.CreatedById != user.Id)
            {
                return Forbid();
            }

            return View(activity);
        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "Admin,Buddy")]
        public async Task<IActionResult> Edit(int id, Activity updatedActivity)
        {
            if (id != updatedActivity.Id)
            {
                return BadRequest(); // ❌ ID mismatch error
            }

            var existingActivity = await _repository.GetAsync(id);
            if (existingActivity == null)
            {
                return NotFound(); // ❌ Activity not found
            }

            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && existingActivity.CreatedById != user.Id)
            {
                return Forbid(); // ❌ Only Admins or the owner can edit
            }

            // ✅ Update properties (but keep the CreatedById unchanged)
            existingActivity.Title = updatedActivity.Title;
            existingActivity.Description = updatedActivity.Description;
            existingActivity.StartDate = updatedActivity.StartDate;
            existingActivity.EndDate = updatedActivity.EndDate;
            existingActivity.Location = updatedActivity.Location;
            existingActivity.MaxParticipants = updatedActivity.MaxParticipants;
            existingActivity.Price = updatedActivity.Price;

            await _repository.UpdateAsync(existingActivity);

            return RedirectToAction("Index"); // ✅ Redirect after saving changes
        }


        [HttpPost("Delete/{id}")]
        [Authorize(Roles = "Admin,Buddy")]
        public async Task<IActionResult> Delete(int id)
        {
            var activity = await _repository.GetAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (!User.IsInRole("Admin") && activity.CreatedById != user.Id)
            {
                return Forbid();
            }

            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
