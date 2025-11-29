using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Controllers
{
    public class VisaPolicyController : Controller
    {
        private readonly IVisaPolicyRepository _visaPolicyRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public VisaPolicyController(IVisaPolicyRepository visaPolicyRepository, UserManager<ApplicationUser> userManager)
        {
            _visaPolicyRepository = visaPolicyRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Challenge();
            }

            var visaPolicies = await _visaPolicyRepository.GetVisaPoliciesForUserNationalityAsync(user.Id);

            return View(visaPolicies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var visaPolicy = await _visaPolicyRepository.GetVisaPolicyAsync(id);

            if (visaPolicy == null)
            {
                return NotFound();
            }

            return View(visaPolicy);
        }
    }
}
