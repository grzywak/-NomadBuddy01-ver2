using NomadBuddy00.Models;
using NomadBuddy00.Repositories;

namespace NomadBuddy00.Services
{
    public class BuddySupportService : IBuddySupportService
    {
        private readonly IBuddySupportRepository _supporRepository;

        public BuddySupportService(IBuddySupportRepository supporRepository)
        {
            _supporRepository = supporRepository;
        }

        public async Task<bool> CreateAsync(BuddySupport model)
        {
            if (string.IsNullOrWhiteSpace(model.Title) ||
                string.IsNullOrWhiteSpace(model.Description))
                {
                return false;
                }

            if (model.Price <0)
                return false;

            model.CreatedAt = DateTime.Now; 
            await _supporRepository.AddAsync(model);
                   return true;
        }

        public async Task<IEnumerable<BuddySupport>> GetAllActiveAsync()
        {
            var allSupports = await _supporRepository.GetAllAsync();
            var activeSupports = allSupports.Where(s => s.IsActive);
            return activeSupports;
        }

        public async Task<BuddySupport?> GetDetailsAsync(int supportId)
        {
               return await _supporRepository.GetByIdAsync(supportId);
        }
    }
}
