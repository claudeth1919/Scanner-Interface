using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using System.Threading;



namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution
	{
		
		public class SocketsServerMultiplexingManager : IDisposable
		{
			
			
#region  <  DATA MEMBERS >
			
			private Hashtable _serversTable;
			private int _maxNumberOfClientsPerServer;
			private int _initialServerPortsNumberRange;
			private int _finalServerPortsNumberRange;
			
			private SocketsServersStack _serversStack;
			
			private bool _discardServersWhenThereWerentClientsConnected;
			
			
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ServerDisposedEventHandler(SocketsServer server);
			private ServerDisposedEventHandler ServerDisposedEvent;
			
			public event ServerDisposedEventHandler ServerDisposed
			{
				add
				{
					ServerDisposedEvent = (ServerDisposedEventHandler) System.Delegate.Combine(ServerDisposedEvent, value);
				}
				remove
				{
					ServerDisposedEvent = (ServerDisposedEventHandler) System.Delegate.Remove(ServerDisposedEvent, value);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
public int ClientsConnectionsCount
			{
				get
				{
					int count = 0;
					lock(this._serversTable)
					{
						IEnumerator enumm = this._serversTable.GetEnumerator();
						SocketsServer server = default(SocketsServer);
						while (enumm.MoveNext())
						{
                            server = (SocketsServer)((DictionaryEntry)enumm.Current).Value;
							count += server.ClientConnectionsCount;
						}
						
					}
					return count;
				}
			}
			
public Collection ServersList
			{
				get
				{
					Collection col = new Collection();
					IEnumerator enumm = this._serversTable.GetEnumerator();
					SocketsServer server = default(SocketsServer);
					
					lock(this._serversTable)
					{
						
						while (enumm.MoveNext())
						{
                            server = (SocketsServer)((DictionaryEntry)enumm.Current).Value;
							col.Add(server, null, null, null);
						}
						
					}
					
					return col;
					
				}
			}
			
public int ServersCount
			{
				get
				{
					return this._serversTable.Count;
				}
			}
			
public int ConnectionsPerServer
			{
				get
				{
					return this._maxNumberOfClientsPerServer;
				}
			}
			
#endregion
			
#region  < EVENTS  >
			
			public delegate void DataReceivedFromClientEventHandler(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler, SocketData data);
			private DataReceivedFromClientEventHandler DataReceivedFromClientEvent;
			
			public event DataReceivedFromClientEventHandler DataReceivedFromClient
			{
				add
				{
					DataReceivedFromClientEvent = (DataReceivedFromClientEventHandler) System.Delegate.Combine(DataReceivedFromClientEvent, value);
				}
				remove
				{
					DataReceivedFromClientEvent = (DataReceivedFromClientEventHandler) System.Delegate.Remove(DataReceivedFromClientEvent, value);
				}
			}
			
			
#endregion
			
#region  <  CONSTRUCTORS  >
			
			public SocketsServerMultiplexingManager(int initialServerPortsNumberRange, int finalServerPortsNumberRange, int maxNumberOfClientsPerServer, bool DiscardServersWhenThereWerentClientsConnected)
			{
				this._serversTable = new Hashtable();
				this._serversStack = new SocketsServersStack();
				
				this._initialServerPortsNumberRange = initialServerPortsNumberRange;
				this._finalServerPortsNumberRange = finalServerPortsNumberRange;
				this._maxNumberOfClientsPerServer = maxNumberOfClientsPerServer;
				
				//sets and initial server and push into the stack to be retrieved
				SocketsServer initialServer = this.CreateAndStackServer();
				
				this._discardServersWhenThereWerentClientsConnected = DiscardServersWhenThereWerentClientsConnected;
				
			}
			
#endregion
			
#region  < EVENT HANDLING  >
			
			private void eventHandling_NewClientConnection(SocketsServerClientConnectionHandler ClientHandler)
			{
				try
				{
				}
				catch (Exception)
				{
				}
			}
			
			private void eventHandling_ClientDataReceived(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler, SocketData data)
			{
				try
				{
					if (DataReceivedFromClientEvent != null)
						DataReceivedFromClientEvent(server, ClientHandler, data);
				}
				catch (Exception)
				{
				}
			}
			
			public void eventHandling_ClientConnectionFinished(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler)
			{
				// a client is disconnected from one of the servers so then is pushed into the stack to make it available
				//for the next request for a server available wiht room for connections
				try
				{
					if (server.ClientConnectionsCount < this._maxNumberOfClientsPerServer)
					{
						if (server.ClientConnectionsCount > 0)
						{
							this._serversStack.Push(server);
						}
						else
						{
							if (this._discardServersWhenThereWerentClientsConnected)
							{
								this.DisposeServer(server);
							}
						}
					}
				}
				catch (Exception)
				{
				}
				
			}
			
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private SocketsServer CreateAndStackServer()
			{
				SocketsServer newSServer = default(SocketsServer);
				
				lock(this._serversTable)
				{
					
					newSServer = new SocketsServer(this._initialServerPortsNumberRange, this._finalServerPortsNumberRange);
					
					this._serversTable.Add(newSServer.ServerID, newSServer);
					
					newSServer.ClientDataReceived += eventHandling_ClientDataReceived;
					newSServer.NewClientConnection += eventHandling_NewClientConnection;
					newSServer.ClientConnectionFinished += eventHandling_ClientConnectionFinished;
					
				}
				
				this._serversStack.Push(newSServer);
				
				return newSServer;
			}
			
			private void DisposeServer(SocketsServer server)
			{
				
				if (!(server == null))
				{
					
					if (this._serversTable.ContainsKey(server.ServerID))
					{
						
						
						server.ClientDataReceived -= eventHandling_ClientDataReceived;
						server.NewClientConnection -= eventHandling_NewClientConnection;
						server.ClientConnectionFinished -= eventHandling_ClientConnectionFinished;
						
						
						
						lock(this._serversTable)
						{
							
							this._serversTable.Remove(server.ServerID);
							this._serversStack.RemoveServerFromStack(server);
							
						}
						
						try
						{
							if (ServerDisposedEvent != null)
								ServerDisposedEvent(server);
						}
						catch (Exception)
						{
						}
						
						server.Dispose();
						
					}
					
				}
				
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public SocketsServer GetCurrentAvailableServer()
			{
				SocketsServer currentServerAvailable = null;
				bool serverFound = false;
				
				lock(this._serversStack)
				{
					
					while (this._serversStack.Count > 0)
					{
						
						//gets the server on the stack top without removing it
						currentServerAvailable = this._serversStack.Peek();
						
						if (!(currentServerAvailable == null))
						{
							
							if (currentServerAvailable.ClientConnectionsCount < this._maxNumberOfClientsPerServer)
							{
								//the current server on the stack has no more room available , so then is created a new
								//server to receive data
								serverFound = true;
								break;
							}
							else
							{
								//if the server in the stack has no more room for the maximun number of connections
								//allowed for the server then is removed from the stack
								this._serversStack.Pop();
								serverFound = false;
							}
						}
						else
						{
							//if the referece is invalid
							this._serversStack.Pop();
							serverFound = false;
						}
						
					}
					
				}
				
				//by the end of the lookin up if the flag 'server found' is false means there where no server with availabel space
				if (!serverFound)
				{
					currentServerAvailable = this.CreateAndStackServer();
				}
				
				return currentServerAvailable;
				
			}
			
			
#region  < INTERFACE IMPLEMENTATION  >
			
			
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
						
						lock(this._serversTable)
						{
							
							IEnumerator enumm = this._serversTable.GetEnumerator();
							SocketsServer server = null;
							
							while (enumm.MoveNext())
							{
								server = (SocketsServer) (((DictionaryEntry) enumm.Current).Value);
								server.Dispose();
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
			
			
#endregion
			
			
			private class SocketsServersStack
			{
				
				private SortedList _serversTable;
				
public int Count
				{
					get
					{
						return this._serversTable.Count;
					}
				}
				
				public SocketsServersStack()
				{
					this._serversTable = new SortedList();
				}
				
				public void Push(SocketsServer server)
				{
					//adds a server to the end of the stack
					lock(this._serversTable)
					{
						int index = this._serversTable.Count + 1;
						this._serversTable.Add(index, server);
					}
					
				}
				
				public SocketsServer Pop()
				{
					SocketsServer server = default(SocketsServer);
					
					lock(this._serversTable)
					{
						int index = this._serversTable.Count;
                        server = (SocketsServer)this._serversTable[index];
						this._serversTable.Remove(index);
					}
					
					return server;
					
				}
				
				public SocketsServer Peek()
				{
					
					SocketsServer server = default(SocketsServer);
					
					lock(this._serversTable)
					{
						int index = this._serversTable.Count;
                        server = (SocketsServer)this._serversTable[index];
					}
					
					return server;
				}
				
				public void RemoveServerFromStack(SocketsServer server)
				{
					
					lock(this._serversTable)
					{
						
						//removes all the references of the server on the sorted list
						IEnumerator enumm = this._serversTable.GetEnumerator();
						int index = 0;
						SocketsServer localServerOnTable = null;
						Collection colOfIndexToDeleteFromTable = new Collection();
						
						while (enumm.MoveNext())
						{
							index = System.Convert.ToInt32(((DictionaryEntry) enumm.Current).Key);
							localServerOnTable = (SocketsServer) (((DictionaryEntry) enumm.Current).Value);
							
							if (localServerOnTable.ServerID == server.ServerID)
							{
								colOfIndexToDeleteFromTable.Add(index, null, null, null);
							}
						}
						
						//remves the elements from the list
						enumm = colOfIndexToDeleteFromTable.GetEnumerator();
						while (enumm.MoveNext())
						{
							index = System.Convert.ToInt32(enumm.Current);
							this._serversTable.Remove(index);
						}
						
						//copies all the elements left into a new colllection
						SortedList copyOfServersList = new SortedList();
						int newIndex = 1;
						enumm = this._serversTable.GetEnumerator();
						
						while (enumm.MoveNext())
						{
							localServerOnTable = (SocketsServer) (((DictionaryEntry) enumm.Current).Value);
							copyOfServersList.Add(newIndex, localServerOnTable);
							newIndex++;
						}
						
						this._serversTable.Clear();
						
						enumm = copyOfServersList.GetEnumerator();
						while (enumm.MoveNext())
						{
							localServerOnTable = (SocketsServer) (((DictionaryEntry) enumm.Current).Value);
							this.Push(localServerOnTable);
						}
						
					}
					
				}
				
			}
			
			
			
			
			
		}
		
	}
	
	
	
	
}
