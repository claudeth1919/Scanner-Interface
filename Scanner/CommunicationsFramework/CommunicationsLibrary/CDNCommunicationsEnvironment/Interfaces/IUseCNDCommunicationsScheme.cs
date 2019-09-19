using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Data;



namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.Interfaces
	{
		
		public interface IUseCNDCommunicationsScheme
		{
			
#region < INTERFACE INFORMATION >
			
#endregion
			
#region < PROCEDURES >
			
			string ComponentName {get;}
			
			void SubscribeToCommunicationsService();
			void UnsubscribeFromCommunicationsService();
			
			void SendData(CommunicationsData data);
			CommunicationsData RequestDataFromRemoteComponent(CNDCommunicationsEnvironment.Data.CommunicationsDataRequest dataRequest);
			CommunicationsData RetrieveDataToRemoteComponent(CNDCommunicationsEnvironment.Data.CommunicationsDataRequest dataRequest);
			void ReceiveData(CommunicationsData data);
			
#endregion
			
			
			
		}
		
		
	}
	
	
	
}
