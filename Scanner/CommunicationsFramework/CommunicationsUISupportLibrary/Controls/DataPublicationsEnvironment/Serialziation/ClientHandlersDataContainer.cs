// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using UtilitiesLibrary.Services.Serialization;
using CommunicationsUISupportLibrary.publicationsConnection;
using CommunicationsUISupportLibrary.publicationsPosting;


namespace CommunicationsUISupportLibrary
{
	[Serializable()]public class ClientHandlersDataContainer : IEnumerable
	{
		
#region  < DATA MEMBERS >
		
		
		private static ClientHandlersDataContainer _ClientHandlersDataContainer;
		
		
		private const string HANDLER_CONTAINER_FILE_NAME = "ClientHandlersDataContainer.sfo";
		
		private Hashtable _handlersTable;
		
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		private ClientHandlersDataContainer()
		{
			this._handlersTable = new Hashtable();
		}
		
#endregion
		
#region  < PROPERTIES >
		
internal IEnumerator HandlersTableEnumerator
		{
			get
			{
				return this._handlersTable.GetEnumerator();
			}
		}
		
public int Count
		{
			get
			{
				return this._handlersTable.Count;
			}
		}
		
#endregion
		
#region  < SINGLETON IMPLEMENTATION >
		
		internal static ClientHandlersDataContainer GetInstance()
		{
			
			if (_ClientHandlersDataContainer == null)
			{
				try
				{
					_ClientHandlersDataContainer = ObjectSerializer.DeserializeObjectFromFile(HANDLER_CONTAINER_FILE_NAME);
				}
				catch (Exception)
				{
					if (_ClientHandlersDataContainer == null)
					{
						_ClientHandlersDataContainer = new ClientHandlersDataContainer();
					}
				}
			}
			
			return _ClientHandlersDataContainer;
			
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void EventHandling_ClientHandlerData_PublicationsConnectionsHandling(PublicationConnectionData data)
		{
			this.SaveData();
		}
		
		private void EventHandling_ClientHandlerData_PublicationsPostingHandling(PostedPublicationDefinitionData data)
		{
			this.SaveData();
		}
#endregion
		
		
#region  < FRIEND METHODS >
		
		internal void AddClientHandlerData(ClientHandlerData data)
		{
			this._handlersTable.Add(data.ClientName, data);
			data.PublicationConnectionDataAdded += EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
			data.PublicationConnectionDataRemoved += EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
			data.publicationPostDataAdded += EventHandling_ClientHandlerData_PublicationsPostingHandling;
			data.PublicationPostDataRemoved += EventHandling_ClientHandlerData_PublicationsPostingHandling;
			this.SaveData();
		}
		
		internal void RemoveClientHandlerData(ClientHandlerData data)
		{
			this._handlersTable.Remove(data.ClientName);
			data.PublicationConnectionDataAdded -= EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
			data.PublicationConnectionDataRemoved -= EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
			data.publicationPostDataAdded -= EventHandling_ClientHandlerData_PublicationsPostingHandling;
			data.PublicationPostDataRemoved -= EventHandling_ClientHandlerData_PublicationsPostingHandling;
			this.SaveData();
		}
		
		internal void RemoveClientHandlerData(string ClientName)
		{
			ClientHandlerData data = (ClientHandlerData)this._handlersTable[ClientName];
			if (!(data == null))
			{
				this._handlersTable.Remove(ClientName);
				data.PublicationConnectionDataAdded -= EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
				data.PublicationConnectionDataRemoved -= EventHandling_ClientHandlerData_PublicationsConnectionsHandling;
				data.publicationPostDataAdded -= EventHandling_ClientHandlerData_PublicationsPostingHandling;
				data.PublicationPostDataRemoved -= EventHandling_ClientHandlerData_PublicationsPostingHandling;
				this.SaveData();
			}
		}
		
		internal void SaveData()
		{
			ObjectSerializer.SerializeObjectToFile(this, HANDLER_CONTAINER_FILE_NAME);
		}
		
#endregion
		
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IEnumerable >
		
		public System.Collections.IEnumerator GetEnumerator()
		{
			ClientHandlersDataContainerEnumerator enumm = new ClientHandlersDataContainerEnumerator(this);
			return enumm;
		}
		
#endregion
		
		
#endregion
		
		
	}
	
}
