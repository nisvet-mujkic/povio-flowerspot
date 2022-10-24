namespace Povio.FlowerSpot.Contracts.Responses.Flowers
{
    public class GetFlowersResponse
    {
        public List<FlowerDto> Flowers { get; set; } = new();
    }

    public class FlowerDto
    {
        public string Name { get; set; } = string.Empty;

        public string ImageRef { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

    }
}