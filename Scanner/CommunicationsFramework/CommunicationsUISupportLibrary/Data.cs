// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using UtilitiesLibrary.Data;


namespace CommunicationsUISupportLibrary
{
	[Serializable()]public class Data
	{
		private string _dataName;
		private object _data;
		
#region  < CONSTRUCTORS >
		
		private Data(string dataname, object data)
		{
			this._dataName = dataname.ToUpper();
			this._data = data;
		}
		
		public Data(string dataname, int data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, decimal data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, string data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, bool data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, DataSet data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, DataTable data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, CustomHashTable data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, CustomList data) : this(dataname, (object) data)
		{
		}
		
		public Data(string dataname, CustomSortedList data) : this(dataname, (object) data)
		{
		}
		
		
#endregion
		
#region  < PROPERTIES >
		
public string DataName
		{
			get
			{
				return this._dataName;
			}
		}
		
public dynamic data
		{
			get
			{
				return this._data;
			}
		}
		
#endregion
		
		
		public override string ToString()
		{
			return this._dataName;
		}
		
	}
}
