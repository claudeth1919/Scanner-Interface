using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.EventLoging;


namespace DataBaseLibrary
{
	[Serializable()]public class DBData : IDisposable
	{
		
		
#region < DATAMEMBERS >
		
		private DataTable _dt;
		
#endregion
		
#region < CONSTRUCTORS >
		
		internal DBData()
		{
			this._dt = new System.Data.DataTable();
		}
		
#endregion
		
#region < PROPERTIES >
		
		
public DataTable Data
		{
			get
			{
				return this._dt;
			}
		}
		
		
		
#endregion
		
#region < FRIEND METHODS >
		internal void FillData(System.Data.SqlClient.SqlCommand cmd)
		{
			using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter())
			{
				da.SelectCommand = cmd;
				da.Fill(this._dt);
			}
			
			
		}
#endregion
		
#region < INTERFACE IMPLEMENTATIONS >
		
		
		public void Dispose()
		{
			this._dt.Dispose();
		}
		
#endregion
		
	}
	
	
	
}
