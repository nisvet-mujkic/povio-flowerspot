using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Configurations
{
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder
                .HasKey(b => new { b.UserId, b.SightingId });
        }
    }
}
