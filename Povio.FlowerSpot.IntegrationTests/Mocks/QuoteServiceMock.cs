using Povio.FlowerSpot.Application.Contracts.Clients;
using Povio.FlowerSpot.Application.Models.Clients;

namespace Povio.FlowerSpot.IntegrationTests.Mocks
{
    public class QuoteServiceMock : IQuoteServiceClient
    {
        public Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync()
        {
            var response = new QuoteOfTheDayResponse()
            {
                Contents = new QuoteResponseContent()
                {
                    Quotes = new List<QuoteItem>() {
                        new QuoteItem()
                        {
                            Author = "author of the quote",
                            Quote = "quote from the author"
                        }
                    }
                }
            };

            return Task.FromResult(response);
        }

        public Task<QuoteOfTheDayResponse> GetQuoteOfTheDayAsync(string category)
        {
            var response = new QuoteOfTheDayResponse()
            {
                Contents = new QuoteResponseContent()
                {
                    Quotes = new List<QuoteItem>() {
                        new QuoteItem()
                        {
                            Author = "author of the quote",
                            Quote = "quote from the author"
                        }
                    }
                }
            };

            return Task.FromResult(response);
        }
    }
}