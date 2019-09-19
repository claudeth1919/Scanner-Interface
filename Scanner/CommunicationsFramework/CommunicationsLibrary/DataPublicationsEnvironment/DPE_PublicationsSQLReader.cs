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
using UtilitiesLibrary.Parametrization;
using UtilitiesLibrary.Services.DataStatistics;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment
	{
		
		public class DPE_PublicationsSQLReader : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private static Hashtable _SQLreadersSingletonTable = new Hashtable();
			
			
			private string _dataBaseSonnectionString;
			private DateTime _lastReadDatetime;
			private long _lastRowIDReaded;
			private bool _isFirstTimeRead;
			
			private string _tablename = "";
			private bool _keepReading;
			private string _publicationName = "";
			
			private System.Timers.Timer _readTimer;
			
			
			private EventStatisticsHandler _UPDATE_StatisticsHandler;
			private EventStatisticsHandler _RESET_StatisticsHandler;
			
			private string _dataReadCommandTest = "";
			private string dateAsstring = "";
			
			
			private readonly object _locker;
			private ThreadPooledProducerConsumerQueue _DATA_RESET_PCQ;
			private ThreadPooledProducerConsumerQueue _DATA_UPDATE_PCQ;
			
			
			
#endregion
			
#region  < PROPERTIES  >
			
			public int get_DataUpdateStatistics(string variableName)
			{
				return (int)this._UPDATE_StatisticsHandler.EventCounter(variableName);
			}
			
            public DataTable UpdateDataStatisticsTable
			{
				get
				{
					return this._UPDATE_StatisticsHandler.StatisticsTable;
				}
			}
			
			public int DataResetStatistics(string variableName)
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
			
#region  < EVENT >
			
			public delegate void dataUpdateFromPublicationEventHandler(DPE_PublicationData data);
			private dataUpdateFromPublicationEventHandler dataUpdateFromPublicationEvent;
			
			public event dataUpdateFromPublicationEventHandler dataUpdateFromPublication
			{
				add
				{
					dataUpdateFromPublicationEvent = (dataUpdateFromPublicationEventHandler) System.Delegate.Combine(dataUpdateFromPublicationEvent, value);
				}
				remove
				{
					dataUpdateFromPublicationEvent = (dataUpdateFromPublicationEventHandler) System.Delegate.Remove(dataUpdateFromPublicationEvent, value);
				}
			}
			
			public delegate void dataResetFromPublicationEventHandler(string publicationName, string variableName);
			private dataResetFromPublicationEventHandler dataResetFromPublicationEvent;
			
			public event dataResetFromPublicationEventHandler dataResetFromPublication
			{
				add
				{
					dataResetFromPublicationEvent = (dataResetFromPublicationEventHandler) System.Delegate.Combine(dataResetFromPublicationEvent, value);
				}
				remove
				{
					dataResetFromPublicationEvent = (dataResetFromPublicationEventHandler) System.Delegate.Remove(dataResetFromPublicationEvent, value);
				}
			}
			
			
			
#endregion
			
#region  < COSNTRUCTORS >
			
			private DPE_PublicationsSQLReader(string publicationsDataBaseConnectionString, string publicationName)
			{
				
				//gets a connection to the
				this._dataBaseSonnectionString = publicationsDataBaseConnectionString;
				
				
				this._locker = new object();
				this._DATA_RESET_PCQ = new ThreadPooledProducerConsumerQueue();
				this._DATA_RESET_PCQ.NewItemDetected += this.EventHandling_DATA_RESET_PCQ_NewItemDetected;
				this._DATA_UPDATE_PCQ = new ThreadPooledProducerConsumerQueue();
				this._DATA_UPDATE_PCQ.NewItemDetected += this.EventHandling_DATA_UPDATE_PCQ_NewItemDetected;
				
				//creates the reading timer
				this._readTimer = new System.Timers.Timer(1500);
				this._readTimer.Elapsed += this.EventHandling_readTimer_Elapsed;
				this._readTimer.AutoReset = false;
				this._readTimer.Stop();
				
				this._isFirstTimeRead = true;
				this._tablename = publicationName;
				this._keepReading = false;
				this._publicationName = publicationName;
				
				this._UPDATE_StatisticsHandler = new EventStatisticsHandler();
				this._RESET_StatisticsHandler = new EventStatisticsHandler();
				
				this._dataReadCommandTest = "";
				this._lastRowIDReaded = -1; //initialization
				
			}
			
#endregion
			
#region  < EVENT HAMDLING >
			
			private void EventHandling_readTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				
				//*****************************************************************************
				// STOPS THE TIMER
				//*****************************************************************************
				this._readTimer.Stop();
				
				try
				{
					
					if (this._isFirstTimeRead)
					{
						//retrieves the server datetime to retrieve the data using datetime
						this._lastReadDatetime = this.GetPublicationsServerDAtetime();
						this.dateAsstring = NowToStandardODBCStringFormat(this._lastReadDatetime);
						this._dataReadCommandTest = "Select * from " + this._tablename + " where datetime >= \'" + dateAsstring + "\' order by [datetime] asc";
						this._isFirstTimeRead = false;
					}
					else
					{
						if (this._lastRowIDReaded > 0)
						{
							//uses the row id as to retrieve new data
							this._dataReadCommandTest = "Select * from " + this._tablename + " where rowID > " + System.Convert.ToString(this._lastRowIDReaded) + " order by [rowID] asc";
						}
						else
						{
							//uses the datetime as to retrieve new data
							this.dateAsstring = NowToStandardODBCStringFormat(this._lastReadDatetime);
							this._dataReadCommandTest = "Select * from " + this._tablename + " where datetime >= \'" + dateAsstring + "\' order by [datetime] asc";
						}
						
					}
					
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseSonnectionString))
					{
						try
						{
							cnn.Open();
							
							
							using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
							{
								cmd.Connection = cnn;
								
								//************************************************************
								//PREPARES THE QUERY TO THE PUBLICATION
								//************************************************************
								
								cmd.CommandText = this._dataReadCommandTest;
								
								using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter())
								{
									da.SelectCommand = cmd;
									
									
									using (DataTable dt = new DataTable())
									{
										//******************************************
										// RETRIEVS THE DATA FROM DATA SOURCE
										da.Fill(dt);
										//******************************************
										
										
										//************************************************************
										//DATA TREATMENT
										if (dt.Rows.Count > 0)
										{
											
											DataRow row = default(DataRow);
											IEnumerator enumm = dt.Rows.GetEnumerator();
											while (enumm.MoveNext())
											{
												row = (DataRow )enumm.Current;
												
												//*****************************************************
												// transfors the row into a data update or data reset
												//*****************************************************
												try
												{
													
													long _rowID;
													string _dataType = "";
													string _value = "";
													string _dataName = "";
													DateTime _dataDatetime = System.Convert.ToDateTime(null);
													bool _isDataReset = false;
													string _attributesTAble = "";
													
													
													_rowID = (long) (row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_ROWID]);
													_dataType = System.Convert.ToString(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_DATA_TYPE]);
													_value = System.Convert.ToString(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_VALUE]);
													_dataName = System.Convert.ToString(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_DATA_NAME]);
													_attributesTAble = System.Convert.ToString(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_ATTRIBUTES_TABLE]);
													
													try
													{
														_dataDatetime = System.Convert.ToDateTime(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_DATA_DATETIME]);
													}
													catch (Exception)
													{
														_dataDatetime = DateTime.Now;
													}
													_isDataReset = System.Convert.ToBoolean(row[DPE_GlobalDefinitions.DPE_PUBLICATION_TABLE_DEFINITION_IS_DATA_RESET]);
													
													
													//------------------------------------------------
													
													if (!_isDataReset)
													{
														DPE_PublicationData data = default(DPE_PublicationData);
														data = DPE_GlobalDefinitions.GetPublicationValueFromString(this._publicationName, _dataName, _dataType, _value);
														
														
														AttributesTable attrTAble = default(AttributesTable);
														//------------------------------------------------
														//verifies if there are a parameters table
														if (_attributesTAble.Length > 0)
														{
															DataVariable dataVar = XMLDataFormatting.RetrieveDataVariableFromXMLString(_attributesTAble);
															CustomHashTable table = (CustomHashTable) dataVar.Data;
															attrTAble = new AttributesTable(table);
															data.AttachAttibutesTable(attrTAble);
														}
														
														this._DATA_UPDATE_PCQ.Enqueue(data);
														
													}
													else
													{
														
														this._DATA_RESET_PCQ.Enqueue(_dataName);
														
													}
												}
												catch (Exception ex)
												{
													CustomEventLog.WriteEntry(ex);
												}
												
											}
											
										}
										//************************************************************
										
										
										//************************************************************
										//GETS THE LAST TABLE REFERENCE DATE TIME and ROWid FROM THE DATA IF IS AVAILABLE
										try
										{
											if (dt.Rows.Count > 0)
											{
												this.SetLastReadDateTiemeAndRowID(dt);
											}
										}
										catch (Exception)
										{
										}
										//************************************************************
										
									} //----------- data table
									
									
								} //-------- SqlDataAdapter
								
								
								
							} //-------- SqlCommand
							
							
						}
						catch (System.Data.SqlClient.SqlException sqlex)
						{
							//overrides the error qhen
							if (sqlex.ErrorCode != -2146232060)
							{
								CustomEventLog.WriteEntry(sqlex);
							}
						}
						catch (Exception ex)
						{
							CustomEventLog.DisplayEvent(EventLogEntryType.Error, ex.ToString());
						}
						finally
						{
							
							if (this._keepReading)
							{
								this._readTimer.Start();
							}
							
							try
							{
								cnn.Close();
								cnn.Dispose();
							}
							catch (Exception)
							{
							}
							
						}
						
					} //-------  sqlConnection
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.DisplayEvent(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
			private void EventHandling_DATA_UPDATE_PCQ_NewItemDetected(object item)
			{
				try
				{
					lock(this._locker)
					{
						
						DPE_PublicationData data = (DPE_PublicationData) item;
						try
						{
							this._UPDATE_StatisticsHandler.LogEvent(data.VariableName);
						}
						catch (Exception)
						{
						}
						
						try
						{
							if (dataUpdateFromPublicationEvent != null)
								dataUpdateFromPublicationEvent(data);
						}
						catch (Exception)
						{
						}
						
					}
					
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
					
					lock(this._locker)
					{
						
						string _dataName = System.Convert.ToString(item);
						
						try
						{
							this._RESET_StatisticsHandler.LogEvent(_dataName);
						}
						catch (Exception)
						{
						}
						
						try
						{
							if (dataResetFromPublicationEvent != null)
								dataResetFromPublicationEvent(this._publicationName, _dataName);
						}
						catch (Exception)
						{
						}
						
					}
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private DateTime GetPublicationsServerDAtetime()
			{
				DateTime dtime = default(DateTime);
				bool dateObtained = false;
				
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this._dataBaseSonnectionString))
					{
						
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							
							cmd.Connection = cnn;
							
							using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
							{
								
								using (DataTable dt = new DataTable())
								{
									
									//selects a datetime as to use as reference to retrieve data
									while (!dateObtained)
									{
										
										try
										{
											//using the server current datetime
											cmd.CommandText = "Select getdate()";
											da.Fill(dt);
											if (dt.Rows.Count > 0)
											{
												dtime = System.Convert.ToDateTime(dt.Rows[0][0]);
												dateObtained = true;
											}
										}
										catch (Exception)
										{
											//if retrieving the server datetime fails then tries to use the las datetime
											//of the current data on the table
											try
											{
												cmd.CommandText = "select max([datetime]) from " + this._tablename;
												dtime = System.Convert.ToDateTime(cmd.ExecuteScalar());
												dateObtained = true;
											}
											catch (Exception)
											{
											}
										}
										
									}
									try
									{
										dt.Dispose();
									}
									catch (Exception)
									{
									}
									
								} //datatable
								
								
								
								try
								{
									da.Dispose();
								}
								catch (Exception)
								{
								}
								
							} //SqlDataAdapter
							
							
						} //SqlCommand
						
						
						try
						{
							cnn.Close();
							cnn.Dispose();
						}
						catch (Exception)
						{
						}
						
					} //SqlConnection
					
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.DisplayEvent(EventLogEntryType.Error, ex.ToString());
				}
				
				return dtime;
				
			}
			
			public static string NowToStandardODBCStringFormat(DateTime dateTime)
			{
				
				string timeAsAstring = "";
				timeAsAstring = System.Convert.ToString(System.Convert.ToString(dateTime.Hour) + ":" + System.Convert.ToString(dateTime.Minute) + ":" + System.Convert.ToString(dateTime.Second) + "." + System.Convert.ToString(dateTime.Millisecond));
				
				string dateAsString = "";
				dateAsString = Strings.Format(dateTime, "yyyyMMdd ");
				
				string nowAsStandardODBCString = dateAsString + " " + timeAsAstring;
				
				
				return nowAsStandardODBCString;
				
			}
			
			private void SetLastReadDateTiemeAndRowID(DataTable data)
			{
				this._lastReadDatetime = System.Convert.ToDateTime(data.Rows[data.Rows.Count - 1]["datetime"]);
				this._lastRowIDReaded = (long) (data.Rows[data.Rows.Count - 1]["rowID"]);
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void StartReading()
			{
				this._isFirstTimeRead = true;
				this._lastRowIDReaded = -1;
				this._keepReading = true;
				this._readTimer.Start();
			}
			
			public void StopReading()
			{
				this._isFirstTimeRead = true;
				this._keepReading = false;
				this._readTimer.Stop();
			}
			
			internal void ResetStatistics(string variableName)
			{
				this._RESET_StatisticsHandler.ResetStatistics(variableName);
				this._UPDATE_StatisticsHandler.ResetStatistics(variableName);
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			public static DPE_PublicationsSQLReader GetReader(string publicationsDataBaseConnectionString, string publicationName)
			{
				try
				{
					
					if (_SQLreadersSingletonTable.ContainsKey(publicationName))
					{
						Hashtable pubTable = (Hashtable) (_SQLreadersSingletonTable[publicationName]);
						
						if (pubTable.ContainsKey(publicationsDataBaseConnectionString))
						{
							DPE_PublicationsSQLReader reader = null;
                            reader = (DPE_PublicationsSQLReader)pubTable[publicationsDataBaseConnectionString];
							return reader;
						}
						else
						{
							DPE_PublicationsSQLReader reader = new DPE_PublicationsSQLReader(publicationsDataBaseConnectionString, publicationName);
							pubTable.Add(publicationsDataBaseConnectionString, publicationsDataBaseConnectionString);
							return reader;
						}
					}
					else
					{
						
						Hashtable table = new Hashtable();
						DPE_PublicationsSQLReader reader = new DPE_PublicationsSQLReader(publicationsDataBaseConnectionString, publicationName);
						
						table.Add(publicationsDataBaseConnectionString, reader);
						
						_SQLreadersSingletonTable.Add(publicationName, table);
						
						return reader;
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
					return null;
				}
			}
			
			
			
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
						this.StopReading();
					}
					catch (Exception)
					{
					}
					
					try
					{
						if (_SQLreadersSingletonTable.ContainsKey(this._publicationName))
						{
							_SQLreadersSingletonTable.Remove(this._publicationName);
						}
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
			
			
			
			
		}
		
	}
	
	
}
