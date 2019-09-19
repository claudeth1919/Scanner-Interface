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
		
		public class SocketsServerClientConnectionsHandlerTableEnumerator : IEnumerator
		{
			
			
#region  < DATAMEMBERS  >
			
			private IEnumerator _enumerator;
			
#endregion
			
#region  < CONSTRUCTOR >
			
			internal SocketsServerClientConnectionsHandlerTableEnumerator(IEnumerator handlersEnumerator)
			{
				this._enumerator = handlersEnumerator;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerator >
			
public dynamic Current
			{
				get
				{
					DictionaryEntry dicentry = new DictionaryEntry();
                    dicentry = (DictionaryEntry)this._enumerator.Current;
					SocketsServerClientConnectionHandler handler = default(SocketsServerClientConnectionHandler);
                    handler = (SocketsServerClientConnectionHandler)dicentry.Value;
					return handler;
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
			
			
#endregion
			
		}
		
	}
	
	
	
}
