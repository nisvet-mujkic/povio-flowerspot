using Microsoft.EntityFrameworkCore;
using Povio.FlowerSpot.Domain.Common;
using Povio.FlowerSpot.Domain.Entities;
using System.Reflection;

namespace Povio.FlowerSpot.Persistence
{
    public class FlowerSpotDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Flower> Flowers { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Sighting> Sighting { get; set; }

        public DbSet<Like> Like { get; set; }

        public FlowerSpotDbContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}