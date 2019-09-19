using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using UtilitiesLibrary.Data;


namespace ALDSDataServerLibrary.Data
{

    public enum MachineStatus 
    {
        manual ,
        automatic ,
        failure
    }

    public class MachineStatusData : ALDSData 
    {
        #region < DATA MEMBERS  > 

            //definition of constants for message 
            private const string MESSAGE_ID = "ALDS_MACHINE_STATUS";
            private const string LINE_NAME = "LINE_NAME";
            private const string MACHINE_NAME = "MACHINE_NAME";
            private const string MACHINE_STATUS = "MACHINE_STATUS";

            private const string STATUS_MANUAL = "MANUAL";
            private const string STATUS_AUTOMATIC = "AUTOMATIC";
            private const string STATUS_FAILURE = "FAILURE";

            //----
            private string _lineName;
            private string _machineName;
            private MachineStatus  _status;


        #endregion

        #region < CONSTRUCTORS  >

            public MachineStatusData(string lineName, string machineName, MachineStatus status)
                : base(MESSAGE_ID) 
            {
                base.AttachDataAttribute(MachineStatusData.LINE_NAME, lineName);
                base.AttachDataAttribute(MachineStatusData.MACHINE_NAME, machineName);
                base.AttachDataAttribute(MachineStatusData.MACHINE_STATUS, status.ToString().ToUpper());
                //
                this._lineName = lineName;
                this._machineName = machineName;
                this._status = status;
            }
        
        #endregion

        #region < PROPERTIES > 

            public string LineName
            {
                get
                {
                    return this._lineName;
                }
            }

            public string MachineName
            {
                get
                {
                    return this._machineName;
                }
            }

            public MachineStatus Status
            {
                get
                {
                    return this._status;
                }
            }


        #endregion 
        
        #region < PRIVATE METHODS >

            private static MachineStatus GetStatusFromString(string status)
            {
                switch (status)
                {
                    case STATUS_MANUAL :
                            return MachineStatus.manual;                      
                    case STATUS_AUTOMATIC :
                        return MachineStatus.automatic;                      
                    case STATUS_FAILURE :
                        return MachineStatus.failure;                      
                    default :
                        throw new Exception ("Can not parse status string " + status + " for ALDS data type [MachineStatusData]" );
                }
            }

        #endregion 

        #region < PUBLIC METHODS >
        
            public static Boolean TryParse(SocketData incommingData, out MachineStatusData resultdata)
            {
                if (incommingData.DataName == MachineStatusData.MESSAGE_ID)
                {
                    string lineName = "";
                    string machineName = "";
                    string statusAsString = "";
                    //we use the custom hashtable that is transportd in the socketData and not the native attributes table
                    CustomHashTable _table = (CustomHashTable)incommingData.Value;


                    if (
                                _table.ContainsKey(MachineStatusData.LINE_NAME)
                                &&
                                 _table.ContainsKey(MachineStatusData.MACHINE_NAME)
                                &&
                                 _table.ContainsKey(MachineStatusData.MACHINE_STATUS)
                        )
                    {
                        lineName = (string) _table.Item(MachineStatusData.LINE_NAME);
                        machineName = (string)_table.Item(MachineStatusData.MACHINE_NAME);
                        statusAsString = (string)_table.Item(MachineStatusData.MACHINE_STATUS);

                        MachineStatus status = GetStatusFromString(statusAsString);
                        resultdata = new MachineStatusData(lineName, machineName, status);
                        //pending to implement 
                        return true;
                    }
                    else
                    {
                        //it is not possible to parse as the ALDS data type requiered
                        resultdata = null;
                        return false;
                    }
                }
                else
                {
                    resultdata = null;
                    return false;
                }
            }
        
        #endregion

        #region < OVERRIDEN METHODS > 

            public override string ToString()
            {
                String tostring = "";
                tostring = "MACHINE STATUS :  " + this._lineName + " -> " + this._machineName + " -> " + this._status.ToString();
                return tostring;

            }


        #endregion

    }
}
