using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;

namespace CommunicationsLibrary.Services.P2PCommunicationsScheme.Common
{
    class DataPreparationHandler
    {
        internal static void PrepareDataToSend(SocketAsyncEventArgs e , P2PData data)
        {
            Byte[] SerializedData = data.Serialize();
            DataPreparationHandler.PrepareAndBufferData(e, SerializedData);            
        }

        internal static void PrepareDataToSend(SocketAsyncEventArgs e, P2PDataRequest dataRequest)
        {
            Byte[] SerializedData = dataRequest.Serialize();
            DataPreparationHandler.PrepareAndBufferData(e, SerializedData); 
        }

        /// <summary>
        /// prepares a data message to be sent to the P2P Port using the 
        /// scheme of SocketAsyncEventArgs. the preparation consisits on
        /// arrange a byte where the first 4 bytes has the total lenght of
        /// packet and the rest is the data it self or part of if
        /// </summary>
        /// <param name="e"></param>
        /// <param name="data"></param> 
        private static void PrepareAndBufferData(SocketAsyncEventArgs e, Byte[] data)
        {
            P2PPortClientConnectionHandler clientConnectionHandler = (P2PPortClientConnectionHandler)e.UserToken;
           
            Int32 lengthOfData = data.Length ;
            Byte[] arrayOfBytesInPrefix = BitConverter.GetBytes(lengthOfData);

            int totalDataLenght = clientConnectionHandler.sendPrefixLength + lengthOfData;
            clientConnectionHandler.CreateNewDataToSendBuffer(totalDataLenght);
          

            //Now copy the 2 things to the theUserToken.dataToSend.
            Buffer.BlockCopy(arrayOfBytesInPrefix , 0 , clientConnectionHandler.DataToSendBuffer, 0                                       , clientConnectionHandler.sendPrefixLength);
            Buffer.BlockCopy(data                 , 0 , clientConnectionHandler.DataToSendBuffer, clientConnectionHandler.sendPrefixLength, lengthOfData);

            clientConnectionHandler.sendBytesRemainingCount = clientConnectionHandler.sendPrefixLength + lengthOfData;
            clientConnectionHandler.bytesSentAlreadyCount = 0;
        }

    }
}
