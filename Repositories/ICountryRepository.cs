using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryByIdAsync(int id);
        Task<List<Country>> GetCountriesByContinentAsync(Continent continent);
    }
}
