using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsLibrary.Services.BroadCasting.Handling;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling.Data
	{
		
		public class DiscoverableServiceDefinitionsContainerEnumerator : IEnumerator
		{
			
			
#region  < DATAMEMBERS >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DiscoverableServiceDefinitionsContainerEnumerator(DiscoverableServiceDefinitionsContainer container)
			{
				this._enumerator = container.DefinitionsList.GetEnumerator();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
public dynamic Current
			{
				get
				{
					DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition defintition = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
                    defintition = (DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition)this._enumerator.Current;
					return defintition;
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
