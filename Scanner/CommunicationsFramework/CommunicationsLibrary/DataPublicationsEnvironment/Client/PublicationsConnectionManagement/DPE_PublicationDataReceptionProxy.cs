using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Clients;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsConnectionManaging
	{
		
		public class DPE_PublicationDataReceptionProxy : IDisposable
		{
			
			
#region  < DATAMEMBERS >
			
			private static DPE_PublicationDataReceptionProxy _STXDSSC_PublicationDataReceptionProxy;
			
			//table to hold all the ports open to receive from publications
			//when is updated to the connected clients that expexts data to be received
			//through a tCP connection
			private Hashtable _SocketServersListenersTable;
			private Hashtable _MultiCastDataReplicatorClientsTable;
			private Hashtable _MultiCastDataReplicatorKeyStringsTable;
			
			//table to log wich clients are connected to who publications in order to
			//know when to dispose a client for receiving publication data because nobody is requiring
			//data from such publication
			private Hashtable _ClientConnectionsToPublicationsLogTable;
			
#endregion
			
#region  < CONSTRUNCTORS >
			
			private DPE_PublicationDataReceptionProxy()
			{
				this._SocketServersListenersTable = new Hashtable();
				this._MultiCastDataReplicatorClientsTable = new Hashtable();
				this._MultiCastDataReplicatorKeyStringsTable = new Hashtable();
				this._ClientConnectionsToPublicationsLogTable = new Hashtable();
			}
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			public static DPE_PublicationDataReceptionProxy GetInstance()
			{
				if (_STXDSSC_PublicationDataReceptionProxy == null)
				{
					_STXDSSC_PublicationDataReceptionProxy = new DPE_PublicationDataReceptionProxy();
				}
				return _STXDSSC_PublicationDataReceptionProxy;
			}
			
#endregion
			
#region  < PRIVATE METHODS  >
			
			private void LogClientForPublicationDataReception(DPE_DataPublicationsClient client, string publicationName)
			{
				try
				{
					if (this._ClientConnectionsToPublicationsLogTable.ContainsKey(publicationName))
					{
						Hashtable publicationTable = default(Hashtable);
						publicationTable = (Hashtable) (this._ClientConnectionsToPublicationsLogTable[publicationName]);
						if (publicationTable.ContainsKey(client.ClientID))
						{
							publicationTable.Remove(client.ClientID);
						}
						publicationTable.Add(client.ClientID, client);
					}
					else
					{
						Hashtable newPublicationTAble = new Hashtable();
						newPublicationTAble.Add(client.ClientID, client);
						this._ClientConnectionsToPublicationsLogTable.Add(publicationName, newPublicationTAble);
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			private void UnLogClientForPublicationDataReception(DPE_DataPublicationsClient client, string publicationName)
			{
				try
				{
					if (this._ClientConnectionsToPublicationsLogTable.ContainsKey(publicationName))
					{
						Hashtable publicationTable = default(Hashtable);
						publicationTable = (Hashtable) (this._ClientConnectionsToPublicationsLogTable[publicationName]);
						if (publicationTable.ContainsKey(client.ClientID))
						{
							publicationTable.Remove(client.ClientID);
						}
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			private int GetConnectedClientsToPublicationCount(string publicationName)
			{
				
				if (this._ClientConnectionsToPublicationsLogTable.ContainsKey(publicationName))
				{
					Hashtable publicationTable = default(Hashtable);
					publicationTable = (Hashtable) (this._ClientConnectionsToPublicationsLogTable[publicationName]);
					if (!(publicationTable == null))
					{
						return publicationTable.Count;
					}
					else
					{
						return 0;
					}
					
				}
				else
				{
					return 0;
				}				
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal CommunicationsLibrary.Services.SocketsDataDistribution.SocketsServer GetPublicationSocketsServerListener(DPE_DataPublicationsClient client, string PublicationName)
			{
				if (this._SocketServersListenersTable.ContainsKey(PublicationName))
				{
					SocketsServer listener = default(SocketsServer);
                    listener = (SocketsServer)this._SocketServersListenersTable[PublicationName];
					this.LogClientForPublicationDataReception(client, PublicationName);
					return listener;
				}
				else
				{
					SocketsServer listener = new SocketsServer(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE, DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE);
					this._SocketServersListenersTable.Add(PublicationName, listener);
					this.LogClientForPublicationDataReception(client, PublicationName);
					return listener;
				}
			}
			
			internal MultiCastDataReplicatorClient GetPublicationMultiCastDataReplicatorClient(DPE_DataPublicationsClient stxdssClient, string PublicationName, string publicationMultiCastIPAddress, int publicationMultiCastPort)
			{
				
				string requestedMulticastKey = publicationMultiCastIPAddress + System.Convert.ToString(publicationMultiCastPort);
				
				if (this._MultiCastDataReplicatorClientsTable.ContainsKey(PublicationName))
				{
					//gets the current multicast client
					MultiCastDataReplicatorClient currentMultiCastClient = default(MultiCastDataReplicatorClient);
                    currentMultiCastClient = (MultiCastDataReplicatorClient)this._MultiCastDataReplicatorClientsTable[PublicationName];
					
					//gets the current key to verify if the address corresponds to the multicast address and port
					string currentMulticastKey = "";
					currentMulticastKey = System.Convert.ToString(this._MultiCastDataReplicatorKeyStringsTable[PublicationName]);
					
					if (!(currentMulticastKey == null))
					{
						
						if (requestedMulticastKey != currentMulticastKey)
						{
							//removes the old key and the old client to create a new one
							currentMultiCastClient.Dispose();
							this._MultiCastDataReplicatorKeyStringsTable.Remove(PublicationName);
							this._MultiCastDataReplicatorClientsTable.Remove(PublicationName);
							return this.GetPublicationMultiCastDataReplicatorClient(stxdssClient, PublicationName, publicationMultiCastIPAddress, publicationMultiCastPort);
						}
						else
						{
							this.LogClientForPublicationDataReception(stxdssClient, PublicationName);
							return currentMultiCastClient;
						}
					}
					else
					{
						currentMultiCastClient.Dispose();
						this._MultiCastDataReplicatorKeyStringsTable.Remove(PublicationName);
						this._MultiCastDataReplicatorClientsTable.Remove(PublicationName);
						return this.GetPublicationMultiCastDataReplicatorClient(stxdssClient, PublicationName, publicationMultiCastIPAddress, publicationMultiCastPort);
					}
				}
				else
				{
					MultiCastDataReplicatorClient client = default(MultiCastDataReplicatorClient);
					client = new MultiCastDataReplicatorClient(publicationMultiCastIPAddress, publicationMultiCastPort);
					client.Connect();
					this._MultiCastDataReplicatorClientsTable.Add(PublicationName, client);
					this._MultiCastDataReplicatorKeyStringsTable.Add(PublicationName, requestedMulticastKey);
					this.LogClientForPublicationDataReception(stxdssClient, PublicationName);
					return client;
				}
			}
			
			internal void LogClientDisconnectionFromPublication(DPE_DataPublicationsClient stxdssClient, string PublicationName)
			{
				try
				{
					this.UnLogClientForPublicationDataReception(stxdssClient, PublicationName);
					int connectedClients = this.GetConnectedClientsToPublicationCount(PublicationName);
					if (connectedClients <= 0)
					{
						//removes all the handles to receive data for this publication because nobody will be use it
						
						//removes the multicast clientss if exists
						MultiCastDataReplicatorClient publicationMultiCastClient = default(MultiCastDataReplicatorClient);
                        publicationMultiCastClient = (MultiCastDataReplicatorClient)this._MultiCastDataReplicatorClientsTable[PublicationName];
						if (!(publicationMultiCastClient == null))
						{
							publicationMultiCastClient.Dispose();
						}
						this._MultiCastDataReplicatorKeyStringsTable.Remove(PublicationName);
						this._MultiCastDataReplicatorClientsTable.Remove(PublicationName);
						
						SocketsServer listener = default(SocketsServer);
                        listener = (SocketsServer)this._SocketServersListenersTable[PublicationName];
						if (!(listener == null))
						{
							listener.Dispose();
						}
						this._SocketServersListenersTable.Remove(PublicationName);
						
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDisposable >
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						//disposing
						DPE_GlobalDefinitions.DISPOSE_DPE_PROXY_PublicationsDataBase();
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
