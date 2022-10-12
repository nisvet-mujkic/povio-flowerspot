using Povio.FlowerSpot.Domain.Common;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class Like : AuditableEntity
    {
        public int UserId { get; set; }

        public int SightingId { get; set; }


        public User User { get; set; }

        public Sighting Sighting { get; set; }
    }
}