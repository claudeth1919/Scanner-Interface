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

using CommunicationsUISupportLibrary.publicationsPosting;
using CommunicationsUISupportLibrary.publicationsPosting.containers;
using CommunicationsUISupportLibrary.publicationsConnection;
using CommunicationsUISupportLibrary.publicationsConnection.containers;


namespace CommunicationsUISupportLibrary
{
	[Serializable()]public class ClientHandlerData
	{
		
		
		
		
#region  < DATA MEMBERS >
		
		private string _clientName;
		private bool _statisticHandling;
		private publicationsPosting.containers.PostedPublicationsDefinitionsDataContainer _PublicationsPostedDataContainer;
		private publicationsConnection.containers.PublicationsConnectionDataContainer _publicationsConnectionContainer;
		
#endregion
#region  < EVENTS >
		
		public delegate void PublicationConnectionDataAddedEventHandler(PublicationConnectionData data);
		private PublicationConnectionDataAddedEventHandler PublicationConnectionDataAddedEvent;
		
		public event PublicationConnectionDataAddedEventHandler PublicationConnectionDataAdded
		{
			add
			{
				PublicationConnectionDataAddedEvent = (PublicationConnectionDataAddedEventHandler) System.Delegate.Combine(PublicationConnectionDataAddedEvent, value);
			}
			remove
			{
				PublicationConnectionDataAddedEvent = (PublicationConnectionDataAddedEventHandler) System.Delegate.Remove(PublicationConnectionDataAddedEvent, value);
			}
		}
		
		public delegate void PublicationConnectionDataRemovedEventHandler(PublicationConnectionData data);
		private PublicationConnectionDataRemovedEventHandler PublicationConnectionDataRemovedEvent;
		
		public event PublicationConnectionDataRemovedEventHandler PublicationConnectionDataRemoved
		{
			add
			{
				PublicationConnectionDataRemovedEvent = (PublicationConnectionDataRemovedEventHandler) System.Delegate.Combine(PublicationConnectionDataRemovedEvent, value);
			}
			remove
			{
				PublicationConnectionDataRemovedEvent = (PublicationConnectionDataRemovedEventHandler) System.Delegate.Remove(PublicationConnectionDataRemovedEvent, value);
			}
		}
		
		public delegate void publicationPostDataAddedEventHandler(PostedPublicationDefinitionData data);
		private publicationPostDataAddedEventHandler publicationPostDataAddedEvent;
		
		public event publicationPostDataAddedEventHandler publicationPostDataAdded
		{
			add
			{
				publicationPostDataAddedEvent = (publicationPostDataAddedEventHandler) System.Delegate.Combine(publicationPostDataAddedEvent, value);
			}
			remove
			{
				publicationPostDataAddedEvent = (publicationPostDataAddedEventHandler) System.Delegate.Remove(publicationPostDataAddedEvent, value);
			}
		}
		
		public delegate void PublicationPostDataRemovedEventHandler(PostedPublicationDefinitionData data);
		private PublicationPostDataRemovedEventHandler PublicationPostDataRemovedEvent;
		
		public event PublicationPostDataRemovedEventHandler PublicationPostDataRemoved
		{
			add
			{
				PublicationPostDataRemovedEvent = (PublicationPostDataRemovedEventHandler) System.Delegate.Combine(PublicationPostDataRemovedEvent, value);
			}
			remove
			{
				PublicationPostDataRemovedEvent = (PublicationPostDataRemovedEventHandler) System.Delegate.Remove(PublicationPostDataRemovedEvent, value);
			}
		}
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public ClientHandlerData(string name, bool statisticsHandling)
		{
			this._statisticHandling = statisticsHandling;
			this._clientName = name;
			this._publicationsConnectionContainer = new publicationsConnection.containers.PublicationsConnectionDataContainer();
			this._PublicationsPostedDataContainer = new publicationsPosting.containers.PostedPublicationsDefinitionsDataContainer();
		}
		
#endregion
		
#region  < PROPERTIES >
		
public string ClientName
		{
			get
			{
				return this._clientName;
			}
		}
		
public bool StatisticsHandling
		{
			get
			{
				return this._statisticHandling;
			}
		}
		
public IEnumerator PublicationsPostEnumerator
		{
			get
			{
				return this._PublicationsPostedDataContainer.GetEnumerator();
			}
		}
		
public IEnumerator PublicationsConnectionsEnumerator
		{
			get
			{
				return this._publicationsConnectionContainer.GetEnumerator();
			}
		}
		
		
#endregion
		
#region  < PUBLIC METHODS >
		
		
#region  < PUBLICATIONS  POSTING DATA  >
		
		public void AddPublicationPostDefinition(PostedPublicationDefinitionData data)
		{
			this._PublicationsPostedDataContainer.AddPublicationData(data);
			try
			{
				if (publicationPostDataAddedEvent != null)
					publicationPostDataAddedEvent(data);
			}
			catch (Exception)
			{
			}
		}
		
		public void RemovePublicationPostDefinition(PostedPublicationDefinitionData data)
		{
			this._PublicationsPostedDataContainer.RemovePublicationData(data);
			try
			{
				if (PublicationPostDataRemovedEvent != null)
					PublicationPostDataRemovedEvent(data);
			}
			catch (Exception)
			{
			}
		}
		
		public PostedPublicationDefinitionData GetPublicationPostDefinition(string publicationName)
		{
			return this._PublicationsPostedDataContainer.GetPublicationData(publicationName);
		}
#endregion
		
#region  < PUBLICATIONS CONNECTION >
		
		public void AddPublicationConnectionData(PublicationConnectionData data)
		{
			this._publicationsConnectionContainer.AddConnectionData(data);
			try
			{
				if (PublicationConnectionDataAddedEvent != null)
					PublicationConnectionDataAddedEvent(data);
			}
			catch (Exception)
			{
			}
		}
		
		public void RemovePublicationConnectionData(PublicationConnectionData data)
		{
			this._publicationsConnectionContainer.RemoveConnectionData(data);
			try
			{
				if (PublicationConnectionDataRemovedEvent != null)
					PublicationConnectionDataRemovedEvent(data);
			}
			catch (Exception)
			{
			}
		}
		
		public PublicationConnectionData GetPublicationConnectionData(string publicationName)
		{
			return this._publicationsConnectionContainer.GetConnectionData(publicationName);
		}
		
		
#endregion
		
		
		
		
#endregion
		
	}
	
}
