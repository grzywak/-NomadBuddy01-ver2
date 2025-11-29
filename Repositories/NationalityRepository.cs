using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly AppDbContext _context;

        public NationalityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nationality>> GetAllNationalitiesAsync()
        {
            return await _context.Nationalities.ToListAsync();
        }
    }
}
