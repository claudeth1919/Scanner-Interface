using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.Serialization;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;



namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling.Data
	{
		
		[Serializable()]public class DiscoverableServiceDefinitionParametersContainer : IEnumerable
		{
			
			
#region  < DATA MEMBERS  >

            private const string PARAMETER_NAME = "Parameter Name";
            private const string SERVICE_PARAMETERS = "SERVICE_PARAMETERS";
            private const string PARAMETER_VALUE = "Parameter Value";
 
			
			private CustomHashTable _parameters;
			//table to hold te service parameters
			private DataTable _serviceParametersDataTable;
			
#endregion
			
#region  < PROPERTIES >
			
public CustomHashTable ParametersTable
			{
				get
				{
					return this._parameters;
				}
			}
			
public DataTable ParametersDataTable
			{
				get
				{
					return this._serviceParametersDataTable;
				}
			}
			
public int Count
			{
				get
				{
					return this._parameters.Count;
				}
			}
#endregion
			
#region  < CONSTRUCTORS>
			
			public DiscoverableServiceDefinitionParametersContainer()
			{
				this._parameters = new CustomHashTable();
				this._serviceParametersDataTable = new DataTable(SERVICE_PARAMETERS);
				this._serviceParametersDataTable.Columns.Add(PARAMETER_NAME, System.Type.GetType("System.String"));
				this._serviceParametersDataTable.Columns.Add(PARAMETER_VALUE, System.Type.GetType("System.String"));
			}
			
			internal DiscoverableServiceDefinitionParametersContainer(CustomHashTable parametersTable) : this ()
			{

                IEnumerator enumm = parametersTable.GetEnumerator();
                DictionaryEntry dicentry;
                while (enumm.MoveNext())
                {
                    dicentry = (DictionaryEntry)enumm.Current;
                    this.AddParameter(Convert.ToString(dicentry.Key), Convert.ToString(dicentry.Value));
                }

               
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			public void AddParameter(string parameterName, string value)
			{
				parameterName = parameterName.ToUpper();
				if (!this._parameters.ContainsKey(parameterName))
				{
					this._parameters.Add(parameterName, value);
					DataRow row = default(DataRow);
					row = this._serviceParametersDataTable.NewRow();
					row[PARAMETER_NAME] = parameterName;
					row[PARAMETER_VALUE] = value;
					this._serviceParametersDataTable.Rows.Add(row);
				}
				else
				{
					this.UpdateParameter(parameterName, value);
				}
			}
			
			public void UpdateParameter(string parameterName, string value)
			{
				parameterName = parameterName.ToUpper();
				if (this._parameters.ContainsKey(parameterName))
				{
					this._parameters.Remove(parameterName);
					this.AddParameter(parameterName, value);
				}
				else
				{
					this.AddParameter(parameterName, value);
				}
			}
			
			public void RemoveParameter(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				if (this._parameters.ContainsKey(parameterName))
				{
					this._parameters.Remove(parameterName);
					string selectionCriteria = "";
					DataRow[] resultRows = null;
                    selectionCriteria = "[" + PARAMETER_NAME + "] = \'" + parameterName + "\'";
					resultRows = this._serviceParametersDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow parameterRow = resultRows[0];
						this._serviceParametersDataTable.Rows.Remove(parameterRow);
						this._serviceParametersDataTable.AcceptChanges();
					}
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public DiscoverableServiceParameter GetParameter(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				if (this._parameters.ContainsKey(parameterName))
				{
					string paramValue = System.Convert.ToString(this._parameters.Item(parameterName));
					DiscoverableServiceParameter param = new DiscoverableServiceParameter(parameterName, paramValue);
					return param;
				}
				else
				{
					return null;
				}
			}
			
			public bool ContainsParameter(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				return this._parameters.ContainsKey(parameterName);
			}
			
			public void SaveToFile(string filePath, string fileName)
			{
				ObjectSerializer.SerializeObjectToFile(this, filePath, fileName);
			}
			
			public void SaveToFile(string fileName)
			{
				ObjectSerializer.SerializeObjectToFile(this, fileName);
			}
			
			public static DiscoverableServiceDefinitionParametersContainer GetLocalServiceParameters(string parametersFileName)
			{
				DiscoverableServiceDefinitionParametersContainer _STXServiceDefinitionParametersContainer = default(DiscoverableServiceDefinitionParametersContainer);
				try
				{
					_STXServiceDefinitionParametersContainer = ObjectSerializer.DeserializeObjectFromFile(parametersFileName);
					return _STXServiceDefinitionParametersContainer;
				}
				catch (Exception)
				{
					return null;
				}
				
			}
			
#endregion

#region  < INTERFACE IMPLEMENTATION >

#region  < IEnumerable >

public System.Collections.IEnumerator GetEnumerator()
{
	DiscoverableServiceDefinitionParametersContainerEnumerator enumm = new DiscoverableServiceDefinitionParametersContainerEnumerator(this._parameters);
	return enumm;
}
			
#endregion
			
#endregion
			
			
		}
		
		
	}
	
	
	
}
