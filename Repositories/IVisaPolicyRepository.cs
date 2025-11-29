using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IVisaPolicyRepository
    {
        Task<List<VisaPolicy>> GetVisaPoliciesForUserNationalityAsync(string nomadId);
        Task<VisaPolicy?> GetVisaPolicyAsync(int visaPolicyId);
        Task<int?> GetVisaPolicyIdAsync(string nomadId, int countryId);
    }
}
