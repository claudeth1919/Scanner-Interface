using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using UtilitiesLibrary.Parametrization;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications
	{
		
		
		public class DPE_PublicationData : IDisposable
		{
			
			
#region  < DATAMEMBERS >
			
			
			private string _publicationName;
			private object _data;
			private string _dataname;
			private DPE_ServerDefs.PublicationVariableDataType _dataType;
			private AttributesTable _parametersTable = new AttributesTable();
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public DPE_PublicationData(string PublicationName, string dataname, string data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, int data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, decimal data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, bool data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, DataTable data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, DataSet data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataSet;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, CustomHashTable data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFHashTable;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, CustomList data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFList;
			}
			
			public DPE_PublicationData(string PublicationName, string dataname, CustomSortedList data)
			{
				this._publicationName = PublicationName;
				this._dataname = dataname.ToUpper();
				this._data = data;
				this._dataType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFSortedList;
			}
			
#endregion
			
#region  < PROPERTIES >
			
			
public string PublicationName
			{
				get
				{
					return this._publicationName;
				}
			}
			
public string VariableName
			{
				get
				{
					return this._dataname;
				}
			}
			
public dynamic Value
			{
				get
				{
					return this._data;
				}
			}
			
public DPE_ServerDefs.PublicationVariableDataType DataType
			{
				get
				{
					return this._dataType;
				}
			}
			
public AttributesTable DataAttributesTable
			{
				get
				{
					return this._parametersTable;
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SetPublicationHolder(DPE_Publication Publication)
			{
				this._publicationName = Publication.PublicationName;
			}
			
			internal void AttachAttibutesTable(AttributesTable table)
			{
				try
				{
					this._parametersTable = null;
				}
				catch (Exception)
				{
				}
				this._parametersTable = table;
			}
			
#endregion
			
#region  <  SHARED METHODS >
			
			public static DPE_PublicationData GetSTXDSS_PublicationData(string PublicationName, string dataname, object data)
			{
				string typeAsString = data.GetType().ToString();
				switch (typeAsString)
				{
					case "System.String":
						return new DPE_PublicationData(PublicationName, dataname, System.Convert.ToString(data));
					case "System.Int32":
						return new DPE_PublicationData(PublicationName, dataname, System.Convert.ToInt32(data));
					case "System.Decimal":
						return new DPE_PublicationData(PublicationName, dataname, System.Convert.ToDecimal(data));
					case "System.Boolean":
						return new DPE_PublicationData(PublicationName, dataname, System.Convert.ToString(System.Convert.ToBoolean(data)));
					case "System.Data.DataTable":
						return new DPE_PublicationData(PublicationName, dataname, (DataTable) data);
					case "System.Data.DataSet":
						break;
						// Return New STXDSS_PublicationData(PublicationName, dataname, CType(data, DataSet))
					case "UtilitiesLibrary.Data.CustomHashTable":
						return new DPE_PublicationData(PublicationName, dataname, (UtilitiesLibrary.Data.CustomHashTable) data);
					case "UtilitiesLibrary.Data.CustomList":
						return new DPE_PublicationData(PublicationName, dataname, (CustomList) data);
					case "UtilitiesLibrary.Data.CustomSortedList":
						return new DPE_PublicationData(PublicationName, dataname, (CustomSortedList) data);
					default:
						throw (new Exception("Unsupported data type \'" + typeAsString + "\' for a Data Publication."));
				}
				return null;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  IDisposable Support
			
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).\
						try
						{
							this._data = null;
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._dataname = null;
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._parametersTable = null;
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._publicationName = null;
						}
						catch (Exception)
						{
						}
					}
					
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
#endregion
			
#endregion
			
			
			
		}
		
		
	}
	
	
	
}
