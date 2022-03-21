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

        public TrackingManager(OpenSkyNetClient client, CancellationToken token)
        {
            customGroup = new CustomTrackingGroup(client);
            proximityGroup = new ProximityTrackingGroup(client);
            Task.Run(() => StartTimer(token));
        }

        async Task StartTimer(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                await Task.Delay(2500);
                await OnTick(token);
            }

        }

        public void StartTracking(string icao24)
        {
            customGroup.Subscribe(icao24);
        }

        public void StopTracking(string icao24)
        {
            customGroup.Unsubscribe(icao24);
        }

        async Task OnTick(CancellationToken token)
        {
            await Task.WhenAll(UpdateCustomGroup(token), UpdateProximityGroup(token));
        }

        async Task UpdateCustomGroup(CancellationToken token)
        {
            await customGroup.Update();
        }

        async Task UpdateProximityGroup(CancellationToken token)
        {
            //Placeholder
            await Task.Delay(1);
        }
    }
}
