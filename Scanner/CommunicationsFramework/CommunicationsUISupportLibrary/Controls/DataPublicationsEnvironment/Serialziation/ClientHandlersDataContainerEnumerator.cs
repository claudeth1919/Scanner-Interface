// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports


namespace CommunicationsUISupportLibrary
{
	[Serializable()]public class ClientHandlersDataContainerEnumerator : IEnumerator
	{
		
#region  < DATA MEMBERS >
		
		private IEnumerator _enumm;
		
#endregion
		
#region  < CONSTRUCTORS  >
		
		internal ClientHandlersDataContainerEnumerator(ClientHandlersDataContainer container)
		{
			this._enumm = container.HandlersTableEnumerator;
		}
		
#endregion
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IEnumerator  >
		
public dynamic Current
		{
			get
			{
				ClientHandlerData data = (ClientHandlerData) (((DictionaryEntry) this._enumm.Current).Value);
				return data;
			}
		}
		
		public bool MoveNext()
		{
			return this._enumm.MoveNext();
		}
		
		public void Reset()
		{
			this._enumm.MoveNext();
		}
		
#endregion
		
#endregion
		
		
	}
	
}
