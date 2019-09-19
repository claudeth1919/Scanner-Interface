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
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsConnectionManaging;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsPostingManagement;
using CommunicationsLibrary.Services.MultiCastDataReplication;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client
	{
		
		public enum DPE_ClientType
		{
			StatusViewerClientType,
			PublisherSubscriberClientType,
			unknown
		}
		
		public enum ConnectionMode
		{
			networkBroadCasting,
			localParameters,
			localHost
		}
		
		public class DPE_DataPublicationsClient : IDisposable
		{
			
#region  < STRUCTURES >
			
			private struct STXDSS_PublicationUpdateRegister
			{
				public string publicationName;
				public string variableName;
			}
			
			private struct STXDSS_PublicationConnectionReg
			{
				public string publicationName;
				public DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode;
			}
			
#endregion
			
#region  < DATAMEMBERS >
			
			private const string STXDS_SERVICE_CONNECTION_PARAMS = "STXDS_SERVICE_CONNECTION_PARAMS";
			
			private const int STXDS_SERVICE_PUBLICATION_CLIENT_CONNECTION_REGISTRATION_MAX_TRIALS = 50;
			private const int STX_DSS_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY_MAX_TRIALS = 50;
			
			private const int STXDS_SERVICE_MAX_COMMAND_TRIALS = 25;
			
			private static CustomHashTable _STXDataSocketServerLocalParametersTable = null;
			
			private string _remoteServerHostName;
			private int _remoteListeningPortNumberOfTheP2PPort;			
						
			private DiscoverableServiceDefinitionHandlingClient _STXServiceClient;
			private string _clientName;
			
			private MultiCastDataReplicatorClient _MultiCastDataReplicatorClient;
			
			
			//****** P2P COMMUNICATIONS ***********************************************************
			//client to p2pport for generic communications
			private Services.P2PCommunicationsScheme.P2PPortClient _DefaultServerP2PPortClient;
			
			//client to the p2pport to send to server information to create a publication
			private Services.P2PCommunicationsScheme.P2PPortClient _PublicationsPostingDataP2PPortClient;
			private int _PublicationsPostingDataP2PPortNumber;
			
			//client to the P2Pport that allows the clients to retrieve information about the publications in order to connect to them
			private Services.P2PCommunicationsScheme.P2PPortClient _PublicationsInformationRetrieveP2PPortClient;
			private int _PublicationsInformationRetrieveP2PPortNumber;
			
			//client to the P2Pport that allows the clients to send its connection to a publicaton registration data
			private Services.P2PCommunicationsScheme.P2PPortClient _PublicationsClientRegistrationP2PPortClient;
			private int _PublicationsClientRegistrationP2PPortNumber;
			
			
			//connection to server related variables
			private bool _isconnected;
			private bool _IsAutoReconnectionTaskScheduled = false;
			private System.Threading.Thread _reconnectionThread;
			
			private string _clientID;
			
			//table that holds connections to publications pending becuase the client was discconnected
			private Hashtable _tableOfPendingReconnectionToPublicationsAfterConnectionWithPublicationLost = new Hashtable();
			private Queue _QueueOfPendingReconnectionToPublicationsAfterConnectionWithPublicationLost = new Queue();
			
			
			private Hashtable _syncLockTable = new Hashtable();
			
			private DPE_PublicationsPostingManager _STXDSSC_PublicationsPostingManager;
			private DPE_PublicationsConnectionsManager _STXDSSC_PublicationsConnectionsManager;
			
			private DateTime _startConnectionTime;
			
			private DPE_ClientType _clientType;
			
			private string _publicationsDSSMainDataBaseCnnString;
			
			private DataStatisticsHandler _DataStatisticsHandler;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_DataPublicationsClient(DPE_ClientType clientType, string ClientName)
			{
				this._clientType = clientType;
				this._clientID = Guid.NewGuid().ToString().ToUpper();
				this._clientName = ClientName;
				this._STXServiceClient = new DiscoverableServiceDefinitionHandlingClient(this._clientName);
				
				this._isconnected = false;
				this._IsAutoReconnectionTaskScheduled = false;
				this._publicationsDSSMainDataBaseCnnString = "";
				
				
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					this._STXDSSC_PublicationsPostingManager = new DPE_PublicationsPostingManager(this);
					this._STXDSSC_PublicationsPostingManager.PublicationPostLostOnServer += this._STXDSSC_PublicationsPostingManager_PublicationPostLostOnServer;
					this._STXDSSC_PublicationsConnectionsManager = new DPE_PublicationsConnectionsManager(this);
					this._STXDSSC_PublicationsConnectionsManager.ConnectionToPublicationLost += this._STXDSSC_PublicationsConnectionsManager_ConnectionToPublicationLost;
					this._STXDSSC_PublicationsConnectionsManager.PublicationDataReceived += this._STXDSSC_PublicationsConnectionsManager_PublicationDataReceived;
					this._STXDSSC_PublicationsConnectionsManager.PublicationDataResetReceived += this._STXDSSC_PublicationsConnectionsManager_PublicationDataResetReceived;
					this._STXDSSC_PublicationsConnectionsManager.PublicationUnicastProxyTCPConnectionBroken += this._STXDSSC_PublicationsConnectionsManager_PublicationUnicastProxyTCPConnectionBroken;
					this._DataStatisticsHandler = new DataStatisticsHandler(this._STXDSSC_PublicationsConnectionsManager);
				}
				
				
				
			}
			
			public DPE_DataPublicationsClient() : this(DPE_ClientType.PublisherSubscriberClientType, AppDomain.CurrentDomain.FriendlyName.Substring(0, AppDomain.CurrentDomain.FriendlyName.IndexOf(".")) + "   ( " + Guid.NewGuid().ToString().ToUpper() + " )")
			{
			}
			
			public DPE_DataPublicationsClient(string ClientName) : this(DPE_ClientType.PublisherSubscriberClientType, ClientName)
			{
			}
			
			public DPE_DataPublicationsClient(DPE_ClientType clientType) : this(clientType, AppDomain.CurrentDomain.FriendlyName.Substring(0, AppDomain.CurrentDomain.FriendlyName.IndexOf(".")) + "   ( " + Guid.NewGuid().ToString().ToUpper() + " )")
			{
			}
			
#endregion
			
#region  < PROPERTIES >
			
public dynamic ClientType
			{
				get
				{
					return this._clientType;
				}
			}
			
public string ClientID
			{
				get
				{
					return this._clientID;
				}
			}
			
public string NetworkID
			{
				get
				{
					return this._DefaultServerP2PPortClient.ClientID;
				}
			}
			
public string ClientHostName
			{
				get
				{
					string hostName = System.Net.Dns.GetHostName();
					return hostName;
				}
			}
			
public string ClientName
			{
				get
				{
					return this._clientName;
				}
			}
			
public DataTable ServerParametersTable
			{
				get
				{
					DataTable _serviceParametersDataTable = default(DataTable);
					_serviceParametersDataTable = new DataTable("DME_CMD_SERVICE_PARAMETERS");
					_serviceParametersDataTable.Columns.Add("Parameter Name", System.Type.GetType("System.String"));
					_serviceParametersDataTable.Columns.Add("Parameter Value", System.Type.GetType("System.String"));
					if (!(_STXDataSocketServerLocalParametersTable == null))
					{
						IEnumerator enumm = _STXDataSocketServerLocalParametersTable.GetEnumerator();
						string paramName = "";
						string paramValue = "";
						DataRow row = default(DataRow);
						while (enumm.MoveNext())
						{
							paramName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
							paramValue = System.Convert.ToString(((DictionaryEntry) enumm.Current).Value);
							row = _serviceParametersDataTable.NewRow();
							row[0] = paramName;
							row[1] = paramValue;
							_serviceParametersDataTable.Rows.Add(row);
						}
					}
					return _serviceParametersDataTable;
				}
			}
			
public bool IsConnected
			{
				get
				{
					return this._isconnected;
				}
			}
			
internal DPE_PublicationsPostingManager PublicationsPostManager
			{
				get
				{
					return this._STXDSSC_PublicationsPostingManager;
				}
			}
			
internal int PublicationsInformationRetrieve_PortNumber
			{
				get
				{
					return this._PublicationsInformationRetrieveP2PPortNumber;
				}
			}
			
internal int PublicationsClientRegistration_PortNumber
			{
				get
				{
					return this._PublicationsClientRegistrationP2PPortNumber;
				}
			}
			
			
internal int PublicationsPost_PortNumber
			{
				get
				{
					return this._PublicationsPostingDataP2PPortNumber;
				}
			}
			
			
internal string DSSServerHostName
			{
				get
				{
					return this._remoteServerHostName;
				}
			}
			
public string PublicationsMainServerDataBaseConnectionString
			{
				get
				{
					return this._publicationsDSSMainDataBaseCnnString;
				}
			}
			
public int PublicationsPostCount
			{
				get
				{
					return this._STXDSSC_PublicationsPostingManager.PostsCount;
				}
			}
			
public DataStatisticsHandler Statistics
			{
				get
				{
					return this._DataStatisticsHandler;
				}
			}
			
#endregion
			
#region  < EVENTS  >
			
			public delegate void PublicationDataReceivedEventHandler(DPE_PublicationData data);
			private PublicationDataReceivedEventHandler PublicationDataReceivedEvent;
			
			public event PublicationDataReceivedEventHandler PublicationDataReceived
			{
				add
				{
					PublicationDataReceivedEvent = (PublicationDataReceivedEventHandler) System.Delegate.Combine(PublicationDataReceivedEvent, value);
				}
				remove
				{
					PublicationDataReceivedEvent = (PublicationDataReceivedEventHandler) System.Delegate.Remove(PublicationDataReceivedEvent, value);
				}
			}
			
			public delegate void PublicationDataResetReceivedEventHandler(string publicationName, string variableName);
			private PublicationDataResetReceivedEventHandler PublicationDataResetReceivedEvent;
			
			public event PublicationDataResetReceivedEventHandler PublicationDataResetReceived
			{
				add
				{
					PublicationDataResetReceivedEvent = (PublicationDataResetReceivedEventHandler) System.Delegate.Combine(PublicationDataResetReceivedEvent, value);
				}
				remove
				{
					PublicationDataResetReceivedEvent = (PublicationDataResetReceivedEventHandler) System.Delegate.Remove(PublicationDataResetReceivedEvent, value);
				}
			}
			
			
			public delegate void ConnectionWithSTXDataServerLostEventHandler();
			private ConnectionWithSTXDataServerLostEventHandler ConnectionWithSTXDataServerLostEvent;
			
			public event ConnectionWithSTXDataServerLostEventHandler ConnectionWithSTXDataServerLost
			{
				add
				{
					ConnectionWithSTXDataServerLostEvent = (ConnectionWithSTXDataServerLostEventHandler) System.Delegate.Combine(ConnectionWithSTXDataServerLostEvent, value);
				}
				remove
				{
					ConnectionWithSTXDataServerLostEvent = (ConnectionWithSTXDataServerLostEventHandler) System.Delegate.Remove(ConnectionWithSTXDataServerLostEvent, value);
				}
			}
			
			public delegate void AutomaticConnectionWithServerPerformedEventHandler();
			private AutomaticConnectionWithServerPerformedEventHandler AutomaticConnectionWithServerPerformedEvent;
			
			public event AutomaticConnectionWithServerPerformedEventHandler AutomaticConnectionWithServerPerformed
			{
				add
				{
					AutomaticConnectionWithServerPerformedEvent = (AutomaticConnectionWithServerPerformedEventHandler) System.Delegate.Combine(AutomaticConnectionWithServerPerformedEvent, value);
				}
				remove
				{
					AutomaticConnectionWithServerPerformedEvent = (AutomaticConnectionWithServerPerformedEventHandler) System.Delegate.Remove(AutomaticConnectionWithServerPerformedEvent, value);
				}
			}
			
			public delegate void ConnectionToPostedPublicationLostEventHandler(string PublicationName);
			private ConnectionToPostedPublicationLostEventHandler ConnectionToPostedPublicationLostEvent;
			
			public event ConnectionToPostedPublicationLostEventHandler ConnectionToPostedPublicationLost
			{
				add
				{
					ConnectionToPostedPublicationLostEvent = (ConnectionToPostedPublicationLostEventHandler) System.Delegate.Combine(ConnectionToPostedPublicationLostEvent, value);
				}
				remove
				{
					ConnectionToPostedPublicationLostEvent = (ConnectionToPostedPublicationLostEventHandler) System.Delegate.Remove(ConnectionToPostedPublicationLostEvent, value);
				}
			}
			
			public delegate void ConnectionToPublicationLostEventHandler(string publicationName);
			private ConnectionToPublicationLostEventHandler ConnectionToPublicationLostEvent;
			
			public event ConnectionToPublicationLostEventHandler ConnectionToPublicationLost
			{
				add
				{
					ConnectionToPublicationLostEvent = (ConnectionToPublicationLostEventHandler) System.Delegate.Combine(ConnectionToPublicationLostEvent, value);
				}
				remove
				{
					ConnectionToPublicationLostEvent = (ConnectionToPublicationLostEventHandler) System.Delegate.Remove(ConnectionToPublicationLostEvent, value);
				}
			}
			
			
			//status events
			public delegate void NewClientConnectionOnServerEventHandler();
			private NewClientConnectionOnServerEventHandler NewClientConnectionOnServerEvent;
			
			public event NewClientConnectionOnServerEventHandler NewClientConnectionOnServer
			{
				add
				{
					NewClientConnectionOnServerEvent = (NewClientConnectionOnServerEventHandler) System.Delegate.Combine(NewClientConnectionOnServerEvent, value);
				}
				remove
				{
					NewClientConnectionOnServerEvent = (NewClientConnectionOnServerEventHandler) System.Delegate.Remove(NewClientConnectionOnServerEvent, value);
				}
			}
			
			public delegate void ClientDisconnectionOnServerEventHandler();
			private ClientDisconnectionOnServerEventHandler ClientDisconnectionOnServerEvent;
			
			public event ClientDisconnectionOnServerEventHandler ClientDisconnectionOnServer
			{
				add
				{
					ClientDisconnectionOnServerEvent = (ClientDisconnectionOnServerEventHandler) System.Delegate.Combine(ClientDisconnectionOnServerEvent, value);
				}
				remove
				{
					ClientDisconnectionOnServerEvent = (ClientDisconnectionOnServerEventHandler) System.Delegate.Remove(ClientDisconnectionOnServerEvent, value);
				}
			}
			
			public delegate void NewPublicaitonPostedEventHandler();
			private NewPublicaitonPostedEventHandler NewPublicaitonPostedEvent;
			
			public event NewPublicaitonPostedEventHandler NewPublicaitonPosted
			{
				add
				{
					NewPublicaitonPostedEvent = (NewPublicaitonPostedEventHandler) System.Delegate.Combine(NewPublicaitonPostedEvent, value);
				}
				remove
				{
					NewPublicaitonPostedEvent = (NewPublicaitonPostedEventHandler) System.Delegate.Remove(NewPublicaitonPostedEvent, value);
				}
			}
			
			public delegate void PublicationDisposedEventHandler();
			private PublicationDisposedEventHandler PublicationDisposedEvent;
			
			public event PublicationDisposedEventHandler PublicationDisposed
			{
				add
				{
					PublicationDisposedEvent = (PublicationDisposedEventHandler) System.Delegate.Combine(PublicationDisposedEvent, value);
				}
				remove
				{
					PublicationDisposedEvent = (PublicationDisposedEventHandler) System.Delegate.Remove(PublicationDisposedEvent, value);
				}
			}
			
			
			
			
#endregion
			
#region  < EVENT HANDLING >
			
#region  < P2P PORT CLIENT >
			
			private void _DefaultServerP2PPortClient_ConnectionLost(Services.P2PCommunicationsScheme.P2PPortClient client)
			{
				this._isconnected = false;
				_STXDataSocketServerLocalParametersTable = null;
				
				string msg = "";
				msg = "Connection with Data Publications Lost. Client : " + this.ClientName;
				CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
				
				this.ScheduleAutomaticConnectionToServerTask();
				try
				{
					if (ConnectionWithSTXDataServerLostEvent != null)
						ConnectionWithSTXDataServerLostEvent();
				}
				catch (Exception)
				{
				}
				
			}
			
#endregion
			
#region  <  MULTICAST SERVER CLIENT FOR STATUS BRODCASTING HANDLING >
			
			public void _MultiCastDataReplicatorClient_DataReceived(byte[] dataReceived)
			{
				try
				{
					string dataAsXMLString = System.Text.Encoding.ASCII.GetString(dataReceived);
					SocketData data = default(SocketData);
					data = SocketData.ParseAndGet_SocketData_FromXMLDataString(dataAsXMLString);
					switch (data.DataName)
					{
						case DPE_ServerDefs.DPE_NEW_CLIENT_CONNECTED:
							try
							{
								if (NewClientConnectionOnServerEvent != null)
									NewClientConnectionOnServerEvent();
							}
							catch (Exception)
							{
							}
							break;
						case DPE_ServerDefs.DPE_CLIENT_DISCONNECTED:
							try
							{
								if (ClientDisconnectionOnServerEvent != null)
									ClientDisconnectionOnServerEvent();
							}
							catch (Exception)
							{
							}
							break;
						case DPE_ServerDefs.DPE_PUBLICATION_CREATED:
							try
							{
								if (NewPublicaitonPostedEvent != null)
									NewPublicaitonPostedEvent();
							}
							catch (Exception)
							{
							}
							break;
						case DPE_ServerDefs.DPE_PUBLICATION_DISPOSED:
							try
							{
								if (PublicationDisposedEvent != null)
									PublicationDisposedEvent();
							}
							catch (Exception)
							{
							}
							break;
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
				
			}
			
#endregion
			
#region  <  PUBLICATIONS CONNECTIONS MANAGER >
			
			internal void _STXDSSC_PublicationsConnectionsManager_ConnectionToPublicationLost(string publicationName)
			{
				try
				{
					if (ConnectionToPublicationLostEvent != null)
						ConnectionToPublicationLostEvent(publicationName);
				}
				catch (Exception)
				{
				}
			}
			
			internal void _STXDSSC_PublicationsConnectionsManager_PublicationDataReceived(DPE_PublicationData data)
			{
				try
				{
					if (PublicationDataReceivedEvent != null)
						PublicationDataReceivedEvent(data);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			internal void _STXDSSC_PublicationsConnectionsManager_PublicationDataResetReceived(string publicationName, string variableName)
			{
				try
				{
					if (PublicationDataResetReceivedEvent != null)
						PublicationDataResetReceivedEvent(publicationName, variableName);
				}
				catch (Exception)
				{
				}
			}
			
			internal void _STXDSSC_PublicationsConnectionsManager_PublicationUnicastProxyTCPConnectionBroken(string publicationName, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				try
				{
					//disconnects from the publication forcing the connectionsmanager to dispose the handler for this
					//connection
					this.DisconnectFromDataPublication(publicationName);
					//tries to connect again in order to post again the connection into the server
					this.ConnectToADataPublication(publicationName, connectionMode);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < PUBLICATIONS POST MANAGER >
			
			private void _STXDSSC_PublicationsPostingManager_PublicationPostLostOnServer(string publicationName)
			{
				try
				{
					this._STXDSSC_PublicationsConnectionsManager.DisposeConnectionHandler(publicationName);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#endregion
			
#region  < PRIVATE METHODS  >
			
#region  < CONNECTION METHODS >
			
			private bool ConnectTriyingLocalHost()
			{
				DiscoverableServiceDefinitionParametersContainer cnnParams =  CommunicationsLibrary.DataPublicationsEnvironment.Server.DPE_DataPublicationsServer.GetLocalHostServiceDefaultParameters();
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
				DiscoverableServiceDefinitionParametersContainer cnnParams = DiscoverableServiceDefinitionParametersContainer.GetLocalServiceParameters(DPE_ServerDefs.DPE_SERVER_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME);
				if (!(cnnParams == null))
				{
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
				if (_STXDataSocketServerLocalParametersTable == null)
				{
					_STXDataSocketServerLocalParametersTable = this.FindServiceOverNetworkAndGetParametersTableForConnection();
				}
				this.ConnectToService(ConnectionMode.networkBroadCasting, _STXDataSocketServerLocalParametersTable);
			}
			
			private void ConnectToService(ConnectionMode connectionMode, CustomHashTable serviceParametersTable)
			{
				try
				{
					this._startConnectionTime = DateTime.Now;
					
					this._isconnected = false;
					
					this._remoteServerHostName = System.Convert.ToString(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME));
					
					this._remoteListeningPortNumberOfTheP2PPort = System.Convert.ToInt32(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT));
					
					//*************************** P2P COMMUNIATIONS *******************************
					//-------------------------------------
					//the clients connects to the generic p2pport to retrieve and send commands
					this._DefaultServerP2PPortClient = new Services.P2PCommunicationsScheme.P2PPortClient(this._remoteServerHostName, this._remoteListeningPortNumberOfTheP2PPort);
					this._DefaultServerP2PPortClient.ConnectionLost += this._DefaultServerP2PPortClient_ConnectionLost;
					this._DefaultServerP2PPortClient.Connect();
					
					//--------------------------------------------------------
					//Gets the connection port number that allows clients to send data to create a publication
					this._PublicationsPostingDataP2PPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT));
					
					//---------------------------------------------------------
					//connection to the port that allos clients to retrieva data of a publication in order to connect to it
					this._PublicationsInformationRetrieveP2PPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT));
					
					//---------------------------------------------------------
					//connection to the port that allows clients to registrate its connection information
					this._PublicationsClientRegistrationP2PPortNumber = System.Convert.ToInt32(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT));
					
					//---------------------------------------------------------
					//gets the publications data base connection string
					this._publicationsDSSMainDataBaseCnnString = System.Convert.ToString(serviceParametersTable.Item(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING));
					
					
					this.CreateClientServerRegistration();
					
                    // at this point connection was succesfull so then ask to retrieve the parameters as they are at the server 
                    


					TimeSpan span = this._startConnectionTime.Subtract(DateTime.Now);
					int ms = (int) (Math.Abs(span.TotalMilliseconds));
                    CustomEventLog.DisplayEvent(EventLogEntryType.SuccessAudit, "Client \'" + this.ClientName + "\' connected succesfully with DATA PUBLICATIONS SERVER using [" + connectionMode.ToString() + "] connection mode (" + System.Convert.ToString(ms) + " ms)");
					
					this._isconnected = true;
					
				}
				catch (Exception ex)
				{
					this._isconnected = false;
					_STXDataSocketServerLocalParametersTable = null;
					try
					{
						this._DefaultServerP2PPortClient.Disconnect();
						this._DefaultServerP2PPortClient.Dispose();
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
					
					string errMsg = "";
					switch (connectionMode)
					{
						case ConnectionMode.localParameters:
							errMsg = "Failed to connect to DATA PUBLICATIONS SERVICE using local parameters table : " + ex.Message;
							break;
						case ConnectionMode.localHost:
                            errMsg = "Failed to connect to DATA PUBLICATIONS SERVICE trying on local host : " + ex.Message;
							break;
						case ConnectionMode.networkBroadCasting:
                            errMsg = "Failed to connect to DATA PUBLICATIONS SERVICE trying network broadcasting : " + ex.Message;
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
				try
				{
					DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDefinition = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
					DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
					serviceDefinition = this._STXServiceClient.FindService(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_NAME);
					
					CustomHashTable parametersTable = new CustomHashTable();
					
					//---------------------- REMOTE SERVICE HOST NAME -------------------------------------
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the paramter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME, param.Value);
					
					//************************* P2P COMMUNICATIONS SET UP ********************************************************
					
					//-------------------------------------------------------------------------------------
					//gets from the paramters of the service, the port number for its p2p port
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT, System.Convert.ToInt32(param.Value));
					
					
					//-------------------------------------------------------------------------------------
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT, System.Convert.ToInt32(param.Value));
					
					//-------------------------------------------------------------------------------------
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT, System.Convert.ToInt32(param.Value));
					
					//-------------------------------------------------------------------------------------
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT, System.Convert.ToInt32(param.Value));
					
					
					//---------------------- PUBLICATIONS DATA BASE CONNECTION STRING  -------------------------------------
					if (!serviceDefinition.ServiceParameters.ContainsParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING))
					{
						throw (new Exception("Can\'t connect to service because the parameters list retrieved doesn\'t contain the parameter \'" + DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING + "\'"));
					}
					param = serviceDefinition.ServiceParameters.GetParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING);
					parametersTable.Add(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING, System.Convert.ToString(param.Value));
					
					return parametersTable;
					
				}
				catch (Exception ex)
				{
					string msg = "Error retrieving parameters service table : " + ex.Message.ToString();
					throw (new Exception(msg));
				}
			}

          /*  private CustomHashTable RetrieveParametersFromServer()
            {


            }*/
			
#endregion
			
#region  < AUTO CONNECTION WITH SERVER >
			
			private void ScheduleAutomaticConnectionToServerTask()
			{
				try
				{
					if (!this._IsAutoReconnectionTaskScheduled)
					{
						this._IsAutoReconnectionTaskScheduled = true;
						CustomEventLog.WriteEntry(EventLogEntryType.Information, "Automatic connection Task with SIFC PROCESS SERVER was launched. Client " + this.ClientName);
						
						this._reconnectionThread = new System.Threading.Thread(new System.Threading.ThreadStart(AutomaticConnectionWithServer_ThreadFunction));
						this._reconnectionThread.IsBackground = true;
						this._reconnectionThread.Start();
						
					}
				}
				catch (Exception)
				{
				}
			}
			
			private void StopAutomaticConnectionToServerTask()
			{
				try
				{
					this._IsAutoReconnectionTaskScheduled = false;
					this._reconnectionThread.Abort();
				}
				catch (Exception)
				{
				}
			}
			
			private void AutomaticConnectionWithServer_ThreadFunction()
			{
				try
				{
					
					while (this._IsAutoReconnectionTaskScheduled)
					{
						
						try
						{
							this.ConnectTriyingLocalHost();
                            CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Connection with DATA PUBLICATIONS SERVER was restored. Client : " + this.ClientName);
							this._IsAutoReconnectionTaskScheduled = false;
							try
							{
								if (AutomaticConnectionWithServerPerformedEvent != null)
									AutomaticConnectionWithServerPerformedEvent();
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
									CustomEventLog.DisplayEvent(EventLogEntryType.Information, "No local parameters found to connect to DATA PUBLICATIONS SERVER");
									try
									{
										this.ConnectBySearchingServiceOverNetwork();
										_IsAutoReconnectionTaskScheduled = false;
										CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with DATA PUBLICATIONS SERVER was performed succesfully. Client : " + this._STXServiceClient.Name);
										try
										{
											if (AutomaticConnectionWithServerPerformedEvent != null)
												AutomaticConnectionWithServerPerformedEvent();
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
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with DATA PUBLICATIONS SERVER was performed succesfully. Client : " + this._STXServiceClient.Name);
									_IsAutoReconnectionTaskScheduled = false;
									try
									{
										if (AutomaticConnectionWithServerPerformedEvent != null)
											AutomaticConnectionWithServerPerformedEvent();
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
									_IsAutoReconnectionTaskScheduled = false;
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Automatic connection task with DATA PUBLICATIONS SERVER was performed succesfully. Client : " + this._STXServiceClient.Name);
									try
									{
										if (AutomaticConnectionWithServerPerformedEvent != null)
											AutomaticConnectionWithServerPerformedEvent();
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
						System.Threading.Thread.Sleep(1500);
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#region  < CLIENT NAME REGISTRATION ON SERVER >
			
			private void CreateClientServerRegistration()
			{
				
				//updates the client name in the server
				int trialCounter = 0;
				
				P2PData p2pdata = new P2PData(DPE_ServerDefs.DPE_CMD_CLIENT_REGISTRATION_DATA, DPE_ServerDefs.DPE_CMD_CLIENT_REGISTRATION_DATA);
				p2pdata.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
				p2pdata.DataAttributesTable.AddAttribute(DPE_ServerDefs.DPE_CLIENT_NETWORK_ID, this.NetworkID);
				p2pdata.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_NAME, ClientName);
				p2pdata.DataAttributesTable.AddAttribute(DPE_ServerDefs.DPE_CLIENT_HOST_NAME, this.ClientHostName);
				p2pdata.DataAttributesTable.AddAttribute(DPE_ServerDefs.DPE_CLIENT_TYPE, Get_DSSClientType_As_String(this._clientType));
				string applicationAppdomain = AppDomain.CurrentDomain.FriendlyName;
				p2pdata.DataAttributesTable.AddAttribute(DPE_ServerDefs.DPE_CLIENT_APPDOMAIN_NAME, applicationAppdomain);
				
				while (true)
				{
					try
					{
						this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, p2pdata);
						return;
					}
					catch (Exception ex)
					{
						if (trialCounter >= STXDS_SERVICE_PUBLICATION_CLIENT_CONNECTION_REGISTRATION_MAX_TRIALS)
						{
							string msg = "";
							msg = "Can\'t connect to the DATA PUBLICATIONS Service because was impossible to complete the client registration. Error: " + ex.Message;
							throw (new Exception(msg));
						}
						else
						{
							trialCounter++;
						}
					}
				}
			}
			
#endregion
			
#region  < PUBLICATION DATA UPDATE VALIDATION >
			
			private void ValidatePublicationDataOnUpdate(DPE_ClientPublicationDefinition definition, string DataName, object data)
			{
				DPE_ServerDefs.PublicationVariableDataType type = default(DPE_ServerDefs.PublicationVariableDataType);
				type = definition.GetVariableDataTypeDefined(DataName);
				
				string varDataType = data.GetType().ToString();
				switch (type)
				{
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer:
						if (varDataType != "System.Int32")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as INTEGER and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal:
						if (varDataType != "System.Decimal")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as DECIMAL and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean:
						if (varDataType != "System.Boolean")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as BOOLEAN and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String:
						if (varDataType != "System.String")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as STRING and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable:
						if (varDataType != "System.Data.DataTable")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as DATATABLE and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataSet:
						if (varDataType != "System.Data.DataSet")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as DATASET and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFHashTable:
						if (varDataType != "UtilitiesLibrary.Data.CustomHashTable")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as CFHASHTABLE and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFList:
						if (varDataType != "UtilitiesLibrary.Data.CustomList")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as CFLIST and was attemping to send as " + varDataType));
						}
						break;
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFSortedList:
						if (varDataType != "UtilitiesLibrary.Data.CustomSortedList")
						{
							throw (new Exception("Data type mismatch. The publication variable is defined as CFSORTEDLIST and was attemping to send as " + varDataType));
						}
						break;
					default:
						throw (new Exception("Invalid data type " + varDataType));
				}
			}
			
#endregion
			
			private void ConnectPublisherToHisOwnPublicationForHandling(DPE_ClientPublicationDefinition publicationDefinition)
			{
				string PublicationName = publicationDefinition.PublicationName.ToUpper();
				
				if (!this.IsConnected)
				{
					//attemps to connect to the server and then creates a connection task to ensure the
					//client will connect to the publication when it will be available
					try
					{
						this.ConnectToServer();
					}
					catch (Exception)
					{
					}
				}
				
				
				//verifies if there is not a previous connection handler for the publication
				if (!this._STXDSSC_PublicationsConnectionsManager.ContainsConnectionHandler(PublicationName))
				{
					//verifies if there is not a previous scheduled automatic connection to the publication
					if (!this._STXDSSC_PublicationsConnectionsManager.ContainsScheduledPublicationConnectionTask(PublicationName))
					{
						this._STXDSSC_PublicationsConnectionsManager.ConnectoToPublication(DPE_PublicationConnectionHandler_Type.publisherHandler, PublicationName, DPE_ServerDefs.DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus);
					}
				}
				
				
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public override string ToString()
			{
				return this.ClientName;
			}
			
			
#region  < SERVER CONNECTION >
			
			public void ConnectToServer()
			{
				if (!_IsAutoReconnectionTaskScheduled)
				{
					if (!this.IsConnected)
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
									CustomEventLog.WriteEntry(EventLogEntryType.Information, "No local parameters found to connect to DATA PUBLICATIONS SERVER");
									try
									{
										this.ConnectBySearchingServiceOverNetwork();
									}
									catch (Exception ex)
									{
										CustomEventLog.WriteEntry(ex);
										this.ScheduleAutomaticConnectionToServerTask();
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
									this.ScheduleAutomaticConnectionToServerTask();
								}
							}
						}
					}
				}
			}
			
			public void ScheduleConnection()
			{
				try
				{
					if (!_IsAutoReconnectionTaskScheduled)
					{
						this.ScheduleAutomaticConnectionToServerTask();
					}
				}
				catch (Exception)
				{
				}
			}
			
			
			public void DisconnectFromServer()
			{
				
				this._isconnected = false;
				
				this.StopAutomaticConnectionToServerTask();
				
				try
				{
					this._DefaultServerP2PPortClient.Dispose();
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
					this._STXServiceClient.Dispose();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._STXDSSC_PublicationsConnectionsManager.Reset();
				}
				catch (Exception)
				{
				}
				try
				{
					this._STXDSSC_PublicationsPostingManager.Reset();
				}
				catch (Exception)
				{
				}
				
				
				
			}
			
#endregion
			
#region  < PUBLICATIONS POST MANAGEMENT >
			
			public void CreateDataPublication(DPE_ClientPublicationDefinition publicationDefinition) //ok
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					if (!this.IsConnected)
					{
						try
						{
							this.ConnectToServer();
						}
						catch (Exception)
						{
						}
					}
					try
					{
						//posts the publication into the server
						this.PublicationsPostManager.PostPublicationOnServer(publicationDefinition);
						//then connects to the publication just to have a link to the publication in the server
						this.ConnectPublisherToHisOwnPublicationForHandling(publicationDefinition);
					}
					catch (Exception ex)
					{
						CustomEventLog.WriteEntry(ex);
						//it failed then schedules a asynchronic task to post the publication and a task to connect to it
						this.PublicationsPostManager.ScheduleTaskToPostAPublicationOnServer(publicationDefinition);
						//schedules a task to connect to a publication
						this._STXDSSC_PublicationsConnectionsManager.ScheduleConnectionTaskToAPublication(publicationDefinition.PublicationName, DPE_ServerDefs.DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus);
						
					}
					
				}
				else
				{
					throw (new Exception("The client can\'t create data publications becuase is connected as Viewer Client"));
				}
				
			}
			
			public void DisposeDataPublication(string publicationName) //ok
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					if (!this.IsConnected)
					{
						if (this._STXDSSC_PublicationsPostingManager.ContainsScheduledPublicationPost(publicationName))
						{
							this._STXDSSC_PublicationsPostingManager.AbortScheduledPublicationPostTask(publicationName);
						}
						
						this._STXDSSC_PublicationsPostingManager.AbortScheduledPublicationPostTask(publicationName);
						
						this._STXDSSC_PublicationsPostingManager.DisposePublicationDefinition(publicationName);
						
						//becuase the clients also connects to the publications it publishers, then
						//calls the publications connection manager in order to remove and destroy the handler created
						//for the client to connect to his own publication
						this._STXDSSC_PublicationsConnectionsManager.DisposeConnectionHandler(publicationName);
					}
					else
					{
						publicationName = publicationName.ToUpper();
						P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_DISPOSE_PUBLICATION, DPE_ServerDefs.DPE_CMD_DISPOSE_PUBLICATION);
						data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
						data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, publicationName);
						
						bool disposed = false;
						int disposeTrialCounter = 0;
						while (!disposed)
						{
							try
							{
								
								this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
								
								if (this._STXDSSC_PublicationsPostingManager.ContainsScheduledPublicationPost(publicationName))
								{
									this._STXDSSC_PublicationsPostingManager.AbortScheduledPublicationPostTask(publicationName);
								}
								
								this._STXDSSC_PublicationsPostingManager.AbortScheduledPublicationPostTask(publicationName);
								
								this._STXDSSC_PublicationsPostingManager.DisposePublicationDefinition(publicationName);
								
								//becuase the clients also connects to the publications it publishers, then
								//calls the publications connection manager in order to remove and destroy the handler created
								//for the client to connect to his own publication
								this._STXDSSC_PublicationsConnectionsManager.DisposeConnectionHandler(publicationName);
								
								try
								{
									this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
								}
								catch (Exception)
								{
								}
								
								disposed = true;
								
							}
							catch (Exception ex)
							{
								disposeTrialCounter++;
								if (disposeTrialCounter > STXDS_SERVICE_MAX_COMMAND_TRIALS)
								{
									string msg = "";
									msg = "Error trying to dispose the publication named \'" + publicationName + "\' : " + ex.Message;
									throw (new Exception(msg));
								}
							}
							System.Threading.Thread.Sleep(5);
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t Dispose a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
			public void AddVariableToPublication(string PublicationName, string variableName, DPE_ServerDefs.PublicationVariableDataType datatype)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					PublicationName = PublicationName.ToUpper();
					variableName = variableName.ToUpper();
					
					if (!this.IsConnected)
					{
						throw (new Exception("The client is not connected to the Data Publications Service"));
					}
					
					//evaluates if the client has the connectin and definition of the publication
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(PublicationName))
					{
						throw (new Exception("Can\'t update the publication definition of \'" + PublicationName + "\' because there is not a local definition to compare and update"));
					}
					else
					{
						DPE_ClientPublicationDefinition pubdef = default(DPE_ClientPublicationDefinition);
						pubdef = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(PublicationName);
						
						if (!(pubdef == null))
						{
							if (pubdef.ContainsVariable(variableName))
							{
								throw (new Exception("Can\'t add the variable \'" + variableName + "\' to the publication \'" + PublicationName + "\' because it exists already in it."));
							}
							
							//connect to the server in order to pudate the publication definition
							P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_ADD_PUBLICATION_VARIABLE, DPE_ServerDefs.DPE_CMD_ADD_PUBLICATION_VARIABLE);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationName);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME, variableName);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_DATA_TYPE, System.Convert.ToString(datatype.ToString()));
							
							bool variableCreated = false;
							int variableCreatedTrialCounter = 0;
							
							while (!variableCreated)
							{
								try
								{
									
									this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
									
									//adds the variable to the local publication
									pubdef.AddVaribleToPublication(variableName, datatype);
									variableCreated = true;
								}
								catch (Exception ex)
								{
									variableCreatedTrialCounter++;
									if (variableCreatedTrialCounter > STXDS_SERVICE_MAX_COMMAND_TRIALS)
									{
										string msg = "";
										msg = "Error adding the variable \'" + variableName + "\' to the publication \'" + PublicationName + "\' : " + ex.Message;
										throw (new Exception(msg));
									}
								}
								System.Threading.Thread.Sleep(5);
							}
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t DISPOSE a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
			public void AddGroupOfVariablesToPublication(string PublicationName, DPE_PublicationGroupOfVariablesDefinitionTable groupOfVariablesTable)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					PublicationName = PublicationName.ToUpper();
					
					if (!this.IsConnected)
					{
						throw (new Exception("The client is not connected to the Data Publications Service"));
					}
					
					//evaluates if the client has the connectin and definition of the publication
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(PublicationName))
					{
						throw (new Exception("Can\'t update the publication definition of \'" + PublicationName + "\' because there is not a local definition to compare and update"));
					}
					else
					{
						DPE_ClientPublicationDefinition pubdef = default(DPE_ClientPublicationDefinition);
						pubdef = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(PublicationName);
						
						if (!(pubdef == null))
						{
							
							IEnumerator rowenumm = groupOfVariablesTable.GroupOfVariablesTable.Rows.GetEnumerator();
							DataRow row = default(DataRow);
							string variableName = "";
							Hashtable varsToBeDiscarded = new Hashtable();
							
							//cycle to discard from the table the variables that are already included in the definition in the local
							//register
							while (rowenumm.MoveNext())
							{
								row = (DataRow)rowenumm.Current;
								variableName = System.Convert.ToString(row[DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME]);
								if (pubdef.ContainsVariable(variableName))
								{
									varsToBeDiscarded.Add(variableName, variableName);
								}
							}
							IEnumerator enumm = varsToBeDiscarded.GetEnumerator();
							while (enumm.MoveNext())
							{
								variableName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
								groupOfVariablesTable.RemoveVariable(variableName);
							}
							
							//connects to the server in order to send the data to update the publication definition
							//connect to the server in order to pudate the publication definition
							P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES, groupOfVariablesTable.GroupOfVariablesTable);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationName);
							
							bool groupOfvariablesCreated = false;
							int variableCreatedTrialCounter = 0;
							
							while (!groupOfvariablesCreated)
							{
								try
								{
									
									this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
									
									//cycle to add the variables to the local definition
									rowenumm = groupOfVariablesTable.GroupOfVariablesTable.Rows.GetEnumerator();
									while (rowenumm.MoveNext())
									{
										row = (DataRow )rowenumm.Current;
										variableName = System.Convert.ToString(row[DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME]);
										DPE_ServerDefs.PublicationVariableDataType datatype = default(DPE_ServerDefs.PublicationVariableDataType);
										try
										{
											datatype = groupOfVariablesTable.GetVariableDataType(variableName);
											pubdef.AddVaribleToPublication(variableName, datatype);
										}
										catch (Exception)
										{
										}
									}
									groupOfvariablesCreated = true;
								}
								catch (Exception ex)
								{
									variableCreatedTrialCounter++;
									if (variableCreatedTrialCounter > STXDS_SERVICE_MAX_COMMAND_TRIALS)
									{
										string msg = "";
										msg = "Error adding a group of variables  to the publication \'" + PublicationName + "\' : " + ex.Message;
										throw (new Exception(msg));
									}
								}
								System.Threading.Thread.Sleep(5);
							}
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t Add Variables to a data publication becuase is connected as Status Viewer Client"));
				}
				
			}
			
			public void RemoveVariableFromPublication(string PublicationName, string variableName)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					PublicationName = PublicationName.ToUpper();
					variableName = variableName.ToUpper();
					
					if (!this.IsConnected)
					{
						throw (new Exception("The client is not connected to the Data Publications Service"));
					}
					
					//evaluates if the client has the connectin and definition of the publication
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(PublicationName))
					{
						throw (new Exception("Can\'t update the publication definition of \'" + PublicationName + "\' because there is not a local definition of it to compare and update"));
					}
					else
					{
						DPE_ClientPublicationDefinition pubdef = default(DPE_ClientPublicationDefinition);
						pubdef = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(PublicationName);
						
						if (!(pubdef == null))
						{
							
							if (!pubdef.ContainsVariable(variableName))
							{
								throw (new Exception("Can\'t remove the variable \'" + variableName + "\' from the publication \'" + PublicationName + " \' because it doens\'t exists in the publication"));
							}
							
							//connect to the server in order to update the publication definition
							P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_REMOVE_PUBLICATION_VARIABLE, DPE_ServerDefs.DPE_CMD_REMOVE_PUBLICATION_VARIABLE);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationName);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME, variableName);
							
							bool variableRemoved = false;
							int variableRemovedTrialCounter = 0;
							
							while (!variableRemoved)
							{
								try
								{
									this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
									
									pubdef.RemoveVariableFromPublication(variableName);
									variableRemoved = true;
								}
								catch (Exception ex)
								{
									variableRemovedTrialCounter++;
									if (variableRemovedTrialCounter >= STXDS_SERVICE_MAX_COMMAND_TRIALS)
									{
										string msg = "";
										msg = "Error removing the variable \'" + variableName + "\' from the publication \'" + PublicationName + "\' : " + ex.Message;
										throw (new Exception(msg));
									}
								}
								System.Threading.Thread.Sleep(200);
							}
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t remove a variable from a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
			public void SetPublicationGroup(string publicationsGroup, string publicationName)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					publicationName = publicationName.ToUpper();
					publicationsGroup = publicationsGroup.ToUpper();
					
					if (!this.IsConnected)
					{
						throw (new Exception("The client is not connected to the Data Publications Service"));
					}
					
					//evaluates if the client has the connectin and definition of the publication
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(publicationName))
					{
						throw (new Exception("Can\'t update the publication definition of \'" + publicationName + "\' because there is not a local definition of it to compare and update"));
					}
					else
					{
						DPE_ClientPublicationDefinition pubdef = default(DPE_ClientPublicationDefinition);
						pubdef = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(publicationName);
						
						if (!(pubdef == null))
						{
							
							//connect to the server in order to update the publication definition
							P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_SET_PUBLICATION_GROUP, DPE_ServerDefs.DPE_CMD_SET_PUBLICATION_GROUP);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, publicationName);
							data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP, publicationsGroup);
							
							try
							{
								this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
							}
							catch (Exception)
							{
								string err = "Error moving the publication \'" + publicationName + "\' to the group \'" + publicationsGroup + "\'";
								throw (new Exception(err));
							}
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t remove a variable from a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
#endregion
			
#region  < PUBLICATIONS CONNECTION  >
			
			public void ConnectToADataPublication(string PublicationName, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					
					PublicationName = PublicationName.ToUpper();
					
					if (this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(PublicationName))
					{
						throw (new Exception("The client can\'t connect to his own publication"));
					}
					
					if (!this.IsConnected)
					{
						//attemps to connect to the server and then creates a connection task to ensure the
						//client will connect to the publication when it will be available
						try
						{
							this.ConnectToServer();
						}
						catch (Exception)
						{
						}
						
						
					}
					//verifies if there is not a previous connection handler for the publication
					if (!this._STXDSSC_PublicationsConnectionsManager.ContainsConnectionHandler(PublicationName))
					{
						//verifies if there is not a previous scheduled automatic connection to the publication
						if (!this._STXDSSC_PublicationsConnectionsManager.ContainsScheduledPublicationConnectionTask(PublicationName))
						{
							try
							{
								this._STXDSSC_PublicationsConnectionsManager.ConnectoToPublication(DPE_PublicationConnectionHandler_Type.subscriptorHandler, PublicationName, connectionMode);
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
								this._STXDSSC_PublicationsConnectionsManager.ScheduleConnectionTaskToAPublication(PublicationName, connectionMode);
							}
						}
						else
						{
							CustomEventLog.WriteEntry(EventLogEntryType.Warning, "There is already a connection process to publication " + PublicationName);
						}
					}
					
				}
				else
				{
					throw (new Exception("The client can\'t connect to a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
			public void DisconnectFromDataPublication(string PublicationName)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					PublicationName = PublicationName.ToUpper();
					if (this._STXDSSC_PublicationsConnectionsManager.ContainsConnectionHandler(PublicationName))
					{
						this._STXDSSC_PublicationsConnectionsManager.DisposeConnectionHandler(PublicationName);
						//stops any attempt to connect to a publication
						if (this._STXDSSC_PublicationsConnectionsManager.ContainsScheduledPublicationConnectionTask(PublicationName))
						{
							this._STXDSSC_PublicationsConnectionsManager.AbortScheduledConnectionToAPublication(PublicationName);
						}
					}
					else
					{
						//stops any attempt to connect to a publication
						if (this._STXDSSC_PublicationsConnectionsManager.ContainsScheduledPublicationConnectionTask(PublicationName))
						{
							this._STXDSSC_PublicationsConnectionsManager.AbortScheduledConnectionToAPublication(PublicationName);
						}
						
						string msg = "";
						msg = "Data Publications Client \'" + this.ClientName + "\' tried to disconnect from the publication \'" + PublicationName + " \' with no connection with such publication.";
						CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
					}
				}
				else
				{
					throw (new Exception("The client can\'t Connect to a data publication becuase is connected as Status Viewer Client"));
				}
				
			}
			
#endregion
			
#region  < SERVER STATUS DATA REQUESTS >
			
			public DataTable GetServerParametersTable()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				P2PData @params = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DME_CMD_SERVICE_PARAMETERS);
				
				try
				{
					@params = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve from server the service parameters: " + ex.Message;
					throw (new Exception(msg));
				}
				
				@params = this._DefaultServerP2PPortClient.RetrieveData(req);
				DataTable dt = default(DataTable);
				dt = (DataTable) (@params.Value);
				return dt;
			}
			
			public DataTable GetClientsRegistryTable()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				P2PData @params = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_CLIENTS_REGISTRY_TABLE);
				
				try
				{
					@params = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve from server the registry of connected Clients " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = default(DataTable);
				dt = (DataTable) (@params.Value);
				return dt;
			}
			
			public DataTable GetPublihsersRegistryTable()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//retrieves from the server the table of all clients that has created
				//publications
				P2PData @params = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_PUBLISHER_CLIENTS_REGISTRY_TABLE);
				try
				{
					@params = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve from server the registry of publisher Clients: " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = default(DataTable);
				dt = (DataTable) (@params.Value);
				return dt;
			}
			
			public DataTable GetPublicationsRegistryTable()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				
				P2PData @params = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_PUBLICATIONS_REGISTRY_TABLE);
				try
				{
					@params = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve from server the registry of publications: " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = default(DataTable);
				dt = (DataTable) (@params.Value);
				return dt;
			}
			
			public DataTable GetListOfVariablesPublishedOnAPublication(string publicationName)
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//retrieves from the server the table definition of the variables that composes
				//a publication
				publicationName = publicationName.ToUpper();
				P2PData ListOfPublishedVariables = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_PUBLICATION_PUBLISHED_VARIABLES_TABLE);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, publicationName);
				try
				{
					ListOfPublishedVariables = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the list of variables contained in the publication \'" + publicationName + "\': " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = default(DataTable);
				dt = (System.Data.DataTable) ListOfPublishedVariables.Value;
				return dt;
			}
			
			public CustomList GetListOfSubscriptionsToPublications(string ClientID)
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//Retrieves from the server the list of the publications where the client
				//is connected to.
				P2PData ListOfPublicationsWhereTheClientIsSubscibed = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID, ClientID);
				
				try
				{
					ListOfPublicationsWhereTheClientIsSubscibed = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the list of subscriptions to publications: " + ex.Message;
					throw (new Exception(msg));
				}
				
				CustomList list = (CustomList) ListOfPublicationsWhereTheClientIsSubscibed.Value;
				return list;
			}
			
			public CustomList GetListOfSubscriptionsToPublications()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//Retrieves from the server the list of the publications where the client
				//is connected to.
				P2PData ListOfPublicationsWhereTheClientIsSubscibed = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
				
				try
				{
					ListOfPublicationsWhereTheClientIsSubscibed = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the list of subscriptions to publications: " + ex.Message;
					throw (new Exception(msg));
				}
				
				CustomList list = (CustomList) ListOfPublicationsWhereTheClientIsSubscibed.Value;
				return list;
			}
			
			public CustomList GetListOfPublicationsPosted()
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//Retrieves from the server the list of the publications created by the client
				P2PData ListOfPublishedPublications = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_CLIENT_POSTED_PUBLICATIONS_LIST);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
				try
				{
					ListOfPublishedPublications = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the list of publications posted: " + ex.Message;
					throw (new Exception(msg));
				}
				
				CustomList list = (CustomList) ListOfPublishedPublications.Value;
				return list;
			}
			
			public DataTable GetTableOfClientsAttachedToPublication(string PublicationName)
			{
				
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//retrieves from the server a table containing the list of clients attached to a publication
				P2PData publicationSubscriptionsList = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_PUBLICATION_ATTACHED_CLIENTS_TABLE);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationName);
				
				try
				{
					publicationSubscriptionsList = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the list of clients attached to the publication \'" + PublicationName + "\': " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = (DataTable) publicationSubscriptionsList.Value;
				return dt;
			}
			
			public DataTable GetStatusTableOfPostedPublications()
			{
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//retrieves from the server a table containing the list of clients attached to a publication
				P2PData postedPublicationsStatusTableData = default(P2PData);
				P2PDataRequest req = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_CLIENT_POSTED_PUBLICATIONS_TABLE);
				req.AddRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this.ClientID);
				
				try
				{
					postedPublicationsStatusTableData = this._DefaultServerP2PPortClient.RetrieveData(req);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to retrieve the status of the publications posted by the client : " + ex.Message;
					throw (new Exception(msg));
				}
				
				DataTable dt = (DataTable) postedPublicationsStatusTableData.Value;
				return dt;
			}
			
			public DataTable GetPublicationStatisticsTable(string PublicationName)
			{
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				DataTable statisticsTable = new DataTable();
				
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._publicationsDSSMainDataBaseCnnString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_CONSULT_STORED_PROCEDURE_NAME;
							
							System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@publicationName", SqlDbType.VarChar);
							param.Value = PublicationName;
							cmd.Parameters.Add(param);
							
							using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
							{
								da.Fill(statisticsTable);
							}
							
						}
						
					}
					
					
				}
				catch (Exception)
				{
					throw;
				}
				
				return statisticsTable;
			}
			
			public void ResetPublicationStatistics(string PublicationName)
			{
				if (!this.IsConnected)
				{
					throw (new Exception("The client is not connected to the Data Publications Service"));
				}
				
				//Retrieves from the server the list of the publications where the client
				//is connected to.
				P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS, DPE_ServerDefs.DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS);
				data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationName);
				
				try
				{
					this._DefaultServerP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to RESET the statistics Of publication : " + ex.Message;
					throw (new Exception(msg));
				}
				
			}
			
#endregion
			
#region  < DATA PUBLICATIONS UPDATE >
			
			public void UpdatePublicationData(DPE_PublicationData data)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					if (!this.IsConnected)
					{
						throw (new Exception("Can\'t update the publication \'" + data.PublicationName + "\' becuase ther is not connection with the server"));
					}
					
					DPE_ClientPublicationDefinition definition = default(DPE_ClientPublicationDefinition);
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(data.PublicationName))
					{
						string msg = "Client can not update data from publication \'" + data.PublicationName + "\', becuase it wasnt posted in the Data Publications Server or there is not available local definition.";
						throw (new Exception(msg));
					}
					else
					{
						definition = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(data.PublicationName);
						
						//validate if the data match with the definition
						if (!definition.ContainsVariable(data.VariableName))
						{
							throw (new Exception("Can\'t update the publication \'" + data.PublicationName + "\' because it doesn\'t host the variable named \'" + data.VariableName + "\'"));
						}
						
						try
						{
							this.ValidatePublicationDataOnUpdate(definition, data.VariableName, data.Value);
						}
						catch (Exception ex)
						{
							throw (new Exception("Error updating the publication \'" + data.PublicationName + "\' : " + ex.Message));
						}
						
						DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
						publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(data.PublicationName);
						if (!(publicationCnnHandler == null))
						{
							try
							{
								publicationCnnHandler.SendPublicationDataUpdate(data);
							}
							catch (Exception ex)
							{
								throw (new Exception("Error updating the publication \'" + data.PublicationName + "\' : " + ex.Message));
							}
						}
						else
						{
							throw (new Exception("Error updating the publication \'" + data.PublicationName + "\' :  Can\'t find a connection handler to the publication"));
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t Update a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
			public void ResetPublicationData(string publicationName, string variableName)
			{
				if (this._clientType == DPE_ClientType.PublisherSubscriberClientType)
				{
					publicationName = publicationName.ToUpper();
					variableName = variableName.ToUpper();
					
					if (!this.IsConnected)
					{
						throw (new Exception("Can\'t update the publication \'" + publicationName + "\' becuase ther is not connection with the server"));
					}
					
					if (!this._STXDSSC_PublicationsPostingManager.ContainsPublicationDefinition(publicationName))
					{
						throw (new Exception("Client can not update data from publications that doesn\'t was posted in the Data Publications Service by itself"));
					}
					else
					{
						DPE_ClientPublicationDefinition definition = default(DPE_ClientPublicationDefinition);
						definition = this._STXDSSC_PublicationsPostingManager.GetPublicationDefinition(publicationName);
						if (!(definition == null))
						{
							if (!definition.ContainsVariable(variableName))
							{
								throw (new Exception("the variable \'" + variableName + "\' doesn\'t exists in the publication \'" + publicationName + "\'"));
							}
							else
							{
								DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
								publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(publicationName);
								if (!(publicationCnnHandler == null))
								{
									try
									{
										publicationCnnHandler.SendPublicationDataReset(variableName);
									}
									catch (Exception ex)
									{
										throw (new Exception("Error updating a data reset to the publication \'" + publicationName + "\' : " + ex.Message));
									}
								}
								else
								{
									throw (new Exception("Error updating the publication \'" + publicationName + "\' :  Can\'t find a connection handler to the publication"));
								}
							}
						}
					}
				}
				else
				{
					throw (new Exception("The client can\'t reset a data publication becuase is connected as Status Viewer Client"));
				}
			}
			
#endregion
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static string Get_DSSClientType_As_String(DPE_ClientType type)
			{
				switch (type)
				{
					case DPE_ClientType.PublisherSubscriberClientType:
						return "PublisherSubscriberClientType";
					case DPE_ClientType.StatusViewerClientType:
						return "StatusViewerClientType";
					default:
						return "Unknown";
				}
			}
			
			internal static DPE_ClientType Get_DSSClientType_From_String(string type)
			{
				switch (type)
				{
					case "PublisherSubscriberClientType":
						return DPE_ClientType.PublisherSubscriberClientType;
					case "StatusViewerClientType":
						return DPE_ClientType.StatusViewerClientType;
					case "Unknown":
						return DPE_ClientType.unknown;
                    default:
                        return DPE_ClientType.unknown;
				}
			}
			
#endregion
			
#region  <  INTERFACE IMPLEMENTATION >
			
#region  < IDisposable >
			
			private bool disposedValue = false; // To detect redundant calls
			
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						try
						{
							this.StopAutomaticConnectionToServerTask();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this.DisconnectFromServer();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._STXDSSC_PublicationsConnectionsManager.Dispose();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._STXDSSC_PublicationsPostingManager.Dispose();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._IsAutoReconnectionTaskScheduled = false;
						}
						catch (Exception)
						{
							
						}
						try
						{
							this._reconnectionThread.Abort();
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
						
					}
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
			
#region  < SUPPORT CLASS >
			
			//class to hold all the statistics into a object
			
			public class DataStatisticsHandler
			{
				private DPE_PublicationsConnectionsManager _STXDSSC_PublicationsConnectionsManager;
				
				public DataStatisticsHandler(DPE_PublicationsConnectionsManager ConnectionsManager)
				{
					this._STXDSSC_PublicationsConnectionsManager = ConnectionsManager;
				}
				
#region  < WRITE >
				
				public int VariableUpdateWriteCount(string publicationName, string variableName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(publicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationWriter.UpdateDataStatistics(variableName);
					}
					else
					{
						throw (new Exception("No connection to publication \'" + publicationName + "\'"));
					}
				}
				
				public dynamic VariableResetWriteCount(string publicationName, string variableName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(publicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationWriter.get_ResetDataStatistics(variableName);
					}
					else
					{
						throw (new Exception("No connection to publication \'" + publicationName + "\'"));
					}
					
				}
				
				public DataTable PublicationUpdateWriteStatistics(string PublicationName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(PublicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationWriter.UpdateDataStatisticsTable;
					}
					else
					{
						throw (new Exception("No connection to publication \'" + PublicationName + "\'"));
					}
				}
				
				public DataTable PublicationResetWriteStatistics(string PublicationName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(PublicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationWriter.ResetDataStatisticsTable;
					}
					else
					{
						throw (new Exception("No connection to publication \'" + PublicationName + "\'"));
					}
				}
				
#endregion
				
#region  < READ >
				
				public DataTable PublicationUpdateReadStatisticsTable(string publicationName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(publicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationReader.UpdateDataStatisticsTable;
					}
					else
					{
						throw (new Exception("No connection to publication \'" + publicationName + "\'"));
					}
				}
				
				public DataTable PublicationResetReadStatisticsTable(string publicationName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(publicationName);
					if (!(publicationCnnHandler == null))
					{
						return publicationCnnHandler.PublicationReader.ResetDataStatisticsTable;
					}
					else
					{
						throw (new Exception("No connection to publication \'" + publicationName + "\'"));
					}
				}
#endregion
				
				
				
				public void ResetPublicationWriteStatistics(string PublicationName, string variableName)
				{
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSC_PublicationsConnectionsManager.GetConnectionHandler(PublicationName);
					if (!(publicationCnnHandler == null))
					{
						publicationCnnHandler.PublicationWriter.ResetStatistics(variableName);
					}
				}
				
			}
#endregion
			
		}
		
		
		
	}
	
	
	
	
}
