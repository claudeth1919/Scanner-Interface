using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling.Data
	{
		
		public class DiscoverableServiceParameter
		{
			
#region  < DATAMEMBERS >
			
			private string _Name;
			private string _Value;
			
#endregion
			
#region  < PROPERTIES >
			
public string Name
			{
				get
				{
					return this._Name;
				}
			}
			
public string Value
			{
				get
				{
					return this._Value;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DiscoverableServiceParameter(string Name, string Value)
			{
				this._Name = Name;
				this._Value = Value;
			}
			
#endregion
			
			public override string ToString()
			{
				string str = "[name=" + this.Name + "],[value=" + this.Value + "]";
				return str;
			}
			
		}
		
	}
	
	
	
	
}
