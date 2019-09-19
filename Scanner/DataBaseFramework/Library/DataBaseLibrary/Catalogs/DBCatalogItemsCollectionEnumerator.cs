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
		
		public class DBCatalogItemsCollectionEnumerator : IEnumerator
		{
			
#region  < DATA MEMBERS  >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DBCatalogItemsCollectionEnumerator(DBCatalogItemsCollection catalog)
			{
				this._enumerator = catalog.ItemsContainer.GetEnumerator();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerator >
			
public dynamic Current
			{
				get
				{
					DictionaryEntry dicEntry = (DictionaryEntry) this._enumerator.Current;
					ICatalogItem item = (ICatalogItem) dicEntry.Value;
					return item;
				}
			}
			
			public bool MoveNext()
			{
				return this._enumerator.MoveNext();
			}
			
			public void Reset()
			{
				this._enumerator.Reset();
			}
			
#endregion
			
#endregion
			
			
		}
		
		
		
	}
	
	
}
