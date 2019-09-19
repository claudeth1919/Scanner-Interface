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
		
		public class BroadCastRepliesContainer : IEnumerable
		{
			
			
#region  < DATAMEMBERS >
			
			private Collection _repliesList;
			private Hashtable _repliesTable;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			internal BroadCastRepliesContainer()
			{
				this._repliesList = new Collection();
				this._repliesTable = new Hashtable();
			}
			
#endregion
			
#region  < PROPERTIES >
			
            public int Count
			{
				get
				{
					return this._repliesList.Count;
				}
			}
			
			public dynamic Item(string ReplyIDName)
			{
				ReplyIDName = ReplyIDName.ToUpper();
				return this._repliesTable[ReplyIDName];
			}
			
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void Clear()
			{
				this._repliesList.Clear();
				this._repliesTable.Clear();
			}
			
			internal void AddReply(BroadCastReply reply)
			{
				this._repliesList.Add(reply, null, null, null);
				try
				{
					this._repliesTable.Add(reply.ReplyIDName, reply);
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public bool ContainsReplyIDName(string ReplyIDName)
			{
				ReplyIDName = ReplyIDName.ToUpper();
				bool RESULT = this._repliesTable.Contains(ReplyIDName);
				return RESULT;
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				BroadCastRepliesContainerEnumerator enumm = new BroadCastRepliesContainerEnumerator(this._repliesList);
				return enumm;
			}
			
#endregion
			
#endregion
			
		}
		
	}
	
	
}
