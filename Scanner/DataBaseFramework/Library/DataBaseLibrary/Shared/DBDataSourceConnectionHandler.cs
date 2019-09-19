using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Definitions;
using UtilitiesLibrary.EventLoging;
using System.Threading;


namespace DataBaseLibrary
{
	public class DBDataSourceConnectionHandler
	{
		
		
#region  < SHARED CONENCTIONS IMPLEMENTATION >
		
		private static Hashtable _sharedConnectionsTable = new Hashtable();
		
		public static DBDataSourceConnectionHandler GetSharedConnectionHandler(string DBServerName, string DataBaseName, string UserID, string userPassword, DataSourceProviderType DBProvider)
		{
			
			string cnnString = "";
			//crates the datasourder connection string
			cnnString = GetConnectionString(DBProvider, DBServerName, DataBaseName, UserID, userPassword);
			
			//verifies if there is a connection that matches the connection string
			
			DBDataSourceConnectionHandler handler = null;
			
			lock(_sharedConnectionsTable)
			{
				
				if (_sharedConnectionsTable.ContainsKey(cnnString))
				{
					handler = (DataBaseLibrary.DBDataSourceConnectionHandler) (_sharedConnectionsTable[cnnString]);
				}
				else
				{
					handler = new DBDataSourceConnectionHandler(DBServerName, DataBaseName, UserID, userPassword, DBProvider);
					_sharedConnectionsTable.Add(cnnString, handler);
				}
				
			}
			
			
			return handler;
			
		}
		
		
		
#endregion
		
#region  < DATAMEMBERS >
		
		private string _DBServerName;
		private string _DataBaseName;
		private string _userID;
		private string _userPassword;
		private DataSourceProviderType _DBProvider;
		
		private bool _eventFiredByOwnConnectionKill;
		
		private System.Data.OleDb.OleDbConnection _DBConnection;
		
		
		private const int MAX_NUMBER_OF_REQUEST_AFTER_CLOSING_CONNECTION = 5000;
		private const int MAX_CONNECTION_LIFE_TIME_INTERVAL_IN_MINUTES = 60;
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		private DBDataSourceConnectionHandler(string DBServerName, string DataBaseName, string UserID, string userPassword, DataSourceProviderType DBProvider)
		{
			
			this._DBServerName = DBServerName;
			this._DataBaseName = DataBaseName;
			this._userID = UserID;
			this._userPassword = userPassword;
			this._DBProvider = DBProvider;
			
			this._DBConnection = null;
			this._DBConnection.InfoMessage += this._DBConnection_InfoMessage;
			this._DBConnection.StateChange += this._DBConnection_StateChange;
			
			
		}
		
#endregion
		
#region  < EVENTS >
		
		public delegate void InfoMessageReceivedEventHandler(string message);
		private InfoMessageReceivedEventHandler InfoMessageReceivedEvent;
		
		public event InfoMessageReceivedEventHandler InfoMessageReceived
		{
			add
			{
				InfoMessageReceivedEvent = (InfoMessageReceivedEventHandler) System.Delegate.Combine(InfoMessageReceivedEvent, value);
			}
			remove
			{
				InfoMessageReceivedEvent = (InfoMessageReceivedEventHandler) System.Delegate.Remove(InfoMessageReceivedEvent, value);
			}
		}
		
		public delegate void DBConnectionLostEventHandler(System.Data.ConnectionState oldState, System.Data.ConnectionState NewState);
		private DBConnectionLostEventHandler DBConnectionLostEvent;
		
		public event DBConnectionLostEventHandler DBConnectionLost
		{
			add
			{
				DBConnectionLostEvent = (DBConnectionLostEventHandler) System.Delegate.Combine(DBConnectionLostEvent, value);
			}
			remove
			{
				DBConnectionLostEvent = (DBConnectionLostEventHandler) System.Delegate.Remove(DBConnectionLostEvent, value);
			}
		}
		
		
#endregion
		
#region  < properties >
		
public string DBServerName
		{
			get
			{
				return this._DBServerName;
			}
			set
			{
				this._DBServerName = value;
			}
		}
		
public System.Data.OleDb.OleDbConnection DBConnection
		{
			get
			{
				return this._DBConnection;
			}
		}
		
public string DataBaseName
		{
			get
			{
				return this._DataBaseName;
			}
			set
			{
				this._DataBaseName = value;
			}
		}
		
public string UserID
		{
			get
			{
				return this._userID;
			}
			set
			{
				this._userID = value;
			}
		}
		
public string UserPassword
		{
			get
			{
				return this._userPassword;
			}
			set
			{
				this._userPassword = value;
			}
		}
		
public DataSourceProviderType DBProvider
		{
			get
			{
				return this._DBProvider;
			}
			set
			{
				this._DBProvider = value;
			}
		}
		
#endregion
		
#region  < EVENT HANDLING  >
		
		private void _DBConnection_InfoMessage(object sender, System.Data.OleDb.OleDbInfoMessageEventArgs e)
		{
			string MESSAGE = "";
			MESSAGE = "[ Source : " + e.Source + "] ,  [ Error Code : " + System.Convert.ToString(e.ErrorCode) + "] , [ Message :  " + e.Message + "]";
			try
			{
				if (InfoMessageReceivedEvent != null)
					InfoMessageReceivedEvent(MESSAGE);
			}
			catch (Exception)
			{
			}
		}
		
		private void _DBConnection_StateChange(object sender, System.Data.StateChangeEventArgs e)
		{
			
			if (!this._eventFiredByOwnConnectionKill)
			{
				
				if (e.OriginalState == ConnectionState.Open)
				{
					if (e.CurrentState == ConnectionState.Broken | e.CurrentState == ConnectionState.Closed)
					{
						try
						{
							if (DBConnectionLostEvent != null)
								DBConnectionLostEvent(e.OriginalState, e.CurrentState);
						}
						catch (Exception)
						{
						}
					}
				}
			}
			
			this._eventFiredByOwnConnectionKill = false;
			
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void CloseConnection()
		{
			this._eventFiredByOwnConnectionKill = true;
			this._DBConnection.Close();
		}
		
		public string GetConnectionString()
		{
			return GetConnectionString(this._DBProvider, this._DBServerName, this._DataBaseName, this._userID, this._userPassword);
		}
		
		public void OpenConnection()
		{
			if (this._DBConnection == null)
			{
				this.CreateNewConnection();
			}
			if (this._DBConnection.State == ConnectionState.Closed)
			{
				this._DBConnection.Open();
			}
		}
		
		public void CreateNewConnection()
		{
			
			this._eventFiredByOwnConnectionKill = true;
			try
			{
				this._DBConnection.Close();
			}
			catch (Exception)
			{
			}
			try
			{
				this._DBConnection.Dispose();
			}
			catch (Exception)
			{
			}
			this._DBConnection = new System.Data.OleDb.OleDbConnection(this.GetConnectionString());
			this._DBConnection.InfoMessage += this._DBConnection_InfoMessage;
			this._DBConnection.StateChange += this._DBConnection_StateChange;
			
		}
		
		public void TestConnection()
		{
			System.Data.OleDb.OleDbConnection cnn = default(System.Data.OleDb.OleDbConnection);
			cnn = new System.Data.OleDb.OleDbConnection(this.GetConnectionString());
			try
			{
				cnn.Open();
			}
			catch (Exception ex)
			{
				string msg;
				msg = "Error connecting to the data source : " + ex.Message;
				throw (new Exception());
			}
			finally
			{
				try
				{
					cnn.Close();
				}
				catch (Exception)
				{
				}
			}
		}
		
		public string GetProviderTypeAsString()
		{
			switch (this._DBProvider)
			{
				case DataSourceProviderType.SQLServer2000:
					return "DataSourceProviderType.SQLServer2000";
				case DataSourceProviderType.SQLServer2005:
					return "DataSourceProviderType.SQLServer2005";
				case DataSourceProviderType.SQLServer2008:
					return "DataSourceProviderType.SQLServer2008";
				case DataSourceProviderType.Oracle:
					return "DataSourceProviderType.Oracle";
				case DataSourceProviderType.MySQL:
					return "DataSourceProviderType.MySQL";
				case DataSourceProviderType.Paradox:
					return "DataSourceProviderType.Paradox";
				case DataSourceProviderType.Progress:
					return "DataSourceProviderType.Progress";
				case DataSourceProviderType.Informix:
					return "DataSourceProviderType.Informix";
				case DataSourceProviderType.AS400:
					return "DataSourceProviderType.AS400";
				default:
					throw (new Exception("Invalid provider type"));
			}
		}
		
		
		public static string GetProviderTypeAsString(DataSourceProviderType DBProvider)
		{
			switch (DBProvider)
			{
				case DataSourceProviderType.SQLServer2000:
					return "DataSourceProviderType.SQLServer2000";
				case DataSourceProviderType.SQLServer2005:
					return "DataSourceProviderType.SQLServer2005";
				case DataSourceProviderType.SQLServer2008:
					return "DataSourceProviderType.SQLServer2008";
				case DataSourceProviderType.Oracle:
					return "DataSourceProviderType.Oracle";
				case DataSourceProviderType.MySQL:
					return "DataSourceProviderType.MySQL";
				case DataSourceProviderType.Paradox:
					return "DataSourceProviderType.Paradox";
				case DataSourceProviderType.Progress:
					return "DataSourceProviderType.Progress";
				case DataSourceProviderType.Informix:
					return "DataSourceProviderType.Informix";
				case DataSourceProviderType.AS400:
					return "DataSourceProviderType.AS400";
				default:
					throw (new Exception("Invalid provider type"));
			}
		}
		
		
#endregion
		
#region  < SHARED METHODS >
		
		public static DBDataSourceConnectionHandler GetDedicatedConnectionHandler(string DBServerName, string DataBaseName, string UserID, string userPassword, DataSourceProviderType DBProvider)
		{
			
			DBDataSourceConnectionHandler handler = new DBDataSourceConnectionHandler(DBServerName, DataBaseName, UserID, userPassword, DBProvider);
			
			return handler;
			
		}
		
		public static string GetConnectionString(DataSourceProviderType DBProvider, string DBServerName, string DataBaseName, string UserID, string UserPassword)
		{
			string cnnString = "";
			
			switch (DBProvider)
			{
				case DataSourceProviderType.SQLServer2000:
					cnnString = "Provider=SQLOLEDB;Data Source=" + DBServerName + ";Initial Catalog=" + DataBaseName + ";User Id=" + UserID + "; Password=" + UserPassword + ";";
					return cnnString;
				case DataSourceProviderType.SQLServer2005:
					cnnString = "Provider=SQLNCLI;Server=" + DBServerName + ";Database=" + DataBaseName + ";Uid=" + UserID + "; Pwd=" + UserPassword + ";";
					return cnnString;
				case DataSourceProviderType.SQLServer2008:
					cnnString = "Provider=SQLNCLI10;Server=" + DBServerName + ";Database=" + DataBaseName + ";Uid=" + UserID + "; Pwd=" + UserPassword + ";";
					return cnnString;
				case DataSourceProviderType.Oracle:
					cnnString = "Provider=OraOLEDB.Oracle;Password=" + UserPassword + ";Persist Security Info=True;User ID=" + UserID + ";Data Source=" + DBServerName + ";";
					return cnnString;
				case DataSourceProviderType.MySQL:
					cnnString = "Provider=MySQLProv;Data Source=" + DBServerName + ";User Id=" + UserID + ";Password=" + UserPassword + ";";
					return cnnString;
				case DataSourceProviderType.Informix:
					cnnString = "";
					return cnnString;
				case DataSourceProviderType.Paradox:
					cnnString = "";
					return cnnString;
				case DataSourceProviderType.Progress:
					cnnString = "";
					return cnnString;
				case DataSourceProviderType.AS400:
					cnnString = "";
					return cnnString;
				default:
					return null;
			}
									
		}
		
		public static DataSourceProviderType GetProviderTypeFromString(string typeAsString)
		{
			switch (typeAsString)
			{
				case "DataSourceProviderType.SQLServer2000":
					return DataSourceProviderType.SQLServer2000;
				case "DataSourceProviderType.SQLServer2005":
					return DataSourceProviderType.SQLServer2005;
				case "DataSourceProviderType.SQLServer2008":
					return DataSourceProviderType.SQLServer2008;
				case "DataSourceProviderType.Oracle":
					return DataSourceProviderType.Oracle;
				case "DataSourceProviderType.MySQL":
					return DataSourceProviderType.MySQL;
				case "DataSourceProviderType.Paradox":
					return DataSourceProviderType.Paradox;
				case "DataSourceProviderType.Progress":
					return DataSourceProviderType.Progress;
				case "DataSourceProviderType.Informix":
					return DataSourceProviderType.Informix;
				case "DataSourceProviderType.AS400":
					return DataSourceProviderType.AS400;
				default:
					throw (new Exception("Invalid provider type"));
					
			}
		}
		
#endregion
		
		
	}
	
	
	
	
}
