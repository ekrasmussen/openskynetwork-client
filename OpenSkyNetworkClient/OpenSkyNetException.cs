using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenSkyNetworkClient
{
    public class OpenSkyNetException : Exception
    {

        public OpenSkyNetException()
        {
        }

        public OpenSkyNetException(string message)
            : base(message)
        {
        }

        public OpenSkyNetException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if !COREFX

        protected OpenSkyNetException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
