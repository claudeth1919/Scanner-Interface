using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Catalogs.Interfaces;

namespace DataBaseLibrary
{
	namespace Catalogs
	{
		
		public class BooleanStatus : ICatalogItem
		{
			
			private bool _Status;
			
            public bool Status
			{
				get
				{
					return this._Status;
				}
			}
			
			
			public BooleanStatus(bool Status)
			{
				this._Status = Status;
			}
			
            public string ID
			{
				get
				{
                    return UtilitiesLibrary.UtilitiesModule.GetIndexableGUID();
        		}
			}
			
            public DBCatalog ParentCatalog
			{
				get
				{
					return null;
				}
			}
			
			public void SetParentCatalog(DataBaseLibrary.Catalogs.DBCatalog catalog)
			{
			}
			
			
		}
		
		
	}
	
	
}
