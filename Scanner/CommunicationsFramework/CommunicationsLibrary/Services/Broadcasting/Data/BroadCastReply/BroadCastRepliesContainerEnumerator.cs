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
	namespace Services.BroadCasting.Data
	{
		
		public class BroadCastRepliesContainerEnumerator : IEnumerator
		{
			
			
#region  < DATA MEMBERS >
			
			private IEnumerator _enumerator;
			
#endregion
			
			
#region  < CONSTRUCTORS >
			
			internal BroadCastRepliesContainerEnumerator(Collection replyesCollection)
			{
				this._enumerator = replyesCollection.GetEnumerator();
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
			
			
#region  < IEnumerator >
			
public dynamic Current
			{
				get
				{
					BroadCastReply broadCastReply = default(BroadCastReply);
					broadCastReply = (BroadCastReply) this._enumerator.Current;
					return broadCastReply;
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
