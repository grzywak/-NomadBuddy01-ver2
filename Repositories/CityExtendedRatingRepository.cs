using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Repositories
{
    public class CityExtendedRatingRepository : ICityExtendedRatingRepository
    {
        private readonly AppDbContext _context;

        public CityExtendedRatingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CitySafetyRating?> GetUserSafetyRatingAsync(int cityId, string nomadId)
        {
            return await _context.CitySafetyRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId && r.NomadId == nomadId);
        }

        public async Task<CitySafetyStatsViewModel> GetSafetyStatsAsync(int cityId)
        {
            var ratings = await _context.CitySafetyRatings
                .Where(r => r.CityId == cityId)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new CitySafetyStatsViewModel();
            }

            return new CitySafetyStatsViewModel
            {
                AvgDaySafety = ratings.Average(r => r.DaySafety),
                AvgNightSafety = ratings.Average(r => r.NightSafety),
                HarassmentRate = (double)ratings.Count(r => r.FeltHarassed) / ratings.Count * 100
            };
        }

        public async Task SubmitSafetyRatingAsync(CitySafetyRating rating)
        {
            var existing = await _context.CitySafetyRatings
                .FirstOrDefaultAsync(r => r.CityId == rating.CityId && r.NomadId == rating.NomadId);

            if (existing != null)
            {
                existing.DaySafety = rating.DaySafety;
                existing.NightSafety = rating.NightSafety;
                existing.FeltHarassed = rating.FeltHarassed;
                existing.SubmittedAt = DateTime.UtcNow;
            }
            else
            {
                rating.SubmittedAt = DateTime.UtcNow;
                _context.CitySafetyRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SubmitHealthcareRatingAsync(CityHealthcareRating rating)
        {
            var existing = await _context.CityHealthcareRatings
                .FirstOrDefaultAsync(r => r.CityId == rating.CityId && r.NomadId == rating.NomadId);

            if (existing != null)
            {
                existing.AvailabilityScore = rating.AvailabilityScore;
                existing.AvgDoctorVisitCost = rating.AvgDoctorVisitCost;
                existing.AvgInsuranceMonthlyCost = rating.AvgInsuranceMonthlyCost;
                existing.SubmittedAt = DateTime.UtcNow;
            }
            else
            {
                rating.SubmittedAt = DateTime.UtcNow;
                _context.CityHealthcareRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<CityHealthcareRating?> GetUserHealthcareRatingAsync(int cityId, string nomadId)
        {
            return await _context.CityHealthcareRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId && r.NomadId == nomadId);
        }

        public async Task<CityHealthcareStatsViewModel> GetHealthcareStatsAsync(int cityId)
        {
            var ratings = await _context.CityHealthcareRatings
                .Where(r => r.CityId == cityId)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new CityHealthcareStatsViewModel();
            }

            return new CityHealthcareStatsViewModel
            {
                AvgAvailabilityScore = ratings.Average(r => r.AvailabilityScore),
                AvgDoctorVisitCost = ratings.Average(r => r.AvgDoctorVisitCost),
                AvgInsuranceMonthlyCost = ratings.Average(r => r.AvgInsuranceMonthlyCost)
            };
        }

        public async Task<CityEntertainmentStatsViewModel> GetEntertainmentStatsAsync(int cityId)
        {
            var ratings = await _context.CityEntertainmentRatings
                .Where(r => r.CityId == cityId)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new CityEntertainmentStatsViewModel();
            }

            return new CityEntertainmentStatsViewModel
            {
                AvgNightlifeScore = ratings.Average(r => r.NightlifeScore),
                AvgEventsFrequencyScore = ratings.Average(r => r.EventsFrequencyScore),
                AvgYouthVibeScore = ratings.Average(r => r.YouthVibeScore)
            };
        }

        public async Task<CityEntertainmentRating?> GetUserEntertainmentRatingAsync(int cityId, string nomadId)
        {
            return await _context.CityEntertainmentRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId && r.NomadId == nomadId);
        }

        public async Task SubmitEntertainmentRatingAsync(CityEntertainmentRating rating)
        {
            var existing = await _context.CityEntertainmentRatings
                .FirstOrDefaultAsync(r => r.CityId == rating.CityId && r.NomadId == rating.NomadId);

            if (existing != null)
            {
                existing.NightlifeScore = rating.NightlifeScore;
                existing.EventsFrequencyScore = rating.EventsFrequencyScore;
                existing.YouthVibeScore = rating.YouthVibeScore;
                existing.SubmittedAt = DateTime.UtcNow;
            }
            else
            {
                rating.SubmittedAt = DateTime.UtcNow;
                _context.CityEntertainmentRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<CityTransportStatsViewModel> GetTransportStatsAsync(int cityId)
        {
            var ratings = await _context.CityTransportRatings
                .Where(r => r.CityId == cityId)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new CityTransportStatsViewModel();
            }

            return new CityTransportStatsViewModel
            {
                AvgPublicTransportScore = ratings.Average(r => r.PublicTransportScore),
                AvgNightTransportScore = ratings.Average(r => r.NightTransportScore),
                AvgBikeFriendlyScore = ratings.Average(r => r.BikeFriendlyScore),
                AvgWalkabilityScore = ratings.Average(r => r.WalkabilityScore),
                AvgTransportCostScore = ratings.Average(r => r.TransportCostScore),
                AvgAppConvenienceScore = ratings.Average(r => r.AppConvenienceScore),
                AvgMotorbikeEaseScore = ratings.Average(r => r.MotorbikeEaseScore)
            };
        }

        public async Task<CityTransportRating?> GetUserTransportRatingAsync(int cityId, string nomadId)
        {
            return await _context.CityTransportRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId && r.NomadId == nomadId);
        }

        public async Task SubmitTransportRatingAsync(CityTransportRating rating)
        {
            var existing = await _context.CityTransportRatings
                .FirstOrDefaultAsync(r => r.CityId == rating.CityId && r.NomadId == rating.NomadId);

            if (existing != null)
            {
                existing.PublicTransportScore = rating.PublicTransportScore;
                existing.NightTransportScore = rating.NightTransportScore;
                existing.BikeFriendlyScore = rating.BikeFriendlyScore;
                existing.WalkabilityScore = rating.WalkabilityScore;
                existing.TransportCostScore = rating.TransportCostScore;
                existing.AppConvenienceScore = rating.AppConvenienceScore;
                existing.MotorbikeEaseScore = rating.MotorbikeEaseScore;
                existing.Comment = rating.Comment;
                existing.SubmittedAt = DateTime.UtcNow;
            }
            else
            {
                rating.SubmittedAt = DateTime.UtcNow;
                _context.CityTransportRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task SubmitCostOfLivingRatingAsync(CityCostOfLivingRating rating)
        {
            var existing = await _context.CityCostOfLivingRatings
                .FirstOrDefaultAsync(r => r.CityId == rating.CityId
                    && r.NomadId == rating.NomadId
                    && r.BudgetLevel == rating.BudgetLevel
                    && r.IsMonthly == rating.IsMonthly);

            if (existing != null)
            {
                existing.Food = rating.Food;
                existing.Housing = rating.Housing;
                existing.Transport = rating.Transport;
                existing.Leisure = rating.Leisure;
                existing.SubmittedAt = DateTime.UtcNow;
            }
            else
            {
                rating.SubmittedAt = DateTime.UtcNow;
                _context.CityCostOfLivingRatings.Add(rating);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<CityCostOfLivingRating?> GetUserCostOfLivingRatingAsync(int cityId, string nomadId, TravelBudget budget, bool isMonthly)
        {
            return await _context.CityCostOfLivingRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId
                    && r.NomadId == nomadId
                    && r.BudgetLevel == budget
                    && r.IsMonthly == isMonthly);
        }

        public async Task<CityCostOfLivingStatsViewModel> GetCostOfLivingStatsAsync(int cityId, TravelBudget budget, bool isMonthly)
        {
            var ratings = await _context.CityCostOfLivingRatings
                .Where(r => r.CityId == cityId
                    && r.BudgetLevel == budget
                    && r.IsMonthly == isMonthly)
                .ToListAsync();

            if (!ratings.Any())
            {
                return new CityCostOfLivingStatsViewModel
                {
                    BudgetLevel = budget,
                    IsMonthly = isMonthly
                };
            }

            return new CityCostOfLivingStatsViewModel
            {
                AvgFood = ratings.Average(r => r.Food),
                AvgHousing = ratings.Average(r => r.Housing),
                AvgTransport = ratings.Average(r => r.Transport),
                AvgLeisure = ratings.Average(r => r.Leisure),
                TotalRatingsCount = ratings.Count(),
                BudgetLevel = budget,
                IsMonthly = isMonthly
            };
        }

        public async Task<List<CityCostOfLivingStatsViewModel>> GetAllCostOfLivingStatsAsync(int cityId)
        {
            var allCombinations = new List<CityCostOfLivingStatsViewModel>();

            foreach (TravelBudget budget in Enum.GetValues(typeof(TravelBudget)))
            {
                foreach (bool isMonthly in new[] { true, false })
                {
                    var ratings = await _context.CityCostOfLivingRatings
                        .Where(r => r.CityId == cityId
                            && r.BudgetLevel == budget
                            && r.IsMonthly == isMonthly)
                        .ToListAsync();

                    if (ratings.Any())
                    {
                        allCombinations.Add(new CityCostOfLivingStatsViewModel
                        {
                            AvgFood = ratings.Average(r => r.Food),
                            AvgHousing = ratings.Average(r => r.Housing),
                            AvgTransport = ratings.Average(r => r.Transport),
                            AvgLeisure = ratings.Average(r => r.Leisure),
                            TotalRatingsCount = ratings.Count,
                            BudgetLevel = budget,
                            IsMonthly = isMonthly
                        });
                    }
                    else
                    {
                        allCombinations.Add(new CityCostOfLivingStatsViewModel
                        {
                            AvgFood = 0,
                            AvgHousing = 0,
                            AvgTransport = 0,
                            AvgLeisure = 0,
                            TotalRatingsCount = 0,
                            BudgetLevel = budget,
                            IsMonthly = isMonthly
                        });
                    }
                }
            }

            return allCombinations;
        }


        public async Task SaveOrUpdateOverallRatingAsync(int cityId, double score, string nomadId)
        {
            var existing = await _context.CityOverallRatings
                .FirstOrDefaultAsync(r => r.CityId == cityId && r.IsSystemGenerated && r.NomadId == nomadId);

            if (existing != null)
            {
                existing.OverallScore = (int)Math.Round(score);
                existing.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                var newRating = new CityOverallRating
                {
                    CityId = cityId,
                    NomadId = nomadId,
                    OverallScore = (int)Math.Round(score),
                    IsSystemGenerated = true,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.CityOverallRatings.Add(newRating);
            }

            await _context.SaveChangesAsync();
        }



    }
}
