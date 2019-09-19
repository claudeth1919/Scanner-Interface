using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsConnectionManaging
	{
		
		internal sealed class DPE_PublicationsProxyDefinitions
		{
			
#region  < TCP PORTS CONSTANTS  AND FIXED CONFIGURATION >
			
			internal const int DPE_PROXY_CLIENTS_CONNECTION_SOCKETS_SERVER_PORT = 7251;
			internal const int DPE_PROXY_CLIENTS_CONNECTION_P2P_PORT = 7252;
			internal const string DPE_PROXY_LOCAL_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME = "DSSPROXY_LOCAL_SERVICE_CONNECTION_PARAMETERS_TABLE.dat";
			
#endregion
			
		}
		
		
	}
	
	
}
