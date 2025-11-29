// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NomadBuddy00.Constants;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly AppDbContext _context;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            AppDbContext context)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public string ReturnUrl { get; set; } = string.Empty;

        public IList<AuthenticationScheme> ExternalLogins { get; set; } = new List<AuthenticationScheme>();

        public class InputModel
        {
            [Required]
            public string FirstName { get; set; } = string.Empty;

            [Required]
            public string LastName { get; set; } = string.Empty;

            [Required]
            public Gender Gender { get; set; }

            [Required]
            public int CountryId { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            [Required]
            public string Role { get; set; } = "Nomad";
            // Nomad-Specific Fields
            [Required]
            public NomadType NomadType { get; set; } = NomadType.RemoteWorker;
            public int? NationalityId { get; set; }
            public TravelBudget TravelBudget { get; set; }
            public Language PreferredLanguage { get; set; }

            // Buddy-Specific Fields
            public string Specialization { get; set; } = string.Empty;
            public int YearsOfExperience { get; set; } = 0;
        }

        public async Task OnGetAsync(string returnUrl = null!)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["Countries"] = await _context.Countries.ToListAsync();
            ViewData["Nationalities"] = await _context.Nationalities.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null!)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid)
            {
                ViewData["Countries"] = await _context.Countries.ToListAsync();
                ViewData["Nationalities"] = await _context.Nationalities.ToListAsync();
                return Page();
            }

            var user = new ApplicationUser
            {
                UserName = Input.Email,
                Email = Input.Email,
                FirstName = Input.FirstName,
                LastName = Input.LastName,
                Gender = Input.Gender,
                CountryId = Input.CountryId
            };

            var result = await _userManager.CreateAsync(user, Input.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                ViewData["Countries"] = await _context.Countries.ToListAsync();
                ViewData["Nationalities"] = await _context.Nationalities.ToListAsync();

                return Page();
            }

            _logger.LogInformation("User created a new account with password.");

            if (Input.Role == "Nomad")
            {
                if (Input.NationalityId == null)
                {
                    ModelState.AddModelError("Input.NationalityId", "Nationality is required for Nomads.");
                    ViewData["Nationalities"] = await _context.Nationalities.ToListAsync();
                    return Page();
                }

                var nomadProfile = new Nomad
                {
                    UserId = user.Id,
                    TravelBudget = Input.TravelBudget,
                    PreferredLanguage = Input.PreferredLanguage,
                    NationalityId = Input.NationalityId.Value,
                    NomadType = Input.NomadType
                };
                _context.Nomads.Add(nomadProfile);
                await _userManager.AddToRoleAsync(user, Roles.NOMAD);
            }
            else
            {
                var buddyProfile = new Buddy
                {
                    UserId = user.Id,
                    Specialization = Input.Specialization,
                    YearsOfExperience = Input.YearsOfExperience
                };
                _context.Buddies.Add(buddyProfile);
                await _userManager.AddToRoleAsync(user, Roles.BUDDY);
            }

            await _context.SaveChangesAsync();

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = user.Id, code, returnUrl },
                protocol: Request.Scheme);

            await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
                return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });

            await _signInManager.SignInAsync(user, isPersistent: false);
            return LocalRedirect(returnUrl);
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
                throw new NotSupportedException("The default UI requires a user store with email support.");
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
