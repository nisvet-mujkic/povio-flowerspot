using Povio.FlowerSpot.Domain.Common;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class Sighting : AuditableEntity
    {
        public int SightingId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }
    }
}
