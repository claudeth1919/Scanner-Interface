using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using UtilitiesLibrary;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Common;


namespace CommunicationsLibrary
{
    namespace Services.P2PCommunicationsScheme
    {

        internal sealed class P2PPortClientConnectionHandler
        {

    #region < DATA MEMBERS > 

            
            internal readonly Int32 BufferOffsetReceive;
            internal readonly Int32 PermanentReceiveMessageOffset;
            internal readonly Int32 BufferOffsetSend;
            internal Int32 lengthOfCurrentIncomingMessage;
            internal string _handlerID;
            private SocketAsyncEventArgs _SEAEobject; 

            //receiveMessageOffset is used to mark the byte position where the message
            //begins in the receive buffer. This value can sometimes be out of
            //bounds for the data stream just received. But, if it is out of bounds, the 
            //code will not access it.
            internal Int32 receiveMessageOffset;
            internal Byte[] byteArrayForPrefix;
            
            internal readonly Int32 receivePrefixLength;
            internal Int32 receivedPrefixBytesDoneCount = 0;
            internal Int32 receivedMessageBytesDoneCount = 0;
            internal Int32 recPrefixBytesDoneThisOp = 0;
            internal Int32 sendBytesRemainingCount;           
            internal readonly Int32 sendPrefixLength;

            private Byte[] dataToSendBuffer;
            private Byte[] dataReceivedBuffer;

            internal Int32 bytesSentAlreadyCount;

            //The session ID correlates with all the data sent in a connected session.
            //It is different from the transmission ID in the DataHolder, which relates
            //to one TCP message. A connected session could have many messages, if you
            //set up your app to allow it.
            private string _ClientID;

            private P2PDataSendMode _dataMode;


    #endregion 

    #region < CONSTRUCTOR >

            public P2PPortClientConnectionHandler(SocketAsyncEventArgs e, Int32 rOffset, Int32 sOffset, Int32 receivePrefixLength ,  Int32 sendPrefixLength )
            {
                this._handlerID = UtilitiesModule.GetIndexableGUID();
                this.BufferOffsetReceive = rOffset;
                this.BufferOffsetSend = sOffset;                
                this.receivePrefixLength = receivePrefixLength;
                this.sendPrefixLength = sendPrefixLength;
                this.receiveMessageOffset = rOffset + receivePrefixLength;
                this.PermanentReceiveMessageOffset = this.receiveMessageOffset;
                this._dataMode = P2PDataSendMode.notDefined;
            }

    #endregion

    #region < PROPERTIES >

            //Let's use an ID for this object during testing, just so we can see what
            //is happening better if we want to.
            public string HandlerID
            {
                get
                {
                    return this._handlerID;
                }
            }

            public string clientID
            {
                get
                {
                    return this._ClientID;
                }
            }

            public Socket CommunicationsSocket
            {
                get
                {
                    return this._SEAEobject.AcceptSocket; 
                }
            }

            public P2PDataSendMode dataSendMode
            {
                get
                {
                    return this._dataMode;
                }
                set
                {
                    this._dataMode = value;
                }
            }

            public Byte[] DataToSendBuffer
            {
                get
                {
                    return this.dataToSendBuffer;
                }
            }
            public Byte[] DataReceivedBuffer
            {
                get
                {
                    return this.dataReceivedBuffer;
                }

            }



    #endregion 

    #region < FRIEND METHODS > 

            internal void CreateNewDataReceivedBuffer(int size)
            {
                this.dataReceivedBuffer = new byte[size];
            }

            internal void CreateNewDataToSendBuffer(int size)
            {             
                this.dataToSendBuffer = new byte[size];
            }
            
            internal void CreateClientSession()
            {
                this._ClientID = UtilitiesModule.GetIndexableGUID();
            }

            internal void Reset()
            {
                this.receivedPrefixBytesDoneCount = 0;
                this.receivedMessageBytesDoneCount = 0;
                this.recPrefixBytesDoneThisOp = 0;
                this.receiveMessageOffset = this.PermanentReceiveMessageOffset;
                this._dataMode = P2PDataSendMode.notDefined;
            }

    #endregion 

           

          

         
        }
    }

}
