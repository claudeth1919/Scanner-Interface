using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.MultiCastDataReplication;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using UtilitiesLibrary.EventLoging;



namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Server.Handling.Publications.DataDistributionHandling
	{
		
		public class DPE_MulticastUDPPublicationDataDistributionHandler : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			private MultiCastDataReplicationServer _MultiCastDataReplicationServer;
			private string _publicationOwnerName;
			
			
#endregion
			
#region  < PROPERTIES>
			
internal string MultiCastIPAddress
			{
				get
				{
					return this._MultiCastDataReplicationServer.MultiCastIPAddress;
				}
			}
			
internal int MultiCastPortNumber
			{
				get
				{
					return this._MultiCastDataReplicationServer.MultiCastPortNumber;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_MulticastUDPPublicationDataDistributionHandler(string publicationOwnerName)
			{
				this._publicationOwnerName = publicationOwnerName;
				//creates a broadcast server
				this._MultiCastDataReplicationServer = new MultiCastDataReplicationServer(DPE_ServerDefs.INITIAL_TCP_PORT_DPE_SERVICE, DPE_ServerDefs.FINAL_TCP_PORT_DPE_SERVICE);
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void SchedulePublicationUpdate(SocketData newData)
			{
				try
				{
					//sends the compressed data to the multicast server
					byte[] compressedData = null;
                    compressedData = UtilitiesLibrary.Services.DataCompression.DataCompressionUtilities.CompressData(newData.DataBytes);
                    this._MultiCastDataReplicationServer.BroadCastData(compressedData);
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error broadcasting update for publication \'" + this._publicationOwnerName + "\' : " + ex.Message;
					CustomEventLog.WriteEntry(EventLogEntryType.Error, msg);
				}
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
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
							this._MultiCastDataReplicationServer.Dispose();
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
			
		}
		
		
		
	}
	
	
}
