using Ardalis.HttpClientTestExtensions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Povio.FlowerSpot.Contracts.Responses.Sightings;
using System.Net.Http.Headers;
using Xunit;

namespace Povio.FlowerSpot.IntegrationTests.Controllers
{
    public class LikeControllerTests : IClassFixture<PovioWebApplicationFactory>
    {
        private readonly PovioWebApplicationFactory _factory;

        public LikeControllerTests(PovioWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnNumberOfLikesForASighting()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var response = await client.GetAndDeserializeAsync<GetNumberOfLikesResponse>("api/sightings/2/likes");
            response.NumberOfLikes.Should().Be(1);
        }

        [Fact]
        public async Task UsersCanOnlyDeleteTheirOwnLikeOnSightings()
        {
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "dGVzdDp0ZXN0");

            var response = await client.DeleteAsync("api/sightings/1/likes");
            response.EnsureSuccessStatusCode();
        }
    }
}
