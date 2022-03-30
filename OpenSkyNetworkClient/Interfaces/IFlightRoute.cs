using Newtonsoft.Json;
using OpenSkyNetworkClient.Converters;
using OpenSkyNetworkClient.Model;

namespace OpenSkyNetworkClient.Interfaces
{
    [JsonConverter(typeof(InterfaceConverter<IFlightRoute, FlightRoute>))]
    public interface IFlightRoute
    {
        string Callsign { get; }
        string[] Route { get; }

        //[JsonConverter(typeof(UnixDateTimeConverter))]
        //[JsonProperty(PropertyName = "updateTime")]
        //DateTime? UpdateTime { get; } 
        string OperatorIata { get; }
        int FlightNumber { get; }
    }
}
