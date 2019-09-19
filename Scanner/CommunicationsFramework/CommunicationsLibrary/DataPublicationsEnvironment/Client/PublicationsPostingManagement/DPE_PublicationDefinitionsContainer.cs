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


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsPostingManagement
	{
		
		internal class DPE_PublicationDefinitionsContainer : IEnumerable
		{
			
			
#region  < DATAMEMBERS >
			
			private Hashtable _publicationsDefinitionsTable;
			
#endregion
			
#region  < PROPERTIES >
			
			internal DPE_ClientPublicationDefinition Item(string publicationName)
			{
				if (this.ContainsPublicationDefinition(publicationName))
				{
                    return (DPE_ClientPublicationDefinition)this._publicationsDefinitionsTable[publicationName];
				}
				else
				{
					return null;
				}
			}
			
internal Hashtable DefintionsTable
			{
				get
				{
					return this._publicationsDefinitionsTable;
				}
			}
			
internal int Count
			{
				get
				{
					return this._publicationsDefinitionsTable.Count;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_PublicationDefinitionsContainer()
			{
				this._publicationsDefinitionsTable = new Hashtable();
			}
			
#endregion
			
#region  < FRIEND METHODS>
			
			public bool ContainsPublicationDefinition(DPE_ClientPublicationDefinition definition)
			{
				if (this._publicationsDefinitionsTable.ContainsKey(definition.PublicationName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			internal bool ContainsPublicationDefinition(string PublicationName)
			{
				if (this._publicationsDefinitionsTable.ContainsKey(PublicationName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			internal void AddPublicationDefinition(DPE_ClientPublicationDefinition definition)
			{
				if (this.ContainsPublicationDefinition(definition))
				{
                    throw (new Exception("The DPE publication definition is aleady included in the container"));
				}
				else
				{
					this._publicationsDefinitionsTable.Add(definition.PublicationName, definition);
				}
			}
			
			internal void RemovePublicationDefinition(DPE_ClientPublicationDefinition definition)
			{
				if (this.ContainsPublicationDefinition(definition))
				{
					this._publicationsDefinitionsTable.Remove(definition.PublicationName);
				}
			}
			
			internal void RemovePublicationDefinition(string publicationName)
			{
				if (this.ContainsPublicationDefinition(publicationName))
				{
					this._publicationsDefinitionsTable.Remove(publicationName);
				}
			}
			
			internal void Clear()
			{
				this._publicationsDefinitionsTable.Clear();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				DPE_PublicationsContainerEnumerator enumm = new DPE_PublicationsContainerEnumerator(this);
				return enumm;
			}
			
#endregion
			
			
		}
		
		
		
	}
	
	
}
