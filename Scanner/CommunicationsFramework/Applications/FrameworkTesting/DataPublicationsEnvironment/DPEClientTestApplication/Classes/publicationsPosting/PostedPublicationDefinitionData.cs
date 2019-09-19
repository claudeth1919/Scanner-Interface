// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using DPEClientTestApplication.publicationsPosting.containers;


namespace DPEClientTestApplication
{
	namespace publicationsPosting
	{
		
		[Serializable()]public class PostedPublicationDefinitionData
		{
			
#region  < DATAMEMBERS >
			
			private string _publicationName;
			private publicationVariablesDefinitionsContainer _publicationVariablesDAtaContainer;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public PostedPublicationDefinitionData(string publicationName)
			{
				this._publicationName = publicationName;
			}
			
#endregion
			
#region  < PROPERTIES >
			
public publicationVariablesDefinitionsContainer VariablesDefinitionContainer
			{
				get
				{
					return this._publicationVariablesDAtaContainer;
				}
			}
			
public string PublicationName
			{
				get
				{
					return this._publicationName;
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddVariableDefinition(PublicationVariableDefinitionData def)
			{
				this._publicationVariablesDAtaContainer.AddVariable(def);
			}
			
			public void RemoveVariableDefinition(PublicationVariableDefinitionData def)
			{
				this._publicationVariablesDAtaContainer.RemoveVariable(def);
			}
			
#endregion
			
		}
		
	}
	
	
}
