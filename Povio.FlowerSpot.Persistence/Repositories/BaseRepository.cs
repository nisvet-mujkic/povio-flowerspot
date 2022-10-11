using Microsoft.EntityFrameworkCore;
using Povio.FlowerSpot.Application.Contracts.Persistence;

namespace Povio.FlowerSpot.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly FlowerSpotDbContext _dbContext;

        public BaseRepository(FlowerSpotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<IReadOnlyCollection<T>> GetAllAsync() =>
            await _dbContext.Set<T>().ToListAsync();

        public virtual async Task<T> GetByIdAsync(int id) =>
            await _dbContext.Set<T>().FindAsync(id);
    }
}
