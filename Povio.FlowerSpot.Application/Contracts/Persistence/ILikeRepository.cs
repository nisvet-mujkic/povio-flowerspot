﻿using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Contracts.Persistence
{
    public interface ILikeRepository : IAsyncRepository<Like>
    {
        Task<Like> FindByCompositeKeyAsync(int sigtingId, int userId, CancellationToken cancellation);

        Task<int> GetNumberOfLikesAsync(int sightingId, CancellationToken cancellationToken);
    }
}
