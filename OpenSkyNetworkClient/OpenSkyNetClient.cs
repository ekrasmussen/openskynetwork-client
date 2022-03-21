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
            Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();

            if(icao24s != null && icao24s.Length > 0)
            {
                for (int i = 0; i < icao24s.Length; i++)
                {
                    keyValuePairs.Add("icao24", icao24s[i]);
                }
            }

            else if(bbox != null)
            {
                keyValuePairs.Add("lamin", bbox.MinLat);
                keyValuePairs.Add("lomin", bbox.MinLon);
                keyValuePairs.Add("lamax", bbox.MaxLat);
                keyValuePairs.Add("lomax", bbox.MaxLon);

            }
                query += RequestStringBuilder.Create(keyValuePairs);
                return GetAsync<IFlightStates>(query, token);
        }
    }
}
