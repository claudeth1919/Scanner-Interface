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
		
		public class P2PDataRetrievalUnexpectedException : ApplicationException
		{
			
			public P2PDataRetrievalUnexpectedException(P2PDataRequest request, string errorMessage) : base("Unexpected Error on P2P port client operation retrieving data \'" + request.RequestedDataName + "\' : " + errorMessage)
			{
			}
			
			public P2PDataRetrievalUnexpectedException(P2PDataRequest request) : base("Unexpected Error on P2P port client operation retrieving data \'" + request.RequestedDataName + "\'")
			{
			}
			
		}
		
		
	}
	
	
}
