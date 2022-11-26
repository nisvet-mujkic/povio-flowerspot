using FluentAssertions;
using Xunit;

namespace Povio.FlowerSpot.IntegrationTests.HealthCheck
{
    public class HealthCheckTests : IClassFixture<PovioWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public HealthCheckTests(PovioWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task AppIsInAHealthyStateWhenStarted()
        {
            var response = await _client.GetAsync("/healthz");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            stringResponse.Should().Be("Healthy");
        }
    }
}