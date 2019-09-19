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


namespace CommunicationsUISupportLibrary
{
	namespace publicationsConnection.containers
	{
		
		[Serializable()]public class PublicationsConnectionDataContainer : IEnumerable
		{
			
#region  < DATA MEMBERS >
			
			private Hashtable _table;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public PublicationsConnectionDataContainer()
			{
				this._table = new Hashtable();
			}
#endregion
			
#region  < PROPERTIES >
			
internal IEnumerator ConnectionInfoTableEnumerator
			{
				get
				{
					return this._table.GetEnumerator();
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddConnectionData(PublicationConnectionData data)
			{
				if (!this._table.ContainsKey(data.PublicationName))
				{
					this._table.Add(data.PublicationName, data);
				}
			}
			
			public void RemoveConnectionData(PublicationConnectionData data)
			{
				this._table.Remove(data.PublicationName);
			}
			
			public PublicationConnectionData GetConnectionData(string publicationName)
			{
				return (PublicationConnectionData)this._table[publicationName];
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				PublicationsConnectionDataContainerEnumerator enumm = new PublicationsConnectionDataContainerEnumerator(this);
				return enumm;
			}
			
#endregion
			
#endregion
			
			
		}
		
	}
	
}
