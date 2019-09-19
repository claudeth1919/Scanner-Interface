using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary;


namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.LocalCommunicationsHandling
	{
		
		internal class LocalComponentCommunicationsHandlersContainer : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private Hashtable _componentCommunicationsHandlersTable;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal LocalComponentCommunicationsHandlersContainer()
			{
				this._componentCommunicationsHandlersTable = new Hashtable();
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void AddNewHandler(LocalComponentCommunicationsHandler handler)
			{
				if (!this._componentCommunicationsHandlersTable.ContainsKey(handler.OwnerComponentName))
				{
					this._componentCommunicationsHandlersTable.Add(handler.OwnerComponentName, handler);
				}
			}
			
			internal void RemoveExistingHandler(LocalComponentCommunicationsHandler handler)
			{
				if (this._componentCommunicationsHandlersTable.ContainsKey(handler.OwnerComponentName))
				{
					this._componentCommunicationsHandlersTable.Remove(handler.OwnerComponentName);
				}
			}
			
			internal bool ContainsHandlerForComponent(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				return this._componentCommunicationsHandlersTable.ContainsKey(ComponentName);
			}
			
			internal LocalComponentCommunicationsHandler GetHandler(string LocalComponentName)
			{
				LocalComponentName = LocalComponentName.ToUpper();
				return (LocalComponentCommunicationsHandler)this._componentCommunicationsHandlersTable[LocalComponentName];
			}
			
			
			internal void DisposeAllHandlers()
			{
				try
				{
					IEnumerator enumm = this._componentCommunicationsHandlersTable.GetEnumerator();
					LocalComponentCommunicationsHandler handler = default(LocalComponentCommunicationsHandler);
					while (enumm.MoveNext())
					{
						handler = (LocalComponentCommunicationsHandler) (((DictionaryEntry) enumm.Current).Value);
						try
						{
							handler.Dispose();
						}
						catch (Exception)
						{
						}
					}
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IDisposable>
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						this.DisposeAllHandlers();
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
