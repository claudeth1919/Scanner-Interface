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
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
	
	
	
	namespace DPEClientTestApplication
	{
		namespace publicationsPosting
		{
			
			[Serializable()]public class PublicationVariableDefinitionData
			{
				
#region  < DATAMEMBERS >
				
				private string _variableName;
                private DPE_ServerDefs.PublicationVariableDataType _publicationVariableDAtaType;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public PublicationVariableDefinitionData(string variableName, CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				this._variableName = variableName;
				this._publicationVariableDAtaType = dataType;
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string VariableName
			{
				get
				{
					return this._variableName;
				}
			}
			
public CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.PublicationVariableDataType DataType
			{
				get
				{
					return this._publicationVariableDAtaType;
				}
			}
			
#endregion
			
		}
		
	}
	
	
}
