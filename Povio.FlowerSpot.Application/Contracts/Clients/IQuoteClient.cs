namespace Povio.FlowerSpot.Application.Contracts.Clients
{
    public interface IQuoteClient
    {
        Task<string> GetQuoteOfTheDayAsync();
    }
}