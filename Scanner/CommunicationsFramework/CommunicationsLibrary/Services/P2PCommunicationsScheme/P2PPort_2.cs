using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualBasic;
using System.Net;
using UtilitiesLibrary.EventLoging;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Common;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Statistics;
using System.Diagnostics;

namespace CommunicationsLibrary.Services.P2PCommunicationsScheme
{
    public class P2PPort : IDisposable
    {

#region < DATAMEMBERS > 

        private const Int32 MAX_CONNECTIONS = 3000;
        private const Int32 NUMBER_OF_SAEA_OBJECTS_FOR_REC_AND_SEND = 30;
        //the number of operations to allocate 
        private const Int32 NUMBER_OF_OPERATIONS_TO_ALLOCATE = 2;
        private const Int32 MAX_SIMULTANEOUS_ACCEPT_OPS = 10;
        private const Int32 BACK_LOG = 100;
      


        private int _listeningPort;
        private IPAddress _IPAddress;
        private P2PPortStatisticsHandler _statisticsHandler;
        private DateTime _startDateTime;
        private Hashtable _ConnectedClientsTable;
        protected IPEndPoint _connectionendpoint;

        private object _portOwnerComponent;
        private BufferManager _bufferManager;
        private Socket _listenSocket;
        private Semaphore _maxConnectionsEnforcer;
        private PrefixHandler _prefixHandler;
        private DataReceptionHandler _messageHandler;
        private SocketAsyncEventArgsPool _poolOfAcceptEventArgs;
        private SocketAsyncEventArgsPool _poolOfRecSendEventArgs;
     
#endregion        

#region  < EVENTS >

        public delegate void NewClientConnectionEventHandler(string ClientID);
        private NewClientConnectionEventHandler NewClientConnectionEvent;
        public event NewClientConnectionEventHandler NewClientConnection
        {
            add
            {
                NewClientConnectionEvent = (NewClientConnectionEventHandler)System.Delegate.Combine(NewClientConnectionEvent, value);
            }
            remove
            {
                NewClientConnectionEvent = (NewClientConnectionEventHandler)System.Delegate.Remove(NewClientConnectionEvent, value);
            }
        }

        public delegate void ClientDisconnectionEventHandler(string ClientID);
        private ClientDisconnectionEventHandler ClientDisconnectionEvent;
        public event ClientDisconnectionEventHandler ClientDisconnection
        {
            add
            {
                ClientDisconnectionEvent = (ClientDisconnectionEventHandler)System.Delegate.Combine(ClientDisconnectionEvent, value);
            }
            remove
            {
                ClientDisconnectionEvent = (ClientDisconnectionEventHandler)System.Delegate.Remove(ClientDisconnectionEvent, value);
            }
        }
        
#endregion

#region < CONSTRUCTORS > 

        public P2PPort(object portOwner, int initialTCPPortNumberToFindAFreePort, int finalTCPPortNumberToFindAFreePort)
        {           
            int listeningPort = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPortOnARange(initialTCPPortNumberToFindAFreePort, finalTCPPortNumberToFindAFreePort);
            this.CreateAndStartPort(portOwner, listeningPort);
        }

        public P2PPort(object portOwner, int listeningPort)
        {
            this.CreateAndStartPort(portOwner, listeningPort);  
        }

        public P2PPort(object portOwner)
        {
            int listeningPort = Services.TCPPortsManagement.TCPPortFinder.GetInstance().GetAvailableFreeTCPPort();
            this.CreateAndStartPort(portOwner, listeningPort);  
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

        public IPAddress IPAddress
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

#region < EVENT HANDLING > 

        private void EventHandling_AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            //Any code that you put in this method will NOT be called if
            //the operation completes synchronously, which will probably happen when
            //there is some kind of socket error. It might be better to put the code
            //in the ProcessAccept method.
            ProcessAccept(e);
        }

        void EventHandling_IO_Completed(object sender, SocketAsyncEventArgs e)
        {   
            // determine which type of operation just completed and call the associated handler
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;

                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new ArgumentException("The last operation completed on the socket was not a receive or send");
            }
        }


#endregion

#region < PRIVATE METHODS >

        #region < PORT INITIALIZATION  >  

        private void CreateAndStartPort(object portOwner, int listeningPort)
        {
            if (!(portOwner is IUseP2PCommunicationsScheme))
            {
                throw (new Exception("The port owner object must implement the interface \'IUseP2PCommunicationsScheme\'"));
            }

            this._portOwnerComponent = portOwner;
            this._ConnectedClientsTable = new Hashtable();
            this._startDateTime = DateTime.Now;
            this._statisticsHandler = new P2PPortStatisticsHandler();           
            this._listeningPort = listeningPort;
            string host = System.Net.Dns.GetHostName();
            this._IPAddress = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetActiveIPAddress();
            this._connectionendpoint = new IPEndPoint(this._IPAddress, this._listeningPort);
            
            this._prefixHandler = new PrefixHandler();
            this._messageHandler = new DataReceptionHandler();

           
            Int32 totalBytes = P2PNetworkingDefinitions.DATABUFFER_SIZE * NUMBER_OF_SAEA_OBJECTS_FOR_REC_AND_SEND * NUMBER_OF_OPERATIONS_TO_ALLOCATE;
            Int32 totalBufferBytesInEachSaeaObject = P2PNetworkingDefinitions.DATABUFFER_SIZE * NUMBER_OF_OPERATIONS_TO_ALLOCATE;
            this._bufferManager = new BufferManager(totalBytes, totalBufferBytesInEachSaeaObject);
                      
            this._poolOfRecSendEventArgs = new SocketAsyncEventArgsPool(NUMBER_OF_SAEA_OBJECTS_FOR_REC_AND_SEND);
            this._poolOfAcceptEventArgs = new SocketAsyncEventArgsPool(NUMBER_OF_OPERATIONS_TO_ALLOCATE);

            this._maxConnectionsEnforcer = new Semaphore(MAX_CONNECTIONS, MAX_CONNECTIONS);
          

            //creation of the pool of SEAE Object used to handle incomming connections 
            for (Int32 i = 0; i < MAX_SIMULTANEOUS_ACCEPT_OPS; i++)
            {
                SocketAsyncEventArgs SAEA = CreateNewSaeaForAccept(_poolOfAcceptEventArgs);
                this._poolOfAcceptEventArgs.Push(SAEA);
            }

            //creation of the pool of SEAE objects used for send and receive data operations
            SocketAsyncEventArgs eventArgObjectForPool;
            for (Int32 i = 0; i < NUMBER_OF_SAEA_OBJECTS_FOR_REC_AND_SEND; i++)
            {
                eventArgObjectForPool = new SocketAsyncEventArgs();
                this._bufferManager.SetBuffer(eventArgObjectForPool);
                eventArgObjectForPool.Completed += new EventHandler<SocketAsyncEventArgs>(EventHandling_IO_Completed);
                P2PPortClientConnectionHandler _P2PClientCnnHandler = new P2PPortClientConnectionHandler(eventArgObjectForPool, eventArgObjectForPool.Offset, eventArgObjectForPool.Offset + P2PNetworkingDefinitions.DATABUFFER_SIZE, P2PNetworkingDefinitions.DATA_SEND_RECEIVE_PREFIX_LENGHT, P2PNetworkingDefinitions.DATA_SEND_RECEIVE_PREFIX_LENGHT);
                _P2PClientCnnHandler.CreateNewDataReceivedBuffer(P2PNetworkingDefinitions.DATABUFFER_SIZE);
                eventArgObjectForPool.UserToken = _P2PClientCnnHandler;
                this._poolOfRecSendEventArgs.Push(eventArgObjectForPool);
            }
                            
            //creation of the socker and binging to a listening port 
            _listenSocket = new Socket(this._connectionendpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _listenSocket.Bind(this._connectionendpoint);
            _listenSocket.Listen(BACK_LOG);
            StartAccept();
        }     

        #endregion 

        private SocketAsyncEventArgs CreateNewSaeaForAccept(SocketAsyncEventArgsPool pool)
        {
            SocketAsyncEventArgs acceptEventArg = new SocketAsyncEventArgs();

            acceptEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(EventHandling_AcceptEventArg_Completed);
           // acceptEventArg.UserToken = theAcceptOpToken;
            return acceptEventArg;
        }
        
        #region < ACCEPT OPERATIONS > 
            
            internal void StartAccept()
            {
                SocketAsyncEventArgs acceptEventArg;

                if (this._poolOfAcceptEventArgs.Count > 1)
                {
                    try
                    {
                        acceptEventArg = this._poolOfAcceptEventArgs.Pop();
                    }
                    catch
                    {
                        //this happens when the pop produces and error but is crated a new SEAE object 
                        //to manage the current incomming connection
                        acceptEventArg = CreateNewSaeaForAccept(_poolOfAcceptEventArgs);
                    }
                }
                else
                {
                    acceptEventArg = CreateNewSaeaForAccept(_poolOfAcceptEventArgs);
                }
                    
                this._maxConnectionsEnforcer.WaitOne();
                bool willRaiseEvent = _listenSocket.AcceptAsync(acceptEventArg);
                if (!willRaiseEvent)
                {
                    ProcessAccept(acceptEventArg);
                }
            }

            private void ProcessAccept(SocketAsyncEventArgs acceptEventArgs)
            {

                if (acceptEventArgs.SocketError != SocketError.Success)
                {
                    //loop for start accepting connections 
                    StartAccept();
                    HandleBadAccept(acceptEventArgs);
                    return;
                }
                else
                {
                    //loop for start accepting connections 
                    StartAccept();

                    Socket acceptsocket = acceptEventArgs.AcceptSocket;         

                    SocketAsyncEventArgs receiveSendEventArgs = this._poolOfRecSendEventArgs.Pop();

                    if (receiveSendEventArgs != null)
                    {
                        P2PPortClientConnectionHandler newClientConnectiontHandler;
                        newClientConnectiontHandler = (P2PPortClientConnectionHandler)receiveSendEventArgs.UserToken;
                        newClientConnectiontHandler.CreateClientSession();

                        receiveSendEventArgs.AcceptSocket = acceptEventArgs.AcceptSocket;

                        //..........................
                        //makes the socket of the current SocketAsyncEventArgs object used to handle
                        //the current connection to null and backs it to the pool for incomming connections
                        acceptEventArgs.AcceptSocket = null;
                        this._poolOfAcceptEventArgs.Push(acceptEventArgs);
                                                
                        StartReceive(receiveSendEventArgs);

                        this._ConnectedClientsTable.Add(newClientConnectiontHandler.clientID, newClientConnectiontHandler);

                        if (NewClientConnectionEvent != null)
                            NewClientConnectionEvent(newClientConnectiontHandler.clientID);
                    }
                    else
                    {
                        acceptsocket.Close();
                        var ex = new Exception("Client connection refused because the maximum number of client connections (" + Convert.ToString(P2PNetworkingDefinitions.DEFAULT_MAX_CONNECTIONS) + ") allowed on the server has been reached.");
                        throw ex;
                    }

                }
            }

            private void HandleBadAccept(SocketAsyncEventArgs acceptEventArgs)
            {
                acceptEventArgs.AcceptSocket.Close();
                _poolOfAcceptEventArgs.Push(acceptEventArgs);
            }

        #endregion

        #region < DATA RECEPTION OPERATIONS >
 
            private void StartReceive(SocketAsyncEventArgs receiveSendEventArgs)
            {
                P2PPortClientConnectionHandler clientHandler = (P2PPortClientConnectionHandler)receiveSendEventArgs.UserToken;
                receiveSendEventArgs.SetBuffer(clientHandler.BufferOffsetReceive, P2PNetworkingDefinitions.DATABUFFER_SIZE);
                bool willRaiseEvent = receiveSendEventArgs.AcceptSocket.ReceiveAsync(receiveSendEventArgs);

                if (!willRaiseEvent)
                {
                    ProcessReceive(receiveSendEventArgs);
                }
            }
               
            private void ProcessReceive(SocketAsyncEventArgs receiveSendEventArgs)
            {
                P2PPortClientConnectionHandler clientHandler = (P2PPortClientConnectionHandler)receiveSendEventArgs.UserToken;

                if (receiveSendEventArgs.SocketError != SocketError.Success)
                {
                    //---------------------------------------------------------
                    // at this point the client has disconnected unexpectedly 
                    clientHandler.Reset();
                    CloseClientSocket(receiveSendEventArgs);
                    return;
                }

                if (receiveSendEventArgs.BytesTransferred == 0)
                {
                    clientHandler.Reset();
                    CloseClientSocket(receiveSendEventArgs);
                    return;
                }
                        
                Int32 remainingBytesToProcess = receiveSendEventArgs.BytesTransferred;
                        
                if (clientHandler.receivedPrefixBytesDoneCount < P2PNetworkingDefinitions.DATA_SEND_RECEIVE_PREFIX_LENGHT)
                {
                    remainingBytesToProcess = _prefixHandler.HandlePrefix(receiveSendEventArgs, clientHandler, remainingBytesToProcess);

                    if (remainingBytesToProcess == 0)
                    {  
                        StartReceive(receiveSendEventArgs);
                        return;
                    }
                }

                bool incomingTcpMessageIsReady;
                incomingTcpMessageIsReady = this._messageHandler.HandleData(receiveSendEventArgs, clientHandler, remainingBytesToProcess);
                
                if (incomingTcpMessageIsReady != true)
                {
                    clientHandler.receiveMessageOffset = clientHandler.BufferOffsetReceive;
                    clientHandler.recPrefixBytesDoneThisOp = 0;
                    StartReceive(receiveSendEventArgs);                
                }
                else
                {
                    //the data transmission is finished 
                    //the data is treated 
                    this.ProcessReceivedData(clientHandler);
                    clientHandler.CreateNewDataReceivedBuffer(P2PNetworkingDefinitions.DATABUFFER_SIZE);
                    clientHandler.Reset();                    
                }
            }
        
            private byte[] ExtractP2PDataToDeserializeToP2PData(Byte[] data)
            {
                //removes the first number of bytes used to hold the prefix data that indicates the data lenght                 
                byte[] temporalData = null;
                Int32  dataLength = data.Length - P2PNetworkingDefinitions.DATA_SEND_RECEIVE_PREFIX_LENGHT;
                temporalData = new byte[dataLength];
                Buffer.BlockCopy(data, P2PNetworkingDefinitions.DATA_SEND_RECEIVE_PREFIX_LENGHT, temporalData, 0, dataLength);
                return temporalData;
            }
           
            private void ProcessReceivedData(P2PPortClientConnectionHandler clientHandler)
            {/*
                try
                {
                    try
                    {

                        Byte[] DataToDeserialize = ExtractP2PDataToDeserializeToP2PData(clientHandler.DataReceivedContainer.Data);

                        //*****************************************
                        //tries to deserialize to a P2PDATA
                        //*****************************************
                        P2PData data = P2PData.Deserialize(DataToDeserialize);
                        this.Statistics.LogDataReceptionEvent(data);
                        try
                        {
                            //catches if an exception ocurrs to avoid the programm exist from the reading thread
                            //because of a failure in the object that implements the interface.
                            ((IUseP2PCommunicationsScheme)this._portOwnerComponent).ReceiveData(data, this.ListeningPortNumber);
                            Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult successfulDataDelivery = Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.GetSucceedDeliveryResult(data);
                            
                            //prepares the data to be sent

                            //clientHandler.CommunicationsSocket.Send(successfulDataDelivery.Serialize());
                            //***************************************************************************************
                        }
                        catch (Exception ex)
                        {
                            Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult failureDataDelivery = Services.P2PCommunicationsScheme.Data.P2PDataDeliveryResult.GetFailureDeliveryResult(data, ex.Message);
                            //prepates the data to be sent 
                            clientHandler.CommunicationsSocket.Send(failureDataDelivery.Serialize());
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
                            //dataRequest = P2PDataRequest.Deserialize(client.ReceiveDataBuffer);
                            try
                            {
                                dataRequested = ((IUseP2PCommunicationsScheme)this._portOwnerComponent).RetrieveData(dataRequest, this.ListeningPortNumber);
                                if (!(dataRequested == null))
                                {
                                    this.Statistics.LogSuccesfulDataRequestEvent(dataRequest);
                                   // client.handlerSocket.Send(dataRequested.Serialize());
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
                                   // client.handlerSocket.Send(reqFAilure.Serialize());
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
                               // client.handlerSocket.Send(reqFAilure.Serialize());
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
                catch (Exception ex)
                {
                    string msg = "";
                    msg = "Error processing incomming data from P2PPort client : " + ex.ToString();
                    CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
                }
                */
            }
			
        
        #endregion 

        #region  < DATA SEND OPERATIONS  > 

            private void StartSend(SocketAsyncEventArgs receiveSendEventArgs)
            {
                P2PPortClientConnectionHandler clientHandler = (P2PPortClientConnectionHandler)receiveSendEventArgs.UserToken;

                if (clientHandler.sendBytesRemainingCount <= P2PNetworkingDefinitions.DATABUFFER_SIZE)
                {
                    receiveSendEventArgs.SetBuffer(clientHandler.BufferOffsetSend, clientHandler.sendBytesRemainingCount);
                    //Copy the bytes to the buffer associated with this SAEA object.
                    Buffer.BlockCopy(clientHandler.DataToSendBuffer, clientHandler.bytesSentAlreadyCount, receiveSendEventArgs.Buffer, clientHandler.BufferOffsetSend, clientHandler.sendBytesRemainingCount);
                }
                else
                {
                    receiveSendEventArgs.SetBuffer(clientHandler.BufferOffsetSend, P2PNetworkingDefinitions.DATABUFFER_SIZE);
                    Buffer.BlockCopy(clientHandler.DataToSendBuffer, clientHandler.bytesSentAlreadyCount, receiveSendEventArgs.Buffer, clientHandler.BufferOffsetSend, P2PNetworkingDefinitions.DATABUFFER_SIZE);
                }

                //post asynchronous send operation
                bool willRaiseEvent = receiveSendEventArgs.AcceptSocket.SendAsync(receiveSendEventArgs);

                if (!willRaiseEvent)
                {      
                    ProcessSend(receiveSendEventArgs);
                }
            }

            private void ProcessSend(SocketAsyncEventArgs receiveSendEventArgs)
            {
                P2PPortClientConnectionHandler clientHandler = (P2PPortClientConnectionHandler)receiveSendEventArgs.UserToken;
        
                if (receiveSendEventArgs.SocketError == SocketError.Success)
                {                
                    clientHandler.sendBytesRemainingCount = clientHandler.sendBytesRemainingCount - receiveSendEventArgs.BytesTransferred;

                    if (clientHandler.sendBytesRemainingCount == 0)
                    {
                        StartReceive(receiveSendEventArgs);
                    }
                    else
                    {
                        clientHandler.bytesSentAlreadyCount += receiveSendEventArgs.BytesTransferred;
                        StartSend(receiveSendEventArgs);
                    }
                }
                else
                {
                    //If we are in this else-statement, there was a socket error.
                    clientHandler.Reset();
                    CloseClientSocket(receiveSendEventArgs);
                }
            }

        #endregion

        #region < CLIENT CONNECTIONS CLOSING > 
        
            private void CloseClientSocket(SocketAsyncEventArgs e)
            {

                P2PPortClientConnectionHandler clientHandler;
                clientHandler = (P2PPortClientConnectionHandler)e.UserToken;

        
                // do a shutdown before you close the socket
                try
                {
                    e.AcceptSocket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                }

                e.AcceptSocket.Close();

                if (clientHandler.DataReceivedBuffer   != null)
                {
                    clientHandler.CreateNewDataReceivedBuffer(P2PNetworkingDefinitions.DATABUFFER_SIZE);
                }
                this._poolOfRecSendEventArgs.Push(e);
                this._maxConnectionsEnforcer.Release();

                this._ConnectedClientsTable.Remove(clientHandler.clientID);


                if (ClientDisconnectionEvent != null)
                    ClientDisconnectionEvent(clientHandler.clientID);
             

            }
        
            internal void CleanUpOnExit()
            {
                DisposeAllSaeaObjects();
            }

            private void DisposeAllSaeaObjects()
            {
                SocketAsyncEventArgs eventArgs;
                while (this._poolOfAcceptEventArgs.Count > 0)
                {
                    eventArgs = _poolOfAcceptEventArgs.Pop();
                    eventArgs.Dispose();
                }
                while (this._poolOfRecSendEventArgs.Count > 0)
                {
                    eventArgs = _poolOfRecSendEventArgs.Pop();
                    eventArgs.Dispose();
                }
            }

        #endregion          


#endregion

#region < INTERFACE IMPLEMENTATION  > 

    #region < IDisposable> 

            public void Dispose()
            {
               
            }

    #endregion

#endregion







         
    }
}
