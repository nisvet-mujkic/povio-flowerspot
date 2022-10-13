using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Application.Contracts.Persistence
{
    public interface ISightingRepository : IAsyncRepository<Sighting>
    {
    }
}