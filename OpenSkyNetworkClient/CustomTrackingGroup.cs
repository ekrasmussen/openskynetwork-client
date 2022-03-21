﻿using OpenSkyNetworkClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    internal class CustomTrackingGroup
    {
        readonly OpenSkyNetworkClient client;
        List<IFlightState> Observers;
        List<string> icao24s;

        public CustomTrackingGroup(OpenSkyNetworkClient _client)
        {
            client = _client;
            icao24s = new List<string>();
            Observers = new List<IFlightState>();
        }

        public void Subscribe(string icao24)
        {
            if(!icao24s.Contains(icao24))
            { 
                icao24s.Add(icao24);
            }
        }
    }
}
