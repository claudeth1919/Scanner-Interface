using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling.Data
	{
		
		public class DiscoverableServiceDefinitionParametersContainerEnumerator : IEnumerator
		{
			
			
#region  < DATA MEMBERS >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DiscoverableServiceDefinitionParametersContainerEnumerator(CustomHashTable parametersTable)
			{
				this._enumerator = parametersTable.GetEnumerator();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerator >
			
            public dynamic Current
			{
				get
				{
					DiscoverableServiceParameter ServiceParameter = default(DiscoverableServiceParameter);
					DictionaryEntry dicEntry = new DictionaryEntry();
                    dicEntry = (DictionaryEntry)this._enumerator.Current;
					string paramName = System.Convert.ToString(dicEntry.Key);
					string paramVAlue = System.Convert.ToString(dicEntry.Value);
					ServiceParameter = new DiscoverableServiceParameter(paramName, paramVAlue);
					return ServiceParameter;
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
