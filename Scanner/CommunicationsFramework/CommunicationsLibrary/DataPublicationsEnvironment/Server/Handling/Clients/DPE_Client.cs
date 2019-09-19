using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Clients
	{
		
		public class DPE_Client
		{
			
#region  < DATAMEMBERS >
			
			private Client.DPE_ClientType _clientType;
			private string _STXDSSClientName;
			private string _ClientHostName;
			private DateTime _connectionDAteTime;
			private string _ClientID;
			private string _networkID;
			private string _appDomainName;
			
#endregion
			
#region  <CONSTRUCTORS  >
			
			internal DPE_Client(DPE_ClientType clientType, string clientID, string networkID, string clientName, string HostName, string AppDomainName)
			{
				this._clientType = clientType;
				this._ClientID = clientID;
				this._networkID = networkID;
				this._STXDSSClientName = clientName;
				this._connectionDAteTime = DateTime.Now;
				if (HostName.Length <= 0)
				{
					this._ClientHostName = "Unknown";
				}
				else
				{
					this._ClientHostName = HostName;
				}
				this._appDomainName = AppDomainName;
			}
			
			internal DPE_Client(DPE_ClientType clientType, string clientID, string networkID, string HostName, string AppDomainName)
			{
				this._clientType = clientType;
				this._ClientID = clientID;
				this._networkID = networkID;
				this._STXDSSClientName = "UNDEFINED";
				this._connectionDAteTime = DateTime.Now;
				if (HostName.Length <= 0)
				{
					this._ClientHostName = "Unknown";
				}
				else
				{
					this._ClientHostName = HostName;
				}
				this._appDomainName = AppDomainName;
			}
			
#endregion
			
#region  < PROPERTIES >
			
            internal string ClientID
			{
				get
				{
					return this._ClientID;
				}
			}
			
            internal string NetworkID
			{
				get
				{
					return this._networkID;
				}
			}
			
            internal string Name
			{
				get
				{
					return this._STXDSSClientName;
				}
			}
			
            internal string ApplicationDomainName
			{
				get
				{
					return this._appDomainName;
				}
			}
			
            internal string ConnectionDateTime
			{
				get
				{
					return System.Convert.ToString( this._connectionDAteTime);
				}
			}
			
            internal string HostName
			{
				get
				{
					return this._ClientHostName;
				}
			}
			
            internal DPE_ClientType ClientType
			{
				get
				{
					return this._clientType;
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SetClientName(string name)
			{
				this._STXDSSClientName = name;
			}
			
#endregion
			
		}
		
	}
	
	
	
}
