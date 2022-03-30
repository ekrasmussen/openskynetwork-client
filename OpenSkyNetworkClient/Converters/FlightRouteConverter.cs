using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenSkyNetworkClient.Model;

namespace OpenSkyNetworkClient.Converters
{
    class FlightRouteConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(FlightRoute);

        public override bool CanRead => true;
        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonArray = JArray.Load(reader);

            return new FlightRoute()
            {
                Callsign = jsonArray[0].Value<string>(),
                Route = jsonArray[1].Value<string[]>(),
                //UpdateTime = jsonArray[2].Value<long?>().FromUnixTimestamp(),
                OperatorIata = jsonArray[3].Value<string>(),
                FlightNumber = jsonArray[4].Value<int>()
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
}
