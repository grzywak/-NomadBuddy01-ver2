using NomadBuddy00.Data;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class BuddySupportRepository : IBuddySupportRepository
    {
        private readonly AppDbContext _context;

        public BuddySupportRepository(AppDbContext context)
        {
            _context = context;   
        }
        public Task AddAsync(BuddySupport support)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuddySupport>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BuddySupport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BuddySupport s)
        {
            throw new NotImplementedException();
        }
    }
}
