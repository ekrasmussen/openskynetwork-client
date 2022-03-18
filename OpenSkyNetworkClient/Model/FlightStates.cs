using OpenSkyNetworkClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Model
{
    class FlightStates : IFlightStates
    {
        public DateTime Time { get; set; }

        public IFlightState[] States { get; set; }
    }
}
