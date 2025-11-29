using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class CountrySeeder
    {
        public static async Task SeedCountriesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.Countries.Any())
                return;

            var countries = new List<Country>
            {
                new() { Name = "Poland", IsoCode = "PL", Continent = Continent.Europe },
                new() { Name = "Germany", IsoCode = "DE", Continent = Continent.Europe },
                new() { Name = "France", IsoCode = "FR", Continent = Continent.Europe },
                new() { Name = "Spain", IsoCode = "ES", Continent = Continent.Europe },
                new() { Name = "Italy", IsoCode = "IT", Continent = Continent.Europe },
                new() { Name = "Thailand", IsoCode = "TH", Continent = Continent.Asia },
                new() { Name = "Portugal", IsoCode = "PT", Continent = Continent.Europe },
                new() { Name = "Indonesia", IsoCode = "ID", Continent = Continent.Asia },
                new() { Name = "Georgia", IsoCode = "GE", Continent = Continent.Asia },
                new() { Name = "Czech Republic", IsoCode = "CZ", Continent = Continent.Europe },
                new() { Name = "Estonia", IsoCode = "EE", Continent = Continent.Europe },
                new() { Name = "South Africa", IsoCode = "ZA", Continent = Continent.Africa },
                new() { Name = "Argentina", IsoCode = "AR", Continent = Continent.SouthAmerica },
                new() { Name = "Vietnam", IsoCode = "VN", Continent = Continent.Asia },
                new() { Name = "South Korea", IsoCode = "KR", Continent = Continent.Asia },
                new() { Name = "Japan", IsoCode = "JP", Continent = Continent.Asia },
                new() { Name = "Mexico", IsoCode = "MX", Continent = Continent.NorthAmerica },
                new() { Name = "Colombia", IsoCode = "CO", Continent = Continent.SouthAmerica },
                new() { Name = "Malaysia", IsoCode = "MY", Continent = Continent.Asia },
                new() { Name = "Turkey", IsoCode = "TR", Continent = Continent.Asia },
                new() { Name = "Austria", IsoCode = "AT", Continent = Continent.Europe },
                new() { Name = "Serbia", IsoCode = "RS", Continent = Continent.Europe },
                new() { Name = "Greece", IsoCode = "GR", Continent = Continent.Europe },
                new() { Name = "Hungary", IsoCode = "HU", Continent = Continent.Europe },
                new() { Name = "Latvia", IsoCode = "LV", Continent = Continent.Europe },
                new() { Name = "Ukraine", IsoCode = "UA", Continent = Continent.Europe },
                new() { Name = "Bulgaria", IsoCode = "BG", Continent = Continent.Europe },
                new() { Name = "Albania", IsoCode = "AL", Continent = Continent.Europe },
                new() { Name = "Croatia", IsoCode = "HR", Continent = Continent.Europe },
            };

            dbContext.Countries.AddRange(countries);
            await dbContext.SaveChangesAsync();
        }
    }
}
