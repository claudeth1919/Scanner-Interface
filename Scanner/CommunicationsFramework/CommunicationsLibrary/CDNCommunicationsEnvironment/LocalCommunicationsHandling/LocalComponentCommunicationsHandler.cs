using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.Services;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Data;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Interfaces;
	
	
	
	namespace CommunicationsLibrary
	{
		namespace CNDCommunicationsEnvironment.LocalCommunicationsHandling
		{
			
			internal class LocalComponentCommunicationsHandler : IUseP2PCommunicationsScheme, IDisposable
			{
				
#region  < DATAMEMBERS >
				
			private P2PPort _p2pPort;
			private object _componentOwner;
			private int _listeningPort;
			private string _p2pPortOwnerName;
			
#endregion
			
#region  < PROPERTIES  >
			
internal string OwnerComponentName
			{
				get
				{
					return this._p2pPortOwnerName;
				}
			}
			
internal int ListeningPortNumber
			{
				get
				{
					return this._p2pPort.ListeningPortNumber;
				}
			}
			
internal DataTable PortDataReceptionStatisticsTable
			{
				get
				{
					return this._p2pPort.Statistics.DataReceptionStatisticsTable;
				}
			}
			
internal DataTable PortDataRequestStatisticsTable
			{
				get
				{
					return this._p2pPort.Statistics.DataRequestsStatisticsTable;
				}
			}
			
internal DataTable portGeneralStatisticsTable
			{
				get
				{
					return this._p2pPort.Statistics.GeneralStatisticsTable;
				}
			}
			
#endregion
			
#region  < CONSTUCTORS >
			
			internal LocalComponentCommunicationsHandler(object componentObject)
			{
				if (!(componentObject is CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme))
				{
					throw (new Exception("Can\'t create a communications handler for the specified object because it must implements the \'IUseCNDCommunicationsScheme\' interface"));
				}
				this._componentOwner = componentObject;
				this._p2pPort = new P2PPort(this, CNDCommunicationsEnvironmentDefinitions.INITIAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT, CNDCommunicationsEnvironmentDefinitions.FINAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT);
				this._p2pPort.NewClientConnection += this.ClientDisconnection;
				this._p2pPort.ClientDisconnection += this.ClientDisconnection;
				this._listeningPort = this._p2pPort.ListeningPortNumber;
				this._p2pPortOwnerName = ((CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme) this._componentOwner).ComponentName;
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void NewClientConnection(string clientID)
			{
				
			}

            private void ClientDisconnection(string clientID)
			{
				
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
    #region  < IUseP2PCommunicationsScheme >
			
            public string P2PPortOwnerName
			{
				get
				{
					return this._p2pPortOwnerName;
				}
			}
			
            public Services.P2PCommunicationsScheme.P2PPort P2PSocketPort
			{
				get
				{
					return this._p2pPort;
				}
			}
			
			public void ReceiveData(Services.P2PCommunicationsScheme.Data.P2PData data, int P2PPortNumber)
			{
				
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				
				if (!data.DataAttributesTable.ContainsAttribute("DATA_TYPE"))
				{
					throw (new Exception("Can\'t process the Communications data because the attribute \'DATA_TYPE\' is missing"));
				}
				else
				{
					attr = data.DataAttributesTable.GetAttribute("DATA_TYPE");
					if (attr.AttrValue != "CommunicationsData")
					{
						throw (new Exception("Invalid P2PData in the \'ComponentCommunicationsHandler\' environment"));
					}
					data.DataAttributesTable.RemoveAttribute("DATA_TYPE");
				}
				
				string adresseComponentName = "";
				
				if (!data.DataAttributesTable.ContainsAttribute("ADDRESSE_COMPONENT"))
				{
					throw (new Exception("Can\'t process the Communications data because the attribute \'ADDRESSE_COMPONENT\' is missing"));
				}
				else
				{
					attr = data.DataAttributesTable.GetAttribute("ADDRESSE_COMPONENT");
					adresseComponentName = attr.AttrValue;
					data.DataAttributesTable.RemoveAttribute("ADDRESSE_COMPONENT");
				}
				
				string senderComponentName = "";
				if (!data.DataAttributesTable.ContainsAttribute("SENDER_COMPONENT"))
				{
					throw (new Exception("Can\'t process the Communications data because the attribute \'SENDER_COMPONENT\' is missing"));
				}
				else
				{
					attr = data.DataAttributesTable.GetAttribute("SENDER_COMPONENT");
					senderComponentName = attr.AttrValue;
					data.DataAttributesTable.RemoveAttribute("SENDER_COMPONENT");
				}
				
				CommunicationsData commsData = default(CommunicationsData);
				commsData = CommunicationsData.GetCommunicationsDataObject(adresseComponentName, senderComponentName, System.Convert.ToString(data.DataName), data.Value);
				
				
				P2PDataAttributesTableEnumerator paramsAttrEnum = default(P2PDataAttributesTableEnumerator);
                paramsAttrEnum = (P2PDataAttributesTableEnumerator)data.DataAttributesTable.GetEnumerator();
				
				while (paramsAttrEnum.MoveNext())
				{
					attr = paramsAttrEnum.Current;
					commsData.AddDataAttribute(attr.AttrName, attr.AttrValue);
				}
				
				((CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme) this._componentOwner).ReceiveData(commsData);
			}
			
			public Services.P2PCommunicationsScheme.Data.P2PData RetrieveData(Services.P2PCommunicationsScheme.Data.P2PDataRequest request, int P2PPortNumber)
			{
				
				string adresseComponentName = System.Convert.ToString(request.GetRequestParameter("ADDRESSE_COMPONENT"));
				if (adresseComponentName == null)
				{
					throw (new Exception("Can\'t retrieve data because the parameter \'ADDRESSE_COMPONENT\' was missing in the request structure"));
				}
				
				string senderComponentName = System.Convert.ToString(request.GetRequestParameter("SENDER_COMPONENT"));
				if (senderComponentName == null)
				{
					throw (new Exception("Can\'t retrieve data because the parameter \'SENDER_COMPONENT\' was missing in the request structure"));
				}
				
				CNDCommunicationsEnvironment.Data.CommunicationsDataRequest commdDataRequest = new CNDCommunicationsEnvironment.Data.CommunicationsDataRequest(adresseComponentName, senderComponentName, System.Convert.ToString(request.RequestedDataName));
				
				CommunicationsData dataResult = ((CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme) this._componentOwner).RetrieveDataToRemoteComponent(commdDataRequest);
				
				P2PData resultData = P2PData.GetP2PDataObject(dataResult.P2PData.DataName, dataResult.P2PData.Value);
				
				return resultData;
			}
			
#endregion
			
#region  < IDisposable >
			
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						try
						{
							this._p2pPort.Dispose();
						}
						catch (Exception)
						{
						}
						
					}
					
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
			
#endregion
			
#endregion

#region < FRIEND METHODS > 

    internal CNDSErviceRegistrationData GetRegistrationInformation()
    {
        CNDSErviceRegistrationData CNDRegistrationData = new CNDSErviceRegistrationData();
        CNDRegistrationData.ComponentName = this.OwnerComponentName;
        CNDRegistrationData.ApplicationName = System.AppDomain.CurrentDomain.FriendlyName;
        CNDRegistrationData.HostName = System.Net.Dns.GetHostName();
        CNDRegistrationData.ListeningPort = this.P2PSocketPort.ListeningPortNumber;
        CNDRegistrationData.IPAddress = this.P2PSocketPort.IPAddress;
        return CNDRegistrationData;
    }

#endregion 


            }
		
	}
	
	
	
}
