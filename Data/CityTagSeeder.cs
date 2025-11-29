using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class CityTagSeeder
    {
        public static async Task SeedCityTagsAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.CityTags.Any())
                return;

            var tags = new List<CityTag>
            {
                // Positive tags
                new() { Text = "Great food scene", IsPositive = true },
                new() { Text = "Reliable public transport", IsPositive = true },
                new() { Text = "Lots of coworking spaces", IsPositive = true },
                new() { Text = "Strong expat community", IsPositive = true },
                new() { Text = "Fast internet", IsPositive = true },
                new() { Text = "Safe for solo travelers", IsPositive = true },
                new() { Text = "Affordable cost of living", IsPositive = true },
                new() { Text = "Rich cultural heritage", IsPositive = true },
                new() { Text = "Mild climate", IsPositive = true },
                new() { Text = "Walkable city", IsPositive = true },

                // Negative tags
                new() { Text = "High air pollution", IsPositive = false },
                new() { Text = "Too touristy", IsPositive = false },
                new() { Text = "Expensive housing", IsPositive = false },
                new() { Text = "Traffic congestion", IsPositive = false },
                new() { Text = "Poor healthcare", IsPositive = false },
                new() { Text = "Slow internet", IsPositive = false },
                new() { Text = "Limited nightlife", IsPositive = false },
                new() { Text = "Language barrier", IsPositive = false },
                new() { Text = "Not very walkable", IsPositive = false },
                new() { Text = "Unfriendly locals", IsPositive = false }
            };

            dbContext.CityTags.AddRange(tags);
            await dbContext.SaveChangesAsync();
        }
    }
}
