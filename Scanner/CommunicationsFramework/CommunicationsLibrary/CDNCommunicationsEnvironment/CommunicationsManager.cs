using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using System.Net;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Data;
using CommunicationsLibrary.CNDCommunicationsEnvironment.Interfaces;
using CommunicationsLibrary.CNDCommunicationsEnvironment.LocalCommunicationsHandling;
using CommunicationsLibrary.CNDCommunicationsEnvironment.RemoteCommunicationsHandling;
using UtilitiesLibrary.EventLoging;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment
	{
		
		internal sealed class CNDCommunicationsEnvironmentDefinitions
		{
			//DEFINES A RANGE OF TCP PORTS WHERE THE CND SERVICE WILL WORK AS RESERVED
			internal const int INITIAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT = 4251;
			internal const int FINAL_TCP_PORT_FOR_CND_COMMS_ENVIRONMENT = 7251;
		}

        internal struct CNDSErviceRegistrationData
        {
            public string ComponentName;
            public string ApplicationName;
            public string HostName;
            public IPAddress IPAddress;
            public int ListeningPort;
        }
			
		
		public class CommunicationsManager : IDisposable
		{
			
			
#region  < DATA MEMBERS >
			
			
			
			
			
			private static CommunicationsManager _CommunicationsManager;
			private CNDClient _CNDClient;
			private LocalComponentCommunicationsHandlersContainer _LocalHandlersContainer;
			private CNDCommunicationsEnvironment.RemoteCommunicationsHandling.RemoteComponentCommunicationsHandlersContainer _remoteHandlersContainer;
			private Hashtable _PendingSubscriptionsTable;
			private Hashtable _componentsSubscribedCNDRegistrationDataTable;
			private System.Timers.Timer _pendingSubscriptionsTimer;
			private System.Timers.Timer _subscriptionRenewalTimer;
			private System.Threading.Thread _subscriptionsRenewalThread;
			
			
#endregion
			
#region  < EVENTS  >
			
			public delegate void CNDTableChangedEventHandler(DataTable table);
			private CNDTableChangedEventHandler CNDTableChangedEvent;
			
			public event CNDTableChangedEventHandler CNDTableChanged
			{
				add
				{
					CNDTableChangedEvent = (CNDTableChangedEventHandler) System.Delegate.Combine(CNDTableChangedEvent, value);
				}
				remove
				{
					CNDTableChangedEvent = (CNDTableChangedEventHandler) System.Delegate.Remove(CNDTableChangedEvent, value);
				}
			}
			
			
#endregion
			
#region  < COSNTRUCTORS>
			
			private CommunicationsManager()
			{
				this._LocalHandlersContainer = new LocalComponentCommunicationsHandlersContainer();
				this._remoteHandlersContainer = new CNDCommunicationsEnvironment.RemoteCommunicationsHandling.RemoteComponentCommunicationsHandlersContainer();
				this._PendingSubscriptionsTable = new Hashtable();
				this._componentsSubscribedCNDRegistrationDataTable = new Hashtable();
				
				this._pendingSubscriptionsTimer = new System.Timers.Timer(10000);
				this._pendingSubscriptionsTimer.Elapsed += this._pendingSubscriptionsTimer_Elapsed;
				this._pendingSubscriptionsTimer.Stop();
				
				this._subscriptionRenewalTimer = new System.Timers.Timer(10000);
				this._subscriptionRenewalTimer.Start();
				
				this._CNDClient = new CNDClient();
				this._CNDClient.ConnectionWithServiceLost += this.ConnectionWithServiceLost;
				this._CNDClient.ComponentRegistrationChanged += this.ComponentRegistrationChanged;
				this._CNDClient.NewComponentRegistrationDetected += this.NewComponentRegistrationDetected;
				this._CNDClient.ComponentUnregistrationDetected += this.ComponentUnregistrationDetected;
				this._CNDClient.Connect();
			}
			
#endregion
			
#region  < EVENT HANDLING >
			
			private void ConnectionWithServiceLost()
			{
				try
				{
					this.ScheduleComponentsSubscriptionRenewalToCNDService();
				}
				catch (Exception)
				{
				}
			}
			
			private void ComponentRegistrationChanged(CNDAddressingReg ComponentCNDRegister)
			{
				try
				{
					if (this._remoteHandlersContainer.ContainsHandlerForRemoteComponent(ComponentCNDRegister.ComponentName))
					{
						RemoteComponentComunicationsHandler handler = default(RemoteComponentComunicationsHandler);
						handler = this._remoteHandlersContainer.GetHandler(ComponentCNDRegister.ComponentName);
						this._remoteHandlersContainer.RemoveExistingHandler(handler);
					}
					RemoteComponentComunicationsHandler newhandler = this.GetRemoteHandlerForComponent(ComponentCNDRegister.ComponentName);
					this._remoteHandlersContainer.AddNewHandler(newhandler);
					if (CNDTableChangedEvent != null)
						CNDTableChangedEvent(this.CNDTable);
				}
				catch (Exception ex)
				{
                    CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void NewComponentRegistrationDetected(CNDAddressingReg ComponentCNDRegister)
			{
				try
				{
					//when a remote component is registred in the CNDService then is detected and is creted locally
					// a handler to communicate with it
					RemoteComponentComunicationsHandler newhandler = this.GetRemoteHandlerForComponent(ComponentCNDRegister.ComponentName);
					this._remoteHandlersContainer.AddNewHandler(newhandler);
					if (CNDTableChangedEvent != null)
						CNDTableChangedEvent(this.CNDTable);
				}
				catch (Exception ex)
				{
                    CustomEventLog.WriteEntry(ex);
				}
			}
			
			private void ComponentUnregistrationDetected(CNDAddressingReg ComponentCNDRegister)
			{
				try
				{
					if (this._remoteHandlersContainer.ContainsHandlerForRemoteComponent(ComponentCNDRegister.ComponentName))
					{
						RemoteComponentComunicationsHandler handler = default(RemoteComponentComunicationsHandler);
						handler = this._remoteHandlersContainer.GetHandler(ComponentCNDRegister.ComponentName);
						this._remoteHandlersContainer.RemoveExistingHandler(handler);
						if (CNDTableChangedEvent != null)
							CNDTableChangedEvent(this.CNDTable);
					}
				}
				catch (Exception ex)
				{
                    CustomEventLog.WriteEntry(ex);
				}
			}
			
			
#endregion
			
#region  < PROPERTIES >
			
			public DataTable ComponentGeneralStatisticsTable(string ComponentName)
			{
				ComponentName = ComponentName.ToUpper();
				if (this._LocalHandlersContainer.ContainsHandlerForComponent(ComponentName))
				{
					CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler handler = default(CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler);
					handler = this._LocalHandlersContainer.GetHandler(ComponentName);
					return handler.portGeneralStatisticsTable;
				}
				else
				{
					return null;
				}
			}
			
			public DataTable ComponentDataReceptionStatisticsTable(string ComponentName)
			{
				if (this._LocalHandlersContainer.ContainsHandlerForComponent(ComponentName))
				{
					CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler handler = default(CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler);
					handler = this._LocalHandlersContainer.GetHandler(ComponentName);
					return handler.PortDataReceptionStatisticsTable;
				}
				else
				{
					return null;
				}
			}
			
			public DataTable ComponentDataRequestsStatisticsTable(string ComponentName)
			{
				if (this._LocalHandlersContainer.ContainsHandlerForComponent(ComponentName))
				{
					CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler handler = default(CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler);
					handler = this._LocalHandlersContainer.GetHandler(ComponentName);
					return handler.PortDataRequestStatisticsTable;
				}
				else
				{
					return null;
				}
			}
			
public DataTable CNDTable
			{
				get
				{
					return this._CNDClient.CNDTable.DataTable;
				}
			}
			
#endregion
			
#region  < SINGLETON IMPLEMENTATION >
			
			public static CommunicationsManager GetInstance()
			{
				if (_CommunicationsManager == null)
				{
					_CommunicationsManager = new CommunicationsManager();
				}
				return _CommunicationsManager;
			}
			
#endregion
			
#region  < PRIVATE METHODS >
			
#region  < PENDING SUBSCRIPTIONS  >
			
			private void LogComponentForPendingSubscriptionToCNDService(CNDSErviceRegistrationData pendingSubscription)
			{
				lock(this._PendingSubscriptionsTable)
				{
					if (this._PendingSubscriptionsTable.ContainsKey(pendingSubscription.ComponentName))
					{
						this._PendingSubscriptionsTable.Remove(pendingSubscription.ComponentName);
					}
					this._PendingSubscriptionsTable.Add(pendingSubscription.ComponentName, pendingSubscription);
				}
			}
			
			private void UnlogComponentForPendingSubscriptionToCNDService(CNDSErviceRegistrationData pendingSubscription)
			{
				lock(this._PendingSubscriptionsTable)
				{
					if (this._PendingSubscriptionsTable.ContainsKey(pendingSubscription.ComponentName))
					{
						this._PendingSubscriptionsTable.Remove(pendingSubscription.ComponentName);
					}
				}
			}
			
			private void StartPendingSubscriptionTimer()
			{
				this._pendingSubscriptionsTimer.Start();
			}
			
			private void StopPendingSubscriptionTimer()
			{
				this._pendingSubscriptionsTimer.Stop();
			}
			
			private void _pendingSubscriptionsTimer_Elapsed(System.Object sender, System.Timers.ElapsedEventArgs e)
			{
				try
				{
					this.StopPendingSubscriptionTimer();
					System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(PerformPendingSubscriptions));
					thread.IsBackground = true;
					thread.Start();
				}
				catch (Exception)
				{
				}
			}
			
			private void PerformPendingSubscriptions()
			{
				this.StopPendingSubscriptionTimer();
				
				Collection tableWithSuccesfulRegiusteredData = new Collection();
				CNDSErviceRegistrationData subcriptionData = new CNDSErviceRegistrationData();
				IEnumerator enumm = default(IEnumerator);
				
				lock(this._PendingSubscriptionsTable)
				{
					
					enumm = this._PendingSubscriptionsTable.GetEnumerator();
					
					while (enumm.MoveNext())
					{
                        subcriptionData = (CNDSErviceRegistrationData)((DictionaryEntry)enumm.Current).Value;
						try
						{
                            this._CNDClient.SubscribeComponent(subcriptionData);
							this.LogComponent(subcriptionData);
							tableWithSuccesfulRegiusteredData.Add(subcriptionData, null, null, null);
						}
						catch (Exception)
						{
                            break;
						}
					}
				}
				//removes the ones that were successfully posted to CND service
				enumm = tableWithSuccesfulRegiusteredData.GetEnumerator();
				while (enumm.MoveNext())
				{
					subcriptionData =  (CNDSErviceRegistrationData)enumm.Current;
					this.UnlogComponentForPendingSubscriptionToCNDService(subcriptionData);
				}
				
				//restart the timer if there were still pendingf subscriptions
				if (_PendingSubscriptionsTable.Count > 0)
				{
					this.StartPendingSubscriptionTimer();
				}
				
			}
			
#endregion
			
#region  < SUBSCRIPTIONS RENEWAL AFTER DESCONNECTION HANDLING >
			
			private void LogComponent(CNDSErviceRegistrationData registrationData)
			{
				lock(this._componentsSubscribedCNDRegistrationDataTable)
				{
					if (this._componentsSubscribedCNDRegistrationDataTable.Contains(registrationData.ComponentName))
					{
						this._componentsSubscribedCNDRegistrationDataTable.Remove(registrationData.ComponentName);
					}
					this._componentsSubscribedCNDRegistrationDataTable.Add(registrationData.ComponentName, registrationData);
				}
			}
			
			private void UnlogComponent(string ComponentName)
			{
				lock(this._componentsSubscribedCNDRegistrationDataTable)
				{
					if (this._componentsSubscribedCNDRegistrationDataTable.Contains(ComponentName))
					{
						this._componentsSubscribedCNDRegistrationDataTable.Remove(ComponentName);
					}
				}
			}
			
			private void ScheduleComponentsSubscriptionRenewalToCNDService()
			{
				this._subscriptionsRenewalThread = new System.Threading.Thread(new System.Threading.ThreadStart(RenewalOfLocalLoggedComponentsRegistration));
				this._subscriptionsRenewalThread.IsBackground = true;
				this._subscriptionsRenewalThread.Priority = System.Threading.ThreadPriority.Normal;
				this._subscriptionsRenewalThread.Start();
			}
			
			private void RenewalOfLocalLoggedComponentsRegistration()
			{
				
				CNDSErviceRegistrationData registrationData = new CNDSErviceRegistrationData();
				Queue localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue = new Queue();
				Hashtable ClientsubscriptionRenewalTrialLogRegTable = new Hashtable();
				IEnumerator enumm = default(IEnumerator);
				
				lock(this._componentsSubscribedCNDRegistrationDataTable)
				{
					
					enumm = this._componentsSubscribedCNDRegistrationDataTable.GetEnumerator();
					
					ClientsubscriptionRenewalTrialLogReg dat = default(ClientsubscriptionRenewalTrialLogReg);
					
					while (enumm.MoveNext())
					{
                        registrationData = (CNDSErviceRegistrationData)((DictionaryEntry)enumm.Current).Value;
						localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue.Enqueue(registrationData);
						dat = new ClientsubscriptionRenewalTrialLogReg(registrationData);
						if (!ClientsubscriptionRenewalTrialLogRegTable.ContainsKey(registrationData.ComponentName))
						{
							ClientsubscriptionRenewalTrialLogRegTable.Add(dat.registrationData.ComponentName, dat);
						}
					}
					
				}
				
				string MSG = "Registration of components to the CND service task was launched with " + System.Convert.ToString(localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue.Count) + " components attached to local STX communications manager. ";
                CustomEventLog.WriteEntry(EventLogEntryType.Information, MSG);
				
				while (localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue.Count > 0)
				{
					try
					{
                        registrationData = (CNDSErviceRegistrationData)localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue.Dequeue();
						try
						{
                            this._CNDClient.SubscribeComponent(registrationData);
							
						}
						catch (Exception ex)
						{
							
							
							string errmsg = "";
							errmsg = "Error loggin the component \'" + registrationData.ComponentName + "\' in the CND servide : " + ex.Message;
                            CustomEventLog.WriteEntry(EventLogEntryType.Warning, errmsg);
							
							System.Threading.Thread.Sleep(50);
							
							ClientsubscriptionRenewalTrialLogReg data = default(ClientsubscriptionRenewalTrialLogReg);
                            data = (ClientsubscriptionRenewalTrialLogReg)ClientsubscriptionRenewalTrialLogRegTable[registrationData.ComponentName];
							if (!(data == null))
							{
								data.IncreaseTrialconter();
								if (data.renewalTrialsCount <= 10)
								{
									localComponentsREgisteredInCNDServiceBeforeDisconnectionQueue.Enqueue(registrationData);
								}
								else
								{
									string err = "";
									err = "The component \'" + registrationData.ComponentName + "\' was discarded for subscription renewal because was reached the maximun renewavl trials event.";
                                    CustomEventLog.WriteEntry(EventLogEntryType.Warning, err);
								}
							}
							else
							{
								string err = "";
								err = "The component \'" + registrationData.ComponentName + "\' isn\'t have a renewal trials handler, so it was discarded for CND service sibscription renewal.";
                                CustomEventLog.WriteEntry(EventLogEntryType.Warning, err);
							}
							
							
						}
					}
					catch (Exception)
					{
					}
					System.Threading.Thread.Sleep(50);
				}
			}
			
#endregion
			
			private RemoteComponentComunicationsHandler GetRemoteHandlerForComponent(string RemoteComponentName)
			{
				try
				{
					CNDAddressingReg reg = default(CNDAddressingReg);
					reg = this._CNDClient.ResolveAddress(RemoteComponentName);
					RemoteComponentComunicationsHandler handler = new RemoteComponentComunicationsHandler(RemoteComponentName, reg.HostName, reg.IPAddress ,reg.P2PPortNumber);
					return handler;
				}
				catch (Exception ex)
				{
					throw (new Exception("Unable to send data to component name \'" + RemoteComponentName + "\' becuase it is not posible to resolve its network location. Error: " + ex.Message));
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
#region  < COMMUNICATIONS INTERFACE SUPPORT METHODS  >
			
			
			
			public void SubscribeToCommunicationsService(object component)
			{
				//the object that subscribes to the communications manager must implements the interface
				//IUseCNDCommunicationsScheme
				if (!(component is CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme))
				{
					throw (new Exception("The component passed as parameter can\'t be subscribed to communications environment because it must implements the \'IUseCNDCommunicationsScheme\' interface"));
				}
				
				string componentName = ((CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme) component).ComponentName;
				componentName = componentName.ToUpper();
				if (componentName.Length <= 0)
				{
					throw (new Exception("Can\'t subscribe to communications service because the component name can\'t be zero length"));
				}
				
				
				if (this._LocalHandlersContainer.ContainsHandlerForComponent(componentName))
				{
					//the component with the name specified is already registered
					throw (new Exception("The component \'" + componentName + "\' is already subscribed in the communications environment"));
				}
				
				CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler componentHandler = new CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler(component);
				this._LocalHandlersContainer.AddNewHandler(componentHandler);
                CNDSErviceRegistrationData CNDRegistrationData = componentHandler.GetRegistrationInformation();
				try
				{
                    this._CNDClient.SubscribeComponent(CNDRegistrationData);
					this.LogComponent(CNDRegistrationData);
				}
				catch (Exception)
				{
					//subscription failed so the manager will try to subscribe later
					this.LogComponentForPendingSubscriptionToCNDService(CNDRegistrationData);
					StartPendingSubscriptionTimer();
				}
				
				try
				{
					//creates locally a handler to communicate with this component
					RemoteComponentComunicationsHandler newhandler = this.GetRemoteHandlerForComponent(componentName);
					this._remoteHandlersContainer.AddNewHandler(newhandler);
				}
				catch (Exception)
				{
				}
				
			}
			
			public void UnsubscribeFromCommunicationsService(object component)
			{
				//the object that subscribes to the communications manager must implements the interface
				//IUseCNDCommunicationsScheme
				if (!(component is CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme))
				{
					throw (new Exception("The component passed as parameter can\'t be subscribed to communications environment because it must implements the \'IUseCNDCommunicationsScheme\' interface"));
				}
				
				string componentName = ((CNDCommunicationsEnvironment.Interfaces.IUseCNDCommunicationsScheme) component).ComponentName;
				componentName = componentName.ToUpper();
				
				CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler handler = default(CNDCommunicationsEnvironment.LocalCommunicationsHandling.LocalComponentCommunicationsHandler);
				if (this._LocalHandlersContainer.ContainsHandlerForComponent(componentName))
				{
					handler = this._LocalHandlersContainer.GetHandler(componentName);
					if (!(handler == null))
					{
						this._LocalHandlersContainer.RemoveExistingHandler(handler);
					}
				}
				
				this._CNDClient.UnSubcribeComponent(componentName);
				
				//destroy the communications handler to communicate with the component locally
				if (this._remoteHandlersContainer.ContainsHandlerForRemoteComponent(componentName))
				{
					RemoteComponentComunicationsHandler remoteComsHandler = default(RemoteComponentComunicationsHandler);
					remoteComsHandler = this._remoteHandlersContainer.GetHandler(componentName);
					this._remoteHandlersContainer.RemoveExistingHandler(remoteComsHandler);
					remoteComsHandler.Dispose();
				}
				
				try
				{
					this.UnlogComponent(componentName);
				}
				catch (Exception)
				{
				}
			}
			
			public void SendData(CommunicationsData data)
			{
				if (this._remoteHandlersContainer.ContainsHandlerForRemoteComponent(data.AddresseComponentName))
				{
					RemoteComponentComunicationsHandler handler = this._remoteHandlersContainer.GetHandler(data.AddresseComponentName);
					handler.SendData(data);
				}
				else
				{
					RemoteComponentComunicationsHandler newhandler = this.GetRemoteHandlerForComponent(data.AddresseComponentName);
					this._remoteHandlersContainer.AddNewHandler(newhandler);
					newhandler.SendData(data);
				}
			}
			
			public CommunicationsData RequestDataFromRemoteComponent(CNDCommunicationsEnvironment.Data.CommunicationsDataRequest dataRequest)
			{
				if (this._remoteHandlersContainer.ContainsHandlerForRemoteComponent(dataRequest.RemoteAddresseComponentName))
				{
					RemoteComponentComunicationsHandler handler = this._remoteHandlersContainer.GetHandler(dataRequest.RemoteAddresseComponentName);
					return handler.RetrieveData(dataRequest);
				}
				else
				{
					RemoteComponentComunicationsHandler newhandler = this.GetRemoteHandlerForComponent(dataRequest.RemoteAddresseComponentName);
					this._remoteHandlersContainer.AddNewHandler(newhandler);
					return newhandler.RetrieveData(dataRequest);
				}
			}
			
			
#endregion
			
			
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
						try
						{
							this._LocalHandlersContainer.DisposeAllHandlers();
							this._LocalHandlersContainer.Dispose();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._remoteHandlersContainer.DisposeAllHandlers();
							this._remoteHandlersContainer.Dispose();
						}
						catch (Exception)
						{
						}
						
						try
						{
							this._CNDClient.Dispose();
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
			
#region  < PRIVATE SUPPORT CLASS >
			
			internal class ClientsubscriptionRenewalTrialLogReg
			{
				public CNDSErviceRegistrationData registrationData;
				public int renewalTrialsCount;
				
				public ClientsubscriptionRenewalTrialLogReg(CNDSErviceRegistrationData data)
				{
					registrationData = data;
					renewalTrialsCount = 0;
				}
				
				public void IncreaseTrialconter()
				{
					renewalTrialsCount++;
				}
				
			}
			
#endregion
			
			
		}
		
		
	}
	
	
}
