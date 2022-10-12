using Povio.FlowerSpot.Domain.Common;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class Sighting : AuditableEntity
    {
        public int SightingId { get; set; }

        public int UserId { get; set; }

        public int FlowerId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageRef { get; set; }


        public User User { get; set; }

        public Flower Flower { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
