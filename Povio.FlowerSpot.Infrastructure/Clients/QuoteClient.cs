using Povio.FlowerSpot.Application.Contracts.Clients;

namespace Povio.FlowerSpot.Infrastructure.Clients
{
    public class QuoteClient : IQuoteClient
    {
        public QuoteClient()
        {

        }

        public Task<string> GetQuoteOfTheDayAsync()
        {
            return Task.FromResult("QUOTE OF THE DAY");
        }
    }
}