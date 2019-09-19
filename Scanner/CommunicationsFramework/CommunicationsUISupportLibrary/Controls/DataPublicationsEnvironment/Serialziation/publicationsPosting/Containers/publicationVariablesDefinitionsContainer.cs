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
		
		[Serializable()]public class publicationVariablesDefinitionsContainer : IEnumerable
		{
			
			
#region  < DATAMEMBERS >
			
			private Hashtable _container;
			
#endregion
			
#region  < PROPERTIES >
			
internal IEnumerator TableEnumerator
			{
				get
				{
					return this._container.GetEnumerator();
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public publicationVariablesDefinitionsContainer()
			{
				this._container = new Hashtable();
			}
			
#endregion
			
#region  < PUBLIC METHODS  >
			
			public void AddVariable(PublicationVariableDefinitionData variable)
			{
				this._container.Add(variable.VariableName, variable);
			}
			
			public void RemoveVariable(PublicationVariableDefinitionData variable)
			{
				this._container.Remove(variable.VariableName);
			}
			
			public PublicationVariableDefinitionData GetVariable(string VariableName)
			{
				return (PublicationVariableDefinitionData)this._container[VariableName];
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				publicationVariablesDefinitionsContainerEnumerator enumm = new publicationVariablesDefinitionsContainerEnumerator(this);
				return enumm;
			}
			
#endregion
			
#endregion
			
			
		}
		
	}
	
}
