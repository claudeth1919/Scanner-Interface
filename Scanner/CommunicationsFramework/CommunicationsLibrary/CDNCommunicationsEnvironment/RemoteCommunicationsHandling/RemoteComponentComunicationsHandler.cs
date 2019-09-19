using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Data;
using CommunicationsLibrary.CNDCommunicationsEnvironment.LocalCommunicationsHandling;




namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.RemoteCommunicationsHandling
	{
		
		internal class RemoteComponentComunicationsHandler : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private string _remoteComponentName;
			private Services.P2PCommunicationsScheme.P2PPortClient _p2pPortClient;
			
#endregion
			
#region  < EVENTS >
			
			internal delegate void ConnectionWithRemoteComponentLostEventHandler(string RemotecomponentName);
			private ConnectionWithRemoteComponentLostEventHandler ConnectionWithRemoteComponentLostEvent;
			
			internal event ConnectionWithRemoteComponentLostEventHandler ConnectionWithRemoteComponentLost
			{
				add
				{
					ConnectionWithRemoteComponentLostEvent = (ConnectionWithRemoteComponentLostEventHandler) System.Delegate.Combine(ConnectionWithRemoteComponentLostEvent, value);
				}
				remove
				{
					ConnectionWithRemoteComponentLostEvent = (ConnectionWithRemoteComponentLostEventHandler) System.Delegate.Remove(ConnectionWithRemoteComponentLostEvent, value);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES  >
			
            internal string RemoteComponentName
			{
				get
				{
					return this._remoteComponentName;
				}
			}
			
#endregion
			
#region  < EVENT HANDLING >

            private void _p2pPortClient_ConnectionLost(P2PPortClient client)
			{
				if (ConnectionWithRemoteComponentLostEvent != null)
					ConnectionWithRemoteComponentLostEvent(this._remoteComponentName);
			}
			
#endregion
			
#region  <  CONSTRUCTORS >
			
			internal RemoteComponentComunicationsHandler(string RemoteComponentName, string RemoteHostName, string IPAddress,int RemoteListeningPort)
			{
				this._remoteComponentName = RemoteComponentName;
                this._p2pPortClient = new Services.P2PCommunicationsScheme.P2PPortClient(RemoteHostName, IPAddress, RemoteListeningPort);
				this._p2pPortClient.ConnectionLost += this._p2pPortClient_ConnectionLost;
				this._p2pPortClient.Connect();
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SendData(CommunicationsData data)
			{
				this._p2pPortClient.SendData(P2PDataSendMode.AsynchronycalSend, data.P2PData);
			}
			
			internal CommunicationsData RetrieveData(CNDCommunicationsEnvironment.Data.CommunicationsDataRequest datarequest)
			{
				P2PData dataResult = default(P2PData);
				dataResult = this._p2pPortClient.RetrieveData(datarequest.P2PDataRequest);
				CommunicationsData dataRetrieved = default(CommunicationsData);
				dataRetrieved = CommunicationsData.GetCommunicationsDataObject(datarequest.RemoteAddresseComponentName, datarequest.SenderComponentName, dataResult.DataName, dataResult.Value);
				return dataRetrieved;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
			
#region  IDisposable Support
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						try
						{
							this._p2pPortClient.Disconnect();
							this._p2pPortClient.Dispose();
						}
						catch (Exception)
						{
						}
					}
					
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
#endregion
			
#endregion
			
			
		}
		
	}
	
	
	
	
	
}
