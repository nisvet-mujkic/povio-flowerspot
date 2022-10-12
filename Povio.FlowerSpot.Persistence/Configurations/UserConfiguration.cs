using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Povio.FlowerSpot.Domain.Entities;

namespace Povio.FlowerSpot.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder
            //    .HasKey(b => b.UserId);
        }
    }
}