using System.Text.Json.Serialization;

namespace Povio.FlowerSpot.Application.Models.Clients
{
    public class QuoteOfTheDayResponse
    {
        public QuoteResponseContent Contents { get; set; }
    }

    public class QuoteResponseContent
    {
        public IReadOnlyCollection<QuoteItem> Quotes { get; set; }
    }

    public class QuoteItem
    {
        public string Quote { get; set; }

        public string Author { get; set; }
    }
}