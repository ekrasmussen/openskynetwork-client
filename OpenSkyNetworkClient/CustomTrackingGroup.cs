using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class CustomTrackingGroup : TrackingGroup
    {
        public List<IFlightState> Observers { get; }

        public CustomTrackingGroup(OpenSkyNetClient client) : base(client)
        {
            Observers = new List<IFlightState>();
        }

        public async Task Update()
        {
            if(Observers != null && Observers.Count > 0)
            {
                var flights = await client.GetCustomStatesAsync(Observers.Select(s => s.Icao24).ToArray());

                //Find the icaos in observers and update the info
                if (flights != null)
                {
                    foreach (var flight in flights.States)
                    {
                        var ifs = Observers.FirstOrDefault(s => s.Icao24 == flight.Icao24);

                        if (ifs != null)
                        {
                            ifs.Update(flight);
                        }
                        else
                        {
                            FindRoute(flight);
                            Observers.Add(flight);
                        }
                    }
                }
            }
        }

        public void Subscribe(string icao24)
        {
            if(!Observers.Any(s => s.Icao24 == icao24))
            {
                IFlightState flight = new FlightState(icao24);
                Observers.Add(flight);
            }
        }

        public void Unsubscribe(string icao24)
        {
            Observers.Remove(Observers.FirstOrDefault(s => s.Icao24 == icao24));
        }
    }
}
