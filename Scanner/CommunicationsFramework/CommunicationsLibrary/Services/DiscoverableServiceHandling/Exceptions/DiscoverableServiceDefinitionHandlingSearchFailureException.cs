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
	namespace Services.DiscoverableServiceHandling
	{
		
		
		public class DiscoverableServiceDefinitionHandlingSearchFailureException : ApplicationException
		{
			
#region  < CONSTRUCTORS >
			
			internal DiscoverableServiceDefinitionHandlingSearchFailureException(string ServiceName) : base("No such Discoverable Service \'" + ServiceName + "\' found")
			{
			}
#endregion
		}
		
		
	}
	
	
	
	
}
