using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public interface INomadLikeRepository
    {
        Task LikeAsync(string likerId, string targetId, MatchMode mode);
        Task<bool> AlreadyLikedAsync(string likerId, string targetId, MatchMode mode);
    }
}
