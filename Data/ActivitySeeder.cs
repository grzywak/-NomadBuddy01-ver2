using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class ActivitySeeder
    {
        public static async Task SeedActivitiesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ActivitySeeder>>();

            // Upewnij się, że DB istnieje
            await context.Database.EnsureCreatedAsync();

            // Jeśli są już aktywności, nie seeduj ponownie
            if (await context.Activities.AnyAsync()) return;

            // Znajdź użytkownika typu Buddy
            var buddy = await userManager.FindByEmailAsync("buddy@mail.com");
            if (buddy == null)
            {
                logger.LogWarning("No buddy user found. Cannot seed activities.");
                return;
            }

            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Morning Yoga in the Park",
                    Location = "Da Nang",
                    Description = "Relax and stretch with a morning yoga session.",
                    StartDate = DateTime.Now.AddDays(1).AddHours(8),
                    EndDate = DateTime.Now.AddDays(1).AddHours(10),
                    Price = 10,
                    MaxParticipants = 15,
                    CreatedById = buddy.Id
                },
                new Activity
                {
                    Title = "Sunset Beach Volleyball",
                    Location = "My Khe Beach",
                    Description = "Join a friendly game of volleyball by the sea.",
                    StartDate = DateTime.Now.AddDays(2).AddHours(17),
                    EndDate = DateTime.Now.AddDays(2).AddHours(19),
                    Price = 0,
                    MaxParticipants = 20,
                    CreatedById = buddy.Id
                },
                new Activity
                {
                    Title = "Vietnamese Cooking Class",
                    Location = "Hoi An",
                    Description = "Learn to make classic Vietnamese dishes.",
                    StartDate = DateTime.Now.AddDays(3).AddHours(10),
                    EndDate = DateTime.Now.AddDays(3).AddHours(13),
                    Price = 25,
                    MaxParticipants = 10,
                    CreatedById = buddy.Id
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();

            logger.LogInformation("Seeded initial activities.");
        }
    }
}
