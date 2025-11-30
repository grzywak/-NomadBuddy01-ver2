using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface IBuddySupportRatingRepository
    {

        Task<BuddySupportRating> GetByIdAsync(int Id);
        Task<IEnumerable<BuddySupportRating>> GetAllAsync();
        Task DeleteAsync(int ratingId);
        Task AddAsync(BuddySupportRating rating);
        Task UpdateAsync(BuddySupportRating rating);

        //do wyszukiwania ratings wg buddy lub session 
        Task<IEnumerable<BuddySupportRating>> GetRatingsForBuddyAsync(string buddyId);
        Task<IEnumerable<BuddySupportRating>> GetRatingsForSessionAsync(int sessionId);
    }


}
