using Throw;

namespace Povio.FlowerSpot.Domain.ValueObjects
{
    public record Coordinates(decimal Longitude, decimal Latitude)
    {
        public static Coordinates Create(decimal longitude, decimal latitude)
        {
            longitude.Throw()
                .IfLessThan(-180)
                .IfGreaterThan(180);

            latitude.Throw()
                .IfLessThan(-90)
                .IfGreaterThan(90);

            return new(longitude, latitude);
        }
    }
}