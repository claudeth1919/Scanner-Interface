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
		
		
		public class P2PDataAttributesTableEnumerator : IEnumerator
		{
			
			
#region  < DATAMEMBERS >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCORS >
			
			internal P2PDataAttributesTableEnumerator(CustomHashTable attrList)
			{
				this._enumerator = attrList.GetEnumerator();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
public dynamic Current
			{
				get
				{
					DictionaryEntry dicEntry = new DictionaryEntry();
                    dicEntry = (DictionaryEntry)this._enumerator.Current;
					P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
					attr.AttrName = System.Convert.ToString(dicEntry.Key);
					attr.AttrValue = System.Convert.ToString(dicEntry.Value);
					return attr;
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
			
			
		}
		
		
	}
	
	
	
	
	
}
