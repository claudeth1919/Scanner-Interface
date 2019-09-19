using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using DataBaseLibrary.Catalogs;
using DataBaseLibrary.Catalogs.Interfaces;


namespace DataBaseLibrary
{
	namespace Catalogs
	{
		
		public class SearchText : ICatalogItem
		{
			
			private string _searchText;
			
            public string SearchText_Renamed
			{
				get
				{
					return this._searchText;
				}
			}
			
			
			public SearchText(string searchText)
			{
				this._searchText = searchText;
			}
			
            public string ID
			{
				get
				{
                    return  UtilitiesLibrary.UtilitiesModule.GetIndexableGUID();;
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
