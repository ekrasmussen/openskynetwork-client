using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class ProximityTrackingGroup
    {
        readonly OpenSkyNetClient client;
        public ObservableCollection<IFlightState> Observers { get; }
        BoundingBox bbox;


        public ProximityTrackingGroup(OpenSkyNetClient _client)
        {
            client = _client;
            Observers = new ObservableCollection<IFlightState>();
        }

        public async Task Update()
        {
            if(bbox != null)
            {
                IFlightStates flights = await client.GetProximityStatesAsync(bbox);

                foreach (var flight in flights.States)
                {
                    var ifs = Observers.FirstOrDefault(s => s.Icao24 == flight.Icao24);

                    if (ifs != null)
                    {

                        if(ifs.FlightRoute == null)
                        {
                            IFlightRoute flightRoute = await client.GetRouteAsync(ifs);
                            ifs.Update(flight, flightRoute);
                        }
                        else
                        {
                            ifs.Update(flight);
                        }
                    }
                }

                RemoveLeavingFlights(flights.States);
                AddEnteringFlights(flights.States);
            }
        }

        void AddEnteringFlights(IFlightState[] states)
        {
            IEnumerable<IFlightState> enteringFlights = states.ExceptBy(Observers.Select(o => o.Icao24), s => s.Icao24).ToList();
            foreach(var lf in enteringFlights)
            {
                Console.WriteLine($"FLIGHT {lf.Icao24} ENTERED AIRSPACE");
                Observers.Add(lf);
            }
        }
        void RemoveLeavingFlights(IFlightState[] states)
        {
            IEnumerable<IFlightState> leavingFlights = Observers.ExceptBy(states.Select(s => s.Icao24), o => o.Icao24).ToList();
            foreach(var lf in leavingFlights)
            {
                Console.WriteLine($"FLIGHT {lf.Icao24} LEFT AIRSPACE");
                Observers.Remove(lf);
            }
        }

        public void UpdateBoundingBox(BoundingBox _bbox)
        {
            bbox = _bbox;
        }

        public void EndTracking()
        {
            bbox = null;
            Observers.Clear();
        }
    }
}
