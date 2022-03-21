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
    internal class ProximityTrackingGroup
    {
        readonly OpenSkyNetClient client;
        ObservableCollection<IFlightState> Observers;
        BoundingBox bbox;


        public ProximityTrackingGroup(OpenSkyNetClient _client)
        {
            client = _client;
            Observers = new ObservableCollection<IFlightState>();
        }

        void UpdateBoundingBox(BoundingBox _bbox)
        {
            bbox = _bbox;
        }
    }
}
