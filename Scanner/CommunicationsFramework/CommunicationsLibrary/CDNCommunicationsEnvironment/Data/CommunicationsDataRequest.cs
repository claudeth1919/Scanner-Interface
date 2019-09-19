using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;


namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.Data
	{
		
		public class CommunicationsDataRequest
		{
			
#region  < DATAMEMBERS >
			
			private string _senderComponentName;
			private string _remoteAddresseComponentName;
			private P2PDataRequest _p2pDataRequest;
			
#endregion
			
#region  < PROPERTIES >
			
public string RemoteAddresseComponentName
			{
				get
				{
					return this._remoteAddresseComponentName;
				}
			}
			
public string SenderComponentName
			{
				get
				{
					return this._senderComponentName;
				}
			}
			
public string RequestedDataName
			{
				get
				{
					return this._p2pDataRequest.RequestedDataName;
				}
			}
			
internal P2PDataRequest P2PDataRequest
			{
				get
				{
					return this._p2pDataRequest;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public CommunicationsDataRequest(string remoteAddresseComponentName, string senderComponentName, string DataNameToRequest)
			{
				DataNameToRequest = DataNameToRequest.ToUpper();
				this._senderComponentName = senderComponentName;
				this._remoteAddresseComponentName = remoteAddresseComponentName;
				this._p2pDataRequest = new P2PDataRequest(DataNameToRequest);
				this._p2pDataRequest.AddRequestParameter("DATA_TYPE", "CommunicationsDataRequest");
				this._p2pDataRequest.AddRequestParameter("SENDER_COMPONENT", senderComponentName);
				this._p2pDataRequest.AddRequestParameter("ADDRESSE_COMPONENT", remoteAddresseComponentName);
			}
			
#endregion
			
			
			
		}
		
	}
	
	
	
	
	
}
