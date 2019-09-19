using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Clients;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications
	{
		
		public class DPE_PublicationsManager : IDisposable
		{
			
			
#region  < DATAMEMBERS >
			
			//variable for singleton implementation
			private static DPE_PublicationsManager _STXDSS_PublicationsContainer;
			
			private Hashtable _publicationsHashTable;
			
			//table that contains the reference about which clients creates the publications
			private Hashtable _referenceTableOFPublicationsCreatedBySTXDSSClients;
			
			//data table that contains the information of all the availabe publications
			private DataTable _publicationsDataTable;
			
			//data table that contains the relation of all the clients that are publishers
			private DataTable _publisherClientsRegistryTable;
			
			//table that keeps the connection reference of the clients
			private Hashtable _referenceTableOFConnectionsToPublicationsOfASTXDSSClient;
			
			//
			private string _publicationsDataBaseCnnString;
			
#endregion
			
#region  < EVENTS >
			
			internal delegate void PublicationShutDownEventHandler();
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
			
			
#endregion
			
#region  < PROPERTIES >
			
			
internal DataTable PublicationsRegistryTable
			{
				get
				{
					return this._publicationsDataTable.Copy();
				}
			}
			
internal DataTable PublihsersRegistryTable
			{
				get
				{
					return this._publisherClientsRegistryTable.Copy();
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_PublicationsManager(string publicationsDAtaBaseConnectionString)
			{
				this._publicationsDataBaseCnnString = publicationsDAtaBaseConnectionString;
				
				//hash table for the publications it seld
				this._publicationsHashTable = new Hashtable();
				
				this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient = new Hashtable();
				
				this._referenceTableOFPublicationsCreatedBySTXDSSClients = new Hashtable();
				
				//data table to log status for the publications
				this._publicationsDataTable = new DataTable("PUBLICATIONS_TABLE");
				this._publicationsDataTable.Columns.Add("Publications Group", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Publication Name", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Publication Creation DateTime", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Publication Owner Name", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Publication Owner Hostname", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Application Domain", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Variables Published Count", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Publication Sockets Server Port", System.Type.GetType("System.String"));
				this._publicationsDataTable.Columns.Add("Subscriptors Count", System.Type.GetType("System.String"));
				
				
				//publishers table
				this._publisherClientsRegistryTable = new DataTable();
				this._publisherClientsRegistryTable.Columns.Add("Client Hostname");
				this._publisherClientsRegistryTable.Columns.Add("Client AppDomain");
				this._publisherClientsRegistryTable.Columns.Add("Client ID");
				this._publisherClientsRegistryTable.Columns.Add("Network ID");
				this._publisherClientsRegistryTable.Columns.Add("Client Name");
				this._publisherClientsRegistryTable.Columns.Add("Publications Count", System.Type.GetType("System.Int32"));
				
			}
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			internal static DPE_PublicationsManager GetInstance(string publicationsDataBaseConnectionString)
			{
				if (_STXDSS_PublicationsContainer == null)
				{
					_STXDSS_PublicationsContainer = new DPE_PublicationsManager(publicationsDataBaseConnectionString);
				}
				return _STXDSS_PublicationsContainer;
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
#region  < MANAGEMENT PUBLICATIONS REGISTRY DATA TABLE  >
			
			private void AddPublicationToDataTableRegistry(DPE_Publication publication)
			{
				try
				{
					DataRow pubrow = default(DataRow);
					pubrow = this._publicationsDataTable.NewRow();
					pubrow["Publications Group"] = publication.PublicationsGroup;
					pubrow["Publication Name"] = publication.PublicationName;
					pubrow["Publication Creation DateTime"] = publication.CreationDateTime;
					pubrow["Publication Owner Name"] = publication.publisherSTXDSSClient.Name;
					pubrow["Publication Owner Hostname"] = publication.publisherSTXDSSClient.HostName;
					pubrow["Application Domain"] = publication.publisherSTXDSSClient.ApplicationDomainName;
					pubrow["Variables Published Count"] = System.Convert.ToString(publication.PublishedVariablesCount);
					pubrow["Publication Sockets Server Port"] = publication.PublicationSocketsServerPort;
					pubrow["Subscriptors Count"] = publication.SubcriptorsAttachedCount;
					this._publicationsDataTable.Rows.Add(pubrow);
				}
				catch (Exception)
				{
				}
			}
			
			private void RemovePublicationFromDataTableRegistry(DPE_Publication publication)
			{
				try
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Publication Name] = \'" + publication.PublicationName + "\'";
					resultRows = this._publicationsDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow publicationRow = resultRows[0];
						this._publicationsDataTable.Rows.Remove(publicationRow);
						this._publicationsDataTable.AcceptChanges();
					}
				}
				catch (Exception)
				{
				}
			}
			
			private void SetPublicationAttachmentsCounterOnDataTableRegistry(DPE_Publication publication)
			{
				if (this._publicationsHashTable.ContainsKey(publication.PublicationName))
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Publication Name] = \'" + publication.PublicationName + "\'";
					resultRows = this._publicationsDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow publisherRow = resultRows[0];
						publisherRow["Subscriptors Count"] = publication.SubcriptorsAttachedCount;
						this._publicationsDataTable.AcceptChanges();
					}
				}
			}
			
			private void SetPublishedVariablesCountOfPublication(DPE_Publication publication)
			{
				if (this._publicationsHashTable.ContainsKey(publication.PublicationName))
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Publication Name] = \'" + publication.PublicationName + "\'";
					resultRows = this._publicationsDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow publisherRow = resultRows[0];
						publisherRow["Variables Published Count"] = publication.PublishedVariablesCount;
						this._publicationsDataTable.AcceptChanges();
					}
				}
			}
			
#endregion
			
#region  < MANAGEMENT OF THE REFERENCE TABLE OF PUBLICATIONS CREATED BY A CLIENT >
			//the table contains the relacion of which publications has been made by which client
			
			private void AddSTXDSSClientPublicationReference(DPE_Publication publication)
			{
				string publisherClientID = "";
				publisherClientID = publication.publisherSTXDSSClient.ClientID;
				if (!this._referenceTableOFPublicationsCreatedBySTXDSSClients.Contains(publisherClientID))
				{
					Hashtable publicationsOFCLientTable = new Hashtable();
					publicationsOFCLientTable.Add(publication.PublicationName, publication);
					this._referenceTableOFPublicationsCreatedBySTXDSSClients.Add(publisherClientID, publicationsOFCLientTable);
					
					//registers the client as publisher
					this.LogClientAsPublisher(publication.publisherSTXDSSClient);
					this.IncreasePublisherClientPublicationsCount(publication.publisherSTXDSSClient);
				}
				else
				{
					Hashtable publicationsOFCLientTable = default(Hashtable);
					publicationsOFCLientTable = (Hashtable) (this._referenceTableOFPublicationsCreatedBySTXDSSClients[publisherClientID]);
					
					this.IncreasePublisherClientPublicationsCount(publication.publisherSTXDSSClient);
					
					if (!publicationsOFCLientTable.Contains(publication.PublicationName))
					{
						publicationsOFCLientTable.Add(publication.PublicationName, publication);
					}
				}
			}
			
			private void RemoveSTXDSSClientPublicationReference(DPE_Publication publication)
			{
				string publisherClientID = "";
				publisherClientID = publication.publisherSTXDSSClient.ClientID;
				
				if (this._referenceTableOFPublicationsCreatedBySTXDSSClients.ContainsKey(publisherClientID))
				{
					Hashtable publicationsOFCLientTable = default(Hashtable);
					publicationsOFCLientTable = (Hashtable) (this._referenceTableOFPublicationsCreatedBySTXDSSClients[publisherClientID]);
					if (publicationsOFCLientTable.Contains(publication.PublicationName))
					{
						publicationsOFCLientTable.Remove(publication.PublicationName);
						this.DecreasePublisherClientPublicationsCount(publication.publisherSTXDSSClient);
					}
					//If the client doesn't have any remaining publications then removes from the table
					//that keeps the tracking of the publications posted by a client
					if (publicationsOFCLientTable.Count <= 0)
					{
						this._referenceTableOFPublicationsCreatedBySTXDSSClients.Remove(publisherClientID);
						this.UnlogClientAsPublisher(publication.publisherSTXDSSClient);
					}
				}
			}
			
			private void DisposeSTXDSSClientPublicationsReference(string STXDSS_ClientID)
			{
				if (this._referenceTableOFPublicationsCreatedBySTXDSSClients.ContainsKey(STXDSS_ClientID))
				{
					this._referenceTableOFPublicationsCreatedBySTXDSSClients.Remove(STXDSS_ClientID);
				}
			}
			
			internal CustomList GetListOfClientPostedPublications(DPE_Client client)
			{
				string publisherClientID = "";
				publisherClientID = client.ClientID;
				
				if (this._referenceTableOFPublicationsCreatedBySTXDSSClients.ContainsKey(publisherClientID))
				{
					Hashtable publicationsOFCLientTable = default(Hashtable);
					publicationsOFCLientTable = (Hashtable) (this._referenceTableOFPublicationsCreatedBySTXDSSClients[publisherClientID]);
					string publicationName = "";
					CustomList list = new CustomList();
					IEnumerator enumm = default(IEnumerator);
					enumm = publicationsOFCLientTable.GetEnumerator();
					while (enumm.MoveNext())
					{
						publicationName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
						list.Add(publicationName);
					}
					return list;
				}
				else
				{
					throw (new Exception("The client \'" + client.Name + "\' is not registered as a publisher"));
				}
			}
			
			internal DataTable GetTableOfPublicationsPostedByClient(DPE_Client client)
			{
				string publisherClientID = "";
				publisherClientID = client.ClientID;
				
				if (this._referenceTableOFPublicationsCreatedBySTXDSSClients.ContainsKey(publisherClientID))
				{
					DataTable dt = new DataTable();
					string selectionCriteria = "";
					System.Data.DataRow[] resultRows = null;
					selectionCriteria = "[Publication Owner Name] = \'" + client.Name + "\'";
					resultRows = this._publicationsDataTable.Select(selectionCriteria);
					
					if (resultRows.Length > 0)
					{
						dt = (DataTable)resultRows.CopyToDataTable();
						return dt;
					}
					else
					{
						throw (new Exception("The client \'" + client.Name + "\' is not registered as a publisher"));
					}
				}
				else
				{
					throw (new Exception("The client \'" + client.Name + "\' is not registered as a publisher"));
				}
			}
			
			
			
#endregion
			
#region  < MANAGEMENT OF THE REFERENCE TABLE OF CONNECTIONS TO A PUBLICATIONS MADE BY A CLIENT  >
			
			private void AddClientConnectionToaPublicationRegister(DPE_Client client, DPE_Publication publication)
			{
				if (!this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient.ContainsKey(client.ClientID))
				{
					CustomHashTable list = new CustomHashTable();
					list.Add(publication.PublicationName, publication.PublicationName);
					this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient.Add(client.ClientID, list);
				}
				else
				{
					CustomHashTable list = default(CustomHashTable);
                    list = (CustomHashTable)this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient[client.ClientID];
					if (!list.ContainsKey(publication.PublicationName))
					{
						list.Add(publication.PublicationName, publication.PublicationName);
					}
				}
			}
			
			private void RemoveClientConnectionToAPublicationRegister(DPE_Client client, DPE_Publication publication)
			{
				if (this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient.ContainsKey(client.ClientID))
				{
					CustomHashTable list = default(CustomHashTable);
                    list = (CustomHashTable)this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient[client.ClientID];
					if (list.ContainsKey(publication.PublicationName))
					{
						list.Remove(publication.PublicationName);
					}
				}
			}
			
			internal CustomList GetClientListOfConnectionsToPublications(DPE_Client client)
			{
				if (this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient.ContainsKey(client.ClientID))
				{
					CustomList list = new CustomList();
					string publicationName = "";
					IEnumerator enumm = default(IEnumerator);
                    CustomHashTable table = (CustomHashTable)this._referenceTableOFConnectionsToPublicationsOfASTXDSSClient[client.ClientID];
					enumm = table.GetEnumerator();
					while (enumm.MoveNext())
					{
						publicationName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
						list.Add(publicationName);
					}
					return list;
				}
				else
				{
					//returns an empty list becuase the cliebt is not conencyed to any publication
					return new CustomList();
				}
			}
			
			
#endregion
			
#region  < MANAGEMENT OF THE REFERENCE TABLE OF CLIENTS REGISTERED AS PUBLISHERS  >
			
			private void LogClientAsPublisher(DPE_Client client)
			{
				try
				{
					if (!this.IsClientRegisteredAsPublisher(client))
					{
						DataRow clientRow = default(DataRow);
						clientRow = this._publisherClientsRegistryTable.NewRow();
						clientRow["Client Hostname"] = client.HostName;
						clientRow["Client AppDomain"] = client.ApplicationDomainName;
						clientRow["Client ID"] = client.ClientID;
						clientRow["Network ID"] = client.NetworkID;
						clientRow["Client Name"] = client.Name;
						clientRow["Publications Count"] = 0;
						this._publisherClientsRegistryTable.Rows.Add(clientRow);
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			private void UnlogClientAsPublisher(DPE_Client client)
			{
				try
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Client ID] = \'" + client.ClientID + "\'";
					resultRows = this._publisherClientsRegistryTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow clientRow = resultRows[0];
						this._publisherClientsRegistryTable.Rows.Remove(clientRow);
						this._publisherClientsRegistryTable.AcceptChanges();
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			private void IncreasePublisherClientPublicationsCount(DPE_Client client)
			{
				string selectionCriteria = "";
				DataRow[] resultRows = null;
				selectionCriteria = "[Client ID] = \'" + client.ClientID + "\'";
				resultRows = this._publisherClientsRegistryTable.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					DataRow clientRow = resultRows[0];
					int count = System.Convert.ToInt32(clientRow["Publications Count"]);
					count++;
					clientRow["Publications Count"] = count;
					this._publisherClientsRegistryTable.AcceptChanges();
				}
			}
			
			private void DecreasePublisherClientPublicationsCount(DPE_Client client)
			{
				string selectionCriteria = "";
				DataRow[] resultRows = null;
				selectionCriteria = "[Client ID] = \'" + client.ClientID + "\'";
				resultRows = this._publisherClientsRegistryTable.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					DataRow clientRow = resultRows[0];
					int count = System.Convert.ToInt32(clientRow["Publications Count"]);
					count--;
					clientRow["Publications Count"] = count;
					this._publisherClientsRegistryTable.AcceptChanges();
				}
			}
			
			public bool IsClientRegisteredAsPublisher(DPE_Client client)
			{
				try
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Client ID] = \'" + client.ClientID + "\'";
					resultRows = this._publisherClientsRegistryTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				catch (Exception)
				{
					return false;
				}
			}
			
			
			
#endregion
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void NewSubscriptionAttachement_EventHandlerFcn(DPE_Publication publication, DPE_Client client)
			{
				try
				{
					this.SetPublicationAttachmentsCounterOnDataTableRegistry(publication);
					this.AddClientConnectionToaPublicationRegister(client, publication);
				}
				catch (Exception)
				{
				}
			}
			
			private void SubscriptionDeattachment_EventHandlerFcn(DPE_Publication publication, DPE_Client client)
			{
				try
				{
					this.SetPublicationAttachmentsCounterOnDataTableRegistry(publication);
					this.RemoveClientConnectionToAPublicationRegister(client, publication);
				}
				catch (Exception)
				{
				}
			}
			
			private void PublicationShutDown_EventHandlerFcn(DPE_Publication publication)
			{
				try
				{
					this.RemovePublication(publication);
					try
					{
						if (PublicationShutDownEvent != null)
							PublicationShutDownEvent();
					}
					catch (Exception)
					{
					}
				}
				catch (Exception)
				{
				}
			}
			
			private void VariableAddedToPublication_EventHandlerFcn(DPE_Publication publication, string variableName, DPE_ServerDefs.PublicationVariableDataType variableType)
			{
				try
				{
					this.SetPublishedVariablesCountOfPublication(publication);
				}
				catch (Exception)
				{
				}
			}
			
			private void VariableRemovedFromPublication_EventHandlerFcn(DPE_Publication publication, string variableName)
			{
				try
				{
					this.SetPublishedVariablesCountOfPublication(publication);
				}
				catch (Exception)
				{
				}
			}
			
			private void PublicationGroupChanged_EventHandlerFcn(DPE_Publication publication, string newGroup)
			{
				try
				{
					string selectionCriteria = "[Publication Name]=\'" + publication.PublicationName + "\'";
					DataRow[] ResultRows = this._publicationsDataTable.Select(selectionCriteria);
					
					if (ResultRows.Length > 0)
					{
						DataRow row = ResultRows[0];
						row["Publications Group"] = newGroup;
						row.AcceptChanges();
					}
				}
				catch (Exception)
				{
					
				}
			}
			
#endregion
			
#region  < FRIEND METHODS  >
			
#region  < PUBLICATIONS MANAGEMENT >
			
			internal void AddPublication(DPE_Publication publication)
			{
				if (!this._publicationsHashTable.Contains(publication.PublicationName))
				{
					//registers the publication in the publications table and datatable
					this._publicationsHashTable.Add(publication.PublicationName, publication);
					this.AddPublicationToDataTableRegistry(publication);
					
					//updates the reference of the publications posted by a client
					this.AddSTXDSSClientPublicationReference(publication);
					
					publication.NewSubscriptionAttachement += NewSubscriptionAttachement_EventHandlerFcn;
					publication.SubscriptionDeattachment += SubscriptionDeattachment_EventHandlerFcn;
					publication.PublicationShutDown += PublicationShutDown_EventHandlerFcn;
					publication.VariableAdded += VariableAddedToPublication_EventHandlerFcn;
					publication.VariableRemoved += VariableRemovedFromPublication_EventHandlerFcn;
					publication.PublicationGroupChanged += PublicationGroupChanged_EventHandlerFcn;
					
				}
				else
				{
					throw (new Exception("The publication named \'" + publication.PublicationName + "\' already exists."));
				}
			}
			
			internal void RemovePublication(DPE_Publication publication)
			{
				if (this._publicationsHashTable.ContainsKey(publication.PublicationName))
				{
					//removes the publication in the publications table and datatable
					this._publicationsHashTable.Remove(publication.PublicationName);
					this.RemovePublicationFromDataTableRegistry(publication);
					
					//updates the reference of the publications posted by a client
					this.RemoveSTXDSSClientPublicationReference(publication);
					
					publication.NewSubscriptionAttachement -= NewSubscriptionAttachement_EventHandlerFcn;
					publication.SubscriptionDeattachment -= SubscriptionDeattachment_EventHandlerFcn;
					publication.PublicationShutDown -= PublicationShutDown_EventHandlerFcn;
					publication.VariableAdded -= VariableAddedToPublication_EventHandlerFcn;
					publication.VariableRemoved -= VariableRemovedFromPublication_EventHandlerFcn;
					
				}
				else
				{
					throw (new Exception("The publication name \'" + publication.PublicationName + "\' not exists."));
				}
			}
			
			internal dynamic ContainsPublication(string PublicationName)
			{
				PublicationName = PublicationName.ToUpper();
				return this._publicationsHashTable.ContainsKey(PublicationName);
			}
			
			internal dynamic ContainsPublication(DPE_Publication Publication)
			{
				return this.ContainsPublication(Publication.PublicationName);
			}
			
			internal DPE_Publication GetPublication(string PublicationName)
			{
				PublicationName = PublicationName.ToUpper();
                return (DPE_Publication)this._publicationsHashTable[PublicationName];
			}
			
#endregion
			
			
			internal void DisposeClientPublications(DPE_Client client)
			{
				try
				{
					CustomList pubList = this.GetListOfClientPostedPublications(client);
					IEnumerator enumm = pubList.GetEnumerator();
					string pubName = "";
					DPE_Publication publication = default(DPE_Publication);
					while (enumm.MoveNext())
					{
						pubName = System.Convert.ToString(enumm.Current);
						publication = this.GetPublication(pubName);
						try
						{
							publication.ShutDownPublication();
							publication.Dispose();
						}
						catch (Exception)
						{
						}
					}
				}
				catch (Exception)
				{
					
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
						//destroys all the available publications publications
						IEnumerator pubEnumm = default(IEnumerator);
						pubEnumm = this._publicationsHashTable.GetEnumerator();
						DPE_Publication publication = default(DPE_Publication);
						while (pubEnumm.MoveNext())
						{
							publication = (DPE_Publication) (((DictionaryEntry) pubEnumm.Current).Value);
							try
							{
								publication.Dispose();
							}
							catch (Exception)
							{
							}
						}
					}
					//
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
