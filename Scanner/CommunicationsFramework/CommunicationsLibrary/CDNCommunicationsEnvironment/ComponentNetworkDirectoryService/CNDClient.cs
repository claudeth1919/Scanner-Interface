using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.Serialization;
using UtilitiesLibrary.EventLoging;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using System.Net;
using System.Windows.Forms;
using System.Threading;




namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		
		public class CNDClient : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			public enum ConnectionMode
			{
				networkBroadCasting,
				localParameters,
				localHost
			}
			
			
			private static CustomHashTable _STXCNDServiceLocalParametersTable = null;
			
			private const string CND_SERVICE_CONNECTION_PARAMS = "CND_SERVICE_CONNECTION_PARAMS";
			
			private CNDTable _localComponentDirectoryTable;
			
			private string _processID;
            private string _ApplicationName;
			private string _remoteHostName;
            private string _remoteHostIPAddress;
			private int _remoteP2PPortNumber;
			private int _remoteSocketsServerPortNumber;
			private string _remoteMultiCastServerIPAddress;
			private int _remoteMultiCastServerPortNumber;
			
			private MultiCastDataReplicatorClient _MultiCastDataReplicatorClient;
			
			private Services.P2PCommunicationsScheme.P2PPortClient _P2PPortClient;
			private DiscoverableServiceDefinitionHandlingClient _STXServiceClient;
            private DiscoverableServiceDefinitionParametersContainer _serviceParameters;
			
			private bool _IsConnected;
			private bool _isREconnectionScheduled;
			private System.Threading.Thread _reconnectionThread;
			
			private System.Timers.Timer _CNDTableUpdateTimer;
			private DateTime _startConnectionTime;
			
			
#endregion
			
#region  < PROPERTIES >
			
    private string ApplicationName
			{
				get
				{
					return this._ApplicationName;
				}
			}
			
private string ProcessID
			{
				get
				{
					return this._processID;
				}
			}
			
public DataTable CNDDataTable
			{
				get
				{
					return this._localComponentDirectoryTable.DataTable;
				}
			}
			
internal CNDTable CNDTable
			{
				get
				{
					return this._localComponentDirectoryTable;
				}
			}

public DataTable ServiceParametersTable
{
    get
    {
        return this._serviceParameters.ParametersDataTable;
    }
}
			
			
#endregion
			
#region  < EVENTS >
			
			public delegate void ConnectionWithServiceLostEventHandler();
			private ConnectionWithServiceLostEventHandler ConnectionWithServiceLostEvent;
			
			public event ConnectionWithServiceLostEventHandler ConnectionWithServiceLost
			{
				add
				{
					ConnectionWithServiceLostEvent = (ConnectionWithServiceLostEventHandler) System.Delegate.Combine(ConnectionWithServiceLostEvent, value);
				}
				remove
				{
					ConnectionWithServiceLostEvent = (ConnectionWithServiceLostEventHandler) System.Delegate.Remove(ConnectionWithServiceLostEvent, value);
				}
			}
			
			public delegate void ComponentRegistrationChangedEventHandler(CNDAddressingReg ComponentCNDRegister);
			private ComponentRegistrationChangedEventHandler ComponentRegistrationChangedEvent;
			
			public event ComponentRegistrationChangedEventHandler ComponentRegistrationChanged
			{
				add
				{
					ComponentRegistrationChangedEvent = (ComponentRegistrationChangedEventHandler) System.Delegate.Combine(ComponentRegistrationChangedEvent, value);
				}
				remove
				{
					ComponentRegistrationChangedEvent = (ComponentRegistrationChangedEventHandler) System.Delegate.Remove(ComponentRegistrationChangedEvent, value);
				}
			}
			
			public delegate void NewComponentRegistrationDetectedEventHandler(CNDAddressingReg ComponentCNDRegister);
			private NewComponentRegistrationDetectedEventHandler NewComponentRegistrationDetectedEvent;
			
			public event NewComponentRegistrationDetectedEventHandler NewComponentRegistrationDetected
			{
				add
				{
					NewComponentRegistrationDetectedEvent = (NewComponentRegistrationDetectedEventHandler) System.Delegate.Combine(NewComponentRegistrationDetectedEvent, value);
				}
				remove
				{
					NewComponentRegistrationDetectedEvent = (NewComponentRegistrationDetectedEventHandler) System.Delegate.Remove(NewComponentRegistrationDetectedEvent, value);
				}
			}
			
			public delegate void ComponentUnregistrationDetectedEventHandler(CNDAddressingReg ComponentCNDRegister);
			private ComponentUnregistrationDetectedEventHandler ComponentUnregistrationDetectedEvent;
			
			public event ComponentUnregistrationDetectedEventHandler ComponentUnregistrationDetected
			{
				add
				{
					ComponentUnregistrationDetectedEvent = (ComponentUnregistrationDetectedEventHandler) System.Delegate.Combine(ComponentUnregistrationDetectedEvent, value);
				}
				remove
				{
					ComponentUnregistrationDetectedEvent = (ComponentUnregistrationDetectedEventHandler) System.Delegate.Remove(ComponentUnregistrationDetectedEvent, value);
				}
			}
			
			public delegate void TableUpdatedByServerEventHandler(DataTable table);
			private TableUpdatedByServerEventHandler TableUpdatedByServerEvent;
			
			public event TableUpdatedByServerEventHandler TableUpdatedByServer
			{
				add
				{
					TableUpdatedByServerEvent = (TableUpdatedByServerEventHandler) System.Delegate.Combine(TableUpdatedByServerEvent, value);
				}
				remove
				{
					TableUpdatedByServerEvent = (TableUpdatedByServerEventHandler) System.Delegate.Remove(TableUpdatedByServerEvent, value);
				}
			}
			
			public delegate void AutoReconnectionWithServicePerformedEventHandler();
			private AutoReconnectionWithServicePerformedEventHandler AutoReconnectionWithServicePerformedEvent;
			
			public event AutoReconnectionWithServicePerformedEventHandler AutoReconnectionWithServicePerformed
			{
				add
				{
					AutoReconnectionWithServicePerformedEvent = (AutoReconnectionWithServicePerformedEventHandler) System.Delegate.Combine(AutoReconnectionWithServicePerformedEvent, value);
				}
				remove
				{
					AutoReconnectionWithServicePerformedEvent = (AutoReconnectionWithServicePerformedEventHandler) System.Delegate.Remove(AutoReconnectionWithServicePerformedEvent, value);
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public CNDClient()
			{
				
				try
				{
					this._processID = System.Convert.ToString(UtilitiesLibrary.UtilitiesModule.GetIndexableGUID());
				}
				catch (Exception)
				{
				}
				this._ApplicationName = System.AppDomain.CurrentDomain.FriendlyName;
				
				this._localComponentDirectoryTable = new CNDTable();
				
				string clientName = "CND_CLIENT_" + Guid.NewGuid().ToString().ToUpper();
				this._STXServiceClient = new DiscoverableServiceDefinitionHandlingClient(clientName);
				
				this._IsConnected = false;
				this._isREconnectionScheduled = false;
				
				this._CNDTableUpdateTimer = new System.Timers.Timer(60000);
				this._CNDTableUpdateTimer.Elapsed += this._CNDTableUpdateTime_Elapsed;

            
				
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void _CNDTableUpdateTime_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._CNDTableUpdateTimer.Stop();
					DataTable dt = this.GetCNDTableFromServer();
					CNDTable temporalCNDTable = new CNDTable(dt);
					//compares the tables before set it
					this.CompareCNDTables(this._localComponentDirectoryTable, temporalCNDTable);
				}
				catch (Exception)
				{
				}
				finally
				{
					this._CNDTableUpdateTimer.Start();
				}
			}

            public void _P2PPortClient_ConnectionLost(P2PPortClient client)
			{
				this._IsConnected = false;
				_STXCNDServiceLocalParametersTable = null;
				
				this.ScheduleAutoReconection();
				
				try
				{
					if (ConnectionWithServiceLostEvent != null)
						ConnectionWithServiceLostEvent();
				}
				catch (Exception)
				{
				}
				
				string msg = "";
				msg = "Connection with CND Service Lost. Client : " + this._STXServiceClient.Name;
                CustomEventLog.WriteEntry(EventLogEntryType.FailureAudit, msg);
				
			}
			
			public void _MultiCastDataReplicatorClient_MultiCastDataReceived(byte[] data)
			{
				try
				{
					
					byte[] decompressedData = null;
                    decompressedData = UtilitiesLibrary.Services.DataCompression.DataCompressionUtilities.DecompressData(data);							
					string xmlString = System.Convert.ToString(System.Text.ASCIIEncoding.ASCII.GetString(decompressedData));
					SocketData socketData = null;
					try
					{
						socketData = SocketData.ParseAndGet_SocketData_FromXMLDataString(xmlString);
						switch (socketData.DataName)
						{
							case CNDServiceDefinitions.CND_TABLE_DATA_NAME:
								DataTable dt = (DataTable) socketData.Value;
								CNDTable temporalCNDTable = new CNDTable(dt);
								//compares the tables before set it
								this.CompareCNDTables(this._localComponentDirectoryTable, temporalCNDTable);
								//sets the local table
								this._localComponentDirectoryTable.SetTable(dt);
								
								try
								{
									if (TableUpdatedByServerEvent != null)
										TableUpdatedByServerEvent(this._localComponentDirectoryTable.DataTable);
								}
								catch (Exception)
								{
								}
								break;
								
							case CNDServiceDefinitions.CND_NEW_REGISTRATION_INSERT:
                                UtilitiesLibrary.Parametrization.Attribute attr_1 = default(UtilitiesLibrary.Parametrization.Attribute);
								string componentName_1 = "";
								string hostName = "";
								string P2PPortNumber = "";
								string IPAddress = "";
								string ApplicationName = "";
								string ApplicationPRocessID = "";
								string registrationDateTime = "";


                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.COMPONENT_NAME);
								componentName_1 = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.HOST_NAME);
								hostName = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.P2P_PORT_NUMBER);
								P2PPortNumber = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.IP_ADDRESS);
								IPAddress = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.APPLICATION_NAME);
								ApplicationName = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.APPLICATION_PROCESS_ID);
								ApplicationPRocessID = System.Convert.ToString(attr_1.Value);

                                attr_1 = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.REGISTRATION_DATETIME);
								registrationDateTime = System.Convert.ToString(attr_1.Value);

                                int portNumber = Convert.ToInt32(P2PPortNumber);
                                CNDAddressingReg ServerCndReg = new CNDAddressingReg(componentName_1, hostName, IPAddress, portNumber, ApplicationName, ApplicationPRocessID, registrationDateTime);
								
								
								try
								{
									//a) evaluates if the local table contains the component of the remote table
									string localHost = Dns.GetHostName();
									
									if (!_localComponentDirectoryTable.ContainsComponentRegistry(ServerCndReg.ComponentName))
									{
										//the component not exists in the local table
                                        portNumber = Convert.ToInt32(P2PPortNumber); 
										this._localComponentDirectoryTable.AddComponentRegistry(componentName_1, hostName, IPAddress, portNumber , ApplicationName, ApplicationPRocessID);
										CNDAddressingReg LocalCndReg = default(CNDAddressingReg);
										LocalCndReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(componentName_1);
										try
										{
											if (NewComponentRegistrationDetectedEvent != null)
												NewComponentRegistrationDetectedEvent(LocalCndReg);
										}
										catch (Exception)
										{
										}
										
									}
									else
									{
										//b) the register already exists in the local table and evaluates if the server and local registration are the same
										CNDAddressingReg LocalCndReg = default(CNDAddressingReg);
										LocalCndReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(componentName_1);
										
										if (ServerCndReg.HostName == LocalCndReg.HostName)
										{
											if (ServerCndReg.P2PPortNumber != LocalCndReg.P2PPortNumber)
											{
												//the host is the same but the listening port has changed
												try
												{
													if (ComponentRegistrationChangedEvent != null)
														ComponentRegistrationChangedEvent(ServerCndReg);
												}
												catch (Exception)
												{
												}
											}
										}
										else
										{
											//the host is different and incidentally the port must be different
											try
											{
												if (ComponentRegistrationChangedEvent != null)
													ComponentRegistrationChangedEvent(ServerCndReg);
											}
											catch (Exception)
											{
											}
										}
									}
									
								}
								catch (Exception ex)
								{
                                    CustomEventLog.WriteEntry(ex);
								}
								break;
								
							case CNDServiceDefinitions.CND_EXISTING_REGISTRATION_REMOVE:
								UtilitiesLibrary.Parametrization.Attribute attr = default(UtilitiesLibrary.Parametrization.Attribute);
								string componentName = "";
								
								attr = (UtilitiesLibrary.Parametrization.Attribute)socketData.AttributesTable.GetAttribute(CNDServiceDefinitions.COMPONENT_NAME);
								componentName = System.Convert.ToString(attr.Value);
								
								try
								{
									if (this._localComponentDirectoryTable.ContainsComponentRegistry(componentName))
									{
										CNDAddressingReg LocalCndReg = default(CNDAddressingReg);
										LocalCndReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(componentName);
										
										this._localComponentDirectoryTable.RemoveComponentRegistry(componentName);
										if (ComponentUnregistrationDetectedEvent != null)
											ComponentUnregistrationDetectedEvent(LocalCndReg);
										
									}
									
								}
								catch (Exception ex)
								{
                                    CustomEventLog.WriteEntry(ex);
								}
								break;
								
						}
					}
					catch (Exception ex)
					{
						string errmsg = "Error receiving the CND table from server : " + ex.Message;
                        CustomEventLog.WriteEntry(ex);
						return;
					}
				}
				catch (Exception ex)
				{
                    CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
#region  < CONNECTION METHODS >
			
			private void SaveServiceConnectionParametersTableToFile(Hashtable table)
			{
				try
				{
					ObjectSerializer.SerializeObjectToFile(table, CND_SERVICE_CONNECTION_PARAMS);
				}
				catch (Exception)
				{
				}
			}
			
			private bool ConnectTriyingLocalHost()
			{
				DiscoverableServiceDefinitionParametersContainer cnnParams = CNDService.GetLocalHostServiceDefaultParameters();
				if (!(cnnParams == null))
				{
					this._startConnectionTime = DateTime.Now;
					this.ConnectToService(ConnectionMode.localHost, cnnParams.ParametersTable);
					return true;
				}
				else
				{
					return false;
				}
			}
			
			private bool ConnectUsingLocalKnownConfiguration()
			{
				DiscoverableServiceDefinitionParametersContainer cnnParams = DiscoverableServiceDefinitionParametersContainer.GetLocalServiceParameters(CNDServiceDefinitions.CND_SERVICE_SERVICE_PARAMETERS_TABLE_FILENAME);
				if (!(cnnParams == null))
				{
					this._startConnectionTime = DateTime.Now;
					this.ConnectToService(ConnectionMode.localParameters, cnnParams.ParametersTable);
					return true;
				}
				else
				{
					return false;
				}
				
			}
			
			private void ConnectBySearchingServiceOverNetwork()
			{
				//loads the table of parameters to connecto to the service
				this._startConnectionTime = DateTime.Now;
				if (_STXCNDServiceLocalParametersTable == null)
				{
					_STXCNDServiceLocalParametersTable = this.FindServiceOverNetworkAndGetParametersTableForConnection();
				}
				this.ConnectToService(ConnectionMode.networkBroadCasting, _STXCNDServiceLocalParametersTable);
			}
			
			private void ConnectToService(ConnectionMode mode, UtilitiesLibrary.Data.CustomHashTable serviceParametersTable)
			{
				try
				{
					
					this._remoteHostName = System.Convert.ToString(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_HOSTNAME));
                    this._remoteHostIPAddress = System.Convert.ToString(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS));
					this._remoteP2PPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER));
					this._remoteSocketsServerPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_SOCKETSSERVER_PORTNUMBER));
					this._remoteMultiCastServerIPAddress = System.Convert.ToString(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS));
					this._remoteMultiCastServerPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER));


                    this._P2PPortClient = new Services.P2PCommunicationsScheme.P2PPortClient(this._remoteHostName, this._remoteHostIPAddress, this._remoteP2PPortNumber);
                    this._P2PPortClient.ConnectionLost += this._P2PPortClient_ConnectionLost;
					this._P2PPortClient.Connect();
					
					this._MultiCastDataReplicatorClient = new MultiCastDataReplicatorClient(this._remoteMultiCastServerIPAddress, this._remoteMultiCastServerPortNumber);
					this._MultiCastDataReplicatorClient.MultiCastDataReceived += this._MultiCastDataReplicatorClient_MultiCastDataReceived;
					this._MultiCastDataReplicatorClient.Connect();
					
					this.GetCNDTableFromServer();
					
					this._IsConnected = true;
					
					
					TimeSpan span = this._startConnectionTime.Subtract(DateTime.Now);
					int ms = (int) (Math.Abs(span.TotalMilliseconds));
                    CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Client \'" + this._STXServiceClient.Name + "\' connected succesfully with CND Service using [" + mode.ToString() + "] connection mode (" + System.Convert.ToString(ms) + " ms)");
					
					this._CNDTableUpdateTimer.Start();

                    //conenction with service was succesfull the fills the connection parameters 
                    this._serviceParameters = new DiscoverableServiceDefinitionParametersContainer(serviceParametersTable);
                                        

					
				}
				catch (Exception ex)
				{
					this._IsConnected = false;
					_STXCNDServiceLocalParametersTable = null;
					
					try
					{
						this._P2PPortClient.Disconnect();
						this._P2PPortClient.Dispose();
					}
					catch (Exception)
					{
					}
					
					string errMsg = "";
					switch (mode)
					{
						case ConnectionMode.localParameters:
							errMsg = "Failed to connect to CND SERVICE using local parameters table : " + ex.Message;
							break;
						case ConnectionMode.localHost:
							errMsg = "Failed to connect to CND SERVICE trying on local host : " + ex.Message;
							break;
						case ConnectionMode.networkBroadCasting:
							errMsg = "Failed to connect to CND SERVICE trying network broadcasting : " + ex.Message;
							break;
						default:
							errMsg = ex.Message;
							break;
					}
					
					throw (new Exception(errMsg, ex));
					
				}
				
			}
			
			private CustomHashTable FindServiceOverNetworkAndGetParametersTableForConnection()
			{
				
				DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDefinition = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
				DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
				serviceDefinition = this._STXServiceClient.FindService(CNDServiceDefinitions.CNDSERVICE_PUBLIC_NAME);
				
				CustomHashTable localFcnParametersTable = new CustomHashTable();
				
				
				//GETS THE HOST WHERE THE SERVICE IS RUNNING
				if (!serviceDefinition.ServiceParameters.ContainsParameter(CNDServiceDefinitions.CND_SERVICE_HOSTNAME))
				{
					throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the paramter \'" + CNDServiceDefinitions.CND_SERVICE_HOSTNAME + "\'"));
				}
				param = serviceDefinition.ServiceParameters.GetParameter(CNDServiceDefinitions.CND_SERVICE_HOSTNAME);
				localFcnParametersTable.Add(CNDServiceDefinitions.CND_SERVICE_HOSTNAME, param.Value);
				
                //GETS THE IP ADDRESS WHERE THE SERVICE IS RUNNING 
                if (!serviceDefinition.ServiceParameters.ContainsParameter(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS))
                {
                    throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the paramter \'" + CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS + "\'"));
                }
                param = serviceDefinition.ServiceParameters.GetParameter(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS);
                localFcnParametersTable.Add(CNDServiceDefinitions.CND_SERVICE_IP_ADDRESS, param.Value);

               
				//GETS THE P2P LISTENING PORT OF THE SERVICE
				if (!serviceDefinition.ServiceParameters.ContainsParameter(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER))
				{
					throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER + "\'"));
				}
				param = serviceDefinition.ServiceParameters.GetParameter(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER);
				localFcnParametersTable.Add(CNDServiceDefinitions.CND_SERVICE_P2PPORT_PORTNUMBER, System.Convert.ToInt32(param.Value));
				
				//gets the CND_SERVICE_MULTICASTSERVER_IP_ADDRESS
				if (!serviceDefinition.ServiceParameters.ContainsParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS))
				{
					throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS + "\'"));
				}
				param = serviceDefinition.ServiceParameters.GetParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS);
				localFcnParametersTable.Add(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_IP_ADDRESS, System.Convert.ToString(param.Value));
				
				//gets the CND_SERVICE_MULTICASTSERVER_PORTNUMBER
				if (!serviceDefinition.ServiceParameters.ContainsParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER))
				{
					throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER + "\'"));
				}
				param = serviceDefinition.ServiceParameters.GetParameter(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER);
				localFcnParametersTable.Add(CNDServiceDefinitions.CND_SERVICE_MULTICASTSERVER_PORTNUMBER, System.Convert.ToInt32(param.Value));
				
				return localFcnParametersTable;
				
			}
			
			
			
#endregion
			
#region  < RECONNECTION METHODS >
			
			private void ScheduleAutoReconection()
			{
				if (this._isREconnectionScheduled == false)
				{
					this._isREconnectionScheduled = true;
					this._reconnectionThread = new System.Threading.Thread(new System.Threading.ThreadStart(AutoReconnectionThreadedFcn));
					this._reconnectionThread.IsBackground = true;
					this._reconnectionThread.Start();
                    CustomEventLog.WriteEntry(EventLogEntryType.Information, "Automatic connection task with CND service was scheduled. Client : " + this._STXServiceClient.Name);
				}
			}
			
			private void StopAutoReconection()
			{
				try
				{
					this._isREconnectionScheduled = false;
					this._reconnectionThread.Abort();
				}
				catch (Exception)
				{
				}
			}
			
			private void AutoReconnectionThreadedFcn()
			{
				
				this._isREconnectionScheduled = true;
				
				while (true)
				{
					
					if (!_IsConnected)
					{
						
						try
						{
							this.ConnectTriyingLocalHost();
                            CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with CND service was performed. Client : " + this._STXServiceClient.Name);
							_isREconnectionScheduled = false;
							try
							{
								if (AutoReconnectionWithServicePerformedEvent != null)
									AutoReconnectionWithServicePerformedEvent();
							}
							catch (Exception)
							{
							}
							return;
						}
						catch (Exception exHost)
						{
                            CustomEventLog.DisplayEvent(EventLogEntryType.Error, exHost.Message);
							try
							{
								if (!this.ConnectUsingLocalKnownConfiguration())
								{
									try
									{
										this.ConnectBySearchingServiceOverNetwork();
										_isREconnectionScheduled = false;
										CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with CND service was performed. Client : " + this._STXServiceClient.Name);
										try
										{
											if (AutoReconnectionWithServicePerformedEvent != null)
												AutoReconnectionWithServicePerformedEvent();
										}
										catch (Exception)
										{
										}
										return;
									}
									catch (Exception)
									{
									}
								}
								else
								{
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with CND service was performed. Client : " + this._STXServiceClient.Name);
									_isREconnectionScheduled = false;
									try
									{
										if (AutoReconnectionWithServicePerformedEvent != null)
											AutoReconnectionWithServicePerformedEvent();
									}
									catch (Exception)
									{
									}
									return;
								}
							}
							catch (Exception ex)
							{
								CustomEventLog.DisplayEvent(EventLogEntryType.Error, ex.Message);
								try
								{
									this.ConnectBySearchingServiceOverNetwork();
									_isREconnectionScheduled = false;
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with CND service was performed. Client : " + this._STXServiceClient.Name);
									try
									{
										if (AutoReconnectionWithServicePerformedEvent != null)
											AutoReconnectionWithServicePerformedEvent();
									}
									catch (Exception)
									{
									}
									return;
								}
								catch (Exception)
								{
								}
							}
						}
					}
					else
					{
						_isREconnectionScheduled = false;
						return;
					}
					System.Threading.Thread.Sleep(1500);
				}
			}
			
#endregion
			
			private void CompareCNDTables(CNDTable localTable, CNDTable serverTable)
			{
				IEnumerator enumm = default(IEnumerator);
				enumm = serverTable.GetEnumerator();
				CNDAddressingReg ServerCndReg = default(CNDAddressingReg);
				
				while (enumm.MoveNext())
				{
                    ServerCndReg = (CNDAddressingReg)enumm.Current;
					//a) evaluates if the local table contains the component of the remote table
					if (!localTable.ContainsComponentRegistry(ServerCndReg.ComponentName))
					{
						try
						{
							if (NewComponentRegistrationDetectedEvent != null)
								NewComponentRegistrationDetectedEvent(ServerCndReg);
						}
						catch (Exception)
						{
						}
					}
					else
					{
						//b) evaluates if the server and local registration is the same
						CNDAddressingReg LocalCndReg = default(CNDAddressingReg);
						LocalCndReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(ServerCndReg.ComponentName);
						
						if (ServerCndReg.HostName == LocalCndReg.HostName)
						{
							if (ServerCndReg.P2PPortNumber != LocalCndReg.P2PPortNumber)
							{
								//the host is the same but the listening port has changed
								try
								{
									if (ComponentRegistrationChangedEvent != null)
										ComponentRegistrationChangedEvent(ServerCndReg);
								}
								catch (Exception)
								{
								}
							}
						}
						else
						{
							//the host is different and incidentally the port must be different
							try
							{
								if (ComponentRegistrationChangedEvent != null)
									ComponentRegistrationChangedEvent(ServerCndReg);
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			
			private string GetLocalHostName()
			{
				return Dns.GetHostName();
			}
			
			private string GetLocalHostIpAddress()
			{
				IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
				IPAddress curhostIPAdd = default(IPAddress);
				curhostIPAdd = host.AddressList[0];
				return curhostIPAdd.ToString();
			}
			
			private CNDAddressingReg ResolveComponentAddressingFromServer(string ComponentName)
			{
				try
				{
					CNDAddressingReg CNDReg = default(CNDAddressingReg);
					
					P2PDataRequest req = new P2PDataRequest(CNDServiceDefinitions.CND_GET_COMPONENT_CND_REGISTRY_CMD);
					req.AddRequestParameter(CNDServiceDefinitions.COMPONENT_NAME, ComponentName);
					P2PData dat = default(P2PData);
					
					dat = this._P2PPortClient.RetrieveData(req);
					if (!(dat == null))
					{
						CustomHashTable table = (UtilitiesLibrary.Data.CustomHashTable) dat.Value;
						CNDReg = CNDTable.GetAddressingRegister(table);
						return CNDReg;
					}
					else
					{
						if (this._localComponentDirectoryTable.ContainsComponentRegistry(ComponentName))
						{
							CNDReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(ComponentName);
							return CNDReg;
						}
						else
						{
							return null;
						}
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
					CNDAddressingReg CNDReg = default(CNDAddressingReg);
					if (this._localComponentDirectoryTable.ContainsComponentRegistry(ComponentName))
					{
						CNDReg = this._localComponentDirectoryTable.GetCNDAddressingRegister(ComponentName);
						return CNDReg;
					}
					else
					{
						return null;
					}
				}
			}
			
			private void CreateComponentRegistrationOnServer(CNDSErviceRegistrationData registration)
			{
				//subscribes in the remote server . . .
				CustomHashTable registrationInfo = new CustomHashTable();
                registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME, registration.ComponentName);
				registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_HOST_NAME, registration.HostName);
				registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER, System.Convert.ToString(registration.ListeningPort));
				registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS, registration.IPAddress.ToString());
				registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME, registration.ApplicationName);
				registrationInfo.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID, this.ProcessID);
				P2PData subscriptionData = new P2PData(CNDServiceDefinitions.CND_COMPONENT_REGISTRATION_CMD, registrationInfo);
				this._P2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, subscriptionData);
			}
			
			private void RemoveComponentRegistrationOnServer(string ComponentName)
			{
				//subscribes in the remote server . . .
				P2PData removalData = new P2PData(CNDServiceDefinitions.CND_COMPONENT_REGISTRATION_REMOVAL_CMD, CNDServiceDefinitions.CND_COMPONENT_REGISTRATION_REMOVAL_CMD);
				removalData.DataAttributesTable.AddAttribute(CNDServiceDefinitions.COMPONENT_NAME, ComponentName);
				this._P2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, removalData);
			}
			
			
#endregion
			
#region  < FRIEND METHODS  >
			
			internal void SubscribeComponent(CNDSErviceRegistrationData registrationData)
			{
                registrationData.ComponentName = registrationData.ComponentName.ToUpper();
				//saves in the local directory . . .
				lock(this._localComponentDirectoryTable)
				{
                    if (this._localComponentDirectoryTable.ContainsComponentRegistry(registrationData.ComponentName))
					{
                        this._localComponentDirectoryTable.RemoveComponentRegistry(registrationData.ComponentName);
					}
                    this._localComponentDirectoryTable.AddComponentRegistry(registrationData.ComponentName, registrationData.HostName, registrationData.IPAddress.ToString(), registrationData.ListeningPort, this.ApplicationName, this.ProcessID);
                }

                this.CreateComponentRegistrationOnServer(registrationData);
				
			}
			
			internal CNDAddressingReg ResolveAddress(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				
				//searches in the local directory
				if (this._localComponentDirectoryTable.ContainsComponentRegistry(ComponentName))
				{
					CNDAddressingReg reg = this._localComponentDirectoryTable.GetCNDAddressingRegister(ComponentName);
					return reg;
				}
				
				CNDAddressingReg cndreg = this.ResolveComponentAddressingFromServer(ComponentName);
				if (!(cndreg == null))
				{
					return cndreg;
				}
				else
				{
					
					//retrieves the table from server to substitute the local directory and asks again
					this.GetCNDTableFromServer();
					
					if (this._localComponentDirectoryTable.ContainsComponentRegistry(ComponentName))
					{
						CNDAddressingReg reg = this._localComponentDirectoryTable.GetCNDAddressingRegister(ComponentName);
						return reg;
					}
					else
					{
						string err = "Unable to resolve address for component " + ComponentName;
						throw (new Exception(err));
					}
				}
			}
			
			internal CNDAddressingReg ResolveAddressInSitu(string ComponentName)
			{
				return this.ResolveAddress(ComponentName);
			}
			
			internal void UnSubcribeComponent(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				try
				{
					//removes in the locally directory
					lock(this._localComponentDirectoryTable)
					{
						if (this._localComponentDirectoryTable.ContainsComponentRegistry(ComponentName))
						{
							this._localComponentDirectoryTable.RemoveComponentRegistry(ComponentName);
						}
					}
					
					this.RemoveComponentRegistrationOnServer(ComponentName);
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void Connect()
			{
				
				if (this._isREconnectionScheduled)
				{
					this.StopAutoReconection();
				}
				
				if (!_IsConnected)
				{
					try
					{
						this.ConnectTriyingLocalHost();
					}
					catch (Exception exHost)
					{
						CustomEventLog.WriteEntry(exHost);
						try
						{
							if (!this.ConnectUsingLocalKnownConfiguration())
							{
								CustomEventLog.WriteEntry(EventLogEntryType.Information, "No local parameters found to connect to CND Service");
								try
								{
									this.ConnectBySearchingServiceOverNetwork();
								}
								catch (Exception ex)
								{
									this.ScheduleAutoReconection();
									CustomEventLog.WriteEntry(ex);
									throw (ex);
								}
							}
						}
						catch (Exception ex)
						{
							CustomEventLog.WriteEntry(ex);
							try
							{
								this.ConnectBySearchingServiceOverNetwork();
							}
							catch (Exception ex1)
							{
								CustomEventLog.WriteEntry(ex1);
								this.ScheduleAutoReconection();
								throw (ex);
							}
						}
						
					}
				}
			}
			
			public void DisconnectFromService()
			{
				
				this.StopAutoReconection();
				
				try
				{
					this._P2PPortClient.Disconnect();
					this._P2PPortClient.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._STXServiceClient.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._MultiCastDataReplicatorClient.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._CNDTableUpdateTimer.Stop();
				}
				catch (Exception)
				{
				}
			}
			
			public DataTable GetCNDTableFromServer()
			{
				
				try
				{
					P2PDataRequest request = new P2PDataRequest(CNDServiceDefinitions.CND_TABLE_DATA_NAME);
					P2PData data = default(P2PData);
					data = this._P2PPortClient.RetrieveData(request);
					DataTable dt = (DataTable) data.Value;
					this._localComponentDirectoryTable.SetTable(dt);
					return dt;
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
					return null;
				}
			}
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
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
							this.DisconnectFromService();
							
							this._CNDTableUpdateTimer.Dispose();
						}
						catch (Exception)
						{
							
						}
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
