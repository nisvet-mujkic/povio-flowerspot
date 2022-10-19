using Microsoft.EntityFrameworkCore;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly FlowerSpotDbContext _dbContext;

        public UserRepository(FlowerSpotDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string username, string password)
        {
            return await _dbContext.User.FirstOrDefaultAsync(
                user => user.Username == username && user.Password == password);
        }
    }
}
