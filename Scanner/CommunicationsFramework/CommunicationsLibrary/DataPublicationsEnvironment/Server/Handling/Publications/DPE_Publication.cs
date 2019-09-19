using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services;
using UtilitiesLibrary.Services.DataStatistics;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services.DataCompression;
using CommunicationsLibrary.DataPublicationsEnvironment;
using CommunicationsLibrary.DataPublicationsEnvironment.Server;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Clients;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications.DataDistributionHandling;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using System.Threading;




namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications
	{
		
		public class DPE_Publication : IDisposable
		{
			
			
#region  < DATA MEMBERS  >
			
			private DPE_PublishedVariablesRegistry _variablesPublishedRegistry;
			
			private DPE_Client _publisherSTXDSSClient;
			
			private string _publicationsGroup;
			
			private string _publicationName;
			
			private DateTime _publicationCreation;
			
			//handling to send the data to a client when it connects to the publications if its required by the connection mode
			private Queue _updatePublicationOnClientConnectionQueue;
			
			//sockets server to attend the incomming data from the publihser
			private SocketsServer  _publicationSocketsServer;
			
			private DPE_PublicationClientConnectionsManager _STXDSS_PublicationClientConnectionsManager;
			
			private string _publicationsDataBaseConnectionString;
			
			
#endregion
			
#region  < EVENTS>
			
			internal delegate void NewSubscriptionAttachementEventHandler(DPE_Publication publication, DPE_Client client);
			private NewSubscriptionAttachementEventHandler NewSubscriptionAttachementEvent;
			
			internal event NewSubscriptionAttachementEventHandler NewSubscriptionAttachement
			{
				add
				{
					NewSubscriptionAttachementEvent = (NewSubscriptionAttachementEventHandler) System.Delegate.Combine(NewSubscriptionAttachementEvent, value);
				}
				remove
				{
					NewSubscriptionAttachementEvent = (NewSubscriptionAttachementEventHandler) System.Delegate.Remove(NewSubscriptionAttachementEvent, value);
				}
			}
			
			internal delegate void SubscriptionDeattachmentEventHandler(DPE_Publication publication, DPE_Client client);
			private SubscriptionDeattachmentEventHandler SubscriptionDeattachmentEvent;
			
			internal event SubscriptionDeattachmentEventHandler SubscriptionDeattachment
			{
				add
				{
					SubscriptionDeattachmentEvent = (SubscriptionDeattachmentEventHandler) System.Delegate.Combine(SubscriptionDeattachmentEvent, value);
				}
				remove
				{
					SubscriptionDeattachmentEvent = (SubscriptionDeattachmentEventHandler) System.Delegate.Remove(SubscriptionDeattachmentEvent, value);
				}
			}
			
			internal delegate void PublicationShutDownEventHandler(DPE_Publication publication);
			private PublicationShutDownEventHandler PublicationShutDownEvent;
			
			internal event PublicationShutDownEventHandler PublicationShutDown
			{
				add
				{
					PublicationShutDownEvent = (PublicationShutDownEventHandler) System.Delegate.Combine(PublicationShutDownEvent, value);
				}
				remove
				{
					PublicationShutDownEvent = (PublicationShutDownEventHandler) System.Delegate.Remove(PublicationShutDownEvent, value);
				}
			}
			
			internal delegate void VariableAddedEventHandler(DPE_Publication publication, string dataName, DPE_ServerDefs.PublicationVariableDataType dataType);
			private VariableAddedEventHandler VariableAddedEvent;
			
			internal event VariableAddedEventHandler VariableAdded
			{
				add
				{
					VariableAddedEvent = (VariableAddedEventHandler) System.Delegate.Combine(VariableAddedEvent, value);
				}
				remove
				{
					VariableAddedEvent = (VariableAddedEventHandler) System.Delegate.Remove(VariableAddedEvent, value);
				}
			}
			
			internal delegate void VariableRemovedEventHandler(DPE_Publication publication, string dataName);
			private VariableRemovedEventHandler VariableRemovedEvent;
			
			internal event VariableRemovedEventHandler VariableRemoved
			{
				add
				{
					VariableRemovedEvent = (VariableRemovedEventHandler) System.Delegate.Combine(VariableRemovedEvent, value);
				}
				remove
				{
					VariableRemovedEvent = (VariableRemovedEventHandler) System.Delegate.Remove(VariableRemovedEvent, value);
				}
			}
			
			internal delegate void PublicationGroupChangedEventHandler(DPE_Publication publication, string groupName);
			private PublicationGroupChangedEventHandler PublicationGroupChangedEvent;
			
			internal event PublicationGroupChangedEventHandler PublicationGroupChanged
			{
				add
				{
					PublicationGroupChangedEvent = (PublicationGroupChangedEventHandler) System.Delegate.Combine(PublicationGroupChangedEvent, value);
				}
				remove
				{
					PublicationGroupChangedEvent = (PublicationGroupChangedEventHandler) System.Delegate.Remove(PublicationGroupChangedEvent, value);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
internal string PublicationName
			{
				get
				{
					return this._publicationName.ToUpper();
				}
			}
			
internal string PublicationsGroup
			{
				get
				{
					return this._publicationsGroup;
				}
			}
			
internal DPE_Client publisherSTXDSSClient
			{
				get
				{
					return this._publisherSTXDSSClient;
				}
			}
			
internal int SubcriptorsAttachedCount
			{
				get
				{
					return this._STXDSS_PublicationClientConnectionsManager.ConnectedClientsCount;
				}
			}
			
internal DateTime CreationDateTime
			{
				get
				{
					return this._publicationCreation;
				}
			}
			
internal DataTable SubscriptorsTable
			{
				get
				{
					return this._STXDSS_PublicationClientConnectionsManager.PublicationSubscriptorsRegistryTable;
				}
			}
			
internal int PublishedVariablesCount
			{
				get
				{
					return this._variablesPublishedRegistry.PublishedVariablesCount;
				}
			}
			
            internal DataTable PublishedVariablesTable
			{
				get
				{
					return this._variablesPublishedRegistry.PublishedVariablesRegistryTable;
				}
			}
			
            internal int PublicationSocketsServerPort
			{
				get
				{
                    int portNumber = Convert.ToInt32(this._publicationSocketsServer.ListeningPort);
                    return portNumber;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_Publication(string publicationsDataBAseConnectionString, string publicationsGroup, string publicationName, DPE_Client STXDSSClient)
			{
				//sets the publication name
				this._publicationsGroup = publicationsGroup.ToUpper();
				
				this._publicationName = publicationName.ToUpper();
				this._publicationCreation = DateTime.Now;
				
				this._variablesPublishedRegistry = new DPE_PublishedVariablesRegistry(publicationName);
				
				//saves reference to the datra socket server that creates the publication
				this._publisherSTXDSSClient = STXDSSClient;
				
				//creates a sockets server to support the link between the client and the publication
				this._publicationSocketsServer = new SocketsServer(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE, DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE);
				this._publicationSocketsServer.NewClientConnection += this.NewIncommingConnectionCDB;
				this._publicationSocketsServer.ClientConnectionFinished += this.ClientConnectionFinishCDB;
				
				this._STXDSS_PublicationClientConnectionsManager = new DPE_PublicationClientConnectionsManager(this);
				
				this._updatePublicationOnClientConnectionQueue = new Queue();
				
				this._publicationsDataBaseConnectionString = publicationsDataBAseConnectionString;
				
				//**************************************************************************************************
				//creates the publication in the data base according with the connection string passed by attribute
				CreatePublicationDataTable(this._publicationsDataBaseConnectionString, this._publicationName);
				
				CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "Publication \'" + this._publicationName + "\'    ->     CREATED succesfully");
			}
			
#endregion
			
#region  < PRIVATE METHODS>
			
#region  < DATA VALIDATION AND TRANSFORMATION >
			
			private void ValidateDataPublication(DPE_PublicationData data)
			{
				DPE_ServerDefs.PublicationVariableDataType type = default(DPE_ServerDefs.PublicationVariableDataType);
				type = this._variablesPublishedRegistry.GetDataVariablePublicationDataType(data.VariableName);
				if (type != data.DataType)
				{
					throw (new Exception("The data published as \'" + data.VariableName + "\' was declared to be of type \'" + type.ToString() + "\' and was received as \'" + data.DataType.ToString() + "\'"));
				}
			}
			
			private DPE_PublicationData ConvertSocketDataToPublicationDataType(SocketData data)
			{
				string dataType = data.Value.GetType().ToString();
				switch (dataType)
				{
					case "System.Int32":
						return new DPE_PublicationData(this.PublicationName, data.DataName, System.Convert.ToInt32(data.Value));
					case "System.Decimal":
						return new DPE_PublicationData(this.PublicationName, data.DataName, System.Convert.ToDecimal(data.Value));
					case "System.Boolean":
						return new DPE_PublicationData(this.PublicationName, data.DataName, System.Convert.ToString(System.Convert.ToBoolean(data.Value)));
					case "System.String":
						return new DPE_PublicationData(this.PublicationName, data.DataName, System.Convert.ToString(data.Value));
					case "System.Data.DataSet":
						return new DPE_PublicationData(this.PublicationName, data.DataName, (DataSet) data.Value);
					case "System.Data.DataTable":
						return new DPE_PublicationData(this.PublicationName, data.DataName, (DataTable) data.Value);
					case "UtilitiesLibrary.Data.CustomHashTable":
						return new DPE_PublicationData(this.PublicationName, data.DataName, System.Convert.ToString((CustomHashTable) data.Value));
					case "UtilitiesLibrary.Data.CustomList":
						return new DPE_PublicationData(this.PublicationName, data.DataName, (CustomList) data.Value);
					case "UtilitiesLibrary.Data.CustomSortedList":
						return new DPE_PublicationData(this.PublicationName, data.DataName, (CustomSortedList) data.Value);
					default:
						string msg = "Unsupported data type \'" + dataType + "\' for publication \'" + this.PublicationName + "\'";
						throw (new Exception(msg));
				}
			}
			
			private SocketData ConvertPublicationDataToSocketDataType(DPE_PublicationData data)
			{
				string dataType = data.Value.GetType().ToString();
				SocketData dataAsSocketData = default(SocketData);
				switch (dataType)
				{
					case "System.Int32":
						dataAsSocketData = new SocketData(data.VariableName, System.Convert.ToInt32(data.Value));
						break;
					case "System.Decimal":
						dataAsSocketData = new SocketData(data.VariableName, System.Convert.ToDecimal(data.Value));
						break;
					case "System.Boolean":
						dataAsSocketData = new SocketData(data.VariableName, System.Convert.ToBoolean(data.Value));
						break;
					case "System.String":
						dataAsSocketData = new SocketData(data.VariableName, System.Convert.ToString(data.Value));
						break;
					case "System.Data.DataSet":
						dataAsSocketData = new SocketData(data.VariableName, (DataSet) data.Value);
						break;
					case "System.Data.DataTable":
						dataAsSocketData = new SocketData(data.VariableName, (DataTable) data.Value);
						break;
					case "UtilitiesLibrary.Data.CustomHashTable":
						dataAsSocketData = new SocketData(data.VariableName, (CustomHashTable) data.Value);
						break;
					case "UtilitiesLibrary.Data.CustomList":
						dataAsSocketData = new SocketData(data.VariableName, (CustomList) data.Value);
						break;
					case "UtilitiesLibrary.Data.CustomSortedList":
						dataAsSocketData = new SocketData(data.VariableName, (CustomSortedList) data.Value);
						break;
					default:
						string msg = "Unsupported data type \'" + dataType + "\' for publication \'" + this.PublicationName + "\'";
						throw (new Exception(msg));
				}
				//*********************************************************************
				//IMPORTANT !!!!!!!
				//this flag indicates the data is for update a publication variable
				dataAsSocketData.AttributesTable.AddAttribute(DPE_ServerDefs.DPE_PUBLICATION_UPDATE_FLAG, DPE_ServerDefs.DPE_PUBLICATION_DATA_UPDATE);
				dataAsSocketData.AttributesTable.AddAttribute(DPE_ServerDefs.DPE_PUBLICATION_NAME, this._publicationName);
				return dataAsSocketData;
			}
			
#endregion
			
#region  <  PUBLICATIONS UPDATE ON A NEW CLIENT CONNECTION >
			
			private void THREAD_FCN_UpdatePublicatonOnSubscriptorConnection()
			{
				try
				{
					SocketsServerClientConnectionHandler ClientHandler = default(SocketsServerClientConnectionHandler);
					
					if (this._updatePublicationOnClientConnectionQueue.Count > 0)
					{
						
						ClientHandler = null;
						try
						{
                            ClientHandler = (SocketsServerClientConnectionHandler)this._updatePublicationOnClientConnectionQueue.Dequeue();
						}
						catch (Exception)
						{
							ClientHandler = null;
						}
						
						if (!(ClientHandler == null))
						{
							
							lock(this._variablesPublishedRegistry)
							{
								
								IEnumerator enumm = default(IEnumerator);
								string variableName = "";
								DPE_PublicationData lastDataValue = default(DPE_PublicationData);
								enumm = this._variablesPublishedRegistry.PublishedVariablesNamesList.GetEnumerator();
								
								while (enumm.MoveNext())
								{
									try
									{
										variableName = System.Convert.ToString(enumm.Current);
										lastDataValue = this._variablesPublishedRegistry.GetLastRecordedDataValue(variableName);
										
										if (!(lastDataValue == null))
										{
											SocketData ds = default(SocketData);
											ds = this.ConvertPublicationDataToSocketDataType(lastDataValue);
											try
											{
												//Uses the sockets server to send data exclusively to a client
												this._publicationSocketsServer.SendDataToClient(ClientHandler, ds);
											}
											catch (Exception ex)
											{
												CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
											}
										}
									}
									catch (Exception ex)
									{
										CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
									}
								}
								
							}
							
							
						}
					}
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
			}
			
			internal void SchedulePublicationUpdateOnClientConnection(SocketsServerClientConnectionHandler clientHandler)
			{
				try
				{
					this._updatePublicationOnClientConnectionQueue.Enqueue(clientHandler);
					
					System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(THREAD_FCN_UpdatePublicatonOnSubscriptorConnection));
					thread.IsBackground = true;
					thread.Priority = ThreadPriority.Normal;
					thread.Start();
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
#endregion
			
#endregion
			
#region  < EVENT HANDLING >
			
#region  < SOCKETS SERVER FOR PUBLISHER CONNECTIONS DETECTION AND LOGGING >
			
			
			private void NewIncommingConnectionCDB(SocketsServerClientConnectionHandler ClientHandler)
			{
				this._STXDSS_PublicationClientConnectionsManager.LogPendingSocketClientMatchConnectionWithSTXDSSClientTable(ClientHandler);
			}
			
			private void ClientConnectionFinishCDB(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler)
			{
				
				this._STXDSS_PublicationClientConnectionsManager.UnlogPendingSocketClientMatchConnectionWithSTXDSSClientTable(ClientHandler);
				
				DPE_Client client = default(DPE_Client);
				client = this._STXDSS_PublicationClientConnectionsManager.GetSubscriptorClient(ClientHandler);
				if (!(client == null))
				{
					try
					{
						this._STXDSS_PublicationClientConnectionsManager.RemoveClientSubscription(ClientHandler);
					}
					catch (Exception)
					{
					}
					try
					{
						if (SubscriptionDeattachmentEvent != null)
							SubscriptionDeattachmentEvent(this, client);
					}
					catch (Exception)
					{
					}
				}
				
			}
			
#endregion
			
#endregion
			
#region  < PUBLICATION VARIABLES DEFINITION >
			
			internal void AddVariableToDataPublication(string dataName, DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				this._variablesPublishedRegistry.AddDataVariablePublication(dataName, dataType);
				try
				{
					if (VariableAddedEvent != null)
						VariableAddedEvent(this, dataName, dataType);
				}
				catch (Exception)
				{
				}
			}
			
			internal void RemoveVariableFromDataPublication(string dataName)
			{
				this._variablesPublishedRegistry.RemoveDataVariablePublication(dataName);
				try
				{
					if (VariableRemovedEvent != null)
						VariableRemovedEvent(this, dataName);
				}
				catch (Exception)
				{
				}
			}
			
			internal bool ContainsVariable(string dataname)
			{
				return System.Convert.ToBoolean(this._variablesPublishedRegistry.ContainsDataVariablePublication(dataname));
			}
			
#endregion
			
#region  < PUBLICATION SUBSCRIPTION IDENTIFICATION AND CONNECTION >
			
			internal void STXDSSClientConnectionIdentificationAndConnection(DPE_Client client, string publicationConnectionHandlerID, DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				
				if (client.ClientID != this.publisherSTXDSSClient.ClientID)
				{
					//only registers as sbscriptors other client different from the publisher
					
					if (this._STXDSS_PublicationClientConnectionsManager.Set_STXDSSClientConnection(client, publicationConnectionHandlerID, connectionMode))
					{
						
						//------------------------------------------------------------------------------------------
						//sends to the client the last update of the publication
						SocketsServerClientConnectionHandler handler = default(SocketsServerClientConnectionHandler);
						handler = this._STXDSS_PublicationClientConnectionsManager.GetClientPublicationConnectionHandler(client);
						if (!(handler == null))
						{
							if (connectionMode == DPE_ServerDefs.DPE_PublicationConnectionMode.ReceiveLastPublicationStatus)
							{
								this.SchedulePublicationUpdateOnClientConnection(handler);
							}
						}
						//-------------------------------------------------------------------------------------------
						
						try
						{
							this.RaiseNewConnectionEvent(client);
						}
						catch (Exception)
						{
						}
						
						
					}
				}
				
			}
			
			internal void RaiseNewConnectionEvent(DPE_Client client)
			{
				try
				{
					if (NewSubscriptionAttachementEvent != null)
						NewSubscriptionAttachementEvent(this, client);
				}
				catch (Exception)
				{
				}
			}
			
			internal bool STXDSSClientSocketConnectionInquiry(DPE_Client client, string publicationConnectionHandlerID)
			{
				return this._STXDSS_PublicationClientConnectionsManager.ContainsClientSocketConnectionHandler(publicationConnectionHandlerID);
			}
			
#endregion
			
			internal void ShutDownPublication()
			{
				this.Dispose();
				try
				{
					if (PublicationShutDownEvent != null)
						PublicationShutDownEvent(this);
				}
				catch (Exception)
				{
				}
			}
			
			internal CustomHashTable GetPublicationParametersTable()
			{
				CustomHashTable table = new CustomHashTable();
				table.Add(DPE_PublicationsDefinitions.DPE_PUBLICATION_HOSTNAME, System.Net.Dns.GetHostName());
				table.Add(DPE_PublicationsDefinitions.DPE_PUBLICATION_PORT, this._publicationSocketsServer.ListeningPort);
				return table;
			}
			
			internal void SetPublicationsGroup(string groupName)
			{
				this._publicationsGroup = groupName.ToUpper();
				try
				{
					if (PublicationGroupChangedEvent != null)
						PublicationGroupChangedEvent(this, this._publicationsGroup);
				}
				catch (Exception)
				{
				}
			}
			
			internal void ResetStatistics()
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._publicationsDataBaseConnectionString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_RESET_STORED_PROCEDURE_NAME;
							
							System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter("@PublicationName", SqlDbType.VarChar);
							param.Value = this._publicationName;
							cmd.Parameters.Add(param);
							
							cmd.ExecuteNonQuery();
							
						}
						
						
					}
					
				}
				catch (Exception)
				{
					
				}
				
				
			}
			
			
#region  < SHARED METHODS >
			
			public static void CreatePublicationDataTable(string publicationsDataBAseConnectionString, string publicationName)
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(publicationsDataBAseConnectionString))
					{
						
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							
							cmd.Connection = cnn;
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.CommandText = DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_CREATION_STORED_PROCEDURE_NAME;
							cmd.Parameters.AddWithValue(DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_NAME, publicationName);
							cmd.ExecuteNonQuery();
							
							try
							{
								cmd.Dispose();
							}
							catch (Exception)
							{
							}
							
						}
						
						
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
				catch (Exception ex)
				{
					throw (new Exception("Can not create publication \'" + publicationName + "\' into publications Database : " + ex.Message));
				}
				
			}
			
			public static void DisposePublicationDataTable(string publicationsDataBAseConnectionString, string publicationName)
			{
				using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(publicationsDataBAseConnectionString))
				{
					
					cnn.Open();
					
					using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
					{
						
						cmd.Connection = cnn;
						cmd.CommandType = CommandType.StoredProcedure;
						cmd.CommandText = DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_DISPOSE_STORED_PROCEDURE_NAME;
						cmd.Parameters.AddWithValue(DPE_GlobalDefinitions.DPE_PUBLICATIONS_DATABASE_PUBLICATION_NAME, publicationName);
						cmd.ExecuteNonQuery();
						
						try
						{
							cmd.Dispose();
						}
						catch (Exception)
						{
						}
						
					}
					
					
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
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDIsposable >
			
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
							this._publicationSocketsServer.Dispose();
						}
						catch (Exception)
						{
						}
						
						try
						{
							DisposePublicationDataTable(this._publicationsDataBaseConnectionString, this.PublicationName);
						}
						catch (Exception)
						{
						}
						
						try
						{
							CustomEventLog.DisplayEvent(EventLogEntryType.Information, "Publication \'" + this.PublicationName + "\' was disposed properly");
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
			
			private class PublicationUpdateOperationHandler : System.IDisposable
			{
				
				
				private DPE_GlobalDefinitions.publicationUpdateOperationType _operationType;
				private DPE_PublicationData _data;
				private string _variableName;
				private string _publicationName;
				private bool disposedValue = false; // To detect redundant calls
				
				
				internal PublicationUpdateOperationHandler(DPE_PublicationData data)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._data = data;
					this._variableName = data.VariableName;
					this._publicationName = data.PublicationName;
				}
				
				internal PublicationUpdateOperationHandler(string publicationName, string variableName)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataReset;
					this._data = null;
					this._variableName = variableName;
					this._publicationName = publicationName;
				}
				
internal DPE_GlobalDefinitions.publicationUpdateOperationType Type
				{
					get
					{
						return this._operationType;
					}
				}
				
internal DPE_PublicationData Data
				{
					get
					{
						return this._data;
					}
				}
				
internal string publicationName
				{
					get
					{
						return this._publicationName;
					}
				}
				
internal string VariableName
				{
					get
					{
						return this._variableName;
					}
				}
				
				
				// IDisposable
				protected virtual void Dispose(bool disposing)
				{
					if (!this.disposedValue)
					{
						if (disposing)
						{
							// TODO: free other state (managed objects).
						}
						this.Finalize();
						// TODO: free your own state (unmanaged objects).
						// TODO: set large fields to null.
					}
					this.disposedValue = true;
				}

                private void Finalize()
                {

                }           
				
				// This code added by Visual Basic to correctly implement the disposable pattern.
				public void Dispose()
				{
					// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
					Dispose(true);
					GC.SuppressFinalize(this);
				}
				
				
			}
			
			
#endregion
			
		}
		
		
	}
	
	
}
