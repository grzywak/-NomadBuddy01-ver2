using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface INationalityRepository
    {
        Task<List<Nationality>> GetAllNationalitiesAsync();
    }
}
