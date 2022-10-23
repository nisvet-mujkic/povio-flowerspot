namespace Povio.FlowerSpot.Contracts.Responses.Sightings
{
    public class CreateSightingResponse
    {
        public int SightingId { get; set; }

        public int UserId { get; set; }

        public int FlowerId { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public string ImageRef { get; set; }

        public string Quote { get; set; }
    }
}