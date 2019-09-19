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






namespace ALDSDataServerLibrary.Server
{  
    
    public class ALDSDataServer
    {
        #region < DATA MEMBERS > 

            private static ALDSDataServer _ALDSDataServer;
            internal const int ALDS_DATA_SERVER_PORT = 9500;
            
            private SocketsServer _DataSocketServer;
            private int _dataReceptionCount;
            private long _dataBroadCastedCounter;


        #endregion 
        
        #region < CONSTRUCTORS >


            private ALDSDataServer()
            {
                this._DataSocketServer = new SocketsServer(ALDS_DATA_SERVER_PORT);   
            }


        #endregion

        #region < EVENT HANDLING  > 
        
        #endregion

        #region < PUBLIC METHODS > 

            public void DistributeData(ALDSData data)
            {
                SocketData dat = data.GetDistributableData();
                this._DataSocketServer.BroadCastData(dat);
            }

        #endregion 

        #region < PATTERN IMPLEMENTATION  >

            #region < SINGLETON  >

                public static ALDSDataServer GetInstance()
                {
                    if (_ALDSDataServer == null)
                    {
                        _ALDSDataServer = new ALDSDataServer();
                    }
                    return  _ALDSDataServer ;
                }


            #endregion


        #endregion




    }
}
