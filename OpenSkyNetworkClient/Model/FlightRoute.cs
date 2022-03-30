using Newtonsoft.Json;
using OpenSkyNetworkClient.Converters;
using OpenSkyNetworkClient.Interfaces;

namespace OpenSkyNetworkClient.Model
{
    [JsonConverter(typeof(FlightRouteConverter))]
    class FlightRoute : IFlightRoute
    {
        public string Callsign { get; set; }
        public string[] Route { get; set; }
        //public DateTime? UpdateTime { get; set; }
        public string OperatorIata { get; set; }
        public int FlightNumber { get; set; }

        public FlightRoute()
        {
        }
    }
}
