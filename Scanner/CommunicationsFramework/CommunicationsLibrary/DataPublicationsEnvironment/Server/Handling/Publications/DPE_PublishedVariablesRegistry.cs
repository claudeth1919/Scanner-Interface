using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications
	{
		
		public class DPE_PublishedVariablesRegistry
		{
			
#region  < CLASS INFORMATION >
			
			
			
#endregion
			
#region  < DATAMEMBERS >
			
			private Hashtable _variablesTable;
			private Hashtable _variablesLastDataRecorded;
			private DataTable _publicationVariablesDataTable;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_PublishedVariablesRegistry(string publicationName)
			{
				this._variablesTable = new Hashtable();
				this._variablesLastDataRecorded = new Hashtable();
				
				this._publicationVariablesDataTable = new DataTable(publicationName);
				this._publicationVariablesDataTable.Columns.Add("Variable Name", System.Type.GetType("System.String"));
				this._publicationVariablesDataTable.Columns.Add("Data Type", System.Type.GetType("System.String"));
			}
			
#endregion
			
#region  < PROPERTIES  >
			
internal Collection PublishedVariablesNamesList
			{
				get
				{
					Collection col = new Collection();
					IEnumerator enumm = this._variablesTable.GetEnumerator();
					string dataName = "";
					while (enumm.MoveNext())
					{
						dataName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
						col.Add(dataName, null, null, null);
					}
					return col;
				}
			}
			
internal DataTable PublishedVariablesRegistryTable
			{
				get
				{
					return this._publicationVariablesDataTable.Copy();
				}
			}
			
internal int PublishedVariablesCount
			{
				get
				{
					return this._variablesTable.Count;
				}
			}
			
#endregion
			
#region  < PRIVATE >
			
			private void AddVariableToDataTableRegistry(string dataname, DPE_ServerDefs.PublicationVariableDataType datataype)
			{
				try
				{
					dataname = dataname.ToUpper();
					DataRow newrow = this._publicationVariablesDataTable.NewRow();
					newrow["Variable Name"] = dataname;
					newrow["Data Type"] = DPE_ServerDefs.Get_String_FromPublicationVariableDataType(datataype);
					this._publicationVariablesDataTable.Rows.Add(newrow);
				}
				catch (Exception)
				{
				}
			}
			
			private void RemoveVariableFromDataTableRegistry(string dataname)
			{
				try
				{
					dataname = dataname.ToUpper();
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[Variable Name] = \'" + dataname + "\'";
					resultRows = this._publicationVariablesDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow publisherRow = resultRows[0];
						this._publicationVariablesDataTable.Rows.Remove(publisherRow);
						this._publicationVariablesDataTable.AcceptChanges();
					}
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void AddDataVariablePublication(string dataName, DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				dataName = dataName.ToUpper();
				lock(this._variablesTable)
				{
					if (!this._variablesTable.ContainsKey(dataName))
					{
						this._variablesTable.Add(dataName, dataType);
						this.AddVariableToDataTableRegistry(dataName, dataType);
					}
				}
			}
			
			internal void RemoveDataVariablePublication(string dataName)
			{
				dataName = dataName.ToUpper();
				lock(this._variablesTable)
				{
					if (this._variablesTable.ContainsKey(dataName))
					{
						this._variablesTable.Remove(dataName);
						this.RemoveVariableFromDataTableRegistry(dataName);
					}
				}
			}
			
			internal dynamic ContainsDataVariablePublication(string dataName)
			{
				dataName = dataName.ToUpper();
				bool result = this._variablesTable.ContainsKey(dataName);
				return result;
			}
			
			internal DPE_ServerDefs.PublicationVariableDataType GetDataVariablePublicationDataType(string dataname)
			{
				dataname = dataname.ToUpper();
				if (this._variablesTable.ContainsKey(dataname))
				{
					DPE_ServerDefs.PublicationVariableDataType type = default(DPE_ServerDefs.PublicationVariableDataType);
					type = (DPE_ServerDefs.PublicationVariableDataType) (this._variablesTable[dataname]);
					return type;
				}
				else
				{
					throw (new Exception("No variable named \'" + dataname + "\' registered in the container"));
				}
			}
			
			internal void RecordLastValue(DPE_PublicationData data)
			{
				try
				{
					lock(this._variablesLastDataRecorded)
					{
						if (this._variablesLastDataRecorded.ContainsKey(data.VariableName))
						{
							this._variablesLastDataRecorded.Remove(data.VariableName);
						}
						this._variablesLastDataRecorded.Add(data.VariableName, data);
					}
				}
				catch (Exception)
				{
				}
			}
			
			internal DPE_PublicationData GetLastRecordedDataValue(string dataName)
			{
				dataName = dataName.ToUpper();
				if (this._variablesLastDataRecorded.ContainsKey(dataName))
				{
                    return (DPE_PublicationData)this._variablesLastDataRecorded[dataName];
				}
				else
				{
					return null;
				}
			}
			
			internal void ClearLastRecordedDataValue(string dataname)
			{
				dataname = dataname.ToUpper();
				lock(this._variablesLastDataRecorded)
				{
					if (this._variablesLastDataRecorded.ContainsKey(dataname))
					{
						this._variablesLastDataRecorded.Remove(dataname);
					}
				}
				
			}
			
#endregion
			
		}
		
		
	}
	
	
}
