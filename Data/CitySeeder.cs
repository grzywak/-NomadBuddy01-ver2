using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class CitySeeder
    {
        public static async Task SeedCitiesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.Cities.Any())
                return;

            var countryDict = dbContext.Countries.ToDictionary(c => c.Name, c => c.Id);

            var cities = new List<City>
            {
                new() { Name = "Bangkok", CountryId = countryDict["Thailand"], AverageInternetSpeedMbps = 200, NumberOfCoworkingSpaces = 50, HealthcareQuality = 3, CostOfLiving = 900 },
                new() { Name = "Lisbon", CountryId = countryDict["Portugal"], AverageInternetSpeedMbps = 300, NumberOfCoworkingSpaces = 40, HealthcareQuality = 4, CostOfLiving = 1100 },
                new() { Name = "Bali", CountryId = countryDict["Indonesia"], AverageInternetSpeedMbps = 150, NumberOfCoworkingSpaces = 35, HealthcareQuality = 3, CostOfLiving = 850 },
                new() { Name = "Chiang Mai", CountryId = countryDict["Thailand"], AverageInternetSpeedMbps = 250, NumberOfCoworkingSpaces = 30, HealthcareQuality = 4, CostOfLiving = 700 },
                new() { Name = "Berlin", CountryId = countryDict["Germany"], AverageInternetSpeedMbps = 400, NumberOfCoworkingSpaces = 60, HealthcareQuality = 5, CostOfLiving = 1600 },
                new() { Name = "Barcelona", CountryId = countryDict["Spain"], AverageInternetSpeedMbps = 350, NumberOfCoworkingSpaces = 55, HealthcareQuality = 4, CostOfLiving = 1500 },
                new() { Name = "Tbilisi", CountryId = countryDict["Georgia"], AverageInternetSpeedMbps = 200, NumberOfCoworkingSpaces = 20, HealthcareQuality = 3, CostOfLiving = 600 },
                new() { Name = "Buenos Aires", CountryId = countryDict["Argentina"], AverageInternetSpeedMbps = 100, NumberOfCoworkingSpaces = 25, HealthcareQuality = 3, CostOfLiving = 700 },
                new() { Name = "Tallinn", CountryId = countryDict["Estonia"], AverageInternetSpeedMbps = 500, NumberOfCoworkingSpaces = 15, HealthcareQuality = 5, CostOfLiving = 1300 },
                new() { Name = "Warsaw", CountryId = countryDict["Poland"], AverageInternetSpeedMbps = 400, NumberOfCoworkingSpaces = 35, HealthcareQuality = 4, CostOfLiving = 1000 },
                new() { Name = "Cape Town", CountryId = countryDict["South Africa"], AverageInternetSpeedMbps = 150, NumberOfCoworkingSpaces = 18, HealthcareQuality = 3, CostOfLiving = 850 },
                new() { Name = "Prague", CountryId = countryDict["Czech Republic"], AverageInternetSpeedMbps = 300, NumberOfCoworkingSpaces = 30, HealthcareQuality = 4, CostOfLiving = 1100 },
                new() { Name = "Ho Chi Minh City", CountryId = countryDict["Vietnam"], AverageInternetSpeedMbps = 250, NumberOfCoworkingSpaces = 40, HealthcareQuality = 3, CostOfLiving = 800 },
                new() { Name = "Seoul", CountryId = countryDict["South Korea"], AverageInternetSpeedMbps = 800, NumberOfCoworkingSpaces = 70, HealthcareQuality = 5, CostOfLiving = 1600 },
                new() { Name = "Tokyo", CountryId = countryDict["Japan"], AverageInternetSpeedMbps = 600, NumberOfCoworkingSpaces = 100, HealthcareQuality = 5, CostOfLiving = 2000 },
                new() { Name = "Mexico City", CountryId = countryDict["Mexico"], AverageInternetSpeedMbps = 180, NumberOfCoworkingSpaces = 28, HealthcareQuality = 3, CostOfLiving = 900 },
                new() { Name = "Medellin", CountryId = countryDict["Colombia"], AverageInternetSpeedMbps = 200, NumberOfCoworkingSpaces = 22, HealthcareQuality = 3, CostOfLiving = 750 },
                new() { Name = "Kuala Lumpur", CountryId = countryDict["Malaysia"], AverageInternetSpeedMbps = 350, NumberOfCoworkingSpaces = 35, HealthcareQuality = 4, CostOfLiving = 950 },
                new() { Name = "Hanoi", CountryId = countryDict["Vietnam"], AverageInternetSpeedMbps = 240, NumberOfCoworkingSpaces = 25, HealthcareQuality = 3, CostOfLiving = 750 },
                new() { Name = "Istanbul", CountryId = countryDict["Turkey"], AverageInternetSpeedMbps = 200, NumberOfCoworkingSpaces = 30, HealthcareQuality = 4, CostOfLiving = 850 },
                new() { Name = "Vienna", CountryId = countryDict["Austria"], AverageInternetSpeedMbps = 500, NumberOfCoworkingSpaces = 30, HealthcareQuality = 5, CostOfLiving = 1600 },
                new() { Name = "Belgrade", CountryId = countryDict["Serbia"], AverageInternetSpeedMbps = 300, NumberOfCoworkingSpaces = 20, HealthcareQuality = 3, CostOfLiving = 800 },
                new() { Name = "Athens", CountryId = countryDict["Greece"], AverageInternetSpeedMbps = 280, NumberOfCoworkingSpaces = 30, HealthcareQuality = 4, CostOfLiving = 1100 },
                new() { Name = "Budapest", CountryId = countryDict["Hungary"], AverageInternetSpeedMbps = 320, NumberOfCoworkingSpaces = 25, HealthcareQuality = 4, CostOfLiving = 1000 },
                new() { Name = "Riga", CountryId = countryDict["Latvia"], AverageInternetSpeedMbps = 400, NumberOfCoworkingSpaces = 18, HealthcareQuality = 4, CostOfLiving = 950 },
                new() { Name = "Canggu", CountryId = countryDict["Indonesia"], AverageInternetSpeedMbps = 160, NumberOfCoworkingSpaces = 20, HealthcareQuality = 3, CostOfLiving = 800 },
                new() { Name = "Tenerife", CountryId = countryDict["Spain"], AverageInternetSpeedMbps = 220, NumberOfCoworkingSpaces = 12, HealthcareQuality = 4, CostOfLiving = 1000 },
                new() { Name = "Lviv", CountryId = countryDict["Ukraine"], AverageInternetSpeedMbps = 200, NumberOfCoworkingSpaces = 15, HealthcareQuality = 3, CostOfLiving = 700 },
                new() { Name = "Sofia", CountryId = countryDict["Bulgaria"], AverageInternetSpeedMbps = 250, NumberOfCoworkingSpaces = 20, HealthcareQuality = 4, CostOfLiving = 850 },
                new() { Name = "Tirana", CountryId = countryDict["Albania"], AverageInternetSpeedMbps = 220, NumberOfCoworkingSpaces = 10, HealthcareQuality = 3, CostOfLiving = 700 },
                new() { Name = "Zagreb", CountryId = countryDict["Croatia"], AverageInternetSpeedMbps = 300, NumberOfCoworkingSpaces = 20, HealthcareQuality = 4, CostOfLiving = 1000 }
            };

            dbContext.Cities.AddRange(cities);
            await dbContext.SaveChangesAsync();
        }
    }
}
