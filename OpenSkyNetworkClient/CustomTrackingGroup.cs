using OpenSkyNetworkClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    internal class CustomTrackingGroup
    {
        readonly OpenSkyNetClient client;
        ObservableCollection<IFlightState> Observers;
        List<string> icao24s;

        public CustomTrackingGroup(OpenSkyNetClient _client)
        {
            client = _client;
            icao24s = new List<string>();
            Observers = new ObservableCollection<IFlightState>();
        }

        public async Task Update()
        {
            var flights = await client.GetCustomStatesAsync(icao24s.ToArray());

            //Find the icaos in observers and update the info
            if(flights != null)
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
                        Observers.Add(flight);
                    }
                }
            }
        }

        public void Subscribe(string icao24)
        {
            if(!icao24s.Contains(icao24))
            { 
                icao24s.Add(icao24);
            }
        }

        public void Unsubscribe(string icao24)
        {
            if(icao24s.Contains(icao24))
            {
                icao24s.Remove(icao24);
                Observers.Remove(Observers.Single(s => s.Icao24 == icao24));
            }
        }
    }
}
