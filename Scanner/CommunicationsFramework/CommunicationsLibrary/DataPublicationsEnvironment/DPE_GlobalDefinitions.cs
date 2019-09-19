using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Configuration;
using UtilitiesLibrary.Configuration.Data;
using UtilitiesLibrary.EventLoging;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment
	{
		
		public sealed class DPE_GlobalDefinitions
		{
			
			public enum publicationUpdateOperationType
			{
				dataUpdate,
				dataReset
			}
			
			public const string DPE_DEFAULT_PUBLICATIONS_GROUP = "DEFAULT";
			
			public const string DPE_PUBLICATIONS_DATABASE_NAME = "DPE_PUBLICATIONS";
			public const string DPE_PUBLICATIONS_DATABASE_USERNAME = "sa";
			public const string DPE_PUBLICATIONS_DATABASE_USERPASSWORD = "SVMET1004hexSIFCDB";
            public const string DPE_PUBLICATIONS_DATABASE_SERVERNAME = "LOCALHOST";
			
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_NAME = "publicationName";
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_CREATION_STORED_PROCEDURE_NAME = "usp_DPE_Publication_PublicationCreation";
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_DISPOSE_STORED_PROCEDURE_NAME = "usp_DPE_Publication_PublicationDispose";
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_CONSULT_STORED_PROCEDURE_NAME = "usp_DPE_Publication_Statistics";
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_RESET_STORED_PROCEDURE_NAME = "usp_DPE_Publication_StatisticsReset";
			public const string DPE_PUBLICATIONS_DATABASE_PUBLICATION_DATA_UPDATE_STORED_PROCEDURE_NAME = "usp_DPE_Publication_DataUpdate";
			
			
			internal const string DPE_PUBLICATIONS_PROXY_DATABASE_NAME = "DPE_PROXY_PUBLICATIONS";
			internal const string DPE_PUBLICATIONS_PROXY_DATABASE_USERNAME = "sa";
			internal const string DPE_PUBLICATIONS_PROXY_DATABASE_USERPASSWORD = "SVMET1004hexSIFCDB";
			
			internal const string DPE_PUBLICATIONS_DATABASE_MASTER_DB = "master";
			
			
#region  < CONSTANTS THAT DEFINES A PUBLICATION TABLE FILED >
			
			public const string DPE_PUBLICATION_TABLE_DEFINITION_ROWID = "rowID";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_DATA_DATETIME = "datetime";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_DATA_NAME = "dataname";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_DATA_TYPE = "dataType";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_VALUE = "value";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_ATTRIBUTES_TABLE = "attributesTable";
			public const string DPE_PUBLICATION_TABLE_DEFINITION_IS_DATA_RESET = "isDataReset";
			
#endregion
			
#region  < DATA TRANSFPORMATION GLOBAL METHODS >
			
			internal const string INVALID_DATA_TYPE = "INVALID_DATA_TYPE";
			
			internal static string GetPublicationValueDataTypeAsString(object value)
			{
				string type = value.GetType().ToString();
				switch (type)
				{
					case "System.String":
					case "System.Int32":
					case "System.Decimal":
					case "System.Boolean":
					case "System.Data.DataTable":
					case "System.Data.DataSet":
					case "UtilitiesLibrary.Data.CustomHashTable":
					case "UtilitiesLibrary.Data.CustomList":
			    	case "UtilitiesLibrary.Data.CustomSortedList":
						return value.GetType().ToString();
					default:
						return INVALID_DATA_TYPE;
				}
				
			}
			
#region  < TRANSFORMATION FROM STRING TO DATA >
			
			public static DPE_PublicationData GetPublicationValueFromString(string publicationName, string variableName, string dataTypeAsString, string value)
			{
				
				switch (dataTypeAsString)
				{
					case "System.Int32":
						int realValue_1 = System.Convert.ToInt32(value);
						DPE_PublicationData data_1 = new DPE_PublicationData(publicationName, variableName, realValue_1);
						return data_1;
					case "System.Decimal":
						decimal realValue_2 = System.Convert.ToDecimal(value);
						DPE_PublicationData data_2 = new DPE_PublicationData(publicationName, variableName, realValue_2);
						return data_2;
					case "System.Boolean":
						bool realValue_3 = System.Convert.ToBoolean(value);
						DPE_PublicationData data_3 = new DPE_PublicationData(publicationName, variableName, realValue_3);
						return data_3;
					case "System.String":
						string realValue_4 = System.Convert.ToString(value);
						DPE_PublicationData data_4 = new DPE_PublicationData(publicationName, variableName, realValue_4);
						return data_4;
					case "System.Data.DataTable":
						DataVariable temporalValue_1 = XMLDataFormatting.RetrieveDataVariableFromXMLString(value);
						DataTable realValue_5 = (System.Data.DataTable) temporalValue_1.Data;
						DPE_PublicationData data_5 = new DPE_PublicationData(publicationName, variableName, realValue_5);
						return data_5;
					case "System.Data.DataSet":
						DataVariable temporalValue_2 = XMLDataFormatting.RetrieveDataVariableFromXMLString(value);
						DataSet realValue_6 = (DataSet) temporalValue_2.Data;
						DPE_PublicationData data_6 = new DPE_PublicationData(publicationName, variableName, realValue_6);
						return data_6;
					case "UtilitiesLibrary.Data.CustomHashTable":
						DataVariable temporalValue_3 = XMLDataFormatting.RetrieveDataVariableFromXMLString(value);
						CustomHashTable realValue_7 = (CustomHashTable) temporalValue_3.Data;
						DPE_PublicationData data_7 = new DPE_PublicationData(publicationName, variableName, realValue_7);
						return data_7;
					case "UtilitiesLibrary.Data.CustomList":
						DataVariable temporalValue_4 = XMLDataFormatting.RetrieveDataVariableFromXMLString(value);
						CustomList realValue_8 = (CustomList) temporalValue_4.Data;
						DPE_PublicationData data_8 = new DPE_PublicationData(publicationName, variableName, realValue_8);
						return data_8;
					case "UtilitiesLibrary.Data.CustomSortedList":
						DataVariable temporalValue = XMLDataFormatting.RetrieveDataVariableFromXMLString(value);
						CustomSortedList realValue = (CustomSortedList) temporalValue.Data;
						DPE_PublicationData data = new DPE_PublicationData(publicationName, variableName, realValue);
						return data;
					default:
						throw (new Exception("Unsupported data type \'" + dataTypeAsString + "\' for publication Data"));
				}
				
			}
			
#endregion
			
#region  <TRANSFORMATION FROM DATA TO STRING  >
			
			public static string GetPublicationValueAsString(string variableName, int value)
			{
				return System.Convert.ToString(value);
			}
			
			public static string GetPublicationValueAsString(string variableName, decimal value)
			{
				return System.Convert.ToString(value);
			}
			
			public static string GetPublicationValueAsString(string variableName, bool value)
			{
				return System.Convert.ToString(value);
			}
			
			public static string GetPublicationValueAsString(string variableName, string value)
			{
				return System.Convert.ToString(value);
			}
			
			public static string GetPublicationValueAsString(string variableName, DataTable value)
			{
				string table = XMLDataFormatting.GetDataVariableXMLString(variableName, value);
				return table;
			}
			
			public static string GetPublicationValueAsString(string variableName, DataSet value)
			{
				string data = XMLDataFormatting.GetDataVariableXMLString(variableName, value);
				return data;
			}
			
			public static dynamic GetPublicationValueAsString(string variableName, CustomHashTable value)
			{
				string data = UtilitiesLibrary.Data.XMLDataFormatting.GetDataVariableXMLString(variableName, value);
				return data;
			}
			
			public static dynamic GetPublicationValueAsString(string variableName, CustomList value)
			{
				string data = UtilitiesLibrary.Data.XMLDataFormatting.GetDataVariableXMLString(variableName, value);
				return data;
			}
			
			public static dynamic GetPublicationValueAsString(string variableName, CustomSortedList value)
			{
				string data = UtilitiesLibrary.Data.XMLDataFormatting.GetDataVariableXMLString(variableName, value);
				return data;
			}
			
#endregion
			
#endregion
			
			internal static bool ISSQLServerInstalledAndRunning(string hostName)
			{
				string cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_MASTER_DB);
				bool result = false;
				using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnString))
				{
					try
					{
						cnn.Open();
						result = true;
					}
					catch (Exception)
					{
						result = false;
					}
				}
				
				return result;
			}
			
			internal static string Get_DPE_ServicePublicationsDBConnectionString(string InitialCatalog)
			{
				
				string cnnString = "";
                string serverName = "";
				string user = "";
				string password = "";
				KeyValue configurationKey = default(KeyValue);
				
				try
				{
					ConfigurationFileHandler configFile = default(ConfigurationFileHandler);
					configFile = ConfigurationFileHandlerProxyServer.GetInstance().GetFileHandler();
					
					if (configFile == null)
					{
						throw (new Exception("No configuration File available"));
					}

                    //***************************************************************************************
                    //gets the server name
                    //***************************************************************************************

                    configurationKey = (KeyValue)(configFile.GetValue("DATA PUBLICATIONS SERVICE/DATA SOURCE/SERVER NAME"));

                    if (!(configurationKey == null))
                    {
                        serverName = configurationKey.Value;
                    }
                    else
                    {
                        string message = "";
                        message = "Not connection string defined for PRODUCTION DATA BASE, Or not configuration Exists in Route : DATA PUBLICATIONS SERVICE/DATA SOURCE/SERVER NAME";
                        CustomEventLog.WriteEntry(EventLogEntryType.Warning, message);
                        serverName = DPE_PUBLICATIONS_DATABASE_SERVERNAME;
                    }


					
					//***************************************************************************************
					//gets the user
					//***************************************************************************************
					configurationKey = (KeyValue) (configFile.GetValue("DATA PUBLICATIONS SERVICE/DATA SOURCE/USER"));
					
					if (!(configurationKey == null))
					{
						user = configurationKey.Value;
					}
					else
					{
						string message = "";
						message = "Not connection string defined for PRODUCTION DATA BASE, Or not configuration Exists in Route : DATA PUBLICATIONS SERVICE/DATA SOURCE/USER";
						CustomEventLog.WriteEntry(EventLogEntryType.Warning, message);
						user = DPE_PUBLICATIONS_DATABASE_USERNAME;
					}
					
					//***************************************************************************************
					//gets the PASSWORD
					//***************************************************************************************
					
					configurationKey = (KeyValue) (configFile.GetValue("DATA PUBLICATIONS SERVICE/DATA SOURCE/PASSWORD"));
					
					if (!(configurationKey == null))
					{
						password = configurationKey.Value;
					}
					else
					{
						string message = "";
						message = "Not connection string defined for PRODUCTION DATA BASE, Or not configuration Exists in Route : DATA PUBLICATIONS SERVICE/DATA SOURCE/PASSWORD";
						CustomEventLog.WriteEntry(EventLogEntryType.Warning, message);
						
						password = DPE_PUBLICATIONS_DATABASE_USERPASSWORD;
					}
					
				}
				catch (Exception)
				{
					user = DPE_PUBLICATIONS_DATABASE_USERNAME;
					password = DPE_PUBLICATIONS_DATABASE_USERPASSWORD;
				}
                cnnString = "DATA SOURCE=" + serverName + " ;USER ID=" + user + ";PWD=" + password + ";INITIAL CATALOG=" + InitialCatalog + "";
				return cnnString;
			}
			
#region  < PUBLICATION DATA BASES MANAGEMENT >
			
			internal static void Create_MAIN_DPE_SERVER_PublicationsDataBaseIfNotExists(string hostName)
			{
				string cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_MASTER_DB);
				try
				{
					
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							
							try
							{
								//****************************************************************************************
								//DROPS PREVIOUS DATABASE
								//****************************************************************************************
								cmd.Connection = cnn;
								
								try
								{
									cmd.CommandText = "ALTER DATABASE " + DPE_PUBLICATIONS_DATABASE_NAME + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
									cmd.ExecuteNonQuery();
								}
								catch (Exception)
								{
								}
								try
								{
									cmd.CommandText = "DROP database " + DPE_PUBLICATIONS_DATABASE_NAME;
									cmd.ExecuteNonQuery();
								}
								catch (Exception)
								{
								}
							}
							catch (Exception)
							{
							}
							
							try
							{
								//****************************************************************************************
								//creates the data base in the server
								//****************************************************************************************
								cmd.Connection = cnn;
								cmd.CommandText = "if not exists ( select [name] from sysdatabases where [name] = \'" + DPE_PUBLICATIONS_DATABASE_NAME + "\') create database " + DPE_PUBLICATIONS_DATABASE_NAME;
								cmd.ExecuteNonQuery();
								
								CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "DPE Server Publications Media CREATED Succesfully.");
								
								cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_NAME);
								//****************************************************************************************
								//creates the stored procedure that creates and disposes the data publication in the data base
								//****************************************************************************************
								CreatePublication_CREATION_StoredProcedure(cnnString);
								CreatePublication_DISPOSING_StoredProcedure(cnnString);
								CreatePublication_STATISTICS_StoredProcedure(cnnString);
								CreatePublication_STATISTICS_RESET_StoredProcedure(cnnString);
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
							
						}
						
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			internal static void Create_DPE_PROXY_ServerPublicationsDataBaseIfNotExists(string hostName)
			{
				
				string cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_MASTER_DB);
				
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnString))
					{
						
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							
							try
							{
								//****************************************************************************************
								//DROPS PREVIOUS DATABASE
								//****************************************************************************************
								cmd.Connection = cnn;
								
								try
								{
									cmd.CommandText = "ALTER DATABASE " + DPE_PUBLICATIONS_PROXY_DATABASE_NAME + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
									cmd.ExecuteNonQuery();
								}
								catch (Exception)
								{
								}
								try
								{
									cmd.CommandText = "DROP database " + DPE_PUBLICATIONS_PROXY_DATABASE_NAME;
									cmd.ExecuteNonQuery();
									
								}
								catch (Exception)
								{
								}
							}
							catch (Exception)
							{
							}
							
							try
							{
								//****************************************************************************************
								//creates the data base in the server
								//****************************************************************************************
								cmd.Connection = cnn;
								cmd.CommandText = "if not exists ( select [name] from sysdatabases where [name] = \'" + DPE_PUBLICATIONS_PROXY_DATABASE_NAME + "\') create database " + DPE_PUBLICATIONS_PROXY_DATABASE_NAME;
								cmd.ExecuteNonQuery();
								
								CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "DPE PROXY Server Publications Media CREATED Succesfully.");
								
								cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_PROXY_DATABASE_NAME);
								//****************************************************************************************
								//creates the stored procedure that creates and disposes the data publication in the data base
								//****************************************************************************************
								CreatePublication_CREATION_StoredProcedure(cnnString);
								CreatePublication_DISPOSING_StoredProcedure(cnnString);
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
							
						}
						
						
					}
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
				
			}
			
			internal static void DISPOSE_MAIN_DPE_SERVER_PublicationsDataBase()
			{
				
				string cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_MASTER_DB);
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnString))
					{
						
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							try
							{
								//****************************************************************************************
								//DROPS DATABASE
								//****************************************************************************************
								cmd.Connection = cnn;
								
								try
								{
									cmd.CommandText = "ALTER DATABASE " + DPE_PUBLICATIONS_DATABASE_NAME + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
									cmd.ExecuteNonQuery();
								}
								catch (Exception)
								{
								}
								try
								{
									cmd.CommandText = "DROP database " + DPE_PUBLICATIONS_DATABASE_NAME;
									cmd.ExecuteNonQuery();
									
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "DPE Server Publications Media DISPOSED Succesfully.");
									
								}
								catch (Exception)
								{
								}
								
							}
							catch (Exception)
							{
								
							}
						}
						
						
					}
					
					
				}
				catch (Exception)
				{
				}
				
			}
			
			internal static void DISPOSE_DPE_PROXY_PublicationsDataBase()
			{
				
				string cnnString = Get_DPE_ServicePublicationsDBConnectionString(DPE_PUBLICATIONS_DATABASE_MASTER_DB);
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnString))
					{
						
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							try
							{
								//****************************************************************************************
								//DROPS DATABASE
								//****************************************************************************************
								cmd.Connection = cnn;
								
								try
								{
									cmd.CommandText = "ALTER DATABASE " + DPE_PUBLICATIONS_PROXY_DATABASE_NAME + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
									cmd.ExecuteNonQuery();
								}
								catch (Exception)
								{
								}
								try
								{
									cmd.CommandText = "DROP database " + DPE_PUBLICATIONS_PROXY_DATABASE_NAME;
									cmd.ExecuteNonQuery();
									
									
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, "DPE PROXY Server Publications Media DISPOSED Succesfully.");
									
								}
								catch (Exception)
								{
								}
								
							}
							catch (Exception)
							{
								
							}
						}
						
						
					}
					
					
				}
				catch (Exception)
				{
				}
				
			}
			
#endregion
			
#region  <  STORED PROCEDURES CREATION >
			
			public static void CreatePublication_CREATION_StoredProcedure(string connectionString)
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(connectionString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							//****************************************************************************************
							//drops the stored procedure
							//****************************************************************************************
							try
							{
								cmd.CommandText = " DROP PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_CREATION_STORED_PROCEDURE_NAME;
								cmd.ExecuteNonQuery();
							}
							catch (Exception)
							{
							}
							
							try
							{
								
								cmd.CommandText = "CREATE PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_CREATION_STORED_PROCEDURE_NAME + Constants.vbNewLine + 
                                  "@publicationName	VARCHAR(500)" + Constants.vbNewLine + 
                                  "AS " + Constants.vbNewLine + 
                                  " " + Constants.vbNewLine + 
                                  "SET NOCOUNT ON  " + Constants.vbNewLine + 
                                  " " + Constants.vbNewLine + 
                                  "DECLARE @SQLSentence  	NVARCHAR(3000) " + Constants.vbNewLine + 
                                  "DECLARE @indexName 	NVARCHAR(500) " + Constants.vbNewLine + 
                                  " " + Constants.vbNewLine + 
                                  "SET @publicationName = upper(@publicationName) " + Constants.vbNewLine + 
                                  "--verifies if the location table exists , if not creates it  " + Constants.vbNewLine + 
                                  " " + Constants.vbNewLine + 
                                  "if EXISTS " + Constants.vbNewLine + 
                                  "( " + Constants.vbNewLine + 
                                  "	SELECT 	name  " + Constants.vbNewLine + 
                                  "	FROM   	sysobjects  " + Constants.vbNewLine + 
                                  "	WHERE 	name = @publicationName " + Constants.vbNewLine + 
                                  "		AND 	  type = \'U\' " + Constants.vbNewLine + 
                                  ") " + Constants.vbNewLine + 
                                  "BEGIN  " + Constants.vbNewLine + 
                                  "	SET @SQLSentence = \'DROP TABLE \' + @publicationName  " + Constants.vbNewLine + 
                                  "	exec sp_executesql @SQLSentence  " + Constants.vbNewLine + 
                                  "END  " + Constants.vbNewLine + 
                                  "		 " + Constants.vbNewLine + 
                                  "SET @SQLSentence = \'  " + Constants.vbNewLine + 
                                  "CREATE TABLE \' + @publicationName + \' " + Constants.vbNewLine + 
                                  "( " + Constants.vbNewLine + "	rowID		        bigint  " + Constants.vbNewLine + "                       identity(1,1) ," + Constants.vbNewLine + 
                                  "	datetime	        datetime  " + Constants.vbNewLine + "			            default GETDATE() NOT NULL, " + Constants.vbNewLine + "	dataname	        varchar(500)  " + Constants.vbNewLine + "			            not null, " + Constants.vbNewLine + "	dataType	        varchar(50)  " + Constants.vbNewLine + "			            not null, " + Constants.vbNewLine + "	value		        varchar(8000)  " + Constants.vbNewLine + "			            not null, " + Constants.vbNewLine + "   attributesTable     varchar(8000) default \'\'\'\'" + Constants.vbNewLine + "                       not null ,"
								+ Constants.vbNewLine + "	isDataReset	bit	 " + Constants.vbNewLine + "			            default 0 " + Constants.vbNewLine + ")\' " + Constants.vbNewLine + "--creates the table executoing the sql sentence  " + Constants.vbNewLine + "exec sp_executesql @SQLSentence  " + Constants.vbNewLine + "SET @indexName = \'id_\' + @publicationName + \'_datetime\' " + Constants.vbNewLine + "SET @SQLSentence = \'CREATE INDEX \' + @indexName + \' " + Constants.vbNewLine + "					ON  \' + @publicationName + \'(datetime)\' " + Constants.vbNewLine + "exec sp_executesql @SQLSentence  " + Constants.vbNewLine + " " + Constants.vbNewLine + "SET @indexName = \'id_\' + @publicationName + \'_rowID\' " + Constants.vbNewLine + "SET @SQLSentence = \'CREATE INDEX \' + @indexName + \' " + Constants.vbNewLine + "					ON  \' + @publicationName + \'(rowID)\' " + Constants.vbNewLine + "exec sp_executesql @SQLSentence  " + Constants.vbNewLine + "DECLARE @publicationStatsTableName  NVARCHAR(1000)" + Constants.vbNewLine + "SET @publicationStatsTableName = @publicationName + \'_STATISTICS\' " + Constants.vbNewLine + "SET @SQLSentence = \'  " + Constants.vbNewLine + "if EXISTS " + Constants.vbNewLine + "( " + Constants.vbNewLine + "	SELECT 	name  " + Constants.vbNewLine + "	FROM   	sysobjects  " + Constants.vbNewLine + "	WHERE 	name = \'\'\' + @publicationStatsTableName + \'\'\'" + Constants.vbNewLine + "		AND 	  type = \'\'U\'\' " + Constants.vbNewLine + ") " + Constants.vbNewLine + "BEGIN  " + Constants.vbNewLine + "	DROP TABLE \' + @publicationName + \'_STATISTICS " + Constants.vbNewLine + "END\'  " + Constants.vbNewLine + "exec sp_executesql @SQLSentence  " + Constants.vbNewLine + "		 " + Constants.vbNewLine + "SET @SQLSentence = \'  " + Constants.vbNewLine + "CREATE TABLE \' + @publicationName + \'_STATISTICS " + Constants.vbNewLine + "( " + Constants.vbNewLine + "	dataname	            varchar(500)  " + Constants.vbNewLine + "			                not null " + Constants.vbNewLine + "                           primary key clustered ,  "
								+ Constants.vbNewLine + "   firstUPDATEDateTime     datetime    ," + Constants.vbNewLine + "   LastUPDATEDateTime      datetime    ," + Constants.vbNewLine + "   UPDATESCount            bigint      ," + Constants.vbNewLine + "   firstRESETDateTime      datetime    ," + Constants.vbNewLine + "   lastRESETDateTime       datetime    ," + Constants.vbNewLine + "   RESETSCount             bigInt      " + Constants.vbNewLine + ")\'" + Constants.vbNewLine + "exec sp_executesql @SQLSentence " + Constants.vbNewLine + "SET @SQLSentence = \'  " + Constants.vbNewLine + "CREATE TRIGGER  trigger_\' + @publicationName + \' ON \' +  @publicationName  + \' " + Constants.vbNewLine + "after INSERT " + Constants.vbNewLine + "AS " + Constants.vbNewLine + "BEGIN " + Constants.vbNewLine + "SET NOCOUNT ON   " + Constants.vbNewLine + "begin transaction " + Constants.vbNewLine + "	DECLARE @maxID bigint  " + Constants.vbNewLine + "	DECLARE @isDataReset bit  " + Constants.vbNewLine + "	DECLARE @dataname varchar(500) " + Constants.vbNewLine + "	DECLARE @isReset bit  " + Constants.vbNewLine + "	DECLARE @currentCount bigint	 " + Constants.vbNewLine + "	DECLARE	@newCount	bigint  " + Constants.vbNewLine + "	SELECT * INTO #temporalINSERTED FROM inserted" + Constants.vbNewLine + "   " + Constants.vbNewLine + "   DECLARE  statCur cursor for " + Constants.vbNewLine + "   Select rowID " + Constants.vbNewLine + "   FROM #temporalINSERTED " + Constants.vbNewLine + "	 " + Constants.vbNewLine + "   OPEN statCur " + Constants.vbNewLine + "   fetch next from statCur into @maxID " + Constants.vbNewLine + "	while @@fetch_status = 0 " + Constants.vbNewLine + "   begin " + Constants.vbNewLine + "	    select	@dataname = dataname,  " + Constants.vbNewLine + "	    		@isReset = isDataReset  " + Constants.vbNewLine + "	    from	\' + @publicationName + \'  " + Constants.vbNewLine + "	    where	rowID = @maxID  " + Constants.vbNewLine + "		     " + Constants.vbNewLine + "	    if not exists  " + Constants.vbNewLine + "	    ( "
								+ Constants.vbNewLine + "		    select	dataname " + Constants.vbNewLine + "		    from	\' + @publicationName + \'_STATISTICS " + Constants.vbNewLine + "		    where	dataname  = @dataname " + Constants.vbNewLine + "	    ) " + Constants.vbNewLine + "	    begin " + Constants.vbNewLine + "           insert into \' + @publicationName + \'_STATISTICS  (dataname , UPDATESCount , RESETSCount) values(@dataname,0,0) " + Constants.vbNewLine + "	    end  " + Constants.vbNewLine + "		if @isReset = 0 " + Constants.vbNewLine + "		begin  " + Constants.vbNewLine + "		    select  @currentCount = UPDATESCount   " + Constants.vbNewLine + "		    from	\' + @publicationName + \'_STATISTICS   " + Constants.vbNewLine + "		    where	dataname  = @dataname   " + Constants.vbNewLine + "		     " + Constants.vbNewLine + "		    IF @currentCount = 0   " + Constants.vbNewLine + "		   	BEGIN " + Constants.vbNewLine + "		   		set @newCount = 1   " + Constants.vbNewLine + "		    	 " + Constants.vbNewLine + "			    update	\' + @publicationName + \'_STATISTICS    " + Constants.vbNewLine + "			    set		UPDATESCount = @newCount  , " + Constants.vbNewLine + "			    		firstUPDATEDateTime = GETDATE()  , " + Constants.vbNewLine + "			    		LastUPDATEDateTime = getdate()  " + Constants.vbNewLine + "			    where	dataname  = @dataname   " + Constants.vbNewLine + "		    END " + Constants.vbNewLine + "		    ELSE " + Constants.vbNewLine + "		    BEGIN " + Constants.vbNewLine + "		    	set @newCount = @currentCount + 1   " + Constants.vbNewLine + "		    	update	\' + @publicationName + \'_STATISTICS    " + Constants.vbNewLine + "		    	set		UPDATESCount = @newCount  ,  " + Constants.vbNewLine + "			    		LastUPDATEDateTime = getdate()  " + Constants.vbNewLine + "			    where	dataname  = @dataname    " + Constants.vbNewLine + "		     " + Constants.vbNewLine + "		    END  " + Constants.vbNewLine + "		 end   " + Constants.vbNewLine + "		 else   " + Constants.vbNewLine + "		 begin  " + Constants.vbNewLine + "		    select  @currentCount = RESETSCount   "
								+ Constants.vbNewLine + "		   	from	\' + @publicationName + \'_STATISTICS   " + Constants.vbNewLine + "		   	where	dataname  = @dataname   " + Constants.vbNewLine + "		   	  " + Constants.vbNewLine + "		    IF @currentCount = 0 " + Constants.vbNewLine + "		    BEGIN " + Constants.vbNewLine + "		    	set @newCount = 1   " + Constants.vbNewLine + "		    	 " + Constants.vbNewLine + "		    	update	\' + @publicationName + \'_STATISTICS    " + Constants.vbNewLine + "		    	set		RESETSCount = @newCount  , " + Constants.vbNewLine + "		    			firstRESETDateTime = GETDATE()  , " + Constants.vbNewLine + "			    		lastRESETDateTime = getdate()  " + Constants.vbNewLine + "			    where	dataname  = @dataname   " + Constants.vbNewLine + "		    END  " + Constants.vbNewLine + "		    ELSE " + Constants.vbNewLine + "		    BEGIN " + Constants.vbNewLine + "		    	set @newCount = @currentCount + 1   " + Constants.vbNewLine + "		    	 " + Constants.vbNewLine + "		    	update	\' + @publicationName + \'_STATISTICS    " + Constants.vbNewLine + "		    	set		RESETSCount = @newCount  , " + Constants.vbNewLine + "			    		lastRESETDateTime = getdate()  " + Constants.vbNewLine + "			    where	dataname  = @dataname   " + Constants.vbNewLine + "		     " + Constants.vbNewLine + "		    END  " + Constants.vbNewLine + "		end   " + Constants.vbNewLine + "   fetch next from statCur into @maxID " + Constants.vbNewLine + "	end    " + Constants.vbNewLine + "commit transaction " + Constants.vbNewLine + "END \'" + Constants.vbNewLine + "exec sp_executesql @SQLSentence ";
								
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
						
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			public static void CreatePublication_DISPOSING_StoredProcedure(string connectionString)
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(connectionString))
					{
						cnn.Open();
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							
							//****************************************************************************************
							//creates command to create the stored procedure
							//****************************************************************************************
							try
							{
								cmd.CommandText = "	DROP PROCEDURE  " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_DISPOSE_STORED_PROCEDURE_NAME;
								cmd.ExecuteNonQuery();
							}
							catch (Exception)
							{
							}
							
							try
							{
								cmd.CommandText = "CREATE PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_DISPOSE_STORED_PROCEDURE_NAME + Constants.vbNewLine + 
									"@publicationName	VARCHAR(100) " + Constants.vbNewLine + 
									"AS " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET NOCOUNT ON  " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"DECLARE @SQLSentence  	NVARCHAR(3000) " + Constants.vbNewLine + 
									"DECLARE @indexName 	NVARCHAR(500) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET @publicationName = upper(@publicationName) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"--verifies if the location table exists , if not creates it  " + Constants.vbNewLine + 
									"if EXISTS " + Constants.vbNewLine + 
									"( " + Constants.vbNewLine + 
									"	SELECT 	name  " + Constants.vbNewLine + 
									"	FROM   	sysobjects  " + Constants.vbNewLine + 
									"	WHERE 	name = @publicationName " + Constants.vbNewLine + 
									"		AND 	  type = \'U\' " + Constants.vbNewLine + 
									") " + Constants.vbNewLine + 
									"BEGIN  " + Constants.vbNewLine + 
									"	SET @SQLSentence = \'DROP TABLE \' + @publicationName " + Constants.vbNewLine + 
									"	exec sp_executesql @SQLSentence  " + Constants.vbNewLine + 
									"END " + Constants.vbNewLine + 
									"DECLARE @publicationStatsTableName  NVARCHAR(1000)" + Constants.vbNewLine + 
									"SET @publicationStatsTableName = @publicationName + \'_STATISTICS\' " + Constants.vbNewLine + 
									"SET @SQLSentence = \'  " + Constants.vbNewLine + 
									"if EXISTS " + Constants.vbNewLine + 
									"( " + Constants.vbNewLine + 
									"	SELECT 	name  " + Constants.vbNewLine + 
									"	FROM   	sysobjects  " + Constants.vbNewLine + 
									"	WHERE 	name = \'\'\' + @publicationStatsTableName + \'\'\'" + Constants.vbNewLine + 
									"		AND 	  type = \'\'U\'\' " + Constants.vbNewLine + 
									") " + Constants.vbNewLine + 
									"BEGIN  " + Constants.vbNewLine + 
									"	DROP TABLE \' + @publicationName + \'_STATISTICS " + Constants.vbNewLine + 
									"END\'  " + Constants.vbNewLine + 
									"exec sp_executesql @SQLSentence  ";
								
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
						
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			public static void CreatePublication_STATISTICS_StoredProcedure(string connectionString)
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(connectionString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							//****************************************************************************************
							//drops the stored procedure
							//****************************************************************************************
							try
							{
								cmd.CommandText = " DROP PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_CONSULT_STORED_PROCEDURE_NAME;
								cmd.ExecuteNonQuery();
							}
							catch (Exception)
							{
							}
							
							try
							{
								
								cmd.CommandText = "CREATE PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_CONSULT_STORED_PROCEDURE_NAME + Constants.vbNewLine + 
									"@publicationName	VARCHAR(500)" + Constants.vbNewLine + 
									"AS " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET NOCOUNT ON  " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"DECLARE @SQLSentence  	NVARCHAR(3000) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET @publicationName = upper(@publicationName) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET @SQLSentence = \' " + Constants.vbNewLine + 
									" SELECT    dataname AS \"Data Name\" ,  " + Constants.vbNewLine + 
									"           firstUPDATEDateTime as \"First UPDATE\", " + Constants.vbNewLine + 
									"           LastUPDATEDateTime as  \"Last UPDATE\" ," + Constants.vbNewLine + 
									"           UPDATESCount as \"UPDATES Count\" ," + Constants.vbNewLine + 
									"           firstRESETDateTime as \"First RESET\", " + Constants.vbNewLine + 
									"           lastRESETDateTime as \"Last RESET\" ," + Constants.vbNewLine + 
									"           RESETSCount as \"RESETS Count\" " + Constants.vbNewLine + 
									" FROM      \' + @publicationName + \'_STATISTICS\'" + Constants.vbNewLine + 
									"exec sp_executesql @SQLSentence  ";
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
						
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			public static void CreatePublication_STATISTICS_RESET_StoredProcedure(string connectionString)
			{
				try
				{
					using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(connectionString))
					{
						cnn.Open();
						
						using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
						{
							cmd.Connection = cnn;
							//****************************************************************************************
							//drops the stored procedure
							//****************************************************************************************
							try
							{
								cmd.CommandText = " DROP PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_RESET_STORED_PROCEDURE_NAME;
								cmd.ExecuteNonQuery();
							}
							catch (Exception)
							{
							}
							
							try
							{
								
								cmd.CommandText = "CREATE PROCEDURE " + DPE_PUBLICATIONS_DATABASE_PUBLICATION_STATISTICS_RESET_STORED_PROCEDURE_NAME + Constants.vbNewLine + 
									"@publicationName	VARCHAR(500)" + Constants.vbNewLine + 
									"AS " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET NOCOUNT ON  " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"DECLARE @SQLSentence  	NVARCHAR(3000) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET @publicationName = upper(@publicationName) " + Constants.vbNewLine + 
									" " + Constants.vbNewLine + 
									"SET @SQLSentence = \' " + Constants.vbNewLine + 
									"       UPDATE  \' + @publicationName + \'_STATISTICS " + Constants.vbNewLine + 
									"       SET     UPDATESCount = 0 , " + Constants.vbNewLine + 
									"               RESETSCount = 0 \' " + Constants.vbNewLine + 
									"exec sp_executesql @SQLSentence  ";
								cmd.ExecuteNonQuery();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
						
						
					}
					
					
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
				
#endregion
			
		}
		
	}
	
	
}
