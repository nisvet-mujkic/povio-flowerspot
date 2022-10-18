using Microsoft.Extensions.DependencyInjection;
using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.Infrastructure.Clients;

namespace Povio.FlowerSpot.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IQuoteClient, QuoteClient>();

            return services;
        }
    }
}