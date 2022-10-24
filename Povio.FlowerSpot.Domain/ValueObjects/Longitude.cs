namespace Povio.FlowerSpot.Domain.ValueObjects
{
    public class Longitude
    {
        private readonly decimal _longitude;

        private Longitude(decimal longitude)
        {
            _longitude = longitude;
        }

        public static Longitude Create(decimal longitude)
        {
            if (longitude < -180 || longitude > 180)
                throw new ArgumentOutOfRangeException(nameof(longitude));

            return new Longitude(longitude);
        }
    }
}