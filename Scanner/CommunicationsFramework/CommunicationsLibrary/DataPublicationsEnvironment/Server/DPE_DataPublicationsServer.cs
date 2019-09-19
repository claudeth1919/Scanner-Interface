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
using System.Net;
using CommunicationsLibrary.Services;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.BroadCasting.Handling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Clients;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsConnectionManaging;
using CommunicationsLibrary.Services.MultiCastDataReplication;



namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server
	{
		
		public class DPE_DataPublicationsServer : IUseP2PCommunicationsScheme, IDisposable
		{
			
#region  < DATAMEMBERS >
			
			//***************************************************************
			//variable for sigleton implementation
			private static DPE_DataPublicationsServer _DataPublicationsServer;
			
			//***************************************************************

            //the server runs locally the DATA PUBLICATIONS Server
			
			private Client.PublicationsConnectionManaging.DPE_PublicationsConnectionsProxyServer _DPE_PRoxyClient;
			
			
			private string _hostName;
			
			private string _publicationsDataBaseConnectionString;
			
			//publications manager
			private Server.Handling.Publications.DPE_PublicationsManager _DPE_PublicationsManager;
			
			//manager thar hols the clients connected
			private Server.Handling.Clients.DPE_ClientsManager _DPE_ClientsManager;
			
			//variables to handle the network service
			private DiscoverableServiceDefinitionHandlingServer _DPE_ServiceHandler;
			private DiscoverableServiceDefinitionParametersContainer _DPE_ServicePArametersCont;
			
			//p2p port to handle generic command and data retrieval from the service
			private P2PPort _P2PDefaultConnectionPort;
			
			//*******************************************************
			//p2p ports dedicated specially for publications issues
			//receives the data to create a publication
			private P2PPort _P2PPublicationsPostingDataPort;
			//retrieves to clients the data of the publication in order to allow them to subscribe
			private P2PPort _P2PPublicationsInformationRetrievePort;
			//port to receive the information of the clients that has been conected to ap ublication
			//in order to match a connection with a specific client
			private P2PPort _P2PPublicationsClientRegistrationPort;
			
			
#endregion
			
#region  <  PROPERTIES >
			
public DataTable ServiceParametersTable
			{
				get
				{
					return this._DPE_ServicePArametersCont.ParametersDataTable;
				}
			}
#endregion
			
#region  < CONSTRUCTORS >
			
			private DPE_DataPublicationsServer()
			{
				
				//If ISPreviousServiceRunningOnTheNetwork() Then
                //    Throw New Exception("The 'DATA PUBLICATIONS Service' is already running in the network environment.")
				//End If
				
				try
				{
					this._DPE_PRoxyClient = DPE_PublicationsConnectionsProxyServer.GetInstance();
				}
				catch (Exception)
				{
				}
				
				string errmsg = "";
				
				//************************************************************************************
				//CREATION OF THE CONNECTION STRING TO THE DATA BASE AND TEST OF THE DATA BASE
				this.Get_SetAndTestPublicationsDataBaseConnectionString();
				
				//************************************************************************************
				//CREATION THE DEFAULT P2P PORT OF THE SERVICE FOR GENEREIC DATA RECEPTION AN RETRIEVAL
				try
				{
					this._P2PDefaultConnectionPort = new P2PPort(this, DPE_ServerDefs.DPE_SERVER_DEFAULT_CONNECTION_PORTNUMBER);
					this._P2PDefaultConnectionPort.NewClientConnection += this.NewIncommingConnectionCDB;
					this._P2PDefaultConnectionPort.ClientDisconnection += this.ClientConnectionFinishCDB;
				}
				catch (Exception ex)
				{
                    errmsg = " Error starting the default P2PPort of DATA PUBLICATIONS Service : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
					
					this._P2PDefaultConnectionPort = new P2PPort(this);
					this._P2PDefaultConnectionPort.NewClientConnection += this.NewIncommingConnectionCDB;
					this._P2PDefaultConnectionPort.ClientDisconnection += this.ClientConnectionFinishCDB;

                    errmsg = "The DATA PUBLICATIONS Service default P2PPort was started using a dinamic port number \'" + System.Convert.ToString(this._P2PDefaultConnectionPort.ListeningPortNumber) + "\' out of the  DATA PUBLICATIONS service range (" + System.Convert.ToString(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE) + "-" + System.Convert.ToString(DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE) + ")";
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
				}
				
				
				//************************************************************************************
				//CREATION THE PORT THAT IS USED TO RECEIVE DATA TO CREATE A PUBLICATION
				try
				{
					this._P2PPublicationsPostingDataPort = new P2PPort(this, DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_POSTING_PORTNUMBER);
				}
				catch (Exception ex)
				{
                    errmsg = " Error starting the default P2PPort of DATA PUBLICATIONS Service : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
					
					this._P2PPublicationsPostingDataPort = new P2PPort(this);

                    errmsg = "The DATA PUBLICATIONS Service P2PPublicationsPostingDataPort P2PPort was started using a dinamic port number \'" + System.Convert.ToString(this._P2PDefaultConnectionPort.ListeningPortNumber) + "\' out of the  DATA PUBLICATIONS service range (" + System.Convert.ToString(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE) + "-" + System.Convert.ToString(DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE) + ")";
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
				}
				
				//************************************************************************************
				//CREATION THE PORT THAT IS USED TO RETRIEVE PUBLICATIONS DATA TO THE CLIENTS
				try
				{
					this._P2PPublicationsInformationRetrievePort = new P2PPort(this, DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_INFORMATION_PORTNUMBER);
				}
				catch (Exception ex)
				{
                    errmsg = " Error starting the default P2PPort of DATA PUBLICATIONS Service : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
					
					this._P2PPublicationsInformationRetrievePort = new P2PPort(this);

                    errmsg = "The DATA PUBLICATIONS Service P2PPublicationsInformationRetrievePort P2PPort was started using a dinamic port number \'" + System.Convert.ToString(this._P2PDefaultConnectionPort.ListeningPortNumber) + "\' out of the  DATA PUBLICATIONS service range (" + System.Convert.ToString(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE) + "-" + System.Convert.ToString(DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE) + ")";
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
				}
				
				//************************************************************************************
				//CREATION THE PORT THAT IS USED TO RECEIVE THE CLIENTES CONNECTION DATA
				try
				{
					this._P2PPublicationsClientRegistrationPort = new P2PPort(this, DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_CLENTS_REGISTRATION_PORTNUMBER);
				}
				catch (Exception ex)
				{
                    errmsg = " Error starting the default P2PPort of DATA PUBLICATIONS Service : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
					
					this._P2PPublicationsClientRegistrationPort = new P2PPort(this);

                    errmsg = "The DATA PUBLICATIONS Service P2PPublicationsInformationRetrievePort P2PPort was started using a dinamic port number \'" + System.Convert.ToString(this._P2PDefaultConnectionPort.ListeningPortNumber) + "\' out of the  DATA PUBLICATIONS service range (" + System.Convert.ToString(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE) + "-" + System.Convert.ToString(DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE) + ")";
					CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
				}
				
				
				this._DPE_PublicationsManager = new DPE_PublicationsManager(this._publicationsDataBaseConnectionString);
				
				//************************************************************************************
				//GETS LOCAL HOST NAME
				this._hostName = System.Net.Dns.GetHostName();
				
				
				
				//crates the service parameters to publish throuGh the STXServiceDefinitionHandlerServer
				this._DPE_ServicePArametersCont = new DiscoverableServiceDefinitionParametersContainer();
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT, System.Convert.ToString(this._P2PDefaultConnectionPort.ListeningPortNumber));
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME, System.Convert.ToString(this._hostName));
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT, System.Convert.ToString(this._P2PPublicationsPostingDataPort.ListeningPortNumber));
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT, System.Convert.ToString(this._P2PPublicationsInformationRetrievePort.ListeningPortNumber));
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT, System.Convert.ToString(this._P2PPublicationsClientRegistrationPort.ListeningPortNumber));
				this._DPE_ServicePArametersCont.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING, System.Convert.ToString(this._publicationsDataBaseConnectionString));
				
				
				this._DPE_ServicePArametersCont.SaveToFile(DPE_ServerDefs.DPE_SERVER_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME);
				
				
				//creates the service handler as singleton
				this._DPE_ServiceHandler = new DiscoverableServiceDefinitionHandlingServer(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode.singletonInstanceNetworkService, DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_NAME, this._DPE_ServicePArametersCont);
				
				this._DPE_ClientsManager = new DPE_ClientsManager();
				
				string msg = "";
				msg = "DATA PUBLICATIONS SERVER Started Succesfully @ " + this._hostName + "   On    " + DateTime.Now.ToString();
				CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, msg);
				
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			
			
			private void Get_SetAndTestPublicationsDataBaseConnectionString()
			{
				
				//*****************************************
				DPE_GlobalDefinitions.Create_MAIN_DPE_SERVER_PublicationsDataBaseIfNotExists(this._hostName);
				//*****************************************
				
				this._hostName = System.Net.Dns.GetHostName();
				
				this._publicationsDataBaseConnectionString = DPE_GlobalDefinitions.Get_DPE_ServicePublicationsDBConnectionString(DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_NAME);
				
				using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._publicationsDataBaseConnectionString))
				{
					try
					{
						cnn.Open();
					}
					catch (Exception)
					{
						CustomEventLog.WriteEntry(EventLogEntryType.FailureAudit, "Unable to connecto to local server publications data base \'" + DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_NAME + "\'");
					}
					finally
					{
						try
						{
							cnn.Close();
							cnn.Dispose();
						}
						catch (Exception)
						{
						}
					}
				}
				
				
			}
			
			
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			public static DPE_DataPublicationsServer GetInstance()
			{
				if (_DataPublicationsServer == null)
				{
					_DataPublicationsServer = new DPE_DataPublicationsServer();
				}
				return _DataPublicationsServer;
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
#region  < P2PPORT  FOR CLIENTS CONNECTIONS >
			
			private void NewIncommingConnectionCDB(string ClientID)
			{
				try
				{
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void ClientConnectionFinishCDB(string clientID)
			{
				try
				{
					this.DisposeClient(clientID);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#endregion
			
			public void ExportServerParametersToFile(string filePath)
			{
				this._DPE_ServicePArametersCont.SaveToFile(filePath, DPE_ServerDefs.DPE_SERVER_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME);
			}
			
#region  <  FRIEND METHODS >
			
			//Friend Function GetSTXDSSClientByItsSocketConnectionHandler(ByVal clientConnectionHandler As SocketsServerClientConnectionHandler) As DPE_Client
			//    Return Me._DPE_ClientsManager.GetClientByItsConnectionHandler(clientConnectionHandler)
			//End Function
			
#endregion
			
#region  < SERVICE HANDLING >
			
			private bool ISPreviousServiceRunningOnTheNetwork()
			{
				DiscoverableServiceDefinitionHandlingClient STXServiceClient = null;
				try
				{
					DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDefinition;
					STXServiceClient = new DiscoverableServiceDefinitionHandlingClient(Guid.NewGuid().ToString());
					serviceDefinition = STXServiceClient.FindService(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_NAME);
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
			
#endregion
			
#region  < DPE CLIENTS HANDLING >
			
			private void DisposeClient(string ClientID)
			{
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByNetworkID(ClientID);
				if (!(client == null))
				{
					this._DPE_ClientsManager.RemoveClient(client);
					
					//if a client is apublisher the shutdowns all its publications
					if (this._DPE_PublicationsManager.IsClientRegisteredAsPublisher(client))
					{
						this._DPE_PublicationsManager.DisposeClientPublications(client);
					}
					
				}
				
			}
			
			private void Handle_DPE_CMD_CLIENT_REGISTRATION_DATA(P2PData data)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to update the name of a subscriptor. The paramter \'DPE_CLIENT_ID\' is missing."));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				
				//-----
				if (!data.DataAttributesTable.ContainsAttribute(DPE_ServerDefs.DPE_CLIENT_NETWORK_ID))
				{
					throw (new Exception("Unable to update the name of a subscriptor. The paramter \'DPE_CLIENT_NETWORK_ID\' is missing."));
				}
				
				string clientNetworkID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_ServerDefs.DPE_CLIENT_NETWORK_ID);
				clientNetworkID = attr.AttrValue;
				
				
				//-----
				
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_NAME))
				{
					throw (new Exception("Unable to update the name of a subscriptor. The paramter \'DPE_CLIENT_NAME\' is missing."));
				}
				
				string clientName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_NAME);
				clientName = attr.AttrValue;
				
				//-----
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_ServerDefs.DPE_CLIENT_HOST_NAME))
				{
					throw (new Exception("Unable to update the name of a subscriptor. The paramter \'DPE_CLIENT_HOST_NAME\' is missing."));
				}
				
				string clientHostName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_ServerDefs.DPE_CLIENT_HOST_NAME);
				clientHostName = attr.AttrValue;
				
				//----
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_ServerDefs.DPE_CLIENT_APPDOMAIN_NAME))
				{
					throw (new Exception("Unable to update the name of a subscriptor. The paramter \'DPE_CLIENT_APPDOMAIN_NAME\' is missing."));
				}
				
				string clientAppdomain = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_ServerDefs.DPE_CLIENT_APPDOMAIN_NAME);
				clientAppdomain = attr.AttrValue;
				
				
				string clientTypeAsString = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_ServerDefs.DPE_CLIENT_TYPE);
				clientTypeAsString = attr.AttrValue;
				DPE_ClientType type = default(DPE_ClientType);
				type = DPE_DataPublicationsClient.Get_DSSClientType_From_String(clientTypeAsString);
				
				this._DPE_ClientsManager.CreateClientRegistration(type, clientID, clientNetworkID, clientName, clientHostName, clientAppdomain);
				
			}
			
			private P2PData Handle_DPE_CLIENTS_REGISTRY_TABLE(P2PDataRequest dataRequest)
			{
				P2PData subscriptorsTableP2PData = new P2PData(dataRequest.RequestedDataName, this._DPE_ClientsManager.ClientsTable);
				return subscriptorsTableP2PData;
			}
			
#endregion
			
#region  < PUBLICATIONS HANDLING >
			
			private void Handle_DPE_CMD_CREATE_PUBLICATION(P2PData data)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP))
				{
					throw (new Exception("Can\'t create the data publication because the parameter \'DPE_PUBLICATIONS_GROUP\' is missing"));
				}
				
				string publicationsGroup = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP);
				publicationsGroup = attr.AttrValue.ToUpper();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t create the data publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Can\'t create the data publication \'" + publicationName + "\'. The parameter \'DPE_CLIENT_ID\' is missing."));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				//'evaluates if a previous publication with the specified name already exists
				if (this._DPE_PublicationsManager.ContainsPublication(publicationName))
				{
					DPE_Publication pub = this._DPE_PublicationsManager.GetPublication(publicationName);
					throw (new Exception("The data publication \'" + publicationName + "\' already exists published by \'" + pub.publisherSTXDSSClient.Name + "\'"));
				}
				
				DPE_Client client = this._DPE_ClientsManager.GetClientByID(clientID);
				if (!(client == null))
				{
					
					DPE_Publication newPublication = new DPE_Publication(this._publicationsDataBaseConnectionString, publicationsGroup, publicationName, client);
					
					CustomHashTable variablesToPublishTable = data.Value;
					IEnumerator enumm = variablesToPublishTable.GetEnumerator();
					string variableName = "";
					string variableDataType = "";
					while (enumm.MoveNext())
					{
						variableName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
						variableDataType = System.Convert.ToString(((DictionaryEntry) enumm.Current).Value);
						DPE_ServerDefs.PublicationVariableDataType dataType = default(DPE_ServerDefs.PublicationVariableDataType);
						dataType = DPE_ServerDefs.Get_PublicationVariableDataType_FromString(variableDataType);
						newPublication.AddVariableToDataPublication(variableName, dataType);
					}
					
					this._DPE_PublicationsManager.AddPublication(newPublication);
					
				}
				else
				{
					throw (new Exception("Invalid client id \'" + clientID + "\'. The client is not registered"));
				}
				
			}
			
			private void Handle_DPE_CMD_DISPOSE_PUBLICATION(P2PData data)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to remove the data publication because the parameter \'DPE_CLIENT_ID\' is missing"));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to remove the data publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				
				//evaluates if a previous publication with the specified name already exists
				if (this._DPE_PublicationsManager.ContainsPublication(publicationName))
				{
					DPE_Publication pub = this._DPE_PublicationsManager.GetPublication(publicationName);
					if (pub.publisherSTXDSSClient.ClientID == clientID)
					{
						pub.ShutDownPublication();
						
					}
					else
					{
						throw (new Exception("Only the publisher client can shutdown the publication \'" + publicationName + "\'"));
					}
				}
			}
			
			private void Handle_DPE_CMD_ADD_PUBLICATION_VARIABLE(P2PData data)
			{
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to add a variable to a data publication because the parameter \'DPE_CLIENT_ID\' is missing"));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByID(clientID);
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to add a variable to a data publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME))
				{
					throw (new Exception("Unable to add a variable to a data publication because the parameter \'DPE_PUBLICATION_VARIABLE_NAME\' is missing"));
				}
				
				string VariableName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME);
				VariableName = attr.AttrValue.ToUpper();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_DATA_TYPE))
				{
					throw (new Exception("Unable to add a variable to a data publication because the parameter \'DPE_PUBLICATION_VARIABLE_DATA_TYPE\' is missing"));
				}
				
				string dataTypeAsString = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_DATA_TYPE);
				dataTypeAsString = attr.AttrValue.ToUpper();
				
				DPE_ServerDefs.PublicationVariableDataType dataType = default(DPE_ServerDefs.PublicationVariableDataType);
				dataType = DPE_ServerDefs.Get_PublicationVariableDataType_FromString(dataTypeAsString);
				
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				
				if (!(publication == null))
				{
					//only the client that is the owner of the publication can update it
					if (publication.publisherSTXDSSClient.ClientID == clientID)
					{
						if (!publication.ContainsVariable(VariableName))
						{
							publication.AddVariableToDataPublication(VariableName, dataType);
							
							//'--------------------------------------------------
							//'broad cast the status of the service
							//Try
							//    'brod cast the status of a new variable created
							//    Dim statusData As New SocketData(DPE_PUBLICATION_VARIABLE_ADDED, DPE_PUBLICATION_VARIABLE_ADDED)
							//    statusData.AttributesTable.AddAttribute("CLIENT_ID", clientID)
							//    statusData.AttributesTable.AddAttribute("PUBLICATION_NAME", publicationName)
							//    statusData.AttributesTable.AddAttribute("VARIABLE_NAME", VariableName)
							//    statusData.AttributesTable.AddAttribute("VARIABLE_DATA_TYPE", dataTypeAsString)
							//    Me._MultiCastDataReplicationServer.BroadCastData(statusData.XMLDataString)
							//Catch ex As Exception
							
							//End Try
							
						}
						else
						{
							string msg = "";
							msg = "Unable to add a variable to the data publication \' " + publicationName + ",it already contains the variable \'" + VariableName + "\'";
							throw (new Exception(msg));
						}
					}
					else
					{
						string msg = "";
						msg = "Unable to add a variable to the data publication \' " + publicationName + "\', The client \'" + client.Name + "\' is not the owner of the publication.";
						throw (new Exception(msg));
					}
				}
				else
				{
					string msg = "";
					msg = "Unable to add a variable to the data publication \' " + publicationName + "\', The publication no longer exists.";
					throw (new Exception(msg));
				}
				
				
			}
			
			private void Handle_DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES(P2PData data)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to remove a variable from a data publication because the parameter \'DPE_CLIENT_ID\' is missing"));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to add a variable to a data publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				
				if (!(publication == null))
				{
					//only the client that is the owner of the publication can update it
					if (publication.publisherSTXDSSClient.ClientID == clientID)
					{
						
						DataTable groupOfVariablesDefinitionTable = (System.Data.DataTable) data.Value;
						IEnumerator Rowenumm = groupOfVariablesDefinitionTable.Rows.GetEnumerator();
						
						DataRow row = default(DataRow);
						string variableName = "";
						string varDataTypeAsString = "";
						DPE_ServerDefs.PublicationVariableDataType dataType = default(DPE_ServerDefs.PublicationVariableDataType);
						
						while (Rowenumm.MoveNext())
						{
							row = (DataRow)Rowenumm.Current;
							variableName = System.Convert.ToString(row[DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME]);
							varDataTypeAsString = System.Convert.ToString(row[DPE_ServerDefs.DATATYPE_TABLE_COLUMN_NAME]);
							dataType = DPE_ServerDefs.Get_PublicationVariableDataType_FromString(varDataTypeAsString);
							try
							{
								publication.AddVariableToDataPublication(variableName, dataType);
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
					}
				}
			}
			
			private void Handle_DPE_CMD_REMOVE_PUBLICATION_VARIABLE(P2PData data)
			{
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to remove a variable from a data publication because the parameter \'DPE_CLIENT_ID\' is missing"));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByID(clientID);
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to remove a variable from a data publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME))
				{
					throw (new Exception("Unable to remove a variable from a data publication because the parameter \'DPE_PUBLICATION_VARIABLE_NAME\' is missing"));
				}
				
				string VariableName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_VARIABLE_NAME);
				VariableName = attr.AttrValue.ToUpper();
				
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				
				if (!(publication == null))
				{
					//only the client that is the owner of the publication can update it
					if (publication.publisherSTXDSSClient.ClientID == clientID)
					{
						if (publication.ContainsVariable(VariableName))
						{
							publication.RemoveVariableFromDataPublication(VariableName);
							
						}
						else
						{
							string msg = "";
							msg = "Unable to remove a variable from the data publication \' " + publicationName + ", not contains the variable \'" + VariableName + "\'";
							throw (new Exception(msg));
						}
					}
					else
					{
						string msg = "";
						msg = "Unable to remove a variable from the data publication \' " + publicationName + "\', The client \'" + client.Name + "\' is not the owner of the publication.";
						throw (new Exception(msg));
					}
				}
				else
				{
					string msg = "";
					msg = "Unable to remove a variable from the data publication \' " + publicationName + "\', The publication no longer exists.";
					throw (new Exception(msg));
				}
				
			}
			
			private dynamic Handle_STX_DSS_PUBLICATION_SUBSCRIPTION_DATA(P2PDataRequest dataRequest)
			{
				
				if (!dataRequest.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t retrieve the information to stablish a connection to a publication because the paremter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				publicationName = dataRequest.GetRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				
				if (this._DPE_PublicationsManager.ContainsPublication(publicationName))
				{
					DPE_Publication publication = default(DPE_Publication);
					publication = this._DPE_PublicationsManager.GetPublication(publicationName);
					CustomHashTable paramsTAble = publication.GetPublicationParametersTable();
					P2PData requestedData = new P2PData(dataRequest.RequestedDataName, paramsTAble);
					return requestedData;
				}
				else
				{
					throw (new Exception("The publication named \'" + publicationName + "\' don\'t exists."));
				}
			}
			
			private P2PData Handle_STX_DSS_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY(P2PDataRequest dataRequest)
			{
				
				if (!dataRequest.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Can\'t retrieve the information verify a clients socket connection to a publication because the parameter \'DPE_CLIENT_ID\' is missing"));
				}
				
				if (!dataRequest.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t retrieve the information verify a clients socket connection to a publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				if (!dataRequest.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_CONNECTION_HANDLER_ID))
				{
					throw (new Exception("Can\'t retrieve the information verify a clients socket connection to a publication because the parameter \'DPE_PUBLICATION_CONNECTION_HANDLER_ID\' is missing"));
				}
				
				
				string clientID = dataRequest.GetRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				string publicationName = dataRequest.GetRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				string publicationHandlerID = dataRequest.GetRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_CONNECTION_HANDLER_ID);
				
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByID(clientID);
				
				if (client == null)
				{
					throw (new Exception("Can\'t retrieve the information verify a clients socket connection to a publication because the specified client does not exists"));
				}
				
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				if (publication == null)
				{
					throw (new Exception("Can\'t retrieve the information verify a clients socket connection to a publication because the specified publication \'" + publicationName + "\' does not exists"));
				}
				
				bool result = publication.STXDSSClientSocketConnectionInquiry(client, publicationHandlerID);
				P2PData returnREsult = new P2PData(DPE_ServerDefs.DPE_CMD_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY, result);
				return returnREsult;
				
			}
			
			private void Handle_DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION(P2PData data)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				//*****************************************************************************
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Can\'t perform the connection of the client to a publication, the parameter \'DPE_CLIENT_ID\' is missing in the command."));
				}
				
				string clientID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				clientID = attr.AttrValue;
				
				//*****************************************************************************
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t perform the connection of the client to a publication, the parameter \'DPE_PUBLICATION_NAME\' is missing in the command."));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue;
				
				//*****************************************************************************
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CONNECTION_HANDLER_ID))
				{
					throw (new Exception("Can\'t perform the connection of the client to a publication, the parameter \'DPE_PUBLICATION_CONNECTION_HANDLER_ID\' is missing in the command."));
				}
				
				string clientPublicationConnectionHandlerID = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CONNECTION_HANDLER_ID);
				clientPublicationConnectionHandlerID = attr.AttrValue;
				
				//*****************************************************************************
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CLIENT_CONNECTION_MODE))
				{
					throw (new Exception("Can\'t perform the connection of the client to a publication, the parameter \'DPE_PUBLICATION_CLIENT_CONNECTION_MODE\' is missing in the command."));
				}
				
				string connectionModeAsString = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_CLIENT_CONNECTION_MODE);
				connectionModeAsString = attr.AttrValue;
				DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode = default(DPE_ServerDefs.DPE_PublicationConnectionMode);
				connectionMode = DPE_ServerDefs.Get_STXDSS_PublicationConnectionMode_FromString(connectionModeAsString);
				
				
				
				//*****************************************************************************
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByID(clientID);
				
				if (client == null)
				{
					throw (new Exception("Can\'t perform the connection of the client to the publication \'" + publicationName + "\' : the client specified doesnt exists."));
				}
				
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				if (publication == null)
				{
					throw (new Exception("Can\'t perform the connection of the client to a publication, the publication \'" + publicationName + "\' not exists."));
				}
				
				try
				{
					publication.STXDSSClientConnectionIdentificationAndConnection(client, clientPublicationConnectionHandlerID, connectionMode);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
					throw (ex);
				}
				
			}
			
			private P2PData Handle_STX_DSS_PUBLICATIONS_REGISTRY_TABLE(P2PDataRequest dataRequest)
			{
				DataTable PublicationsRegistryTable = default(DataTable);
				PublicationsRegistryTable = this._DPE_PublicationsManager.PublicationsRegistryTable;
				P2PData data = new P2PData(dataRequest.RequestedDataName, PublicationsRegistryTable);
				return data;
			}
			
			private P2PData Handle_STX_DSS_PUBLISHER_CLIENTS_REGISTRY_TABLE(P2PDataRequest dataRequest)
			{
				DataTable publihsersRegistryTable = default(DataTable);
				publihsersRegistryTable = this._DPE_PublicationsManager.PublihsersRegistryTable;
				P2PData data = new P2PData(dataRequest.RequestedDataName, publihsersRegistryTable);
				return data;
			}
			
			private P2PData Handle_STX_DSS_PUBLICATION_PUBLISHED_VARIABLES_TABLE(P2PDataRequest request)
			{
				
				if (!request.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t rettieve the list of variables contained in a publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = request.GetRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				DataTable dt = default(DataTable);
				if (!(publication == null))
				{
					dt = publication.PublishedVariablesTable;
				}
				else
				{
					dt = new DataTable();
				}
				P2PData data = new P2PData(request.RequestedDataName, dt);
				return data;
			}
			
			private P2PData Handle_STX_DSS_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST(P2PDataRequest request)
			{
				//returns a table containig the relation of publications to where a client is connected to
				if (!request.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to retrieve the list of the subscribed publications. The paramter \'DPE_CLIENT_ID\' is missing."));
				}
				
				string clientID = "";
				clientID = request.GetRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				
				DPE_Client client = default(DPE_Client);
				client = this._DPE_ClientsManager.GetClientByID(clientID);
				CustomList list = default(CustomList);
				if (!(client == null))
				{
					list = this._DPE_PublicationsManager.GetClientListOfConnectionsToPublications(client);
				}
				else
				{
					list = new CustomList();
				}
				P2PData data = new P2PData(request.RequestedDataName, list);
				return data;
			}
			
			private P2PData Handle_STX_DSS_CLIENT_POSTED_PUBLICATIONS_LIST(P2PDataRequest request)
			{
				//retrieves a list of all the publications created and posted by a client
				if (!request.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Unable to retrieve the list of posted publications of a client. The paramter \'DPE_CLIENT_ID\' is missing."));
				}
				
				string clientID = "";
				clientID = request.GetRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				
				DPE_Client client = this._DPE_ClientsManager.GetClientByID(clientID);
				CustomList list = default(CustomList);
				if (!(client == null))
				{
					list = this._DPE_PublicationsManager.GetListOfClientPostedPublications(client);
				}
				else
				{
					list = new CustomList();
				}
				
				P2PData data = new P2PData(request.RequestedDataName, list);
				return data;
			}
			
			private P2PData Handle_STX_DSS_PUBLICATION_ATTACHED_CLIENTS_TABLE(P2PDataRequest request)
			{
				//retrieves the relation list of all the available clients connected to a specific publication
				
				if (!request.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Can\'t rettieve the list of clients subscribed to a publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				publicationName = request.GetRequestParameter(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				
				DPE_Publication pub = this._DPE_PublicationsManager.GetPublication(publicationName);
				if (!(pub == null))
				{
					P2PData requestedData = new P2PData(request.RequestedDataName, pub.SubscriptorsTable);
					return requestedData;
				}
				else
				{
					throw (new Exception("The publication \'" + publicationName + "\' not exists."));
				}
			}
			
			private P2PData Handle_STX_DSS_POSTED_CLIENT_PUBLICATIONS(P2PDataRequest p2pDataRequest)
			{
				
				if (!p2pDataRequest.ContainsRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID))
				{
					throw (new Exception("Can\'t retrieve the table of publications posted by client. The parameter \'DPE_CLIENT_ID\' is missing in the request command."));
				}
				
				string clientID = "";
				clientID = p2pDataRequest.GetRequestParameter(DPE_PublicationsDefinitions.DPE_CLIENT_ID);
				
				DPE_Client client = this._DPE_ClientsManager.GetClientByID(clientID);
				if (!(client == null))
				{
					DataTable dt = default(DataTable);
					dt = this._DPE_PublicationsManager.GetTableOfPublicationsPostedByClient(client);
					P2PData requestedData = new P2PData(p2pDataRequest.RequestedDataName, dt);
					return requestedData;
				}
				else
				{
					throw (new Exception("Invalid client id \'" + clientID + "\'. The client is not registered"));
				}
			}
			
			private void handle_DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS(P2PData data)
			{
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to RESET data statistics of publication because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue.ToUpper();
				DPE_Publication publication = default(DPE_Publication);
				publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				publication.ResetStatistics();
				
			}
			
			private void habdle_DPE_CMD_SET_PUBLICATION_GROUP(P2PData data)
			{
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP))
				{
					throw (new Exception("Unable to move publication to a group of publications because the parameter \'DPE_PUBLICATIONS_GROUP\' is missing"));
				}
				
				string publicationsGroup = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP);
				publicationsGroup = attr.AttrValue;
				
				
				if (!data.DataAttributesTable.ContainsAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME))
				{
					throw (new Exception("Unable to move publication to a group of publications because the parameter \'DPE_PUBLICATION_NAME\' is missing"));
				}
				
				string publicationName = "";
				attr = data.DataAttributesTable.GetAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME);
				publicationName = attr.AttrValue;
				
				DPE_Publication publication = this._DPE_PublicationsManager.GetPublication(publicationName);
				publication.SetPublicationsGroup(publicationsGroup);
				
			}
			
#endregion
			
#region  < CLIENT DATA RECEPTIONS AND REQUEST FUNCTIONS THROUG ITS P2PPORTS >
			
			internal void ReceiveAndProcess_Data_From_DPEClient(Services.P2PCommunicationsScheme.Data.P2PData data, int portNumber)
			{
				//This interface funcion handles the data received for the operations of publications
				//creation and removal, and the subscription additions and removal
				switch (data.DataName)
				{
					case DPE_ServerDefs.DPE_CMD_CREATE_PUBLICATION:
						this.Handle_DPE_CMD_CREATE_PUBLICATION(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_DISPOSE_PUBLICATION:
						this.Handle_DPE_CMD_DISPOSE_PUBLICATION(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_ADD_PUBLICATION_VARIABLE:
						this.Handle_DPE_CMD_ADD_PUBLICATION_VARIABLE(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES:
						this.Handle_DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_REMOVE_PUBLICATION_VARIABLE:
						this.Handle_DPE_CMD_REMOVE_PUBLICATION_VARIABLE(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_CLIENT_REGISTRATION_DATA:
						this.Handle_DPE_CMD_CLIENT_REGISTRATION_DATA(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION:
						this.Handle_DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS:
						this.handle_DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS(data);
						break;
						
					case DPE_ServerDefs.DPE_CMD_SET_PUBLICATION_GROUP:
						this.habdle_DPE_CMD_SET_PUBLICATION_GROUP(data);
						break;
						
						
				}
			}
			
			internal P2PData ReceiveAndProcessRequest_to_Retrieve_Data_To_DPEClient(P2PDataRequest dataRequest, int portNumber)
			{
				switch (dataRequest.RequestedDataName)
				{
					
					//*******************************************************************************
					//!!!!!!!!!!!!!!!! IMPORTAT EVALUATION TO CONFIRM TO CLIENT THAT THE CONNECTION
					//BELONGS TO THE SXT DATA SOCKET SERVICE
					//*******************************************************************************
				case DPE_ServerDefs.DPE_PUBLICATIONS_SERVICE_PORT_CONNECTION_CHECK_DATA:
					P2PData conformationDAta = new P2PData(DPE_ServerDefs.DPE_PUBLICATIONS_SERVICE_PORT_CONNECTION_CHECK_DATA, true);
					return conformationDAta;
					//*******************************************************************************
					//*******************************************************************************
					
				case DPE_ServerDefs.DPE_CMD_PUBLICATION_SUBSCRIPTION_DATA: //ok , clientok
					//retrieves to the client the data of the required publication in order
					//to allow the remote client stablish a connection with the requested publication
					return this.Handle_STX_DSS_PUBLICATION_SUBSCRIPTION_DATA(dataRequest);
					
				case DPE_ServerDefs.DME_CMD_SERVICE_PARAMETERS: //ok , clientok
					//returns the table of the data socket service parameters
					P2PData serviceParams = new P2PData(dataRequest.RequestedDataName, this._DPE_ServicePArametersCont.ParametersDataTable);
					return serviceParams;
					
				case DPE_ServerDefs.DPE_CMD_CLIENTS_REGISTRY_TABLE: //ok , client ok
					//returns the table of all the clients connected to the data socket service
					return this.Handle_DPE_CLIENTS_REGISTRY_TABLE(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_PUBLISHER_CLIENTS_REGISTRY_TABLE: //ok  client ok
					//returns a table contaning the reference of the clients that are registered
					//as publishers
					return this.Handle_STX_DSS_PUBLISHER_CLIENTS_REGISTRY_TABLE(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_PUBLICATIONS_REGISTRY_TABLE: //ok  client ok
					//returns the table of all the availabe publications registered
					//within the service
					return this.Handle_STX_DSS_PUBLICATIONS_REGISTRY_TABLE(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_PUBLICATION_PUBLISHED_VARIABLES_TABLE: //ok client ok
					//returns the table of the published variables contained in a specific publication
					return this.Handle_STX_DSS_PUBLICATION_PUBLISHED_VARIABLES_TABLE(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST: //ok  client ok
					//returns a table of all the subscriptions of a specific client
					return this.Handle_STX_DSS_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_CLIENT_POSTED_PUBLICATIONS_LIST: //ok  client ok
					//return a list of all the publications created by a client
					return this.Handle_STX_DSS_CLIENT_POSTED_PUBLICATIONS_LIST(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_PUBLICATION_ATTACHED_CLIENTS_TABLE: //ok , client ok
					//returns the list of the clients attached to a publication
					return Handle_STX_DSS_PUBLICATION_ATTACHED_CLIENTS_TABLE(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_CLIENT_POSTED_PUBLICATIONS_TABLE:
					return Handle_STX_DSS_POSTED_CLIENT_PUBLICATIONS(dataRequest);
					
				case DPE_ServerDefs.DPE_CMD_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY:
					return this.Handle_STX_DSS_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY(dataRequest);
					
				default:
					return null;
			}
		}
		
#endregion
		
#region  < SERVER STATUS BROADCASTING >
		
		
		
#endregion
		
#region  < FRIEND SHARED METHODS >
		
		internal static DiscoverableServiceDefinitionParametersContainer GetLocalHostServiceDefaultParameters()
		{
			string hostNAme = Dns.GetHostName();
			
			DiscoverableServiceDefinitionParametersContainer @params = new DiscoverableServiceDefinitionParametersContainer();
			
			@params = new DiscoverableServiceDefinitionParametersContainer();
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_P2P_PORT, System.Convert.ToString(DPE_ServerDefs.DPE_SERVER_DEFAULT_CONNECTION_PORTNUMBER));
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_HOSTNAME, System.Convert.ToString(hostNAme));
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT, System.Convert.ToString(DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_POSTING_PORTNUMBER));
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT, System.Convert.ToString(DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_INFORMATION_PORTNUMBER));
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT, System.Convert.ToString(DPE_ServerDefs.DPE_SERVER_PUBLICATIONS_CLENTS_REGISTRATION_PORTNUMBER));
			
			string cnnString = DPE_GlobalDefinitions.Get_DPE_ServicePublicationsDBConnectionString(DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_NAME);
			@params.AddParameter(DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING, System.Convert.ToString(cnnString));
			
			return @params;
			
		}
		
#endregion
		
#region  < INTERFACE IMPLEMENTATION  >
		
#region  < IUseP2PCommunicationsScheme >
		
public Services.P2PCommunicationsScheme.P2PPort P2PSocketPort
		{
			get
			{
				return this._P2PDefaultConnectionPort;
			}
		}
		
public string P2PPortOwnerName
		{
			get
			{
				return DPE_ServerDefs.DATA_PUBLICATIONS_SERVICE_SERVER_NAME;
			}
		}
		
		public void ReceiveData(Services.P2PCommunicationsScheme.Data.P2PData data, int P2PPortNumber)
		{
			this.ReceiveAndProcess_Data_From_DPEClient(data, P2PPortNumber);
		}
		
		public Services.P2PCommunicationsScheme.Data.P2PData RetrieveData(P2PDataRequest dataRequest, int P2PPortNumber)
		{
			return ReceiveAndProcessRequest_to_Retrieve_Data_To_DPEClient(dataRequest, P2PPortNumber);
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
					
					try
					{
						this._DPE_ServiceHandler.Dispose();
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._P2PDefaultConnectionPort.Dispose();
					}
					catch (Exception)
					{
					}
					
					
					try
					{
						this._DPE_PRoxyClient.Dispose();
					}
					catch (Exception)
					{
					}
					
					try
					{
						//shutdowns all the availabel publications
						this._DPE_PublicationsManager.Dispose();
					}
					catch (Exception)
					{
					}
					
					try
					{
						DPE_GlobalDefinitions.DISPOSE_MAIN_DPE_SERVER_PublicationsDataBase();
					}
					catch (Exception)
					{
					}
					
					string msg = "";
					string hostname = System.Net.Dns.GetHostName();
					msg = "DATA PUBLICATIONS SERVER Shutdown @ " + hostname + "   on   " + DateTime.Now.ToString();
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
