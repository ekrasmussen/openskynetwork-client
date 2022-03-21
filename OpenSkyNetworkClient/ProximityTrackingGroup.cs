﻿using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    internal class ProximityTrackingGroup
    {
        readonly OpenSkyNetworkClient client;
        List<IFlightState> Observers;
        BoundingBox bbox;


        public ProximityTrackingGroup(OpenSkyNetworkClient _client)
        {
            client = _client;
            Observers = new List<IFlightState>();
        }

        void UpdateBoundingBox(BoundingBox _bbox)
        {
            bbox = _bbox;
        }
    }
}
