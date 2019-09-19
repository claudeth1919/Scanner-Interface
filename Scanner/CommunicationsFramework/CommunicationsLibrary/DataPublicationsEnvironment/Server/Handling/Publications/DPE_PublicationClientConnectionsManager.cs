using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Clients;
using UtilitiesLibrary.EventLoging;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications
	{
		
		public class DPE_PublicationClientConnectionsManager
		{
			
#region  < DATA MEMBERS >
			
			//table of Pending socket client identification in order to match a client with a STXDSSclient
			private Hashtable _PendingSocketClientMatchWithSTXDSSClientTable;
			private Hashtable _socketConnectionHandlerToClientREferenceTable;
			private Hashtable _STXDSSClientTosocketConnectionHandlerReferenceTable;
			private DataTable _STXDSSClienstSubscribedRegistryTable;
			private DPE_Publication _publicationOwner;
			
			private Queue _posponedMatchQueue;
			private System.Timers.Timer _posponedMatchTimer;
			private const int MAX_MATCH_INTERVAL_LAP_IN_SECONDS = 60;
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_PublicationClientConnectionsManager(DPE_Publication publicationOwner)
			{
				this._publicationOwner = publicationOwner;
				this._PendingSocketClientMatchWithSTXDSSClientTable = new Hashtable();
				this._socketConnectionHandlerToClientREferenceTable = new Hashtable();
				this._STXDSSClientTosocketConnectionHandlerReferenceTable = new Hashtable();
				
				this._STXDSSClienstSubscribedRegistryTable = new DataTable();
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Client Name");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Client ID");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Client AppDomain");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Client HostName");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Connection Date Time");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Client Network ID");
				this._STXDSSClienstSubscribedRegistryTable.Columns.Add("Connection Mode");
				
				
				this._posponedMatchQueue = new Queue();
				this._posponedMatchTimer = new System.Timers.Timer(100);
				this._posponedMatchTimer.Elapsed += this._posponedMatchTimer_Elapsed;
				this._posponedMatchTimer.AutoReset = false;
				this._posponedMatchTimer.Stop();
				
			}
			
#endregion
			
#region  < PROPERTIES   >
			
public int ConnectedClientsCount
			{
				get
				{
					return this._STXDSSClienstSubscribedRegistryTable.Rows.Count;
				}
			}
			
public DataTable PublicationSubscriptorsRegistryTable
			{
				get
				{
					return this._STXDSSClienstSubscribedRegistryTable;
				}
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void _posponedMatchTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._posponedMatchTimer.Stop();
					
					PublicationConnectionClientMatchRegister matchLog = null;
					
					lock(this._posponedMatchQueue)
					{
                        matchLog = (PublicationConnectionClientMatchRegister)this._posponedMatchQueue.Dequeue();
					}
					
					if (!(matchLog == null))
					{
						
						if (matchLog.GetElapsedSeconds() < MAX_MATCH_INTERVAL_LAP_IN_SECONDS)
						{
							
							//realizes the matching
							if (this._PendingSocketClientMatchWithSTXDSSClientTable.ContainsKey(matchLog.PublicationConnectionHandlerID))
							{
								
								SocketsServerClientConnectionHandler socketConnectionHandler = default(SocketsServerClientConnectionHandler);
                                socketConnectionHandler = (SocketsServerClientConnectionHandler)this._PendingSocketClientMatchWithSTXDSSClientTable[matchLog.PublicationConnectionHandlerID];
								if (socketConnectionHandler == null)
								{
									throw (new Exception("There is not registered a socket connection handler of the client \'" + matchLog.Client.Name + "\' in the publication named \'" + this._publicationOwner.PublicationName + "\'"));
								}
								
								this.RegisterNewSubscriptorToPublication(matchLog.Client, socketConnectionHandler, matchLog.ConnectionMode);
								
								//regisers in a table the relation of the socket client that belong to the stxdssclient for
								//further reference
								if (!this._socketConnectionHandlerToClientREferenceTable.ContainsKey(socketConnectionHandler.ClientID))
								{
									this._socketConnectionHandlerToClientREferenceTable.Add(socketConnectionHandler.ClientID, matchLog.Client);
								}
								
								//regiosters the relation of the socket connection woth the client for further reference
								if (!this._STXDSSClientTosocketConnectionHandlerReferenceTable.ContainsKey(matchLog.Client.ClientID))
								{
									this._STXDSSClientTosocketConnectionHandlerReferenceTable.Add(matchLog.Client.ClientID, socketConnectionHandler);
								}
								
								this.UnlogPendingSocketClientMatchConnectionWithSTXDSSClientTable(socketConnectionHandler);
								
								//------------------------------------------------------------------------------------------
								//sends to the client the last update of the publication
								SocketsServerClientConnectionHandler handler = default(SocketsServerClientConnectionHandler);
								handler = this.GetClientPublicationConnectionHandler(matchLog.Client);
								if (!(handler == null))
								{
									if (matchLog.ConnectionMode == DPE_ServerDefs.DPE_PublicationConnectionMode.ReceiveLastPublicationStatus)
									{
										this._publicationOwner.SchedulePublicationUpdateOnClientConnection(handler);
									}
								}
								//-------------------------------------------------------------------------------------------
								
								
								try
								{
									this._publicationOwner.RaiseNewConnectionEvent(matchLog.Client);
								}
								catch (Exception)
								{
								}
								
								
								
							}
							else
							{
								if (matchLog.GetElapsedSeconds() < MAX_MATCH_INTERVAL_LAP_IN_SECONDS)
								{
									lock(this._posponedMatchQueue)
									{
										this._posponedMatchQueue.Enqueue(matchLog);
									}
								}
								
							}
							
						}
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
				finally
				{
					
					if (this._posponedMatchQueue.Count > 0)
					{
						this._posponedMatchTimer.Start();
					}
					
				}
				
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void RegisterNewSubscriptorToPublication(DPE_Client subscriptorClient, SocketsServerClientConnectionHandler connectionHandler, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				try
				{
					DataRow clientRow = this._STXDSSClienstSubscribedRegistryTable.NewRow();
					clientRow["Client Name"] = subscriptorClient.Name;
					clientRow["Client ID"] = subscriptorClient.ClientID;
					clientRow["Client HostName"] = subscriptorClient.HostName;
					clientRow["Client AppDomain"] = subscriptorClient.ApplicationDomainName;
					clientRow["Connection Date Time"] = System.Convert.ToString(DateTime.Now);
					clientRow["Client Network ID"] = System.Convert.ToString(connectionHandler.ClientID);
					
					string cnnmode = "";
					switch (connectionMode)
					{
						case DPE_ServerDefs.DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus:
							cnnmode = "Not Receive Last Status";
							break;
						case DPE_ServerDefs.DPE_PublicationConnectionMode.ReceiveLastPublicationStatus:
							cnnmode = "Receive Last Status";
							break;
						default:
							cnnmode = "Undefined Status";
							break;
					}
					clientRow["Connection Mode"] = cnnmode;
					
					lock(this._STXDSSClienstSubscribedRegistryTable)
					{
						this._STXDSSClienstSubscribedRegistryTable.Rows.Add(clientRow);
					}
					
					CustomEventLog.DisplayEvent(EventLogEntryType.Information, "Client \'" + subscriptorClient.Name + "\' connected to publication \'" + this._publicationOwner.PublicationName + "\'");
				}
				catch (Exception)
				{
				}
			}
			
			private void UnregisterSubscriptorFromPublication(DPE_Client subscriptorClient)
			{
				try
				{
					
					lock(this._STXDSSClienstSubscribedRegistryTable)
					{
						
						string selectionCriteria = "";
						DataRow[] resultRows = null;
						selectionCriteria = "[Client ID] = \'" + subscriptorClient.ClientID + "\'";
						resultRows = this._STXDSSClienstSubscribedRegistryTable.Select(selectionCriteria);
						if (resultRows.Length > 0)
						{
							DataRow subscriptorRow = resultRows[0];
							this._STXDSSClienstSubscribedRegistryTable.Rows.Remove(subscriptorRow);
							this._STXDSSClienstSubscribedRegistryTable.AcceptChanges();
						}
						
					}
					
				}
				catch (Exception)
				{
					
				}
			}
			
			
#region  < DPE CLIENT MATCH WITH SOCKET CONNECTION >
			
			internal bool LogPendingSocketClientMatchConnectionWithSTXDSSClientTable(SocketsServerClientConnectionHandler ClientHandler)
			{
				if (!this._PendingSocketClientMatchWithSTXDSSClientTable.ContainsKey(ClientHandler.ClientID))
				{
					this._PendingSocketClientMatchWithSTXDSSClientTable.Add(ClientHandler.ClientID, ClientHandler);
					return true;
				}
				else
				{
					return false;
				}
			}
			
			internal bool UnlogPendingSocketClientMatchConnectionWithSTXDSSClientTable(SocketsServerClientConnectionHandler ClientHandler)
			{
				if (this._PendingSocketClientMatchWithSTXDSSClientTable.ContainsKey(ClientHandler.ClientID))
				{
					this._PendingSocketClientMatchWithSTXDSSClientTable.Remove(ClientHandler.ClientID);
					return true;
				}
				else
				{
					return false;
				}
			}
			
#endregion
			
#region  < CLIENT CONNECTION MATCH IDENTIFICATION >
			
			internal dynamic Set_STXDSSClientConnection(DPE_Client client, string publicationConnectionHandlerID, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				
				if (this._PendingSocketClientMatchWithSTXDSSClientTable.ContainsKey(publicationConnectionHandlerID))
				{
					
					SocketsServerClientConnectionHandler socketConnectionHandler = default(SocketsServerClientConnectionHandler);
                    socketConnectionHandler = (SocketsServerClientConnectionHandler)this._PendingSocketClientMatchWithSTXDSSClientTable[publicationConnectionHandlerID];
					if (socketConnectionHandler == null)
					{
						throw (new Exception("There is not registered a socket connection handler of the client \'" + client.Name + "\' in the publication named \'" + this._publicationOwner.PublicationName + "\'"));
					}
					
					this.RegisterNewSubscriptorToPublication(client, socketConnectionHandler, connectionMode);
					
					//regisers in a table the relation of the socket client that belong to the stxdssclient for
					//further reference
					if (!this._socketConnectionHandlerToClientREferenceTable.ContainsKey(socketConnectionHandler.ClientID))
					{
						this._socketConnectionHandlerToClientREferenceTable.Add(socketConnectionHandler.ClientID, client);
					}
					
					//regiosters the relation of the socket connection woth the client for further reference
					if (!this._STXDSSClientTosocketConnectionHandlerReferenceTable.ContainsKey(client.ClientID))
					{
						this._STXDSSClientTosocketConnectionHandlerReferenceTable.Add(client.ClientID, socketConnectionHandler);
					}
					
					//removes from a table the pending match registration
					this.UnlogPendingSocketClientMatchConnectionWithSTXDSSClientTable(socketConnectionHandler);
					
					return true;
					
				}
				else
				{
					//the connection to the publication throuh the socket server don't exists when this happens so then the match is scheduled in a task
					PublicationConnectionClientMatchRegister matchLog = new PublicationConnectionClientMatchRegister(client, publicationConnectionHandlerID, connectionMode);
					
					this._posponedMatchQueue.Enqueue(matchLog);
					this._posponedMatchTimer.Start();
					
					return false;
					
				}
				
			}
			
			internal DPE_Client GetSubscriptorClient(SocketsServerClientConnectionHandler publicationConnectionHandler)
			{
				if (this._socketConnectionHandlerToClientREferenceTable.ContainsKey(publicationConnectionHandler.ClientID))
				{
					DPE_Client client = default(DPE_Client);
                    client = (DPE_Client)this._socketConnectionHandlerToClientREferenceTable[publicationConnectionHandler.ClientID];
					return client;
				}
				else
				{
					return null;
				}
			}
			
			internal void RemoveClientSubscription(SocketsServerClientConnectionHandler publicationConnectionHandler)
			{
				DPE_Client client = default(DPE_Client);
				client = this.GetSubscriptorClient(publicationConnectionHandler);
				if (!(client == null))
				{
					this.UnregisterSubscriptorFromPublication(client);
				}
				
				if (this._STXDSSClientTosocketConnectionHandlerReferenceTable.ContainsKey(client.ClientID))
				{
					this._STXDSSClientTosocketConnectionHandlerReferenceTable.Remove(client.ClientID);
				}
				
				if (this._socketConnectionHandlerToClientREferenceTable.ContainsKey(publicationConnectionHandler.ClientID))
				{
					this._socketConnectionHandlerToClientREferenceTable.Remove(publicationConnectionHandler.ClientID);
				}
				
				this.UnlogPendingSocketClientMatchConnectionWithSTXDSSClientTable(publicationConnectionHandler);
			}
			
			internal SocketsServerClientConnectionHandler GetClientPublicationConnectionHandler(DPE_Client client)
			{
				if (this._STXDSSClientTosocketConnectionHandlerReferenceTable.ContainsKey(client.ClientID))
				{
                    return (SocketsServerClientConnectionHandler)this._STXDSSClientTosocketConnectionHandlerReferenceTable[client.ClientID];
				}
				else
				{
					return null;
				}
			}
			
			internal bool ContainsClientSocketConnectionHandler(string publicationConnectionHandlerID)
			{
				if (this._PendingSocketClientMatchWithSTXDSSClientTable.ContainsKey(publicationConnectionHandlerID))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
#endregion
			
			
#endregion
			
			
#region  < SUPPORT CLASSES  >
			
			private class PublicationConnectionClientMatchRegister
			{
				private DPE_Client _client;
				private string _publicationConnectionHandlerID;
				private DPE_ServerDefs.DPE_PublicationConnectionMode _connectionMode;
				private DateTime _insertionDateTime;
				
				internal PublicationConnectionClientMatchRegister(DPE_Client client, string publicationConnectionHandlerID, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
				{
					this._client = client;
					this._publicationConnectionHandlerID = publicationConnectionHandlerID;
					this._connectionMode = connectionMode;
					this._insertionDateTime = DateTime.Now;
				}
				
internal DPE_Client Client
				{
					get
					{
						return this._client;
					}
				}
internal string PublicationConnectionHandlerID
				{
					get
					{
						return this._publicationConnectionHandlerID;
					}
				}
internal DPE_ServerDefs.DPE_PublicationConnectionMode ConnectionMode
				{
					get
					{
						return this._connectionMode;
					}
				}
				
				public int GetElapsedSeconds()
				{
					TimeSpan t = DateTime.Now.Subtract(this._insertionDateTime);
					int elapsedSEcs = (int) (Math.Abs(t.TotalSeconds));
					return elapsedSEcs;
				}
				
			}
			
#endregion
			
			
		}
		
		
		
		
	}
	
}
