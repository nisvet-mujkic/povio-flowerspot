using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.IntegrationTests.Database;
using Povio.FlowerSpot.IntegrationTests.Mocks;
using Povio.FlowerSpot.Persistence;
using Xunit;

namespace Povio.FlowerSpot.IntegrationTests
{
    public class PovioWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlTestcontainer _dbContainer;

        public PovioWebApplicationFactory()
        {
            _dbContainer = new TestcontainersBuilder<PostgreSqlTestcontainer>()
                .WithDatabase(new PostgreSqlTestcontainerConfiguration()
                {
                    Database = "testdb",
                    Username = "povio",
                    Password = "povio"
                })
                .WithCleanUp(true)
                .Build();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.RemoveAll(typeof(FlowerSpotDbContext));
                services.AddSingleton(_ => new FlowerSpotDbContext(_dbContainer.ConnectionString));

                services.AddSingleton<IQuoteServiceClient, QuoteServiceMock>();

                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var dbContext = scope.ServiceProvider.GetService<FlowerSpotDbContext>();

                if (dbContext is not null)
                {
                    dbContext.Database.Migrate();
                    Seeder.Seed(dbContext);
                }
            });
        }

        public async Task InitializeAsync() =>
            await _dbContainer.StartAsync();

        async Task IAsyncLifetime.DisposeAsync() =>
            await _dbContainer.StopAsync();
    }
}
