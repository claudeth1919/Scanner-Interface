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
		
		public class DiscoverableServiceDefinitionsContainer : IEnumerable
		{
			
			
			
#region  < DATA MEMBERS >
			
			private Collection _DefinitionsList;
			
#endregion
			
#region  < properties  >
			
internal Collection DefinitionsList
			{
				get
				{
					return this._DefinitionsList;
				}
			}
			
#endregion
			
#region  < COSNTRUCTORS >
			
			internal DiscoverableServiceDefinitionsContainer()
			{
				this._DefinitionsList = new Collection();
			}
			
#endregion
			
#region  < FRIEND METHODS  >
			
			internal void AddDefinition(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition definition)
			{
				this._DefinitionsList.Add(definition, null, null, null);
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				DiscoverableServiceDefinitionsContainerEnumerator enumm = new DiscoverableServiceDefinitionsContainerEnumerator(this);
				return enumm;
			}
			
#endregion
			
#endregion
			
			
		}
		
		
		
		
	}
	
}
