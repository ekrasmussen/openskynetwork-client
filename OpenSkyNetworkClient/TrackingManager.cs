using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class TrackingManager
    {
        CustomTrackingGroup customGroup;
        ProximityTrackingGroup proximityGroup;

        public TrackingManager(OpenSkyNetworkClient client, CancellationToken token)
        {
            customGroup = new CustomTrackingGroup(client);
            proximityGroup = new ProximityTrackingGroup(client);
            Task.Run(() => StartTimer(token));
        }

        async Task StartTimer(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                await Task.Delay(5000);
                await OnTick(token);
            }

        }

        async Task OnTick(CancellationToken token)
        {
            await Task.WhenAll(UpdateCustomGroup(token), UpdateProximityGroup(token));
        }

        async Task UpdateCustomGroup(CancellationToken token)
        {
            //Placeholder
            await Task.Delay(1);
        }

        async Task UpdateProximityGroup(CancellationToken token)
        {
            //Placeholder
            await Task.Delay(1);
        }
    }
}
