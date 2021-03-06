using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;

namespace OpenSkyNetworkClient
{
    public class ProximityTrackingGroup : TrackingGroup
    {
        public List<IFlightState> Observers { get; }
        BoundingBox bbox;
        public ProximityTrackingGroup(OpenSkyNetClient client) : base(client)
        {
            Observers = new List<IFlightState>();
        }

        public async Task Update()
        {
            if (bbox != null)
            {
                IFlightStates flights = await client.GetProximityStatesAsync(bbox);

                foreach (var flight in flights.States)
                {
                    var ifs = Observers.FirstOrDefault(s => s.Icao24 == flight.Icao24);

                    if (ifs != null)
                    {
                        ifs.Update(flight);
                    }
                }

                RemoveLeavingFlights(flights.States);
                AddEnteringFlights(flights.States);
            }
        }

        async void AddEnteringFlights(IFlightState[] states)
        {
            IEnumerable<IFlightState> enteringFlights = states.ExceptBy(Observers.Select(o => o.Icao24), s => s.Icao24).ToList();
            foreach (var lf in enteringFlights)
            {
                Console.WriteLine($"FLIGHT {lf.Icao24} ENTERED AIRSPACE");
                FindRoute(lf);

                Observers.Add(lf);
            }
        }
        void RemoveLeavingFlights(IFlightState[] states)
        {
            IEnumerable<IFlightState> leavingFlights = Observers.ExceptBy(states.Select(s => s.Icao24), o => o.Icao24).ToList();
            foreach (var lf in leavingFlights)
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
