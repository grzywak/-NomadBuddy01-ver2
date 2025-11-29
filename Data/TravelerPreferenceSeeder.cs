using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class TravelerPreferenceSeeder
    {
        public static async Task SeedTravelerPreferencesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.TravelerPreferences.Any())
                return;

            // Tworzenie preferencji
            var preferences = new List<TravelerPreference>
            {
                new() { PreferenceKey = "likes_beach", Label = "I love being near the sea" },
                new() { PreferenceKey = "likes_mountains", Label = "I enjoy mountainous regions" },
                new() { PreferenceKey = "likes_rural", Label = "I prefer small, quiet towns" },
                new() { PreferenceKey = "likes_cities", Label = "I like exploring vibrant cities" },
                new() { PreferenceKey = "needs_coworking", Label = "Reliable coworking is essential" },
                new() { PreferenceKey = "needs_fast_internet", Label = "I require fast internet" },
                new() { PreferenceKey = "enjoys_nightlife", Label = "I enjoy nightlife and parties" },
                new() { PreferenceKey = "values_safety", Label = "I prioritize safe destinations" },
                new() { PreferenceKey = "low_cost", Label = "Low cost of living is important" },
                new() { PreferenceKey = "cares_healthcare", Label = "Good healthcare access matters" },
                new() { PreferenceKey = "likes_culture", Label = "I love art, history, and local culture" },
                new() { PreferenceKey = "values_nature", Label = "Proximity to nature is important" },
            };

            dbContext.TravelerPreferences.AddRange(preferences);
            await dbContext.SaveChangesAsync();

            // Pobierz typy podróżników
            var types = dbContext.TravelerTypes.ToList();
            var allPrefs = dbContext.TravelerPreferences.ToList();

            // Przypisania suggestedFor
            void Assign(string prefKey, string[] travelerTypeNames)
            {
                var pref = allPrefs.FirstOrDefault(p => p.PreferenceKey == prefKey);
                if (pref == null) return;

                pref.SuggestedForTypes = types
                    .Where(t => travelerTypeNames.Contains(t.Name))
                    .ToList();
            }

            Assign("likes_beach", new[] { "Nature Lover", "Urban Explorer" });
            Assign("likes_mountains", new[] { "Nature Lover", "Adventure Seeker" });
            Assign("likes_rural", new[] { "Nature Lover" });
            Assign("likes_cities", new[] { "Urban Explorer", "Party Animal" });
            Assign("needs_coworking", new[] { "Urban Explorer" });
            Assign("needs_fast_internet", new[] { "Urban Explorer", "Adventure Seeker" });
            Assign("enjoys_nightlife", new[] { "Party Animal", "Urban Explorer" });
            Assign("values_safety", new[] { "Cultural Enthusiast", "Nature Lover" });
            Assign("low_cost", new[] { "Adventure Seeker", "Party Animal" });
            Assign("cares_healthcare", new[] { "Cultural Enthusiast", "Nature Lover" });
            Assign("likes_culture", new[] { "Cultural Enthusiast" });
            Assign("values_nature", new[] { "Nature Lover", "Adventure Seeker" });

            await dbContext.SaveChangesAsync();
        }
    }
}


