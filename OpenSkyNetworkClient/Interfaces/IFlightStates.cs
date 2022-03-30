using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenSkyNetworkClient.Converters;
using OpenSkyNetworkClient.Model;

namespace OpenSkyNetworkClient.Interfaces
{
    [JsonConverter(typeof(InterfaceConverter<IFlightStates, FlightStates>))]
    public interface IFlightStates
    {
        /// <summary>
        /// The time which the state vectors in this response are associated with. All vectors represent the state of a vehicle with the interval [time−1,time][time−1,time].
        /// </summary>  
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(PropertyName = "time")]
        DateTime Time { get; }

        /// <summary>
        /// The state vectors.
        /// </summary>  
        [JsonConverter(typeof(FlightStateArrayConverter))]
        IFlightState[] States { get; }
    }
}
