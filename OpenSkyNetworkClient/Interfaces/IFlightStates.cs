using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Interfaces
{
    [JsonConverter(typeof(InterfaceConverter<IFlightStates, FlightStates>))]
    public interface IFlightStates
    {
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "time")]
        DateTime Time { get;}

        [JsonConverter(typeof(FlightStateArrayConverter))]
        IFlightState[] States { get; }
    }
}
