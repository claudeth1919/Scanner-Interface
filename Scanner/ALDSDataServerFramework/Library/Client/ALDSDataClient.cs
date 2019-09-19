using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Parametrization;
using ALDSDataServerLibrary.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.BroadCasting;




namespace ALDSDataServerLibrary.Client
{

    public delegate void ConnectionLostWithALDSDataServer(ALDSDataClient sender);
    public delegate void DataReceivedFromALDSDataServer (ALDSDataClient sender , ALDSData dataReceived);


    public class ALDSDataClient
    {
        #region  < DATA MEMBERS >

            private SocketsServerClient _client;
          
            
        #endregion 

        #region  < EVENTS  >

            public event  ConnectionLostWithALDSDataServer ConnectionLost;
            public event DataReceivedFromALDSDataServer   DataReceived;

        #endregion 
                
        #region < EVENT HANDLING > 

            private void _client_ConnectionLost(SocketsServerClient sender)
            {
                if (ConnectionLost != null)
                    ConnectionLost(this);
            }

            private void _client_DataReceived(SocketData Data, SocketsServerClient sender)
            {
                //event received from ALDS data server through the sockets server 
                ALDSData ALDSdata; 
                Boolean result = this.TryParse(Data , out ALDSdata );
                if (result)
                    if (DataReceived != null)
                        DataReceived(this, ALDSdata);
            }
        

        #endregion 

        #region  < CONSTRUCTORS >

            public ALDSDataClient(string hostName)
            {
                this._client = new SocketsServerClient(hostName, ALDSDataServerLibrary.Server.ALDSDataServer.ALDS_DATA_SERVER_PORT);
                this._client.ConnectionLost += new SocketsServerClient.ConnectionLostEventHandler(_client_ConnectionLost);
                this._client.DataReceived += new SocketsServerClient.DataReceivedEventHandler(_client_DataReceived);
            }

        #endregion


        #region < PUBLIC METHODS > 

            public void Connect()
            {
                this._client.Connect();
            }


        #endregion 

        #region  < PRIVATE METHODS > 

            private Boolean TryParse(SocketData data, out ALDSData ALDS_Data)
            {
                MachineStatusData machineStatus;
                if (MachineStatusData.TryParse(data, out machineStatus))
                {
                    ALDS_Data = machineStatus;
                    return true;
                }
                else
                {
                    try
                    {
                        //creates an ALDS data using 
                        ALDS_Data = new ALDSData(data.DataName);
                        CustomHashTable table = (CustomHashTable)data.Value;
                        foreach (System.Collections.DictionaryEntry  dice in table)
                        {
                            ALDS_Data.AttachDataAttribute((string)dice.Key, (string)dice.Value);
                        }        
                    }
                    catch (Exception ex)
                    {
                        ALDS_Data = null;
                        return false;
                    }
                    
                    return true;
                }
            }

            

        #endregion 

    }
}
