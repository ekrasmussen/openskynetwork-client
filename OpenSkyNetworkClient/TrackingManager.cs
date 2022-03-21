﻿using OpenSkyNetworkClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class TrackingManager
    {
        public CustomTrackingGroup customGroup { get; }
        public ProximityTrackingGroup proximityGroup {get;} 

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
                await Task.Delay(5000);
                await OnTick(token);
            }

        }

        async Task OnTick(CancellationToken token)
        {
            UpdateCustomGroup(token);
            UpdateProximityGroup(token);
        }

        async Task UpdateCustomGroup(CancellationToken token)
        {
            await customGroup.Update();
        }

        async Task UpdateProximityGroup(CancellationToken token)
        {
            await proximityGroup.Update();
        }


        public void StartTracking(string icao24)
        {
            customGroup.Subscribe(icao24);
        }

        public void StartProximityTracking(BoundingBox bbox)
        {
            proximityGroup.UpdateBoundingBox(bbox);
        }

        public void StopTracking(string icao24)
        {
            customGroup.Unsubscribe(icao24);
        }

        public void StopProximityTracking()
        {
            proximityGroup.EndTracking();
        }

    }
}
