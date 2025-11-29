using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class TravelerTypeSeeder
    {
        public static async Task SeedTravelerTypesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.TravelerTypes.Any())
                return;

            var types = new List<TravelerType>
            {
                new() { Name = "Nature Lover", Description = "Loves quiet, natural places and fresh air." },
                new() { Name = "Adventure Seeker", Description = "Seeks physical challenges and outdoor thrills." },
                new() { Name = "Party Animal", Description = "Enjoys festivals, nightlife, and social energy." },
                new() { Name = "Cultural Enthusiast", Description = "Loves history, museums, and local traditions." },
                new() { Name = "Urban Explorer", Description = "Drawn to cities, cafes, and creative spaces." }
            };

            dbContext.TravelerTypes.AddRange(types);
            await dbContext.SaveChangesAsync();

            var allTypes = dbContext.TravelerTypes.ToList();

            var questions = new List<TravelerQuestion>
            {
                // Nature Lover
                new() { QuestionText = "I enjoy spending time in quiet natural places, away from the city's noise.", TravelerTypeId = allTypes.First(t => t.Name == "Nature Lover").Id },
                new() { QuestionText = "Peace, fresh air, and scenic landscapes help me recharge.", TravelerTypeId = allTypes.First(t => t.Name == "Nature Lover").Id },

                // Adventure Seeker
                new() { QuestionText = "I thrive on trying new things and facing physical challenges.", TravelerTypeId = allTypes.First(t => t.Name == "Adventure Seeker").Id },
                new() { QuestionText = "My ideal trip includes activities like hiking, climbing, or extreme sports.", TravelerTypeId = allTypes.First(t => t.Name == "Adventure Seeker").Id },

                // Party Animal
                new() { QuestionText = "I often plan trips around festivals, concerts, or nightlife.", TravelerTypeId = allTypes.First(t => t.Name == "Party Animal").Id },
                new() { QuestionText = "I love being around people, music, and high energy.", TravelerTypeId = allTypes.First(t => t.Name == "Party Animal").Id },

                // Cultural Enthusiast
                new() { QuestionText = "Exploring museums, local traditions, and historic places excites me.", TravelerTypeId = allTypes.First(t => t.Name == "Cultural Enthusiast").Id },
                new() { QuestionText = "Learning about the history and culture of a place is a big part of my travels.", TravelerTypeId = allTypes.First(t => t.Name == "Cultural Enthusiast").Id },

                // Urban Explorer
                new() { QuestionText = "I love the energy of big cities with modern spots, cafes, and creative spaces.", TravelerTypeId = allTypes.First(t => t.Name == "Urban Explorer").Id },
                new() { QuestionText = "Trendy neighborhoods, architecture, and city vibes are what I seek.", TravelerTypeId = allTypes.First(t => t.Name == "Urban Explorer").Id }
            };

            dbContext.TravelerQuestions.AddRange(questions);
            await dbContext.SaveChangesAsync();
        }
    }
}
