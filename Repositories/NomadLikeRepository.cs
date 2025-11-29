using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Enums;
using NomadBuddy00.Models;

namespace NomadBuddy00.Repositories
{
    public class NomadLikeRepository : INomadLikeRepository
    {
        private readonly AppDbContext _context;

        public NomadLikeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task LikeAsync(string likerId, string targetId, MatchMode mode)
        {
            if (likerId == targetId) return;

            var alreadyExists = await _context.NomadLikes
                .AnyAsync(l => l.LikerId == likerId && l.TargetId == targetId && l.Mode == mode);

            if (alreadyExists) return;

            var like = new NomadLike
            {
                LikerId = likerId,
                TargetId = targetId,
                Mode = mode
            };

            _context.NomadLikes.Add(like);

            // Sprawdź czy druga osoba też dała like
            var reverseLike = await _context.NomadLikes
                .FirstOrDefaultAsync(l => l.LikerId == targetId && l.TargetId == likerId && l.Mode == mode);

            if (reverseLike != null)
            {
                var match = new NomadMatch
                {
                    Nomad1Id = likerId,
                    Nomad2Id = targetId,
                    Mode = mode,
                    MatchedAt = DateTime.UtcNow
                };

                _context.NomadMatches.Add(match);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<bool> AlreadyLikedAsync(string likerId, string targetId, MatchMode mode)
        {
            return await _context.NomadLikes
                .AnyAsync(l => l.LikerId == likerId && l.TargetId == targetId && l.Mode == mode);
        }
    }
}
