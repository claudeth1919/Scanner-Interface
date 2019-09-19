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
using System.Text;
using System.Threading;



namespace CommunicationsLibrary
{
	namespace Services.AsyncTCPSocketComms
	{
		
		public class AsynchronousTCPSocketListener : IDisposable
		{
			
			
			private class ConnectionHandlerStateObj
			{
				public Socket workSocket = null;
				public const int BufferSize = 65000;
				public byte[] buffer = new byte[BufferSize + 1];
				public StringBuilder sb = new StringBuilder();
			}
			
			private ManualResetEvent waitConnectionSignal = new ManualResetEvent(false);
			private bool _WaitConnectionsFlag;
			private int _portNumber;
			private System.Timers.Timer _waitConnectionTimer;
			private Socket listener;
			private Collection _handlersList;
			
			
#region  < CONTRUCTORS >
			
			public AsynchronousTCPSocketListener(int portNumber)
			{
				this._portNumber = portNumber;
				IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
				
				listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				listener.Bind(localEndPoint);
				listener.Listen(100);
				
				this._handlersList = new Collection();
				
				this._WaitConnectionsFlag = true;
				
				_waitConnectionTimer = new System.Timers.Timer(10);
				_waitConnectionTimer.Elapsed += _waitConnectionTimer_Elapsed;
				_waitConnectionTimer.AutoReset = false;
				_waitConnectionTimer.Start();
				
			}
			
#endregion
			
#region  < PROPERTIES >
			
public int ListeningPortNumber
			{
				get
				{
					return this._portNumber;
				}
			}
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ClientConnectionReceivedEventHandler(string clientID);
			private ClientConnectionReceivedEventHandler ClientConnectionReceivedEvent;
			
			public event ClientConnectionReceivedEventHandler ClientConnectionReceived
			{
				add
				{
					ClientConnectionReceivedEvent = (ClientConnectionReceivedEventHandler) System.Delegate.Combine(ClientConnectionReceivedEvent, value);
				}
				remove
				{
					ClientConnectionReceivedEvent = (ClientConnectionReceivedEventHandler) System.Delegate.Remove(ClientConnectionReceivedEvent, value);
				}
			}
			
			public delegate void ClientConnectionLostEventHandler(string clientID);
			private ClientConnectionLostEventHandler ClientConnectionLostEvent;
			
			public event ClientConnectionLostEventHandler ClientConnectionLost
			{
				add
				{
					ClientConnectionLostEvent = (ClientConnectionLostEventHandler) System.Delegate.Combine(ClientConnectionLostEvent, value);
				}
				remove
				{
					ClientConnectionLostEvent = (ClientConnectionLostEventHandler) System.Delegate.Remove(ClientConnectionLostEvent, value);
				}
			}
			
			public delegate void DataReceivedEventHandler(string clientID, byte[] data, int dataLenght);
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
			
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void _waitConnectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					
					if (this._WaitConnectionsFlag)
					{
						_waitConnectionTimer.Stop();
						// Set the event to nonsignaled state.
						waitConnectionSignal.Reset();
						
						// Start an asynchronous socket to listen for connections.
						Console.WriteLine("Waiting for a connection...");
						listener.BeginAccept(new AsyncCallback(AcceptConnectionCallback), listener);
						// Wait until a connection is made and processed before continuing.
						waitConnectionSignal.WaitOne();
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					if (this._WaitConnectionsFlag)
					{
						_waitConnectionTimer.Start();
					}
				}
				
			}
			
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void AcceptConnectionCallback(IAsyncResult ar)
			{
				try
				{
					Socket listener = (Socket) ar.AsyncState;
					Socket handler = listener.EndAccept(ar);
					ConnectionHandlerStateObj state = new ConnectionHandlerStateObj();
					state.workSocket = handler;
					handler.BeginReceive(state.buffer, 0, ConnectionHandlerStateObj.BufferSize, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ReadCallback), state);
					this._handlersList.Add(handler, null, null, null);
					try
					{
						string clientID = handler.RemoteEndPoint.ToString();
						if (ClientConnectionReceivedEvent != null)
							ClientConnectionReceivedEvent(clientID);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception)
				{
				}
				finally
				{
					waitConnectionSignal.Set();
				}
				
			}
			
			private void ReadCallback(IAsyncResult ar)
			{
				string content = string.Empty;
				ConnectionHandlerStateObj state = (ConnectionHandlerStateObj) ar.AsyncState;
				Socket handler = state.workSocket;
				
				try
				{
					int bytesRead = handler.EndReceive(ar);
					
					if (bytesRead > 0)
					{
						try
						{
							string clientID = handler.RemoteEndPoint.ToString();
							if (DataReceivedEvent != null)
								DataReceivedEvent(clientID, state.buffer, bytesRead);
						}
						catch (Exception)
						{
						}
						handler.BeginReceive(state.buffer, 0, ConnectionHandlerStateObj.BufferSize, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ReadCallback), state);
					}
				}
				catch (SocketException)
				{
					try
					{
						string clientID = handler.RemoteEndPoint.ToString();
						if (ClientConnectionLostEvent != null)
							ClientConnectionLostEvent(clientID);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception)
				{
				}
				
			}
			
			private void DisconnectCallback(IAsyncResult ar)
			{
				try
				{
					ConnectionHandlerStateObj state = (ConnectionHandlerStateObj) ar.AsyncState;
					Socket handler = state.workSocket;
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
						try
						{
							this._waitConnectionTimer.Stop();
							this._waitConnectionTimer.Dispose();
							this._WaitConnectionsFlag = false;
							waitConnectionSignal.Close();
							
							IEnumerator enumm = this._handlersList.GetEnumerator();
							Socket sock = default(Socket);
							while (enumm.MoveNext())
							{
								try
								{
									sock = (Socket) enumm.Current;
									sock.Close();
								}
								catch (Exception)
								{
								}
							}
							this._handlersList.Clear();
							try
							{
								listener.Close();
							}
							catch (Exception)
							{
							}
							
							
							
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
