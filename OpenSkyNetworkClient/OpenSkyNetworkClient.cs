using OpenSkyNetworkClient.APIAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class OpenSkyNetworkClient : Connection
    {
        readonly TrackingManager trackingManager;
        readonly CancellationTokenSource tokenSource = new CancellationTokenSource();

        public OpenSkyNetworkClient()
        {
            trackingManager = new TrackingManager(this, tokenSource.Token);
        }
    }
}
