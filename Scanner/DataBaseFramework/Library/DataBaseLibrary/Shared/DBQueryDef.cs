using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Definitions;



namespace DataBaseLibrary
{
#region < CLASS INFORMATION >
	
#endregion
	
	
	[Serializable()]public class DBQueryDef : DBQueryDefinition
	{
		
		
		
#region < DATAMEMBERS >

		private string _connectionString;
		
#endregion
		
#region < PROPERTIES >
		
public string ConnectionString
		{
			get
			{
				return this._connectionString;
			}
		}
		
#endregion		
		
#region < CONSTRUCTORS >
		
		public DBQueryDef(string ConnectionString, queryType queryTpe, string commandText) : base(commandText, queryTpe)
		{
			this._connectionString = ConnectionString;
		}
		
		public DBQueryDef(string ConnectionString, queryType queryTpe) : base(queryTpe)
		{
			this._connectionString = ConnectionString;
		}
		
		
#endregion
		
		
#region < PRIVATE METHODS >
		
#endregion
		
		
		
		
		
		
	}
	
}
