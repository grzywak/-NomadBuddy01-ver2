using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Constants;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class UserSeeder
    {
        public static async Task InitializeUsersAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<UserSeeder>>();

                // Admin
                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "admin@mail.com", "Admin#1", Roles.ADMIN, Gender.Other);

                // Buddy
                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "buddy@mail.com", "Buddy#1", Roles.BUDDY, Gender.Female);

                // Nomads
                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "nomad1@mail.com", "Nomad#1", Roles.NOMAD, Gender.Female,
                                    Language.English, TravelBudget.Budget, NomadType.RemoteWorker, 48.8566, 2.3522, "FR", "FR");

                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "nomad2@mail.com", "Nomad#2", Roles.NOMAD, Gender.Male,
                    Language.Spanish, TravelBudget.Budget, NomadType.Backpacker, 40.4168, -3.7038, "PL", "PL");

                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "nomad3@mail.com", "Nomad#3", Roles.NOMAD, Gender.Male,
                    Language.French, TravelBudget.Midrange, NomadType.SlowTraveler, 43.7102, 7.2620, "FR", "FR");

                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "nomad4@mail.com", "Nomad#4", Roles.NOMAD, Gender.Female,
                    Language.German, TravelBudget.Luxury, NomadType.Freelancer, 52.5200, 13.4050, "DE", "DE");

                await EnsureUserWithRoleCreated(userManager, dbContext, logger, "nomad5@mail.com", "Nomad#5", Roles.NOMAD, Gender.Other,
                    Language.Polish, TravelBudget.Midrange, NomadType.GapYearTraveler, 50.0647, 19.9450, "PL", "PL");
            }

        }

        private static async Task EnsureUserWithRoleCreated(
            UserManager<ApplicationUser> userManager,
            AppDbContext dbContext,
            ILogger logger,
            string email,
            string password,
            string role,
            Gender gender,
            Language preferredLanguage = Language.English,
            TravelBudget travelStyle = TravelBudget.Budget,
            NomadType nomadType = NomadType.RemoteWorker,
            double latitude = 0,
            double longitude = 0,
            string nationalityIsoCode = "PL",
            string countryIsoCode = "PL")
        {

            if (await userManager.FindByEmailAsync(email) is not null)
            {
                logger.LogInformation($"User {email} already exists.");
                return;
            }

            var country = await dbContext.Countries.FirstOrDefaultAsync(c => c.IsoCode == countryIsoCode);
            if (country == null)
                throw new Exception($"Country with ISO code '{countryIsoCode}' not found. Please seed it first.");

            var nationality = await dbContext.Nationalities.FirstOrDefaultAsync(n => n.IsoCode == nationalityIsoCode);
            if (nationality == null)
            {
                throw new Exception($"Nationality with ISO code '{nationalityIsoCode}' not found. Please seed it first.");
            }

            var user = new ApplicationUser
            {
                Email = email,
                EmailConfirmed = true,
                UserName = email,
                FirstName = "Test",
                LastName = "User",
                CountryId = country.Id,
                Gender = gender
            };

            var creationResult = await userManager.CreateAsync(user, password);

            if (!creationResult.Succeeded)
            {
                var errors = string.Join(", ", creationResult.Errors);
                logger.LogError($"Failed to create user {email}: {errors}");
                throw new Exception($"User creation failed for {email}. Errors: {errors}");
            }

            var roleAssignmentResult = await userManager.AddToRoleAsync(user, role);

            if (!roleAssignmentResult.Succeeded)
            {
                var errors = string.Join(", ", roleAssignmentResult.Errors);
                logger.LogError($"Failed to assign role {role} to {email}: {errors}");
                throw new Exception($"Role assignment failed for {email}. Errors: {errors}");
            }

            if (role == Roles.NOMAD)
            {
                dbContext.Nomads.Add(new Nomad
                {
                    UserId = user.Id,
                    RegistrationDate = DateTime.UtcNow,
                    PreferredLanguage = preferredLanguage,
                    TravelBudget = travelStyle,
                    Latitude = latitude,
                    Longitude = longitude,
                    NationalityId = nationality.Id,
                    NomadType = nomadType
                });
            }
            else if (role == Roles.BUDDY)
            {
                dbContext.Buddies.Add(new Buddy
                {
                    UserId = user.Id,
                    RegistrationDate = DateTime.UtcNow,
                    Specialization = "Local expert",
                    YearsOfExperience = 10
                });
            }

            await dbContext.SaveChangesAsync();

            logger.LogInformation($"User {email} created successfully with role {role}.");
        }
    }
}
