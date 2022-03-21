using OpenSkyNetworkClient.APIAccess;
using OpenSkyNetworkClient.Interfaces;
using OpenSkyNetworkClient.Model;
using OpenSkyNetworkClient.Tool;
using System;
using System.Collections.Generic;
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

        public Task<IFlightStates> GetAllStatesAsync(CancellationToken token = default) => GetStatesBasicAsync("states/all", null, null, token);
        public Task<IFlightStates> GetCustomStatesAsync(string[] icao24s, CancellationToken token = default) => GetStatesBasicAsync("states/all", icao24s, null, token);
        public Task<IFlightStates> GetProximityStatesAsync(BoundingBox bbox, CancellationToken token = default) => GetStatesBasicAsync("states/all", null, bbox, token);

        Task<IFlightStates> GetStatesBasicAsync(string query, string[] icao24s = null, BoundingBox bbox = null, CancellationToken token = default)
        {
            if(icao24s != null && icao24s.Length > 0)
            {
                query += RequestStringBuilder.Create(icao24s);
            }

            else if(bbox != null)
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("lamin", bbox.MinLat);
                dict.Add("lomin", bbox.MinLon);
                dict.Add("lamax", bbox.MaxLat);
                dict.Add("lomax", bbox.MaxLon);

                query += RequestStringBuilder.Create(dict);
            }
                
                return GetAsync<IFlightStates>(query, token);
        }
    }
}
