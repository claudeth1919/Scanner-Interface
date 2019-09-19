using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunicationsLibrary.Services.P2PCommunicationsScheme.Common
{
    internal sealed class DataHolder
    {       
        internal Byte[] Data;
        internal Int32 receivedTransMissionId;
        internal Int32 sessionId;
    }
}
