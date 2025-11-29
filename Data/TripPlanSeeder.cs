using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class TripPlanSeeder
    {
        public static async Task SeedTripPlansAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (dbContext.TripPlans.Any())
                return;

            var nomad = await dbContext.Nomads
                .Include(n => n.Nationality)
                .Where(n => n.NationalityId != null)
                .FirstOrDefaultAsync();

            var countries = await dbContext.Countries
                .Where(c => dbContext.VisaPolicies.Any(vp => vp.CountryId == c.Id && vp.NationalityId == nomad.NationalityId))
                .Take(5)
                .ToListAsync();

            if (nomad == null || nomad.NationalityId == null || countries.Count < 2)
                return;

            var tripPlans = new List<TripPlan>
            {
                new TripPlan
                {
                    NomadId = nomad.UserId,
                    Name = "Summer 2025 Adventure",
                    CreatedAt = DateTime.UtcNow,
                    TripStops = new List<TripStop>
                    {
                        await CreateTripStopWithVisaAsync(dbContext, nomad.NationalityId, countries[0].Id, new DateTime(2025, 6, 1), new DateTime(2025, 7, 1), "Enjoy the beaches!"),
                        await CreateTripStopWithVisaAsync(dbContext, nomad.NationalityId, countries[1].Id, new DateTime(2025, 7, 2), new DateTime(2025, 8, 1), "Explore the culture!")
                    }
                },
                new TripPlan
                {
                    NomadId = nomad.UserId,
                    Name = "Asia Nomad Life",
                    CreatedAt = DateTime.UtcNow,
                    TripStops = new List<TripStop>
                    {
                        await CreateTripStopWithVisaAsync(dbContext, nomad.NationalityId, countries[2].Id, new DateTime(2025, 8, 5), new DateTime(2025, 9, 5), "Discover food and people!"),
                        await CreateTripStopWithVisaAsync(dbContext, nomad.NationalityId, countries[3].Id, new DateTime(2025, 9, 10), new DateTime(2025, 10, 10), "Mountains and city life.")
                    }
                }
            };

            dbContext.TripPlans.AddRange(tripPlans);
            await dbContext.SaveChangesAsync();
        }

        private static async Task<TripStop> CreateTripStopWithVisaAsync(AppDbContext dbContext, int nationalityId, int countryId, DateTime startDate, DateTime endDate, string notes)
        {
            var visaPolicy = await dbContext.VisaPolicies
                .FirstOrDefaultAsync(vp => vp.NationalityId == nationalityId && vp.CountryId == countryId);

            if (visaPolicy == null)
            {
                Console.WriteLine($"[Warning] No VisaPolicy found for NationalityId {nationalityId} and CountryId {countryId}");
            }

            return new TripStop
            {
                CountryId = countryId,
                StartDate = startDate,
                EndDate = endDate,
                Notes = notes,
                VisaPolicyId = visaPolicy?.Id
            };
        }
    }
}