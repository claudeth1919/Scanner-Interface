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
		
		public class DPE_PublicationConnectionHandlersContainer
		{
			
#region  < DATA MEMBERS  >
			
			private Hashtable _tableOfPublicationConnectionHandlers;
#endregion
			
#region  < PROPERTIES >
			
internal int Count
			{
				get
				{
					return this._tableOfPublicationConnectionHandlers.Count;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public DPE_PublicationConnectionHandlersContainer()
			{
				this._tableOfPublicationConnectionHandlers = new Hashtable();
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			
			internal bool ContainsPublicationHandler(string PublicationName)
			{
				return this._tableOfPublicationConnectionHandlers.ContainsKey(PublicationName);
			}
			
			internal void RemoveConnectionHandler(string PublicationName)
			{
				if (this._tableOfPublicationConnectionHandlers.ContainsKey(PublicationName))
				{
					this._tableOfPublicationConnectionHandlers.Remove(PublicationName);
				}
			}
			
			internal DPE_PublicationConnectionHandler GetConnectionHandler(string publicationName)
			{
				if (this.ContainsPublicationHandler(publicationName))
				{
                    return (DPE_PublicationConnectionHandler)this._tableOfPublicationConnectionHandlers[publicationName];
				}
				else
				{
					return null;
				}
			}
			
			internal void Clear()
			{
				this._tableOfPublicationConnectionHandlers.Clear();
			}
			
			internal void AddPublicationConnectionHandler(DPE_PublicationConnectionHandler publicationConnectionHandler)
			{
				lock(this._tableOfPublicationConnectionHandlers)
				{
					if (!this._tableOfPublicationConnectionHandlers.ContainsKey(publicationConnectionHandler.PublicationName))
					{
                        this._tableOfPublicationConnectionHandlers.Add(publicationConnectionHandler.PublicationName, publicationConnectionHandler);
					}
					else
					{
                        throw (new Exception("The connection handler for publication \'" + publicationConnectionHandler.PublicationName + "\' is already added."));
					}
				}
			}
			
			internal void DiscardAllLocalConnectionsToPublications()
			{
				lock(this._tableOfPublicationConnectionHandlers)
				{
					IEnumerator enumm = default(IEnumerator);
					DPE_PublicationConnectionHandler handler = default(DPE_PublicationConnectionHandler);
					enumm = this._tableOfPublicationConnectionHandlers.GetEnumerator();
					while (enumm.MoveNext())
					{
                        handler = (DPE_PublicationConnectionHandler)((DictionaryEntry)enumm.Current).Value;
						try
						{
							handler.DisconnectFromPublication();
							handler.Dispose();
						}
						catch (Exception)
						{
						}
					}
					this._tableOfPublicationConnectionHandlers.Clear();
				}
			}
			
#endregion
			
		}
		
		
	}
	
}
