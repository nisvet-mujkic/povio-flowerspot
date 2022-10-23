using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.Infrastructure.Clients;
using Povio.FlowerSpot.Infrastructure.Configurations;

namespace Povio.FlowerSpot.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection(QuoteServiceConfiguration.Position)
                .Get<QuoteServiceConfiguration>();

            services.AddHttpClient<IQuoteServiceClient, QuoteServiceClient>(config =>
            {
                config.BaseAddress = new Uri(options.BaseUrl);
            });

            return services;
        }
    }
}