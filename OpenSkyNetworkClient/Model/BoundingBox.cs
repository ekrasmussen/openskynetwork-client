namespace OpenSkyNetworkClient.Model
{
    public class BoundingBox
    {
        public double MinLat, MinLon;
        public double MaxLat, MaxLon;

        public BoundingBox(double _minlat, double _minlon, double _maxlat, double _maxlon)
        {
            MinLat = Math.Round(_minlat, 6, MidpointRounding.AwayFromZero);
            MinLon = Math.Round(_minlon, 6, MidpointRounding.AwayFromZero);
            MaxLat = Math.Round(_maxlat, 6, MidpointRounding.AwayFromZero);
            MaxLon = Math.Round(_maxlon, 6, MidpointRounding.AwayFromZero);
        }
    }
}
