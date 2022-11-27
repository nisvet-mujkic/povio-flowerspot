using Ardalis.HttpClientTestExtensions;
using Bogus;
using FluentAssertions;
using Povio.FlowerSpot.Application.Features.Flowers.Commands.Create;
using Povio.FlowerSpot.Contracts.Responses.Flowers;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Povio.FlowerSpot.IntegrationTests.Controllers
{
    public class FlowerControllerTests : IClassFixture<PovioWebApplicationFactory>
    {
        private readonly PovioWebApplicationFactory _factory;

        public FlowerControllerTests(PovioWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetNotAllowedForNotAuthenticatedUsers()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("api/flowers");

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task GetFlowersShouldReturnResponse()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var response = await client.GetAndDeserializeAsync<GetFlowersResponse>("api/flowers");

            response.Flowers.Should().NotBeEmpty();
        }

        [Fact]
        public async Task PostShouldCreateNewFlower()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var faker = new Faker<CreateFlowerCommand>()
                .CustomInstantiator(f =>
                    new CreateFlowerCommand(f.Lorem.Word(), f.Internet.Url(), f.Lorem.Paragraph(1)));

            var command = faker.Generate();
            var content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

            var response = await client.PostAndDeserializeAsync<CreateFlowerResponse>("api/flowers", content);

            response.FlowerId.Should().Be(4);
            response.Name.Should().Be(command.Name);
            response.ImageRef.Should().Be(command.ImageRef);
            response.Description.Should().Be(command.Description);
        }
    }
}
