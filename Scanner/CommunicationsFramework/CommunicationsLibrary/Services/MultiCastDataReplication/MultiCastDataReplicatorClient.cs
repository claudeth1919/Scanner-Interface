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
using System.IO.Compression;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services;


namespace CommunicationsLibrary
{
	namespace Services.MultiCastDataReplication
	{
		
		public class MultiCastDataReplicatorClient : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			
			private Socket _BroadCastlisteningSocket;
			private int _broadCastPortNumber;
			private string _broadCastIPAddressAsString;
			private IPAddress _mcIP;
			private IPEndPoint _receivePoint;
			
			private byte[] _ReceiveDataBuffer = new byte[DEfinitions.MAX_BROADCAST_BUFFER_SIZE + 1];
			
			private Queue _DataReceivedTreatmentAndHandlingQueue;
			private bool _DataReceivedTreatmentAndHandling;
			private System.Timers.Timer _DataReceivedTreatmentAndHandlingTimer;
			
#endregion
			
#region  < EVENTS >
			
			public delegate void MultiCastDataReceivedEventHandler(byte[] data);
			private MultiCastDataReceivedEventHandler MultiCastDataReceivedEvent;
			
			public event MultiCastDataReceivedEventHandler MultiCastDataReceived
			{
				add
				{
					MultiCastDataReceivedEvent = (MultiCastDataReceivedEventHandler) System.Delegate.Combine(MultiCastDataReceivedEvent, value);
				}
				remove
				{
					MultiCastDataReceivedEvent = (MultiCastDataReceivedEventHandler) System.Delegate.Remove(MultiCastDataReceivedEvent, value);
				}
			}
			
			
#endregion
			
#region  < COSNTRUCTORS >
			
			public MultiCastDataReplicatorClient(string broadCastIP, int broadCastPortNumber)
			{
				//creates the listening socket
				this._BroadCastlisteningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				// Set the reuse address option
				this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
				
				this._broadCastPortNumber = broadCastPortNumber;
				this._broadCastIPAddressAsString = broadCastIP;
				
				this._DataReceivedTreatmentAndHandling = true;
				this._DataReceivedTreatmentAndHandlingQueue = new Queue();
				this._DataReceivedTreatmentAndHandlingTimer = new System.Timers.Timer(1);
				this._DataReceivedTreatmentAndHandlingTimer.Elapsed += this.EventHandling_DataReceivedTreatmentAndHandlingTimer_Elapsed;
				this._DataReceivedTreatmentAndHandlingTimer.AutoReset = false;
				this._DataReceivedTreatmentAndHandlingTimer.Start();
				
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
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
						
						
						if (this._DataReceivedTreatmentAndHandling)
						{
							try
							{
								lock(this._DataReceivedTreatmentAndHandlingQueue)
								{
									this._DataReceivedTreatmentAndHandlingQueue.Enqueue(RealBuffer);
								}
								
								this._DataReceivedTreatmentAndHandlingTimer.Start();
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
			
			private void EventHandling_DataReceivedTreatmentAndHandlingTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					int count = this._DataReceivedTreatmentAndHandlingQueue.Count;
					int iterationsCount = count;
					
					if (count > 0)
					{
						byte[] RealBuffer = null;
						
						while (count > 0)
						{
							
							RealBuffer = null;
							try
							{
								lock(this._DataReceivedTreatmentAndHandlingQueue)
								{
                                    RealBuffer = (byte[])this._DataReceivedTreatmentAndHandlingQueue.Dequeue();
								}
							}
							catch (Exception)
							{
								RealBuffer = null;
							}
							
							if (!(RealBuffer == null))
							{
								try
								{
									if (MultiCastDataReceivedEvent != null)
										MultiCastDataReceivedEvent(RealBuffer);
								}
								catch (Exception)
								{
								}
							}
							count--;
							
							//to avoid locks on CPU when while will iterate more than once
							if (iterationsCount > 1)
							{
								Thread.Sleep(1);
							}
							
						}
						
					}
				}
				catch (Exception)
				{
					
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void Connect()
			{
				//Create an IPEndPoint and bind to it
				IPEndPoint ipep = new IPEndPoint(IPAddress.Any, this._broadCastPortNumber);
				this._BroadCastlisteningSocket.Bind(ipep);
				
				//Add membership in the multicast group
				this._mcIP = IPAddress.Parse(this._broadCastIPAddressAsString);
				this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(this._mcIP, IPAddress.Any));
				
				//reate the EndPoint class
				this._receivePoint = new IPEndPoint(IPAddress.Any, 0);
				EndPoint tempReceivePoint = (EndPoint) this._receivePoint;
				
				//starts the asynchronical data reception from server
				this._BroadCastlisteningSocket.BeginReceive(_ReceiveDataBuffer, 0, _ReceiveDataBuffer.Length, (System.Net.Sockets.SocketFlags) 0, new AsyncCallback(ClientDataReceptionCallback), null);
				
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						
						this._DataReceivedTreatmentAndHandling = false;
						
						try
						{
							this._DataReceivedTreatmentAndHandlingTimer.Dispose();
						}
						catch (Exception)
						{
						}
						
						
						try
						{
							//closes the listening port
							this._BroadCastlisteningSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(this._mcIP, IPAddress.Any));
							this._BroadCastlisteningSocket.Close();
							this._BroadCastlisteningSocket.Disconnect(false);
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
			
			
			
		}
		
		
	}
	
}
