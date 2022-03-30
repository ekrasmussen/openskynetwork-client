using Newtonsoft.Json.Converters;

namespace OpenSkyNetworkClient.Converters
{
    class InterfaceConverter<TInterface, TClass> : CustomCreationConverter<TInterface>
        where TClass : TInterface, new()
    {
        public override TInterface Create(Type objectType) => new TClass();
    }
}
