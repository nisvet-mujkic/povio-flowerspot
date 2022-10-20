using Microsoft.EntityFrameworkCore;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        private readonly FlowerSpotDbContext _dbContext;

        public LikeRepository(FlowerSpotDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Like> FindByCompositeKeyAsync(int sigtingId, int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.Like.FindAsync(new object[] { sigtingId, userId }, cancellationToken);
        }

        public async Task<int> GetNumberOfLikesAsync(int sightingId, CancellationToken cancellationToken)
        {
            return await _dbContext.Like.CountAsync(x => x.SightingId == sightingId, cancellationToken);
        }
    }
}