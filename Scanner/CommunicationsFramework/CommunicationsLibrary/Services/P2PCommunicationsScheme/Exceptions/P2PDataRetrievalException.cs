using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme
	{
		
		public class P2PDataRetrievalException : ApplicationException
		{
			
			public P2PDataRetrievalException(P2PDataRequest request, string errorMessage) : base("Error on P2PPort operation data request of \'" + request.RequestedDataName + "\' : " + errorMessage)
			{
			}
			
		}
		
		
	}
	
	
}
