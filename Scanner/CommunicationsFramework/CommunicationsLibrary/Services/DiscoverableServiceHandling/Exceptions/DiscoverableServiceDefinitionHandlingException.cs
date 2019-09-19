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
		
		
		public class DiscoverableServiceDefinitionHandlingException : ApplicationException
		{
			
            #region  < CONSTRUCTORS >
			
			internal DiscoverableServiceDefinitionHandlingException(string ServiceName, string parameterName) : base("Error in the replied definition of a service " + ServiceName.ToUpper() + " found. The parameter " + parameterName.ToUpper() + " is missing in the parameters table")
			{
			}
#endregion

		}
		
		
	}
	
	
	
	
}
