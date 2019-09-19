using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.EventLoging;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme
	{
		
		public class DedicatedP2PPortsManager : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private Hashtable _dedicatedPortsTable;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public DedicatedP2PPortsManager()
			{
				this._dedicatedPortsTable = new Hashtable();
			}
			
#endregion
			
#region  < PUBLIC MEHTODS  >
			
			public void CreateDedicatedPort(object portOwner, string OwnerPortClientID, int initialPortNumberInRangeToFindAvailablePort, int finalPortNumberInRangeToFindAvailablePort)
			{
				if (!this._dedicatedPortsTable.ContainsKey(OwnerPortClientID))
				{
					P2PPort newPort = new P2PPort(portOwner, initialPortNumberInRangeToFindAvailablePort, finalPortNumberInRangeToFindAvailablePort);
					this._dedicatedPortsTable.Add(OwnerPortClientID, newPort);
				}
				else
				{
					throw (new Exception("The client specified already has a dedicated P2Pport."));
				}
			}
			
			
			public void CreateDedicatedPort(object portOwner, string OwnerPortClientID)
			{
				if (!this._dedicatedPortsTable.ContainsKey(OwnerPortClientID))
				{
					P2PPort newPort = new P2PPort(portOwner);
					this._dedicatedPortsTable.Add(OwnerPortClientID, newPort);
				}
				else
				{
					throw (new Exception("The client specified already has a dedicated P2Pport."));
				}
			}
			
			public void DisposeDedicatedPort(string OwnerPortClientID)
			{
				if (this._dedicatedPortsTable.ContainsKey(OwnerPortClientID))
				{
					P2PPort Port = default(P2PPort);
					Port = (P2PPort)this._dedicatedPortsTable[OwnerPortClientID];
					Port.Dispose();
					this._dedicatedPortsTable.Remove(OwnerPortClientID);
				}
			}
			
			public P2PPort GetPort(string OwnerPortClientID)
			{
				if (this._dedicatedPortsTable.ContainsKey(OwnerPortClientID))
				{
					return (P2PPort)this._dedicatedPortsTable[OwnerPortClientID];
				}
				else
				{
					return null;
				}
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
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
						//disposes all the available dedicated ports
						IEnumerator enumm = default(IEnumerator);
						enumm = this._dedicatedPortsTable.GetEnumerator();
						P2PPort port = default(P2PPort);
						while (enumm.MoveNext())
						{
							try
							{
								port = (P2PPort) (((DictionaryEntry) enumm.Current).Value);
								port.Dispose();
							}
							catch (Exception ex)
							{
								CustomEventLog.WriteEntry(ex);
							}
						}
						this._dedicatedPortsTable.Clear();
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
			
			
			
		}
		
	}
	
}
