using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(FlowerSpotDbContext dbContext) : base(dbContext)
        {
        }
    }
}
