using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using ALDSDataServerLibrary.Client;
using ALDSDataServerLibrary.Data;
using ALDSDataServerLibrary.Data.Handling;


namespace ALDSDataServerLibrary.Services
{
    public delegate void MachineStopped(String machineName);
    public delegate void WebNotificationSuccesfully(String machineName);
    public delegate void MachineResumeOperation(String machineName);
    public delegate void WebNotificationError(String machineName, string error);

    
    public class ALDSMachineOperationMonitor
    {
        #region < DATA MEMBERS  > 

            private ALDSDataClient _client;
            private MachineOperationManager _manager;
            private string _ALDSDBConnectionString;
            private int _linenumber; 

        
        #endregion 

        #region < CONSTRUCTOR >
        
            public ALDSMachineOperationMonitor(int linenumber, string ALDSHostName, string ALDSDBConnectionString)
            {
                this._client = new ALDSDataClient(ALDSHostName);
                this._client.Connect();
                this._client.DataReceived +=new DataReceivedFromALDSDataServer(_client_DataReceived);
                this._manager = new MachineOperationManager();
                this._manager.MachineIsStopped +=new MachineHasStopped(_manager_MachineIsStopped);
                this._manager.MachineHasResumedOperation +=new MachineResumedOperation(_manager_MachineHasResumedOperation);
                this._ALDSDBConnectionString = ALDSDBConnectionString;
                this._linenumber = linenumber;
            }
        
        #endregion

        #region < PROEPRTIES > 

            public ALDSDataClient ALDSClient
            {
                get
                {
                    return this._client;
                }
            }

        #endregion 

        #region< EVENTS > 

            public event MachineStopped MachineStopped;
            public event MachineResumeOperation MachineResumeOperation;
            public event WebNotificationSuccesfully WebNotificationSuccesfully;
            public event WebNotificationError WebNotificationError;


        #endregion 

        #region < EVENT HANDLING >

            private void _client_DataReceived(ALDSDataClient sender, ALDSData dataReceived)
            {
                if (dataReceived is MachineStatusData)
                {
                    MachineStatusData statusData = (MachineStatusData)dataReceived;

                    if (statusData.Status != MachineStatus.failure)
                    {
                        this._manager.HandleMachineStatus(statusData.MachineName, statusData.Status);                    }         
                    else
                    {
                         if (MachineStopped != null)
                             MachineStopped(statusData.MachineName);

                       
                         this.notifyMachineStatus(this._linenumber, statusData.MachineName);
                     
                    }
                }
            }

            private void _manager_MachineIsStopped(string machineName)
            {
                if (MachineStopped != null)
                    MachineStopped(machineName);
                //interface to push an http notification             
                this.notifyMachineStatus(this._linenumber, machineName);
             
            }

            private void _manager_MachineHasResumedOperation(string machineName)
            {
                if (MachineResumeOperation != null)
                    MachineResumeOperation(machineName);
              

            }


        #endregion

        #region < PRIVATE METHODS  >

            private int GetStationNumberFromName(string machineName)
            {
                int machineNumber = -1;
                //this._ALDSDBConnectionString = "Server=P02036336\\SQLEXPRESS;Database=AldsTC8;User Id=AIS_ALDS;Password=23erghiop0";  // for testing purposes only
                string query = "select DisplayName from station where id = '" + machineName + "'";

                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._ALDSDBConnectionString))
                {
                    cnn.Open();
                    using(System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = query;

                        System.Data.SqlClient.SqlDataReader reader =  cmd.ExecuteReader();
                        if (reader != null)
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                string displayName = (String)reader["DisplayName"];
                                string[] elements1 = displayName.Split('(');
                                if (elements1.Count<string>() >= 2)
                                {
                                    string machineNumberString;
                                    string token1 = elements1[1];
                                    string[] elements2 = token1.Split(')');
                                    string token2 = elements2[0];
                                    if (token2.Contains('.'))
                                    {
                                        string[] elements3 = token2.Split('.');
                                        machineNumberString  = elements3[0];
                                        Boolean result = int.TryParse(machineNumberString, out machineNumber);
                                        if (!result)
                                        {
                                            throw new Exception("CAn not parse station number from Display Name [ " + machineNumberString + " ] ");
                                        }
                                    }
                                    else
                                    {
                                        machineNumberString = token2.Replace(")", "");
                                        Boolean result = int.TryParse(machineNumberString, out machineNumber);
                                        if (!result)
                                        {
                                            throw new Exception("CAn not parse station number from Display Name");
                                        }
                                    }
                                }
                                else
                                {
                                    throw new Exception("CAn not parse station number from Display Name");
                                }
                            }
                            else
                            {
                                throw new Exception("Can not retrieve machine Display Name for machine [" + machineName + " ] ");
                            }
                        }
                        else
                        {
                            throw new Exception("Can not retrieve machine Display Name for machine [" + machineName + " ] ");
                        }
                    }
                }


                return machineNumber;
            }

            private string GetRegisterID(string WebResponse)
            {
                string REgisterID = "";

                //string {"htid":"0","ID_REGISTRO":"30"}              
                string[] elements1 = WebResponse.Split(',');
                string registerToken = elements1[1];
                string[] elements2 = registerToken.Split(':');
                REgisterID = elements2[1];
                REgisterID = REgisterID.Replace("}","");
                REgisterID = REgisterID.Replace(@"\", "");
                REgisterID = REgisterID.Replace("\"", "");
                REgisterID = REgisterID.Replace(@"\r", "");
                REgisterID = REgisterID.Replace(@"\n", "");
                return REgisterID;

            }

            private void notifyMachineStatus(int linea, string MachineName)
            {
                try
                {
                    int machineNumber = this.GetStationNumberFromName(MachineName);
                    

                    string requestUriString = string.Concat(new object[]
			        {
				        "http://www.octavioparedes.com.mx/ANDON/nuevo.php?linea=",
				        linea,
				        "&estacion=",
				        machineNumber,
				        "&htid=0"
			        });
                 

                    WebRequest webRequest = WebRequest.Create(requestUriString);
                    HttpWebRequest request = (HttpWebRequest)webRequest;                  
                    request.Proxy.Credentials = new NetworkCredential("tpm_lub", "?Cde1234", "schaeffler");
                    HttpWebResponse httpWebResponse = (HttpWebResponse)webRequest.GetResponse();
                    string text2;
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string text = streamReader.ReadToEnd();
                        text2 = text;
                    }
                    string json = text2;
               
                    string registerID = this.GetRegisterID(json);

                    string requestUriString2 = string.Concat(new object[]
			        {
				        "http://www.octavioparedes.com.mx/ANDON/pushTest.php?LINEA=",
				        linea,
				        "&ESTACION=",
				        machineNumber,
				        "&ID_REGISTRO=",
				        registerID
			        });
                    WebRequest webRequest2 = WebRequest.Create(requestUriString2);
                    HttpWebRequest request2 = (HttpWebRequest)webRequest2;
                    request2.Proxy.Credentials = new NetworkCredential("tpm_lub", "?Cde1234", "schaeffler");

                    HttpWebResponse httpWebResponse2 = (HttpWebResponse)webRequest2.GetResponse();
                    using (StreamReader streamReader2 = new StreamReader(httpWebResponse2.GetResponseStream()))
                    {
                        string text4 = streamReader2.ReadToEnd();
                    }

                    if (WebNotificationSuccesfully != null)
                        WebNotificationSuccesfully(MachineName);

                }
                catch (Exception ex)
                {
                    if (WebNotificationError != null)
                        WebNotificationError(MachineName, ex.Message);

                }
            }


        #endregion

        #region < >

        #endregion


    }
}
