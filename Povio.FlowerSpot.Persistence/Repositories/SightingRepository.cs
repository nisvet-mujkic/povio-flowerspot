using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class SightingRepository : BaseRepository<Sighting>, ISightingRepository
    {
        public SightingRepository(FlowerSpotDbContext dbContext) : base(dbContext)
        {
        }
    }
}