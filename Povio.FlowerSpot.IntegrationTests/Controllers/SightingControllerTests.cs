using Ardalis.HttpClientTestExtensions;
using FluentAssertions;
using Povio.FlowerSpot.Application.Features.Sightings.Commands.Create;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Povio.FlowerSpot.IntegrationTests.Controllers
{
    public class SightingControllerTests : IClassFixture<PovioWebApplicationFactory>
    {
        private readonly PovioWebApplicationFactory _factory;

        public SightingControllerTests(PovioWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PostSightingShouldCreateASighting()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var command = new CreateCommand(111, 60, 1, 1, "image-ref");
            var content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");
            var response = await client.PostAndDeserializeAsync<CreateSightingResponse>("api/sightings", content);

            response.Longitude.Should().Be(command.Longitude);
            response.Latitude.Should().Be(command.Latitude);
            response.FlowerId.Should().Be(command.FlowerId);
            response.ImageRef.Should().Be(command.ImageRef);
            response.UserId.Should().Be(command.UserId);
            response.Quote.Should().Be("quote from the author");
        }

        [Fact]
        public async Task OnlyUserThatCreatedTheSightingCanDeleteIt()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var response = await client.DeleteAsync("api/sightings/1");
            response.EnsureSuccessStatusCode();
        }
    }
}
