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
using CommunicationsLibrary.Services.TCPPortsManagement;


namespace CommunicationsLibrary
{
	namespace Services.MultiCastDataReplication
	{
		
		internal sealed class DEfinitions
		{
			internal const int MAX_BROADCAST_BUFFER_SIZE = 200000;
		}
		
		
		public class MultiCastDataReplicationServer : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			
			
			private Socket _broadCastCommunicationsSocket;
			private IPAddress _mcIP;
			private IPEndPoint _sendIPEndPoint;
			private int _ttl = 4; //Time to live , defines the reach of a datagram packet, 0 - localhost, 1 = LAN, 2 = Site
			private int _broadCastPortNumber;
			private string _IpAddress;
			
#endregion
			
#region  < PROPERTIES >
			
public string MultiCastIPAddress
			{
				get
				{
					return this._IpAddress;
				}
			}
			
public int MultiCastPortNumber
			{
				get
				{
					return this._broadCastPortNumber;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public MultiCastDataReplicationServer(string MultiCastIPaddress, int multicastPort)
			{
				
				//Create an IP endpoint class instance
				this._IpAddress = MultiCastIPaddress;
				this._mcIP = IPAddress.Parse(this._IpAddress);
				this._broadCastPortNumber = multicastPort;
				this._sendIPEndPoint = new IPEndPoint(this._mcIP, this._broadCastPortNumber);
				
				//creates the listening socket
				this._broadCastCommunicationsSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				//Set the Time to Live
				this._broadCastCommunicationsSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, _ttl);
				
				
			}
			
			public MultiCastDataReplicationServer(int initialTCPPortNumberToFindAFreePort, int finalTCPPortNumberToFindAFreePort)
			{
				//Create an IP endpoint class instance
				this._IpAddress = System.Convert.ToString(MultiCastDataReplication.RandomMulticastIPAddressGenerator.GetInstance().GetRandomMultiCastIPAsString());
				this._mcIP = IPAddress.Parse(this._IpAddress);
				this._broadCastPortNumber = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPortOnARange(initialTCPPortNumberToFindAFreePort, finalTCPPortNumberToFindAFreePort);
				this._sendIPEndPoint = new IPEndPoint(this._mcIP, this._broadCastPortNumber);
				
				//creates the listening socket
				this._broadCastCommunicationsSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				//Set the Time to Live
				this._broadCastCommunicationsSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, _ttl);
				
			}
			
			public MultiCastDataReplicationServer(string MultiCastIPaddress) : this(MultiCastIPaddress, Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPort())
			{
			}
			
			public MultiCastDataReplicationServer() : this(System.Convert.ToString(MultiCastDataReplication.RandomMulticastIPAddressGenerator.GetInstance().GetRandomMultiCastIPAsString()), Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPort())
			{
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void BroadCastData(string dataToBroadCast)
			{
				try
				{
					byte[] dataToReplicate = null;
					dataToReplicate = System.Text.Encoding.ASCII.GetBytes(dataToBroadCast);
					this._broadCastCommunicationsSocket.SendTo(dataToReplicate, 0, dataToReplicate.Length, SocketFlags.None, this._sendIPEndPoint);
				}
				catch (Exception ex)
				{
					string msg = "Error Broadcasting Data : " + ex.ToString();
					throw (new Exception(msg));
				}
			}
			
			public void BroadCastData(byte[] dataToBroadcast)
			{
				try
				{
					this._broadCastCommunicationsSocket.SendTo(dataToBroadcast, 0, dataToBroadcast.Length, SocketFlags.None, this._sendIPEndPoint);
				}
				catch (Exception ex)
				{
					string msg = "Error Broadcasting Data : " + ex.ToString();
					throw (new Exception(msg));
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
							this._broadCastCommunicationsSocket.Disconnect(false);
							this._broadCastCommunicationsSocket.Close();
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
