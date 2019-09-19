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
using System.Threading;
using System.Text;
using System.IO;
using System.IO.Compression;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.Queueing;
using UtilitiesLibrary.Services.DataCompression;



namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution
	{
		
		public class SocketsServerClient : IDisposable
		{
			
#region DATA MEMBERS
			
			//Streem to retrieve and send data to the server
			private System.Net.Sockets.Socket _clientSocket;
			//Address of the oject in the server class Direccion del objeto de la clase Servidor
			private string _serverHostName;
			//listening port of the server
			private string _serverListeningPortNumber;
			//tcp client
			private TcpClient _tcpClnt;
			
			//disconnection flag to handle when the communication is lost when the server shutdown
			//or when was a manual disconnection
			private bool _disconnectionFlag;
			
			private string _clientName;
			private string _ClientID;
			private byte[] _DataReceiveBuffer = new byte[SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE + 1];
			
			private TimedProducerConsumerQueue  _incommingDataPRocessingQueue;
			
			private System.Timers.Timer _outgoingDataTimer;
			private Services.SocketsDataDistribution.Data.SocketDataContainer _dataContainer;
			
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ConnectionLostEventHandler(SocketsServerClient sender);
			private ConnectionLostEventHandler ConnectionLostEvent;
			
			public event ConnectionLostEventHandler ConnectionLost
			{
				add
				{
					ConnectionLostEvent = (ConnectionLostEventHandler) System.Delegate.Combine(ConnectionLostEvent, value);
				}
				remove
				{
					ConnectionLostEvent = (ConnectionLostEventHandler) System.Delegate.Remove(ConnectionLostEvent, value);
				}
			}
			
			public delegate void DataReceivedEventHandler(SocketData Data, SocketsServerClient sender);
			private DataReceivedEventHandler DataReceivedEvent;
			
			public event DataReceivedEventHandler DataReceived
			{
				add
				{
					DataReceivedEvent = (DataReceivedEventHandler) System.Delegate.Combine(DataReceivedEvent, value);
				}
				remove
				{
					DataReceivedEvent = (DataReceivedEventHandler) System.Delegate.Remove(DataReceivedEvent, value);
				}
			}
			
			public delegate void DataSentErrorEventHandler(string dataname, Exception ex);
			private DataSentErrorEventHandler DataSentErrorEvent;
			
			public event DataSentErrorEventHandler DataSentError
			{
				add
				{
					DataSentErrorEvent = (DataSentErrorEventHandler) System.Delegate.Combine(DataSentErrorEvent, value);
				}
				remove
				{
					DataSentErrorEvent = (DataSentErrorEventHandler) System.Delegate.Remove(DataSentErrorEvent, value);
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public SocketsServerClient(string ServerHostName, int ServerListeningPort) : this(Guid.NewGuid().ToString(), ServerHostName, ServerListeningPort)
			{
			}
			
			public SocketsServerClient(string clientName, string ServerHostName, int ServerListeningPort)
			{
				this._serverHostName = ServerHostName;
				this._serverListeningPortNumber = System.Convert.ToString(ServerListeningPort);
				this._clientName = clientName.ToUpper();
                this._incommingDataPRocessingQueue = new TimedProducerConsumerQueue();
				this._incommingDataPRocessingQueue.NewItemDetected += this.EventHandling_incommingDataPRocessingTimer_NewItemReceived;
				
				this._dataContainer = new Services.SocketsDataDistribution.Data.SocketDataContainer();
				this._outgoingDataTimer = new System.Timers.Timer(150);
				this._outgoingDataTimer.Elapsed += this.EventHandling_outgoingDataTimer_Elapsed;
				this._outgoingDataTimer.AutoReset = false;
				
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void EventHandling_incommingDataPRocessingTimer_NewItemReceived(object item)
			{
				try
				{
					byte[] data = (byte[]) item;
					
					if (!(data == null))
					{
						Services.SocketsDataDistribution.Data.SocketDataContainer container = Services.SocketsDataDistribution.Data.SocketDataContainer.Deserialize(data);
						SocketData sd = default(SocketData);
						IEnumerator enumm = container.GetEnumerator();
						while (enumm.MoveNext())
						{
                            sd = (SocketData)enumm.Current;
							try
							{
								if (DataReceivedEvent != null)
									DataReceivedEvent(sd, this);
							}
							catch (Exception)
							{
							}
						}
					}
				}
				catch (Exception)
				{
				}
				
			}
			
			private void EventHandling_outgoingDataTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._outgoingDataTimer.Stop();
					
					lock(this._dataContainer)
					{
						if (this._dataContainer.Count > 0)
						{
							byte[] datatosend = this._dataContainer.Serialize();
							this._clientSocket.Send(datatosend, datatosend.Length, SocketFlags.None);
							this._dataContainer.Clear();
						}
					}
					
				}
				catch (Exception)
				{
					
				}
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string ServerHostName
			{
				get
				{
					return _serverHostName;
				}
			}
			
public string ServerListeningPort
			{
				get
				{
					return _serverListeningPortNumber;
				}
			}
			
public int LocalEndPointPortNumber
			{
				get
				{
					IPEndPoint endp = (IPEndPoint) this._tcpClnt.Client.LocalEndPoint;
					return endp.Port;
				}
			}
			
public string ClientID
			{
				get
				{
					return this._ClientID;
				}
			}
			
public string ClientName
			{
				get
				{
					return this._clientName;
				}
			}
			
#endregion
			
#region  < SOCKET INCOMMING DATA READING AND TREATMENT >
			
			public void ClientDataReceptionCallback(IAsyncResult ar)
			{
				//process the data incopmming from the client
				
				byte[] ReceivedBuffer = null;
				ReceivedBuffer = (byte[]) ar.AsyncState;
				
				try
				{
					int bytesRead = this._clientSocket.EndReceive(ar);
					
					if (bytesRead > 0)
					{
						
						try
						{
							this._incommingDataPRocessingQueue.Enqueue(ReceivedBuffer);
						}
						catch (Exception)
						{
						}
						
						try
						{
							//prepares to receive data again
							this._clientSocket.BeginReceive(this._DataReceiveBuffer, 0, this._DataReceiveBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), this._DataReceiveBuffer);
						}
						catch (Exception)
						{
						}
						
					}
					else
					{
						if (!_disconnectionFlag)
						{
							//this event happens when the connection with the stream source is lost
							try
							{
								if (ConnectionLostEvent != null)
									ConnectionLostEvent(this);
							}
							catch (Exception)
							{
							}
						}
						return;
					}
				}
				catch (ObjectDisposedException)
				{
					//do nothing 'the connection already finished
				}
				catch (SocketException ex)
				{
					if (!_disconnectionFlag)
					{
						//this event happens when the connection with the stream source is lost
						if (ex.ErrorCode == 10054)
						{
							//ErrorCode	10054
							//message = Se ha forzado la interrupción de una conexión existente por el host remoto
							try
							{
								if (ConnectionLostEvent != null)
									ConnectionLostEvent(this);
							}
							catch (Exception)
							{
							}
						}
						else if (ex.ErrorCode == 995)
						{
							this._clientSocket.BeginReceive(this._DataReceiveBuffer, 0, this._DataReceiveBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), this._DataReceiveBuffer);
						}
					}
					return;
				}
				catch (Exception ex)
				{
                    CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
#endregion
			
#region < PUBLIC METHODS >
			
			public void Connect()
			{
				_disconnectionFlag = false;
				//connection to the server via a TCPClient
				this._tcpClnt = new TcpClient();
                int portNumber = Convert.ToInt32(this.ServerListeningPort);
				this._tcpClnt.Connect(this.ServerHostName, portNumber);
				this._clientSocket = this._tcpClnt.Client;
				this._clientSocket.Blocking = false;
				this._clientSocket.NoDelay = false;
				this._clientSocket.LingerState = new LingerOption(false, 0);
				this._clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				this._clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				
				this._ClientID = this._tcpClnt.Client.LocalEndPoint.ToString();
				
				this._outgoingDataTimer.Start();
				
				this._clientSocket.BeginReceive(this._DataReceiveBuffer, 0, this._DataReceiveBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), this._DataReceiveBuffer);
				
			}
			
			public void DisconnectFromServer()
			{
				try
				{
					_disconnectionFlag = true;
					this._clientSocket.Disconnect(false);
					this._outgoingDataTimer.Stop();
				}
				catch (Exception)
				{
				}
			}
			
			public void SendDataToServer(SocketData Data)
			{
				
				lock(this._dataContainer)
				{
					this._dataContainer.AddData(Data);
				}
				if (!this._outgoingDataTimer.Enabled)
				{
					this._outgoingDataTimer.Start();
				}
				
			}
			
			public override string ToString()
			{
				string st = "Client : " + this.ClientID;
				string connectedStr = "";
				if (this._clientSocket.Connected)
				{
					connectedStr = ";  Connected To \'" + this.ServerHostName + "\' on Port [" + this.ServerListeningPort + "]";
				}
				st = st + connectedStr;
				return st;
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
							this.DisconnectFromServer();
						}
						catch (Exception)
						{
						}
						try
						{
							this._outgoingDataTimer.Dispose();
						}
						catch (Exception)
						{
						}
						try
						{
							this._incommingDataPRocessingQueue.Dispose();
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
