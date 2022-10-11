using Povio.FlowerSpot.Domain.Common;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class Flower : AuditableEntity
    {
        public int FlowerId { get; set; }

        public string Name { get; set; }

        public string ImageRef { get; set; }

        public string Description { get; set; }
    }
}