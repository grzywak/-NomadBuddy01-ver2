using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class NationalitySeeder
    {
        public static async Task SeedNationalitiesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.Nationalities.Any())
                return;

            var nationalities = new List<Nationality>
            {
                new() { Name = "Poland", IsoCode = "PL" },
                new() { Name = "Spain", IsoCode = "ES" },
                new() { Name = "France", IsoCode = "FR" },
                new() { Name = "Germany", IsoCode = "DE" },
                new() { Name = "United Kingdom", IsoCode = "GB" },
                new() { Name = "United States", IsoCode = "US" },
                new() { Name = "Portugal", IsoCode = "PT" },
                new() { Name = "Italy", IsoCode = "IT" },
                new() { Name = "Canada", IsoCode = "CA" },
                new() { Name = "Netherlands", IsoCode = "NL" }
            };

            dbContext.Nationalities.AddRange(nationalities);
            await dbContext.SaveChangesAsync();
        }
    }
}
