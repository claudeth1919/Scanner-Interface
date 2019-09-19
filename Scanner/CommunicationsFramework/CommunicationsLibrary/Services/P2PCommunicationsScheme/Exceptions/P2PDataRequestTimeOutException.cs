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
		
		public class P2PDataRequestTimeOutException : ApplicationException
		{
			
			public P2PDataRequestTimeOutException(P2PDataRequest request) : base("Time out on P2PPort data request operation of data :" + request.RequestedDataName + "\'.")
			{
			}
			
			public P2PDataRequestTimeOutException() : base("Time out on P2PPort data Request operation.")
			{
			}
			
		}
		
		
	}
	
	
}
