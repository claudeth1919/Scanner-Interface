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
	
	
	[Serializable()]public class ManagedDBQueryDef : DBQueryDefinition
	{
		
		
#region < DATAMEMBERS >
		
		private string _connectionStringID;
		
#endregion
		
#region < PROPERTIES >
		
		
public string ConnectionStringID
		{
			get
			{
				return this._connectionStringID;
			}
		}
		
#endregion
		
#region < CONSTRUCTORS >
		
		public ManagedDBQueryDef(string connectionStringID, string commandText, queryType queryType) : base(commandText, queryType)
		{
			this._connectionStringID = connectionStringID;
		}
		
		public ManagedDBQueryDef(string connectionStringID, queryType queryType) : base(queryType)
		{
			this._connectionStringID = connectionStringID;
		}
		
#endregion
		
#region < PRIVATE METHODS >
		
#endregion
		
		
		
		
		
		
	}
	
}
