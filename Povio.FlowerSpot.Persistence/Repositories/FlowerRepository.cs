using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class FlowerRepository : BaseRepository<Flower>, IFlowerRepository
    {
        public FlowerRepository(FlowerSpotDbContext dbContext) : base(dbContext)
        {
        }
    }
}