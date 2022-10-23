using Flurl.Http;
using Microsoft.Extensions.Logging;
using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.Application.Models.Clients;

namespace Povio.FlowerSpot.Infrastructure.Clients
{
    public class QuoteServiceClient : IQuoteServiceClient
    {
        private readonly FlurlClient _client;
        private readonly ILogger<QuoteServiceClient> _logger;

        public QuoteServiceClient(ILogger<QuoteServiceClient> logger, HttpClient client)
        {
            _logger = logger;
            _client = new FlurlClient(client);
        }

        public async Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync()
        {
            try
            {
                return await _client.Request("qod")
                    .GetJsonAsync<QuoteOfTheDayResponse>();
            }
            catch (FlurlHttpException exception)
            {
                _logger.LogError(exception, message: exception.Message);
                throw;
            }
        }

        public async Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync(string category)
        {
            try
            {
                return await _client.Request("qod").SetQueryParam("category", category)
                    .GetJsonAsync<QuoteOfTheDayResponse>();
            }
            catch (FlurlHttpException exception)
            {
                _logger.LogError(exception, message: exception.Message);
                throw;
            }
        }
    }
}