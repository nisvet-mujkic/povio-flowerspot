using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Povio.FlowerSpot.Application.Contracts.Persistence;
using Povio.FlowerSpot.Persistence.Repositories;

namespace Povio.FlowerSpot.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FlowerSpotConnectionString");
            services.AddScoped(_ => new FlowerSpotDbContext(connectionString));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IFlowerRepository, FlowerRepository>();
            services.AddScoped<ISightingRepository, SightingRepository>();

            return services;
        }
    }
}
