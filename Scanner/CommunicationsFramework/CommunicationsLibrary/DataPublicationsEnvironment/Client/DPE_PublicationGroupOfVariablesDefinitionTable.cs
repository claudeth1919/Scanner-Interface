using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsConnectionManaging;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsPostingManagement;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client
	{
		
		public class DPE_PublicationGroupOfVariablesDefinitionTable
		{
			
#region  < DATA MEMBERS >
			
			private DataTable _table;
			private Hashtable _tableAsHashTable;
			
			
			
#endregion
			
#region  < PROPERTIES >
			
public DataTable GroupOfVariablesTable
			{
				get
				{
					return this._table;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_PublicationGroupOfVariablesDefinitionTable()
			{
				this._tableAsHashTable = new Hashtable();
				this._table = new DataTable();
				this._table.Columns.Add(DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME, System.Type.GetType("System.String"));
				this._table.Columns.Add(DPE_ServerDefs.DATATYPE_TABLE_COLUMN_NAME, System.Type.GetType("System.String"));
			}
			
#endregion
			
#region  < PUBLIC METHODS  >
			
			public void AddVariable(string variableName, DPE_ServerDefs.PublicationVariableDataType dataType)
			{
				variableName = variableName.ToUpper();
				if (!this.ContainsVariableName(variableName))
				{
					//addition to the datatable
					DataRow row = default(DataRow);
					row = this._table.NewRow();
					row[DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME] = variableName;
					row[DPE_ServerDefs.DATATYPE_TABLE_COLUMN_NAME] = dataType.ToString();
					this._table.Rows.Add(row);
					//addition to the hash table
					this._tableAsHashTable.Add(variableName, dataType);
				}
			}
			
			public bool ContainsVariableName(string variableName)
			{
				variableName = variableName.ToUpper();
				string selectionCriteria = "";
				DataRow[] resultRows = null;
				selectionCriteria = "[" + DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME + "] = \'" + variableName + "\'";
				resultRows = this._table.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			public DPE_ServerDefs.PublicationVariableDataType GetVariableDataType(string variableName)
			{
				variableName = variableName.ToUpper();
				if (this._tableAsHashTable.ContainsKey(variableName))
				{
					DPE_ServerDefs.PublicationVariableDataType type = default(DPE_ServerDefs.PublicationVariableDataType);
                    type = (DPE_ServerDefs.PublicationVariableDataType)this._tableAsHashTable[variableName];
					return type;
				}
				else
				{
                    return DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Undefined;
				}
			}
			
			public void RemoveVariable(string variableName)
			{
				variableName = variableName.ToUpper();
				string selectionCriteria = "";
				DataRow[] resultRows = null;
				selectionCriteria = "[" + DPE_ServerDefs.VARIBLE_NAME_TABLE_COLUMN_NAME + "] = \'" + variableName + "\'";
				resultRows = this._table.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					try
					{
						this._table.Rows.Remove(resultRows[0]);
					}
					catch (Exception)
					{
					}
				}
				try
				{
					this._tableAsHashTable.Remove(variableName);
				}
				catch (Exception)
				{
				}
			}
			
			
			
#endregion
			
		}
		
	}
	
	
	
}
