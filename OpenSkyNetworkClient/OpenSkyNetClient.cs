using OpenSkyNetworkClient.APIAccess;
using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;
using OpenSkyNetworkClient.Tool;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class OpenSkyNetClient : Connection
    {

        readonly TrackingManager trackingManager;
        readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        public OpenSkyNetClient()
        {
            trackingManager = new TrackingManager(this, tokenSource.Token);
        }

        public void StartTracking(string icao24) => trackingManager.StartTracking(icao24);
        public void StopTracking(string icao24) => trackingManager.StopTracking(icao24);

        public void StartProximityTracking(BoundingBox bbox) => trackingManager.StartProximityTracking(bbox);
        public void StopProximityTracking() => trackingManager.StopProximityTracking();

        public Task<IFlightStates> GetAllStatesAsync(CancellationToken token = default) => GetStatesBasicAsync("states/all", null, null, token);
        public Task<IFlightStates> GetCustomStatesAsync(string[] icao24s, CancellationToken token = default)
        {
            if( icao24s != null && icao24s.Length > 0)
            {
                return GetStatesBasicAsync("states/all", icao24s, null, token);
            }

            else
            {
                return null;
            }
        }
        public Task<IFlightStates> GetProximityStatesAsync(BoundingBox bbox, CancellationToken token = default) => GetStatesBasicAsync("states/all", null, bbox, token);

        public Task<IFlightRoute> GetRouteAsync(IFlightState state, CancellationToken token = default) => throw new NotImplementedException();
        //To be implemented

        Task<IFlightStates> GetStatesBasicAsync(string query, string[] icao24s = null, BoundingBox bbox = null, CancellationToken token = default)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            if (icao24s != null && icao24s.Length > 0)
            {
                query += RequestStringBuilder.Create(icao24s);
            }

            else if (bbox != null)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("lamin", bbox.MinLat);
                dict.Add("lomin", bbox.MinLon);
                dict.Add("lamax", bbox.MaxLat);
                dict.Add("lomax", bbox.MaxLon);

                query += RequestStringBuilder.Create(dict);
            }
            Console.WriteLine(query);
            return GetAsync<IFlightStates>(query, token);
        }

        public ObservableCollection<IFlightState> GetCustomList()
        {
            return trackingManager.customGroup.Observers;
        }

        public ObservableCollection<IFlightState> GetProximityList()
        {
            return trackingManager.proximityGroup.Observers;
        }
    }
}
