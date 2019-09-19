using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;

namespace CommunicationsLibrary.Services.P2PCommunicationsScheme.Common
{
    internal class PrefixHandler
    {
        public Int32 HandlePrefix(SocketAsyncEventArgs e,  P2PPortClientConnectionHandler  clientHandler, Int32 remainingBytesToProcess)
        {
            //receivedPrefixBytesDoneCount tells us how many prefix bytes were
            //processed during previous receive ops which contained data for 
            //this message. Usually there will NOT have been any previous 
            //receive ops here. So in that case,
            //receiveSendToken.receivedPrefixBytesDoneCount would equal 0.
            //Create a byte array to put the new prefix in, if we have not
            //already done it in a previous loop.
            if (clientHandler.receivedPrefixBytesDoneCount == 0)
            {
                clientHandler.byteArrayForPrefix = new Byte[clientHandler.receivePrefixLength];
            }

            // If this next if-statement is true, then we have received >=
            // enough bytes to have the prefix. So we can determine the 
            // length of the message that we are working on.
            if (remainingBytesToProcess >= clientHandler.receivePrefixLength - clientHandler.receivedPrefixBytesDoneCount)
            {
                //Now copy that many bytes to byteArrayForPrefix.
                //We can use the variable receiveMessageOffset as our main
                //index to show which index to get data from in the TCP
                //buffer.
                int srcOffset = clientHandler.receiveMessageOffset - clientHandler.receivePrefixLength + clientHandler.receivedPrefixBytesDoneCount;
                int count = clientHandler.receivePrefixLength - clientHandler.receivedPrefixBytesDoneCount;
                Buffer.BlockCopy(e.Buffer, srcOffset, clientHandler.byteArrayForPrefix, clientHandler.receivedPrefixBytesDoneCount, count);
                remainingBytesToProcess = remainingBytesToProcess - clientHandler.receivePrefixLength + clientHandler.receivedPrefixBytesDoneCount;

                clientHandler.recPrefixBytesDoneThisOp = clientHandler.receivePrefixLength - clientHandler.receivedPrefixBytesDoneCount;
                clientHandler.receivedPrefixBytesDoneCount = clientHandler.receivePrefixLength;
                clientHandler.lengthOfCurrentIncomingMessage = BitConverter.ToInt32(clientHandler.byteArrayForPrefix, 0);
            }

            else
            {
                //This next else-statement deals with the situation 
                //where we have some bytes
                //of this prefix in this receive operation, but not all.
                //-------------------               
                //Write the bytes to the array where we are putting the
                //prefix data, to save for the next loop.
                Buffer.BlockCopy(e.Buffer, clientHandler.receiveMessageOffset - clientHandler.receivePrefixLength + clientHandler.receivedPrefixBytesDoneCount, clientHandler.byteArrayForPrefix, clientHandler.receivedPrefixBytesDoneCount, remainingBytesToProcess);

                clientHandler.recPrefixBytesDoneThisOp = remainingBytesToProcess;
                clientHandler.receivedPrefixBytesDoneCount += remainingBytesToProcess;
                remainingBytesToProcess = 0;
            }

            // This section is needed when we have received
            // an amount of data exactly equal to the amount needed for the prefix,
            // but no more. And also needed with the situation where we have received
            // less than the amount of data needed for prefix. 
            if (remainingBytesToProcess == 0)
            {
                clientHandler.receiveMessageOffset = clientHandler.receiveMessageOffset - clientHandler.recPrefixBytesDoneThisOp;
                clientHandler.recPrefixBytesDoneThisOp = 0;
            }
            return remainingBytesToProcess;
        }
    }
}
