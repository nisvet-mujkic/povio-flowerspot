using Povio.FlowerSpot.Application.Models.Clients;

namespace Povio.FlowerSpot.Application.Contracts.Clients
{
    public interface IQuoteServiceClient
    {
        Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync();

        Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync(string category);
    }
}