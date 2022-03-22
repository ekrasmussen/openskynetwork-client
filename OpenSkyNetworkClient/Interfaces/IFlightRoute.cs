using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenSkyNetworkClient.Converters;
using OpenSkyNetworkClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
