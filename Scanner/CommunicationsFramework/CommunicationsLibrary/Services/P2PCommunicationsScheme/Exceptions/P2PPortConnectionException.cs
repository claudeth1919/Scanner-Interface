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
		
		public class P2PPortConnectionException : ApplicationException
		{
			
			public P2PPortConnectionException() : base("The connection with remote P2PPort gone lost when waiting a response for DATA SEND or DATA REQUEST operation")
			{
			}
			
		}
		
		
	}
	
	
}
