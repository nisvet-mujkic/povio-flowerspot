using Xunit;

namespace Povio.FlowerSpot.IntegrationTests
{
    public class TestFixture : IClassFixture<PovioWebApplicationFactory>
    {
        private readonly PovioWebApplicationFactory _factory;

        protected HttpClient Client => _factory.CreateClient();

        public TestFixture(PovioWebApplicationFactory factory)
        {
            _factory = factory;
        }
    }
}