using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsLibrary.Services.BroadCasting.Handling;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling
	{
		
		public class DiscoverableServiceDefinitionHandlingClient : IDisposable
		{
			
            #region  < DATAMEMBERS >

            private const string DSH_CLIENT_NAME_PREFIX = "DSH_CLIENT_";
			private DataBroadcastClient _DataBroadcastClient;
			private string _clientName;
			
			private const int TIME_OUT_SECONDS = 3;
			
#endregion
			
            #region  < PROPERTIES >
			
public string Name
			{
				get
				{
					return this._clientName;
				}
			}
			
#endregion
			
            #region  < CONSTRUCTORS >
			
			public DiscoverableServiceDefinitionHandlingClient(string clientName)
			{
                this._clientName = DSH_CLIENT_NAME_PREFIX + clientName.ToUpper();
				// Me._DataBroadcastClient = DataBroadcastClient.GetInstance(Me._clientName)
				this._DataBroadcastClient = new DataBroadcastClient(this._clientName, DiscoverableServiceHandlingOperativeDefs.DHS_SERVICE_HANDLER_BROADCAST_IP_ADDRESS, DiscoverableServiceHandlingOperativeDefs.DSH_SERVICE_HANDLER_BROADCAST_TCP_PORT);
			}
			
#endregion
			
            #region  < PUBLIC METHODS >
			
			public DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition FindService(string ServiceNameToFind)
			{
				try
				{
					BroadCasting.Data.BroadCastRepliesContainer replies = default(BroadCasting.Data.BroadCastRepliesContainer);
					replies = this._DataBroadcastClient.BroadCastDataAndWaitOneFirstReply(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_BROADCAST_ID_NAME_STRING, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME, ServiceNameToFind, TIME_OUT_SECONDS);
					if (replies.Count > 0)
					{
						
						//evaluates if the reply contains the reply from the service searched
						if (replies.ContainsReplyIDName(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_REPLYIDNAME_STRING))
						{
							BroadCasting.Data.BroadCastReply STXSErviceReply = default(BroadCasting.Data.BroadCastReply);
							STXSErviceReply = replies.Item(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_REPLYIDNAME_STRING);
							
							//evaluates for the service parameters table attached with the data name specified
							//by the constant SERVICE_PARAMETERS_TABLE
							if (STXSErviceReply.DataName == DiscoverableServiceHandlingOperativeDefs.SERVICE_PARAMETERS_TABLE)
							{
								CustomHashTable paramsTable = (CustomHashTable) STXSErviceReply.Value;
								DiscoverableServiceDefinitionParametersContainer serviceParams = new DiscoverableServiceDefinitionParametersContainer(paramsTable);
								DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDEfiniton = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
								
								DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
								
								//retrieves the service name from the parameters list
								//and removes it from the parameters list
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME));
								}
								serviceDEfiniton.ServiceName = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								
								//retrieves the service id from the parameters table and removes it
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_ID));
								}
								serviceDEfiniton.ServiceIDString = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								
								//retrieves the service operation mode
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE));
								}
								serviceDEfiniton.ServiceOperationMode = DiscoverableServiceHandlingOperativeDefs.GetServiceOperationModeFromString(param.Value);
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								
								serviceDEfiniton.ServiceParameters = serviceParams;
								return serviceDEfiniton;
							}
							else
							{
								throw (new DiscoverableServiceDefinitionHandlingSearchFailureException(ServiceNameToFind));
							}
						}
						else
						{
							throw (new DiscoverableServiceDefinitionHandlingSearchFailureException(ServiceNameToFind));
						}
					}
					else
					{
                        throw (new DiscoverableServiceDefinitionHandlingSearchFailureException(ServiceNameToFind));
					}
				}
				catch (Services.BroadCasting.DataBroadCastWaitReplyException)
				{
					throw (new DiscoverableServiceDefinitionHandlingSearchFailureException(ServiceNameToFind));
				}
				catch (Exception)
				{
					throw (new DiscoverableServiceDefinitionHandlingSearchFailureException(ServiceNameToFind));
				}
			}
			
			public Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer DiscoverAllAvailableServices(string ServiceNameToFind, int intervallTimeSeconds)
			{
				Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer servicesFoundContainer = new Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer();
				
				BroadCasting.Data.BroadCastRepliesContainer replies = default(BroadCasting.Data.BroadCastRepliesContainer);
				try
				{
					replies = this._DataBroadcastClient.BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_BROADCAST_ID_NAME_STRING, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME, ServiceNameToFind, intervallTimeSeconds);
					
					IEnumerator enumm = replies.GetEnumerator();
					BroadCastReply reply = default(BroadCastReply);
					
					while (enumm.MoveNext())
					{
                        reply = (BroadCastReply)enumm.Current;
						
						//evaluates if the reply contains the reply from the service searched
						if (reply.ReplyIDName == DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_REPLYIDNAME_STRING)
						{
							BroadCasting.Data.BroadCastReply STXSErviceReply = default(BroadCasting.Data.BroadCastReply);
							STXSErviceReply = reply;
							
							//evaluates for the service parameters table attached with the data name specified
							//by the constant SERVICE_PARAMETERS_TABLE
							if (STXSErviceReply.DataName == DiscoverableServiceHandlingOperativeDefs.SERVICE_PARAMETERS_TABLE)
							{
								CustomHashTable paramsTable = (CustomHashTable) STXSErviceReply.Value;
								DiscoverableServiceDefinitionParametersContainer serviceParams = new DiscoverableServiceDefinitionParametersContainer(paramsTable);
								DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDEfiniton = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
								
								DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
								
								//retrieves the service name from the parameters list
								//and removes it from the parameters list
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME));
								}
								serviceDEfiniton.ServiceName = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								
								//retrieves the service id from the parameters table and removes it
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_ID));
								}
								serviceDEfiniton.ServiceIDString = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								
								//retrieves the service operation mode
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE));
								}
								serviceDEfiniton.ServiceOperationMode = DiscoverableServiceHandlingOperativeDefs.GetServiceOperationModeFromString(param.Value);
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								
								serviceDEfiniton.ServiceParameters = serviceParams;
								
								servicesFoundContainer.AddDefinition(serviceDEfiniton);
								
							}
						}
						
					}
					return servicesFoundContainer;
					
				}
				catch (Exception)
				{
					return servicesFoundContainer;
				}
			}
			
			public Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer DiscoverServicesNumOfInstances(string ServiceNameToFind, int numberOfInstances)
			{
				Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer servicesFoundContainer = new Services.DiscoverableServiceHandling.Data.DiscoverableServiceDefinitionsContainer();
				
				BroadCasting.Data.BroadCastRepliesContainer replies = default(BroadCasting.Data.BroadCastRepliesContainer);
				try
				{
					replies = this._DataBroadcastClient.BroadCastDataAndWaitSpecifiedNumberOfReplies(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_BROADCAST_ID_NAME_STRING, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME, ServiceNameToFind, numberOfInstances);
					
					IEnumerator enumm = replies.GetEnumerator();
					BroadCastReply reply = default(BroadCastReply);
					
					while (enumm.MoveNext())
					{
                        reply = (BroadCastReply)enumm.Current;
						
						//evaluates if the reply contains the reply from the service searched
						if (reply.ReplyIDName == DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME_QUERY_REPLYIDNAME_STRING)
						{
							BroadCasting.Data.BroadCastReply STXSErviceReply = default(BroadCasting.Data.BroadCastReply);
							STXSErviceReply = reply;
							
							//evaluates for the service parameters table attached with the data name specified
							//by the constant SERVICE_PARAMETERS_TABLE
							if (STXSErviceReply.DataName == DiscoverableServiceHandlingOperativeDefs.SERVICE_PARAMETERS_TABLE)
							{
								CustomHashTable paramsTable = (CustomHashTable) STXSErviceReply.Value;
								DiscoverableServiceDefinitionParametersContainer serviceParams = new DiscoverableServiceDefinitionParametersContainer(paramsTable);
								DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDEfiniton = new DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition();
								
								DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
								
								//retrieves the service name from the parameters list
								//and removes it from the parameters list
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME));
								}
								serviceDEfiniton.ServiceName = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_NAME);
								
								//retrieves the service id from the parameters table and removes it
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_ID));
								}
								serviceDEfiniton.ServiceIDString = param.Value;
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_ID);
								
								//retrieves the service operation mode
								param = serviceParams.GetParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								if (param == null)
								{
									throw (new DiscoverableServiceDefinitionHandlingException(ServiceNameToFind, DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE));
								}
								serviceDEfiniton.ServiceOperationMode = DiscoverableServiceHandlingOperativeDefs.GetServiceOperationModeFromString(param.Value);
								serviceParams.RemoveParameter(DiscoverableServiceHandlingOperativeDefs.SERVICE_OPERATION_MODE);
								
								serviceDEfiniton.ServiceParameters = serviceParams;
								
								servicesFoundContainer.AddDefinition(serviceDEfiniton);
								
							}
						}
						
					}
					return servicesFoundContainer;
					
				}
				catch (Exception)
				{
					return servicesFoundContainer;
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
						try
						{
							this._DataBroadcastClient.Dispose();
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
