using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class InterestSeeder
    {
        public static async Task SeedInterestsAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<InterestSeeder>>();

                if (await dbContext.NomadInterests.AnyAsync())
                {
                    logger.LogInformation("Nomad interests already seeded.");
                    return;
                }

                var nomads = await dbContext.Nomads.ToListAsync();

                if (!nomads.Any())
                {
                    logger.LogWarning("No Nomads found in the database to assign interests to.");
                    return;
                }

                var possibleTags = new List<string>
            {
                "Surfing", "Photography", "Yoga", "Coworking",
                "Nightlife", "Hiking", "Volunteering", "Language Exchange"
            };

                var random = new Random();

                foreach (var nomad in nomads)
                {
                    // Każdy nomad dostaje 2 losowe zainteresowania
                    var selectedTags = possibleTags.OrderBy(_ => random.Next()).Take(2).ToList();

                    foreach (var tag in selectedTags)
                    {
                        dbContext.NomadInterests.Add(new NomadInterest
                        {
                            NomadId = nomad.UserId,
                            Tag = tag
                        });
                    }
                }

                await dbContext.SaveChangesAsync();
                logger.LogInformation("Nomad interests seeded successfully.");
            }
        }
    }
}
