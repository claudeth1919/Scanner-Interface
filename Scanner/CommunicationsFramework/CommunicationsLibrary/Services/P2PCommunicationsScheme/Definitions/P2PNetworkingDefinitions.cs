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
	namespace Services.P2PCommunicationsScheme
	{
		
		public enum P2PDataSendMode
		{
			SyncrhonicalSend,
			AsynchronycalSend,
            notDefined
		}
		
		
		sealed class P2PNetworkingDefinitions
		{
            internal const int DEFAULT_MAX_CONNECTIONS = 100;
			internal const int DATABUFFER_SIZE = 15000;
			internal const int READ_TIME_OUT_SECONDS = 15;
			internal const string EMPTY_P2PDATA = "EMPTY_P2PDATA";

            internal const Int32 DATA_SEND_RECEIVE_PREFIX_LENGHT = 4;

		}
		
		
	}
	
}
