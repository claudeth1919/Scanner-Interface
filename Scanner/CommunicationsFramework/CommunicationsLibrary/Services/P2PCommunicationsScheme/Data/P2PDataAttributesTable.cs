using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme.Data
	{
		
		[Serializable()]public class P2PDataAttributesTable : IEnumerable
		{
			
#region  < DATAMEMBERS >
			
			[Serializable()]public struct P2PDataAttribute
			{
				public string AttrName;
				public string AttrValue;
			}
			
			
			private CustomHashTable _parametersList;
			
#endregion
			
#region  < PROPERTIES >
			
            public int count
			{
				get
				{
					return this._parametersList.Count;
				}
			}			

            internal CustomHashTable Table
			{
				get
				{
					return this._parametersList;
				}
			}
			
			public P2PDataAttribute GetAttribute(string attrName)
			{
				attrName = attrName.ToUpper();
				if (this._parametersList.ContainsKey(attrName))
				{
					P2PDataAttribute attr = new P2PDataAttribute();
					string value = System.Convert.ToString(this._parametersList.Item(attrName));
					attr.AttrName = attrName;
					attr.AttrValue = value;
					return attr;
				}
				else
				{
                    throw new Exception("Can not find parameter " + attrName);
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal P2PDataAttributesTable()
			{
				this._parametersList = new CustomHashTable();
			}
			
			internal P2PDataAttributesTable(CustomHashTable attrList)
			{
				this._parametersList = attrList;
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddAttribute(string attrName, string attrValue)
			{
				attrName = attrName.ToUpper();
				if (!this._parametersList.ContainsKey(attrName))
				{
					this._parametersList.Add(attrName, attrValue);
				}
				else
				{
					throw (new Exception("The attribute " + attrName + " is already included in the attributes list"));
				}
			}
			
			public void RemoveAttribute(string attrName)
			{
				attrName = attrName.ToUpper();
				if (this._parametersList.ContainsKey(attrName))
				{
					this._parametersList.Remove(attrName);
				}
				else
				{
					throw (new Exception("The attribute " + attrName + " is not included in the list"));
				}
			}
			
			public void UpdateAttribute(string attrName, string NewAttrValue)
			{
				try
				{
					this.RemoveAttribute(attrName);
				}
				catch (Exception)
				{
				}
				try
				{
					this.AddAttribute(attrName, NewAttrValue);
				}
				catch (Exception)
				{
					
				}
			}
			
			public bool ContainsAttribute(string attrName)
			{
				attrName = attrName.ToUpper();
				return this._parametersList.ContainsKey(attrName);
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				P2PDataAttributesTableEnumerator enumm = new P2PDataAttributesTableEnumerator(this._parametersList);
				return enumm;
			}
			
#endregion
			
#endregion
			
			
		}
		
		
	}
	
	
}
