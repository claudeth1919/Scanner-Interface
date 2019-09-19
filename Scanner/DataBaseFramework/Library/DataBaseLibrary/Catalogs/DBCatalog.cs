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
	namespace Catalogs
	{
		
		[Serializable()]public abstract class DBCatalog
		{
			
#region  < DATA MEMBERS >
			
			
			private DBCatalogItemsCollection _allItemsCollection;
			private DBCatalogItemsCollection _selectedItemsCollection;
			private DBCatalogQueryParameters _DBCatalogQueryParameters;
			private string _name;
			private string _dataSourceConnectionString;
			
			
#endregion
			
#region  <  PROPERTIES >
			
public DBCatalogItemsCollection Items
			{
				get
				{
					return this._allItemsCollection;
				}
			}
			
public DBCatalogItemsCollection SelectedItems
			{
				get
				{
					return this._selectedItemsCollection;
				}
			}
			
public DBCatalogQueryParameters QueryParameters
			{
				get
				{
					return this._DBCatalogQueryParameters;
				}
				set
				{
					this._DBCatalogQueryParameters = value;
				}
			}
			
public string DataSourceConnectionString
			{
				get
				{
					return this._dataSourceConnectionString;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DBCatalog(string catalogName, string dataSourceConnectionString)
			{
				this._name = catalogName;
				this._DBCatalogQueryParameters = new DBCatalogQueryParameters();
				this._dataSourceConnectionString = dataSourceConnectionString;
				this._allItemsCollection = new DBCatalogItemsCollection();
				this._selectedItemsCollection = new DBCatalogItemsCollection();
			}
			
#endregion
			
#region   <  PULIC  MUST OVERRIDE  METHODS >
			
			public abstract void Load();
			
			public abstract void ReLoad();
			
			public abstract DBCatalogItemsCollection Query();
			
			public abstract DBCatalogItemsCollection Query(DBCatalogQueryParameters parameters);
			
#endregion
			
		}
		
		
		
	}
	
}
