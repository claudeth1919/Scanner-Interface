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
using System.Threading;


namespace DataBaseLibrary
{
	namespace Catalogs
	{
		
		[Serializable()]public class DBCatalogItemsCollection : IEnumerable
		{
			
			
#region  < DATA MEMBERS >
			
			private readonly object _locker = new object();
			private Hashtable _itemsCollection;
			
#endregion
			
			
#region  < PROPERTIES >
			
internal IEnumerable ItemsContainer
			{
				get
				{
					return this._itemsCollection;
				}
			}
			
public int Count
			{
				get
				{
					return this._itemsCollection.Count;
				}
			}
			
#endregion
			
#region  < CONSTRICTORS >
			
			public DBCatalogItemsCollection()
			{
				this._itemsCollection = new Hashtable();
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddItem(ICatalogItem item)
			{
				lock(_locker)
				{
					
					
					string id = item.ID;
					
					if (!this._itemsCollection.ContainsKey(id))
					{
						this._itemsCollection.Add(id, item);
					}
					else
					{
						throw (new Exception("The element already belogs to the catalog items collection"));
					}
					
				}
				
			}
			
			public ICatalogItem GetItem(string id)
			{
				return (ICatalogItem) (this._itemsCollection[id]);
			}
			
			public bool ContainsItem(ICatalogItem element)
			{
				string id = element.ID;
				return this._itemsCollection.ContainsKey(id);
			}
			
			public bool ContainsItem(string id)
			{
				return this._itemsCollection.ContainsKey(id);
			}
			
			public void Clear()
			{
				this._itemsCollection.Clear();
			}
			
			public void RemoveItem(string ID)
			{
				ICatalogItem item = this.GetItem(ID);
				this._itemsCollection.Remove(item.ID);
			}
			
			public void RemoveItem(ICatalogItem item)
			{
				this._itemsCollection.Remove(item.ID);
			}
			
			public void UpdateItem(ICatalogItem item)
			{
				if (this.ContainsItem(item))
				{
					ICatalogItem oldItem = this.GetItem(item.ID);
					this.RemoveItem(oldItem);
				}
				this.AddItem(item);
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  <  IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				DBCatalogItemsCollectionEnumerator enumm = new DBCatalogItemsCollectionEnumerator(this);
				return enumm;
			}
			
#endregion
			
#endregion
			
		}
		
		
	}
	
	
}
