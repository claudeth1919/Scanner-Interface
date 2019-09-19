using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		
		[Serializable()]public class CNDTable : IEnumerable
		{
			
			
#region  < DATA MEMBERS >
			
			private DataTable _componentDirectoryDataTable;
			
#endregion
			
#region  < PROPERTIES >
			
internal DataTable DataTable
			{
				get
				{
					return this._componentDirectoryDataTable.Copy();
				}
			}
			
internal int RegisteredComponentsCount
			{
				get
				{
					return this._componentDirectoryDataTable.Rows.Count;
				}
			}
			
public System.Data.DataTable Table
			{
				get
				{
					DataTable dt = this._componentDirectoryDataTable.Copy();
					return dt;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal CNDTable()
			{
				this._componentDirectoryDataTable = new DataTable(CNDServiceDefinitions.CND_TABLE_DATA_NAME);
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME, System.Type.GetType("System.String"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_HOST_NAME, System.Type.GetType("System.String"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER, System.Type.GetType("System.Int32"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS, System.Type.GetType("System.String"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME, System.Type.GetType("System.String"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID, System.Type.GetType("System.String"));
				this._componentDirectoryDataTable.Columns.Add(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME, System.Type.GetType("System.String"));
			}
			
			internal CNDTable(DataTable Table)
			{
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME + "\'"));
				}
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_HOST_NAME))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_HOST_NAME + "\'"));
				}
				
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER + "\'"));
				}
				
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_IP_ADDRESS + "\'"));
				}
				
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME + "\'"));
				}
				
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID + "\'"));
				}
				
				if (!Table.Columns.Contains(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME))
				{
					throw (new Exception("Invalid CNDTable Format: it doesnt contains a column named \'" + CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME + "\'"));
				}
				try
				{
					Table.TableName = CNDServiceDefinitions.CND_TABLE_DATA_NAME;
				}
				catch (Exception)
				{
				}
				this._componentDirectoryDataTable = Table;
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SetTable(DataTable datatable)
			{
				this._componentDirectoryDataTable = datatable;
			}
			
			internal bool ContainsComponentRegistry(string ComponentName)
			{
				bool RESULT = default(bool);
				lock(this._componentDirectoryDataTable)
				{
					ComponentName = ComponentName.ToUpper();
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[" + CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME + "] = \'" + ComponentName + "\'";
					resultRows = this._componentDirectoryDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						RESULT = true;
					}
					else
					{
						RESULT = false;
					}
				}
				return RESULT;
			}
			
			internal void RemoveComponentRegistry(string ComponentName)
			{
				lock(this._componentDirectoryDataTable)
				{
					ComponentName = ComponentName.ToUpper();
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					selectionCriteria = "[" + CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME + "] = \'" + ComponentName + "\'";
					resultRows = this._componentDirectoryDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						DataRow componentRow = default(DataRow);
						componentRow = resultRows[0];
						this._componentDirectoryDataTable.Rows.Remove(componentRow);
						this._componentDirectoryDataTable.AcceptChanges();
					}
				}
				
			}
			
			internal void AddComponentRegistry(string ComponentName, string HostName, string ipAdress, int P2PPortNumber, string AppName, string ProcessID)
			{
				lock(this._componentDirectoryDataTable)
				{
					DataRow componentRow = default(DataRow);
					componentRow = this._componentDirectoryDataTable.NewRow();
					componentRow[CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME] = ComponentName;
					componentRow[CNDServiceDefinitions.CND_TABLE_HOST_NAME] = HostName;
					componentRow[CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER] = P2PPortNumber;
					componentRow[CNDServiceDefinitions.CND_TABLE_IP_ADDRESS] = ipAdress;
					componentRow[CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME] = AppName;
					componentRow[CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID] = ProcessID;
					componentRow[CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME] = DateTime.Now.ToString();
					this._componentDirectoryDataTable.Rows.Add(componentRow);
				}
			}
			
			internal CustomHashTable GetComponentRegistry(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				string selectionCriteria = "";
				DataRow[] resultRows = null;
				selectionCriteria = "[" + CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME + "] = \'" + ComponentName + "\'";
				resultRows = this._componentDirectoryDataTable.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					DataRow componentRow = default(DataRow);
					componentRow = resultRows[0];
					
					CustomHashTable table = new CustomHashTable();
					string compName = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME]);
					string hostName = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_HOST_NAME]);
					string P2PPortNumber = System.Convert.ToString(System.Convert.ToInt32(componentRow[CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER]));
					string IPAddress = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_IP_ADDRESS]);
					string ApplicationName = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME]);
					string ApplicationProcessID = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID]);
					string RegistrationDateTime = System.Convert.ToString(componentRow[CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME]);
					
					table.Add(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME, compName);
					table.Add(CNDServiceDefinitions.CND_TABLE_HOST_NAME, hostName);
					table.Add(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER, P2PPortNumber);
					table.Add(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS, IPAddress);
					table.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME, ApplicationName);
					table.Add(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID, ApplicationProcessID);
					table.Add(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME, RegistrationDateTime);
					
					return table;
				}
				else
				{
					return null;
				}
			}
			
			internal CNDAddressingReg GetCNDAddressingRegister(string ComponentName)
			{
				UtilitiesLibrary.Data.CustomHashTable table = default(UtilitiesLibrary.Data.CustomHashTable);
				table = this.GetComponentRegistry(ComponentName);
				if (!(table == null))
				{
					string compName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME));
					compName = compName.ToUpper();
					string hostName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_HOST_NAME));
					string P2PPortNumber = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER));
					string IPAddress = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS));
					string ApplicationName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME));
					string ApplicationProcessID = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID));
					string RegistrationDateTime = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME));
                    int portNumber = Convert.ToInt32(P2PPortNumber);
                    CNDAddressingReg reg = new CNDAddressingReg(ComponentName, hostName, IPAddress, portNumber, ApplicationName, ApplicationProcessID, RegistrationDateTime);
					return reg;
				}
				else
				{
					return null;
				}
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static CNDAddressingReg GetAddressingRegister(CustomHashTable table)
			{
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[Component Name]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_HOST_NAME))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[Hostname]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[P2PPortNumber]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[IPAddress]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[Application Name]\' is missing."));
				}
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[Application Process ID]\' is missing."));
				}
				
				
				if (!table.Contains(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME))
				{
					throw (new Exception("Can\'t get a CNDAddressingReg from Table because the parameter \'[Registration Date Time]\' is missing."));
				}
				
				string compName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME));
				compName = compName.ToUpper();
				string hostName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_HOST_NAME));
				string P2PPortNumber = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER));
				string IPAddress = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_IP_ADDRESS));
				string ApplicationName = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME));
				string ApplicationProcessID = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID));
				string RegistrationDateTime = System.Convert.ToString(table.Item(CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME));
				
                int PortNumber = Convert.ToInt32(P2PPortNumber);
                CNDAddressingReg reg = new CNDAddressingReg(compName, hostName, IPAddress, PortNumber, ApplicationName, ApplicationProcessID, RegistrationDateTime);
				return reg;
				
				
			}
			
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				CNDTableEnumerator enumetator = new CNDTableEnumerator(this);
				return enumetator;
			}
			
#endregion
			
			
			
#endregion
			
			
		}
		
		
		
	}
	
	
}
