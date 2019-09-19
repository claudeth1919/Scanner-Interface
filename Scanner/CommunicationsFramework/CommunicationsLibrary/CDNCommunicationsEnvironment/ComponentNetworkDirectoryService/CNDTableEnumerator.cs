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
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		public class CNDTableEnumerator : IEnumerator
		{
			
#region  < DATAMEMBERS >
			
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal CNDTableEnumerator(CNDTable table)
			{
				this._enumerator = table.DataTable.Rows.GetEnumerator();
			}
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
            public dynamic Current
			{
				get
				{
					DataRow row = (DataRow )this._enumerator.Current;
					string compName = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME]);
					string hostName = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_HOST_NAME]);
					string P2PPortNumber = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_P2P_PORT_NUMBER]);
					string IPAddress = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_IP_ADDRESS]);
					string ApplicationName = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_APPLICATION_NAME]);
					string ApplicationProcessID = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_APPLICATION_PROCESS_ID]);
					string RegistrationDateTime = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_REGISTRATION_DATETIME]);
                    int portNumber = Convert.ToInt32(P2PPortNumber);
                    CNDAddressingReg reg = new CNDAddressingReg(compName, hostName, IPAddress, portNumber, ApplicationName, ApplicationProcessID, RegistrationDateTime);
					return reg;
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
