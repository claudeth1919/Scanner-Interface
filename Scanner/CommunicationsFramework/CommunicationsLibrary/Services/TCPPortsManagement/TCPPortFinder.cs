using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using CommunicationsLibrary.Utilities;	
	
	
	namespace CommunicationsLibrary
	{
		namespace Services.TCPPortsManagement
		{
			
			public class TCPPortFinder
			{
				
#region  < DATA MEMBERS >
				
				private static TCPPortFinder _TCPPortFinder;
			
			private const int START_TCP_PORT = 4000;
			
			private Hashtable _tcpPortSearchingHandlersTable;
			
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			private TCPPortFinder()
			{
				this._tcpPortSearchingHandlersTable = new Hashtable();
			}
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			internal static TCPPortFinder GetInstance()
			{
				if (_TCPPortFinder == null)
				{
					_TCPPortFinder = new TCPPortFinder();
				}
				return _TCPPortFinder;
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			
			internal int GetAvailableFreeTCPPort()
			{
                return CommunicationsUtilities.GetFreeTCPPort(START_TCP_PORT);
			}
			
			internal int GetAvailableFreeTCPPortOnARange(int lowerPort, int upperPort)
			{
				string rangeIDName = "";
				int lowPort = 0;
				int upPort = 0;
				
				if (lowerPort < upperPort)
				{
					rangeIDName = System.Convert.ToString(lowerPort) + System.Convert.ToString(upperPort);
					lowPort = lowerPort;
					upPort = upperPort;
				}
				else
				{
					rangeIDName = System.Convert.ToString(upperPort) + System.Convert.ToString(lowerPort);
					lowPort = upperPort;
					upPort = lowerPort;
				}
				
				TCPPortsRangeFinderHandler handler = default(TCPPortsRangeFinderHandler);
				
				if (this._tcpPortSearchingHandlersTable.ContainsKey(rangeIDName))
				{
                    handler = (TCPPortsRangeFinderHandler)this._tcpPortSearchingHandlersTable[rangeIDName];
					return handler.GetAvailablePort();
				}
				else
				{
					handler = new TCPPortsRangeFinderHandler(lowPort, upPort);
					this._tcpPortSearchingHandlersTable.Add(rangeIDName, handler);
					return handler.GetAvailablePort();
				}
			}
			
#endregion
			
			
			
			
			
			
		}
		
		
	}
	
	
}
