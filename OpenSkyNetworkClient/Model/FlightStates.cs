using OpenSkyNetworkClient.Interfaces;

namespace OpenSkyNetworkClient.Model
{
    class FlightStates : IFlightStates
    {
        public DateTime Time { get; set; }

        public IFlightState[] States { get; set; }
    }
}
