using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;


namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution.ClientStatistics
	{
		
		public class SocketsSeverClientStatisticsManager : IDisposable
		{
			
#region  < STRUCTURE  >
			
			public struct DataSocketClientStatsRegister
			{
				public SocketsServerClientConnectionHandler clientHandlera;
			}
#endregion
			
#region  < DATA MEMBERS  >
			
			private DataTable _DataReceptionStatiticalTable;
			private Queue _incommingStatiticalDataLogQueue;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal SocketsSeverClientStatisticsManager()
			{
				this._incommingStatiticalDataLogQueue = new Queue();
				this.CreateClientDataReceptionStatistics();
			}
			
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private void CreateClientDataReceptionStatistics()
			{
				DataColumn column = default(DataColumn);
				try
				{
					//creation of the table
					this._DataReceptionStatiticalTable = new DataTable("DataReceptionStatiticalTable");
					
					//creation of the clientName Name column
					column = new DataColumn("ClientName", Type.GetType("System.String"));
					column.Caption = "Client Name";
					this._DataReceptionStatiticalTable.Columns.Add(column);
					
					
					column = new DataColumn("ClientIDString", Type.GetType("System.String"));
					column.Caption = "Client Identification";
					column.Unique = true;
					this._DataReceptionStatiticalTable.Columns.Add(column);
					
					column = new DataColumn("FirstReceptionDateTime", Type.GetType("System.DateTime"));
					column.Caption = "First Reception";
					this._DataReceptionStatiticalTable.Columns.Add(column);
					
					column = new DataColumn("LastReceptionDateTime", Type.GetType("System.DateTime"));
					column.Caption = "Last Reception";
					this._DataReceptionStatiticalTable.Columns.Add(column);
					
					column = new DataColumn("NoDataReceivedFromClient", Type.GetType("System.Integer"));
					column.Caption = "No. Data Reception Events";
					this._DataReceptionStatiticalTable.Columns.Add(column);
					
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			//Friend Sub RegisterClientDataReception(ByVal client As SocketsServerClientConnectionHandler)
			//    Try
			//        SyncLock Me._incommingStatiticalDataLogQueue
			//            Me._incommingStatiticalDataLogQueue.Enqueue(client)
			//        End SyncLock
			//        Dim newLogThred As New Threading.Thread(AddressOf StatisticalDataReceptionTransaction)
			//    Catch ex As Exception
			//    End Try
			//End Sub
			
#endregion
			
#region  < THREADING >
			
			//Private Sub StatisticalDataReceptionTransaction()
			//    Dim client As SocketsServerClientConnectionHandler
			//    Try
			//        SyncLock Me._incommingStatiticalDataLogQueue
			//            client = Me._incommingStatiticalDataLogQueue.Dequeue
			//        End SyncLock
			
			//        Dim selectionCreteria As String = "ClientIDString = '" & client.IdentityString & "'"
			//        Dim resultRows() As DataRow = Me._DataReceptionStatiticalTable.Select(selectionCreteria)
			//        If resultRows.Length <= 0 Then
			//            'the client is not registered in the table
			//            'Dim newClientDataRow As
			//        Else
			//            'the client exisits in the table
			
			//        End If
			
			//    Catch ex As Exception
			//    Finally
			//        Threading.Thread.Sleep(0)
			//    End Try
			
			//End Sub
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDisposible >
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
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
