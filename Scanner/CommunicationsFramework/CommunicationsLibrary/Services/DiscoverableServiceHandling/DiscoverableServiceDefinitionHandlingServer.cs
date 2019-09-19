using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsLibrary.Services.BroadCasting.Handling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using UtilitiesLibrary.EventLoging;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling
	{
		
		
		public class DiscoverableServiceDefinitionHandlingServer : IDisposable
		{
			
			
            #region  < CLASS INFORMATION >
			
#endregion
			
            #region  < DATA MEMBERS >
			
			private string _serviceName;
			private string _serviceID;
			private DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode _servideMode;
			private DiscoverableServiceDefinitionParametersContainer _serviceParameters;
			private DataBroadcastListener _broadcastListener;
			private int _clientQueriesReceived;
			private int _succesfullQueriesResulted;
			
			
#endregion  
			
            #region  < EVENTS >
			
			public delegate void STXServiceQueryReceivedEventHandler(string ServiceName, string ClientName, string ClientHost);
			private STXServiceQueryReceivedEventHandler STXServiceQueryReceivedEvent;
			
			public event STXServiceQueryReceivedEventHandler STXServiceQueryReceived
			{
				add
				{
					STXServiceQueryReceivedEvent = (STXServiceQueryReceivedEventHandler) System.Delegate.Combine(STXServiceQueryReceivedEvent, value);
				}
				remove
				{
					STXServiceQueryReceivedEvent = (STXServiceQueryReceivedEventHandler) System.Delegate.Remove(STXServiceQueryReceivedEvent, value);
				}
			}
			
			public delegate void STXServiceSuccesfullQueryResultEventHandler(string ServiceName, string ClientName, string ClientHost);
			private STXServiceSuccesfullQueryResultEventHandler STXServiceSuccesfullQueryResultEvent;
			
			public event STXServiceSuccesfullQueryResultEventHandler STXServiceSuccesfullQueryResult
			{
				add
				{
					STXServiceSuccesfullQueryResultEvent = (STXServiceSuccesfullQueryResultEventHandler) System.Delegate.Combine(STXServiceSuccesfullQueryResultEvent, value);
				}
				remove
				{
					STXServiceSuccesfullQueryResultEvent = (STXServiceSuccesfullQueryResultEventHandler) System.Delegate.Remove(STXServiceSuccesfullQueryResultEvent, value);
				}
			}
			
			
#endregion
			
            #region  < PROPERTIES >
			
public string ServiceName
			{
				get
				{
					return this._serviceName.ToUpper();
				}
			}
			
public DiscoverableServiceDefinitionParametersContainer ServiceParameters
			{
				get
				{
					return this._serviceParameters;
				}
			}
			
public DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode ServiceMode
			{
				get
				{
					return this._servideMode;
				}
			}
			
public int ClientQueriesReceivedCount
			{
				get
				{
					return this._clientQueriesReceived;
				}
			}
			
public int SuccessfullClientQueriesCount
			{
				get
				{
					return this._succesfullQueriesResulted;
				}
			}
			
			
			
#endregion
			
            #region  < CONSTRUCTORS >
			
			public DiscoverableServiceDefinitionHandlingServer(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode serviceMode, string serviceName, DiscoverableServiceDefinitionParametersContainer parameters)
			{
				this._serviceName = serviceName.ToUpper();
				this._serviceID = Guid.NewGuid().ToString("N");
				this._servideMode = serviceMode;
				this._serviceParameters = parameters;
				//adds the service name, its id and its operation mode in the parameters Table
				//in order to reply the table within the broadcast reply as a hashtable and
				//retrieve those parametes in the client to fill specific fiels of the structure DiscoverableServiceDefinition
				this._serviceParameters.AddParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME, this._serviceName);
				this._serviceParameters.AddParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID, this._serviceID);
				this._serviceParameters.AddParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE, DiscoverableServiceHandlingOperativeDefs.GetServiceOperationModeAsString(this._servideMode));
				
				this._clientQueriesReceived = 0;
				this._succesfullQueriesResulted = 0;
				
				//Me._broadcastListener = BroadCasting.DataBroadcastListener.GetInstance
				this._broadcastListener = new DataBroadcastListener(DiscoverableServiceHandlingOperativeDefs.DHS_SERVICE_HANDLER_BROADCAST_IP_ADDRESS, DiscoverableServiceHandlingOperativeDefs.DSH_SERVICE_HANDLER_BROADCAST_TCP_PORT);
				this._broadcastListener.DataReceived += this.broadcastDataReceived;
				
			}
			
#endregion
			
            #region  < EVENT HANDLING >
			
			private void broadcastDataReceived(Services.BroadCasting.Handling.DataBroadCastHandler broadcastDataReceptionHandler)
			{
				
				bool raiseTheSuccesfullQueryEvent = false;
				string serviceNameBeingLooking = "UNDEFINED";
				this._clientQueriesReceived++;
				
				if (broadcastDataReceptionHandler.BroadcastingMode == Services.BroadCasting.Handling.DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply)
				{
					//evaluates if the received broadcast corresponds to a event to find a STX network service over the network
					if (broadcastDataReceptionHandler.broadcastIDName == DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_BROADCAST_ID_NAME_STRING)
					{
						
						//because the service name comes in the broadcasted data in the dataname evaluates
						//if the dataname received correspond to the estandard dataname defined to
						//retrieve the service name who is being lookig for a broadcast client
						if (broadcastDataReceptionHandler.BroadCastedData.DataName == DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME)
						{
							
							
							serviceNameBeingLooking = System.Convert.ToString(broadcastDataReceptionHandler.BroadCastedData.Value);
							serviceNameBeingLooking = serviceNameBeingLooking.ToUpper();
							//operation to evaluate if the service being looked corresponds to the service
							//name defined within the handler
							
							if (this.ServiceName == serviceNameBeingLooking)
							{
								//the local service corresponds to the query, so the handler replyes
								// the service parameters list to the broadcaster
								try
								{
									BroadCastReply serviceReply = new BroadCastReply(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_REPLYIDNAME_STRING, DiscoverableServiceHandlingOperativeDefs.SERVICE_PARAMETERS_TABLE, this._serviceParameters.ParametersTable);
									broadcastDataReceptionHandler.SendReplyToBroadcaster(serviceReply);
									raiseTheSuccesfullQueryEvent = true;
									this._succesfullQueriesResulted++;
								}
								catch (Exception ex)
								{
									CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
								}
							}
						}
					}
				}
				else
				{
					//save the error that the object can respond to a reply from the broadcast client
				}
				
				try
				{
					if (STXServiceQueryReceivedEvent != null)
						STXServiceQueryReceivedEvent(serviceNameBeingLooking, broadcastDataReceptionHandler.BroadCastedData.BroadCasterInformation.BroadcasterName, broadcastDataReceptionHandler.BroadCastedData.BroadCasterInformation.Host);
				}
				catch (Exception)
				{
				}
				
				if (raiseTheSuccesfullQueryEvent)
				{
					try
					{
						if (STXServiceSuccesfullQueryResultEvent != null)
							STXServiceSuccesfullQueryResultEvent(serviceNameBeingLooking, broadcastDataReceptionHandler.BroadCastedData.BroadCasterInformation.BroadcasterName, broadcastDataReceptionHandler.BroadCastedData.BroadCasterInformation.Host);
					}
					catch (Exception)
					{
					}
				}
				
			}
			
			
#endregion
			
            #region  < INTERFACE IMPLEMENTATION  >
			
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
						this._broadcastListener.Dispose();
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
