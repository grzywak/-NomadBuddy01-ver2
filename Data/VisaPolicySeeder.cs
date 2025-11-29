using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public static class VisaPolicySeeder
    {
        public static async Task SeedVisaPoliciesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (await dbContext.VisaPolicies.AnyAsync())
                return;

            var visaPolicies = new List<VisaPolicy>
            {
                // Europe
                new VisaPolicy
                {
                    NationalityId = 1, // Poland
                    CountryId = 2, // Spain
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for up to 90 days within a 180-day period.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 3, // France
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for tourism or business for up to 90 days.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 4, // Germany
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free access with a valid passport.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 10, // Netherlands
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for short stays.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 7, // Portugal
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry with a passport for short-term stays.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 8, // Italy
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free stay for tourism or business for up to 90 days.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 5, // United Kingdom
                    AccessType = VisaAccessType.VisaRequired,
                    AllowedStayDays = 180,
                    Notes = "Visa required for tourism or business stays up to 180 days.",
                    EstimatedCostUSD = 100
                },

                // North America
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 6, // United States
                    AccessType = VisaAccessType.ETA,
                    AllowedStayDays = 90,
                    Notes = "Electronic System for Travel Authorization (ESTA) required for stays up to 90 days.",
                    EstimatedCostUSD = 21
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 9, // Canada
                    AccessType = VisaAccessType.ETA,
                    AllowedStayDays = 180,
                    Notes = "Electronic Travel Authorization (eTA) required before travel.",
                    EstimatedCostUSD = 7
                },

                // Australia and Oceania
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 11, // Australia
                    AccessType = VisaAccessType.ETA,
                    AllowedStayDays = 90,
                    Notes = "Electronic Travel Authority (ETA) required before travel.",
                    EstimatedCostUSD = 20
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 12, // New Zealand
                    AccessType = VisaAccessType.ETA,
                    AllowedStayDays = 90,
                    Notes = "New Zealand Electronic Travel Authority (NZeTA) required before arrival.",
                    EstimatedCostUSD = 9
                },

                // Asia
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 13, // Japan
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for up to 90 days for tourism or business.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 14, // South Korea
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for stays up to 90 days.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 15, // Thailand
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 30,
                    Notes = "Visa-free entry for up to 30 days for tourism purposes.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 16, // India
                    AccessType = VisaAccessType.EVisa,
                    AllowedStayDays = 60,
                    Notes = "Electronic visa (e-Visa) required before travel.",
                    EstimatedCostUSD = 25
                },

                // South America
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 17, // Brazil
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for up to 90 days for tourism or business.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 18, // Argentina
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free stay for up to 90 days.",
                    EstimatedCostUSD = null
                },

                // Africa
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 19, // South Africa
                    AccessType = VisaAccessType.VisaFree,
                    VisaFreePeriodDays = 90,
                    Notes = "Visa-free entry for up to 90 days.",
                    EstimatedCostUSD = null
                },
                new VisaPolicy
                {
                    NationalityId = 1,
                    CountryId = 20, // Egypt
                    AccessType = VisaAccessType.VisaOnArrival,
                    AllowedStayDays = 30,
                    Notes = "Visa available on arrival or apply for an e-Visa before travel.",
                    EstimatedCostUSD = 25
                }
            };

            dbContext.VisaPolicies.AddRange(visaPolicies);
            await dbContext.SaveChangesAsync();
        }
    }
}

