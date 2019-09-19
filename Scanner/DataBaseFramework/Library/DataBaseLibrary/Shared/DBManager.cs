using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary;
using System.Data.SqlClient;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Configuration;
using UtilitiesLibrary.Configuration.Data;


namespace DataBaseLibrary
{
	[Serializable()]public class DBManager
	{
		
#region < CLASS INFORMATION >
#endregion
		
#region < DATAMEMBERS >
		//for singleton implementation
		private static DBManager _DBManager;
		private SortedList _connectionsStringList;
		
#endregion
		
#region < CONSTRUCTORS >
		
		private DBManager()
		{
			//create the connections string list
			_connectionsStringList = new SortedList();
			//_storedProceduresList = New SortedList
		}
		
#endregion
		
#region SINGLETON IMPLEMENTATION
		
		internal static DBManager GetInstance()
		{
			if (_DBManager == null)
			{
				_DBManager = new DBManager();
			}
			return _DBManager;
		}
		
#endregion
		
#region < PRIVATE METHODS >
		
		private static string GetConnectionString(string DataBaseKeyID)
		{
			string cnnString = "";
			DBManager _dbManager = DBManager.GetInstance();
			
			//evaluates if the key id exisit already in the connections string list
			if (!_dbManager._connectionsStringList.ContainsKey(DataBaseKeyID))
			{
				
				//get acces to configuration file handler
				ConfigurationFileHandler configFile = default(ConfigurationFileHandler);
				configFile = ConfigurationFileHandlerProxyServer.GetInstance().GetFileHandler();
				
				KeyValue configurationKey = default(KeyValue);
				configurationKey = (KeyValue) (configFile.GetValue("DATABASE_FRAMEWORK/CONNECTION_STRINGS/" + DataBaseKeyID));
				
				if (configurationKey == null)
				{
					string message = "";
					message = "Not connection string defined for DataBaseID : " + DataBaseKeyID + Constants.vbNewLine + "Or not configuration Exists in Route : DATABASE_FRAMEWORK/CONNECTION_STRINGS/";
					throw (new Exception(message));
				}
				
				//adds the new connection string
				cnnString = configurationKey.Value;
				_dbManager._connectionsStringList.Add(DataBaseKeyID, configurationKey.Value);
			}
			else
			{
				cnnString = System.Convert.ToString(_dbManager._connectionsStringList[DataBaseKeyID]);
			}
			return cnnString;
		}
		
		private static DBData GetDataFromSource(string ConnectionString, DBQueryDefinition queryDefinition)
		{
			
			return default(DBData);
		}
		
#endregion
		
#region < PUBLIC METHODS >
		
		public static void Clear()
		{
			DBManager _dbManager = DBManager.GetInstance();
			_dbManager._connectionsStringList.Clear();
		}
		
		public static DBData RetrieveData(DBQueryDef queryDefinition)
		{
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(queryDefinition.ConnectionString))
			{
				
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryDefinition.CommandText, cnn))
				{
					
					DBData DBData = new DBData();
					switch (queryDefinition.QueryType)
					{
						case DataBaseLibrary.Definitions.queryType.Text:
							cmd.CommandType = CommandType.Text;
							DBData.FillData(cmd);
							break;
							
						case DataBaseLibrary.Definitions.queryType.StoredProcedure:
							cmd.CommandType = CommandType.StoredProcedure;
							
							System.Collections.IEnumerator listEnumerator = default(System.Collections.IEnumerator);
							QueryParameter parameter = default(QueryParameter);
							
							//gets the parameters from the definition
							listEnumerator = queryDefinition.Parameters.GetEnumerator();
							while (listEnumerator.MoveNext())
							{
                                parameter = (QueryParameter)listEnumerator.Current;
								System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameter.Name, parameter.Value);
                                param.SqlDbType = parameter.sqlType;
                                param.Direction = parameter.Direction;
                                param.Size = parameter.Size;
								cmd.Parameters.Add(param);
							}
							DBData.FillData(cmd);
							break;
					}
					return DBData;
				}
				
			}
			
			
		}

        public static ParametersContainer RetrieveOUTPUTParametersData(DBQueryDef queryDefinition)
        {
            ParametersContainer _OUTPUTcontainer = new ParametersContainer(); 

        
            using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(queryDefinition.ConnectionString))
            {

                cnn.Open();

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryDefinition.CommandText, cnn))
                {

                    try
                    {
                        switch (queryDefinition.QueryType)
                        {
                            case DataBaseLibrary.Definitions.queryType.Text:
                                cmd.CommandType = CommandType.Text;
                                break;

                            case DataBaseLibrary.Definitions.queryType.StoredProcedure:
                                cmd.CommandType = CommandType.StoredProcedure;

                                System.Collections.IEnumerator listEnumerator = default(System.Collections.IEnumerator);

                                QueryParameter parameter = default(QueryParameter);

                                //gets the parameters from the definition
                                listEnumerator = queryDefinition.Parameters.GetEnumerator();
                                while (listEnumerator.MoveNext())
                                {
                                    parameter = (QueryParameter)listEnumerator.Current;
                                    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameter.Name , parameter.sqlType);
                                    param.SqlDbType = parameter.sqlType;
                                    param.Direction = parameter.Direction;
                                    param.Size = parameter.Size;

                                    if (param.Direction == ParameterDirection.Output)
                                    {
                                        _OUTPUTcontainer.AddParameter(parameter);
                                    }
                                    cmd.Parameters.Add(param);                                   
                                }
                                break;
                        }
                        cmd.ExecuteNonQuery();
                        //transferrs the valur retrieved to the parameters in the result set 
                        foreach (QueryParameter param in _OUTPUTcontainer)
                        {
                            param.Value = cmd.Parameters[param.Name].Value; 
                        }                        
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }

                }
            }

            return _OUTPUTcontainer;
        }

		public static DBData RetrieveData(ManagedDBQueryDef queryDefinition)
		{
			
			string cnnstring = "";
			cnnstring = GetConnectionString(queryDefinition.ConnectionStringID);
			DBData DBData = new DBData();
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnstring))
			{
				
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryDefinition.CommandText, cnn))
				{
					
					switch (queryDefinition.QueryType)
					{
						case DataBaseLibrary.Definitions.queryType.Text:
							cmd.CommandType = CommandType.Text;
							DBData.FillData(cmd);
							break;
							
						case DataBaseLibrary.Definitions.queryType.StoredProcedure:
							cmd.CommandType = CommandType.StoredProcedure;
							
							System.Collections.IEnumerator listEnumerator = default(System.Collections.IEnumerator);											
							QueryParameter parameter = default(QueryParameter);
							
							//gets the parameters from the definition
							listEnumerator = queryDefinition.Parameters.GetEnumerator();
							while (listEnumerator.MoveNext())
							{
                                parameter = (QueryParameter)listEnumerator.Current;
								System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameter.Name, parameter.Value);
                                param.Direction = parameter.Direction;
                                param.SqlDbType = parameter.sqlType;
                                param.Size = parameter.Size;
                                cmd.Parameters.Add(param);
							}
							DBData.FillData(cmd);
							break;
					}
					
				}
				
			}
			
			
			return DBData;
		}
		
		public static void ExecuteQuery(DBQueryDef queryDefinition)
		{
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(queryDefinition.ConnectionString))
			{
				
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryDefinition.CommandText, cnn))
				{
					
					try
					{
						switch (queryDefinition.QueryType)
						{
							case DataBaseLibrary.Definitions.queryType.Text:
								cmd.CommandType = CommandType.Text;
								break;
								
							case DataBaseLibrary.Definitions.queryType.StoredProcedure:
								cmd.CommandType = CommandType.StoredProcedure;
								
								System.Collections.IEnumerator listEnumerator = default(System.Collections.IEnumerator);
															
								QueryParameter parameter = default(QueryParameter);
								
								//gets the parameters from the definition
								listEnumerator = queryDefinition.Parameters.GetEnumerator();
								while (listEnumerator.MoveNext())
								{									
									parameter = (QueryParameter) listEnumerator.Current;
                                    System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameter.Name, parameter.Value);
                                    param.Direction = parameter.Direction;
                                    param.SqlDbType = parameter.sqlType;
                                    param.Size = parameter.Size;
                                    cmd.Parameters.Add(param);
								}
								break;
						}
						cmd.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						throw (ex);
					}
					
				}
				
				
			}
			
			
		}
		
		public static void ExecuteQuery(ManagedDBQueryDef queryDefinition)
		{
			
			string cnnstring = "";
			cnnstring = GetConnectionString(queryDefinition.ConnectionStringID);
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(cnnstring))
			{
				
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(queryDefinition.CommandText, cnn))
				{
					
					
					switch (queryDefinition.QueryType)
					{
						case DataBaseLibrary.Definitions.queryType.Text:
							cmd.CommandType = CommandType.Text;
							break;
							
						case DataBaseLibrary.Definitions.queryType.StoredProcedure:
							cmd.CommandType = CommandType.StoredProcedure;
							
							System.Collections.IEnumerator listEnumerator = default(System.Collections.IEnumerator);
													
							QueryParameter parameter = default(QueryParameter);
													
							//gets the parameters from the definition
							listEnumerator = queryDefinition.Parameters.GetEnumerator();
							while (listEnumerator.MoveNext())
							{
                                parameter = (QueryParameter)listEnumerator.Current;
								System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameter.Name, parameter.Value);
                                param.Direction = parameter.Direction;
                                param.SqlDbType = parameter.sqlType;
                                param.Size = parameter.Size;
                                cmd.Parameters.Add(param);
							}
							break;
							
					}
					cmd.ExecuteNonQuery();
				}
			}
		}
		
#endregion
		
		
		
		
		
		
	}
	
}
