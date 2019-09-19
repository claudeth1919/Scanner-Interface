using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client
	{
		
		public class DPE_ClientPublicationDefinition
		{
			
#region  < DATAMEMBERS >
			
			private string _publicationName;
			private string _publicationsGroup;
			private Hashtable _variablesToPublish;
			
#endregion
			
#region  < PROPERTIES >
			
public string PublicationName
			{
				get
				{
					return this._publicationName;
				}
			}
			
public string PublicationsGroup
			{
				get
				{
					return this._publicationsGroup;
				}
			}
			
internal Hashtable VariablesToPublishTable
			{
				get
				{
					return this._variablesToPublish;
				}
				set
				{
					this._variablesToPublish = value;
				}
			}
			
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_ClientPublicationDefinition(string PublicationName) : this(DPE_GlobalDefinitions.DPE_DEFAULT_PUBLICATIONS_GROUP, PublicationName)
			{
			}
			
			public DPE_ClientPublicationDefinition(string publicationsGroup, string PublicationName)
			{
				this._publicationsGroup = publicationsGroup;
				this._publicationName = PublicationName.ToUpper();
				this._publicationName = this._publicationName.Replace(" ", "_");
				this._variablesToPublish = new Hashtable();
			}
			
			
			
#endregion
			
#region  <  PUBLIC METHODS >
			
			public void AddVaribleToPublication(string variableName, DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				variableName = variableName.ToUpper();
				if (!this._variablesToPublish.ContainsKey(variableName))
				{
					this._variablesToPublish.Add(variableName, dataType);
				}
			}
			
			public void RemoveVariableFromPublication(string variableName)
			{
				variableName = variableName.ToUpper();
				if (this._variablesToPublish.ContainsKey(variableName))
				{
					this._variablesToPublish.Remove(variableName);
				}
			}
			
			public bool ContainsVariable(string variableName)
			{
				variableName = variableName.ToUpper();
				return this._variablesToPublish.ContainsKey(variableName);
			}
			
			public DPE_ServerDefs.PublicationVariableDataType GetVariableDataTypeDefined(string variableName)
			{
				variableName = variableName.ToUpper();
				if (this._variablesToPublish.ContainsKey(variableName))
				{
					DPE_ServerDefs.PublicationVariableDataType type = default(DPE_ServerDefs.PublicationVariableDataType);
                    type = (DPE_ServerDefs.PublicationVariableDataType)this._variablesToPublish[variableName];
					return type;
				}
				else
				{
					throw (new Exception("The variable \'" + variableName + "\' is not contained in the publication \'" + this._publicationName + "\'"));
				}
			}
			
#endregion
			
		}
		
		
	}
	
	
}
