using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using UtilitiesLibrary.EventLoging;



namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		public class CNDRemoteComponentLinkHandlerTable
		{
			
#region  < DATAMEMBERS >
			
			private Hashtable _remoteComponentLinkTable;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal CNDRemoteComponentLinkHandlerTable()
			{
				this._remoteComponentLinkTable = new Hashtable();
			}
			
#endregion
			
#region  < EVENTS >
			
			internal delegate void LinkWithRemoteComponentHasBrokenEventHandler(string ComponentName);
			private LinkWithRemoteComponentHasBrokenEventHandler LinkWithRemoteComponentHasBrokenEvent;
			
			internal event LinkWithRemoteComponentHasBrokenEventHandler LinkWithRemoteComponentHasBroken
			{
				add
				{
					LinkWithRemoteComponentHasBrokenEvent = (LinkWithRemoteComponentHasBrokenEventHandler) System.Delegate.Combine(LinkWithRemoteComponentHasBrokenEvent, value);
				}
				remove
				{
					LinkWithRemoteComponentHasBrokenEvent = (LinkWithRemoteComponentHasBrokenEventHandler) System.Delegate.Remove(LinkWithRemoteComponentHasBrokenEvent, value);
				}
			}
			
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void P2PPortClient_ConnectionLost(Services.P2PCommunicationsScheme.P2PPortClient client)
			{
				string componentName = client.ClientName;
				if (this.ContainsLinkToRemoteComponent(componentName))
				{
					try
					{
						this.DestroyLinkWithRemoteComponent(componentName);
					}
					catch (Exception)
					{
					}
					try
					{
						if (LinkWithRemoteComponentHasBrokenEvent != null)
							LinkWithRemoteComponentHasBrokenEvent(componentName);
					}
					catch (Exception)
					{
					}
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void CreateLinkWithRemoteComponent(CNDAddressingReg addressingReg)
			{
				if (this.ContainsLinkToRemoteComponent(addressingReg))
				{
					//removes the old link
					this.DestroyLinkWithRemoteComponent(addressingReg);
				}
				//creates a remote P2PPortClient in order to create a link with the remote component and know when it
				//shutdows thorugh the port client event that detects the disconnection
				Services.P2PCommunicationsScheme.P2PPortClient _remotePortClientLink = new Services.P2PCommunicationsScheme.P2PPortClient(addressingReg.HostName, addressingReg.IPAddress , addressingReg.P2PPortNumber, addressingReg.ComponentName);
				try
				{
					_remotePortClientLink.Connect();
					_remotePortClientLink.ConnectionLost += P2PPortClient_ConnectionLost;
					this._remoteComponentLinkTable.Add(addressingReg.ComponentName, _remotePortClientLink);
				}
				catch (Exception ex)
				{
					throw (new Exception("Error creating a link to remote component: " + ex.Message));
				}
			}
			
			internal void DestroyLinkWithRemoteComponent(CNDAddressingReg addressingReg)
			{
				if (this._remoteComponentLinkTable.ContainsKey(addressingReg.ComponentName))
				{
                    P2PPortClient client = (P2PPortClient)this._remoteComponentLinkTable[addressingReg.ComponentName];
					this._remoteComponentLinkTable.Remove(addressingReg.ComponentName);
					client.ConnectionLost -= P2PPortClient_ConnectionLost;
					client.Disconnect();
					client.Dispose();
				}
			}
			
			internal void DestroyLinkWithRemoteComponent(string ComponentName)
			{
				if (this._remoteComponentLinkTable.ContainsKey(ComponentName))
				{
					P2PPortClient client = (P2PPortClient)this._remoteComponentLinkTable[ComponentName];
					this._remoteComponentLinkTable.Remove(ComponentName);
					client.ConnectionLost -= P2PPortClient_ConnectionLost;
					try
					{
						client.Dispose();
					}
					catch (Exception)
					{
					}
				}
			}
			
			
			internal bool ContainsLinkToRemoteComponent(CNDAddressingReg addressingReg)
			{
				return this._remoteComponentLinkTable.ContainsKey(addressingReg.ComponentName);
			}
			
			internal bool ContainsLinkToRemoteComponent(string componentName)
			{
				componentName = componentName.ToUpper();
				return this._remoteComponentLinkTable.ContainsKey(componentName);
			}
			
			
#endregion
			
			
			
		}
		
		
	}
	
}
