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
	namespace CNDCommunicationsEnvironment.RemoteCommunicationsHandling
	{
		
		public class RemoteComponentCommunicationsHandlersContainer : IDisposable
		{
			
			
#region  < DATAMEMBERS >
			
			private Hashtable _handlersTable;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal RemoteComponentCommunicationsHandlersContainer()
			{
				this._handlersTable = new Hashtable();
			}
			
#endregion
			
#region  < EVENT HANDLING  >
			
			private void ConnectionWithRemoteComponentLost(string RemoteComponentName)
			{
				if (this.ContainsHandlerForRemoteComponent(RemoteComponentName))
				{
					RemoteComponentComunicationsHandler handler = default(RemoteComponentComunicationsHandler);
					handler = this.GetHandler(RemoteComponentName);
					this.RemoveExistingHandler(handler);
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal void AddNewHandler(RemoteComponentComunicationsHandler handler)
			{
				if (!this._handlersTable.ContainsKey(handler.RemoteComponentName))
				{
                    this._handlersTable.Add(handler.RemoteComponentName, handler);
					handler.ConnectionWithRemoteComponentLost += ConnectionWithRemoteComponentLost;
				}
			}
			
			internal void RemoveExistingHandler(RemoteComponentComunicationsHandler handler)
			{
                if (this._handlersTable.ContainsKey(handler.RemoteComponentName))
				{
                    this._handlersTable.Remove(handler.RemoteComponentName);
					handler.ConnectionWithRemoteComponentLost -= ConnectionWithRemoteComponentLost;
				}
			}
			
			internal bool ContainsHandlerForRemoteComponent(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				return this._handlersTable.ContainsKey(ComponentName);
			}
			
			internal RemoteComponentComunicationsHandler GetHandler(string RemoteComponentName)
			{
				RemoteComponentName = RemoteComponentName.ToUpper();
                return (RemoteComponentComunicationsHandler)this._handlersTable[RemoteComponentName];
			}
			
			internal void DisposeAllHandlers()
			{
				try
				{
					IEnumerator enumm = this._handlersTable.GetEnumerator();
					RemoteComponentComunicationsHandler handler = default(RemoteComponentComunicationsHandler);
					while (enumm.MoveNext())
					{
						handler = (RemoteComponentComunicationsHandler) (((DictionaryEntry) enumm.Current).Value);
						try
						{
							handler.Dispose();
						}
						catch (Exception)
						{
						}
						handler.ConnectionWithRemoteComponentLost -= ConnectionWithRemoteComponentLost;
					}
					this._handlersTable.Clear();
				}
				catch (Exception)
				{
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
						this.DisposeAllHandlers();
					}
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
