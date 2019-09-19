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
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsConnectionManaging;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsPostingManagement;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsConnectionManaging
	{
		
		public class DPE_PublicationsConnectionsManager : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			internal struct PublicationConnectionInfo
			{
				public DPE_PublicationConnectionHandler_Type connectionType;
				public string PublicationName;
				public DPE_ServerDefs.DPE_PublicationConnectionMode ConnectionMode;
			}
			
			
			//PUBLICATIONS CONNECTIONS PROXY SERVER  AND CLIENT
			
			private DPE_PublicationsConnectionsProxyServerClient _STXDSSC_PublicationsProxyConnectionsServerClient;
			
			
			private const int MAX_CONNECTION_ELAPSED_SECONDS_AFTER_THROW_ERROR = 30;
			private const int MAX_DATA_CONNECTION_PARAMETERS_INQUIRY_TRIALS = 30;
			private const int MAX_CONNECTION_REGISTRATION_TRIALS = 30;
			
			private DPE_DataPublicationsClient _STXDataSocketClient;
			
			private DPE_PublicationConnectionHandlersContainer _STXDSSPublicationConnectionHandlersContainer;
			
			//variables to handle the scheduling of connection to publications
			private Hashtable _tableOfConnectionRegistersForScheduledConnectionTasks = new Hashtable();
			private Queue _queueOfScheduledConnectionTasks = new Queue();
			
			//variables to handle the reconnection to publications after a connection loss with the server
			//this variables keep tracking of the connections stablished to publications in order
			//to restablish the connections if the communications withe the server is lost
			private Hashtable _tableOfConnectionInfoRegistersOfConnectionsToPublications;
			private bool _isTaskForAutoReconnectionToPublicationsLaunched = false;
			private System.Threading.Thread _reconnectionToPublicationsThread;
			
			private System.Threading.Thread _publicationsConnectionThread = null;
			
#endregion
			
#region  < EVENTS >
			
			internal delegate void PublicationDataReceivedEventHandler(DPE_PublicationData data);
			private PublicationDataReceivedEventHandler PublicationDataReceivedEvent;
			
			internal event PublicationDataReceivedEventHandler PublicationDataReceived
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
			
			internal delegate void PublicationDataResetReceivedEventHandler(string publicationName, string variableName);
			private PublicationDataResetReceivedEventHandler PublicationDataResetReceivedEvent;
			
			internal event PublicationDataResetReceivedEventHandler PublicationDataResetReceived
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
			
			internal delegate void ConnectionToPublicationLostEventHandler(string publicationName);
			private ConnectionToPublicationLostEventHandler ConnectionToPublicationLostEvent;
			
			internal event ConnectionToPublicationLostEventHandler ConnectionToPublicationLost
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
			
			internal delegate void PublicationUnicastProxyTCPConnectionBrokenEventHandler(string publicationName, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode);
			private PublicationUnicastProxyTCPConnectionBrokenEventHandler PublicationUnicastProxyTCPConnectionBrokenEvent;
			
			internal event PublicationUnicastProxyTCPConnectionBrokenEventHandler PublicationUnicastProxyTCPConnectionBroken
			{
				add
				{
					PublicationUnicastProxyTCPConnectionBrokenEvent = (PublicationUnicastProxyTCPConnectionBrokenEventHandler) System.Delegate.Combine(PublicationUnicastProxyTCPConnectionBrokenEvent, value);
				}
				remove
				{
					PublicationUnicastProxyTCPConnectionBrokenEvent = (PublicationUnicastProxyTCPConnectionBrokenEventHandler) System.Delegate.Remove(PublicationUnicastProxyTCPConnectionBrokenEvent, value);
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_PublicationsConnectionsManager(DPE_DataPublicationsClient client)
			{
				this._STXDataSocketClient = client;
				this._STXDataSocketClient.ConnectionWithSTXDataServerLost += this._STXDataSocketClient_ConnectionWithSTXDataServerLost;
				
				this._STXDSSC_PublicationsProxyConnectionsServerClient = DPE_PublicationsConnectionsProxyServerClient.GetInstance(client.PublicationsMainServerDataBaseConnectionString);
				this._STXDSSC_PublicationsProxyConnectionsServerClient.ConnectionWithProxyServerLost += this._STXDSSC_PublicationsProxyConnectionsServerClient_ConnectionWithProxyServerLost;
				
				this._STXDSSPublicationConnectionHandlersContainer = new DPE_PublicationConnectionHandlersContainer();
				this._tableOfConnectionInfoRegistersOfConnectionsToPublications = new Hashtable();
				
				
			}
			
#endregion
			
#region  < EVENT HANDLING  >
			
#region  < REMOTE DPE SERVER CONNECTION HANDLING EVENTS >
			
			private void _STXDataSocketClient_ConnectionWithSTXDataServerLost()
			{
				try
				{
					//Me.ScheduleTaskToRestablishThePreviousConnectionsToPublicationsAfterDSSServerConnectionLoss()
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < LOCAL PUBLICATIONS CONNECTIONS PROXY SERVER CLIENT  CONNECTION >
			
			private void _STXDSSC_PublicationsProxyConnectionsServerClient_ConnectionWithProxyServerLost()
			{
				try
				{
					//Me._STXDSSC_PublicationsProxyConnectionsServer = STXDSSC_PublicationsConnectionsProxyServer.GetInstance
					//Me._STXDSSC_PublicationsProxyConnectionsServerClient = STXDSSC_PublicationsConnectionsProxyServerClient.GetInstance
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
			}
			
#endregion
			
#endregion
			
#region  < PUBLICATIONS CONNECTIONS HANLDERS EVENT HANDLING >
			
			private void STXDSSPublicationConnectionHandler_PublicationDataReceived(DPE_PublicationData data)
			{
				try
				{
					//to avoid the publsiher client receive updates from its own publications
					if (PublicationDataReceivedEvent != null)
						PublicationDataReceivedEvent(data);
				}
				catch (Exception)
				{
				}
			}
			
			private void STXDSSPublicationConnectionHandler_ConnectionLost(string publicationName)
			{
				//this events happens when a connection to a publications gets lost
				
				//**********************************************************************
				//writes a mesage to the log
				string msg = "";
				msg = "Connection with Remote Publication \'" + publicationName + "\' Lost. Client : " + this._STXDataSocketClient.ClientName;
				CustomEventLog.WriteEntry(EventLogEntryType.Warning, msg);
				
				//***********************************************************************
				//removes the local connection hanlder
				this.DisposeConnectionHandler(publicationName);
				
				//***********************************************************************
				//launch a recconection task
				this.ReconnectToDataPublication(publicationName);
				
				//***********************************************************************
				//sends and event
				try
				{
					if (ConnectionToPublicationLostEvent != null)
						ConnectionToPublicationLostEvent(publicationName);
				}
				catch (Exception)
				{
				}
				
			}
			
			private void STXDSSPublicationConnectionHandler_PublicationDataResetReceived(string publicationName, string variableName)
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
			
#endregion
			
#region  < HANDLING OF RECONNECTION TO PREVIOUS CONNECTIONS TO PUBLICATIONS >
			
			private void ScheduleTaskToRestablishThePreviousConnectionsToPublicationsAfterDSSServerConnectionLoss()
			{
				if (this._tableOfConnectionInfoRegistersOfConnectionsToPublications.Count > 0)
				{
					if (_isTaskForAutoReconnectionToPublicationsLaunched)
					{
						return;
					}
					else
					{
						this._isTaskForAutoReconnectionToPublicationsLaunched = true;
						this._STXDSSPublicationConnectionHandlersContainer.DiscardAllLocalConnectionsToPublications();
						CustomEventLog.WriteEntry(EventLogEntryType.Information, "All previous connected publications re-Connection task was launched. Client " + this._STXDataSocketClient.ClientName);
						this._reconnectionToPublicationsThread = new System.Threading.Thread(new System.Threading.ThreadStart(TaskToRestablishThePreviousConnectionsToPublicationsAfterDSSServerConnectionLoss_ThreadFcn));
						this._reconnectionToPublicationsThread.Priority = System.Threading.ThreadPriority.Highest;
						this._reconnectionToPublicationsThread.IsBackground = true;
						this._reconnectionToPublicationsThread.Start();
					}
				}
			}
			
			private void TaskToRestablishThePreviousConnectionsToPublicationsAfterDSSServerConnectionLoss_ThreadFcn()
			{
				try
				{
					IEnumerator enumm = default(IEnumerator);
					Hashtable newTable = new Hashtable();
					
					lock(this._tableOfConnectionInfoRegistersOfConnectionsToPublications)
					{
						enumm = _tableOfConnectionInfoRegistersOfConnectionsToPublications.GetEnumerator();
						PublicationConnectionInfo cnnInfo = new PublicationConnectionInfo();
						while (enumm.MoveNext())
						{
							cnnInfo = (PublicationConnectionInfo) (((DictionaryEntry) enumm.Current).Value);
							this.ReconnectToDataPublication(cnnInfo.PublicationName);
						}
					}
					
				}
				catch (Exception)
				{
				}
			}
			
			private void StopPublicationReconnectionsTask()
			{
				try
				{
					this._isTaskForAutoReconnectionToPublicationsLaunched = false;
					this._reconnectionToPublicationsThread.Abort();
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < HANDLING OF CONNECTION WITH PUBLICATIONS  >
			
			internal DPE_PublicationConnectionHandler CreatePublicationConnectionHandler(DPE_PublicationConnectionHandler_Type handlerType, DPE_DataPublicationsClient client, string PublicationName, string PublicationHostName, int publicationsSocketsServerPortNumber, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				
				//***********************************************************************************************
				//creates the handler according to the type of connection
				DPE_PublicationConnectionHandler publicationCnnHandler = null;
				publicationCnnHandler = new DPE_PublicationConnectionHandler(handlerType, client, PublicationName, PublicationHostName, publicationsSocketsServerPortNumber, connectionMode);
				
				if (!(publicationCnnHandler == null))
				{
					try
					{
						//evaluates if the client is not the publisher of the publication, in order to avoid thepublisher client to
						//receive its own publication update
						if (!this._STXDataSocketClient.PublicationsPostManager.ContainsPublicationDefinition(PublicationName))
						{
							if (publicationCnnHandler.HandlerType == DPE_PublicationConnectionHandler_Type.subscriptorHandler)
							{
								publicationCnnHandler.PublicationDataReceived += STXDSSPublicationConnectionHandler_PublicationDataReceived;
								publicationCnnHandler.PublicationDataResetReceived += STXDSSPublicationConnectionHandler_PublicationDataResetReceived;
							}
						}
						//for both type of handlers is created a handler to the connectio lost event in order to know when a connection to a publication
						//is lost
						publicationCnnHandler.ConnectionToPublicationLost += STXDSSPublicationConnectionHandler_ConnectionLost;
					}
					catch (Exception)
					{
						publicationCnnHandler.PublicationDataReceived -= STXDSSPublicationConnectionHandler_PublicationDataReceived;
						publicationCnnHandler.ConnectionToPublicationLost -= STXDSSPublicationConnectionHandler_ConnectionLost;
						publicationCnnHandler.PublicationDataResetReceived -= STXDSSPublicationConnectionHandler_PublicationDataResetReceived;
					}
					
					try
					{
						this._STXDSSPublicationConnectionHandlersContainer.AddPublicationConnectionHandler(publicationCnnHandler);
					}
					catch (Exception ex)
					{
						CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
					}
					
					if (handlerType == DPE_PublicationConnectionHandler_Type.subscriptorHandler)
					{
						
						//---------------------------------------
						//saves into a has table the publication name and its connection mode for further reference when is needed to perfofm
						//automatic reconnections just for connections handlers defined as subscriptors handler
						PublicationConnectionInfo cnnInfo = new PublicationConnectionInfo();
						cnnInfo.connectionType = handlerType;
						cnnInfo.PublicationName = PublicationName;
						cnnInfo.ConnectionMode = connectionMode;
						
						try
						{
							//saves the connection information for the subscriptors connection type handlers
							if (this._tableOfConnectionInfoRegistersOfConnectionsToPublications.ContainsKey(PublicationName))
							{
								this._tableOfConnectionInfoRegistersOfConnectionsToPublications.Remove(PublicationName);
							}
							this._tableOfConnectionInfoRegistersOfConnectionsToPublications.Add(PublicationName, cnnInfo);
						}
						catch (Exception ex)
						{
							CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
						}
					}
					
				}
				
				//---------------------------------------
				return publicationCnnHandler;
				
			}
			
			internal void DisposeConnectionHandler(string publicationName)
			{
				
				if (this.ContainsConnectionHandler(publicationName))
				{
					
					DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
					publicationCnnHandler = this._STXDSSPublicationConnectionHandlersContainer.GetConnectionHandler(publicationName);
					
					//--------------------------------------------------------------
					try
					{
						publicationCnnHandler.PublicationDataReceived -= STXDSSPublicationConnectionHandler_PublicationDataReceived;
						publicationCnnHandler.ConnectionToPublicationLost -= STXDSSPublicationConnectionHandler_ConnectionLost;
						publicationCnnHandler.PublicationDataResetReceived -= STXDSSPublicationConnectionHandler_PublicationDataResetReceived;
					}
					catch (Exception)
					{
					}
					
					try
					{
						publicationCnnHandler.Dispose();
					}
					catch (Exception)
					{
					}
					
					//stops any attempt to connect to a publication
					if (this.ContainsScheduledPublicationConnectionTask(publicationName))
					{
						this.AbortScheduledConnectionToAPublication(publicationName);
					}
					
					this._STXDSSPublicationConnectionHandlersContainer.RemoveConnectionHandler(publicationName);
					
					//If Me._tableOfConnectionInfoRegistersOfConnectionsToPublications.ContainsKey(publicationName) Then
					//    Me._tableOfConnectionInfoRegistersOfConnectionsToPublications.Remove(publicationName)
					//End If
					
				}
				
			}
			
			internal bool ContainsConnectionHandler(string publicationName)
			{
				return this._STXDSSPublicationConnectionHandlersContainer.ContainsPublicationHandler(publicationName);
			}
			
			internal DPE_PublicationConnectionHandler GetConnectionHandler(string PublicationName)
			{
				return this._STXDSSPublicationConnectionHandlersContainer.GetConnectionHandler(PublicationName);
			}
			
			
#endregion
			
#region  < HANDLING OF TASKS FOR SCHEDULED CONNECTIONS TO PUBLICATIONS >
			
			
			internal void ConnectoToPublication(DPE_PublicationConnectionHandler_Type connectionHandlerType, string publicationName, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				//*****************************************************************************
				//request to the server the connection parameters of the publication
				P2PDataRequest dataREquest = new P2PDataRequest(DPE_ServerDefs.DPE_CMD_PUBLICATION_SUBSCRIPTION_DATA);
				dataREquest.AddRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, publicationName);
				
				P2PData publicationPArams = null;
				string msg = "";
				Services.P2PCommunicationsScheme.P2PPortClient publicationsInformationRetrieveP2PPortClient = null;
				int trialsCount = 0;
				
				
				publicationsInformationRetrieveP2PPortClient = new Services.P2PCommunicationsScheme.P2PPortClient(this._STXDataSocketClient.DSSServerHostName, this._STXDataSocketClient.PublicationsInformationRetrieve_PortNumber);
				publicationsInformationRetrieveP2PPortClient.Connect();
				
				
				//performs a  while cycle until the client gets the connection parameters
				while (true)
				{
					
					try
					{
						publicationPArams = publicationsInformationRetrieveP2PPortClient.RetrieveData(dataREquest);
                        break;
					}
					catch (Exception ex)
					{
						
						trialsCount++;
						
						if (trialsCount >= MAX_DATA_CONNECTION_PARAMETERS_INQUIRY_TRIALS)
						{
							msg = "Error trying to connect to publication \'" + publicationName + "\': " + ex.Message;
							throw (new Exception(msg));
						}
					}
					
					System.Threading.Thread.Sleep(10);
					
				}
				
				try
				{
					publicationsInformationRetrieveP2PPortClient.Dispose();
				}
				catch (Exception)
				{
				}
				
				CustomHashTable paramsList = (CustomHashTable) publicationPArams.Value;
				string publicationHostNAme = System.Convert.ToString(paramsList.Item(DPE_PublicationsDefinitions.DPE_PUBLICATION_HOSTNAME));
				int publicationPort = System.Convert.ToInt32(paramsList.Item(DPE_PublicationsDefinitions.DPE_PUBLICATION_PORT));
				
				//*****************************************************************************
				//CREATION OF THE PUBLICATION HANDLER and CONNECTION WITH publication
				DPE_PublicationConnectionHandler publicationConnectionHandler = default(DPE_PublicationConnectionHandler);
				publicationConnectionHandler = this.CreatePublicationConnectionHandler(connectionHandlerType, this._STXDataSocketClient, publicationName, publicationHostNAme, publicationPort, connectionMode);
				
				
				//*****************************************************************************
				//Ciclic process in order to allow the server to register the client socket connection . -> to synchronize the client registration
				//by ser client with the server event to log the publication event
				
				msg = "Error trying to perform the client connection registration to the publication \'" + publicationName + "\' : ";
				
				//*****************************************************************************
				//registration of the client connection to a publication in the server
				//the client sends to the server a information telling to which publication has already connected
				//and also for the TCP client mode to tell the publication to which port send the data
				
				int connectionRegistrationTrialCounter = 0;
				bool connectionRegistration = false;
				
				//preparation of the connection information into a p2p data
				P2PData clientPubCnnData = new P2PData(DPE_ServerDefs.DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION, DPE_ServerDefs.DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION);
				clientPubCnnData.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this._STXDataSocketClient.ClientID);
				clientPubCnnData.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, publicationName);
				clientPubCnnData.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CONNECTION_HANDLER_ID, publicationConnectionHandler.HandlerID);
				//---------------------HANDLING FOR THE CONNECTION MODE ------------------------------
				string connectionModeAsString = "";
				connectionModeAsString = DPE_ServerDefs.Get_STXDSS_PublicationConnectionMode_ToAString(connectionMode);
				clientPubCnnData.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CLIENT_CONNECTION_MODE, connectionModeAsString);
				
				
				msg = "Error trying to perform the client connection registration to the publication \'" + publicationName + "\' : ";
				
				
				//sends to server the information to the server several times until the information reaches the server
				Services.P2PCommunicationsScheme.P2PPortClient publicationsClientRegistrationP2PPortClient = default(Services.P2PCommunicationsScheme.P2PPortClient);
				
				publicationsClientRegistrationP2PPortClient = new Services.P2PCommunicationsScheme.P2PPortClient(this._STXDataSocketClient.DSSServerHostName, this._STXDataSocketClient.PublicationsClientRegistration_PortNumber);
				publicationsClientRegistrationP2PPortClient.Connect();
				
				while (connectionRegistration == false)
				{
					try
					{
						publicationsClientRegistrationP2PPortClient.SendData(P2PDataSendMode.SyncrhonicalSend, clientPubCnnData);
						
						connectionRegistration = true;
						
						publicationsClientRegistrationP2PPortClient.Dispose();
						
						CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Connection to publication \'" + publicationName + "\' succesfull");
						
						break ;
					}
					catch (Exception ex)
					{
						System.Threading.Thread.Sleep(10);
						
						connectionRegistrationTrialCounter++;
						
						if (connectionRegistrationTrialCounter >= MAX_CONNECTION_REGISTRATION_TRIALS)
						{
							
							msg = msg + ex.Message;
							
							try
							{
								publicationsClientRegistrationP2PPortClient.Dispose();
							}
							catch (Exception)
							{
							}
							
							try
							{
								this.DisposeConnectionHandler(publicationName);
							}
							catch (Exception)
							{
							}
							
							throw (new Exception(msg));
							
						}
					}
				}
			
			}
			
			private void ReconnectToDataPublication(string publicationName)
			{
				
				//***********************************************************************
				//creates a task to restablisht the connection to the publication
				if (this._tableOfConnectionInfoRegistersOfConnectionsToPublications.ContainsKey(publicationName))
				{
					PublicationConnectionInfo cnnInfo = new PublicationConnectionInfo();
                    cnnInfo = (PublicationConnectionInfo)this._tableOfConnectionInfoRegistersOfConnectionsToPublications[publicationName];
					this.ScheduleConnectionTaskToAPublication(cnnInfo.PublicationName, cnnInfo.ConnectionMode);
				}
				
				//***********************************************************************
				//frees the connection handler resources of previous connection to the publication
				DPE_PublicationConnectionHandler publicationCnnHandler = default(DPE_PublicationConnectionHandler);
				publicationCnnHandler = this._STXDSSPublicationConnectionHandlersContainer.GetConnectionHandler(publicationName);
				
				if (!(publicationCnnHandler == null))
				{
					try
					{
						publicationCnnHandler.PublicationDataReceived -= STXDSSPublicationConnectionHandler_PublicationDataReceived;
						publicationCnnHandler.ConnectionToPublicationLost -= STXDSSPublicationConnectionHandler_ConnectionLost;
						publicationCnnHandler.PublicationDataResetReceived -= STXDSSPublicationConnectionHandler_PublicationDataResetReceived;
					}
					catch (Exception)
					{
					}
					
					try
					{
						publicationCnnHandler.Dispose();
					}
					catch (Exception)
					{
					}
				}
				
			}
			
			internal void ScheduleConnectionTaskToAPublication(string PublicationName, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				//this function is intended to be used by subscribers clients
				try
				{
					if (!this._tableOfConnectionRegistersForScheduledConnectionTasks.ContainsKey(PublicationName))
					{
						
						string msg = "";
						msg = "Task to connect with publication \'" + PublicationName + "\' was scheduled and started";
						CustomEventLog.WriteEntry(EventLogEntryType.Information, msg);
						
						PublicationConnectionTaskInfo reg = new PublicationConnectionTaskInfo(DPE_PublicationConnectionHandler_Type.subscriptorHandler, PublicationName, connectionMode);
						lock(this._tableOfConnectionRegistersForScheduledConnectionTasks)
						{
							this._tableOfConnectionRegistersForScheduledConnectionTasks.Add(PublicationName, reg);
						}
						lock(this._queueOfScheduledConnectionTasks)
						{
							this._queueOfScheduledConnectionTasks.Enqueue(reg);
						}
						
						if (this._publicationsConnectionThread == null)
						{
							this._publicationsConnectionThread = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadedFcn_ConnectionToEnqueuedDataPublications));
							this._publicationsConnectionThread.IsBackground = true;
							this._publicationsConnectionThread.Priority = System.Threading.ThreadPriority.Normal;
							this._publicationsConnectionThread.Start();
						}
						
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			//Friend Sub Schedule_OnLine_ConnectionTaskToAPublication(ByVal PublicationName As String, ByVal connectionMode As DPE_PublicationConnectionMode)
			//    Try
			
			//        If Not Me._tableOfConnectionRegistersForScheduledConnectionTasks.ContainsKey(PublicationName) Then
			
			//            Dim reg As New PublicationConnectionTaskInfo(STXDSSC_PublicationConnectionHandler_Type.subscriptorHandler, PublicationName, connectionMode)
			//            SyncLock Me._tableOfConnectionRegistersForScheduledConnectionTasks
			//                Me._tableOfConnectionRegistersForScheduledConnectionTasks.Add(PublicationName, reg)
			//            End SyncLock
			//            SyncLock Me._queueOfScheduledConnectionTasks
			//                Me._queueOfScheduledConnectionTasks.Enqueue(reg)
			//            End SyncLock
			
			//            'if the unique thread that is intended to be used for the connection is not created, then the thread is launched
			//            'the objective is no have only a unique thread for connections
			//            If Me._publicationsConnectionThread Is Nothing Then
			//                Me._publicationsConnectionThread = New Threading.Thread(AddressOf ThreadedFcn_ConnectionToEnqueuedDataPublications)
			//                Me._publicationsConnectionThread.IsBackground = True
			//                Me._publicationsConnectionThread.Priority = Threading.ThreadPriority.AboveNormal
			//                Me._publicationsConnectionThread.Start()
			//            End If
			
			
			//        End If
			//    Catch ex As Exception
			//        CustomEventLog.WriteEntry(ex)
			//    End Try
			//End Sub
			
			internal bool ContainsScheduledPublicationConnectionTask(string publicationName)
			{
				if (this._tableOfConnectionRegistersForScheduledConnectionTasks.ContainsKey(publicationName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			internal void ThreadedFcn_ConnectionToEnqueuedDataPublications()
			{
				
				PublicationConnectionTaskInfo reg = null;
				bool continueCycle = true;
				
				while (continueCycle)
				{
					
					try
					{
						//if there are connection registers
						if (this._queueOfScheduledConnectionTasks.Count > 0)
						{
							
							//if the client is connected then performs connections
							
							if (this._STXDataSocketClient.IsConnected)
							{
								
								lock(this._queueOfScheduledConnectionTasks)
								{
                                    reg = (PublicationConnectionTaskInfo)this._queueOfScheduledConnectionTasks.Dequeue();
								}
								
								if (!(reg == null))
								{
									
									try
									{
										this.ConnectoToPublication(reg.connectionType, reg.publicationName, reg.connectionMode);
										
										
										string msg = "";
										
										msg = "Connection with publication \'" + reg.publicationName + "\' was Performed succesfully";
										CustomEventLog.DisplayEvent(EventLogEntryType.SuccessAudit, msg);
										
										lock(this._tableOfConnectionRegistersForScheduledConnectionTasks)
										{
											this._tableOfConnectionRegistersForScheduledConnectionTasks.Remove(reg.publicationName);
										}
										
										reg.keepScheduledConnectionTask = false;
										
									}
									catch (Exception ex)
									{
										
										if (reg.GetElapsedTimeInSeconds() > MAX_CONNECTION_ELAPSED_SECONDS_AFTER_THROW_ERROR)
										{
											CustomEventLog.DisplayEvent(EventLogEntryType.Error, "Error connecting to publication \'" + reg.publicationName + "\' : " + ex.Message);
											reg.ResetTime();
										}
										
										
										//the connection failed and then the connection attempt is enqueed again only it theres is a record on the schedule table
										//that indicates that is pending to conenct to such publication
										
										lock(this._tableOfConnectionRegistersForScheduledConnectionTasks)
										{
											if (this._tableOfConnectionRegistersForScheduledConnectionTasks.ContainsKey(reg.publicationName))
											{
												
												lock(this._queueOfScheduledConnectionTasks)
												{
													this._queueOfScheduledConnectionTasks.Enqueue(reg);
												}
												
											}
											
										}
										
									}
									
								}
								
							}
						}
						
					}
					catch (Exception ex)
					{
						CustomEventLog.DisplayEvent(EventLogEntryType.Error, ex.ToString());
					}
					finally
					{
						if (this._tableOfConnectionRegistersForScheduledConnectionTasks.Count == 0)
						{
							this._publicationsConnectionThread = null;
							continueCycle = false;
						}
						else
						{
							if (this._STXDataSocketClient.IsConnected)
							{
								//is sleeps for 250 ms after attempt to connecto to another publication if the client is connected
								System.Threading.Thread.Sleep(250);
							}
							else
							{
								//if the connection with the server is broken then waits a little bit more to attempt to connect to a publication
								System.Threading.Thread.Sleep(2000);
							}
						}
					}
					
				}
				
			}
			
			internal void AbortScheduledConnectionToAPublication(string publicationName)
			{
				if (this.ContainsScheduledPublicationConnectionTask(publicationName))
				{
					PublicationConnectionTaskInfo reg;
					
					lock(this._tableOfConnectionRegistersForScheduledConnectionTasks)
					{
                        reg = (PublicationConnectionTaskInfo)this._tableOfConnectionRegistersForScheduledConnectionTasks[publicationName];
						reg.keepScheduledConnectionTask = false;
						this._tableOfConnectionRegistersForScheduledConnectionTasks.Remove(publicationName);
					}
					
				}
			}
			
			internal void DisposeAllScheduledConnectionsToPublications()
			{
				try
				{
					lock(this._tableOfConnectionRegistersForScheduledConnectionTasks)
					{
						IEnumerator enumm = default(IEnumerator);
						enumm = this._tableOfConnectionRegistersForScheduledConnectionTasks.GetEnumerator();
						PublicationConnectionTaskInfo reg;
						while (enumm.MoveNext())
						{
                            reg = (PublicationConnectionTaskInfo)((DictionaryEntry)enumm.Current).Value;
							reg.keepScheduledConnectionTask = false;
						}
						this._tableOfConnectionRegistersForScheduledConnectionTasks.Clear();
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
			internal void Reset()
			{
				try
				{
					this.DisposeAllScheduledConnectionsToPublications();
				}
				catch (Exception)
				{
				}
				
				
				try
				{
					this.StopPublicationReconnectionsTask();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._tableOfConnectionInfoRegistersOfConnectionsToPublications.Clear();
				}
				catch (Exception)
				{
				}
				
				try
				{
					this._STXDSSPublicationConnectionHandlersContainer.DiscardAllLocalConnectionsToPublications();
				}
				catch (Exception)
				{
				}
				
			}
			
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
						this._STXDSSPublicationConnectionHandlersContainer.DiscardAllLocalConnectionsToPublications();
						try
						{
							this.DisposeAllScheduledConnectionsToPublications();
						}
						catch (Exception)
						{
						}
						try
						{
							this._reconnectionToPublicationsThread.Abort();
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
		
#region  < SUPPORT CLASS >
		
		internal class PublicationConnectionTaskInfo
		{
			
			public DPE_PublicationConnectionHandler_Type connectionType;
			public string publicationName;
			public DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode;
			//Public ConnectionThread As System.Threading.Thread
			public bool keepScheduledConnectionTask;
			public DateTime creationDateTime;
			
			//Public Sub New(ByVal cnnType As STXDSSC_PublicationConnectionHandler_Type, ByVal STXDSSPublicationName As String, ByVal STXDSSConnectionMode As DPE_PublicationConnectionMode, ByVal ReconnectionToPublicationThread As Threading.Thread)
			public PublicationConnectionTaskInfo(DPE_PublicationConnectionHandler_Type cnnType, string STXDSSPublicationName, DPE_ServerDefs.DPE_PublicationConnectionMode STXDSSConnectionMode)
			{
				this.creationDateTime = DateTime.Now;
				this.connectionType = cnnType;
				this.publicationName = STXDSSPublicationName;
				this.connectionMode = STXDSSConnectionMode;
				//Me.ConnectionThread = ReconnectionToPublicationThread
				this.keepScheduledConnectionTask = true;
			}
			
			public int GetElapsedTimeInSeconds()
			{
				TimeSpan span = this.creationDateTime.Subtract(DateTime.Now);
				return (int) (Math.Abs(span.TotalSeconds));
			}
			
			public void ResetTime()
			{
				this.creationDateTime = DateTime.Now;
			}
			
		}
		
		
#endregion
		
	}
	
}
