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
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services;
using CommunicationsLibrary.Services.TCPPortsManagement;
using CommunicationsLibrary.Services.BroadCasting.Handling;
using CommunicationsLibrary.Services.BroadCasting.Data;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.DataCompression;



namespace CommunicationsLibrary
{
	namespace Services.BroadCasting
	{
		
		public class DataBroadcastClient : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private enum broadCastMode
			{
				broadCastAndNoWaitReply,
				BroadCastAndWaitOneFirstReply,
				BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall,
				BroadCastAndWaitForSpecifiedNumberOfReplies
			}
			
			private static Hashtable _dataBroadCastersTable;
			
			private string _broadcasterName;
			private string _broadCasterHostName;
			private Socket _broadCastCommunicationsSocket;
			private IPAddress _mcIP;
			private IPEndPoint _sendIPEndPoint;
			private int _ttl = 1; //Time to live
			
			//Variables to stablish a listening port get retrieval from the server
			private TcpListener _ReplyTCPListener;
			private int _ReplyTCPListenerPortNumber;
			private TcpClient _ReplyTCPClient;
			private NetworkStream _replyTCPClientStrem;
			private Services.BroadCasting.Data.BroadCastRepliesContainer _broadCastREpliesReceived;
			private const int DEFAULT_REPLY_TIME_OUT_IN_SECONDS = 10;
			
			private bool _dataRequestResultISAvailable;
			private bool _dataRequestErrorISAvailable;
			private string _waitReplyErrorMsg;
			
			private broadCastMode _broadCastMode;
			
			private int _repliesExpectedToReceiveCount;
			
			private bool _WaitBroadCastReplyFlag;
			
			private Queue _incommingDataTreatmentQueue;
			
#endregion
			
#region  < THREADING SIGNALING  >
			
			static ManualResetEvent WaitDataRequest_AR_Event = new ManualResetEvent(false);
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ReplyReceivedEventHandler();
			private ReplyReceivedEventHandler ReplyReceivedEvent;
			
			public event ReplyReceivedEventHandler ReplyReceived
			{
				add
				{
					ReplyReceivedEvent = (ReplyReceivedEventHandler) System.Delegate.Combine(ReplyReceivedEvent, value);
				}
				remove
				{
					ReplyReceivedEvent = (ReplyReceivedEventHandler) System.Delegate.Remove(ReplyReceivedEvent, value);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
public string Name
			{
				get
				{
					return this._broadcasterName;
				}
			}
			
internal string HostName
			{
				get
				{
					return this._broadCasterHostName;
				}
			}
			
internal int ReplyListeningPort
			{
				get
				{
					return this._ReplyTCPListenerPortNumber;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DataBroadcastClient(string broadCasterName, string broadCastIPAddress, int broadCastPort)
			{
				try
				{
					//sets a mode by default
					this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
					
					this._incommingDataTreatmentQueue = new Queue();
					
					//sets a name to identofy a broadcaster
					this._broadcasterName = broadCasterName;
					
					//Create an IP endpoint class instance
					this._mcIP = IPAddress.Parse(broadCastIPAddress);
					this._sendIPEndPoint = new IPEndPoint(this._mcIP, broadCastPort);
					
					//creates the listening socket
					this._broadCastCommunicationsSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
					//Set the Time to Live
					this._broadCastCommunicationsSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, _ttl);
					
					//creates the reply container
					this._broadCastREpliesReceived = new Services.BroadCasting.Data.BroadCastRepliesContainer();
					
					//creates the listener to catch server responses of the broad cast host server
					this._ReplyTCPListenerPortNumber = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPortOnARange(BroadCastingDefinitions.INITIAL_TCP_PORT_STX_DATABROADCAST_SERVICE, BroadCastingDefinitions.FINAL_TCP_PORT_STX_DATABROADCAST_SERVICE);
					
					string host = System.Net.Dns.GetHostName();
					IPAddress local_IPAddress = System.Net.Dns.GetHostEntry(host).AddressList[1];
					this._ReplyTCPListener = new TcpListener(local_IPAddress, this._ReplyTCPListenerPortNumber);
					
					this._ReplyTCPListener.Start();
					//gets the local host name
					this._broadCasterHostName = Dns.GetHostName();
					
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private dynamic WaitBroadCastListenersReply(int timeOutInSeconds)
			{
				
				try
				{
					this._ReplyTCPListener.Start();
				}
				catch (Exception)
				{
				}
				
				//change the control flag for the reply
				this._broadCastREpliesReceived.Clear();
				
				//waits locally for a while
				int timeOutInMilliSeconds = timeOutInSeconds * 1000;
				
				//********************************************************************
				//statars a new thread to process the incomming data  from listeners
				//this thread only persists meanwhile the client is waiting replies
				this._incommingDataTreatmentQueue.Clear();
				//********************************************************************
				//starts the thread that waits for and the listen methods
				this._WaitBroadCastReplyFlag = false;
				var ReplyTCPListenerThread = new Thread(new System.Threading.ThreadStart(WaitBroadCastReply));
				ReplyTCPListenerThread.IsBackground = true;
				ReplyTCPListenerThread.Priority = ThreadPriority.Normal;
				ReplyTCPListenerThread.Start();
				
				this._dataRequestResultISAvailable = false;
				this._dataRequestErrorISAvailable = false;
				this._repliesExpectedToReceiveCount = 0;
				
				WaitDataRequest_AR_Event.Reset();
				ThreadPool.QueueUserWorkItem(WaitingDataDeliveryResultThredFcn, WaitDataRequest_AR_Event);
				
				//if was specified a timeout mode
				if (WaitDataRequest_AR_Event.WaitOne(timeOutInMilliSeconds, true))
				{
					switch (this._broadCastMode)
					{
						
					case broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies:
						if (this._dataRequestResultISAvailable)
						{
							if (this._broadCastREpliesReceived.Count > 0)
							{
								this._WaitBroadCastReplyFlag = false;
								return this._broadCastREpliesReceived;
							}
							else
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
							}
						}
						else
						{
							if (this._dataRequestErrorISAvailable)
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Exception(this._waitReplyErrorMsg));
							}
							else
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
							}
						}
					case broadCastMode.BroadCastAndWaitOneFirstReply:
						if (this._dataRequestResultISAvailable)
						{
							if (this._broadCastREpliesReceived.Count > 0)
							{
								this._WaitBroadCastReplyFlag = false;
								return this._broadCastREpliesReceived;
							}
							else
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
							}
						}
						else
						{
							if (this._dataRequestErrorISAvailable)
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Exception(this._waitReplyErrorMsg));
							}
							else
							{
								this._WaitBroadCastReplyFlag = false;
								throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
							}
						}
					case broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall:
						if (this._broadCastREpliesReceived.Count > 0)
						{
							this._WaitBroadCastReplyFlag = false;
							return this._broadCastREpliesReceived;
						}
						else
						{
							this._WaitBroadCastReplyFlag = false;
							throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
						}
				}
			}
			else
			{
				switch (this._broadCastMode)
				{
					case broadCastMode.BroadCastAndWaitOneFirstReply:
					case broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies:
					case broadCastMode.broadCastAndNoWaitReply:
					case broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall:
						if (this._broadCastREpliesReceived.Count <= 0)
						{
							this._WaitBroadCastReplyFlag = false;
							throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
						}
						else
						{
							return this._broadCastREpliesReceived;
						}
					default:
						this._WaitBroadCastReplyFlag = false;
						throw (new Services.BroadCasting.DataBroadCastWaitReplyException());
				}
			}
			this._WaitBroadCastReplyFlag = false;
			return null;
		}
		
#endregion
		
#region  < PUBLIC METHODS  >
		
#region  < DATA BROAD CAST METHOD >
		
		private void BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode mode, string broadcastIDName, string dataName, object data)
		{
			//creates a broadcastable data
			BroadcastableData _dataToBroadCast = default(BroadcastableData);
			switch (data.GetType().ToString())
			{
				case "System.String":
					_dataToBroadCast = new BroadcastableData(this, dataName, System.Convert.ToString(data));
					break;
				case "System.Int32":
					_dataToBroadCast = new BroadcastableData(this, dataName, System.Convert.ToInt32(data));
					break;
				case "System.Boolean":
					_dataToBroadCast = new BroadcastableData(this, dataName, System.Convert.ToBoolean(data));
					break;
				case "System.Decimal":
					_dataToBroadCast = new BroadcastableData(this, dataName, System.Convert.ToDecimal(data));
					break;
				case "System.Data.DataTable":
					_dataToBroadCast = new BroadcastableData(this, dataName, (DataTable) data);
					break;
				case "UtilitiesLibrary.Data.CustomHashTable":
					_dataToBroadCast = new BroadcastableData(this, dataName, (CustomHashTable) data);
					break;
				case "UtilitiesLibrary.Data.CustomList":
					_dataToBroadCast = new BroadcastableData(this, dataName, (CustomList) data);
					break;
				case "UtilitiesLibrary.Data.CustomSortedList":
					_dataToBroadCast = new BroadcastableData(this, dataName, (CustomSortedList) data);
					break;
				default:
					throw (new Exception("Unsupported data type " + data.GetType().ToString() + " for data broadcasting service"));
			}
			//crates a handler to be sent
			Services.BroadCasting.Handling.DataBroadCastHandler handler = new Services.BroadCasting.Handling.DataBroadCastHandler(mode, broadcastIDName, _dataToBroadCast);
			
			//transforms the handler from its xml representation into Byte
			byte[] serializedBroadCastHandler = handler.Serialize();
			
			//broadcasts the data
			this._broadCastCommunicationsSocket.SendTo(serializedBroadCastHandler, 0, serializedBroadCastHandler.Length, SocketFlags.None, this._sendIPEndPoint);
			//*******************************************************************
		}
		
#endregion
		
#region  < BROAD CAST WITHOUT WAITING REPLY >
		
		public void BroadCastData(string broadcastIDName, string dataName, string data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, int data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, decimal data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, bool data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, DataTable data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, CustomHashTable data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, CustomList data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
		public void BroadCastData(string broadcastIDName, string dataName, CustomSortedList data)
		{
			this._broadCastMode = broadCastMode.broadCastAndNoWaitReply;
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply, broadcastIDName, dataName, data);
		}
		
#endregion
		
#region  <  BROAD CAST AND WAIT ONE FIRST REPLY WITHUOUT TIME OUT >
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, string data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, int data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, decimal data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, bool data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, DataTable data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomHashTable data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomList data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomSortedList data)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
#endregion
		
#region  <  BROAD CAST AND WAIT ONE FIRST REPLY WITHUOUT TIME OUT >
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, string data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, int data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, decimal data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, bool data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, DataTable data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomHashTable data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomList data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitOneFirstReply(string broadcastIDName, string dataName, CustomSortedList data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitOneFirstReply;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
#endregion
		
		
#region  <  BROAD CAST AND AND WAIT SEVERAL REPLIES WITH TIME OUT   >
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, string data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, int data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, decimal data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, bool data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, DataTable data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, CustomHashTable data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, CustomList data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(string broadcastIDName, string dataName, CustomSortedList data, int timeIntervallInSeconds)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(timeIntervallInSeconds);
		}
		
		
#endregion
		
#region  < BROAD CAST AND WAIT FOR EXPECTED NUMBER OF REPLIES >
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, string data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, int data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, decimal data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, bool data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, DataTable data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, CustomHashTable data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, CustomList data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		public Services.BroadCasting.Data.BroadCastRepliesContainer BroadCastDataAndWaitSpecifiedNumberOfReplies(string broadcastIDName, string dataName, CustomSortedList data, int numberOfExpectedReplies)
		{
			//sets the broad cast mode flag
			this._broadCastMode = broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies;
			this._repliesExpectedToReceiveCount = numberOfExpectedReplies;
			try
			{
				this._ReplyTCPListener.Start();
			}
			catch (Exception)
			{
			}
			//broad cast the data
			this.BroadCastDataToListeners(Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply, broadcastIDName, dataName, data);
			//stablishes a wait task and returns the result data replied back
			return this.WaitBroadCastListenersReply(DEFAULT_REPLY_TIME_OUT_IN_SECONDS);
		}
		
		
#endregion
		
#endregion
		
#region  < THREADING METHODS >
		
		private void IncommingDataTreatment(byte[] DataReceivedBuffer)
		{
			
			if (!(DataReceivedBuffer == null))
			{
				if (DataReceivedBuffer.Length > 0)
				{
					try
					{
						
						BroadCastReply reply = BroadCastReply.Deserialize(DataReceivedBuffer);
						
						if (!(reply == null))
						{
							try
							{
								this._broadCastREpliesReceived.AddReply(reply);
								
								switch (this._broadCastMode)
								{
									case broadCastMode.BroadCastAndWaitOneFirstReply:
										this._dataRequestResultISAvailable = true;
										break;
									case broadCastMode.BroadCastAndWaitForSpecifiedNumberOfReplies:
										if (this._broadCastREpliesReceived.Count >= this._repliesExpectedToReceiveCount)
										{
											this._dataRequestResultISAvailable = true;
										}
										break;
									case broadCastMode.BroadCastAndWaitWaitSeveralRepliesWithinTimeIntervall:
										break;
										//do nothing, just keeps working until the timeout is consumed
								}
							}
							catch (Exception ex)
							{
								string err = "";
								err = "Invalid broad cast reply : " + reply.XMLDataString + " -> " + ex.ToString();
								CustomEventLog.WriteEntry(EventLogEntryType.Error, err);
							}
						}
					}
					catch (Exception ex)
					{
						CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
						switch (this._broadCastMode)
						{
							case broadCastMode.BroadCastAndWaitOneFirstReply:
								this._waitReplyErrorMsg = ex.Message;
								this._dataRequestErrorISAvailable = true;
								return;
						}
						
					}
				}
			}
		}
		
#region  < READING INCOMMING BROADCASTED DATA >
		
		private void WaitBroadCastReply()
		{
			
			byte[] DataReceivedBuffer = new byte[BroadCastingDefinitions.MAX_BROADCAST_BUFFER_SIZE + 1];
			
			this._WaitBroadCastReplyFlag = true;
			
			this._broadCastREpliesReceived.Clear();
			
			while (this._WaitBroadCastReplyFlag)
			{
				try
				{
					this._ReplyTCPClient = this._ReplyTCPListener.AcceptTcpClient();
				}
				catch (Exception)
				{
				}
				
				try
				{
					if (!(this._ReplyTCPClient == null))
					{
						NetworkStream stream = this._ReplyTCPClient.GetStream();
						
						int readedBytes = 0;
						
						//reads from the stream
						readedBytes = stream.Read(DataReceivedBuffer, 0, DataReceivedBuffer.Length);
						
						byte[] newBufferReceived = new byte[readedBytes - 1 + 1];
						
						System.Array.Copy(DataReceivedBuffer, newBufferReceived, readedBytes);
						
						//receives the replay from remote listeners
						this.IncommingDataTreatment(newBufferReceived);
					}
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
		}
		
		private void WaitingDataDeliveryResultThredFcn(object stateInfo)
		{
			while (true)
			{
				if (this._dataRequestResultISAvailable)
				{
					((ManualResetEvent) stateInfo).Set();
					break;
				}
				if (this._dataRequestErrorISAvailable)
				{
					((ManualResetEvent) stateInfo).Set();
					break;
				}
				Thread.Sleep(5);
			}
		}
		
#endregion
		
		
		
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
						this._WaitBroadCastReplyFlag = false;
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._ReplyTCPListener.Stop();
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
