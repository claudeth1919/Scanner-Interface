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



namespace CommunicationsLibrary
{
	namespace Services.AsyncTCPSocketComms
	{
		
		
		
		public class AsynchronousTCPSocketListenerClient : IDisposable
		{
			
			
			private class ConnectionHandlerStateObj
			{
				private Socket _handlerSocket = null;
				public byte[] DataBuffer = new byte[65001];
				
				public ConnectionHandlerStateObj(Socket socketHandler)
				{
					this._handlerSocket = socketHandler;
				}
				
public int BufferSize
				{
					get
					{
						return this.DataBuffer.Length;
					}
				}
				
public Socket HandlerSocket
				{
					get
					{
						return this._handlerSocket;
					}
				}
			}
			
			//signaling events
			private ManualResetEvent _connectionDoneSignal = new ManualResetEvent(false);
			private ManualResetEvent _SendDoneSignal = new ManualResetEvent(false);
			private ManualResetEvent _receiveDoneSignal = new ManualResetEvent(false);
			
			//connection flags
			private string _connectionMessageError;
			private bool _connectionErrorAvailable;
			
			//data send flags
			private string _dataSendMessageError;
			private bool _dateSendErrorAvailable;
			private string _ClientID;
			
			private Socket _listenerClient;
			private IPEndPoint remoteEP;
			
			private System.Timers.Timer _beginReadTimer;
			
			
#region  < CONSTRUCTORS >
			
			public AsynchronousTCPSocketListenerClient(string hostName, int portNumber)
			{
				IPHostEntry ipHostInfo = Dns.GetHostEntry(hostName);
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				this.remoteEP = new IPEndPoint(ipAddress, portNumber);
				_listenerClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				this._connectionMessageError = "";
				this._connectionErrorAvailable = false;
				
				this._beginReadTimer = new System.Timers.Timer(1);
				this._beginReadTimer.Elapsed += this._beginReadTimer_Elapsed;
				this._beginReadTimer.AutoReset = false;
				this._ClientID = this.remoteEP.ToString();
				
			}
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ConnectionLostEventHandler(string ClientID);
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
			
			
			
#endregion
			
#region  < PROPERTIES >
			
public string ClientID
			{
				get
				{
					return this._ClientID;
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void ConnectCallback(IAsyncResult ar)
			{
				try
				{
					Socket client = (Socket) ar.AsyncState;
					client.EndConnect(ar);
					this._ClientID = client.RemoteEndPoint.ToString();
				}
				catch (Exception ex)
				{
					this._connectionMessageError = ex.Message;
					this._connectionErrorAvailable = true;
				}
				finally
				{
					_connectionDoneSignal.Set();
				}
			}
			
			private void SendDataCallback(IAsyncResult ar)
			{
				try
				{
					Socket client = (Socket) ar.AsyncState;
					int bytesSent = client.EndSend(ar);
				}
				catch (Exception)
				{
				}
				finally
				{
					_SendDoneSignal.Set();
				}
			}
			
			private void StartReceiving()
			{
				this._receiveDoneSignal.Reset();
				ConnectionHandlerStateObj state = new ConnectionHandlerStateObj(this._listenerClient);
				this._listenerClient.BeginReceive(state.DataBuffer, 0, state.BufferSize, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ReceiveCallback), state);
				this._receiveDoneSignal.WaitOne();
			}
			
			private void ReceiveCallback(IAsyncResult ar)
			{
				
				// Retrieve the state object and the client socket
				// from the asynchronous state object.
				ConnectionHandlerStateObj state = (ConnectionHandlerStateObj) ar.AsyncState;
				Socket client = state.HandlerSocket;
				
				// Read data from the remote device.
				try
				{
					int bytesRead = client.EndReceive(ar);
				}
				catch (SocketException)
				{
					try
					{
						
						if (ConnectionLostEvent != null)
							ConnectionLostEvent(this.ClientID);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception)
				{
					
				}
				
			}
			
#endregion
			
			
#region  < EVENT HANDLING >
			
			private void _beginReadTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._beginReadTimer.Stop();
					this.StartReceiving();
				}
				catch (Exception)
				{
				}
				
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void Connect()
			{
				this._connectionMessageError = "";
				this._connectionErrorAvailable = false;
				
				_connectionDoneSignal.Reset();
				_listenerClient.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), _listenerClient);
				_connectionDoneSignal.WaitOne();
				
				if (_connectionErrorAvailable == true)
				{
					throw (new Exception(this._connectionMessageError));
				}
				
				this._beginReadTimer.Start();
				
			}
			
			public void SendData(byte[] byteData)
			{
				this._dataSendMessageError = "";
				this._dateSendErrorAvailable = false;
				_SendDoneSignal.Reset();
				_listenerClient.BeginSend(byteData, 0, byteData.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(SendDataCallback), _listenerClient);
				_SendDoneSignal.WaitOne();
				if (_dateSendErrorAvailable)
				{
					throw (new Exception(this._dataSendMessageError));
				}
			}
			
#endregion
			
#region  INTERFACE IMPLEMENTATION
			
			
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
						this._listenerClient.Disconnect(false);
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
