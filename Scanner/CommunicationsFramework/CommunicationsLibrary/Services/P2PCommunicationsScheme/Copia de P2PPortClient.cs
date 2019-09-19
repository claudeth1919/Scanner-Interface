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
using System.IO;
using System.Threading;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Statistics;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme
	{
		
		public class P2PPortClient : IDisposable
		{
			
#region  < CLASS INFORMATION >
			
#endregion
			
#region  < DATA MEMBERS >

            /// <summary>
            /// defines the connection type client : if it sill be used the host name or an IPAddress to buil TCP connection
            /// </summary>
            private enum ConnectionModeType
            {
                useHostName ,
                useIPAddress ,
                unknown
            }

			//variable that blocks the operation of the port to allow only an operation anytime
			//for send and retrieve data
			private string _socketPortBlockingFlag = "VARIABLE_TO_BLOCK_SOCKET_PORT";
			
			private Stream _socketStream;
			private TcpClient _tcpClient;
			private IPEndPoint _remoteEndPoint;
			private int _remotePortNumber;
			private string _remoteHostName;
            private IPAddress _IPAddress; 
			private Services.P2PCommunicationsScheme.Statistics.P2PPortClientStatisticsHandler _P2PPortStatisticsHandler;
			
			
			//control variables
			private bool _manualDisconnection = false;
			private bool _connectionWithRemotePortLost;
			private bool _unexpectedErrorOcurred;
			private string _unexpectedErrorMEssage;
			
			//data request control flags
			private bool _dataRetrievedIsAvailable;
			private bool _dataRetrievalErrorIsAvailable;
			//data delivery control flags
			private bool _dataDEliveryResultISAvailable;
			
			private string _portClientName;
			
			private P2PData _P2PDataRetrievedFromRemotePort;
			private Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult _P2PDataDeliveryResultReceivedFromRemotePort;
			private P2PDataRequestFailure _P2PDataRequestFailureReceived;
			
			private byte[] _ReceiveDataBuffer = new byte[P2PNetworkingDefinitions.DATABUFFER_SIZE + 1];

            private ConnectionModeType _connectionModeType;
			
#region  < THREADING SIGNALING  >
			
			static ManualResetEvent WaitDataRequest_AR_Event = new ManualResetEvent(false);
			static ManualResetEvent WaitDataDeliveryResult_AR_Event = new ManualResetEvent(false);
			
#endregion
			
#endregion
			
#region  <  PROPERTIES >
			
public string ClientID
			{
				get
				{
					if (!(this._tcpClient == null))
					{
						return this._tcpClient.Client.LocalEndPoint.ToString();
					}
					else
					{
						string ID = Guid.NewGuid().ToString().ToUpper();
						return ID;
					}
				}
			}
			
public string RemoteHostName
			{
				get
				{
					return this._remoteHostName;
				}
			}
			
public int RemotePortNumber
			{
				get
				{
					return this._remotePortNumber;
				}
			}
			
public int LocalEndPointPortNumber
			{
				get
				{
					IPEndPoint endp = (IPEndPoint) this._tcpClient.Client.LocalEndPoint;
					return endp.Port;
				}
			}
			
public Services.P2PCommunicationsScheme.Statistics.P2PPortClientStatisticsHandler Statistics
			{
				get
				{
					return this._P2PPortStatisticsHandler;
				}
			}
			
public string ClientName
			{
				get
				{
					return this._portClientName;
				}
			}
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ConnectionLostEventHandler(P2PPortClient client);
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
			
			public delegate void ConnectionClosedEventHandler(P2PPortClient client);
			private ConnectionClosedEventHandler ConnectionClosedEvent;
			
			public event ConnectionClosedEventHandler ConnectionClosed
			{
				add
				{
					ConnectionClosedEvent = (ConnectionClosedEventHandler) System.Delegate.Combine(ConnectionClosedEvent, value);
				}
				remove
				{
					ConnectionClosedEvent = (ConnectionClosedEventHandler) System.Delegate.Remove(ConnectionClosedEvent, value);
				}
			}
			
			public delegate void SuccesfullyDataSentEventHandler(P2PData data);
			private SuccesfullyDataSentEventHandler SuccesfullyDataSentEvent;
			
			public event SuccesfullyDataSentEventHandler SuccesfullyDataSent
			{
				add
				{
					SuccesfullyDataSentEvent = (SuccesfullyDataSentEventHandler) System.Delegate.Combine(SuccesfullyDataSentEvent, value);
				}
				remove
				{
					SuccesfullyDataSentEvent = (SuccesfullyDataSentEventHandler) System.Delegate.Remove(SuccesfullyDataSentEvent, value);
				}
			}
			
			public delegate void DataSendErrorEventHandler(P2PData data, Exception ex);
			private DataSendErrorEventHandler DataSendErrorEvent;
			
			public event DataSendErrorEventHandler DataSendError
			{
				add
				{
					DataSendErrorEvent = (DataSendErrorEventHandler) System.Delegate.Combine(DataSendErrorEvent, value);
				}
				remove
				{
					DataSendErrorEvent = (DataSendErrorEventHandler) System.Delegate.Remove(DataSendErrorEvent, value);
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public P2PPortClient(string hostName, int portNumber) 
                : this (hostName, null, portNumber , null)
			{           }

            public P2PPortClient(string hostIPAddress, int portNumber, string ClientName)
                : this(null, hostIPAddress, portNumber, ClientName)
            {            }

            public P2PPortClient(string hostName, string hostIPAddress, int portNumber)
                : this(hostName, hostIPAddress, portNumber,null)
            {            }



            public P2PPortClient(string hostName, string IPAddress, int portNumber, string ClientName)
            {
                this._connectionModeType = ConnectionModeType.unknown;
                //------------------------------
                // host name definition
                if ((hostName != null)  && ( hostName.Length > 0 ))
                {                   
                    this._remoteHostName = hostName;
                    this._connectionModeType = ConnectionModeType.useHostName;
                }              
                //------------------------------
                // IP ADDRESS definition
                if ((IPAddress != null) && (IPAddress.Length > 0))
                {
                    try
                    {
                        this._IPAddress = System.Net.IPAddress.Parse(IPAddress);
                        this._connectionModeType = ConnectionModeType.useIPAddress;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Invalid IP address specified '" + IPAddress + "'");
                    }
                }
              
                if (this._connectionModeType == ConnectionModeType.unknown) 
                {
                    throw new Exception("Not enough or invalid host name or IPaddress parameters specified for the P2P connection");
                }
                
                //------------------------------

                this._remotePortNumber = portNumber;

                if ((ClientName != null) && (ClientName.Length > 0))
                {
                    this._portClientName = ClientName;
                }
                else
                {
                    this._portClientName = Guid.NewGuid().ToString().ToUpper();
                }
                this._P2PPortStatisticsHandler = new Services.P2PCommunicationsScheme.Statistics.P2PPortClientStatisticsHandler();
                this._manualDisconnection = false;
            }
         

            		
			
#endregion
			
#region  <  THREADING >
			
#region  < SOCKET HANDLING FOR DATA RECEPTION AND DELIVERY RESULT >
			
			
			private void ReadSocket(IAsyncResult ar)
			{
				
				var receivedData = new byte[P2PNetworkingDefinitions.DATABUFFER_SIZE+ 1];
				int bytesRead = 0;
				this._connectionWithRemotePortLost = false;
				this._unexpectedErrorOcurred = false;
				this._unexpectedErrorMEssage = "";
				
				try
				{
					
					try
					{
						bytesRead = this._socketStream.EndRead(ar);
					}
					catch (Exception)
					{
					}
					
					
					if (bytesRead > 0)
					{
						
						byte[] ReaDatalBufferReceived = new byte[bytesRead - 1 + 1];
						
						System.Array.Copy(this._ReceiveDataBuffer, ReaDatalBufferReceived, bytesRead);
						System.Array.Clear(this._ReceiveDataBuffer, 0, this._ReceiveDataBuffer.Length);
						
						if (!(ReaDatalBufferReceived == null))
						{
							
							
							try
							{
								//*****************************************
								//tries to deserialize to a P2PDATA
								//*****************************************
								this._P2PDataRetrievedFromRemotePort = P2PData.Deserialize(ReaDatalBufferReceived);
								this._dataRetrievedIsAvailable = true;
								
							}
							catch (Exception)
							{
								try
								{
									//*****************************************
									//tries to deserialize to a P2P_DATA_DELIVERY_RESULT
									//*****************************************
									this._P2PDataDeliveryResultReceivedFromRemotePort = Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.Deserialize(ReaDatalBufferReceived);
									this._dataDEliveryResultISAvailable = true;
								}
								catch (Exception)
								{
									try
									{
										//*****************************************
										//tries to deserialize to a P2P_DATA_REQUEST_FAILURE
										//*****************************************
										this._P2PDataRequestFailureReceived = P2PDataRequestFailure.Deserialize(ReaDatalBufferReceived);
										this._dataRetrievalErrorIsAvailable = true;
									}
									catch (Exception)
									{
										this._unexpectedErrorMEssage = "Invalid Data received in P2PPortClient";
										this._unexpectedErrorOcurred = true;
									}
									
								}
								
							}
							
						}
						
						this._socketStream.BeginRead(_ReceiveDataBuffer, 0, _ReceiveDataBuffer.Length, new AsyncCallback(ReadSocket), null);
						
					}
					else
					{
						//and error has ocurred and the remote port has broken its
						//link but is not catched by the environment, but can be determined
						//becuase the read operation proceeds with no data available
						if (this._manualDisconnection == false)
						{
							this._unexpectedErrorOcurred = true;
							this._unexpectedErrorMEssage = "An unexpected error ocurred in the connection when client was waiting a response from remote port.";
							try
							{
								this._tcpClient.Client.Close();
							}
							catch (Exception)
							{
							}
							try
							{
								if (ConnectionLostEvent != null)
									ConnectionLostEvent(this);
							}
							catch (Exception)
							{
							}
						}
					}
				}
				catch (IOException)
				{
					try
					{
						this._connectionWithRemotePortLost = true;
						this._tcpClient.Client.Close();
					}
					catch (Exception)
					{
					}
					try
					{
						if (ConnectionLostEvent != null)
							ConnectionLostEvent(this);
					}
					catch (Exception)
					{
					}
				}
				catch (Exception ex)
				{
					this._unexpectedErrorMEssage = ex.Message;
					this._unexpectedErrorOcurred = true;
					try
					{
						if (ConnectionLostEvent != null)
							ConnectionLostEvent(this);
					}
					catch (Exception)
					{
					}
				}
			}
			
			private void WaitingRequestResponseThredFcn(object stateInfo)
			{
				this._dataRetrievedIsAvailable = false;
				this._dataRetrievalErrorIsAvailable = false;
				this._unexpectedErrorOcurred = false;
				
				while (true)
				{
					if (this._dataRetrievedIsAvailable)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					if (this._dataRetrievalErrorIsAvailable)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					if (this._connectionWithRemotePortLost)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					if (this._unexpectedErrorOcurred)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					Thread.Sleep(5);
				}
			}
			
			private void WaitingDataDeliveryResultThredFcn(object stateInfo)
			{
				this._dataDEliveryResultISAvailable = false;
				this._unexpectedErrorOcurred = false;
				
				while (true)
				{
					
					if (this._dataDEliveryResultISAvailable)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					if (this._connectionWithRemotePortLost)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					if (this._unexpectedErrorOcurred)
					{
						((ManualResetEvent) stateInfo).Set();
						break;
					}
					Thread.Sleep(5);
				}
			}
			
#endregion
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void SendDataInSynchronicalMode(P2PData data)
			{
				string errMsg = "";
				bool throwException = false;
				
				if (!(this._tcpClient == null))
				{
					
					int OPERATION_TIME_OUT_IN_MS = P2PNetworkingDefinitions.READ_TIME_OUT_SECONDS * 1000;
					
					lock(this._socketPortBlockingFlag)
					{
						
						this._dataDEliveryResultISAvailable = false;
						
						byte[] dataByteBuffer = data.Serialize();
						
						if (dataByteBuffer.Length > P2PNetworkingDefinitions.DATABUFFER_SIZE)
						{
							throwException = true;
							errMsg = "The size of the data exceeds the maximun limit of " + System.Convert.ToString(P2PNetworkingDefinitions.DATABUFFER_SIZE) + " for the P2P port";
						}
						else
						{
							if (!(this._socketStream == null))
							{
								try
								{
									//************************************************************************
									this._socketStream.Write(dataByteBuffer, 0, dataByteBuffer.Length);
									
									this.Statistics.LogDataSendEvent(data);
									WaitDataDeliveryResult_AR_Event.Reset();
									
									ThreadPool.QueueUserWorkItem(WaitingDataDeliveryResultThredFcn, WaitDataDeliveryResult_AR_Event);
									
									if (WaitDataDeliveryResult_AR_Event.WaitOne(OPERATION_TIME_OUT_IN_MS, true))
									{
										//the working method activated the signal so a data is available
										if (this._dataDEliveryResultISAvailable)
										{
											if (this._P2PDataDeliveryResultReceivedFromRemotePort.ResultType == Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.DeliveryResultType.DeliveryFailure)
											{
												errMsg = this._P2PDataDeliveryResultReceivedFromRemotePort.ResultMessage;
												throwException = true;
											}
										}
									}
								}
								catch (Exception ex)
								{
									throwException = true;
									errMsg = ex.Message;
								}
							}
							else
							{
								throwException = true;
								errMsg = "The socket stream is not available";
							}
						}
					}
					if (throwException)
					{
						throw (new Exception(errMsg));
					}
				}
				else
				{
					throw (new Exception("The client is not connected to the remote port specified as [" + this._remoteHostName + " : " + System.Convert.ToString(this._remotePortNumber) + "]"));
				}
			}
			
			private void SendDataInAsynchronicalMode(P2PData data)
			{
				//this method send data to the P2PPort without waiting a callback or a result from the remote port
				bool throwError = false;
				string errMsg = "";
				
				if (!(this._tcpClient == null))
				{
					
					lock(this._socketPortBlockingFlag)
					{
						
						this._dataDEliveryResultISAvailable = false;
						byte[] dataByteBuffer = data.Serialize();
						
						if (dataByteBuffer.Length > P2PNetworkingDefinitions.DATABUFFER_SIZE)
						{
							throwError = true;
							errMsg = "The size of the data exceeds the maximun limit of " + System.Convert.ToString(P2PNetworkingDefinitions.DATABUFFER_SIZE) + " for the P2P port";
						}
						else
						{
							if (!(this._socketStream == null))
							{
								try
								{
									this._socketStream.Write(dataByteBuffer, 0, dataByteBuffer.Length);
									
									this.Statistics.LogDataSendEvent(data);
								}
								catch (Exception ex)
								{
									throwError = true;
									errMsg = ex.Message;
								}
							}
							else
							{
								throwError = true;
								errMsg = "The socket stream is not available";
							}
						}
					}
					if (throwError)
					{
						throw (new Exception(errMsg));
					}
				}
				else
				{
					throw (new Exception("The client is not connected to the remote port specified as [" + this._remoteHostName + " : " + System.Convert.ToString(this._remotePortNumber) + "]"));
				}
			}
			
#endregion
			
#region  < PUBLIC MEHTODS  >
			
			public void Connect()
			{
				this._tcpClient = new TcpClient();
                //stablishment of the communications based in the connection type 
                switch(this._connectionModeType)
                {
                    case    ConnectionModeType.useHostName :
                            this._tcpClient.Connect(this._remoteHostName, this.RemotePortNumber);
                            break;

                    case    ConnectionModeType.useIPAddress :
                            this._tcpClient.Connect(this._IPAddress, this.RemotePortNumber);
                            break;
                }

               
				this._socketStream = this._tcpClient.GetStream();
				
				//initiates the asynchronical stream read
				this._socketStream.BeginRead(_ReceiveDataBuffer, 0, _ReceiveDataBuffer.Length, new AsyncCallback(ReadSocket), null);
				this._connectionWithRemotePortLost = false;
				this._manualDisconnection = false;
			}
			
			public void Disconnect()
			{
				this._manualDisconnection = true;
				try
				{
					this._socketStream.Close();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._socketStream.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._tcpClient.Client.Disconnect(false);
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._tcpClient.Client.Close();
				}
				catch (Exception)
				{
				}
				
				try
				{
					if (ConnectionClosedEvent != null)
						ConnectionClosedEvent(this);
				}
				catch (Exception)
				{
				}
			}
			
			
#region  < DATASEND >
			
			public void SendData(P2PDataSendMode mode, P2PData data)
			{
				switch (mode)
				{
					case P2PDataSendMode.SyncrhonicalSend:
						//sends data to the remote port and waits intil the remote port returns a operation
						//result
						try
						{
							this.SendDataInSynchronicalMode(data);
						}
						catch (Exception ex)
						{
							throw (ex);
						}
						try
						{
							if (SuccesfullyDataSentEvent != null)
								SuccesfullyDataSentEvent(data);
						}
						catch (Exception)
						{
						}
						break;
					case P2PDataSendMode.AsynchronycalSend:
						//this method send data to the P2PPort without waiting a callback or a result from the remote port
						this.SendDataInAsynchronicalMode(data);
						try
						{
							if (SuccesfullyDataSentEvent != null)
								SuccesfullyDataSentEvent(data);
						}
						catch (Exception)
						{
						}
						break;
				}
				
			}
			
#endregion
			
#region  < DATA RETRIEVAL >
			
			private P2PData RetrieveData(P2PDataRequest request, int timeOutInSeconds)
			{
				
				bool dataRetrieved = false;
				
				byte[] bufferToBeSend = null;
				Exception exception = null;
				
				int OPERATION_TIME_OUT_IN_MS = timeOutInSeconds * 1000;
				
				
				bufferToBeSend = request.Serialize();
				
				lock(this._socketPortBlockingFlag)
				{
					try
					{
						if (!(this._socketStream == null))
						{
							//initialization of control flags
							this._dataRetrievedIsAvailable = false;
							this._dataRetrievalErrorIsAvailable = false;
							this._unexpectedErrorOcurred = false;
							
							//sends the data request using the socket stream
							try
							{
								//*********************************************************************************
								this._socketStream.Write(bufferToBeSend, 0, bufferToBeSend.Length);
								
								//*********************************************************************************
								//crates a signaled thread thar waits until the controls flags changes because a data or error is received
								//in the read socket thread
								WaitDataRequest_AR_Event.Reset();
								ThreadPool.QueueUserWorkItem(WaitingRequestResponseThredFcn, WaitDataRequest_AR_Event);
								
								if (WaitDataRequest_AR_Event.WaitOne(OPERATION_TIME_OUT_IN_MS, true))
								{
									
									//the working method activated the signal so an event is availabel according with the
									//activated control flags
									if (this._dataRetrievedIsAvailable)
									{
										this.Statistics.LogSuccesfulDataRequestEvent(request);
										dataRetrieved = true;
										
									}
									else if (this._dataRetrievalErrorIsAvailable)
									{
										this.Statistics.LogFailedDataRequestEvent(request);
										exception = new P2PDataRetrievalException(request, this._P2PDataRequestFailureReceived.ErrorMessage);
										
									}
									else if (this._connectionWithRemotePortLost)
									{
										this.Statistics.LogFailedDataRequestEvent(request);
										exception = new P2PPortConnectionException();
										
									}
									else if (this._unexpectedErrorOcurred)
									{
										this.Statistics.LogFailedDataRequestEvent(request);
										if (!(this._unexpectedErrorMEssage == null))
										{
											if (this._unexpectedErrorMEssage.Length > 0)
											{
												exception = new P2PDataRetrievalUnexpectedException(request, this._unexpectedErrorMEssage);
											}
											else
											{
												exception = new P2PDataRetrievalUnexpectedException(request);
											}
										}
										else
										{
											exception = new P2PDataRetrievalUnexpectedException(request);
										}
									}
								}
								else
								{
									//timeout waiting for the response
									this.Statistics.LogFailedDataRequestEvent(request);
									exception = new P2PDataRequestTimeOutException(request);
								}
							}
							catch (Exception ex)
							{
								throw (ex);
							}
						}
						else
						{
							exception = new Exception("Socket stream invalid of not available.");
						}
					}
					catch (Exception ex)
					{
						exception = ex;
					}
				}
				
				if (!(exception == null))
				{
					throw (exception);
				}
				else
				{
					if (dataRetrieved)
					{
						return this._P2PDataRetrievedFromRemotePort;
					}
					else
					{
						return null;
					}
				}
			}
			
			public P2PData RetrieveData(P2PDataRequest request)
			{
				return this.RetrieveData(request, P2PNetworkingDefinitions.READ_TIME_OUT_SECONDS);
			}
			
#endregion
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < iDisposable >
			
			
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
							this.Disconnect();
						}
						catch (Exception)
						{
						}					
					}
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
