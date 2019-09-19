using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;
//using VisualUtilitiesLibrary.Services.VisualizationManagment.ControlBlinking;
using CommunicationsLibrary.Services;
using System.Threading;



namespace DPEServerClientApp
{
	public partial class frmDPEServerClientAppMainForm
	{
		
#region Default Instance
		
		private static frmDPEServerClientAppMainForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmDPEServerClientAppMainForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDPEServerClientAppMainForm();
					defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		
#region  < DATAMEMBERS >
		
		private enum UpdateTaskFlag
		{
			fullStatusUpdate,
			clientsRegistryStatusUpdate,
			publicationsRegistryStatusUpdate
		}
		
		
		private const string HOSTNAME_NODE = "HOSTNAME_NODE";
		private const string PUBLISHER_NODE = "PUBLISHER_NODE";
		private const string PUBLICATION_ELEMENT = "PUBLICATION_ELEMENT";
		private const string PUBLICATIONS_GROUP = "PUBLICATIONS_GROUP";
		
		private DPE_DataPublicationsClient _DPEPublicationsClient;
		private DataTable _clientConnectionsMasterTable;
		private DataTable _clientPublishersTable;
		private DataTable _publicationsMasterTable;
		
		private Queue _clientPublicationsPostedDisplayQueue = new Queue();
		private Queue _clientConnectionsToPublicationsDisplayQueue = new Queue();
		private Queue _publicationVariablesDisplayQueue = new Queue();
		private Queue _publicationStatisticsUpdateQueue = new Queue();
		private Queue _publicationAttachedClientsUpdateQueue = new Queue();
		
		private DPE_ClientIdentificationCredential _currentSelectedCredentialsOnAllConnectionsByHostTreeView;
		private DPE_ClientIdentificationCredential _currentSelectedCredentialsOnPublishersClientByHostTreeView;
		
		private string _selectedPublicationNameSelectedOnPublicationsTreeView;
		
		private CustomEventLog _stxEventLog;
		
		private Queue _serviceStatusUpdateTaskQueue = new Queue();
		
		private UtilitiesLibrary.VisualUtilities.ControlBlink.ControlBlinker _controlBlinker = new UtilitiesLibrary.VisualUtilities.ControlBlink.ControlBlinker();
		private System.Timers.Timer tmrDataUpdate;
		
		private System.Timers.Timer _serverConnectionTimer;
		
		
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public frmDPEServerClientAppMainForm()
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
			
			// Add any initialization after the InitializeComponent() call.
			
			AppRunCheck.Check_If_IAm_Running_ExitIfTrue_And_ShowMessage();
			
			
			
			this._serverConnectionTimer = new System.Timers.Timer(1000);
			this._serverConnectionTimer.Elapsed += this.EventHandling_serverConnectionTimer_Elapsed;
			this._serverConnectionTimer.AutoReset = false;
			
		}
		
#endregion
		
#region  < SAFE UI ACCESS >
		
#region  < TREE VIEW >
		
		delegate void TreeView_AddNode_Delegate(System.Windows.Forms.TreeView treeNodeViewCtrl, TreeNode node);
		
		private void TreeView_AddNode(System.Windows.Forms.TreeView treeNodeViewCtrl, TreeNode node)
		{
			if (treeNodeViewCtrl.InvokeRequired)
			{
				TreeView_AddNode_Delegate d = new TreeView_AddNode_Delegate(TreeView_AddNode);
				this.Invoke(d, new object[] {treeNodeViewCtrl, node});
			}
			else
			{
				treeNodeViewCtrl.Nodes.Add(node);
			}
		}
		
		
#endregion
		
#region  < DATA GRID VIEW  >
		
		delegate void DataGridView_DataSource_Delegate(DataGridView dataGridViewControl, DataTable datasource);
		
		private void DataGridView_DataSource(DataGridView dataGridViewControl, DataTable datasource)
		{
			if (dataGridViewControl.InvokeRequired)
			{
				DataGridView_DataSource_Delegate d = new DataGridView_DataSource_Delegate(DataGridView_DataSource);
				this.Invoke(d, new object[] {dataGridViewControl, datasource});
			}
			else
			{
				dataGridViewControl.DataSource = datasource;
			}
		}
		
#endregion
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void _STXDataSocketClient_NewClientConnection()
		{
			try
			{
				this.EnqueueClientsRegistryUpdateTask();
			}
			catch (Exception)
			{
			}
		}
		
		private void _STXDataSocketClient_ClientDisconnection()
		{
			try
			{
				this.EnqueueClientsRegistryUpdateTask();
			}
			catch (Exception)
			{
			}
		}
		
		private void _STXDataSocketClient_NewPublicaitonPosted()
		{
			try
			{
				this.EnqueuePublicationsRegistryUpdateTask();
			}
			catch (Exception)
			{
			}
		}
		
		private void _STXDataSocketClient_PublicationDisposed()
		{
			try
			{
				this.EnqueuePublicationsRegistryUpdateTask();
			}
			catch (Exception)
			{
			}
		}
		
		private void _STXDataSocketClient_AutomaticConnectionWithServerPerformed()
		{
			try
			{
				try
				{
					this._controlBlinker.StopBlinking(this.txtConnectionStatusLabel);
					this.txtConnectionStatusLabel.Text = "Connected to DSS Service";
					this.txtConnectionStatusLabel.BackColor = Color.GreenYellow;
					this.EnqueueUpdateFullServiceStatusTask();
				}
				catch (Exception)
				{
				}
			}
			catch (Exception)
			{
			}
		}
		
		private void ConnectionWithServerLost()
		{
			try
			{
				this.txtConnectionStatusLabel.Text = "Connection With Server Lost!!!!";
				this.txtConnectionStatusLabel.BackColor = Color.Gainsboro;
				this._controlBlinker.StartUndefinedIntervalControlBlink(this.txtConnectionStatusLabel, Color.Gainsboro, Color.Red);
				this.ClearControls();
			}
			catch (Exception)
			{
			}
		}
		
		private void _stxEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				if (UIControlsSafeAccessFunctions.ListBox_Items_Count(this.lstSTXEventLog) > 1000)
				{
					UIControlsSafeAccessFunctions.ListBox_Items_Clear(this.lstSTXEventLog);
				}
				string item = LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine);
				UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstSTXEventLog, item);
			}
			catch (Exception ex)
			{
				this.lstSTXEventLog.Items.Add(ex.Message);
			}
		}
		
		private void EventHandling_serverConnectionTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				this._serverConnectionTimer.Stop();
				try
				{
					this.ConnectToSTXDataSocketServer();
				}
				catch (Exception ex)
				{
					this.lstSTXEventLog.Items.Add(ex.Message);
					this.btnConnectToServer.Visible = true;
					MessageBox.Show(ex.Message);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
#endregion
		
#region  < UI MANAGEMENT METHODS >
		
		private void ClearControls()
		{
			try
			{
				this._currentSelectedCredentialsOnAllConnectionsByHostTreeView = null;
				this._currentSelectedCredentialsOnPublishersClientByHostTreeView = null;
				//all connections
				this.lstvClientSubscriptors.Items.Clear();
				this.lsvAllConnectionsPostedPublications.Items.Clear();
				this.lsvAllConnectionsConnectionToPublications.Items.Clear();
				this.tvwClientSubscriptors.Nodes.Clear();
				this.lsvAllConnectionsByHostPublicationsPosted.Items.Clear();
				this.lsvAllConnectionsByHostConnectionToPublications.Items.Clear();
				//publisher clients
				this.lsvPublisherClients.Items.Clear();
				this.lsvPublisherConnectionsAllPublicationsPosted.Items.Clear();
				this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Items.Clear();
				this.tvwPublisherClients.Nodes.Clear();
				this.lsvPublisherClientsViewByHostPostedPublications.Items.Clear();
				this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Items.Clear();
				
				//publications
				//table view
				this.lstAvailablePublications.Items.Clear();
				this.lsvPublicationREsumeTableViewVariablesList.Items.Clear();
				this.lsvPublicationsREsumeConnectedCLientsList.Items.Clear();
				this.dgrPublicationDataUpdateStatisticsListView.DataSource = null;
				//tree view
				this.lsvPublicationTreeViewVariablesList.Items.Clear();
				this.lsvPublicationsREsumeTreeviewConnectedClients.Items.Clear();
				this.dgrPublicationDataUpdateStatisticsTreeView.DataSource = null;
				
				
			}
			catch (Exception)
			{
			}
		}
		
		private void AdjustListViewTableViewColSize(ListView listView)
		{
			try
			{
				int colWidth = 0;
				colWidth = (int) ((double) listView.Width / listView.Columns.Count);
				ColumnHeader col;
				IEnumerator enumm = listView.Columns.GetEnumerator();
				while (enumm.MoveNext())
				{
					col = (System.Windows.Forms.ColumnHeader) enumm.Current;
					col.Width = colWidth;
				}
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < CONNECTION >
		
		private void ConnectToSTXDataSocketServer()
		{
			this.ConnectWithService();
			this.LoadServerParameters();
			this.UpdateFullServiceStatusTask();
		}
		
		private void ConnectWithService()
		{
			this._DPEPublicationsClient = new DPE_DataPublicationsClient(DPE_ClientType.StatusViewerClientType);
			this._DPEPublicationsClient.NewClientConnectionOnServer += this._STXDataSocketClient_NewClientConnection;
			this._DPEPublicationsClient.ClientDisconnectionOnServer += this._STXDataSocketClient_ClientDisconnection;
			this._DPEPublicationsClient.NewPublicaitonPosted += this._STXDataSocketClient_NewPublicaitonPosted;
			this._DPEPublicationsClient.PublicationDisposed += this._STXDataSocketClient_PublicationDisposed;
			this._DPEPublicationsClient.AutomaticConnectionWithServerPerformed += this._STXDataSocketClient_AutomaticConnectionWithServerPerformed;
			this._DPEPublicationsClient.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
			this.Text = this.Text + " -  Client : " + this._DPEPublicationsClient.ClientName;
			try
			{
				this._DPEPublicationsClient.ConnectToServer();
				this._controlBlinker.StopBlinking(this.txtConnectionStatusLabel);
				this.txtConnectionStatusLabel.Text = "Connected to DSS Service";
				this.txtConnectionStatusLabel.BackColor = Color.GreenYellow;
				this.WindowState = FormWindowState.Maximized;
			}
			catch (Exception)
			{
				this.txtConnectionStatusLabel.Text = "NOT Connected to Server";
				this.txtConnectionStatusLabel.BackColor = Color.Red;
				this._controlBlinker.StartUndefinedIntervalControlBlink(this.txtConnectionStatusLabel, Color.Gainsboro, Color.Red);
				throw;
			}
			
		}
		
		private void LoadServerParameters()
		{
			DataTable dt = default(DataTable);
			dt = this._DPEPublicationsClient.ServerParametersTable;
			this.dgrdServerParameters.DataSource = dt;
			int colWidth = 0;
			colWidth = (int) ((double) this.dgrdServerParameters.Width / dt.Columns.Count);
			DataGridViewColumn col = default(DataGridViewColumn);
			foreach (DataGridViewColumn tempLoopVar_col in this.dgrdServerParameters.Columns)
			{
				col = tempLoopVar_col;
				col.Width = colWidth;
			}
		}
		
#endregion
		
#region  < UPDATE METHODS >
		
		private void UpdateFullServiceStatusTask()
		{
			this.UpdateClientsRegistry();
			this.UpdatePublisherClientsRegistry();
			this.UpdatePublicationsRegistry();
		}
		
		private void EnqueueUpdateFullServiceStatusTask()
		{
			try
			{
				UpdateTask task = new UpdateTask(UpdateTaskFlag.fullStatusUpdate);
				lock(this._serviceStatusUpdateTaskQueue)
				{
					this._serviceStatusUpdateTaskQueue.Enqueue(task);
				}
				this.tmrDataUpdate.Start();
			}
			catch (Exception)
			{
			}
		}
		
		private void EnqueueClientsRegistryUpdateTask()
		{
			try
			{
				UpdateTask task = new UpdateTask(UpdateTaskFlag.clientsRegistryStatusUpdate);
				lock(this._serviceStatusUpdateTaskQueue)
				{
					this._serviceStatusUpdateTaskQueue.Enqueue(task);
				}
				this.tmrDataUpdate.Start();
			}
			catch (Exception)
			{
			}
		}
		
		private void EnqueuePublicationsRegistryUpdateTask()
		{
			try
			{
				UpdateTask task = new UpdateTask(UpdateTaskFlag.publicationsRegistryStatusUpdate);
				lock(this._serviceStatusUpdateTaskQueue)
				{
					this._serviceStatusUpdateTaskQueue.Enqueue(task);
				}
				this.tmrDataUpdate.Start();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < CLIENTS REGISTRY >
		
		private void UpdateClientsRegistry()
		{
			this._clientConnectionsMasterTable = this._DPEPublicationsClient.GetClientsRegistryTable();
			try
			{
				//-----------------------------------------------------------
				//sets up the listview control
				this.lstvClientSubscriptors.View = View.Details;
				this.lstvClientSubscriptors.HideSelection = false;
				this.lstvClientSubscriptors.FullRowSelect = true;
				this.lstvClientSubscriptors.GridLines = true;
				this.lstvClientSubscriptors.MultiSelect = false;
				
				this.lstvClientSubscriptors.Items.Clear();
				this.lstvClientSubscriptors.Columns.Clear();
				this.lstvClientSubscriptors.Columns.Add("Client Name", 150, HorizontalAlignment.Left);
				this.lstvClientSubscriptors.Columns[0].ImageIndex = 2;
				
				this.lstvClientSubscriptors.Columns.Add("Host Name", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[1].ImageIndex = 0;
				
				this.lstvClientSubscriptors.Columns.Add("Client Application Domain", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[2].ImageIndex = 1;
				
				this.lstvClientSubscriptors.Columns.Add("Client ID", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[3].ImageIndex = 3;
				
				this.lstvClientSubscriptors.Columns.Add("Network ID", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[4].ImageIndex = 4;
				
				this.lstvClientSubscriptors.Columns.Add("ConnectionDateTime", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[5].ImageIndex = 5;
				
				this.lstvClientSubscriptors.Columns.Add("Type", 100, HorizontalAlignment.Center);
				this.lstvClientSubscriptors.Columns[6].ImageIndex = 6;
				
				
				//-----------------------------------------------------------
				//sets up the trew view control
				this.tvwClientSubscriptors.Nodes.Clear();
				this.tvwClientSubscriptors.HideSelection = false;
				this.tvwClientSubscriptors.FullRowSelect = true;
				
				
				if (!(this._clientConnectionsMasterTable == null))
				{
					
					
					DataTable dt = this._clientConnectionsMasterTable.Copy();
					
					DataRow row = default(DataRow);
					IEnumerator rowEnumm = default(IEnumerator);
					ListViewItem STXDssClientItem = default(ListViewItem);
					string ClientHostName = "";
					string clientName = "";
					string clientAppDomain = "";
					string ClientID = "";
					string NetworkID = "";
					string ConnectionDateTime = "";
					string clientType = "";
					
					Hashtable hostNamesNodesHashTable = new Hashtable();
					Hashtable appDomainNodesHashTable = new Hashtable();
					Hashtable hostNodeToApplicationDomainNodesTables = new Hashtable();
					
					
					TreeNode hostNameNode = default(TreeNode);
					TreeNode ApplicationDomainNode = default(TreeNode);
					
					rowEnumm = dt.Rows.GetEnumerator();
					while (rowEnumm.MoveNext())
					{
						string nodeText = "";
						row = (System.Data.DataRow) rowEnumm.Current;
						
						clientName = System.Convert.ToString(row["Client Name"]);
						clientAppDomain = System.Convert.ToString(row["Client AppDomain"]);
						ClientHostName = System.Convert.ToString(row["Client HostName"]);
						ClientID = System.Convert.ToString(row["Client ID"]);
						NetworkID = System.Convert.ToString(row["Network ID"]);
						ConnectionDateTime = System.Convert.ToString(row["Connection Date Time"]);
						clientType = System.Convert.ToString(row["Type"]);
						
						DPE_ClientIdentificationCredential clientCredentials = new DPE_ClientIdentificationCredential(clientName, ClientID);
						
						
						//*****************************************************************************
						//fills the list view control
						STXDssClientItem = new ListViewItem(clientName);
						STXDssClientItem.Tag = clientCredentials;
						this.lstvClientSubscriptors.Items.Add(STXDssClientItem);
						
						STXDssClientItem.SubItems.Add(ClientHostName);
						STXDssClientItem.SubItems.Add(clientAppDomain);
						STXDssClientItem.SubItems.Add(ClientID);
						STXDssClientItem.SubItems.Add(NetworkID);
						STXDssClientItem.SubItems.Add(ConnectionDateTime);
						STXDssClientItem.SubItems.Add(clientType);
						
						
						//*****************************************************************************
						//fills the TREE VIEW control
						//creates the host node
						if (!hostNamesNodesHashTable.ContainsKey(ClientHostName))
						{
							//creates the host name node
							hostNameNode = new TreeNode(ClientHostName, 0, 0);
							hostNameNode.Tag = HOSTNAME_NODE;
							//adds the host name node to the main host nodes name table
							hostNamesNodesHashTable.Add(ClientHostName, hostNameNode);
							
							if (!hostNodeToApplicationDomainNodesTables.ContainsKey(ClientHostName))
							{
								//create the app domain node and adds to the current host domain node
								ApplicationDomainNode = new TreeNode(clientAppDomain, 1, 1);
								ApplicationDomainNode.Tag = "APP_DOMAIN_NODE";
								hostNameNode.Nodes.Add(ApplicationDomainNode);
								
								//creates a table to hold all the application nodes of the host name node
								//and adds the current app domain node
								Hashtable AppNodesInHostNameTable = new Hashtable();
								AppNodesInHostNameTable.Add(clientAppDomain, ApplicationDomainNode);
								
								//adds the table of app nodes od the current host to a table
								hostNodeToApplicationDomainNodesTables.Add(ClientHostName, AppNodesInHostNameTable);
								
							}
							else
							{
								//retrieves the table of the app domain nodes of the current host name
								Hashtable AppNodesInHostNameTable = default(Hashtable);
								AppNodesInHostNameTable = (Hashtable) (hostNodeToApplicationDomainNodesTables[ClientHostName]);
								
								//revies if it contains the app domain node
								if (AppNodesInHostNameTable.ContainsKey(clientAppDomain))
								{
									//gets the current app domain node
									ApplicationDomainNode = (System.Windows.Forms.TreeNode) (AppNodesInHostNameTable[clientAppDomain]);
								}
								else
								{
									//if not exists then creates it, saves in to the table of the app domain
									//nodes of the current host name
									ApplicationDomainNode = new TreeNode(clientAppDomain, 1, 1);
									ApplicationDomainNode.Tag = "APP_DOMAIN_NODE";
									AppNodesInHostNameTable.Add(clientAppDomain, ApplicationDomainNode);
									hostNameNode.Nodes.Add(ApplicationDomainNode);
								}
							}
						}
						else
						{
							//gets the host node
							hostNameNode = (System.Windows.Forms.TreeNode) (hostNamesNodesHashTable[ClientHostName]);
							//gets the application domain node according to the client host name
							if (!hostNodeToApplicationDomainNodesTables.ContainsKey(ClientHostName))
							{
								//create the app domain node and adds to the current host domain node
								ApplicationDomainNode = new TreeNode(clientAppDomain);
								ApplicationDomainNode.Tag = "APP_DOMAIN_NODE";
								hostNameNode.Nodes.Add(ApplicationDomainNode);
								
								//creates a table to hold all the application nodes of the host name node
								//and adds the current app domain node
								Hashtable AppNodesInHostNameTable = new Hashtable();
								AppNodesInHostNameTable.Add(clientAppDomain, ApplicationDomainNode);
								
								//adds the table of app nodes od the current host to a table
								hostNodeToApplicationDomainNodesTables.Add(ClientHostName, AppNodesInHostNameTable);
							}
							else
							{
								//retrieves the table of the app domain nodes of the current host name
								Hashtable AppNodesInHostNameTable = default(Hashtable);
								AppNodesInHostNameTable = (Hashtable) (hostNodeToApplicationDomainNodesTables[ClientHostName]);
								
								//revies if it contains the app domain node
								if (AppNodesInHostNameTable.ContainsKey(clientAppDomain))
								{
									//gets the current app domain node
									ApplicationDomainNode = (System.Windows.Forms.TreeNode) (AppNodesInHostNameTable[clientAppDomain]);
								}
								else
								{
									//if not exists then creates it, saves in to the table of the app domain
									//nodes of the current host name
									ApplicationDomainNode = new TreeNode(clientAppDomain, 1, 1);
									ApplicationDomainNode.Tag = "APP_DOMAIN_NODE";
									AppNodesInHostNameTable.Add(clientAppDomain, ApplicationDomainNode);
									hostNameNode.Nodes.Add(ApplicationDomainNode);
								}
							}
						}
						if (ClientID == this._DPEPublicationsClient.ClientID)
						{
							nodeText = clientName + "   -  ( THIS INSTANCE CLIENT )";
						}
						else
						{
							nodeText = clientName;
						}
						TreeNode clientNode = new TreeNode(nodeText, 2, 2);
						clientNode.Tag = clientCredentials;
						ApplicationDomainNode.Nodes.Add(clientNode);
						
						nodeText = "CLIENT ID    =    " + ClientID;
						TreeNode clientIDNode = new TreeNode(nodeText, 3, 3);
						clientIDNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientIDNode);
						
						nodeText = "NETWORK ID    =    " + NetworkID;
						TreeNode clientNetIDNode = new TreeNode(nodeText, 4, 4);
						clientNetIDNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientNetIDNode);
						
						nodeText = "CONNECTION TIME    =    " + ConnectionDateTime;
						TreeNode clientConnectionTimeNode = new TreeNode(nodeText, 5, 5);
						clientConnectionTimeNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientConnectionTimeNode);
						
						nodeText = "TYPE   =    " + clientType;
						TreeNode clientTypeNode = new TreeNode(nodeText, 6, 6);
						clientTypeNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientTypeNode);
						
						hostNameNode.Expand();
						ApplicationDomainNode.Expand();
						
					}
					
					//at the end then is added all the host nodes
					
					IEnumerator nodeEnumm = default(IEnumerator);
					nodeEnumm = hostNamesNodesHashTable.GetEnumerator();
					while (nodeEnumm.MoveNext())
					{
						hostNameNode = (System.Windows.Forms.TreeNode) (((DictionaryEntry) nodeEnumm.Current).Value);
						this.TreeView_AddNode(this.tvwClientSubscriptors, hostNameNode);
					}
					this.AdjustListViewTableViewColSize(this.lstvClientSubscriptors);
				}
			}
			catch (Exception)
			{
			}
		}
		
		private void DisplayListOfPostedPublicationsByClient(DPE_ClientIdentificationCredential ClientCredentials, ListView listViewControl)
		{
			//retrieves the table of all available publications
			DataTable publicationsTableDt = this._DPEPublicationsClient.GetPublicationsRegistryTable();
			try
			{
				listViewControl.Items.Clear();
				listViewControl.Columns.Clear();
				listViewControl.View = View.Details;
				listViewControl.GridLines = true;
				listViewControl.FullRowSelect = true;
				listViewControl.HideSelection = false;
				listViewControl.MultiSelect = false;
				
				listViewControl.Columns.Add("Name", 200);
				listViewControl.Columns[0].ImageIndex = 0;
				
				listViewControl.Columns.Add("Creation DateTime", 200, HorizontalAlignment.Center);
				listViewControl.Columns[1].ImageIndex = 1;
				
				listViewControl.Columns.Add("Variables Count", 150, HorizontalAlignment.Center);
				listViewControl.Columns[2].ImageIndex = 2;
				
				listViewControl.Columns.Add("Sockets Server Port", 150, HorizontalAlignment.Center);
				listViewControl.Columns[3].ImageIndex = 3;
				
				listViewControl.Columns.Add("Subscriptors Count", 150, HorizontalAlignment.Center);
				listViewControl.Columns[4].ImageIndex = 6;
				
				IEnumerator rowEnumm = default(IEnumerator);
				DataRow[] resultRows = null;
				string selectionCriteria = "";
				selectionCriteria = "[Publication Owner Name] = \'" + ClientCredentials.ClientName + "\'";
				resultRows = publicationsTableDt.Select(selectionCriteria);
				if (resultRows.Length > 0)
				{
					rowEnumm = resultRows.GetEnumerator();
					DataRow row = default(DataRow);
					string publicationName = "";
					string publicationDAteTime = "";
					string variablesPublised = "";
					string publicationPort = "";
					string connectedClients = "";
					
					
					while (rowEnumm.MoveNext())
					{
						row = (System.Data.DataRow) rowEnumm.Current;
						publicationName = System.Convert.ToString(row["Publication Name"]);
						publicationDAteTime = System.Convert.ToString(row["Publication Creation DateTime"]);
						variablesPublised = System.Convert.ToString(row["Variables Published Count"]);
						publicationPort = System.Convert.ToString(row["Publication Sockets Server Port"]);
						connectedClients = System.Convert.ToString(row["Subscriptors Count"]);
						
						ListViewItem item = new ListViewItem(publicationName);
						item.Tag = publicationName;
						item.SubItems.Add(publicationDAteTime);
						item.SubItems.Add(variablesPublised);
						item.SubItems.Add(publicationPort);
						item.SubItems.Add(connectedClients);
						
						listViewControl.Items.Add(item);
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private void DisplayOfClientConnectionsToPublications(DPE_ClientIdentificationCredential clientCredentials, ListView listViewControl)
		{
			CustomList listOfConnectionToPublicationsNames = this._DPEPublicationsClient.GetListOfSubscriptionsToPublications(clientCredentials.ClientID);
			DataTable publicationsDataTable = this._DPEPublicationsClient.GetPublicationsRegistryTable();
			try
			{
				listViewControl.Items.Clear();
				listViewControl.Columns.Clear();
				listViewControl.View = View.Details;
				listViewControl.GridLines = true;
				listViewControl.FullRowSelect = true;
				listViewControl.HideSelection = false;
				listViewControl.MultiSelect = false;
				
				listViewControl.Columns.Add("Name", 200);
				listViewControl.Columns[0].ImageIndex = 0;
				
				listViewControl.Columns.Add("Creation DateTime", 200, HorizontalAlignment.Center);
				listViewControl.Columns[1].ImageIndex = 1;
				
				listViewControl.Columns.Add("Variables Count", 150, HorizontalAlignment.Center);
				listViewControl.Columns[2].ImageIndex = 2;
				
				listViewControl.Columns.Add("Sockets Server Port", 150, HorizontalAlignment.Center);
				listViewControl.Columns[3].ImageIndex = 3;
				
				listViewControl.Columns.Add("Subscriptors Count", 150, HorizontalAlignment.Center);
				listViewControl.Columns[4].ImageIndex = 6;
				
				string publicationName = "";
				string publicationDAteTime = "";
				string variablesPublised = "";
				string publicationPort = "";
				string connectedClients = "";
				
				IEnumerator publicationEnum = default(IEnumerator);
				publicationEnum = listOfConnectionToPublicationsNames.GetEnumerator();
				while (publicationEnum.MoveNext())
				{
					publicationName = System.Convert.ToString(publicationEnum.Current);
					DataRow[] resultRows = null;
					string selectionCriteria = "";
					selectionCriteria = "[Publication Name] = \'" + publicationName + "\'";
					resultRows = publicationsDataTable.Select(selectionCriteria);
					if (resultRows.Length > 0)
					{
						IEnumerator rowEnum = resultRows.GetEnumerator();
						DataRow row = default(DataRow);
						while (rowEnum.MoveNext())
						{
							
							row = (System.Data.DataRow) rowEnum.Current;
							publicationName = System.Convert.ToString(row["Publication Name"]);
							publicationDAteTime = System.Convert.ToString(row["Publication Creation DateTime"]);
							variablesPublised = System.Convert.ToString(row["Variables Published Count"]);
							publicationPort = System.Convert.ToString(row["Publication Sockets Server Port"]);
							connectedClients = System.Convert.ToString(row["Subscriptors Count"]);
							
							ListViewItem item = new ListViewItem(publicationName);
							item.Tag = publicationName;
							item.SubItems.Add(publicationDAteTime);
							item.SubItems.Add(variablesPublised);
							item.SubItems.Add(publicationPort);
							item.SubItems.Add(connectedClients);
							
							listViewControl.Items.Add(item);
							
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
#endregion
		
#region  < PUBLISHERS REGISTRY >
		
		private void UpdatePublisherClientsRegistry()
		{
			this._clientPublishersTable = this._DPEPublicationsClient.GetPublihsersRegistryTable();
			try
			{
				//-----------------------------------------------------------
				//sets up the listview control
				this.lsvPublisherClients.View = View.Details;
				this.lsvPublisherClients.HideSelection = false;
				this.lsvPublisherClients.FullRowSelect = true;
				this.lsvPublisherClients.GridLines = true;
				this.lsvPublisherClients.MultiSelect = false;
				
				this.lsvPublisherClients.Items.Clear();
				this.lsvPublisherClients.Columns.Clear();
				this.lsvPublisherClients.Columns.Add("Client Name");
				this.lsvPublisherClients.Columns[0].ImageIndex = 2;
				
				this.lsvPublisherClients.Columns.Add("Host Name");
				this.lsvPublisherClients.Columns[1].ImageIndex = 0;
				
				this.lsvPublisherClients.Columns.Add("Client Application Domain", 150);
				this.lsvPublisherClients.Columns[2].ImageIndex = 1;
				
				this.lsvPublisherClients.Columns.Add("Client ID");
				this.lsvPublisherClients.Columns[3].ImageIndex = 3;
				
				this.lsvPublisherClients.Columns.Add("Network ID");
				this.lsvPublisherClients.Columns[4].ImageIndex = 4;
				
				this.lsvPublisherClients.Columns.Add("Publications Posted");
				this.lsvPublisherClients.Columns[5].ImageIndex = 6;
				
				
				//-----------------------------------------------------------
				//sets up the trew view control
				this.tvwPublisherClients.Nodes.Clear();
				this.tvwPublisherClients.HideSelection = false;
				this.tvwPublisherClients.FullRowSelect = true;
				
				if (!(this._clientConnectionsMasterTable == null))
				{
					
					
					DataTable dt = this._clientPublishersTable.Copy();
					
					DataRow row = default(DataRow);
					IEnumerator rowEnumm = default(IEnumerator);
					ListViewItem STXDSSPublisherClientItem = default(ListViewItem);
					string ClientHostName = "";
					string clientApplicationDomain = "";
					string clientName = "";
					string ClientID = "";
					string ClientNetworkID = "";
					int publicationsPosted = 0;
					
					Hashtable hostNamesNodesHashTable = new Hashtable();
					TreeNode hostNameNode = default(TreeNode);
					
					rowEnumm = dt.Rows.GetEnumerator();
					while (rowEnumm.MoveNext())
					{
						string nodeText = "";
						row = (System.Data.DataRow) rowEnumm.Current;
						clientName = System.Convert.ToString(row["Client Name"]);
						ClientHostName = System.Convert.ToString(row["Client Hostname"]);
						clientApplicationDomain = System.Convert.ToString(row["Client AppDomain"]);
						ClientID = System.Convert.ToString(row["Client ID"]);
						ClientNetworkID = System.Convert.ToString(row["Network ID"]);
						publicationsPosted = System.Convert.ToInt32((System.Convert.ToString(row["Publications Count"])));
						
						DPE_ClientIdentificationCredential clientCredentials = new DPE_ClientIdentificationCredential(clientName, ClientID);
						
						//********************************************************************
						//fills the list view control
						STXDSSPublisherClientItem = new ListViewItem(clientName);
						STXDSSPublisherClientItem.Tag = clientCredentials;
						this.lsvPublisherClients.Items.Add(STXDSSPublisherClientItem);
						STXDSSPublisherClientItem.SubItems.Add(ClientHostName);
						STXDSSPublisherClientItem.SubItems.Add(clientApplicationDomain);
						STXDSSPublisherClientItem.SubItems.Add(ClientID);
						STXDSSPublisherClientItem.SubItems.Add(ClientNetworkID);
						STXDSSPublisherClientItem.SubItems.Add(System.Convert.ToString(publicationsPosted));
						
						
						//********************************************************************
						//fills the tree view control
						
						if (!hostNamesNodesHashTable.ContainsKey(ClientHostName))
						{
							hostNameNode = new TreeNode(ClientHostName, 0, 0);
							hostNameNode.Tag = HOSTNAME_NODE;
							hostNamesNodesHashTable.Add(ClientHostName, hostNameNode);
						}
						else
						{
							hostNameNode = (System.Windows.Forms.TreeNode) (hostNamesNodesHashTable[ClientHostName]);
						}
						
						
						
						if (ClientID == this._DPEPublicationsClient.ClientID)
						{
							nodeText = clientName + "   -  ( THIS INSTANCE CLIENT )";
						}
						else
						{
							nodeText = clientName;
						}
						TreeNode clientNode = new TreeNode(nodeText, 1, 1);
						clientNode.Tag = clientCredentials;
						hostNameNode.Nodes.Add(clientNode);
						
						nodeText = "CLIENT ID    =    " + ClientID;
						
						TreeNode clientIDNode = new TreeNode(nodeText, 2, 2);
						clientIDNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientIDNode);
						
						nodeText = "NETWORK ID    =    " + ClientNetworkID;
						TreeNode clientNetIDNode = new TreeNode(nodeText, 3, 3);
						clientNetIDNode.Tag = clientCredentials;
						clientNode.Nodes.Add(clientNetIDNode);
						
						nodeText = "No. PUBLICATIONS POSTED    =    " + System.Convert.ToString(publicationsPosted);
						TreeNode publicationsNode = new TreeNode(nodeText, 6, 6);
						publicationsNode.Tag = clientCredentials;
						clientNode.Nodes.Add(publicationsNode);
						
						hostNameNode.Expand();
						
					}
					
					//at the end then is added all the host nodes
					
					IEnumerator nodeEnumm = default(IEnumerator);
					nodeEnumm = hostNamesNodesHashTable.GetEnumerator();
					while (nodeEnumm.MoveNext())
					{
						hostNameNode = (System.Windows.Forms.TreeNode) (((DictionaryEntry) nodeEnumm.Current).Value);
						this.TreeView_AddNode(this.tvwPublisherClients, hostNameNode);
					}
					this.AdjustListViewTableViewColSize(this.lsvPublisherClients);
				}
			}
			catch (Exception)
			{
			}
		}
		
		
#endregion
		
#region  <  PUBLICATIONS REGISTRY >
		
		private void UpdatePublicationsRegistry()
		{
			this._publicationsMasterTable = this._DPEPublicationsClient.GetPublicationsRegistryTable();
			try
			{
				this.lstAvailablePublications.Items.Clear();
				this.lstAvailablePublications.Columns.Clear();
				this.lstAvailablePublications.View = View.Details;
				this.lstAvailablePublications.GridLines = true;
				this.lstAvailablePublications.FullRowSelect = true;
				this.lstAvailablePublications.HideSelection = false;
				this.lstAvailablePublications.MultiSelect = false;
				
				this.lstAvailablePublications.Columns.Add("Publications Group", 350);
				this.lstAvailablePublications.Columns[0].ImageIndex = 0;
				
				this.lstAvailablePublications.Columns.Add("Publication Name", 350);
				this.lstAvailablePublications.Columns[1].ImageIndex = 1;
				
				this.lstAvailablePublications.Columns.Add("Creation DateTime", 200);
				this.lstAvailablePublications.Columns[2].ImageIndex = 2;
				
				this.lstAvailablePublications.Columns.Add("Owner Name", 200);
				this.lstAvailablePublications.Columns[3].ImageIndex = 3;
				
				this.lstAvailablePublications.Columns.Add("Owner HostName", 200);
				this.lstAvailablePublications.Columns[4].ImageIndex = 4;
				
				this.lstAvailablePublications.Columns.Add("Application Domain", 200);
				this.lstAvailablePublications.Columns[5].ImageIndex = 5;
				
				this.lstAvailablePublications.Columns.Add("Variables Published Count", 200);
				this.lstAvailablePublications.Columns[6].ImageIndex = 6;
				
				this.lstAvailablePublications.Columns.Add("Sockets Server Port", 200);
				this.lstAvailablePublications.Columns[7].ImageIndex = 7;
				
				this.lstAvailablePublications.Columns.Add("Subscriptors Count", 200);
				this.lstAvailablePublications.Columns[8].ImageIndex = 8;
				
				
				
				//tree view variables
				this.tvwPublicationsREsumeTreeView.Nodes.Clear();
				this.tvwPublicationsREsumeTreeView.FullRowSelect = true;
				this.tvwPublicationsREsumeTreeView.HideSelection = false;
				
				Hashtable hostNameNodesTable = new Hashtable();
				Hashtable PublicationOwnerNodesTable = new Hashtable();
				Hashtable groupsNodesTable = new Hashtable();
				
				TreeNode hostNameNode = default(TreeNode);
				TreeNode ownerNameNode = default(TreeNode);
				
				
				DataRow row = default(DataRow);
				DataTable dt = this._publicationsMasterTable.Copy();
				IEnumerator rowEnum = dt.Rows.GetEnumerator();
				string publicationsGroup = "";
				string publicationName = "";
				string creationDateTime = "";
				string OwnerName = "";
				string OwnerHostName = "";
				string applicationDomain = "";
				string varsCount = "";
				string P2PPort = "";
				string SubscriptorsCount = "";
				string nodetext = "";
				string selectionCriteria = "";
				
				while (rowEnum.MoveNext())
				{
					try
					{
						row = (System.Data.DataRow) rowEnum.Current;
						publicationsGroup = System.Convert.ToString(row["Publications Group"]);
						publicationName = System.Convert.ToString(row["Publication Name"]);
						creationDateTime = System.Convert.ToString(row["Publication Creation DateTime"]);
						OwnerName = System.Convert.ToString(row["Publication Owner Name"]);
						OwnerHostName = System.Convert.ToString(row["Publication Owner Hostname"]);
						applicationDomain = System.Convert.ToString(row["Application Domain"]);
						varsCount = System.Convert.ToString(row["Variables Published Count"]);
						P2PPort = System.Convert.ToString(row["Publication Sockets Server Port"]);
						SubscriptorsCount = System.Convert.ToString(row["Subscriptors Count"]);
						
						//fills the list view control
						ListViewItem item = new ListViewItem(publicationsGroup);
						item.Tag = publicationName;
						item.SubItems.Add(publicationName);
						item.SubItems.Add(creationDateTime);
						item.SubItems.Add(OwnerName);
						item.SubItems.Add(OwnerHostName);
						item.SubItems.Add(applicationDomain);
						item.SubItems.Add(varsCount);
						item.SubItems.Add(P2PPort);
						item.SubItems.Add(SubscriptorsCount);
						this.lstAvailablePublications.Items.Add(item);
						//--------------------------------------------------
						//fills the tree view option
						
						//gets the host node
						if (!hostNameNodesTable.ContainsKey(OwnerHostName))
						{
							hostNameNode = new TreeNode(OwnerHostName, 0, 0);
							hostNameNode.Tag = HOSTNAME_NODE;
							hostNameNodesTable.Add(OwnerHostName, hostNameNode);
						}
						else
						{
							hostNameNode = (System.Windows.Forms.TreeNode) (hostNameNodesTable[OwnerHostName]);
						}
						
						//gets the client node
						if (!PublicationOwnerNodesTable.ContainsKey(OwnerName))
						{
							ownerNameNode = new TreeNode(OwnerName, 1, 1);
							ownerNameNode.Tag = PUBLISHER_NODE;
							PublicationOwnerNodesTable.Add(OwnerName, ownerNameNode);
							hostNameNode.Nodes.Add(ownerNameNode);
							
							//--------------------OWNER NAME  -------------------------------
							//gets all the publication rows of the publishser
							DataRow[] publisherResultRows = null;
							selectionCriteria = "[Publication Owner Name] = \'" + OwnerName + "\'";
							publisherResultRows = dt.Select(selectionCriteria);
							
							if (publisherResultRows.Length > 0)
							{
								groupsNodesTable.Clear();
								
								IEnumerator publisherResRowEnum = default(IEnumerator);
								DataRow publisherResRow = default(DataRow);
								publisherResRowEnum = publisherResultRows.GetEnumerator();
								
								while (publisherResRowEnum.MoveNext())
								{
									publisherResRow = (System.Data.DataRow) publisherResRowEnum.Current;
									publicationsGroup = System.Convert.ToString(publisherResRow["Publications Group"]);
									publicationName = System.Convert.ToString(publisherResRow["Publication Name"]);
									creationDateTime = System.Convert.ToString(publisherResRow["Publication Creation DateTime"]);
									varsCount = System.Convert.ToString(publisherResRow["Variables Published Count"]);
									P2PPort = System.Convert.ToString(publisherResRow["Publication Sockets Server Port"]);
									SubscriptorsCount = System.Convert.ToString(publisherResRow["Subscriptors Count"]);
									
									TreeNode groupNode = default(TreeNode);
									if (!groupsNodesTable.ContainsKey(publicationsGroup))
									{
										groupNode = new TreeNode(publicationsGroup, 2, 2);
										groupNode.Tag = PUBLICATIONS_GROUP;
										ownerNameNode.Nodes.Add(groupNode);
										groupsNodesTable.Add(publicationsGroup, groupNode);
									}
									else
									{
										groupNode = (System.Windows.Forms.TreeNode) (groupsNodesTable[publicationsGroup]);
									}
									
									//create the publication node and attaches it to the ownser node
									TreeNode publicationNode = new TreeNode(publicationName, 3, 3);
									publicationNode.Tag = publicationName;
									groupNode.Nodes.Add(publicationNode);
									
									nodetext = "Creation Date Time    =    " + creationDateTime;
									TreeNode publicationDateTimeNode = new TreeNode(nodetext, 4, 4);
									publicationDateTimeNode.Tag = PUBLICATION_ELEMENT;
									publicationNode.Nodes.Add(publicationDateTimeNode);
									
									nodetext = "No. Variables Published    =    " + varsCount;
									TreeNode variablesPublishedNode = new TreeNode(nodetext, 5, 5);
									variablesPublishedNode.Tag = PUBLICATION_ELEMENT;
									publicationNode.Nodes.Add(variablesPublishedNode);
									
									nodetext = "No. Clients Connected    =    " + SubscriptorsCount;
									TreeNode subscriptorsCountNode = new TreeNode(nodetext, 6, 6);
									subscriptorsCountNode.Tag = PUBLICATION_ELEMENT;
									publicationNode.Nodes.Add(subscriptorsCountNode);
									
									nodetext = "Publication Port    =    " + P2PPort;
									TreeNode publicationPortNode = new TreeNode(nodetext, 7, 7);
									publicationPortNode.Tag = PUBLICATION_ELEMENT;
									publicationNode.Nodes.Add(publicationPortNode);
									//'-------------------------------------------------------------------------
								}
							}
						}
					}
					catch (Exception ex)
					{
						throw (ex);
					}
				}
				IEnumerator nodeEnumm = default(IEnumerator);
				nodeEnumm = hostNameNodesTable.GetEnumerator();
				while (nodeEnumm.MoveNext())
				{
					hostNameNode = (System.Windows.Forms.TreeNode) (((DictionaryEntry) nodeEnumm.Current).Value);
					hostNameNode.Expand();
					this.TreeView_AddNode(this.tvwPublicationsREsumeTreeView, hostNameNode);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private void UpdateAndDisplayListOfVariablesAttachedToPublication(string publicationName, ListView listViewCtrl)
		{
			DataTable VariablesTable = this._DPEPublicationsClient.GetListOfVariablesPublishedOnAPublication(publicationName);
			try
			{
				listViewCtrl.Items.Clear();
				listViewCtrl.Columns.Clear();
				listViewCtrl.View = View.Details;
				listViewCtrl.GridLines = true;
				listViewCtrl.FullRowSelect = true;
				listViewCtrl.HideSelection = false;
				listViewCtrl.MultiSelect = false;
				
				listViewCtrl.Columns.Add("Variable Name", 200);
				listViewCtrl.Columns.Add("DataType", 200);
				
				DataRow row = default(DataRow);
				IEnumerator rowEnumm = default(IEnumerator);
				string varName = "";
				string VarDataType = "";
				rowEnumm = VariablesTable.Rows.GetEnumerator();
				while (rowEnumm.MoveNext())
				{
					row = (System.Data.DataRow) rowEnumm.Current;
					varName = System.Convert.ToString(row[0]);
					VarDataType = System.Convert.ToString(row[1]);
					ListViewItem item = new ListViewItem(varName);
					item.SubItems.Add(VarDataType);
					listViewCtrl.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private void UpdateAndDisplayPublicationDataUpdateStatistics(string publicationName, DataGridView DataGridViewControl)
		{
			DataTable statisticsTable = default(DataTable);
			statisticsTable = this._DPEPublicationsClient.GetPublicationStatisticsTable(publicationName);
			this.DataGridView_DataSource(DataGridViewControl, statisticsTable);
		}
		
		private void UpdatePublicationconnectedClients(string publicationName, ListView displayListViewControl)
		{
			DataTable SubscribedClientsTable = this._DPEPublicationsClient.GetTableOfClientsAttachedToPublication(publicationName);
			try
			{
				displayListViewControl.View = View.Details;
				displayListViewControl.HideSelection = false;
				displayListViewControl.FullRowSelect = true;
				displayListViewControl.GridLines = true;
				displayListViewControl.MultiSelect = false;
				
				displayListViewControl.Items.Clear();
				displayListViewControl.Columns.Clear();
				displayListViewControl.Columns.Add("Client Name", 300);
				displayListViewControl.Columns.Add("Host Name", 200);
				displayListViewControl.Columns.Add("Application Domain", 200);
				displayListViewControl.Columns.Add("ConnectionDateTime", 150);
				displayListViewControl.Columns.Add("Client ID", 200);
				displayListViewControl.Columns.Add("Network ID", 200);
				displayListViewControl.Columns.Add("Connection Mode", 200);
				
				
				DataRow row = default(DataRow);
				IEnumerator rowEnumm = SubscribedClientsTable.Rows.GetEnumerator();
				ListViewItem item = default(ListViewItem);
				
				string ClientHostName = "";
				string clientApplicationDomain = "";
				string clientName = "";
				string ClientID = "";
				string ClientNetworkID = "";
				string ConnectionDateTime = "";
				string connectionMode = "";
				string clientTCPPort = "";
				
				while (rowEnumm.MoveNext())
				{
					row = (System.Data.DataRow) rowEnumm.Current;
					clientName = System.Convert.ToString(row["Client Name"]);
					clientApplicationDomain = System.Convert.ToString(row["Client AppDomain"]);
					ClientHostName = System.Convert.ToString(row["Client HostName"]);
					ClientID = System.Convert.ToString(row["Client ID"]);
					ClientNetworkID = System.Convert.ToString(row["Client Network ID"]);
					ConnectionDateTime = System.Convert.ToString(row["Connection Date Time"]);
					connectionMode = System.Convert.ToString(row["Connection Mode"]);
					
					item = new ListViewItem(clientName);
					item.SubItems.Add(ClientHostName);
					item.SubItems.Add(clientApplicationDomain);
					item.SubItems.Add(ConnectionDateTime);
					item.SubItems.Add(ClientID);
					item.SubItems.Add(ClientNetworkID);
					item.SubItems.Add(connectionMode);
					item.SubItems.Add(clientTCPPort);
					
					
					
					displayListViewControl.Items.Add(item);
				}
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private string GetSelectedPublicationNameFromTreeView()
		{
			if (!(this.tvwPublicationsREsumeTreeView.SelectedNode == null))
			{
				string nodeTagText = "";
				nodeTagText = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
				switch (nodeTagText)
				{
					case HOSTNAME_NODE:
					case PUBLISHER_NODE:
						return null;
					default:
						string publicationName = "";
						publicationName = nodeTagText;
						return publicationName;
				}
			}
			else
			{
				return null;
			}
		}
		
		
#endregion
		
#region  < SUPPORT CLASS >
		
		private class UpdateTask
		{
			public UpdateTaskFlag updateMode;
			private DateTime taskDateTime;
			
			internal UpdateTask(UpdateTaskFlag mode)
			{
				this.updateMode = mode;
				this.taskDateTime = DateTime.Now;
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void STXDataSocketClient_Load(System.Object sender, System.EventArgs e)
		{
			
			
			
			try
			{
				this._stxEventLog = CustomEventLog.GetInstance();
				this._stxEventLog.LogEntryReceived += this._stxEventLog_LogEntryReceived;
			}
			catch (Exception ex)
			{
				this.lstSTXEventLog.Items.Add(ex.Message);
			}
			
			this.tmrDataUpdate = new System.Timers.Timer(500);
			this.tmrDataUpdate.Elapsed += this.tmrDataUpdate_Tick;
			this.tmrDataUpdate.Enabled = true;
			this.tmrDataUpdate.Start();
			
			this.txtConnectionStatusLabel.Text = "Not Connected to DSS Service";
			this.txtConnectionStatusLabel.BackColor = Color.Red;
			this._controlBlinker.StartUndefinedIntervalControlBlink(this.txtConnectionStatusLabel, Color.Gainsboro, Color.Red);
			
			this._serverConnectionTimer.Start();
			
		}
		
		public void frmSTXDataSocketClient_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._DPEPublicationsClient.DisconnectFromServer();
				this._DPEPublicationsClient.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnConnectToServer_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this._DPEPublicationsClient = new DPE_DataPublicationsClient(DPE_ClientType.StatusViewerClientType);
				this._DPEPublicationsClient.NewClientConnectionOnServer += this._STXDataSocketClient_NewClientConnection;
				this._DPEPublicationsClient.ClientDisconnectionOnServer += this._STXDataSocketClient_ClientDisconnection;
				this._DPEPublicationsClient.NewPublicaitonPosted += this._STXDataSocketClient_NewPublicaitonPosted;
				this._DPEPublicationsClient.PublicationDisposed += this._STXDataSocketClient_PublicationDisposed;
				this._DPEPublicationsClient.AutomaticConnectionWithServerPerformed += this._STXDataSocketClient_AutomaticConnectionWithServerPerformed;
				this._DPEPublicationsClient.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
				this._DPEPublicationsClient.ConnectToServer();
				this.btnConnectToServer.Visible = false;
				this.txtConnectionStatusLabel.Text = "Connected to Server";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
			
		public void lstvClientSubscriptors_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				DPE_ClientIdentificationCredential clientCredentials = default(DPE_ClientIdentificationCredential);
				clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) (this.lstvClientSubscriptors.SelectedItems[0].Tag);
				this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvAllConnectionsPostedPublications);
				this.DisplayOfClientConnectionsToPublications(clientCredentials, this.lsvAllConnectionsConnectionToPublications);
			}
			catch (Exception)
			{
			}
		}
		
		public void tvwClientSubscriptors_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				object selectedObj = null;
				selectedObj = tvwClientSubscriptors.SelectedNode.Tag;
				string type = selectedObj.GetType().ToString();
				if (type == "DPEServerClientApp.DPE_ClientIdentificationCredential")
				{
					DPE_ClientIdentificationCredential clientCredentials = default(DPE_ClientIdentificationCredential);
					clientCredentials = (DPE_ClientIdentificationCredential) selectedObj;
					if (!(_currentSelectedCredentialsOnAllConnectionsByHostTreeView == null))
					{
						if (clientCredentials.ClientID != _currentSelectedCredentialsOnAllConnectionsByHostTreeView.ClientID)
						{
							_currentSelectedCredentialsOnAllConnectionsByHostTreeView = clientCredentials;
							this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvAllConnectionsByHostPublicationsPosted);
							this.DisplayOfClientConnectionsToPublications(clientCredentials, this.lsvAllConnectionsByHostConnectionToPublications);
						}
					}
					else
					{
						_currentSelectedCredentialsOnAllConnectionsByHostTreeView = clientCredentials;
						this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvAllConnectionsByHostPublicationsPosted);
						this.DisplayOfClientConnectionsToPublications(clientCredentials, this.lsvAllConnectionsByHostConnectionToPublications);
					}
				}
				else
				{
					this._currentSelectedCredentialsOnAllConnectionsByHostTreeView = null;
					this.lsvAllConnectionsByHostPublicationsPosted.Items.Clear();
					this.lsvAllConnectionsByHostConnectionToPublications.Items.Clear();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void lsvPublisherClients_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				try
				{
					DPE_ClientIdentificationCredential clientCredentials = default(DPE_ClientIdentificationCredential);
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) (this.lsvPublisherClients.SelectedItems[0].Tag);
					this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Items.Clear();
					this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvPublisherConnectionsAllPublicationsPosted);
				}
				catch (Exception)
				{
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void tvwPublisherClients_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				object selectedObj = null;
				selectedObj = tvwPublisherClients.SelectedNode.Tag;
				string type = selectedObj.GetType().ToString();
				if (type == "DPEServerClientApp.DPE_ClientIdentificationCredential")
				{
					DPE_ClientIdentificationCredential clientCredentials = default(DPE_ClientIdentificationCredential);
					clientCredentials = (DPE_ClientIdentificationCredential) selectedObj;
					if (!(_currentSelectedCredentialsOnPublishersClientByHostTreeView == null))
					{
						if (clientCredentials.ClientID != _currentSelectedCredentialsOnPublishersClientByHostTreeView.ClientID)
						{
							this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Clear();
							_currentSelectedCredentialsOnPublishersClientByHostTreeView = clientCredentials;
							this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvPublisherClientsViewByHostPostedPublications);
						}
					}
					else
					{
						this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Clear();
						_currentSelectedCredentialsOnPublishersClientByHostTreeView = clientCredentials;
						this.DisplayListOfPostedPublicationsByClient(clientCredentials, this.lsvPublisherClientsViewByHostPostedPublications);
					}
				}
				else
				{
					this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Clear();
					this.lsvPublisherClientsViewByHostPostedPublications.Items.Clear();
					this._currentSelectedCredentialsOnPublishersClientByHostTreeView = null;
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void lsvPublisherClientsViewByHostPostedPublications_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				string publicationName = "";
				publicationName = System.Convert.ToString(lsvPublisherClientsViewByHostPostedPublications.SelectedItems[0].Tag);
				this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName, this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList);
			}
			catch (Exception)
			{
			}
		}
		
		public void lsvPublisherConnectionsAllPublicationsPosted_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				string publicationName = "";
				publicationName = System.Convert.ToString(lsvPublisherConnectionsAllPublicationsPosted.SelectedItems[0].Tag);
				this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName, this.lsvPublisherConnectionsAllPublicationsPostedVariablesList);
			}
			catch (Exception)
			{
			}
		}
		
		
		
		
		
		
		public void btnClearLog_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstSTXEventLog.Items.Clear();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstSTXEventLog_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (this.lstSTXEventLog.SelectedIndex >= 0)
				{
					MessageBox.Show(System.Convert.ToString(this.lstSTXEventLog.SelectedItem));
				}
			}
			catch (Exception)
			{
			}
		}
		
		private void tmrDataUpdate_Tick(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				this.tmrDataUpdate.Stop();
				
				UpdateTask task = default(UpdateTask);
				lock(this._serviceStatusUpdateTaskQueue)
				{
					task = (DPEServerClientApp.frmDPEServerClientAppMainForm.UpdateTask) (this._serviceStatusUpdateTaskQueue.Dequeue());
				}
				
				if (!(task == null))
				{
					switch (task.updateMode)
					{
						case UpdateTaskFlag.clientsRegistryStatusUpdate:
							this.UpdateClientsRegistry();
							this.UpdatePublisherClientsRegistry();
							break;
							
						case UpdateTaskFlag.fullStatusUpdate:
							this.UpdateFullServiceStatusTask();
							break;
							
						case UpdateTaskFlag.publicationsRegistryStatusUpdate:
							this.UpdatePublicationsRegistry();
							break;
							
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				if (this._serviceStatusUpdateTaskQueue.Count > 0)
				{
					this.tmrDataUpdate.Start();
				}
			}
		}
		
		public void btnUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.dgrdNetworkStatisticsIPv4.DataSource = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetNetworkingStatiticsTable(System.Net.NetworkInformation.NetworkInterfaceComponent.IPv4);
			}
			catch (Exception)
			{
			}
			try
			{
				this.dgrdNetworkStatisticsIPv6.DataSource = CommunicationsLibrary.Utilities.CommunicationsUtilities.GetNetworkingStatiticsTable(System.Net.NetworkInformation.NetworkInterfaceComponent.IPv6);
			}
			catch (Exception)
			{
			}
		}
		
		
		
		
		
		public void btnZoomPubsVariablesTreeView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublicationTreeViewVariablesList.Items.Count > 0)
				{
					
					string publicationName = null;
					publicationName = GetSelectedPublicationNameFromTreeView();
					if (publicationName == null)
					{
						publicationName = "";
					}
					string caption = "List of variables of publication : \'" + publicationName + "\'";
					frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublicationTreeViewVariablesList);
					frm.ShowDialog();
					frm.Dispose();
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnZoomPubsClientsTreeView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublicationsREsumeTreeviewConnectedClients.Items.Count > 0)
				{
					
					string publicationName = null;
					publicationName = GetSelectedPublicationNameFromTreeView();
					if (publicationName == null)
					{
						publicationName = "";
					}
					string caption = "Connected clients to  publication : \'" + publicationName + "\'";
					frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublicationsREsumeTreeviewConnectedClients);
					frm.ShowDialog();
					frm.Dispose();
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnZoomPubsStatisticsTreeView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				string publicationName = null;
				publicationName = GetSelectedPublicationNameFromTreeView();
				if (publicationName == null)
				{
					publicationName = "";
				}
				string caption = "";
				frmListViewZoomView frm = default(frmListViewZoomView);
				caption = "Statistics of publication : \'" + publicationName + "\'";
				frm = new frmListViewZoomView(caption, this.dgrPublicationDataUpdateStatisticsTreeView);
				frm.ShowDialog();
				try
				{
					frm.Dispose();
				}
				catch (Exception)
				{
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lsvPublicationsREsumeTreeviewConnectedClients_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				ListViewItem item = default(ListViewItem);
				item = this.lsvPublicationsREsumeTreeviewConnectedClients.SelectedItems[0];
				if (!(item == null))
				{
					string publicationName = null;
					publicationName = GetSelectedPublicationNameFromTreeView();
					if (publicationName == null)
					{
						publicationName = "";
					}
					string caption = "";
					caption = "Client connected to publication  : \'" + publicationName + "\'";
					frmListViewItemZoomView frm = new frmListViewItemZoomView(caption, item);
					frm.ShowDialog();
					frm.Dispose();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void lsvPublicationsREsumeConnectedCLientsList_DoubleClick(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAvailablePublications.Items.Count > 0)
				{
					string publicationName = "";
					publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
					if (!(publicationName == null))
					{
						ListViewItem item = default(ListViewItem);
						item = this.lsvPublicationsREsumeConnectedCLientsList.SelectedItems[0];
						string caption = "";
						caption = "Client connected to publication  : \'" + publicationName + "\'";
						frmListViewItemZoomView frm = new frmListViewItemZoomView(caption, item);
						frm.ShowDialog();
						frm.Dispose();
					}
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void lstAvailablePublications_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (lstAvailablePublications.Items.Count > 0)
				{
					ListViewItem item = default(ListViewItem);
					item = this.lstAvailablePublications.SelectedItems[0];
					if (!(item == null))
					{
						string caption = "";
						caption = "Client connected to publication  : \'" + item.Text + "\'";
						frmListViewItemZoomView frm = new frmListViewItemZoomView(caption, item);
						frm.ShowDialog();
						frm.Dispose();
					}
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnAllPublihsersPubliationsListZoomView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublisherConnectionsAllPublicationsPosted.Items.Count > 0)
				{
					
					DPE_ClientIdentificationCredential clientCredentials = default(DPE_ClientIdentificationCredential);
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) (this.lsvPublisherClients.SelectedItems[0].Tag);
					
					if (!(clientCredentials == null))
					{
						
						string caption = "Publications posted by  : \'" + clientCredentials.ClientName + "\'";
						frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublisherConnectionsAllPublicationsPosted);
						frm.ShowDialog();
						frm.Dispose();
					}
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnAllPublishersPublicationVariablesZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				if (this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Items.Count > 0)
				{
					
					string publicationName = "";
					publicationName = System.Convert.ToString(this.lsvPublisherConnectionsAllPublicationsPosted.SelectedItems[0].Tag);
					
					if (!(publicationName == null))
					{
						
						string caption = "Variables included in publication : \'" + publicationName + "\'";
						frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublisherConnectionsAllPublicationsPostedVariablesList);
						frm.ShowDialog();
						frm.Dispose();
					}
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				DPE_ClientIdentificationCredential clientCredentials = null;
				
				try
				{
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) this.tvwPublisherClients.SelectedNode.Tag;
				}
				catch (Exception)
				{
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) this.tvwPublisherClients.SelectedNode.Parent.Tag;
				}
				
				
				if (!(clientCredentials == null))
				{
					string caption = "Publications posted by  : \'" + clientCredentials.ClientName + "\'";
					frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublisherClientsViewByHostPostedPublications);
					frm.ShowDialog();
					frm.Dispose();
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Items.Count > 0)
				{
					string publicationName = "";
					publicationName = System.Convert.ToString(this.lsvPublisherClientsViewByHostPostedPublications.SelectedItems[0].Tag);
					
					if (!(publicationName == null))
					{
						
						string caption = "Variables included in publication : \'" + publicationName + "\'";
						frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList);
						frm.ShowDialog();
						frm.Dispose();
					}
				}
				
			}
			catch (Exception)
			{
			}
		}

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearControls();
                this.UpdateFullServiceStatusTask();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
		
		
		
		
		
#region  < PUBLICATIONS >
		
		public void lstAvailablePublications_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				string publicationName = "";
				publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
				this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName, this.lsvPublicationREsumeTableViewVariablesList);
				this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsListView);
				this.UpdatePublicationconnectedClients(publicationName, this.lsvPublicationsREsumeConnectedCLientsList);
			}
			catch (Exception)
			{
			}
		}
		
		public void btnPublicationsResumtStatisticsReset_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!(this.lstAvailablePublications.SelectedItems[0] == null))
				{
					string publicationName = "";
					publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
					if (Interaction.MsgBox("Reset Statistics for publication " + publicationName + "?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
					{
						this._DPEPublicationsClient.ResetPublicationStatistics(publicationName);
						this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsTreeView);
						this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsListView);
					}
				}
				else
				{
					throw (new Exception("No publication selected from list"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void tvwPublicationsREsumeTreeView_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				if (!(this.tvwPublicationsREsumeTreeView.SelectedNode == null))
				{
					string nodeTagText = "";
					nodeTagText = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
					switch (nodeTagText)
					{
						case HOSTNAME_NODE:
						case PUBLISHER_NODE:
						case PUBLICATIONS_GROUP:
							this._selectedPublicationNameSelectedOnPublicationsTreeView = null;
							this.lsvPublicationTreeViewVariablesList.Items.Clear();
							this.lsvPublicationsREsumeTreeviewConnectedClients.Items.Clear();
							this.dgrPublicationDataUpdateStatisticsListView.DataSource = null;
							this.dgrPublicationDataUpdateStatisticsTreeView.DataSource = null;
							break;
						case PUBLICATION_ELEMENT:
							string publicationName_1 = "";
							publicationName_1 = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Parent.Tag);
							if (!(_selectedPublicationNameSelectedOnPublicationsTreeView == null))
							{
								if (_selectedPublicationNameSelectedOnPublicationsTreeView != publicationName_1)
								{
									this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName_1, this.lsvPublicationTreeViewVariablesList);
									this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName_1, dgrPublicationDataUpdateStatisticsTreeView);
									this.UpdatePublicationconnectedClients(publicationName_1, this.lsvPublicationsREsumeTreeviewConnectedClients);
								}
							}
							else
							{
								if (_selectedPublicationNameSelectedOnPublicationsTreeView != publicationName_1)
								{
									this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName_1, this.lsvPublicationTreeViewVariablesList);
									this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName_1, this.dgrPublicationDataUpdateStatisticsTreeView);
									this.UpdatePublicationconnectedClients(publicationName_1, this.lsvPublicationsREsumeTreeviewConnectedClients);
								}
							}
							break;
						default:
							string publicationName = "";
							publicationName = nodeTagText;
							if (!(_selectedPublicationNameSelectedOnPublicationsTreeView == null))
							{
								if (_selectedPublicationNameSelectedOnPublicationsTreeView != publicationName)
								{
									this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName, this.lsvPublicationTreeViewVariablesList);
									this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsTreeView);
									this.UpdatePublicationconnectedClients(publicationName, this.lsvPublicationsREsumeTreeviewConnectedClients);
								}
							}
							else
							{
								if (_selectedPublicationNameSelectedOnPublicationsTreeView != publicationName)
								{
									this.UpdateAndDisplayListOfVariablesAttachedToPublication(publicationName, this.lsvPublicationTreeViewVariablesList);
									this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsTreeView);
									this.UpdatePublicationconnectedClients(publicationName, this.lsvPublicationsREsumeTreeviewConnectedClients);
								}
							}
							break;
					}
					
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnPublicationsResumtStatisticsUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!(this.lstAvailablePublications.SelectedItems[0] == null))
				{
					string publicationName = "";
					publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
					this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsListView);
				}
				else
				{
					throw (new Exception("No publication selected from list"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnPublicationsResumTreeViewStatisticsUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!(this.tvwPublicationsREsumeTreeView.SelectedNode == null))
				{
					string nodeTagText = "";
					nodeTagText = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
					switch (nodeTagText)
					{
						case HOSTNAME_NODE:
						case PUBLISHER_NODE:
						case PUBLICATION_ELEMENT:
							break;
						default:
							string publicationName = "";
							publicationName = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
							this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsTreeView);
							this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsListView);
							break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnPublicationsResumTreeViewStatisticsReset_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!(this.tvwPublicationsREsumeTreeView.SelectedNode == null))
				{
					string nodeTagText = "";
					nodeTagText = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
					switch (nodeTagText)
					{
						case HOSTNAME_NODE:
						case PUBLISHER_NODE:
						case PUBLICATION_ELEMENT:
							break;
						default:
							string publicationName = "";
							publicationName = System.Convert.ToString(this.tvwPublicationsREsumeTreeView.SelectedNode.Tag);
							if (Interaction.MsgBox("Reset Statistics for publication " + publicationName + "?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
							{
								this._DPEPublicationsClient.ResetPublicationStatistics(publicationName);
								this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsTreeView);
								this.UpdateAndDisplayPublicationDataUpdateStatistics(publicationName, this.dgrPublicationDataUpdateStatisticsListView);
							}
							break;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
		
		public void btnZoomPubsStatisticsListView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string publicationName = null;
				if (this.lstAvailablePublications.Items.Count > 0)
				{
					publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
				}
				if (publicationName == null)
				{
					publicationName = "";
				}
				string caption = "";
				frmListViewZoomView frm = default(frmListViewZoomView);
				
				caption = "Statistics of publication : \'" + publicationName + "\'";
				frm = new frmListViewZoomView(caption, this.dgrPublicationDataUpdateStatisticsListView);
				frm.ShowDialog();
				
				try
				{
					frm.Dispose();
				}
				catch (Exception)
				{
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		public void btnZoomPubsClientsListView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublicationsREsumeConnectedCLientsList.Items.Count > 0)
				{
					
					string publicationName = null;
					if (this.lstAvailablePublications.Items.Count > 0)
					{
						publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
					}
					if (publicationName == null)
					{
						publicationName = "";
					}
					string caption = "Connected clients to  publication : \'" + publicationName + "\'";
					frmListViewZoomView frm = default(frmListViewZoomView);
					frm = new frmListViewZoomView(caption, this.lsvPublicationsREsumeConnectedCLientsList);
					frm.ShowDialog();
					frm.Dispose();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void btnZoomPubsVariablesListView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvPublicationREsumeTableViewVariablesList.Items.Count > 0)
				{
					
					string publicationName = null;
					if (this.lstAvailablePublications.Items.Count > 0)
					{
						publicationName = System.Convert.ToString(this.lstAvailablePublications.SelectedItems[0].Tag);
					}
					if (publicationName == null)
					{
						publicationName = "";
					}
					string caption = "List of variables of publication : \'" + publicationName + "\'";
					frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvPublicationREsumeTableViewVariablesList);
					frm.ShowDialog();
					frm.Dispose();
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnZoomAvailablePublications_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAvailablePublications.Items.Count > 0)
				{
					frmListViewZoomView frm = default(frmListViewZoomView);
					frm = new frmListViewZoomView("Available Publications on Server", this.lstAvailablePublications);
					frm.ShowDialog();
					frm.Dispose();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void btnPublicationsTreeViewZoomView_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.tvwPublicationsREsumeTreeView.Nodes.Count > 0)
				{
					frmTreeViewZoomView frm = new frmTreeViewZoomView("Available Publications on Server", this.tvwPublicationsREsumeTreeView);
					frm.ShowDialog();
					frm.Dispose();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void btnAvaibalePublicationsTreeViewTreeExpand_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwPublicationsREsumeTreeView.ExpandAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnAvaibalePublicationsTreeViewTreeCollapse_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwPublicationsREsumeTreeView.CollapseAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnAvaibalePublicationsTreeViewTreeNodeCollapse_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdatePublicationsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		
		public void Button8_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.AdjustListViewTableViewColSize(this.lstAvailablePublications);
			}
			catch (Exception)
			{
			}
		}
		
		public void Button7_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdatePublicationsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
#endregion
		
		
		
#region  < CLIENT CONNECTIONS  VIEW >
		
		public void btnZoomAllClientsTableViewPostedPubsList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvAllConnectionsPostedPublications.Items.Count > 0)
				{
					
					DPE_ClientIdentificationCredential clientCredentials = null;
					
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) (this.lstvClientSubscriptors.SelectedItems[0].Tag);
					if (!(clientCredentials == null))
					{
						
						string caption = "Posted publications by Client  :  \'" + clientCredentials.ClientName + "\'";
						frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvAllConnectionsPostedPublications);
						frm.ShowDialog();
						frm.Dispose();
					}
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnZoomAllClientsTableViewPubsConnectionsList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lsvAllConnectionsConnectionToPublications.Items.Count > 0)
				{
					
					DPE_ClientIdentificationCredential clientCredentials = null;
					
					clientCredentials = (DPEServerClientApp.DPE_ClientIdentificationCredential) (this.lstvClientSubscriptors.SelectedItems[0].Tag);
					
					if (!(clientCredentials == null))
					{
						
						string caption = "List of connection ti publications of client  :  \'" + clientCredentials.ClientName + "\'";
						frmListViewZoomView frm = new frmListViewZoomView(caption, this.lsvAllConnectionsConnectionToPublications);
						frm.ShowDialog();
						frm.Dispose();
						
					}
					
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientsCnnListViewZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstvClientSubscriptors.Items.Count > 0)
				{
					
					frmListViewZoomView frm = new frmListViewZoomView("Clients Connected to Publications Server", this.lstvClientSubscriptors);
					frm.ShowDialog();
					frm.Dispose();
					
				}
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnClientConnsTreeViewZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.tvwClientSubscriptors.Nodes.Count > 0)
				{
					frmTreeViewZoomView frm = new frmTreeViewZoomView("Clients Connected to Publications Server", this.tvwClientSubscriptors);
					frm.ShowDialog();
					frm.Dispose();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClientConnsTreeViewExpandAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwClientSubscriptors.ExpandAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientConnsTreeViewCollapseAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwClientSubscriptors.CollapseAll();
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnClientConnsTreeViewCollapseNode_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdateClientsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		public void btnClientCnnsTreeViewPostedPubsZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmListViewZoomView frm = new frmListViewZoomView("Posted Publications by Selected Client", this.lsvAllConnectionsByHostPublicationsPosted);
				frm.ShowDialog();
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClienCnnsTreeViewPubcConnsZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmListViewZoomView frm = new frmListViewZoomView("Connections to Publications by Selected Client", this.lsvAllConnectionsByHostConnectionToPublications);
				frm.ShowDialog();
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClientCnnsListViewAdjustCols_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.AdjustListViewTableViewColSize(this.lstvClientSubscriptors);
			}
			catch (Exception)
			{
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmListViewZoomView frm = default(frmListViewZoomView);
				frm = new frmListViewZoomView("Publisher Clients Connections on Server", this.lsvPublisherClients);
				frm.ShowDialog();
				frm.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdateClientsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		public void btnClientCnnsPublishersTreeViewZoom_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmTreeViewZoomView frm = new frmTreeViewZoomView("Publisher Clients Connections", this.tvwPublisherClients);
				frm.ShowDialog();
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClientCnnsPublishersTreeViewExpandAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwPublisherClients.ExpandAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientCnnsPublishersTreeViewCollapseAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.tvwPublisherClients.CollapseAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientCnnsPublishersTreeViewNodeCollapse_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdatePublisherClientsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		public void Button6_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.AdjustListViewTableViewColSize(this.lsvPublisherClients);
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button5_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.UpdatePublisherClientsRegistry();
			}
			catch (Exception)
			{
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
#endregion

    

      
		
#endregion
		
		
		
	}
	
	
}
