namespace Povio.FlowerSpot.Contracts.Responses.Flowers
{
    public class GetFlowersResponse
    {
        public List<FlowerDto> Flowers { get; set; }
    }

    public class FlowerDto
    {
        public string Name { get; set; }
    }
}