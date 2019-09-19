using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using CommunicationsLibrary.Services.TCPPortsManagement;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.Queueing;
using UtilitiesLibrary.Services.DataCompression;


namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution
	{
		
		public class SocketsServer : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private string _serverID;
			
			//table to contain the information of all the connected clients
			private Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionsHandlerTable _connectedClientsTable;
			
			//connection information of the last incomming client connection
			private System.Net.IPEndPoint _currentClientInformation;
			private SocketsServerClientConnectionHandler _incommingClientConnection;
			
			//variables to manage the client incomming connections
			private TcpListener _tcpLsn; //listener to process incomming connections
			private string _listeningPortNumber; //Server listening port
			
			private string _hostName;
			
			//statistical variables
			private DateTime _StartDateTime;
			
			private bool _dataBroadCast;
			
			private ThreadPooledProducerConsumerQueue _incommingDataProcessingQueue;
			
#endregion
			
#region < EVENTS >
			
			public delegate void NewClientConnectionEventHandler(SocketsServerClientConnectionHandler ClientHandler);
			private NewClientConnectionEventHandler NewClientConnectionEvent;
			
			public event NewClientConnectionEventHandler NewClientConnection
			{
				add
				{
					NewClientConnectionEvent = (NewClientConnectionEventHandler) System.Delegate.Combine(NewClientConnectionEvent, value);
				}
				remove
				{
					NewClientConnectionEvent = (NewClientConnectionEventHandler) System.Delegate.Remove(NewClientConnectionEvent, value);
				}
			}
			
			public delegate void ClientDataReceivedEventHandler(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler, SocketData data);
			private ClientDataReceivedEventHandler ClientDataReceivedEvent;
			
			public event ClientDataReceivedEventHandler ClientDataReceived
			{
				add
				{
					ClientDataReceivedEvent = (ClientDataReceivedEventHandler) System.Delegate.Combine(ClientDataReceivedEvent, value);
				}
				remove
				{
					ClientDataReceivedEvent = (ClientDataReceivedEventHandler) System.Delegate.Remove(ClientDataReceivedEvent, value);
				}
			}
			
			public delegate void ClientConnectionFinishedEventHandler(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler);
			private ClientConnectionFinishedEventHandler ClientConnectionFinishedEvent;
			
			public event ClientConnectionFinishedEventHandler ClientConnectionFinished
			{
				add
				{
					ClientConnectionFinishedEvent = (ClientConnectionFinishedEventHandler) System.Delegate.Combine(ClientConnectionFinishedEvent, value);
				}
				remove
				{
					ClientConnectionFinishedEvent = (ClientConnectionFinishedEventHandler) System.Delegate.Remove(ClientConnectionFinishedEvent, value);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
public string ServerID
			{
				get
				{
					return this._serverID;
				}
			}
			
public string ListeningPort
			{
				get
				{
					return this._listeningPortNumber;
				}
			}
			
private Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionsHandlerTable ClientsConnectionsTable
			{
				get
				{
					return this._connectedClientsTable;
				}
			}
			
public int ClientConnectionsCount
			{
				get
				{
					return this._connectedClientsTable.NumOfConnectedClients;
				}
			}
			
public string HostName
			{
				get
				{
					return this._hostName;
				}
			}
			
public DateTime StartDateTime
			{
				get
				{
					return this._StartDateTime;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public SocketsServer(int initialTCPPortNumberToFindAFreePort, int finalTCPPortNumberToFindAFreePort)
			{
				this._listeningPortNumber = System.Convert.ToString(Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPortOnARange(initialTCPPortNumberToFindAFreePort, finalTCPPortNumberToFindAFreePort));
				this._connectedClientsTable = new Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionsHandlerTable();
				this.StartServer();
			}
			
			public SocketsServer(int listeningPort)
			{
				this._listeningPortNumber = System.Convert.ToString(listeningPort);
				this._connectedClientsTable = new Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionsHandlerTable();
				this.StartServer();
			}
			
			public SocketsServer()
			{
				this._listeningPortNumber = System.Convert.ToString(Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPort());
				this._connectedClientsTable = new Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionsHandlerTable();
				this.StartServer();
			}
			
			
#endregion
			
#region  < PRIVATE METHODS >
			
			
			private void StartServer()
			{
				this._serverID = Guid.NewGuid().ToString();
				this._serverID = this._serverID.ToUpper();
				this._serverID = this._serverID.Replace("-", "");
				
				this._hostName = Dns.GetHostName();
				
				//*****************************************************************************************
				//client incomming connections management
				
				string host = System.Net.Dns.GetHostName();
                IPAddress local_IPAddress = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetActiveIPAddress();
                int portNumber  = Convert.ToInt32(this.ListeningPort);
                this._tcpLsn = new TcpListener(local_IPAddress, portNumber);
				
				//starts the listener
				this._tcpLsn.Start();
				this._tcpLsn.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				this._tcpLsn.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				this._tcpLsn.Server.LingerState = new LingerOption(false, 0);
				this._tcpLsn.Server.NoDelay = false;
				this._tcpLsn.Server.Blocking = true;
				
				this._StartDateTime = DateTime.Now;
				
				
				this._dataBroadCast = true;
				
				this._incommingDataProcessingQueue = new ThreadPooledProducerConsumerQueue();
				this._incommingDataProcessingQueue.NewItemDetected += this.EventHandling_incommingDataProcessingQueue_NewItemDetected;
				
				
				//starts the ASYNCHORNIC connections listening
				this._tcpLsn.Server.BeginAccept(new AsyncCallback(ClientConnectionCallback), this._tcpLsn.Server);
				
				
			}
			
			private void FinishClientSocketConnection(SocketsServerClientConnectionHandler ClientHandler)
			{
				try
				{
					ClientHandler.CloseConnection();
				}
				catch (Exception)
				{
					//do no handling
				}
				try
				{
					ClientHandler.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					lock(this.ClientsConnectionsTable)
					{
						this.ClientsConnectionsTable.RemoveClientSocketHandler(ClientHandler);
					}
				}
				catch (Exception)
				{
					//do no handling
				}
			}
			
			private void FinishAllClientSocketConnections()
			{
				IEnumerator enumm = default(IEnumerator);
				SocketsServerClientConnectionHandler client = default(SocketsServerClientConnectionHandler);
				
				enumm = this.ClientsConnectionsTable.GetEnumerator();
				while (enumm.MoveNext())
				{
                    client = (SocketsServerClientConnectionHandler)enumm.Current;
					this.FinishClientSocketConnection(client);
				}
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void EventHandling_incommingDataProcessingQueue_NewItemDetected(object item)
			{
				try
				{
					
					SocketsServerClientConnectionHandler clientCnnHandler = (SocketsServerClientConnectionHandler) item;
					
					if (!(clientCnnHandler == null))
					{
						
						Services.SocketsDataDistribution.Data.SocketDataContainer container = Services.SocketsDataDistribution.Data.SocketDataContainer.Deserialize(clientCnnHandler.DataReceptionBuffer);
						
						IEnumerator enumm = container.GetEnumerator();
						SocketsServerClientConnectionHandler client = this._connectedClientsTable.GetClientConnectionHandler(clientCnnHandler.ClientID);
						SocketData data = default(SocketData);
						while (enumm.MoveNext())
						{
                            data = (SocketData)enumm.Current;
							try
							{
								if (ClientDataReceivedEvent != null)
									ClientDataReceivedEvent(this, client, data);
							}
							catch (Exception)
							{
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
					
				}
				
			}
			
#endregion
			
#region  < ASYNCHRONIC OPERATION MANAGEMENT FOR DATA RECEPTION AND PROCESSING >
			
			private void ClientConnectionCallback(IAsyncResult ar)
			{
				Socket listener = default(Socket);
				Socket handler = default(Socket);
				SocketsServerClientConnectionHandler newClientConnectionHandler = null;
				
				try
				{
					this._tcpLsn.Server.BeginAccept(new AsyncCallback(ClientConnectionCallback), this._tcpLsn.Server);
				}
				catch (Exception)
				{
				}
				
				try
				{
					listener = (Socket) ar.AsyncState;
					handler = listener.EndAccept(ar);
					newClientConnectionHandler = new SocketsServerClientConnectionHandler(handler);
				}
				catch (ObjectDisposedException)
				{
					//do nothing
				}
				catch (Exception ex2)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex2.ToString());
					newClientConnectionHandler = null;
				}
				
				if (!(newClientConnectionHandler == null))
				{
					try
					{
						this.ClientsConnectionsTable.AddClientSocketHandler(newClientConnectionHandler);
					}
					catch (Exception)
					{
					}
					
					try
					{
						if (NewClientConnectionEvent != null)
							NewClientConnectionEvent(newClientConnectionHandler);
					}
					catch (Exception)
					{
					}
					
					try
					{
						newClientConnectionHandler.handlerSocket.BeginReceive(newClientConnectionHandler.DataReceptionBuffer, 0, newClientConnectionHandler.DataReceptionBufferSize, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), newClientConnectionHandler);
					}
					catch (Exception)
					{
					}
					
				}
				
			}
			
			private void ClientDataReceptionCallback(IAsyncResult ar)
			{
				//process the data incopmming from the client
				
				SocketsServerClientConnectionHandler clientCnnHandler = default(SocketsServerClientConnectionHandler);
				clientCnnHandler = (SocketsServerClientConnectionHandler) ar.AsyncState;
				
				try
				{
					int bytesRead = clientCnnHandler.handlerSocket.EndReceive(ar);
					
					if (bytesRead > 0)
					{
						
						try
						{
							this._incommingDataProcessingQueue.Enqueue(clientCnnHandler);
						}
						catch (Exception)
						{
						}
						
						//prepares to receive data again
						try
						{
							clientCnnHandler.handlerSocket.BeginReceive(clientCnnHandler.DataReceptionBuffer, 0, clientCnnHandler.DataReceptionBufferSize, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), clientCnnHandler);
						}
						catch (Exception)
						{
						}
						
						
					}
					else
					{
						try
						{
							this.FinishClientSocketConnection(clientCnnHandler);
						}
						catch (Exception)
						{
						}
						try
						{
							if (ClientConnectionFinishedEvent != null)
								ClientConnectionFinishedEvent(this, clientCnnHandler);
						}
						catch (Exception)
						{
						}
					}
				}
				catch (ObjectDisposedException)
				{
					//do nothing 'the connection already finished
				}
				catch (SocketException)
				{
					try
					{
						this.FinishClientSocketConnection(clientCnnHandler);
					}
					catch (Exception)
					{
					}
					try
					{
						if (ClientConnectionFinishedEvent != null)
							ClientConnectionFinishedEvent(this, clientCnnHandler);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void StopServer()
			{
				try
				{
					try
					{
						this.FinishAllClientSocketConnections();
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._tcpLsn.Stop();
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._tcpLsn.Server.Close();
					}
					catch (Exception)
					{
					}
					
				}
				catch (Exception)
				{
				}
			}
			
			public void SendDataToClient(SocketsServerClientConnectionHandler ClientHandler, SocketData Data)
			{
				ClientHandler.SendData(Data);
			}
			
			public void BroadCastData(SocketData Data)
			{
				
				lock(this._connectedClientsTable)
				{
					
					IEnumerator enumm = default(IEnumerator);
					SocketsServerClientConnectionHandler client = default(SocketsServerClientConnectionHandler);
					enumm = this._connectedClientsTable.GetEnumerator();
					if (this._connectedClientsTable.NumOfConnectedClients > 0)
					{
						
						
						while (enumm.MoveNext())
						{
                            client = (SocketsServerClientConnectionHandler)enumm.Current;
							try
							{
								this.SendDataToClient(client, Data);
							}
							catch (ObjectDisposedException)
							{
							}
							catch (Exception ex)
							{
								string msg = "";
								msg = "Error broadcasting data to connected clients : " + ex.ToString();
								CustomEventLog.DisplayEvent(EventLogEntryType.Error, msg);
							}
						}
					}
					
				}
				
			}
			
			public override string ToString()
			{
				string str = "Server : " + this._serverID + " ; [  Clients Connected = " + System.Convert.ToString(this.ClientConnectionsCount) + "  ] ";
				return str;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDisposable >
			
			public void Dispose()
			{
				try
				{
					this.StopServer();
				}
				catch (Exception)
				{
				}
				try
				{
					this._incommingDataProcessingQueue.Dispose();
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#endregion
			
		}
		
		
	}
	
	
	
}
