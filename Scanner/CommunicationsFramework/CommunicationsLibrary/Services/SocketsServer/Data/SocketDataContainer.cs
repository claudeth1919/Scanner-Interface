using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Services.Serialization;


namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution.Data
	{
		
		[Serializable()]public class SocketDataContainer : IEnumerable, IDisposable
		{
			
			
			
#region  < DATA MEMBERS >
			
			private Collection _dataContainer;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public SocketDataContainer()
			{
				this._dataContainer = new Collection();
			}
			
#endregion
			
#region  < PROPERTIES >
			
public int Count
			{
				get
				{
					return this._dataContainer.Count;
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS  >
			
			public void AddData(SocketData data)
			{
				this._dataContainer.Add(data, null, null, null);
			}
			
			public void Clear()
			{
				this._dataContainer.Clear();
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
#region  < SHARED METHODS  >
			
			public static SocketDataContainer Deserialize(byte[] data)
			{
				return ((SocketDataContainer) (ObjectSerializer.DeserializeObjectFromByte(data)));
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IEnumerable  >
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				return this._dataContainer.GetEnumerator();
			}
			
#endregion
			
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
						this._dataContainer.Clear();
						try
						{
							this._dataContainer = null;
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
