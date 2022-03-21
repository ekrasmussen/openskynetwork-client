using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Model
{
    public class BoundingBox
    {
        public float MinLat, MinLon;
        public float MaxLat, MaxLon;

        public BoundingBox(float _minlat, float _minlon, float _maxlat, float _maxlon)
        { 
            MinLat = _minlat;
            MinLon = _minlon;
            MaxLat = _maxlat;
            MaxLon = _maxlon;
        }
    }
}
