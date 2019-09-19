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
		
		[Serializable()]public class publicationVariablesDefinitionsContainerEnumerator : IEnumerator
		{
			
			
#region  < DATAMEMBERS >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			internal publicationVariablesDefinitionsContainerEnumerator(publicationVariablesDefinitionsContainer container)
			{
				this._enumerator = container.TableEnumerator;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  <IEnumerator  >
			
public dynamic Current
			{
				get
				{
					PublicationVariableDefinitionData variable = (PublicationVariableDefinitionData) (((DictionaryEntry) this._enumerator.Current).Value);
					return variable;
				}
			}
			
			public bool MoveNext()
			{
				return this._enumerator.MoveNext();
			}
			
			public void Reset()
			{
				this._enumerator.Reset();
			}
			
#endregion
			
#endregion
			
		}
		
		
	}
	
}
