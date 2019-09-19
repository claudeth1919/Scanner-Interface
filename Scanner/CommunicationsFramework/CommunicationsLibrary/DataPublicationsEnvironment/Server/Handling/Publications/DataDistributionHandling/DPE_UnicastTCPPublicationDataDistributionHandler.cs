using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using UtilitiesLibrary.EventLoging;
using System.Threading;



namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications.DataDistributionHandling
	{
		
		
		public class DPE_UnicastTCPPublicationDataDistributionHandler : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private string _publicationOwnerName;
			
			private Hashtable _TCPSocketsServerClientsTable;
			private Hashtable _TCPSocketsConnectionStringIDReferenceTable;
			private Hashtable _DisconnectedTCPsocketServerClientsTable;
			
			private Queue _TCPUnicastDataDistributionQueue;
			private System.Timers.Timer _dataDistributionTimer;
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_UnicastTCPPublicationDataDistributionHandler(string publicationOwnerName)
			{
				
				this._publicationOwnerName = publicationOwnerName;
				
				this._TCPSocketsServerClientsTable = new Hashtable();
				this._DisconnectedTCPsocketServerClientsTable = new Hashtable();
				this._TCPSocketsConnectionStringIDReferenceTable = new Hashtable();
				
				this._TCPUnicastDataDistributionQueue = new Queue();
				this._dataDistributionTimer = new System.Timers.Timer(1);
				this._dataDistributionTimer.Elapsed += this.eventHandling__dataDistributionTimer_Elapsed;
				this._dataDistributionTimer.AutoReset = false;
				this._dataDistributionTimer.Stop();
				
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			
#region  < SOCKETS SERVER FOR  TCP DATA DISTRIBUTION >
			
			private void TCPSocketsServerClient_ConnectionLost(CommunicationsLibrary.Services.SocketsDataDistribution.SocketsServerClient sender)
			{
				try
				{
					//adds to the table of clients which connection went lost in order to further evaluate if
					//a local client is valid to send data
					lock(this._DisconnectedTCPsocketServerClientsTable)
					{
						this._DisconnectedTCPsocketServerClientsTable.Add(sender.ClientID, sender);
					}
					
					string clientID = sender.ClientID;
					
					//removes any event hanlder for the connection object
					SocketsServerClient client = null;
					
					if (this._TCPSocketsServerClientsTable.ContainsKey(clientID))
					{
                        client = (SocketsServerClient)this._TCPSocketsServerClientsTable[sender.ClientID];
						client.ConnectionLost -= TCPSocketsServerClient_ConnectionLost;
					}
					
					this.CleanClientDisconnectionsEnvironment();
					
					//gets the connection string id and removes from the connections available
					string connectionPortStringID = "";
                    int portNumber = Convert.ToInt32(sender.ServerListeningPort);
                    connectionPortStringID = this.GetConnectionStringID(sender.ServerHostName, portNumber);
					lock(this._TCPSocketsConnectionStringIDReferenceTable)
					{
						this._TCPSocketsConnectionStringIDReferenceTable.Remove(connectionPortStringID);
					}
					
					if (!(client == null))
					{
						try
						{
							client.DisconnectFromServer();
						}
						catch (Exception)
						{
						}
						try
						{
							client.Dispose();
						}
						catch (Exception)
						{
						}
					}
					
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < TIMER FOR DATA DISTRINBUTION >
			
			private void eventHandling__dataDistributionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._dataDistributionTimer.Stop();
					
					SocketData dataToBeSend = null;
					
					if (this._TCPUnicastDataDistributionQueue.Count > 0)
					{
						
						lock(this._TCPUnicastDataDistributionQueue)
						{
							
							try
							{
                                dataToBeSend = (SocketData)this._TCPUnicastDataDistributionQueue.Dequeue();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
								dataToBeSend = null;
							}
							
						}
						
						if (!(dataToBeSend == null))
						{
							
							IEnumerator enumm = default(IEnumerator);
							SocketsServerClient client = default(SocketsServerClient);
							
							lock(this._TCPSocketsServerClientsTable)
							{
								
								try
								{
									enumm = this._TCPSocketsServerClientsTable.GetEnumerator();
									while (enumm.MoveNext())
									{
										try
										{
											client = (SocketsServerClient) (((DictionaryEntry) enumm.Current).Value);
											
											//verifies if the client is valid to send data
											if (!this._DisconnectedTCPsocketServerClientsTable.ContainsKey(client.ClientID))
											{
												try
												{
													client.SendDataToServer(dataToBeSend);
												}
												catch (Exception ex)
												{
													CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
												}
											}
										}
										catch (Exception ex)
										{
											CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
										}
										Thread.Sleep(1);
									}
									
								}
								catch (Exception ex)
								{
									CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
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
					if (this._TCPUnicastDataDistributionQueue.Count > 0)
					{
						this._dataDistributionTimer.Start();
					}
				}
			}
			
			
#endregion
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void CleanClientDisconnectionsEnvironment()
			{
				//removes from the sockets clients table the ones which disconnection went lost
				//in order to avoid to try to send data to a connection that is no longer valid
				
				if (this._DisconnectedTCPsocketServerClientsTable.Count > 0)
				{
					
					SocketsServerClient client = null;
					
					lock(this._DisconnectedTCPsocketServerClientsTable)
					{
						
						IEnumerator enumm = default(IEnumerator);
						enumm = this._DisconnectedTCPsocketServerClientsTable.GetEnumerator();
						
						while (enumm.MoveNext())
						{
							
							client = (SocketsServerClient) (((DictionaryEntry) enumm.Current).Value);
							
							lock(this._TCPSocketsServerClientsTable)
							{
								try
								{
									this._TCPSocketsServerClientsTable.Remove(client.ClientID);
								}
								catch (Exception ex)
								{
									CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
								}
							}
						}
						
					}
					
					try
					{
						this._DisconnectedTCPsocketServerClientsTable.Clear();
					}
					catch (Exception ex)
					{
						CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
					}
					
				}
				
			}
			
			private string GetConnectionStringID(string hostName, int listeningTCPPortNumber)
			{
				
				string hostNameUpperCase = hostName.ToUpper();
				string connectionPortStringID = "";
				connectionPortStringID = hostNameUpperCase + System.Convert.ToString(listeningTCPPortNumber);
				return connectionPortStringID;
				
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SchedulePublicationUpdate(SocketData data)
			{
				try
				{
					lock(this._TCPUnicastDataDistributionQueue)
					{
						this._TCPUnicastDataDistributionQueue.Enqueue(data);
					}
					
					this._dataDistributionTimer.Start();
					
				}
				catch (Exception)
				{
				}
			}
			
			internal void HandleUnicastTCPConnectionToRemoteProxy(string HostName, int listeningTCPPortNumber)
			{
				
				//creates a unique string ID using the hostname and the port number in order to determine it there
				//is a previous connection to that port
				string connectionPortStringID = "";
				connectionPortStringID = this.GetConnectionStringID(HostName, listeningTCPPortNumber);
				
				if (!this._TCPSocketsConnectionStringIDReferenceTable.Contains(connectionPortStringID))
				{
					
					SocketsServerClient socketsServerClient = new SocketsServerClient(HostName, listeningTCPPortNumber);
					
					socketsServerClient.Connect();
					
					socketsServerClient.ConnectionLost += TCPSocketsServerClient_ConnectionLost;
					
					//-----------------------------------------------------------------
					//adds to the socketsServerClients Table that hold the connection handlers
					lock(this._TCPSocketsServerClientsTable)
					{
						try
						{
							this._TCPSocketsServerClientsTable.Remove(socketsServerClient.ClientID);
						}
						catch (Exception)
						{
						}
						this._TCPSocketsServerClientsTable.Add(socketsServerClient.ClientID, socketsServerClient);
					}
					
					//-----------------------------------------------------------------
					//adds to the reference connectionsStringID in order to know that a connection to the
					//specified host and port exists already
					lock(this._TCPSocketsConnectionStringIDReferenceTable)
					{
						try
						{
							this._TCPSocketsConnectionStringIDReferenceTable.Remove(connectionPortStringID);
						}
						catch (Exception)
						{
						}
						this._TCPSocketsConnectionStringIDReferenceTable.Add(connectionPortStringID, socketsServerClient);
					}
					
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
						
						try
						{
							this._dataDistributionTimer.Stop();
							this._dataDistributionTimer.Dispose();
						}
						catch (Exception)
						{
						}
						
						
						IEnumerator enumm = default(IEnumerator);
						SocketsServerClient client = default(SocketsServerClient);
						enumm = this._TCPSocketsServerClientsTable.GetEnumerator();
						
						while (enumm.MoveNext())
						{
							client = (SocketsServerClient) (((DictionaryEntry) enumm.Current).Value);
							try
							{
								client.DisconnectFromServer();
								client.Dispose();
							}
							catch (Exception)
							{
							}
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
