using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;
using NomadBuddy00.ViewModels;

namespace NomadBuddy00.Repositories
{
    public class CityRecommendationRepository : ICityRecommendationRepository
    {
        private readonly AppDbContext _context;

        public CityRecommendationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<List<City>> GetAllCitiesWithRatingsAsync()
        {
            return await _context.Cities
                                 .Include(c => c.Ratings)
                                 .Include(c => c.TagVotes)
                                        .ThenInclude(t => t.CityTag)
                                 .ToListAsync();
        }
        public async Task<City?> GetCityDetailsAsync(int cityId)
        {
            return await _context.Cities
                .Include(c => c.Ratings)
                .Include(c => c.TagVotes)
                        .ThenInclude (t => t.CityTag)
                .FirstOrDefaultAsync(c => c.Id == cityId);
        }

        public async Task<List<City>> GetCitiesByCountryAsync(int countryId)
        {
            return await _context.Cities
                                 .Where(c => c.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<List<CityTag>> GetAllCityTagsAsync()
        {
            return await _context.CityTags.ToListAsync();
        }
        public async Task AddTagVoteAsync(CityTagVote vote)
        {
            _context.CityTagVotes.Add(vote);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CityRecommendationResult>> GetTopRecommendedCitiesAsync(string nomadId)
        {
            //TODO hybrid logic here
            var cities = await _context.Cities
                         .Include(c => c.Ratings)
                         .Include(c => c.TagVotes)
                                .ThenInclude(t => t.CityTag)
                         .ToListAsync();

            var results = cities.Select(city => new CityRecommendationResult
            {
                City = city,
                AverageRating = city.Ratings.Any() ? city.Ratings.Average(r => r.OverallScore) : (double?)null
            })
                    .OrderByDescending(r => r.AverageRating)
                    .Take(5)
                    .ToList();

            return results;
        }

        public async Task<List<CityRecommendationResult>> GetFilteredRecommendedCitiesAsync(
            string nomadId,
            TravelBudget? budget,
            Continent? continent,
            int? countryId)
        {
            var citiesQuery = _context.Cities
                .Include(c => c.Ratings)
                .Include(c => c.Country)
                .Include(c => c.TagVotes)
                    .ThenInclude(t => t.CityTag)
                .AsQueryable();

            if (countryId.HasValue)
                citiesQuery = citiesQuery.Where(c => c.CountryId == countryId);

            if (continent.HasValue)
                citiesQuery = citiesQuery.Where(c => c.Country.Continent == continent.Value);

            var cities = await citiesQuery.ToListAsync();

            var results = cities.Select(city => new CityRecommendationResult
            {
                City = city,
                AverageRating = city.Ratings.Any() ? city.Ratings.Average(r => r.OverallScore) : (double?)null
            })
            .OrderByDescending(r => r.AverageRating)
            .Take(10)
            .ToList();

            return results;
        }

        public async Task<CityDetailsViewModel> GetCityDetailsWithRatingsAsync(int cityId, string nomadId)
        {
            var city = await _context.Cities
                .Include(c => c.Ratings)
                .Include(c => c.TagVotes).ThenInclude(t => t.CityTag)
                .FirstOrDefaultAsync(c => c.Id == cityId);

            if (city == null) return null!;

            var ratings = city.Ratings;
            var avg = new CityDetailsViewModel
            {
                City = city,
                //AvgInternet = ratings.Any() ? ratings.Average(r => r.InternetScore) : 0,
                //AvgCoworking = ratings.Any() ? ratings.Average(r => r.CoworkingScore) : 0,
                //AvgHealthcare = ratings.Any() ? ratings.Average(r => r.HealthcareScore) : 0,
                AvgOverall = ratings.Any() ? ratings.Average(r => r.OverallScore) : 0,
                UserRating = ratings.FirstOrDefault(r => r.NomadId == nomadId)
            };

            return avg;
        }
        public async Task AddOrUpdateCityRatingAsync(CityRatingViewModel cityRatingViewModel, string nomadId)
        {
            var existingRating = await _context.CityOverallRatings
                                        .FirstOrDefaultAsync(r => r.CityId == cityRatingViewModel.CityId
                                        && r.NomadId == nomadId);

            if (existingRating != null)
            {
                //existingRating.InternetScore = cityRatingViewModel.InternetScore;
                //existingRating.CoworkingScore = cityRatingViewModel.CoworkingScore;
                //existingRating.HealthcareScore = cityRatingViewModel.HealthcareScore;
                existingRating.OverallScore = cityRatingViewModel.OverallScore;
            }
            else
            {
                var rating = new CityOverallRating
                {
                    CityId = cityRatingViewModel.CityId,
                    NomadId = nomadId,
                    //InternetScore = cityRatingViewModel.InternetScore,
                    //CoworkingScore = cityRatingViewModel.CoworkingScore,
                    //HealthcareScore = cityRatingViewModel.HealthcareScore,
                    OverallScore = cityRatingViewModel.OverallScore
                };
                _context.CityOverallRatings.Add(rating);
            }
                                        
            await _context.SaveChangesAsync();
        }

        public async Task<List<CityRecommendationResult>> GetRecommendedCitiesForNomadTypeAsync(NomadType nomadType, int count = 5)
        {
            var ratings = await _context.CityOverallRatings
                .Include(r => r.City)
                    .ThenInclude(c => c.Country)
                .Include(r => r.Nomad)
                .Where(r => r.Nomad.NomadType == nomadType)
                .ToListAsync();

            var grouped = ratings
                .GroupBy(r => r.City)
                .Select(g => new CityRecommendationResult
                {
                    City = g.Key,
                    AverageRating = g.Average(r => r.OverallScore)
                })
                .OrderByDescending(r => r.AverageRating)
                .Take(count)
                .ToList();

            return grouped;
        }


    }
}
