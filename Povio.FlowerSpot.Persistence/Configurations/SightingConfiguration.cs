using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Configurations
{
    public class SightingConfiguration : IEntityTypeConfiguration<Sighting>
    {
        public void Configure(EntityTypeBuilder<Sighting> builder)
        {
            builder.HasKey(x => x.SightingId);

            builder.OwnsOne(x => x.Coordinates, sb =>
            {
                sb.Property(x => x.Longitude).HasColumnName("Longitude");
                sb.Property(x => x.Latitude).HasColumnName("Latitude");
            });
        }
    }
}
