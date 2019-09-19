using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;


namespace DataBaseLibrary
{
	namespace Definitions
	{
		
		[Serializable()]public enum queryType
		{
			Text = 1,
			StoredProcedure = 2
		}
		
		[Serializable()]public enum CatalogElementStatus
		{
			AlreadyLoaded = 1,
			Created = 2,
			Deleted = 3,
			Inserted = 4
		}
		
		[Serializable()]public enum CatalogSourceMode
		{
			SerializedFile = 1,
			DataBase = 2
		}
		
		
		[Serializable()]public enum DataSourceProviderType
		{
			SQLServer2000,
			SQLServer2005,
			SQLServer2008,
			Oracle,
			MySQL,
			Informix,
			Paradox,
			Progress,
			AS400
		}
		
		
	}
	
	
	
	
}
