using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Net;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using UtilitiesLibrary.Services;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.DataCompression;



namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution.ClientConnectionsHandling
	{
		
		public class SocketsServerClientConnectionHandler : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private string _remoteHostName;
			private Socket _handlerSocket;
			private ManualResetEvent WaitToSignalDone = new ManualResetEvent(false);
			private System.Net.IPEndPoint _clientEndPoint;
			private SocketData _LastReceivedData;
			private string _remoteIPAddress;
			private int _remotePortNumber;
			private string _ClientIdentityString;
			private DateTime _connectionDateTime;
			private string _localStringID;
			private IPEndPoint _IPID;
			private string _ClientID;
			private byte[] _DataReceptionBuffer = new byte[SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE + 1];
			private Services.SocketsDataDistribution.Data.SocketDataContainer _dataContainer;
			private System.Timers.Timer _dataSendTimer;
			
			
			
#endregion
			
#region  < PROPERTIES >
			
public Socket handlerSocket
			{
				get
				{
					return this._handlerSocket;
				}
			}
			
public string ClientID
			{
				get
				{
					return this._ClientID;
				}
			}
			
public SocketData LastDataReceived
			{
				get
				{
					return this._LastReceivedData;
				}
				set
				{
					this._LastReceivedData = value;
				}
			}
			
public string RemoteHostName
			{
				get
				{
					return this._remoteHostName;
				}
			}
			
public string RemoteIpAddress
			{
				get
				{
					return this._remoteIPAddress;
				}
			}
			
public int RemotePort
			{
				get
				{
					return this._remotePortNumber;
				}
			}
			
public string IdentityString
			{
				get
				{
					return this._ClientIdentityString;
				}
			}
			
public bool IsConnected
			{
				get
				{
					return this._handlerSocket.Connected;
				}
			}
			
public DateTime ConnectionDateTime
			{
				get
				{
					return this._connectionDateTime;
				}
			}
			
public int DataReceptionBufferSize
			{
				get
				{
					return this._DataReceptionBuffer.Length;
				}
			}
			
public byte[] DataReceptionBuffer
			{
				get
				{
					return this._DataReceptionBuffer;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public SocketsServerClientConnectionHandler(Socket handlerSocket)
			{
				this._handlerSocket = handlerSocket;
				this._handlerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				this._handlerSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendBuffer, SocketsServerDefinitions.MAX_SOCKET_DATA_BUFFER_SIZE);
				try
				{
					IPAddress ipAdd = default(IPAddress);
					ipAdd = IPAddress.Parse(System.Convert.ToString(((IPEndPoint) _handlerSocket.RemoteEndPoint).Address.ToString()));
					this._remoteIPAddress = ipAdd.ToString();
					IPHostEntry hostIp = default(IPHostEntry);
					hostIp = Dns.GetHostEntry(ipAdd);
					this._remoteHostName = hostIp.HostName;
				}
				catch (Exception)
				{
					this._remoteHostName = "Unknown";
				}
				try
				{
					IPEndPoint ip = default(IPEndPoint);
                    ip = (IPEndPoint)this._handlerSocket.RemoteEndPoint;
					this._remotePortNumber = ip.Port;
				}
				catch (Exception)
				{
					this._remotePortNumber = -1;
				}
				
				this._localStringID = Guid.NewGuid().ToString("N");

                IPEndPoint IPEp = (IPEndPoint)handlerSocket.RemoteEndPoint;
                this._IPID = new IPEndPoint(IPEp.Address, this._remotePortNumber);
				
				this._ClientID = this._IPID.ToString();
				
				try
				{
					this._ClientIdentityString = "[CLIENT ID= " + this._localStringID + "] [HOST=" + this._remoteHostName + "] [IP=" + this._remoteIPAddress + "] [PORT=" + System.Convert.ToString(this.RemotePort) + "]";
				}
				catch (Exception)
				{
					this._ClientIdentityString = "UNKNOWN";
				}
				
				this._connectionDateTime = DateTime.Now;
				
				this._dataContainer = new Services.SocketsDataDistribution.Data.SocketDataContainer();
				this._dataSendTimer = new System.Timers.Timer(250);
				this._dataSendTimer.Elapsed += this.EventHandling_dataSendTimer_Elapsed;
				this._dataSendTimer.AutoReset = false;
				this._dataSendTimer.Stop();
				
			}
			
#endregion
			
#region  < EVENT HANDLING  >
			
			private void EventHandling_dataSendTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._dataSendTimer.Stop();
					lock(this._dataContainer)
					{
						byte[] dataToSend = this._dataContainer.Serialize();
						this._handlerSocket.Send(dataToSend);
						this._dataContainer.Clear();
					}
				}
				catch (Exception)
				{
				}
				finally
				{
				}
				
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			internal void CloseConnection()
			{
				try
				{
					this._handlerSocket.Close();
				}
				catch (Exception)
				{
					//do no handling
				}
			}
			
			public void SendData(SocketData data)
			{
				lock(this._dataContainer)
				{
					this._dataContainer.AddData(data);
					if (!this._dataSendTimer.Enabled)
					{
						this._dataSendTimer.Start();
					}
				}
			}
			
			public int ReceiveData(byte[] buffer, int size, SocketFlags socketFlags)
			{
				return this._handlerSocket.Receive(buffer, size, socketFlags);
			}
			
			public override string ToString()
			{
				return this.IdentityString;
			}
			
#endregion
			
#region  < IMPLEMENTATION >
			
#region  < IDisposable >
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects
						this.CloseConnection();
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
