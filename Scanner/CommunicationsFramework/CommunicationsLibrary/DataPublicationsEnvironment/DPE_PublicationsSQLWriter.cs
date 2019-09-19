using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.Queueing;
using UtilitiesLibrary.Services.DataStatistics;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment
	{
		
		public class DPE_PublicationsSQLWriter : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private object _locker = new object();
			
			
			private string _dataBaseConnectionString;
			
			private string _publicationName = "";
					
			
			private System.Timers.Timer _dataClearTimer;
			
			
			private const string DEFAULT_DATATYPE_FOR_RESERT_OPERATION = "NO_DATA_TYPE_AVAILABLE";
			private const string DEFAULT_DATAVALUE_FOR_RESERT_OPERATION = "NO_VALUE_AVAILABLE";
			
			private string _dataType = "";
			private string _dataValue = "";
			
			private EventStatisticsHandler _UPDATE_StatisticsHandler;
			private EventStatisticsHandler _RESET_StatisticsHandler;
			
			
			private ThreadPooledProducerConsumerQueue _DATA_RESET_PCQ;
			private ThreadPooledProducerConsumerQueue _DATA_UPDATE_PCQ;
			
			
#endregion
			
#region  < PROPERTIES  >
			
			public int UpdateDataStatistics(string variableName)
			{
				return (int) this._UPDATE_StatisticsHandler.EventCounter(variableName);
			}
			
            public DataTable UpdateDataStatisticsTable
			{
				get
				{
					return this._UPDATE_StatisticsHandler.StatisticsTable;
				}
			}
			
			public int get_ResetDataStatistics(string variableName)
			{
				return (int)this._RESET_StatisticsHandler.EventCounter(variableName);
			}
			
public DataTable ResetDataStatisticsTable
			{
				get
				{
					return this._RESET_StatisticsHandler.StatisticsTable;
				}
			}
			
			
#endregion
			
#region  < COSNTRUCTORS >
			
			public DPE_PublicationsSQLWriter(string publicationsDataBaseConnectionString, string publicationName)
			{
				this._dataBaseConnectionString = publicationsDataBaseConnectionString;
				
				//clears the table every 30 seconds
				this._dataClearTimer = new System.Timers.Timer(60000);
				this._dataClearTimer.Elapsed += this.EventHandling__dataClearTimer_Elapsed;
				this._dataClearTimer.AutoReset = false;
				this._dataClearTimer.Start();
				
				this._publicationName = publicationName;
				
				this._UPDATE_StatisticsHandler = new EventStatisticsHandler();
				this._RESET_StatisticsHandler = new EventStatisticsHandler();
				
				this._DATA_RESET_PCQ = new ThreadPooledProducerConsumerQueue();
				this._DATA_RESET_PCQ.NewItemDetected += this.EventHandling_DATA_RESET_PCQ_NewItemDetected;
				this._DATA_UPDATE_PCQ = new ThreadPooledProducerConsumerQueue();
				this._DATA_UPDATE_PCQ.NewItemDetected += this.EventHandling_DATA_UPDATE_PCQ_NewItemDetected;
				
				
			}
			
#endregion
			
#region  < EVENT HAMDLING >
			
			private void EventHandling__dataClearTimer_Elapsed(System.Object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this._dataClearTimer.Stop();
					this.ClearTable();
				}
				catch (Exception)
				{
				}
				finally
				{
					this._dataClearTimer.Start();
				}
			}
			
			private void EventHandling_DATA_UPDATE_PCQ_NewItemDetected(object item)
			{
				try
				{
					DPE_PublicationData data = (DPE_PublicationData) item;
					this.WriteDataUPDATE(data);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void EventHandling_DATA_RESET_PCQ_NewItemDetected(object item)
			{
				try
				{
					string variableName = System.Convert.ToString(item);
					this.WriteDataRESET(variableName);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			public static string NowToStandardODBCStringFormat(DateTime dateTime)
			{
				
				string timeAsAstring = "";
				timeAsAstring = System.Convert.ToString(System.Convert.ToString(dateTime.Hour) + ":" + System.Convert.ToString(dateTime.Minute) + ":" + System.Convert.ToString(dateTime.Second) + "." + System.Convert.ToString(dateTime.Millisecond));
				
				string dateAsString = "";
				dateAsString = Strings.Format(dateTime, "yyyyMMdd ");
				
				string nowAsStandardODBCString = dateAsString + " " + timeAsAstring;
				
				return nowAsStandardODBCString;
				
			}
			
			private void ClearTable()
			{
				try
				{
					
					lock(this._locker)
					{
						
						using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseConnectionString))
						{
							
							cnn.Open();
							
							using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
							{
								
								cmd.Connection = cnn;
								TimeSpan timespan = new TimeSpan(0, 5, 0);
								DateTime serverDateTime = this.GetPublicationsServerDAtetime();
								DateTime dtFrameLimit = serverDateTime.Subtract(timespan);
								string dtFrameLimitAsString = NowToStandardODBCStringFormat(dtFrameLimit);
								
								cmd.CommandText = "Delete From " + this._publicationName + " where [datetime] <= \'" + dtFrameLimitAsString + "\'";
								try
								{
									cmd.ExecuteNonQuery();
									
								}
								catch (System.Data.SqlClient.SqlException ex1)
								{
									if (ex1.ErrorCode != -2146232060) // the error code reaises when a table dont exists
									{
										string msg = "Error CLEARING old data of publication \'" + this._publicationName + "\' : " + ex1.Message;
										Exception newEX = new Exception(msg);
										throw (newEX);
									}
								}
								catch (Exception ex)
								{
									string msg = "Error CLEARING old data of publication \'" + this._publicationName + "\' : " + ex.Message;
									Exception newEX = new Exception(msg);
									throw (newEX);
								}
								
							}
							
						}
						
						
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
				
			}
			
			private DateTime GetPublicationsServerDAtetime()
			{
				DateTime dtime = DateTime.Now;
				try
				{
					
					lock(this._locker)
					{
						
						using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseConnectionString))
						{
							
							cnn.Open();
							
							using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
							{
								
								cmd.Connection = cnn;
								
								cmd.CommandText = "Select getdate()";
								
								using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter())
								{
									da.SelectCommand = cmd;
									
									using (DataTable dt = new DataTable())
									{
										da.Fill(dt);
										if (dt.Rows.Count > 0)
										{
											dtime = System.Convert.ToDateTime(dt.Rows[0][0]);
										}
										else
										{
											dtime = DateTime.Now;
										}
										
									}
									
								}
								
							}
							
						}
						
						
					}
					
				}
				catch (Exception ex)
				{
					string msg = "Error retrieving server date and time : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
				}
				return dtime;
			}
			
			private void WriteDataUPDATE(DPE_PublicationData data)
			{
				try
				{
					lock(_locker)
					{
						
						using (var cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseConnectionString))
						{
							
							cnn.Open();
							
							using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
							{
								cmd.Connection = cnn;
								
								
								this._dataType = DPE_GlobalDefinitions.GetPublicationValueDataTypeAsString(data.Value);
								this._dataValue = DPE_GlobalDefinitions.GetPublicationValueAsString(data.VariableName, System.Convert.ToInt32(data.Value));
								
								string attributesAsString = "";
								if (data.DataAttributesTable.Count > 0)
								{
									CustomHashTable table = data.DataAttributesTable.ToSTXHashTable();
									attributesAsString = UtilitiesLibrary.Data.XMLDataFormatting.GetValueAsString(data.VariableName, table);
								}
								
								cmd.CommandText = "INSERT into " + this._publicationName + "(dataname,dataType, value, attributesTable , isDataReset)" + 
									"VALUES(\'" + data.VariableName + "\',\'" + this._dataType + "\',\'" + this._dataValue + "\',\'" + attributesAsString + "\',0)";
								try
								{
									cmd.ExecuteNonQuery();
									this._UPDATE_StatisticsHandler.LogEvent(data.VariableName);
								}
								catch (Exception ex)
								{
									string msg = "Error performing UPDATE on \'" + data.VariableName + "\' from publication \'" + this._publicationName + "\': " + ex.Message;
									Exception newEX = new Exception(msg);
									throw (newEX);
								}
								
							} //--------- cmd
							
							
						} //using del sql connection
						
						
					}
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void WriteDataRESET(string variableName)
			{
				try
				{
					lock(_locker)
					{
						
						using (var cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseConnectionString))
						{
							
							cnn.Open();
							//--------------------------------------------------------------
							// DATA RESET OPERATION ON THE PUBLICATION
							//--------------------------------------------------------------
							using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
							{
								cmd.Connection = cnn;
								
								this._dataType = DEFAULT_DATATYPE_FOR_RESERT_OPERATION;
								this._dataValue = DEFAULT_DATAVALUE_FOR_RESERT_OPERATION;
								
								cmd.CommandText = "INSERT into " + this._publicationName + "(dataname,dataType, value,isDataReset)" + 
									"VALUES(\'" + variableName + "\',\'" + this._dataType + "\',\'" + this._dataValue + "\',1)";
								
								try
								{
									cmd.ExecuteNonQuery();
									this._RESET_StatisticsHandler.LogEvent(variableName);
								}
								catch (Exception ex)
								{
									string msg = "Error performing RESET on \'" + variableName + "\' from publication \'" + this._publicationName + "\': " + ex.Message;
									Exception newEX = new Exception(msg);
									throw (newEX);
								}
								
							}
							
							
						} //using del sql connection
						
						
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			
#endregion
			
#region  < PUBLIC METHODS >
			
#region  < DATA UPDATE METHODS >
			
			public void UpdatePublicationVariable(DPE_PublicationData data)
			{
				try
				{
					this._DATA_UPDATE_PCQ.Enqueue(data);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			internal void ResetStatistics(string variableName)
			{
				this._RESET_StatisticsHandler.ResetStatistics(variableName);
				this._UPDATE_StatisticsHandler.ResetStatistics(variableName);
			}
			
#endregion
			
#region  < DATA RESET METHODS >
			
			public void ResetPublicationVariable(string variableName)
			{
				try
				{
					this._DATA_RESET_PCQ.Enqueue(variableName);
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDisposable>
			
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
					}
					
					try
					{
						this.ClearTable();
					}
					catch (Exception)
					{
					}
					
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
#endregion
			
#endregion
			
#region  < SUPPORT CLASS >
			
			private class PublicationUpdateOperationHandler : System.IDisposable
			{
				
				private DPE_GlobalDefinitions.publicationUpdateOperationType _operationType;
				private object _value;
				private string _variableName;
				private bool disposedValue = false; // To detect redundant calls
				
				
				internal PublicationUpdateOperationHandler(string variableName)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataReset;
					this._value = null;
					this._variableName = variableName;
				}
				
				
				internal PublicationUpdateOperationHandler(string variableName, int value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, decimal value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, bool value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, string value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, DataTable value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, DataSet value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, CustomHashTable value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, CustomList value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
				internal PublicationUpdateOperationHandler(string variableName, CustomSortedList value)
				{
					this._operationType = DPE_GlobalDefinitions.publicationUpdateOperationType.dataUpdate;
					this._value = value;
					this._variableName = variableName;
				}
				
public DPE_GlobalDefinitions.publicationUpdateOperationType OperationType
				{
					get
					{
						return this._operationType;
					}
				}
				
public string VariableName
				{
					get
					{
						return this._variableName;
					}
				}
				
public dynamic Value
				{
					get
					{
						return this._value;
					}
				}
				
				
				// IDisposable
				protected virtual void Dispose(bool disposing)
				{
					if (!this.disposedValue)
					{
						if (disposing)
						{
						}
						// TODO: free your own state (unmanaged objects).
						// TODO: set large fields to null.
					}
					this.disposedValue = true;
				}
				
				// This code added by Visual Basic to correctly implement the disposable pattern.
				public void Dispose()
				{
					// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
					Dispose(true);
					GC.SuppressFinalize(this);
				}
				
				
			}
			
			
#endregion
			
		}
		
	}
	
	
}
