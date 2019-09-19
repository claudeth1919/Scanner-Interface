using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Net;



namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		
		[Serializable()]public class CNDAddressingReg
		{
			
			
#region < CLASS INFORMATION >
			
#endregion
			
#region < DATA MEMBERS >
			
			private string _hostname;
  			private string _componentName;
			private int _P2PPortNumber;
			private string _ipAddress;
			private string _appName;
			private string _appProcessID;
			private string _subscriptionDateTime;
			
#endregion
			
#region < CONSTRUCTORS >
			
			
			public CNDAddressingReg(string ComponentName, string HostName, string ipAddress, int P2PPortNumber, string AppName, string ProcessID, string subscriptionDateTime)
			{
				this._componentName = ComponentName;
				this._hostname = HostName;
				this._P2PPortNumber = P2PPortNumber;
				this._ipAddress = ipAddress;
				this._appName = AppName;
				this._appProcessID = ProcessID;
				this._subscriptionDateTime = subscriptionDateTime;
			}
			
			
			
			
#endregion
			
#region  < PROPERTIES >
			
			
public string ComponentName
			{
				get
				{
					return this._componentName;
				}
			}
			
public string HostName
			{
				get
				{
					return this._hostname;
				}
			}

          
			
public int P2PPortNumber
			{
				get
				{
					return this._P2PPortNumber;
				}
			}
			
public string IPAddress
			{
				get
				{
					return this._ipAddress;
				}
			}
			
public new string ToString
			{
				get
				{
					return this.HostName;
				}
			}
			
public string AppDomain
			{
				get
				{
					return this._appName;
				}
			}
			
public string  ProcessID
			{
				get
				{
					return this._appProcessID;
				}
			}
			
public string SubscriptionDateTime
			{
				get
				{
					return this._subscriptionDateTime;
				}
			}
			
#endregion
			
		}
		
	}
	
	
	
}
