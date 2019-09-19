using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Threading;
using CommunicationsLibrary.Services;
using CommunicationsLibrary.Utilities;
using UtilitiesLibrary.EventLoging;


namespace CommunicationsLibrary
{
	namespace Services.TCPPortsManagement
	{
		
		public class TCPPortsRangeFinderHandler : IDisposable
		{
			
			
#region  < DATAMEMBERS >
			
			private int _portsRangeLowerLimit;
			private int _portsRangeUpperLimit;
			private int _LastAssignedPortNumber;
			
			private bool _IsHandlerPerformingPortsSearching;
			
			private string _handlerID;
			private SortedList _availablePortsList;
			
			private const int AVAILABLE_PORTS_QUEUE_MIN_SIZE = 100;
			private const int AVAILABLE_PORTS_QUEUE_MAX_SIZE = 400;
       
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public TCPPortsRangeFinderHandler(int portsLowerLimit, int portsUpperLimit)
			{
				if (portsLowerLimit < portsUpperLimit)
				{
					this._portsRangeLowerLimit = portsLowerLimit;
					this._portsRangeUpperLimit = portsUpperLimit;
				}
				else
				{
					this._portsRangeLowerLimit = portsUpperLimit;
					this._portsRangeUpperLimit = portsLowerLimit;
				}
				
				this._handlerID = System.Convert.ToString(this._portsRangeLowerLimit) + System.Convert.ToString(this._portsRangeUpperLimit);
				
				this._availablePortsList = new SortedList();
				
				this._LastAssignedPortNumber = -1;
				
				this._IsHandlerPerformingPortsSearching = false;
				this.SchedulePortsSearchingTask();
				
			}
			
#endregion
			
#region  < PROPERTIES >
			
            public SortedList availableTCPPortsTable
			{
				get
				{
                    return (SortedList)this._availablePortsList.Clone();
				}
			}
			
#endregion
			
#region  <  THREADING >
			
			private void SearchAvailableTCPPorts_ThreadFcn()
			{
				
				this._IsHandlerPerformingPortsSearching = true;
				
				
				int portsFound = 0;
				SortedList openPortsList = default(SortedList);
				int portNumber = 0;
				
				DateTime noww = DateTime.Now;
				
				portsFound = 0;
				
				int searchStartLowerLimit = 0;
				int searchStartUpperLimit = 0;
				
				
				//no ports in the queue to be retrieves as free
				while (portsFound < AVAILABLE_PORTS_QUEUE_MAX_SIZE)
				{
					
					lock(this._availablePortsList)
					{
						
						if (this._availablePortsList.Count > 0)
						{
							//gets the upper current limit
							int lastPortFound = 0;
							lastPortFound = System.Convert.ToInt32(this._availablePortsList.GetByIndex(this._availablePortsList.Count - 1));
							if (lastPortFound >= this._portsRangeUpperLimit)
							{
								//only it it reached the upper limit, then starts again from the begining
								searchStartLowerLimit = this._portsRangeLowerLimit;
							}
							else
							{
								searchStartLowerLimit = lastPortFound;
							}
							searchStartUpperLimit = this._portsRangeUpperLimit;
						}
						else
						{
							searchStartLowerLimit = this._portsRangeLowerLimit;
							searchStartUpperLimit = this._portsRangeUpperLimit;
						}
						
					}
					
					//first time it runs
					for (portNumber = searchStartLowerLimit; portNumber <= searchStartUpperLimit; portNumber++)
					{
                        openPortsList = CommunicationsUtilities.GetOpenTCPPortsInARangeOfPorts(this._portsRangeLowerLimit, this._portsRangeUpperLimit);
						if (!openPortsList.ContainsKey(portNumber))
						{
							portsFound++;
							try
							{
								lock(this._availablePortsList)
								{
									this._availablePortsList.Add(portNumber, portNumber);
								}
							}
							catch (Exception)
							{
							}
							if (portsFound >= AVAILABLE_PORTS_QUEUE_MAX_SIZE)
							{
								break;
							}
						}
					}
				}
                Thread.Sleep(1);
				this._IsHandlerPerformingPortsSearching = false;
				
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
			private int DequeueNextAvailablePort()
			{
				bool gotPort = false;
				int currentPortFromqueue = 0;
				while (!gotPort)
				{
					if (this._availablePortsList.Count > 0)
					{
						
						currentPortFromqueue = System.Convert.ToInt32(this._availablePortsList.GetByIndex(0));
						
						lock(this._availablePortsList)
						{
							this._availablePortsList.RemoveAt(0);
						}
						
						System.Net.Sockets.TcpListener listener = null;
						string host = System.Net.Dns.GetHostName();
                        System.Net.IPAddress local_IPAddress = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetActiveIPAddress();
                        listener = new System.Net.Sockets.TcpListener(local_IPAddress, currentPortFromqueue);
						try
						{
							listener.Start();
							listener.Stop();
							this._LastAssignedPortNumber = currentPortFromqueue;
							listener = null;
							gotPort = true;
						}
						catch (System.Net.Sockets.SocketException ex)
						{
							switch (ex.ErrorCode)
							{
								case 10048: //the port is opened by another process
									try
									{
										listener.Stop();
									}
									catch (Exception)
									{
									}
									break;
								case 10055: //there is no more space to allocate another port in the system, no more resources available
									string msg = "Error finding an open port : " + ex.Message;
									throw (new Exception(msg));
							}
						}
						catch (Exception)
						{
							try
							{
								listener.Stop();
							}
							catch (Exception)
							{
							}
						}
						
					}
					else
					{
                        this._LastAssignedPortNumber = CommunicationsUtilities.GetFreeTCPPortOnPortsRange(this._portsRangeLowerLimit, this._portsRangeUpperLimit);
					}
					
				}
				
				return this._LastAssignedPortNumber;
				
			}
			
			private void SchedulePortsSearchingTask()
			{
				try
				{
					if (this._IsHandlerPerformingPortsSearching == false)
					{
						this._IsHandlerPerformingPortsSearching = true;
						Thread firstSearchThread = new Thread(new System.Threading.ThreadStart(SearchAvailableTCPPorts_ThreadFcn));
						firstSearchThread.IsBackground = true;
						firstSearchThread.Priority = ThreadPriority.Highest;
						firstSearchThread.Start();
					}
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			public int GetAvailablePort()
			{
				int portsCount = 0;
				
				lock(this._availablePortsList)
				{
					portsCount = this._availablePortsList.Count;
				}
				
				if (portsCount > 0)
				{
					int portToReturn = 0;
					portToReturn = this.DequeueNextAvailablePort();
					if (portsCount <= AVAILABLE_PORTS_QUEUE_MIN_SIZE)
					{
						this.SchedulePortsSearchingTask();
					}
					return portToReturn;
				}
				else
				{
                    this._LastAssignedPortNumber = CommunicationsUtilities.GetFreeTCPPortOnPortsRange(this._portsRangeLowerLimit, this._portsRangeUpperLimit);
					return this._LastAssignedPortNumber;
				}
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < IDisposable >
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			public virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
						try
						{
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
