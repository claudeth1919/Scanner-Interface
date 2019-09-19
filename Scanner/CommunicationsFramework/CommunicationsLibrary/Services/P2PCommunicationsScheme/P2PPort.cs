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
using CommunicationsLibrary.Services.TCPPortsManagement;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Statistics;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.Queueing;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme
	{
		
		public class P2PPort_original : IDisposable
		{
			
#region  < CLASS INFORMATION >
			
#endregion
			
#region  < DATA MEMBERS >


         

             // We use a Mutex to block the listener thread so that limited client connections are active
            // on the server.  If you stop the server, the mutex is released. 
            private static Mutex _mutex;

            // Here is where we track the totalbytes read by the server
            protected int totalbytesread;

            // Here is our stack of available accept sockets
            private  P2PAsyncEventStack _socketPool;

            //control flag 
            protected bool exceptionthrown;

            protected Socket _connectionsocket;
            protected IPEndPoint _connectionendpoint;

            private Hashtable _ConnectedClientsTable;

            private int _listeningPort;
            private IPAddress _IPAddress;
            private object _portOwnerComponent;
            private P2PPortStatisticsHandler _statisticsHandler;
            private DateTime _startDateTime;

            private TimedProducerConsumerQueue _incommingDataProcessingQueue;


#endregion
			
#region  < CONSTRUCTORS AND OBJECT INITIALIZATION >
			
			
			public P2PPort_original(object portOwner, int listeningPort)
			{
				if (!(portOwner is IUseP2PCommunicationsScheme))
				{
					throw (new Exception("The port owner object must implement the interface \'IUseP2PCommunicationsScheme\'"));
				}
				this.P2PPortCreation(portOwner, listeningPort);
			}
			
			public P2PPort_original(object portOwner, int initialTCPPortNumberToFindAFreePort, int finalTCPPortNumberToFindAFreePort)
			{
				if (!(portOwner is IUseP2PCommunicationsScheme))
				{
					throw (new Exception("The port owner object must implement the interface \'IUseP2PCommunicationsScheme\'"));
				}
				int listeningPort = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPortOnARange(initialTCPPortNumberToFindAFreePort, finalTCPPortNumberToFindAFreePort);
				this.P2PPortCreation(portOwner, listeningPort);
			}

            public P2PPort_original(object portOwner)
			{
				if (!(portOwner is IUseP2PCommunicationsScheme))
				{
					throw (new Exception("The port owner object must implement the interface \'IUseP2PCommunicationsScheme\'"));
				}
				int listeningPort = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPort();
				this.P2PPortCreation(portOwner, listeningPort);
			}
					
			
#endregion
			
#region  < EVENTS >
			
			public delegate void NewClientConnectionEventHandler(string ClientID);
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
			
			public delegate void ClientDisconnectionEventHandler(string ClientID);
			private ClientDisconnectionEventHandler ClientDisconnectionEvent;			
			public event ClientDisconnectionEventHandler ClientDisconnection
			{
				add
				{
					ClientDisconnectionEvent = (ClientDisconnectionEventHandler) System.Delegate.Combine(ClientDisconnectionEvent, value);
				}
				remove
				{
					ClientDisconnectionEvent = (ClientDisconnectionEventHandler) System.Delegate.Remove(ClientDisconnectionEvent, value);
				}
			}
			
			
			
#endregion

 #region < EVENT HANDLING > 


                // This method is called when there is no more data to read from a connected client
                private void OnIOCompleted(object sender, SocketAsyncEventArgs e)
                {
                    // Determine which type of operation just completed and call the associated handler.
                    // We are only processing receives right now on this server.
                    if (e.LastOperation == SocketAsyncOperation.Receive)
                        this.ProcessReceive(e);

                }

                // This method is triggered when the accept socket completes an operation async
                // In the case of our accept socket, we are looking for a client connection to complete
                private void OnAcceptCompleted(object sender, SocketAsyncEventArgs AsyncEventArgs)
                {
                    ProcessAccept(AsyncEventArgs);
                }

                private void _incommingDataProcessingQueue_NewItemDetected(object Item)
                {
                    try
                    {
                        if (Item != null)
                        {
                            P2PPortClientHandler clientHandler = (P2PPortClientHandler)Item;

                            ProcessReceivedData(clientHandler);
                        }
                    }
                    catch
                    {

                    }

                }

 #endregion 

#region  < PROPERTIES  >

    public int ListeningPortNumber
	{
		get
		{
			return this._listeningPort;
		}
	}

    public IPAddress  IPAddress
    {
        get
        {
            return this._IPAddress;
        }
    }

    public DateTime StartDateTime
	{
		get
		{
			return this._startDateTime;
		}
	}
					
    public int NoOfConnectedP2PClients
	{
		get
		{
            return this._ConnectedClientsTable.Count;
		}
	}
			
    public P2PPortStatisticsHandler Statistics
			{
				get
				{
					return this._statisticsHandler;
				}
			}
			
#endregion
			
#region  < ASYNCHRONIC CALLS >

            public void StartAcceptAsync(SocketAsyncEventArgs acceptEventArg)
            {
                // If there is not an accept socket, create it
                // If there is, reuse it
                if (acceptEventArg == null)
                {
                    acceptEventArg = new SocketAsyncEventArgs();
                    acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(OnAcceptCompleted);
                }
                else
                {
                    acceptEventArg.AcceptSocket = null;
                }

                // this will return true if there is a connection
                // waiting to be processed (IO Pending) 
                bool acceptpending = this._connectionsocket.AcceptAsync(acceptEventArg);

                // If not, we can go ahead and process the accept.
                // Otherwise, the Completed event we tacked onto the accept socket will do it when it completes
                if (!acceptpending)
                {
                    // Process the accept event A client has connected to the port 
                    ProcessAccept(acceptEventArg);

                }
            }

            // This method is used to process the accept socket connection
            private void ProcessAccept(SocketAsyncEventArgs AsyncEventArgs)
            {
                // First we get the accept socket from the passed in arguments
                Socket acceptsocket = AsyncEventArgs.AcceptSocket;

                // If the accept socket is connected to a client we will process it
                // otherwise nothing happens
                if (acceptsocket.Connected)
                {
                    try
                    {
                        // Go get a read socket out of the read socket stack
                        SocketAsyncEventArgs readsocket = _socketPool.Pop();
                                               
                        // If we get a socket, use it, otherwise all the sockets in the stack are used up
                        // and we can't accept anymore connections until one frees up
                        if (readsocket != null)
                        {
                            P2PPortClientHandler newClientHandler;

                            try
                            {
                                newClientHandler = new P2PPortClientHandler(acceptsocket, readsocket);

                                // Start a receive request and immediately check to see if the receive is already complete
                                // Otherwise OnIOCompleted will get called when the receive is complete
                                bool IOPending = acceptsocket.ReceiveAsync(newClientHandler.readSocket);
                                if (!IOPending)
                                {
                                    ProcessReceive(readsocket);
                                }

                                //raises the event that a clien has conencted 
                                this._ConnectedClientsTable.Add(newClientHandler.clientID, newClientHandler);
                                if (NewClientConnectionEvent != null)
                                    NewClientConnectionEvent(newClientHandler.clientID);


                            }
                            catch (Exception ex)
                            {
                            }  
                        }
                        else
                        {
                            acceptsocket.Close();
                            var ex = new Exception("Client connection refused because the maximum number of client connections (" + Convert.ToString(P2PNetworkingDefinitions.DEFAULT_MAX_CONNECTIONS) + ") allowed on the server has been reached.");
                            throw ex;
                        }
                    }
                    catch (Exception ex)
                    {
                        exceptionthrown = true;                       
                    }

                    // Start the process again to wait for the next connection
                    StartAcceptAsync(AsyncEventArgs);
                }
            }

         
#endregion
			
#region  < PRIVATE METHODS >
			
#region  < XML Data Handling >
			
			internal static string GetXMLDataHeader(string XMLDataString)
			{
				//function intended to retruieve the data header from a XML string
				
				System.IO.StringReader sr = null;
				System.Xml.XmlTextReader m_xmlr = null;
				
				try
				{
					sr = new System.IO.StringReader(XMLDataString);
					m_xmlr = new System.Xml.XmlTextReader(sr);
					m_xmlr.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
				}
				catch (System.Xml.XmlException)
				{
					string msg;
					msg = "Error trying to get XML format from  P2P Data string [" + XMLDataString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse P2P socket XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				try
				{
					m_xmlr.Read();
					string HeaderIdentifier = m_xmlr.Name;
					return HeaderIdentifier;
				}
				catch (Exception ex)
				{
					throw (new Exception("Error trying to rettieve the Data header from the XML String  [" + XMLDataString + "] : " + ex.Message));
				}
				
				
			}
			
#endregion

            // creates th server port  and all the requiered resorces 
            private void P2PPortCreation(object portOwner, int listeningPort)
            {
                if (!(portOwner is IUseP2PCommunicationsScheme))
                {
                    throw (new Exception("The port owner object must implement the interface \'IUseP2PCommunicationsScheme\'"));
                }
                exceptionthrown = false;

                //definition of the port owner object
                this._portOwnerComponent = portOwner;

                // First we set up our mutex and semaphore
                _mutex = new Mutex();
              
                // Then we create our stack of read sockets
                _socketPool = new P2PAsyncEventStack(P2PNetworkingDefinitions.DEFAULT_MAX_CONNECTIONS);

                // Now we create enough read sockets to service the maximum number of clients
                // that we will allow on the server
                // We also assign the event handler for IO Completed to each socket as we create it
                // and set up its buffer to the right size.
                // Then we push it onto our stack to wait for a client connection
                for (Int32 i = 0; i < P2PNetworkingDefinitions.DEFAULT_MAX_CONNECTIONS; i++)
                {
                    SocketAsyncEventArgs asyncEvtArgs = new SocketAsyncEventArgs();
                    asyncEvtArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnIOCompleted);
                    asyncEvtArgs.SetBuffer(new Byte[P2PNetworkingDefinitions.DATABUFFER_SIZE], 0, P2PNetworkingDefinitions.DATABUFFER_SIZE);
                    _socketPool.Push(asyncEvtArgs);
                }

                //creates a queue to process incomming requests 
                _incommingDataProcessingQueue = new TimedProducerConsumerQueue();
                _incommingDataProcessingQueue.NewItemDetected += new TimedProducerConsumerQueue.NewItemDetectedEventHandler(_incommingDataProcessingQueue_NewItemDetected); 

                
                //creates the table of connected clients
                this._ConnectedClientsTable = new Hashtable();

                //initiualizes statistical and startup data
                this._startDateTime = DateTime.Now;
                this._statisticsHandler = new P2PPortStatisticsHandler();

                //sets the listening port
                this._listeningPort = listeningPort;

                string host = System.Net.Dns.GetHostName();
                this._IPAddress = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetActiveIPAddress();

                // creates the end point of the port 
                this._connectionendpoint = new IPEndPoint(this._IPAddress, this._listeningPort);

                //creates the communications socket
                this._connectionsocket = new Socket(this._connectionendpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Now make it a listener socket at the IP address and port that we specified
                this._connectionsocket.Bind(this._connectionendpoint);

                this._connectionsocket.Listen(P2PNetworkingDefinitions.DEFAULT_MAX_CONNECTIONS);
                StartAcceptAsync(null);
                _mutex.WaitOne(); 
            }
			
            // This method processes the read socket once it has a transaction
            private void ProcessReceive(SocketAsyncEventArgs readSocket)
            {
                Int32 bytecount = readSocket.BytesTransferred;

                // if BytesTransferred is 0, then the remote end closed the connection
                if (bytecount > 0)
                {
                    //SocketError.Success indicates that the last operation on the underlying socket succeeded
                    if (readSocket.SocketError == SocketError.Success)
                    {
                      
                        P2PPortClientHandler clientHandler;
                        clientHandler = (P2PPortClientHandler)readSocket.UserToken;

                        //process the received data 
                        _incommingDataProcessingQueue.Enqueue(clientHandler);

                        bool IOPending = clientHandler.handlerSocket.ReceiveAsync(readSocket);
                        if (!IOPending)
                        {
                            ProcessReceive(readSocket);
                        }    
                    }
                    else
                    {
                        ProcessError(readSocket);
                    }
                }
                else
                {
                    //soemthing in the communications is nok the closes the resource 
                    CloseReadSocket(readSocket);

                }
            }

            private void ProcessError(SocketAsyncEventArgs readSocket)
            {
               CloseReadSocket(readSocket);
            }
                        
            // This overload of the close method doesn't require a token
            private void CloseReadSocket(SocketAsyncEventArgs readSocket)
            {
                P2PPortClientHandler clientHandler;
                clientHandler = readSocket.UserToken as P2PPortClientHandler;
                CloseAndFinishClientConnection(clientHandler);
                // Put the read socket back in the stack to be used again
                this._socketPool.Push(readSocket);
            }      
           
            // function that mainly process the received data in the server port 
            private void ProcessReceivedData(P2PPortClientHandler client)
            {
                try
                {                  
                    if (!(client == null))
                    {

                        try
                        {
                            //*****************************************
                            //tries to deserialize to a P2PDATA
                            //*****************************************
                            P2PData data = P2PData.Deserialize(client.ReceiveDataBuffer);
                            this.Statistics.LogDataReceptionEvent(data);
                            try
                            {
                                //catches if an exception ocurrs to avoid the programm exist from the reading thread
                                //because of a failure in the object that implements the interface.
                                ((IUseP2PCommunicationsScheme)this._portOwnerComponent).ReceiveData(data, this.ListeningPortNumber);
                                Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult successfulDataDelivery = Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.GetSucceedDeliveryResult(data);
                                client.handlerSocket.Send(successfulDataDelivery.Serialize());
                                //***************************************************************************************
                            }
                            catch (Exception ex)
                            {
                                Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult failureDataDelivery = Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.GetFailureDeliveryResult(data, ex.Message);
                                client.handlerSocket.Send(failureDataDelivery.Serialize());
                                //***************************************************************************************
                            }
                        }
                        catch (Exception ex)
                        {
                            //*****************************************
                            //tries to deserialize to a P2P_DATA_DELIVERY_RESULT
                            //*****************************************
                            P2PDataRequest dataRequest = default(P2PDataRequest);
                            P2PData dataRequested = default(P2PData);
                            try
                            {
                                dataRequest = P2PDataRequest.Deserialize(client.ReceiveDataBuffer);
                                try
                                {
                                    dataRequested = ((IUseP2PCommunicationsScheme)this._portOwnerComponent).RetrieveData(dataRequest, this.ListeningPortNumber);
                                    if (!(dataRequested == null))
                                    {
                                        this.Statistics.LogSuccesfulDataRequestEvent(dataRequest);
                                        client.handlerSocket.Send(dataRequested.Serialize());
                                        //***************************************************************************************
                                    }
                                    else
                                    {
                                        this.Statistics.LogFailedDataRequestEvent(dataRequest);
                                        string portOwnerName = ((IUseP2PCommunicationsScheme)this._portOwnerComponent).P2PPortOwnerName;
                                        if (portOwnerName == null)
                                        {
                                            portOwnerName = "UNKNOWN";
                                        }
                                        string errorMessage = "The remote object \'" + portOwnerName + "\' can\'t handle the requested data named \'" + dataRequest.RequestedDataName + "\'";
                                        P2PDataRequestFailure reqFAilure = P2PDataRequestFailure.GetP2PDataRequestFailure(dataRequest, errorMessage);
                                        client.handlerSocket.Send(reqFAilure.Serialize());
                                        //***************************************************************************************

                                    }
                                }
                                catch (Exception ex2)
                                {
                                    this.Statistics.LogFailedDataRequestEvent(dataRequest);
                                    string portOwnerName = ((IUseP2PCommunicationsScheme)this._portOwnerComponent).P2PPortOwnerName;
                                    if (portOwnerName == null)
                                    {
                                        portOwnerName = "UNKNOWN";
                                    }
                                    string errorMessage = ex2.Message;
                                    P2PDataRequestFailure reqFAilure = P2PDataRequestFailure.GetP2PDataRequestFailure(dataRequest, errorMessage);
                                    client.handlerSocket.Send(reqFAilure.Serialize());
                                    //***************************************************************************************
                                }
                            }
                            catch (Exception)
                            {
                                string msg = "";
                                msg = "Error processing incomming data from P2PPort client : " + ex.ToString();
                                CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    string msg = "";
                    msg = "Error processing incomming data from P2PPort client : " + ex.ToString();
                    CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
                }

            }
			
#region  < CLIENT CONNECTIONS HANDLING >
			
			private void CloseAndFinishClientConnection(P2PPortClientHandler clientHandler)
			{
				P2PPortClientHandler currentClientHandler = default(P2PPortClientHandler);

                currentClientHandler = (P2PPortClientHandler)this._ConnectedClientsTable[clientHandler.clientID];
				try
				{
					if (!(currentClientHandler.handlerSocket == null))
					{
						currentClientHandler.handlerSocket.Close();
					}
				}
				catch (Exception)
				{
				}
				try
				{
                    this._ConnectedClientsTable.Remove(currentClientHandler.clientID);
                }
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void CloseAndFinishAllClientConnectionsOnPortDisposing()
			{
				IEnumerator enumm = default(IEnumerator);
				P2PPortClientHandler _P2PPortClientHandler = default(P2PPortClientHandler);
				Hashtable copyOFClientConnectedTable = default(Hashtable);
				
				copyOFClientConnectedTable = (Hashtable) (this._ConnectedClientsTable.Clone());
				
				enumm = copyOFClientConnectedTable.GetEnumerator();
				while (enumm.MoveNext())
				{
					_P2PPortClientHandler = (P2PPortClientHandler) (((DictionaryEntry) enumm.Current).Value);
					try
					{
						_P2PPortClientHandler.handlerSocket.Close();
					}
					catch (Exception)
					{
					}
				}
				this._ConnectedClientsTable.Clear();
			}
			
#endregion
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
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
						this.CloseAndFinishAllClientConnectionsOnPortDisposing();
					}
                    this._connectionsocket.Close();
                    _mutex.ReleaseMutex();
                    this._socketPool.Dispose();
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
