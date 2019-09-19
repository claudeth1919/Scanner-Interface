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
	namespace Services.SocketsDataDistribution.ClientConnectionsHandling
	{
		
		public class SocketsServerClientConnectionsHandlerTable : IEnumerable, ICloneable
		{
			
			
			
#region  < DATA MEMBERS >
			
			private Hashtable _ClientsSocketHandlerTable;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal SocketsServerClientConnectionsHandlerTable()
			{
				this._ClientsSocketHandlerTable = new Hashtable();
			}
			
#endregion
			
#region  <  PUBLIC METHODS >
			
			internal void AddClientSocketHandler(SocketsServerClientConnectionHandler ClientSocketHandler)
			{
				if (!this._ClientsSocketHandlerTable.Contains(ClientSocketHandler.ClientID))
				{
					this._ClientsSocketHandlerTable.Add(ClientSocketHandler.ClientID, ClientSocketHandler);
				}
				else
				{
					throw (new Exception("The client " + ClientSocketHandler.IdentityString + " is already contained in the handling Table"));
				}
			}
			
			internal void RemoveClientSocketHandler(SocketsServerClientConnectionHandler ClientSocketHandler)
			{
				if (this._ClientsSocketHandlerTable.Contains(ClientSocketHandler.ClientID))
				{
					this._ClientsSocketHandlerTable.Remove(ClientSocketHandler.ClientID);
				}
				else
				{
					throw (new Exception("The client " + ClientSocketHandler.IdentityString + " is not registered the handling Table"));
				}
			}
			
			internal SocketsServerClientConnectionHandler GetClientConnectionHandler(string ClientID)
			{
				if (this._ClientsSocketHandlerTable.ContainsKey(ClientID))
				{
                    return (SocketsServerClientConnectionHandler)this._ClientsSocketHandlerTable[ClientID];
				}
				else
				{
					return null;
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
internal int NumOfConnectedClients
			{
				get
				{
					return this._ClientsSocketHandlerTable.Count;
				}
			}
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerator >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				SocketsServerClientConnectionsHandlerTableEnumerator enumerator = new SocketsServerClientConnectionsHandlerTableEnumerator(this._ClientsSocketHandlerTable.GetEnumerator());
				return enumerator;
			}
			
#endregion
			
#region  < ICloneable >
			
			public dynamic Clone()
			{
				SocketsServerClientConnectionsHandlerTable newTable = new SocketsServerClientConnectionsHandlerTable();
				IEnumerator enumm = default(IEnumerator);
				SocketsServerClientConnectionHandler client = default(SocketsServerClientConnectionHandler);
				enumm = this.GetEnumerator();
				while (enumm.MoveNext())
				{
                    client = (SocketsServerClientConnectionHandler)enumm.Current;
					newTable.AddClientSocketHandler(client);
				}
				return newTable;
			}
			
#endregion
			
#endregion
			
			
			
		}
		
	}
	
	
}
