// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace SQLServerScriptRunner
{
	namespace SQLServerScripting
	{
		
		public class SQLScriptRunner
		{
			
#region  < DATA MEMBERS >
			
			private string _serverName; //.. Server where the DB resides
			private string _user;
			private string _pwd;
			private string _dataBase; //.. database name (catalog is the name used when building the connection string)
			private string _connectionString;
			private SortedList _fileList; //.. scripts will run according to their order in the list
			private SortedList _scriptsToExecute;
			
#endregion
			
			
#region  < CONSTRUCTORS >
			
			public SQLScriptRunner(string ServerName, string DataBaseName, string user, string pwd, SortedList fileList)
			{
				this._serverName = ServerName;
				this._user = user;
				this._pwd = pwd;
				this._dataBase = DataBaseName;
				this._connectionString = this.CreateConnectionString();
				this._fileList = fileList;
				this.GetScriptsFromFileList();
				
			}
			
#endregion
			
			
#region  < PUBLIC METHODS >
			
			public void Run()
			{
				try
				{
					foreach (DictionaryEntry item in this._scriptsToExecute)
					{
						try
						{
							SQLScript currentScript = default(SQLScript);
							currentScript = (SQLScript) item.Value;
							ExecuteScript(currentScript);
							//WriteScript(item.Key, currentScript)
							
						}
						catch (System.Data.SqlClient.SqlException ex)
						{
							// This line must record the failure for a later notification to user
							throw (ex);
						}
					}
				}
				catch (Exception ex)
				{
					throw (ex);
					
				}
			}
			
#endregion
			
			
#region  < PRIVATE METHODS >
			
			private void GetScriptsFromFileList()
			{
				try
				{
					if (this._scriptsToExecute == null)
					{
						_scriptsToExecute = new SortedList();
					}
					foreach (DictionaryEntry item in this._fileList)
					{
						try
						{
							SQLScript currentscript = new SQLScript(System.Convert.ToString(item.Value));
							_scriptsToExecute.Add(currentscript.FileName, currentscript);
						}
						catch (Exception)
						{
						}
					}
				}
				catch (Exception)
				{
				}
			}
			
			private string CreateConnectionString()
			{
				return "Data Source=" + this._serverName + ";user=" + this._user + ";pwd=" + this._pwd + ";Initial Catalog=" + this._dataBase;
			}
			
			private void WriteScript(string ScriptName, SQLScript script)
			{
				try
				{
					IEnumerator ienum = script.ScriptBatchContents.GetEnumerator();
					StringBuilder strBldr = default(StringBuilder);
					string testPath = System.AppDomain.CurrentDomain.BaseDirectory + ScriptName + ".txt";
					
					while (ienum.MoveNext())
					{
						strBldr = (System.Text.StringBuilder) ienum.Current;
						StreamWriter wr = new StreamWriter(testPath, true);
						wr.Write(strBldr.ToString());
						wr.Close();
					}
					
				}
				catch (Exception ex)
				{
					throw (ex);
				}
			}
			
			private dynamic ExecuteScript(SQLScript script)
			{
				System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection();
				System.Data.SqlClient.SqlCommand dbComm = new System.Data.SqlClient.SqlCommand();
				string scriptBatchContentsText = "";
				
				while (script.ScriptBatchContents.Count > 0)
				{
					scriptBatchContentsText = System.Convert.ToString(script.ScriptBatchContents.Dequeue());
					try
					{
						dbConn.ConnectionString = this._connectionString;
						
						dbComm.Connection = dbConn;
						dbComm.CommandType = CommandType.Text;
						dbComm.CommandText = scriptBatchContentsText;
						
						dbConn.Open();
						dbComm.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						throw (ex);
					}
					finally
					{
						dbConn.Close();
					}
				}
				return default(dynamic);
			}
			
#endregion
			
			
		}
	}
	
	
	
}
