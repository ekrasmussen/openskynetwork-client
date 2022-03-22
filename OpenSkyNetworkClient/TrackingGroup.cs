using OpenSkyNetworkClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public abstract class TrackingGroup
    {
        protected OpenSkyNetClient client;
        protected TrackingGroup(OpenSkyNetClient _client)
        {
            client = _client;
        }
        protected async Task FindRoute(IFlightState state)
        {
            IFlightRoute route = await client.GetRouteAsync(state.CallSign);

            if (route != null)
            {
                state.AddRoute(route);
            }
        }
    }
}
