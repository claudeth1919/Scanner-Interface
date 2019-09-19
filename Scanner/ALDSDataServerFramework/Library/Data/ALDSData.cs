using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using UtilitiesLibrary.Data;


namespace ALDSDataServerLibrary.Data
{
    public class ALDSData
    {
        #region < DATA MEMBERS  > 


            //defined the message ID 
            private string _messageID;
            private UtilitiesLibrary.Data.CustomHashTable _attributesTable; 

        #endregion 

        #region < PROPERTIES > 

            protected CustomHashTable AttributesTable
            {
                get
                {
                    return this._attributesTable;
                }
            }

            public string DataID
            {
                get
                {
                    return this._messageID;
                }
            }


        #endregion 

        #region < CONSTRUCTOR >

            public ALDSData(string MessageID)
            {
                this._messageID = MessageID.ToUpper();
                this._attributesTable = new CustomHashTable();
            }

        #endregion

        
        #region < PUBLIC METHODS >

            public SocketData GetDistributableData()
            {
                SocketData data = new SocketData(this.DataID, this._attributesTable);
                return data;
            }

        #endregion


        #region < PROTECTED METHODS  > 

            public void AttachDataAttribute(string DataName, string dataValue )
            {
                this._attributesTable.Add(DataName, dataValue);
            }


            public string GetData(string DataName)
            {
                return this._attributesTable.Item(DataName);               
            }
        #endregion 


    }
}
