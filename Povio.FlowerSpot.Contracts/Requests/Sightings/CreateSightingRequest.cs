namespace Povio.FlowerSpot.Contracts.Requests.Sightings
{
    public class CreateSightingRequest
    {
        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public int FlowerId { get; set; }

        public string ImageRef { get; set; }
    }
}