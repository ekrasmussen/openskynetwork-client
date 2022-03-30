using Newtonsoft.Json;
using OpenSkyNetworkClient.Model;

namespace OpenSkyNetworkClient.Converters
{
    class FlightStateArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => objectType == typeof(FlightState[]);

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartArray)
            {
                return serializer.Deserialize<FlightState[]>(reader);
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            => throw new NotImplementedException();
    }
}
