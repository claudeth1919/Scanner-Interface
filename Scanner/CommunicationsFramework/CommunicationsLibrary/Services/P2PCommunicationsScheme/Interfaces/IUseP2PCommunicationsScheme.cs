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
		
		public interface IUseP2PCommunicationsScheme
		{
			
#region  < PROPERTIES  >
			
			P2PPort P2PSocketPort {get;}
			string P2PPortOwnerName {get;}
			
#endregion
			
#region  < METHODS >
			
			void ReceiveData(P2PData data, int HandlerP2PPortNumber);
			P2PData RetrieveData(P2PDataRequest request, int HandlerP2PPortNumber);
			
#endregion
			
		}
		
		
		
	}
	
	
}
