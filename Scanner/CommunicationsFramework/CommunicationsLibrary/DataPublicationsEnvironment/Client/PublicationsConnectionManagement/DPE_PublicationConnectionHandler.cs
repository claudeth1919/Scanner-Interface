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
using UtilitiesLibrary.Services.DataCompression;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using System.Threading;



namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsConnectionManaging
	{
		
		
		internal enum DPE_PublicationConnectionHandler_Type
		{
			publisherHandler,
			subscriptorHandler
		}
		
		internal class DPE_PublicationConnectionHandler : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private DPE_DataPublicationsClient _STXDataSocketClient;
			
			private DPE_PublicationConnectionHandler_Type _handlerType;
			
			private string _publicationName;
			private string _publicationHostNAme;
			private int _publicationPort;
			
			//socket server that handlers the socket connection to detect the spcket status of the publication
			private SocketsServerClient _PublicationSocketsServerClient;
			
			private DPE_ServerDefs.DPE_PublicationConnectionMode _connectionMode;
			
			private DPE_PublicationsConnectionsProxyServerClient _STXDSSC_PublicationsProxyConnectionsServerClient;
			
			//object that watches the data updates in the local publication data base
			private DPE_PublicationsSQLReader _DSSPublicationsSQLReader;
			
			
			//object that writes data to the publication
			private DPE_PublicationsSQLWriter _DSSPublicationsSQLWriter;
			
			
			
#endregion
			
#region  <  EVENTS >
			
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
			
			internal delegate void ConnectionToPublicationLostEventHandler(string publictionName);
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
			
			internal delegate void PublicationsProxyServerConnectionBrokenEventHandler(DPE_PublicationConnectionHandler handler);
			private PublicationsProxyServerConnectionBrokenEventHandler PublicationsProxyServerConnectionBrokenEvent;
			
			internal event PublicationsProxyServerConnectionBrokenEventHandler PublicationsProxyServerConnectionBroken
			{
				add
				{
					PublicationsProxyServerConnectionBrokenEvent = (PublicationsProxyServerConnectionBrokenEventHandler) System.Delegate.Combine(PublicationsProxyServerConnectionBrokenEvent, value);
				}
				remove
				{
					PublicationsProxyServerConnectionBrokenEvent = (PublicationsProxyServerConnectionBrokenEventHandler) System.Delegate.Remove(PublicationsProxyServerConnectionBrokenEvent, value);
				}
			}
			
			
			
#endregion
			
#region  < PROPERTIES  >
			
public string PublicationName
			{
				get
				{
					return this._publicationName;
				}
			}
			
public string HandlerID
			{
				get
				{
					return this._PublicationSocketsServerClient.ClientID;
				}
			}
			
public DPE_ServerDefs.DPE_PublicationConnectionMode ConnectionMode
			{
				get
				{
					return this._connectionMode;
				}
			}
			
public DPE_PublicationConnectionHandler_Type HandlerType
			{
				get
				{
					return this._handlerType;
				}
			}
			
internal DPE_PublicationsSQLReader PublicationReader
			{
				get
				{
					return this._DSSPublicationsSQLReader;
				}
			}
			
internal DPE_PublicationsSQLWriter PublicationWriter
			{
				get
				{
					return this._DSSPublicationsSQLWriter;
				}
			}
			
#endregion
			
#region  < CONSTUCTORS >
			
			public DPE_PublicationConnectionHandler(DPE_PublicationConnectionHandler_Type handlerType, DPE_DataPublicationsClient client, string PublicationName, string PublicationHostName, int publicationsSocketsServerPortNumber, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				//*************************************************************************************
				this._STXDSSC_PublicationsProxyConnectionsServerClient = DPE_PublicationsConnectionsProxyServerClient.GetInstance(client.PublicationsMainServerDataBaseConnectionString);
				this._STXDSSC_PublicationsProxyConnectionsServerClient.ConnectionWithProxyServerLost += this._STXDSSC_PublicationsProxyConnectionsServerClient_ConnectionWithProxyServerLost;
				this._STXDSSC_PublicationsProxyConnectionsServerClient.Connect();
				
				this._handlerType = handlerType;
				this._STXDataSocketClient = client;
				this._publicationName = PublicationName;
				this._publicationHostNAme = PublicationHostName;
				this._publicationPort = publicationsSocketsServerPortNumber;
				this._connectionMode = connectionMode;
				
				
				//*************************************************************************************
				//creates the server socket client to the publication's socket server in order to use it as endpoint to detect
				//when the publication goes off line
				string clientName = this._publicationName + Guid.NewGuid().ToString();
				this._PublicationSocketsServerClient = new SocketsServerClient(clientName, this._publicationHostNAme, this._publicationPort);
				this._PublicationSocketsServerClient.DataReceived += publicationSocketClient_DataReceived;
				this._PublicationSocketsServerClient.ConnectionLost += publicationSocketClient_ConnectionLost;
				this._PublicationSocketsServerClient.Connect();
				
				
				//becuase only the subscriptors clients will receive data from the publication
				if (handlerType == DPE_PublicationConnectionHandler_Type.subscriptorHandler)
				{
					
					//*****************************************************************************************
					
					
					try
					{
						
						//asks the proxy server to have a handle to create a sql reader to read locally the publications update
						this._DSSPublicationsSQLReader = this._STXDSSC_PublicationsProxyConnectionsServerClient.GetPublicationSocketsServerListenerClient(this._publicationName, this._publicationHostNAme);
						this._DSSPublicationsSQLReader.dataResetFromPublication += EventHandling_DSSPublicationsSQLReader_dataResetFromPublication;
						this._DSSPublicationsSQLReader.dataUpdateFromPublication += EventHandling_DSSPublicationsSQLReader_dataUpdateFromPublication;
						this._DSSPublicationsSQLReader.StartReading();
						
						this._STXDSSC_PublicationsProxyConnectionsServerClient.LogClientConnectionFromPublication(this._STXDSSC_PublicationsProxyConnectionsServerClient.SocketsServerClientID, this._STXDataSocketClient, this._publicationName);
						
						
					}
					catch (Exception ex)
					{
                        CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
					}
				}
				else if (handlerType == DPE_PublicationConnectionHandler_Type.publisherHandler)
				{
					
					this._DSSPublicationsSQLWriter = new DPE_PublicationsSQLWriter(client.PublicationsMainServerDataBaseConnectionString, this._publicationName);
					
				}
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
#region  < SOCKET CLIENTS FOR CONNECTION TO PUBLICATIONS >
			
			private void publicationSocketClient_DataReceived(SocketData data, SocketsServerClient sender)
			{
				try
				{
					//data received from the publication to this specific client
					//the data incomming from this is intended to be recived as when the client connects to the publication
					//and receives the current publication data to this point
					//*******************************************************
					this.ProcessPublicationUpdateDataReceivedOnConnection(data);
					//*******************************************************
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void publicationSocketClient_ConnectionLost(SocketsServerClient sender)
			{
				
				if (this._handlerType == DPE_PublicationConnectionHandler_Type.subscriptorHandler)
				{
					
					try
					{
						if (ConnectionToPublicationLostEvent != null)
							ConnectionToPublicationLostEvent(this._publicationName);
					}
					catch (Exception)
					{
					}
					
				}
				
			}
			
#endregion
			
#region  < CONNECTION WITH PROXY SERVER HANDLING >
			
			
			private void _STXDSSC_PublicationsProxyConnectionsServerClient_ConnectionWithProxyServerLost()
			{
				try
				{
					if (PublicationsProxyServerConnectionBrokenEvent != null)
						PublicationsProxyServerConnectionBrokenEvent(this);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < PUBLICATIONS SQL READER HANDLER >
			
			private void EventHandling_DSSPublicationsSQLReader_dataUpdateFromPublication(DPE_PublicationData newData)
			{
				try
				{
					if (PublicationDataReceivedEvent != null)
						PublicationDataReceivedEvent(newData);
				}
				catch (Exception)
				{
				}
			}
			
			private void EventHandling_DSSPublicationsSQLReader_dataResetFromPublication(string publicationName, string variableName)
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
			
#endregion
			
#region  < DATA RECEPTION HANDLING FOR MULTICAST UDP AND TCP  CONNECTION MODES >
			
			
			
#region  < DATA TREATMENT >
			
			private void ProcessPublicationUpdateDataReceivedOnConnection(SocketData data)
			{
				//the publication name comes as the sender socket client name
				DPE_PublicationData pubData = default(DPE_PublicationData);
				string publicationName = "";
				publicationName = data.AttributesTable.GetAttribute(DPE_ServerDefs.DPE_PUBLICATION_NAME).Value;
				if (publicationName == null)
				{
					throw (new Exception("Can\'t process publication data because the publication name attribute \'DPE_PUBLICATION_NAME\' is missing in the Socket data"));
				}
				
				string updateFlagString = "";
				updateFlagString = data.AttributesTable.GetAttribute(DPE_ServerDefs.DPE_PUBLICATION_UPDATE_FLAG).Value;
				if (updateFlagString == null)
				{
					string msg = "Can\'t process the publication update because the incomming data dont contain the control flag \'" + DPE_ServerDefs.DPE_PUBLICATION_UPDATE_FLAG + "\'";
					throw (new Exception(msg));
				}
				else
				{
					switch (updateFlagString)
					{
						case DPE_ServerDefs.DPE_PUBLICATION_DATA_UPDATE:
							pubData = DPE_PublicationData.GetSTXDSS_PublicationData(publicationName, data.DataName, data.Value);
							if (data.AttributesTable.Count > 0)
							{
								pubData.DataAttributesTable.SetAttributesFromSource(data.AttributesTable);
							}
							try
							{
								if (PublicationDataReceivedEvent != null)
									PublicationDataReceivedEvent(pubData);
							}
							catch (Exception)
							{
							}
							break;
						case DPE_ServerDefs.DPE_PUBLICATION_DATA_RESET:
							try
							{
								if (PublicationDataResetReceivedEvent != null)
									PublicationDataResetReceivedEvent(publicationName, data.DataName);
							}
							catch (Exception)
							{
							}
							break;
						default:
							string msg = "";
							msg = "Can\'t Update Publication data. Invalid parameter value for flag \'" + DPE_ServerDefs.DPE_PUBLICATION_UPDATE_FLAG + "\' : " + updateFlagString;
                            CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
							break;
					}
				}
			}
			
#endregion
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void DisconnectFromPublication()
			{
				this._PublicationSocketsServerClient.DataReceived -= publicationSocketClient_DataReceived;
				this._PublicationSocketsServerClient.ConnectionLost -= publicationSocketClient_ConnectionLost;
			}
			
			internal void SendPublicationDataUpdate(DPE_PublicationData data)
			{
				this._DSSPublicationsSQLWriter.UpdatePublicationVariable(data);
			}
			
			internal void SendPublicationDataReset(string VariableName)
			{
				this._DSSPublicationsSQLWriter.ResetPublicationVariable(VariableName);
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
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
						this.DisconnectFromPublication();
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
		
		//Friend Class DataProcessingRegister
		
		//    Public Enum IncommingDataformat
		//        typeSocketDataAsXMLString
		//        TypeSocketData
		//        TypeByte
		//    End Enum
		
		//    Public formatType As IncommingDataformat
		//    Public data As Object
		
		//    Public Sub New(ByVal incommingData As Object, ByVal format As IncommingDataformat)
		//        Me.data = incommingData
		//        formatType = format
		//    End Sub
		//End Class
		
#endregion
		
		
	}
	
}
