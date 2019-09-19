// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.IO;


namespace SQLServerDBAttacher
{
	public class SQLServerDBAttacher : IDisposable
	{
		
#region << DATA MEMBERS >>
		
		private string cnnStr;
		
#endregion
		
#region << CONSTRUCTOR >>
		
		public SQLServerDBAttacher(string SQLServerName, string UserID, string PassWord)
		{
			//creates the connection string
			cnnStr = "Data Source=" + SQLServerName + ";user=" + UserID + ";pwd=" + PassWord + ";Initial Catalog=master";
		}
		
#endregion
		
#region << PUBLIC FUNCTIONS >>
		
		public void Attach(string DBName, string mdfDBFilePathName, string ldfLogFilePathName)
		{
			//this function attachs a database from a .mdf and .ldf files specifying a name for the database
			if (!File.Exists(mdfDBFilePathName))
			{
				throw (new Exception("Specified mdf file not exists in the pathname provided : " + mdfDBFilePathName));
			}
			if (!File.Exists(ldfLogFilePathName))
			{
				throw (new Exception("Specified ldf file not exists in the pathname provided : " + ldfLogFilePathName));
			}
			//get the full paths
			string SQLcmd = "";
			SQLcmd = "EXEC sp_attach_db \'" + DBName + "\',\'" + mdfDBFilePathName + "\',\'" + ldfLogFilePathName + "\'";
			
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this.cnnStr))
			{
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
				{
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = SQLcmd;
					
					cmd.ExecuteNonQuery();
					
				}
				
				
			}
			
			
		}
		
		public void Attach(string DBName, string mdfDBFilePathName)
		{
			
			if (!File.Exists(mdfDBFilePathName))
			{
				throw (new Exception("Specified mdf file not exists in the pathname provided : " + mdfDBFilePathName));
			}
			
			string SQLcmd = "";
			SQLcmd = "EXEC sp_attach_single_file_db \'" + DBName + "\',\'" + mdfDBFilePathName + "\'";
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this.cnnStr))
			{
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
				{
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = SQLcmd;
					
					cmd.ExecuteNonQuery();
					
				}
				
				
			}
			
			
			
		}
		
		public void Detach(string DBName, bool skipChecks)
		{
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this.cnnStr))
			{
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
				{
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "ALTER DATABASE [" + DBName + "]" + Constants.vbNewLine + 
						"SET SINGLE_USER" + Constants.vbNewLine + 
						"WITH ROLLBACK IMMEDIATE";
					
					cmd.ExecuteNonQuery();
					
					
					cmd.CommandText = "DROP DATABASE [" + DBName + "]";
					cmd.ExecuteNonQuery();
					
				}
				
				
			}
			
			
		}
		
		public void Detach(string DBName)
		{
			
			using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(this.cnnStr))
			{
				cnn.Open();
				
				using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
				{
					cmd.Connection = cnn;
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = "ALTER DATABASE [" + DBName + "]" + Constants.vbNewLine + 
						"SET SINGLE_USER" + Constants.vbNewLine + 
						"WITH ROLLBACK IMMEDIATE";
					
					cmd.ExecuteNonQuery();
					
					
					cmd.CommandText = "DROP DATABASE [" + DBName + "]";
					cmd.ExecuteNonQuery();
					
					
				}
				
				
			}
			
			
		}
		
#endregion
		
#region << INTERFACE IMPLEMENTATIONS >>
		
		public void Dispose()
		{
			//tells the Garbage Collector to explicit free this object memory resoruces
			//avoiding calling of finalize object's function
			GC.SuppressFinalize(this);
		}
		
#endregion
		
	}
	
}
