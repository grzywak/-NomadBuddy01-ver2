using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class VisaPolicyRepository : IVisaPolicyRepository
    {
        private readonly AppDbContext _context;

        public VisaPolicyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<VisaPolicy>> GetVisaPoliciesForUserNationalityAsync(string nomadId)
        {
            var nomad = await _context.Nomads
                .Include(n => n.Nationality)
                .FirstOrDefaultAsync(n => n.UserId == nomadId);

            if (nomad == null)
            {
                return new List<VisaPolicy>();
            }

            return await _context.VisaPolicies
                .Include(v => v.Country)
                .Where(v => v.NationalityId == nomad.NationalityId)
                .ToListAsync();
        }

        public async Task<VisaPolicy?> GetVisaPolicyAsync(int visaPolicyId)
        {
            return await _context.VisaPolicies
                .Include(v => v.Country)
                .FirstOrDefaultAsync(v => v.Id == visaPolicyId);
        }

        public async Task<int?> GetVisaPolicyIdAsync(string nomadId, int countryId)
        {
            var nomad = await _context.Nomads
                .FirstOrDefaultAsync(n => n.UserId == nomadId);

            if (nomad == null)
            {
                return null;
            }

            var visaPolicy = await _context.VisaPolicies
                .FirstOrDefaultAsync(v => v.NationalityId == nomad.NationalityId && v.CountryId == countryId);

            return visaPolicy?.Id;
        }
    }
}
