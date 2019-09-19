using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using UtilitiesLibrary.EventLoging;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme.Statistics
	{
		
		
		public class P2PPortClientStatisticsHandler
		{
			
#region  < DATAMEMBERS >
			
			private DataTable _generalStatisticsTable;
			private DataTable _dataSendingStatisticsTable;
			private DataTable _dataRequestStatisticsTable;
			
#endregion
			
#region  < PROPERTIES >
			
public DataTable GeneralStatisticsTable
			{
				get
				{
					DataTable table = this._generalStatisticsTable;
					return table;
				}
			}
			
public DataTable DataSendingStatisticsTable
			{
				get
				{
					DataTable table = this._dataSendingStatisticsTable;
					return table;
				}
			}
			
public DataTable DataRequestsStatisticsTable
			{
				get
				{
					DataTable table = this._dataRequestStatisticsTable;
					return table;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			internal P2PPortClientStatisticsHandler()
			{
				this.CreateSocketPortClientDataStatisticsTables();
			}
			
#endregion
			
#region  < PRIVATE MEHTODS >
			
			private void CreateSocketPortClientDataStatisticsTables()
			{
				try
				{
					
					//creation of the general statistics
					this._generalStatisticsTable = new DataTable("P2PPortClientGeneralStatisticsTable");
					this._generalStatisticsTable.Columns.Add("Client Port Event", System.Type.GetType("System.String"));
					this._generalStatisticsTable.Columns.Add("Count", System.Type.GetType("System.Int64"));
					
					//creation of the data sending statistics table
					this._dataSendingStatisticsTable = new DataTable("P2PPortClientDataReceptionStatisticsTable");
					this._dataSendingStatisticsTable.Columns.Add("DataName", System.Type.GetType("System.String"));
					this._dataSendingStatisticsTable.Columns.Add("DataType", System.Type.GetType("System.String"));
					this._dataSendingStatisticsTable.Columns.Add("Count", System.Type.GetType("System.Int64"));
					this._dataSendingStatisticsTable.Columns.Add("FirstSendDateTime", System.Type.GetType("System.DateTime"));
					this._dataSendingStatisticsTable.Columns.Add("LastSendDateTime", System.Type.GetType("System.DateTime"));
					
					//creation of the data recepction statistics table
					this._dataRequestStatisticsTable = new DataTable("P2PPortClientDataRequestsStatisticsTable");
					this._dataRequestStatisticsTable.Columns.Add("DataName", System.Type.GetType("System.String"));
					this._dataRequestStatisticsTable.Columns.Add("Successful", System.Type.GetType("System.Int64"));
					this._dataRequestStatisticsTable.Columns.Add("Failed", System.Type.GetType("System.Int64"));
					this._dataRequestStatisticsTable.Columns.Add("FirstRequestDateTime", System.Type.GetType("System.DateTime"));
					this._dataRequestStatisticsTable.Columns.Add("LastRequestDateTime", System.Type.GetType("System.DateTime"));
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void LogDataSendEventsOnTable(P2PData Data)
			{
				
				if (!(Data == null))
				{
					
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					
					
					//*****************************************************************************
					//updates the general statistics table
					//*****************************************************************************
					try
					{
						
						lock(this._generalStatisticsTable)
						{
							
							selectionCriteria = "[Client Port Event] = \'Successful Data Send\'";
							resultRows = this._generalStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								DataRow row = this._generalStatisticsTable.NewRow();
								row["Client Port Event"] = "Successful Data Send";
								row["Count"] = 1;
								this._generalStatisticsTable.Rows.Add(row);
							}
							else
							{
								long count = (long) (resultRows[0]["Count"]);
								count++;
								resultRows[0]["Count"] = count;
								resultRows[0].AcceptChanges();
							}
							
						}
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient General Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
					
					//*****************************************************************************
					//updates the data send statistics table
					//*****************************************************************************
					try
					{
						
						lock(this._dataSendingStatisticsTable)
						{
							
							selectionCriteria = "DataName = \'" + Data.DataName + "\' AND DataType = \'" + Data.Value.GetType().ToString() + "\'";
							resultRows = this._dataSendingStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								//the dataname with the datatype is not registered
								DataRow row = this._dataSendingStatisticsTable.NewRow();
								row["DataName"] = Data.DataName;
								row["DataType"] = Data.Value.GetType().ToString();
								row["Count"] = 1;
								row["FirstSendDateTime"] = DateTime.Now;
								row["LastSendDateTime"] = DateTime.Now;
								this._dataSendingStatisticsTable.Rows.Add(row);
							}
							else
							{
								//the dataname with the datatype is registered
								long count = (long) (resultRows[0]["Count"]);
								count++;
								resultRows[0]["Count"] = count;
								resultRows[0]["LastSendDateTime"] = DateTime.Now;
								resultRows[0].AcceptChanges();
							}
							
						}
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient Data Send Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
				}
				
			}
			
			private void LogSuccesfulDataRequestEventsOnTable(P2PDataRequest dataRequest)
			{
				
				if (!(dataRequest == null))
				{
					
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					//*****************************************************************************
					//updates the general statistics table
					//*****************************************************************************
					try
					{
						lock(this._generalStatisticsTable)
						{
							
							selectionCriteria = "[Client Port Event] = \'Succesful Data Request\'";
							resultRows = this._generalStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								DataRow row = this._generalStatisticsTable.NewRow();
								row["Client Port Event"] = "Succesful Data Request";
								row["Count"] = 1;
								this._generalStatisticsTable.Rows.Add(row);
							}
							else
							{
								long count = (long) (resultRows[0]["Count"]);
								count++;
								resultRows[0]["Count"] = count;
								resultRows[0].AcceptChanges();
							}
							
						}
						
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient General Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
					
					//*****************************************************************************
					//updates the data request statistics table
					//*****************************************************************************
					try
					{
						
						lock(this._dataRequestStatisticsTable)
						{
							
							selectionCriteria = "DataName = \'" + dataRequest.RequestedDataName + "\'";
							resultRows = this._dataRequestStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								//the dataname with the datatype is not registered
								DataRow row = this._dataRequestStatisticsTable.NewRow();
								row["DataName"] = dataRequest.RequestedDataName;
								row["Successful"] = 1;
								row["Failed"] = 0;
								row["FirstRequestDateTime"] = DateTime.Now;
								row["LastRequestDateTime"] = DateTime.Now;
								this._dataRequestStatisticsTable.Rows.Add(row);
							}
							else
							{
								//the dataname with the datatype is registered
								long count = (long) (resultRows[0]["Successful"]);
								count++;
								resultRows[0]["Successful"] = count;
								resultRows[0]["LastRequestDateTime"] = DateTime.Now;
								resultRows[0].AcceptChanges();
							}
							
						}
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient Data Requests Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
				}
				
			}
			
			private void LogFailedDataRequestEventsOnTable(P2PDataRequest dataRequest)
			{
				
				if (!(dataRequest == null))
				{
					
					string selectionCriteria = "";
					DataRow[] resultRows = null;
					//*****************************************************************************
					//updates the general statistics table
					//*****************************************************************************
					try
					{
						
						lock(this._generalStatisticsTable)
						{
							
							selectionCriteria = "[Client Port Event] = \'Failed Data Request\'";
							resultRows = this._generalStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								DataRow row = this._generalStatisticsTable.NewRow();
								row["Client Port Event"] = "Failed Data Request";
								row["Count"] = 1;
								this._generalStatisticsTable.Rows.Add(row);
							}
							else
							{
								long count = (long) (resultRows[0]["Count"]);
								count++;
								resultRows[0]["Count"] = count;
								resultRows[0].AcceptChanges();
							}
							
						}
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient General Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
					
					//*****************************************************************************
					//updates the data request statistics table
					//*****************************************************************************
					try
					{
						
						lock(this._dataRequestStatisticsTable)
						{
							
							selectionCriteria = "DataName = \'" + dataRequest.RequestedDataName + "\'";
							resultRows = this._dataRequestStatisticsTable.Select(selectionCriteria);
							if (resultRows.Length <= 0)
							{
								//the dataname with the datatype is not registered
								DataRow row = this._dataRequestStatisticsTable.NewRow();
								row["DataName"] = dataRequest.RequestedDataName;
								row["Successful"] = 0;
								row["Failed"] = 1;
								row["FirstRequestDateTime"] = DateTime.Now;
								row["LastRequestDateTime"] = DateTime.Now;
								this._dataRequestStatisticsTable.Rows.Add(row);
							}
							else
							{
								//the dataname with the datatype is registered
								long count = (long) (resultRows[0]["Failed"]);
								count++;
								resultRows[0]["Failed"] = count;
								resultRows[0]["LastRequestDateTime"] = DateTime.Now;
								resultRows[0].AcceptChanges();
							}
							
						}
						
					}
					catch (Exception ex)
					{
						string msg = "Error updating P2PPortClient Data Requests Statistics Table : " + ex.ToString();
						CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
					}
					
				}
				
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void LogDataSendEvent(P2PData data)
			{
				try
				{
					this.LogDataSendEventsOnTable(data);
				}
				catch (Exception)
				{
				}
			}
			
			internal void LogSuccesfulDataRequestEvent(P2PDataRequest dataRequest)
			{
				try
				{
					this.LogSuccesfulDataRequestEventsOnTable(dataRequest);
				}
				catch (Exception)
				{
				}
			}
			
			internal void LogFailedDataRequestEvent(P2PDataRequest dataRequest)
			{
				try
				{
					this.LogFailedDataRequestEventsOnTable(dataRequest);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
		}
		
		
	}
	
	
}
