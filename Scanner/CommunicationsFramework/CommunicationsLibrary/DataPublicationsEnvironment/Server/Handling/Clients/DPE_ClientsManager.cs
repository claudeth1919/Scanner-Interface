using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Clients
	{
		
		internal struct ClientRegistrationData
		{
			public DPE_ClientType clientType;
			public string clientID;
			public string clientNetworkID;
			public string clientName;
			public string clientAppDomain;
		}
		
		internal class DPE_ClientsManager
		{
			
#region  < DATAMEMBERS >
			
			private Hashtable _registeredClientsTableByID;
			private Hashtable _registeredClientsTableByNetworkID;
			
			private DataTable _clientsRegistryDataTable;
			
			
#endregion
			
#region  < PROPERTIES  >
			
internal DataTable ClientsTable
			{
				get
				{
					return this._clientsRegistryDataTable.Copy();
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_ClientsManager()
			{
				
				this._registeredClientsTableByID = new Hashtable();
				this._registeredClientsTableByNetworkID = new Hashtable();
				
				this._clientsRegistryDataTable = new DataTable();
				this._clientsRegistryDataTable.Columns.Add("Client HostName");
				this._clientsRegistryDataTable.Columns.Add("Client AppDomain");
				this._clientsRegistryDataTable.Columns.Add("Client Name");
				this._clientsRegistryDataTable.Columns.Add("Client ID");
				this._clientsRegistryDataTable.Columns.Add("Network ID");
				this._clientsRegistryDataTable.Columns.Add("Connection Date Time");
				this._clientsRegistryDataTable.Columns.Add("Type");
				
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void LogClientIntoRegistryTable(DPE_Client client)
			{
				try
				{
					DataRow clientRow = default(DataRow);
					clientRow = this._clientsRegistryDataTable.NewRow();
					clientRow["Client HostName"] = client.HostName;
					clientRow["Client AppDomain"] = client.ApplicationDomainName;
					clientRow["Client Name"] = client.Name;
					clientRow["Client ID"] = client.ClientID;
					clientRow["Network ID"] = client.NetworkID;
					clientRow["Connection Date Time"] = client.ConnectionDateTime;
					switch (client.ClientType)
					{
						case DPE_ClientType.PublisherSubscriberClientType:
							clientRow["Type"] = "Publisher / Subscriber";
							break;
						case DPE_ClientType.StatusViewerClientType:
							clientRow["Type"] = "Status Viewer";
							break;
						default:
							clientRow["Type"] = "Unknown";
							break;
					}
					this._clientsRegistryDataTable.Rows.Add(clientRow);
				}
				catch (Exception)
				{
				}
			}
			
			private void UnlogClientFromRegistryTable(DPE_Client client)
			{
				try
				{
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Client ID] = \'" + client.ClientID + "\'";
					resultRows = this._clientsRegistryDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow subscriptorRow = resultRows[0];
						this._clientsRegistryDataTable.Rows.Remove(subscriptorRow);
						this._clientsRegistryDataTable.AcceptChanges();
					}
				}
				catch (Exception)
				{
					
				}
			}
			
#endregion
			
#region  < FRIEND METHODS  >
			
#region  < CLIENTS REGISTRATION METHODS >
			
			internal void AddClient(DPE_Client client)
			{
				if (!this._registeredClientsTableByID.ContainsKey(client.ClientID))
				{
					this._registeredClientsTableByID.Add(client.ClientID, client);
				}
				
				if (!this._registeredClientsTableByNetworkID.ContainsKey(client.NetworkID))
				{
					this._registeredClientsTableByNetworkID.Add(client.NetworkID, client);
				}
				
				this.LogClientIntoRegistryTable(client);
				
			}
			
			internal void RemoveClient(DPE_Client client)
			{
				if (this._registeredClientsTableByID.ContainsKey(client.ClientID))
				{
					this._registeredClientsTableByID.Remove(client.ClientID);
				}
				
				if (this._registeredClientsTableByNetworkID.ContainsKey(client.NetworkID))
				{
					this._registeredClientsTableByNetworkID.Remove(client.NetworkID);
				}
				
				this.UnlogClientFromRegistryTable(client);
				
			}
			
			internal DPE_Client GetClientByID(string clientID)
			{
				if (this._registeredClientsTableByID.ContainsKey(clientID))
				{
                    return (DPE_Client)this._registeredClientsTableByID[clientID];
				}
				else
				{
					return null;
				}
			}
			
			internal DPE_Client GetClientByNetworkID(string networkID)
			{
				if (this._registeredClientsTableByNetworkID.ContainsKey(networkID))
				{
                    return (DPE_Client)this._registeredClientsTableByNetworkID[networkID];
				}
				else
				{
					return null;
				}
			}
			
#endregion
			
#region  < CLIENTS CREATION AND REGISTRATION >
			
           	internal void CreateClientRegistration(DPE_ClientType clientType, string clientID, string networkID, string clientName, string clientHostName, string clientAppDomain)
			{
				DPE_Client newClient = new DPE_Client(clientType, clientID, networkID, clientName, clientHostName, clientAppDomain);
				this.AddClient(newClient);
			}
			
#endregion
			
			
			
			
#endregion
			
			
		}
		
	}
	
	
	
}
