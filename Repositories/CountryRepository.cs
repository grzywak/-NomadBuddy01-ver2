using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _context;

        public CountryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryByIdAsync(int id)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Country>> GetCountriesByContinentAsync(Continent continent)
        {
            return await _context.Countries
                .Where(c => c.Continent == continent)
                .ToListAsync();
        }
    }
}
