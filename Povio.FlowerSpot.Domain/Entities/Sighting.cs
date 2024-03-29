﻿using Povio.FlowerSpot.Domain.Common;
using Povio.FlowerSpot.Domain.ValueObjects;

namespace Povio.FlowerSpot.Domain.Entities
{
    public class Sighting : AuditableEntity
    {
        public int SightingId { get; set; }

        public int UserId { get; set; }

        public int FlowerId { get; set; }

        public Coordinates Coordinates { get; set; }

        public string ImageRef { get; set; }

        public string Quote { get; set; }

        public User User { get; set; }

        public Flower Flower { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
