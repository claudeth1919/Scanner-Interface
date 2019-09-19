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
		namespace Catalogs.Interfaces
		{
			
			
			public interface ICatalogItem
			{
				
#region  < PROPERTIES >
				
				string ID {get;}
				DBCatalog ParentCatalog {get;}
				
#endregion
				
#region  < METHODS  >
				
				void SetParentCatalog(DBCatalog catalog);
			
#endregion
			
			
			
			
		}
		
		
	}
	
	
	
	
}
