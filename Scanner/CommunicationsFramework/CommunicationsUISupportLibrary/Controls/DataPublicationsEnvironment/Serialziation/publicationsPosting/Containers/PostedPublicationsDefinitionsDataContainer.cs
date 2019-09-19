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
	namespace publicationsPosting.containers
	{
		
		[Serializable()]public class PostedPublicationsDefinitionsDataContainer : IEnumerable
		{
			
#region  < DATA MEMBERS  >
			
			private Hashtable _publicationsPostingTable;
			
#endregion
			
#region  < PROPERTIES  >
			
internal IEnumerator TableEnumerator
			{
				get
				{
					return this._publicationsPostingTable.GetEnumerator();
				}
			}
			
#endregion
			
			
#region  < COSNTUCTORS >
			
			public PostedPublicationsDefinitionsDataContainer()
			{
				this._publicationsPostingTable = new Hashtable();
			}
			
#endregion
			
			
#region  < PUBLIC METHODS >
			
			public void AddPublicationData(PostedPublicationDefinitionData data)
			{
				this._publicationsPostingTable.Add(data.PublicationName, data);
			}
			
			public void RemovePublicationData(PostedPublicationDefinitionData data)
			{
				this._publicationsPostingTable.Remove(data.PublicationName);
			}
			
			
			public PostedPublicationDefinitionData GetPublicationData(string publicationName)
			{
				return (PostedPublicationDefinitionData)this._publicationsPostingTable[publicationName];
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				PostedPublicationsDefinitionsDataContainerEnumerator newEnumm = new PostedPublicationsDefinitionsDataContainerEnumerator(this);
				return newEnumm;
			}
			
#endregion
			
#endregion
			
		}
	}
	
	
	
	
	
}
