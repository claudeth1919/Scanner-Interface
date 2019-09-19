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
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsLibrary.Services.BroadCasting.Handling;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.DataCompression;




namespace CommunicationsLibrary
{
	namespace Services.BroadCasting
	{
		
		public class DataBroadcastListener : IDisposable
		{
			
#region  < SPECIAL CLASS INFORMATION >
			
#endregion
			
#region  < DATA MEMBERS >
			
			private static DataBroadcastListener _DataBroadCastHostServer;
			
			private Socket _BroadCastlisteningSocket;
			private IPAddress _mcIP;
			private IPEndPoint _receivePoint;
			
			private string _broadCastIPAddress;
			private int _broadCastPort;
			
			private byte[] _ReceiveDataBuffer = new byte[BroadCastingDefinitions.MAX_BROADCAST_BUFFER_SIZE + 1];
			
			
#endregion
			
#region  < EVENTS >
			
			public delegate void DataReceivedEventHandler(Services.BroadCasting.Handling.DataBroadCastHandler data);
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
			
#region  < CONSTRUCTODS >
			
			public DataBroadcastListener(string BroadCastIPAddress, int broadCastPort)
			{
				//creates the listening socket
				this._BroadCastlisteningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				// Set the reuse address option
				this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
				
				//Create an IPEndPoint and bind to it
				IPEndPoint ipep = new IPEndPoint(IPAddress.Any, broadCastPort);
				this._BroadCastlisteningSocket.Bind(ipep);
				
				//Add membership in the multicast group
				this._mcIP = IPAddress.Parse(BroadCastIPAddress);
				this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(this._mcIP, IPAddress.Any));
				
				//reate the EndPoint class
				this._receivePoint = new IPEndPoint(IPAddress.Any, broadCastPort);
				EndPoint tempReceivePoint = (EndPoint) this._receivePoint;
				
				
				this._BroadCastlisteningSocket.BeginReceive(_ReceiveDataBuffer, 0, _ReceiveDataBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), null);
				
				
			}
			
#endregion
			
			
#region  < PRIVATE MEMBERS >
			
			public void ClientDataReceptionCallback(IAsyncResult ar)
			{
				
				try
				{
					int bytesRead = 0;
					
					// Read data from the client socket.
					try
					{
						bytesRead = this._BroadCastlisteningSocket.EndReceive(ar);
					}
					catch (Exception)
					{
					}
					
					if (bytesRead > 0)
					{
						
						byte[] RealBuffer = new byte[bytesRead - 1 + 1];
						
						System.Array.Copy(this._ReceiveDataBuffer, RealBuffer, bytesRead);
						
						if (!(RealBuffer == null))
						{
							
							Services.BroadCasting.Handling.DataBroadCastHandler receivedBroadCastHandler = Services.BroadCasting.Handling.DataBroadCastHandler.Deserialize(RealBuffer);
							
							try
							{
								if (DataReceivedEvent != null)
									DataReceivedEvent(receivedBroadCastHandler);
							}
							catch (Exception)
							{
							}
							
						}
						
						System.Array.Clear(this._ReceiveDataBuffer, 0, this._ReceiveDataBuffer.Length);
						
						this._BroadCastlisteningSocket.BeginReceive(this._ReceiveDataBuffer, 0, this._ReceiveDataBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), null);
						
					}
					
				}
				catch (SocketException ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
#endregion
			
#region  < Interface Implementation >
			
			
			
#region  IDisposable
			
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
							//closes the listening port
							this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(this._mcIP, IPAddress.Any));
							this._BroadCastlisteningSocket.Close();
						}
						catch (Exception)
						{
							
						}
						
						try
						{
							_DataBroadCastHostServer = null;
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
