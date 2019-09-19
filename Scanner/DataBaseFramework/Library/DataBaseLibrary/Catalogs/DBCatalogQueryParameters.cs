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
		
		[Serializable()]public class DBCatalogQueryParameters
		{
			
#region  < DATAMEMBERS >
			
			private Hashtable _parameters;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DBCatalogQueryParameters()
			{
				this._parameters = new Hashtable();
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddParameter(string parameterName, ICatalogItem item)
			{
				parameterName = parameterName.ToUpper();
				if (this._parameters.ContainsKey(parameterName))
				{
					this._parameters.Remove(parameterName);
				}
				this._parameters.Add(parameterName, item);
			}
			
			public void ClearParameters()
			{
				this._parameters.Clear();
			}
			
			public ICatalogItem GetParameter(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				return (ICatalogItem) (this._parameters[parameterName]);
			}
			
			public int GetParameterCatalogID(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				ICatalogItem item = (ICatalogItem) (this._parameters[parameterName]);
				return System.Convert.ToInt32(item.ID);
			}
			
			public bool ContainsParameter(string parameterName)
			{
				parameterName = parameterName.ToUpper();
				return this._parameters.ContainsKey(parameterName);
			}
			
#endregion
			
		}
		
		
		
	}
	
}
