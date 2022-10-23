using Povio.FlowerSpot.Infrastructure.Configurations;

namespace Povio.FlowerSpot.Api.Extensions
{
    public static class ConfigurationsRegistration
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<QuoteServiceConfiguration>()
                .Bind(configuration.GetSection(QuoteServiceConfiguration.Position))
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services;
        }
    }
}
