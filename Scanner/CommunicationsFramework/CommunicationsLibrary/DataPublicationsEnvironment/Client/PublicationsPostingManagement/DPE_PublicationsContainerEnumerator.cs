using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsPostingManagement
	{
		
		
		public class DPE_PublicationsContainerEnumerator : IEnumerator
		{
			
			
#region  < DATA MEMBERES >
			
			private DPE_PublicationDefinitionsContainer _STXDSSPublicationDefinitionsContainer;
			IEnumerator enumm;
			
#endregion
			
			internal DPE_PublicationsContainerEnumerator(DPE_PublicationDefinitionsContainer publicationsContainer)
			{
				this._STXDSSPublicationDefinitionsContainer = publicationsContainer;
				this.enumm = this._STXDSSPublicationDefinitionsContainer.DefintionsTable.GetEnumerator();
			}
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerator >
			
public dynamic Current
			{
				get
				{
					DPE_ClientPublicationDefinition def = default(DPE_ClientPublicationDefinition);
					def = (DPE_ClientPublicationDefinition) (((DictionaryEntry) this.enumm.Current).Value);
					return def;
				}
			}
			
			public bool MoveNext()
			{
				return this.enumm.MoveNext();
			}
			
			public void Reset()
			{
				this.enumm.Reset();
			}
			
#endregion
			
#endregion
			
		}
		
		
	}
	
}
