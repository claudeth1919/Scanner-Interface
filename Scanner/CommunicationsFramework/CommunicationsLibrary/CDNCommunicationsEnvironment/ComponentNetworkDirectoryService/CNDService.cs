using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using System.Net;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.EventLoging;
using CommunicationsLibrary.Services;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using System.Net;



namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		public class CNDService : IUseP2PCommunicationsScheme, IDisposable
		{
			
			
#region  < DATAMEMBERS >
			//************************************************************************
			
			private static CNDService _CND;
			private CNDTable _CNDTable;
			//Private WithEvents _serviceSocketsServer As SocketsServer
			private P2PPort _serviceP2PPort;
			private string _hostName;
            private string _IPAddress;
			
			private CNDRemoteComponentLinkHandlerTable _remoteComponentLinkTable;
			
			private DataTable _serviceParametersTable;
			
			//variables to handle the network service
			private DiscoverableServiceDefinitionHandlingServer _stxServiceHandler;
			private DiscoverableServiceDefinitionParametersContainer _STXServicePArametersCont;
			
			private MultiCastDataReplicationServer _MultiCastDataReplicationServer;
			
			
			
			
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			
			private CNDService()
			{
				
				this._remoteComponentLinkTable = new CNDRemoteComponentLinkHandlerTable();
				this._remoteComponentLinkTable.LinkWithRemoteComponentHasBroken += this.LinkWithRemoteComponentHasBroken;
				
				//************************************************************************************
				//CREATION THE DEFAULT P2P PORT OF THE SERVICE
				try
				{
					this._serviceP2PPort = new P2PPort(this, CNDServiceDefinitions.CND_SERVICE_DEFAULT_PORT);
				}
				catch (Exception ex)
				{
					string msg = " Error starting the default P2PPort of CND service : " + ex.Message;
                    CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
					
					this._serviceP2PPort = new P2PPort(this);
					
					msg = "The CND Service default P2PPort was started using a dinamic port number \'" + System.Convert.ToString(this._serviceP2PPort.ListeningPortNumber) + "\' out of the CND service range (" + System.Convert.ToString(CNDCommunicationsEnvironmentDefinitions.INITIAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT) + "-" + System.Convert.ToString(CNDCommunicationsEnvironmentDefinitions.FINAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT) + ")";
                    CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
				}
				
				//************************************************************************************
				//CREATION THE MULTICASTING DATA REPLICATOR SERVER
				try
				{
					this._MultiCastDataReplicationServer = new MultiCastDataReplicationServer(CNDServiceDefinitions.CND_SERVICE_MULTICAST_IP_ADDRESS, CNDServiceDefinitions.CND_SERVICE_MULTICAST_PORT);
				}
				catch (Exception ex)
				{
					string msg = " Error starting a multicast port for CND service : " + ex.Message;
                    CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
					
					this._MultiCastDataReplicationServer = new MultiCastDataReplicationServer();
					
					msg = "The CND service Multicast Server was started using a dinamic port number \'" + System.Convert.ToString(this._MultiCastDataReplicationServer.MultiCastPortNumber) + "\' out of the CND service range (" + System.Convert.ToString(CNDCommunicationsEnvironmentDefinitions.INITIAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT) + "-" + System.Convert.ToString(CNDCommunicationsEnvironmentDefinitions.FINAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT) + ")";
                    CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
					
				}
				
				this.LoadCNDTableFromFileOrCreateAndEmptyTableIfNotExists();
				
				this._hostName = System.Net.Dns.GetHostName();
				//crates the service parameters to publish throuGh the STXServiceDefinitionHandlerServer
				this._STXServicePArametersCont = new DiscoverableServiceDefinitionParametersContainer();
                this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_NAME, System.Convert.ToString(CNDServiceDefinitions.CNDSERVICE_PUBLIC_NAME));
				this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_HOSTNAME, System.Convert.ToString(this._hostName));
                this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS, this._serviceP2PPort.IPAddress.ToString());
				this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER, System.Convert.ToString(this._serviceP2PPort.ListeningPortNumber));
				this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS, System.Convert.ToString(this._MultiCastDataReplicationServer.MultiCastIPAddress));
				this._STXServicePArametersCont.AddParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER, System.Convert.ToString(this._MultiCastDataReplicationServer.MultiCastPortNumber));
				
				this._STXServicePArametersCont.SaveToFile(CNDServiceDefinitions.CND_SERVICE_SERVICE_PARAMETERS_TABLE_FILENAME);
				
				this._serviceParametersTable = new DataTable("CND Service Parameters");
				this._serviceParametersTable.Columns.Add("Parameter Name");
				this._serviceParametersTable.Columns.Add("Parameter Value");
				IEnumerator enumm = this._STXServicePArametersCont.ParametersTable.GetEnumerator();
				string paramName = "";
				string ParamValue = "";
				DataRow paramRow = default(DataRow);
				while (enumm.MoveNext())
				{
					paramName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
					ParamValue = System.Convert.ToString(((DictionaryEntry) enumm.Current).Value);
					paramRow = this._serviceParametersTable.NewRow();
					paramRow[0] = paramName;
					paramRow[1] = ParamValue;
					this._serviceParametersTable.Rows.Add(paramRow);
				}
				
				//creates the service handler as singleton
				this._stxServiceHandler = new DiscoverableServiceDefinitionHandlingServer(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode.singletonInstanceNetworkService, CNDServiceDefinitions.CNDSERVICE_PUBLIC_NAME, this._STXServicePArametersCont);

                CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "CND Service started succesfully @ " + this._hostName + " on " + DateTime.Now.ToString());
				
			}
			
			
#endregion
			
#region  < EVENTS >
			
			public delegate void CNDTableStatusChangedEventHandler();
			private CNDTableStatusChangedEventHandler CNDTableStatusChangedEvent;
			
			public event CNDTableStatusChangedEventHandler CNDTableStatusChanged
			{
				add
				{
					CNDTableStatusChangedEvent = (CNDTableStatusChangedEventHandler) System.Delegate.Combine(CNDTableStatusChangedEvent, value);
				}
				remove
				{
					CNDTableStatusChangedEvent = (CNDTableStatusChangedEventHandler) System.Delegate.Remove(CNDTableStatusChangedEvent, value);
				}
			}
			
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			public static CNDService GetInstance()
			{
				if (_CND == null)
				{
					_CND = new CNDService();
				}
				return _CND;
			}
			
#endregion
			
#region  <  PROPERTIES >
			
internal CNDTable CNDTable
			{
				get
				{
					return this._CNDTable;
				}
			}
			
public DataTable ComponentNetworkDirectoryTable
			{
				get
				{
					return this._CNDTable.DataTable;
				}
			}
			
public DataTable ServiceParametersTable
			{
				get
				{
					return this._serviceParametersTable;
				}
			}
			
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void LinkWithRemoteComponentHasBroken(string ComponentName)
			{
				try
				{
					this.UnsubsribeComponent(ComponentName);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private bool ISPreviousServiceRunningOnTheNetwork()
			{
				DiscoverableServiceDefinitionHandlingClient STXServiceClient = null;
				try
				{
					DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDefinition;
					STXServiceClient = new DiscoverableServiceDefinitionHandlingClient(Guid.NewGuid().ToString());
					serviceDefinition = STXServiceClient.FindService(CNDServiceDefinitions.CNDSERVICE_PUBLIC_NAME);
					return true;
				}
				catch (Services.DiscoverableServiceHandling.DiscoverableServiceDefinitionHandlingSearchFailureException)
				{
					//the service wasn't found runing on the network
					return false;
				}
				catch (Exception)
				{
					return false;
				}
				finally
				{
					try
					{
						STXServiceClient.Dispose();
					}
					catch (Exception)
					{
					}
				}
			}
			
#region  < CND TABLE MANAGING>
			
			private static string GetFileTableName()
			{
				string serializedFilePathName = System.AppDomain.CurrentDomain.BaseDirectory + CNDServiceDefinitions.CND_TABLE_FILE_NAME;
				return serializedFilePathName;
			}
			
			private void LoadCNDTableFromFileOrCreateAndEmptyTableIfNotExists()
			{
				if (System.IO.File.Exists(GetFileTableName()))
				{
					this.LoadCNDTable();
				}
				else
				{
					this._CNDTable = new CNDTable();
				}
			}
			
			private void LoadCNDTable()
			{
				this._CNDTable = null;
				System.IO.FileStream fs = null;
				try
				{
					fs = new System.IO.FileStream(GetFileTableName(), System.IO.FileMode.Open);
					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					this._CNDTable = (CNDTable) (formatter.Deserialize(fs));
				}
				catch (Exception)
				{
					if (this._CNDTable == null)
					{
						this._CNDTable = new CNDTable();
					}
				}
				finally
				{
					try
					{
						fs.Close();
					}
					catch (Exception)
					{
					}
				}
			}
			
			private void SaveCNDTable()
			{
				
			}
			
			private void BroadCastNewRegistryInsertion(CNDAddressingReg CNDTableReg)
			{
				SocketData dsReg = new SocketData(CNDServiceDefinitions.CND_NEW_REGISTRATION_INSERT, CNDServiceDefinitions.CND_NEW_REGISTRATION_INSERT);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.COMPONENT_NAME, CNDTableReg.ComponentName);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.HOST_NAME, CNDTableReg.HostName);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.P2P_PORT_NUMBER, System.Convert.ToString(CNDTableReg.P2PPortNumber));
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.IP_ADDRESS, CNDTableReg.IPAddress);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.APPLICATION_NAME, CNDTableReg.AppDomain);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.APPLICATION_PROCESS_ID, System.Convert.ToString(CNDTableReg.ProcessID));
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.REGISTRATION_DATETIME, CNDTableReg.SubscriptionDateTime);
				byte[] compressedData = null;
				compressedData = UtilitiesLibrary.Services.DataCompression.DataCompressionUtilities.CompressData(dsReg.DataBytes);
				this._MultiCastDataReplicationServer.BroadCastData(compressedData);
			}
			
			private void BroadCastRegistryRemoval(CNDAddressingReg CNDTableReg)
			{
				SocketData dsReg = new SocketData(CNDServiceDefinitions.CND_EXISTING_REGISTRATION_REMOVE, CNDServiceDefinitions.CND_EXISTING_REGISTRATION_REMOVE);
				dsReg.AttributesTable.AddAttribute(CNDServiceDefinitions.COMPONENT_NAME, CNDTableReg.ComponentName);
				byte[] compressedData = null;
                compressedData = UtilitiesLibrary.Services.DataCompression.DataCompressionUtilities.CompressData(dsReg.DataBytes);
				this._MultiCastDataReplicationServer.BroadCastData(compressedData);
			}
			
			private void SubscribeComponent(string ComponentName, string HostName, string ipAdress, int P2PPortNumber, string AppName, string ProcessID)
			{
				//'creates a new registration and adds to the directory
				//Dim newReg As CNDAddressingReg = New CNDAddressingReg(ComponentName, HostName, ipAdress, listeningTCPPort, AppName, ProcessID, Now)
				ComponentName = ComponentName.ToUpper();
				if (this.CNDTable.ContainsComponentRegistry(ComponentName))
				{
					this.UnsubsribeComponent(ComponentName);
				}
				this.CNDTable.AddComponentRegistry(ComponentName, HostName, ipAdress, P2PPortNumber, AppName, ProcessID);
				CNDAddressingReg reg = this.CNDTable.GetCNDAddressingRegister(ComponentName);
				this._remoteComponentLinkTable.CreateLinkWithRemoteComponent(reg);
				this.SaveCNDTable();
				this.BroadCastNewRegistryInsertion(reg);
				try
				{
					if (CNDTableStatusChangedEvent != null)
						CNDTableStatusChangedEvent();
				}
				catch (Exception)
				{
				}
			}
			
			private void UnsubsribeComponent(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				if (this.CNDTable.ContainsComponentRegistry(ComponentName))
				{
					CNDAddressingReg reg = this.CNDTable.GetCNDAddressingRegister(ComponentName);
					
					this.CNDTable.RemoveComponentRegistry(ComponentName);
					this._remoteComponentLinkTable.DestroyLinkWithRemoteComponent(ComponentName);
					this.SaveCNDTable();
					
					this.BroadCastRegistryRemoval(reg);
					
					try
					{
						if (CNDTableStatusChangedEvent != null)
							CNDTableStatusChangedEvent();
					}
					catch (Exception)
					{
					}
				}
			}
			
#endregion
			
#region  < P2P CLIENT DATA REQUEST HANDLING  >
			
			private P2PData Handle_GetComponentAddressingRegistry_Request(P2PDataRequest request)
			{
				string componentName = "";
				componentName = request.GetRequestParameter(CNDServiceDefinitions.COMPONENT_NAME);
				if (componentName == null)
				{
					throw (new Exception("Can\'t resolve the Addressing because the paramter \'COMPONENT_NAME\' was missing in the data request."));
				}
				if (!this.CNDTable.ContainsComponentRegistry(componentName))
				{
					throw (new Exception("Can\'t resolve the Addressig for component \'" + componentName + "\' because is not registered on the Service"));
				}
				CustomHashTable cnsREgister = this.CNDTable.GetComponentRegistry(componentName);
				P2PData register = new P2PData("CND_ADDRESSING_REGISTER", cnsREgister);
				return register;
			}
			
			private void Handle_ComponentRegistration_Data(P2PData data)
			{
				UtilitiesLibrary.Data.CustomHashTable table = default(UtilitiesLibrary.Data.CustomHashTable);
				table = (CustomHashTable) data.Value;
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[Component Name]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_HOST_NAME))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[Hostname]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[P2PPortNumber]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[IPAddress]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[Application Name]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID))
				{
					throw (new Exception("Can\'t register a component in CNDService becuase the parameter \'[Application Process ID]\' is missing."));
				}
				
				string compName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME));
				compName = compName.ToUpper();
				string hostName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_HOST_NAME));
				string P2PPortNumber = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER));
				string IPAddress = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS));
				string ApplicationName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME));
				string ApplicationProcessID = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID));
                
                int portNumber = Convert.ToInt32(P2PPortNumber);
                this.SubscribeComponent(compName, hostName, IPAddress, portNumber, ApplicationName, ApplicationProcessID);
			}
			
			private void Handle_ComponentRegistrationRemoval_Data(P2PData data)
			{
				if (!data.DataAttributesTable.ContainsAttribute(CNDServiceDefinitions.COMPONENT_NAME))
				{
					throw (new Exception("can\'t remove a component registry becuase the parameter \'" + CNDServiceDefinitions.COMPONENT_NAME + " \' is missing"));
				}
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				attr = data.DataAttributesTable.GetAttribute(CNDServiceDefinitions.COMPONENT_NAME);
				string compName = "";
				compName = attr.AttrValue;
				
				this.UnsubsribeComponent(compName);
				
			}
			
			
#endregion
			
			
#endregion
			
#region  < FRIEND METHODS >
			
			public CustomHashTable ResolveAddress(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				if (this.CNDTable.ContainsComponentRegistry(ComponentName))
				{
					return this.CNDTable.GetComponentRegistry(ComponentName);
				}
				else
				{
					return null;
				}
			}
			
			
#endregion
			
#region  < PUBLIC METHODS  >
			
			public void ExportServerParametersToFile(string filePath)
			{
				this._STXServicePArametersCont.SaveToFile(filePath, CNDServiceDefinitions.CND_SERVICE_SERVICE_PARAMETERS_TABLE_FILENAME);
			}
			
			
#endregion
			
#region  < FRIEND SHARED METHODS >
			
			internal static DiscoverableServiceDefinitionParametersContainer GetLocalHostServiceDefaultParameters()
			{
				
				string hostNAme = Dns.GetHostName();
				
				DiscoverableServiceDefinitionParametersContainer parameters = new DiscoverableServiceDefinitionParametersContainer();
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_NAME, System.Convert.ToString(CNDServiceDefinitions.CNDSERVICE_PUBLIC_NAME));
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_HOSTNAME, System.Convert.ToString(hostNAme));
                IPAddress LocalActiveIPAddress = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetActiveIPAddress();
                string IPAdddressAsString = LocalActiveIPAddress.ToString();
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS, System.Convert.ToString(IPAdddressAsString));
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER, System.Convert.ToString(CNDServiceDefinitions.CND_SERVICE_DEFAULT_PORT));
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS, System.Convert.ToString(CNDServiceDefinitions.CND_SERVICE_MULTICAST_IP_ADDRESS));
                parameters.AddParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER, System.Convert.ToString(CNDServiceDefinitions.CND_SERVICE_MULTICAST_PORT));


                return parameters;
				
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IUseP2PNetworkkng >
			
            public string P2PPortOwnerName
			{
				get
				{
					return CNDServiceDefinitions.CNDSERVICE_P2PPORT_OWNERNAME;
				}
			}
			
            public Services.P2PCommunicationsScheme.P2PPort P2PSocketPort
			{
				get
				{
					return this._serviceP2PPort;
				}
			}
			
			public void ReceiveData(Services.P2PCommunicationsScheme.Data.P2PData data, int P2PPortNumber)
			{
				switch (data.DataName)
				{
					case CNDServiceDefinitions.CND_COMPONENT_REGISTRATION_CMD:
						this.Handle_ComponentRegistration_Data(data);
						break;
					case CNDServiceDefinitions.CND_COMPONENT_REGISTRATION_REMOVAL_CMD:
						this.Handle_ComponentRegistrationRemoval_Data(data);
						break;
				}
			}
			
			public Services.P2PCommunicationsScheme.Data.P2PData RetrieveData(Services.P2PCommunicationsScheme.Data.P2PDataRequest request, int P2PPortNumber)
			{
				if (request.RequestedDataName == CNDServiceDefinitions.CND_TABLE_DATA_NAME)
				{
					P2PData cndTable = new P2PData(CNDServiceDefinitions.CND_TABLE_DATA_NAME, this.CNDTable.DataTable);
					return cndTable;
					
					//*****************************************************************
					// !!!!! IMPORTANT EVALUATION
					//this indicates to the connected client that the port belongs to
					//the CND service,
					//*****************************************************************
				}
				else if (request.RequestedDataName == CNDServiceDefinitions.CND_SERVICE_PORT_CONNECTION_CHECK_DATA)
				{
					return new P2PData(CNDServiceDefinitions.CND_SERVICE_PORT_CONNECTION_CHECK_DATA, true);
					//*****************************************************************
					//*****************************************************************
				}
				else if (request.RequestedDataName == CNDServiceDefinitions.CND_GET_COMPONENT_CND_REGISTRY_CMD)
				{
					return this.Handle_GetComponentAddressingRegistry_Request(request);
				}
				else
				{
					throw (new Exception("The CND Service can handle the data named \'" + request.RequestedDataName + "\'"));
				}
			}
			
#endregion
			
#region  < IDisposable >
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						try
						{
							this._serviceP2PPort.Dispose();
						}
						catch (Exception ex)
						{
                            CustomEventLog.WriteEntry(ex);
						}
						//Try
						//    Me._serviceSocketsServer.Dispose()
						//Catch ex As Exception
						//    CustomEventLog.WriteEntry(ex)
						//End Try
						try
						{
							this._stxServiceHandler.Dispose();
						}
						catch (Exception ex)
						{
                            CustomEventLog.WriteEntry(ex);
						}
						
						try
						{
							this._MultiCastDataReplicationServer.Dispose();
						}
						catch (Exception)
						{
						}
						
						string msg = "";
						string hostname = Dns.GetHostName();
						msg = "CND service Shutdown @ " + hostname + "   on   " + DateTime.Now.ToString();
                        CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
						
					}
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
			
#endregion
			
#endregion
			
			
			
		}
		
	}
	
}
