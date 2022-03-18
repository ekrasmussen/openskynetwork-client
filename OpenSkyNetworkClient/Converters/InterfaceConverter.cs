using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient.Converters
{
    class InterfaceConverter<TInterface, TClass> : CustomCreationConverter<TInterface>
        where TClass : TInterface, new()
    {
        public override TInterface Create(Type objectType) => new TClass();
    }
}
