namespace Povio.FlowerSpot.Contracts.Responses.Sightings
{
    public class GetSightingsResponse
    {
        public List<SightingDto> Sightings { get; set; } = new();
    }

    public class SightingDto
    {
        public int SightingId { get; set; }

        public int UserId { get; set; }

        public int FlowerId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageRef { get; set; } = string.Empty;

        public string Quote { get; set; } = string.Empty;
    }
}