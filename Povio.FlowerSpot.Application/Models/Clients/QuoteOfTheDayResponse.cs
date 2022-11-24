namespace Povio.FlowerSpot.Application.Models.Clients
{
    public class QuoteOfTheDayResponse
    {
        public QuoteResponseContent Contents { get; set; } = new();
    }

    public class QuoteResponseContent
    {
        public IReadOnlyCollection<QuoteItem> Quotes { get; set; } = new List<QuoteItem>();
    }

    public class QuoteItem
    {
        public string Quote { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
    }

    public static class QuoteOfTheDayResponseExtensions
    {
        public static string GetQuoteOfTheDay(this QuoteOfTheDayResponse response)
        {
            var quotes = response.Contents.Quotes;

            return quotes.Any() ? quotes.First().Quote : string.Empty;
        }
    }
}