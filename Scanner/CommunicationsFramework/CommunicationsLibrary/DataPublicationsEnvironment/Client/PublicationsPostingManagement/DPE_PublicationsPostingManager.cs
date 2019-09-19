using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.Serialization;
using UtilitiesLibrary.EventLoging;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsConnectionManaging;
using CommunicationsLibrary.DataPublicationsEnvironment.Client.PublicationsPostingManagement;
using System.Threading;


namespace CommunicationsLibrary
{
	namespace DataPublicationsEnvironment.Client.PublicationsPostingManagement
	{
		
		internal class DPE_PublicationsPostingManager : IDisposable
		{
			
#region  < DATA MEMBERS >
			
			private const int MAX_PUBLICATION_SCHEDULED_POSTING_TRIALS = 100;
			
			//table containing the definition of the publications posted by the client in order to compare
			//the definition at the momento of updating
			private DPE_DataPublicationsClient _STXDataSocketClient;
			//holds the definitions of the publications that where created ion the server succesfully
			private DPE_PublicationDefinitionsContainer _ContainerOfPostedPublicationsOnServer;
			
			//holds the publications that couldn;t be created in the server in order to create it later
			//when its posible
			private DPE_PublicationDefinitionsContainer _ContainerOfScheduledPublicationsPostingOnServer;
			private Queue _publicationsScheduledPostingQueue;
			private Hashtable _PublicationScheduleREgistersTable;
			
#endregion
			
#region  < PROPERTIES >
			
internal int PostsCount
			{
				get
				{
					return this._ContainerOfPostedPublicationsOnServer.Count;
				}
			}
			
#endregion
			
#region  < EVENTS  >
			
			internal delegate void PublicationPostLostOnServerEventHandler(string PublicationName);
			private PublicationPostLostOnServerEventHandler PublicationPostLostOnServerEvent;
			
			internal event PublicationPostLostOnServerEventHandler PublicationPostLostOnServer
			{
				add
				{
					PublicationPostLostOnServerEvent = (PublicationPostLostOnServerEventHandler) System.Delegate.Combine(PublicationPostLostOnServerEvent, value);
				}
				remove
				{
					PublicationPostLostOnServerEvent = (PublicationPostLostOnServerEventHandler) System.Delegate.Remove(PublicationPostLostOnServerEvent, value);
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			internal DPE_PublicationsPostingManager(DPE_DataPublicationsClient client)
			{
				this._STXDataSocketClient = client;
				this._STXDataSocketClient.ConnectionWithSTXDataServerLost += this._STXDataSocketClient_ConnectionWithSTXDataServerLost;
				this._ContainerOfPostedPublicationsOnServer = new DPE_PublicationDefinitionsContainer();
				this._ContainerOfScheduledPublicationsPostingOnServer = new DPE_PublicationDefinitionsContainer();
				this._PublicationScheduleREgistersTable = new Hashtable();
				this._publicationsScheduledPostingQueue = new Queue();
			}
			
#endregion
			
#region  < EVENT HANDLING  >
			
			private void _STXDataSocketClient_ConnectionWithSTXDataServerLost()
			{
				try
				{
					this.ScheduleTasksToRestorePreviousPostedPublicationsAfterConnectionLost();
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < HANDLING OF THE TASKS TO CREATE A PUBLICATION IN THE SERVER IN A SCHEDULED TASK >
			
			private void ScheduleTaskToPostAPublicationOnServer_ThreadFcn()
			{
				try
				{
					PublicationScheduledTaskRegister regFromQueue = null;
					
					regFromQueue = null;
					
					lock(this._publicationsScheduledPostingQueue)
					{
						if (this._publicationsScheduledPostingQueue.Count > 0)
						{
							try
							{
                                regFromQueue = (PublicationScheduledTaskRegister)this._publicationsScheduledPostingQueue.Dequeue();
							}
							catch (Exception)
							{
								regFromQueue = null;
							}
						}
					}
					
					
					if (!(regFromQueue == null))
					{
						
						PublicationScheduledTaskRegister regFromTable = default(PublicationScheduledTaskRegister);
						
						lock(this._PublicationScheduleREgistersTable)
						{
                            regFromTable = (PublicationScheduledTaskRegister)this._PublicationScheduleREgistersTable[regFromQueue.PublicationDefinition.PublicationName];
						}
						
						while (regFromQueue.keepScheduleTaskWorking)
						{
							
							if (this._STXDataSocketClient.IsConnected)
							{
								
								try
								{
									this._STXDataSocketClient.PublicationsPostManager.PostPublicationOnServer(regFromTable.PublicationDefinition);
									this._PublicationScheduleREgistersTable.Remove(regFromTable.PublicationDefinition);
									this._ContainerOfScheduledPublicationsPostingOnServer.RemovePublicationDefinition(regFromTable.PublicationDefinition);
									this.RemovePublicationScheduledTask(regFromTable.PublicationDefinition.PublicationName);
									
									string msg = "";
									msg = "Publication \'" + regFromTable.PublicationDefinition.PublicationName + "\' was restored on the Server.";
									CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, msg);
									regFromTable.keepScheduleTaskWorking = false;
									regFromQueue = null;
									regFromTable = null;
                                    break ;
								}
								catch (Exception)
								{
									regFromTable.IncreaseTrialcounter();
								}
								
							}
							
							System.Threading.Thread.Sleep(2000);
						}
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
			internal void ScheduleTaskToPostAPublicationOnServer(DPE_ClientPublicationDefinition publicationDefinition)
			{
				
				if (!this.ContainsScheduledPublicationPost(publicationDefinition.PublicationName))
				{
					
					lock(this._ContainerOfScheduledPublicationsPostingOnServer)
					{
						
						if (!this._ContainerOfScheduledPublicationsPostingOnServer.ContainsPublicationDefinition(publicationDefinition))
						{
							
							this._ContainerOfScheduledPublicationsPostingOnServer.AddPublicationDefinition(publicationDefinition);
							
							System.Threading.Thread scheduleTask = new System.Threading.Thread(new System.Threading.ThreadStart(ScheduleTaskToPostAPublicationOnServer_ThreadFcn));
							scheduleTask.IsBackground = true;
							scheduleTask.Priority = System.Threading.ThreadPriority.Normal;
							
							PublicationScheduledTaskRegister reg = new PublicationScheduledTaskRegister(publicationDefinition, scheduleTask);
							
							lock(this._PublicationScheduleREgistersTable)
							{
								try
								{
									this._PublicationScheduleREgistersTable.Remove(publicationDefinition.PublicationName);
								}
								catch (Exception)
								{
								}
								this._PublicationScheduleREgistersTable.Add(publicationDefinition.PublicationName, reg);
							}
							
							lock(this._publicationsScheduledPostingQueue)
							{
								this._publicationsScheduledPostingQueue.Enqueue(reg);
							}
							
							scheduleTask.Start();
							
							string msg = "";
							msg = "Task to post the publication \'" + publicationDefinition.PublicationName + " was scheduled and started\'";
							CustomEventLog.WriteEntry(EventLogEntryType.Information, msg);
							
						}
					}
				}
			}
			
			internal bool ContainsScheduledPublicationPost(string publicationName)
			{
				if (this._ContainerOfScheduledPublicationsPostingOnServer.ContainsPublicationDefinition(publicationName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			
			internal void RemovePublicationScheduledTask(string publicationName)
			{
				this.AbortScheduledPublicationPostTask(publicationName);
			}
			
			internal void AbortScheduledPublicationPostTask(string publicationName)
			{
				
				if (this.ContainsScheduledPublicationPost(publicationName))
				{
					lock(this._ContainerOfScheduledPublicationsPostingOnServer)
					{
						this._ContainerOfScheduledPublicationsPostingOnServer.RemovePublicationDefinition(publicationName);
						lock(this._PublicationScheduleREgistersTable)
						{
							PublicationScheduledTaskRegister reg = default(PublicationScheduledTaskRegister);
                            reg = (PublicationScheduledTaskRegister)this._PublicationScheduleREgistersTable[publicationName];
							if (!(reg == null))
							{
								reg.keepScheduleTaskWorking = false;
								try
								{
									reg.scheduledPostTaskThread.Abort();
								}
								catch (Exception)
								{
								}
							}
							try
							{
								this._PublicationScheduleREgistersTable.Remove(publicationName);
							}
							catch (Exception)
							{
							}
						}
					}
				}
			}
			
			private void DisposeAllScheduledPublicationsPostingTasks()
			{
				try
				{
					lock(this._PublicationScheduleREgistersTable)
					{
						IEnumerator enumm = default(IEnumerator);
						enumm = this._PublicationScheduleREgistersTable.GetEnumerator();
						PublicationScheduledTaskRegister reg = default(PublicationScheduledTaskRegister);
						while (enumm.MoveNext())
						{
                            reg = (PublicationScheduledTaskRegister)((DictionaryEntry)enumm.Current).Value;
							reg.keepScheduleTaskWorking = false;
							try
							{
								reg.scheduledPostTaskThread.Abort();
							}
							catch (Exception)
							{
							}
						}
						this._PublicationScheduleREgistersTable.Clear();
					}
				}
				catch (Exception)
				{
				}
			}
			
#endregion
			
#region  < HANLDING OF THE TASK TO CREATE THE POSTED PUBLICATIONS  ON SERVER AFTER CONNECTION LOSS>
			
			private void ScheduleTasksToRestorePreviousPostedPublicationsAfterConnectionLost()
			{
				try
				{
					if (this._ContainerOfPostedPublicationsOnServer.Count > 0)
					{
						
						DPE_ClientPublicationDefinition publicationDef = null;
						Collection listOfPublicationsToPostAfterServerDesconection = new Collection();
						IEnumerator enumm = null;
											
						lock(this._ContainerOfPostedPublicationsOnServer)
						{
							enumm = this._ContainerOfPostedPublicationsOnServer.GetEnumerator();
							while (enumm.MoveNext())
							{
                                publicationDef = (DPE_ClientPublicationDefinition)enumm.Current;
								listOfPublicationsToPostAfterServerDesconection.Add(publicationDef, null, null, null);
							}
							//clears the container of posted publications
							this._ContainerOfPostedPublicationsOnServer.Clear();
						}
						
						enumm = listOfPublicationsToPostAfterServerDesconection.GetEnumerator();
						while (enumm.MoveNext())
						{
                            publicationDef = (DPE_ClientPublicationDefinition)enumm.Current;
							this.ScheduleTaskToPostAPublicationOnServer(publicationDef);
							try
							{
								if (PublicationPostLostOnServerEvent != null)
									PublicationPostLostOnServerEvent(publicationDef.PublicationName);
							}
							catch (Exception)
							{
							}
						}
					}
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(ex);
				}
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
#region  < HANDLING OF PUBLICATIONS DEFINITIONS POSTED ON THE SERVER >
			
			internal void PostPublicationOnServer(DPE_ClientPublicationDefinition PublicationDefinition)
			{
				
				//crates the publication definition into a P2PData to send to the server
				CustomHashTable varsToPublish = new CustomHashTable();
				string variableName = "";
				DPE_ServerDefs.PublicationVariableDataType variableDataType = default(DPE_ServerDefs.PublicationVariableDataType);
				string variableDataTypeAsString = "";
				
				IEnumerator enumm = PublicationDefinition.VariablesToPublishTable.GetEnumerator();
				while (enumm.MoveNext())
				{
					variableName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
					variableDataType = (DPE_ServerDefs.PublicationVariableDataType) (((DictionaryEntry) enumm.Current).Value);
					variableDataTypeAsString = DPE_ServerDefs.Get_String_FromPublicationVariableDataType(variableDataType);
					varsToPublish.Add(variableName, variableDataTypeAsString);
				}
				
				P2PData data = new P2PData(DPE_ServerDefs.DPE_CMD_CREATE_PUBLICATION, varsToPublish);
				data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATIONS_GROUP, PublicationDefinition.PublicationsGroup);
				data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_CLIENT_ID, this._STXDataSocketClient.ClientID);
				data.DataAttributesTable.AddAttribute(DPE_PublicationsDefinitions.DPE_PUBLICATION_NAME, PublicationDefinition.PublicationName);
				
				Services.P2PCommunicationsScheme.P2PPortClient p2pclient = default(Services.P2PCommunicationsScheme.P2PPortClient);
				try
				{
					p2pclient = new Services.P2PCommunicationsScheme.P2PPortClient(this._STXDataSocketClient.DSSServerHostName, this._STXDataSocketClient.PublicationsPost_PortNumber);
					p2pclient.Connect();
					
					//sends the information to the server in order to create it
					p2pclient.SendData(P2PDataSendMode.SyncrhonicalSend, data);
					
					p2pclient.Dispose();
					
					//it the publication was created in the server then ists definition is saved in the publications posted manager
					//in order to allow it to re create ii if needed
					this.AddPublicationDefinitionAfterCreation(PublicationDefinition);
					
					string msg = "Publication \'" + PublicationDefinition.PublicationName + "\'    ->    POSTED succesfully.";
					CustomEventLog.WriteEntry(EventLogEntryType.SuccessAudit, msg);
					
				}
				catch (Exception ex)
				{
					try
					{
						this.RemovePublicationDefinition(PublicationDefinition);
					}
					catch (Exception)
					{
					}
					string errMSg = "";
					errMSg = "Error creating the publication \'" + PublicationDefinition.PublicationName + "\' : " + ex.Message;
					throw (new Exception(errMSg));
				}
			}
			
			internal void AddPublicationDefinitionAfterCreation(DPE_ClientPublicationDefinition definition)
			{
				this._ContainerOfPostedPublicationsOnServer.AddPublicationDefinition(definition);
			}
			
			internal void RemovePublicationDefinition(DPE_ClientPublicationDefinition definition)
			{
				this._ContainerOfPostedPublicationsOnServer.RemovePublicationDefinition(definition);
			}
			
			internal void DisposePublicationDefinition(string publicationName)
			{
				this._ContainerOfPostedPublicationsOnServer.RemovePublicationDefinition(publicationName);
			}
			
			internal bool ContainsPublicationDefinition(string publicationName)
			{
				bool result = default(bool);
				result = this._ContainerOfPostedPublicationsOnServer.ContainsPublicationDefinition(publicationName);
				return result;
			}
			
			internal DPE_ClientPublicationDefinition GetPublicationDefinition(dynamic publicationName)
			{
				return this._ContainerOfPostedPublicationsOnServer.Item(System.Convert.ToString(publicationName));
			}
			
#endregion
			
			internal void Reset()
			{
				this._ContainerOfPostedPublicationsOnServer.Clear();
				this._ContainerOfScheduledPublicationsPostingOnServer.Clear();
				this.DisposeAllScheduledPublicationsPostingTasks();
				try
				{
					this._publicationsScheduledPostingQueue.Clear();
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
						try
						{
							this.DisposeAllScheduledPublicationsPostingTasks();
						}
						catch (Exception)
						{
						}
						this._ContainerOfScheduledPublicationsPostingOnServer.Clear();
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
		
#region  < SUPPORT CLASS >
		
		internal class PublicationScheduledTaskRegister
		{
			public DPE_ClientPublicationDefinition PublicationDefinition;
			public System.Threading.Thread scheduledPostTaskThread;
			public bool keepScheduleTaskWorking;
			public int TaskTrialCounter;
			
			public PublicationScheduledTaskRegister(DPE_ClientPublicationDefinition def, System.Threading.Thread scheduleTask)
			{
				this.PublicationDefinition = def;
				this.scheduledPostTaskThread = scheduleTask;
				this.keepScheduleTaskWorking = true;
				this.TaskTrialCounter = 0;
			}
			
			public void IncreaseTrialcounter()
			{
				this.TaskTrialCounter++;
			}
		}
		
#endregion
		
		
	}
	
}
