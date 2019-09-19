using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;

namespace CommunicationsLibrary.Services.P2PCommunicationsScheme.Common
{
    class DataReceptionHandler
    {

        public bool HandleData(SocketAsyncEventArgs receiveSendEventArgs,  P2PPortClientConnectionHandler  clientHandler, Int32 remainingBytesToProcess)
        {
            bool incomingTcpMessageIsReady = false;
                     
            if (clientHandler.receivedMessageBytesDoneCount == 0)
            {   
                clientHandler.CreateNewDataReceivedBuffer (clientHandler.lengthOfCurrentIncomingMessage);
            }

            if (remainingBytesToProcess + clientHandler.receivedMessageBytesDoneCount == clientHandler.lengthOfCurrentIncomingMessage)
            {
               Buffer.BlockCopy(receiveSendEventArgs.Buffer, clientHandler.receiveMessageOffset, clientHandler.DataReceivedBuffer, clientHandler.receivedMessageBytesDoneCount, remainingBytesToProcess);
               incomingTcpMessageIsReady = true;
            }
            else
            {
                try
                {
                    Buffer.BlockCopy(receiveSendEventArgs.Buffer, clientHandler.receiveMessageOffset, clientHandler.DataReceivedBuffer, clientHandler.receivedMessageBytesDoneCount, remainingBytesToProcess);
                    clientHandler.receiveMessageOffset = clientHandler.receiveMessageOffset - clientHandler.recPrefixBytesDoneThisOp;
                    clientHandler.receivedMessageBytesDoneCount += remainingBytesToProcess;

                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                }
            }
            return incomingTcpMessageIsReady;
        }
    }
}
