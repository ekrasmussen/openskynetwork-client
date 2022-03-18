using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Model
{
    internal class BoundingBox
    {
        float minlat, minlon;
        float maxlat, maxlon;

        public BoundingBox(float _minlat, float _minlon, float _maxlat, float _maxlon)
        { 
            minlat = _minlat;
            minlon = _minlon;
            maxlat = _maxlat;
            maxlon = _maxlon;
        }
    }
}
