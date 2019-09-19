using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.DataStatistics;
using UtilitiesLibrary.Services.Serialization;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using System.Windows.Forms;




namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_ClientHandler
	{
		
#region  < DATAMEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private ClientHandlerData _ClientHandlerData;
		private CF_DPE_PublicationsPostHandlersContainer _PublicationsHandlersContainer;
		private CF_DPE_PublicationsSubscriptionsHandlersContainer _PublicationsConnectionsHandlersContainer;
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public CF_DPE_ClientHandler(string clientName, bool DataStatisticsHandling)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Add any initialization after the InitializeComponent() call.
			clientName = clientName.ToUpper();
			this._client = new DPE_DataPublicationsClient(clientName);
			this._client.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
			if (!this._client.IsConnected)
			{
				this._client.ConnectToServer();
			}
			
			this._ClientHandlerData = new ClientHandlerData(clientName, DataStatisticsHandling);
			
			this.lblSErverConnectionStatus.Text = "Status: Connected To Server";
			this._PublicationsHandlersContainer = new CF_DPE_PublicationsPostHandlersContainer(this._client, this._ClientHandlerData);
			this._PublicationsConnectionsHandlersContainer = new CF_DPE_PublicationsSubscriptionsHandlersContainer(this._client, this._ClientHandlerData);
			
		}
		
		public CF_DPE_ClientHandler(ClientHandlerData data)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Add any initialization after the InitializeComponent() call.
			this._client = new DPE_DataPublicationsClient(data.ClientName);
			this._client.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
			if (!this._client.IsConnected)
			{
				this._client.ConnectToServer();
			}
			
			this._ClientHandlerData = data;
			this.lblSErverConnectionStatus.Text = "Status: Connected To Server";
			this._PublicationsHandlersContainer = new CF_DPE_PublicationsPostHandlersContainer(this._client, this._ClientHandlerData);
			this._PublicationsConnectionsHandlersContainer = new CF_DPE_PublicationsSubscriptionsHandlersContainer(this._client, this._ClientHandlerData);
			
			
			//creates all the publications configured for the client
			IEnumerator enumm = data.PublicationsPostEnumerator;
			publicationsPosting.PostedPublicationDefinitionData pubPostData = null;
			
			while (enumm.MoveNext())
			{
                pubPostData = (publicationsPosting.PostedPublicationDefinitionData)enumm.Current;
				DPE_ClientPublicationDefinition publication = new DPE_ClientPublicationDefinition(pubPostData.PublicationName);
				
				IEnumerator enumm2 = pubPostData.VariablesDefinitionContainer.GetEnumerator();
				publicationsPosting.PublicationVariableDefinitionData varDAta = null;
				while (enumm2.MoveNext())
				{
                    varDAta = (publicationsPosting.PublicationVariableDefinitionData)enumm2.Current;
					publication.AddVaribleToPublication(varDAta.VariableName, varDAta.DataType);
				}
				
				this._client.CreateDataPublication(publication);
				
				this._PublicationsHandlersContainer.AddPublicationHandler(publication.PublicationName);
				
			}
			
			//creates all the connections with publications configured for the client
			IEnumerator pubCnnEnumm = data.PublicationsConnectionsEnumerator;
			publicationsConnection.PublicationConnectionData cnndta = default(publicationsConnection.PublicationConnectionData);
			
			while (pubCnnEnumm.MoveNext())
			{
				cnndta = (publicationsConnection.PublicationConnectionData)pubCnnEnumm.Current;
				this._client.ConnectToADataPublication(cnndta.PublicationName, cnndta.ConnectionMode);
				this._PublicationsConnectionsHandlersContainer.AddPublicationConnectionHandler(cnndta.PublicationName);				
			}			
		}
		
		public CF_DPE_ClientHandler()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			// Add any initialization after the InitializeComponent() call.
			this._client = new DPE_DataPublicationsClient();
			this._client.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
			this._client.ConnectToServer();
			this.lblSErverConnectionStatus.Text = "Status: Connected To Server";
			
			this._PublicationsHandlersContainer = new CF_DPE_PublicationsPostHandlersContainer(this._client, this._ClientHandlerData);
			
		}
		
#endregion
		
#region  < PROPERTIES >
		
public DPE_DataPublicationsClient STXDSS_Client
		{
			get
			{
				return this._client;
			}
		}
		
public ClientHandlerData ClientHandlerData
		{
			get
			{
				return this._ClientHandlerData;
			}
		}
		
#endregion
		
#region  < SAFE UI ACCESS >
		
		delegate void SetDataGrid_DataSourceCallBackDelegate(System.Windows.Forms.DataGridView datagridview, DataTable item);
		delegate void SetListBox_ItemCallBackDelegate(System.Windows.Forms.ListBox listBox, object item);
		delegate void ClearListBox_CallBackDelegate(System.Windows.Forms.ListBox listBox);
		delegate void Set_TextBox_Text_CallBack_Delegate(System.Windows.Forms.TextBox textBox, string text);
		delegate void Set_Label_Text_CallBack_Delegate(System.Windows.Forms.Label label, string text);
		
		
		private void SetDataGrid_DataSource(System.Windows.Forms.DataGridView datagridview, DataTable item)
		{
			if (datagridview.InvokeRequired)
			{
				SetDataGrid_DataSourceCallBackDelegate d = new SetDataGrid_DataSourceCallBackDelegate(SetDataGrid_DataSource);
				this.Invoke(d, new object[] {datagridview, item});
			}
			else
			{
				datagridview.DataSource = item;
			}
		}
		
		private void SetListBox_Item(System.Windows.Forms.ListBox listBox, object item)
		{
			if (listBox.InvokeRequired)
			{
				SetListBox_ItemCallBackDelegate d = new SetListBox_ItemCallBackDelegate(SetListBox_Item);
				this.Invoke(d, new object[] {listBox, item});
			}
			else
			{
				listBox.Items.Add(item);
			}
		}
		
		private void ClearListBox(System.Windows.Forms.ListBox listBox)
		{
			if (listBox.InvokeRequired)
			{
				ClearListBox_CallBackDelegate d = new ClearListBox_CallBackDelegate(ClearListBox);
				this.Invoke(d, new object[] {listBox});
			}
			else
			{
				listBox.Items.Clear();
			}
		}

        delegate bool Get_Check_Status_CallBack_Delegate(System.Windows.Forms.CheckBox checkBox);
		private bool Get_Check_Status(System.Windows.Forms.CheckBox checkBox)
		{
			if (checkBox.InvokeRequired)
			{
				Get_Check_Status_CallBack_Delegate d = new Get_Check_Status_CallBack_Delegate(Get_Check_Status);
				this.Invoke(d, new object[] {checkBox});
                return checkBox.Checked;
			}
			else
			{
				return checkBox.Checked;
			}
		}
		
		private void Set_TextBox_Text(System.Windows.Forms.TextBox textBox, string text)
		{
			if (textBox.InvokeRequired)
			{
				Set_TextBox_Text_CallBack_Delegate d = new Set_TextBox_Text_CallBack_Delegate(Set_TextBox_Text);
				this.Invoke(d, new object[] {textBox, text});
			}
			else
			{
				textBox.Text = text;
			}
		}
		
		private void Set_Label_Text(System.Windows.Forms.Label label, string text)
		{
			if (label.InvokeRequired)
			{
				Set_Label_Text_CallBack_Delegate d = new Set_Label_Text_CallBack_Delegate(Set_Label_Text);
				this.Invoke(d, new object[] {label, text});
			}
			else
			{
				label.Text = text;
			}
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void ConnectionWithServerLost()
		{
			this.Set_Label_Text(this.lblSErverConnectionStatus, "Status: Connection With Server Lost");
		}
		
		
#endregion
		
#region  < PRIVATE METHODS >
		
		
		
		private string GetSelectedPublicationName()
		{
			if (this.lstAvailablePubications.SelectedIndex >= 0)
			{
				return System.Convert.ToString(this.lstAvailablePubications.SelectedItem);
			}
			else
			{
				return null;
			}
		}
		
		private void LoadAvailablePublicationsOnList(DataTable table)
		{
			try
			{
				this.ClearListBox(this.lstAvailablePubications);
				DataRow row = default(DataRow);
				IEnumerator rowenumm = table.Rows.GetEnumerator();
				string pubName = "";
				while (rowenumm.MoveNext())
				{
					row = (DataRow)rowenumm.Current;
					pubName = System.Convert.ToString(row[0]);
					SetListBox_Item(this.lstAvailablePubications, pubName);
				}
			}
			catch (Exception ex)
			{
				this.lstErrorLog.Items.Add(ex.Message);
			}
		}
		
		
		
		private void UpdateAvailablePublications()
		{
			this.lstAvailablePubications.Items.Clear();
			DataTable dt = this._client.GetPublicationsRegistryTable();
			string pubName = "";
			IEnumerator enumm = dt.Rows.GetEnumerator();
			DataRow row = default(DataRow);
			while (enumm.MoveNext())
			{
				row = (DataRow)enumm.Current;
				pubName = System.Convert.ToString(row[1]);
				this.lstAvailablePubications.Items.Add(pubName);
			}
		}
		
		private void UpdateClientSubscriptions()
		{
			this.lstSubscribedPublications.Items.Clear();
			CustomList list = default(CustomList);
			list = this._client.GetListOfSubscriptionsToPublications();
			IEnumerator enumm = list.GetEnumerator();
			string pubName = "";
			while (enumm.MoveNext())
			{
				pubName = System.Convert.ToString(enumm.Current);
				this.lstSubscribedPublications.Items.Add(pubName);
			}
		}
		
		private void UpdateClientPostedPublications()
		{
			try
			{
				this.lstPostedPublications.Items.Clear();
				CustomList list = default(CustomList);
				list = this._client.GetListOfPublicationsPosted();
				IEnumerator enumm = list.GetEnumerator();
				string pubName = "";
				while (enumm.MoveNext())
				{
					pubName = System.Convert.ToString(enumm.Current);
					this.lstPostedPublications.Items.Add(pubName);
				}
			}
			catch (Exception)
			{
			}
		}
		
		private void adjustGrid(C1.Win.C1FlexGrid.C1FlexGrid grid)
		{
			try
			{
				int colWidth = (int) (((double) grid.Width / grid.Cols.Count) - 5);
				
				int index = 0;
				index = 0;
				for (index = 0; index <= grid.Cols.Count; index++)
				{
					grid.Cols[index].Width = colWidth;
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		private void LoadListOfPublicationPublishedVariables(string PublicationName, System.Windows.Forms.ListBox listBoxCtrl)
		{
			ClearListBox(listBoxCtrl);
			DataTable dt = this._client.GetListOfVariablesPublishedOnAPublication(PublicationName);
			
			DataRow row = default(DataRow);
			string varName = "";
			string varDataType = "";
			
			IEnumerator enumm = dt.Rows.GetEnumerator();
			while (enumm.MoveNext())
			{
				row = (DataRow)enumm.Current;
				varName = System.Convert.ToString(row[0]);
				varDataType = System.Convert.ToString(row[1]);
				string str = varName + " , " + varDataType;
				SetListBox_Item(listBoxCtrl, str);
			}
			
		}
		
		
		
#endregion
		
#region  < PUBLIC METHODS >
		
		
		public void DisposeHandler()
		{
			try
			{
				if (this._client.IsConnected)
				{
					this._client.DisconnectFromServer();
				}
			}
			catch (Exception)
			{
			}
		}
		
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void STXDSS_ClientHandler_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Dock = System.Windows.Forms.DockStyle.Fill;
				this.txtClientName.Text = this._client.ClientName;
				
				this._PublicationsHandlersContainer.Dock = System.Windows.Forms.DockStyle.Fill;
				this.spltrPublicationsContainer.Panel2.Controls.Add(this._PublicationsHandlersContainer);
				
				this._PublicationsConnectionsHandlersContainer.Dock = System.Windows.Forms.DockStyle.Fill;
				this.spltrPublicationsSubscriptionsContainer.Panel2.Controls.Add(this._PublicationsConnectionsHandlersContainer);
				this.UpdateClientSubscriptions();
				
			}
			catch (Exception ex)
			{
				this.lstErrorLog.Items.Add(ex.Message);
			}
		}
		
		public void btnCreatePublication_Click(System.Object sender, System.EventArgs e)
		{
			frm_DPE_PublicationCreation frm = null;
			try
			{
				frm = new frm_DPE_PublicationCreation(this._client);
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._PublicationsHandlersContainer.AddPublicationHandler(frm.PublicationPostingData.PublicationName);
					this.UpdateClientPostedPublications();
				}
				//data serialization
				this._ClientHandlerData.AddPublicationPostDefinition(frm.PublicationPostingData);
				
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				try
				{
					frm.Dispose();
				}
				catch (Exception)
				{
				}
			}
		}
		
		public void btnDeletePublication_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstPostedPublications.Items.Count <= 0)
				{
					throw (new Exception("No publications available"));
				}
				
				if (this.lstPostedPublications.SelectedIndex < 0)
				{
					MessageBox.Show("No Publication selected");
				}
				
				string publicationName = "";
				publicationName = System.Convert.ToString(this.lstPostedPublications.SelectedItem);
				this._client.DisposeDataPublication(publicationName);
				this.UpdateClientPostedPublications();
				
				//save data
				publicationsPosting.PostedPublicationDefinitionData data = this._ClientHandlerData.GetPublicationPostDefinition(publicationName);
				this._ClientHandlerData.RemovePublicationPostDefinition(data);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
		
		
		public void btnRemoveFromPublication_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstSubscribedPublications.Items.Count <= 0)
				{
					throw (new Exception("No subscriptions available te deattach from."));
				}
				
				if (this.lstSubscribedPublications.SelectedIndex < 0)
				{
					throw (new Exception("No publication selected from list"));
				}
				
				string publicationName = "";
				publicationName = System.Convert.ToString(this.lstSubscribedPublications.SelectedItem);
				this._client.DisconnectFromDataPublication(publicationName);
				this.UpdateClientSubscriptions();
				
				//serialization of data
				publicationsConnection.PublicationConnectionData data = this._ClientHandlerData.GetPublicationConnectionData(publicationName);
				this._ClientHandlerData.RemovePublicationConnectionData(data);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnConnectToPublication_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string pubName = this.GetSelectedPublicationName();
				if (pubName == null)
				{
					throw (new Exception("No selected publication from list"));
				}
				CF_DPE_ConnectionMode frm = new CF_DPE_ConnectionMode();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._client.ConnectToADataPublication(pubName, frm.ConnectionMode);
					this._PublicationsConnectionsHandlersContainer.AddPublicationConnectionHandler(pubName);
					
					//serialization of data
					publicationsConnection.PublicationConnectionData publicationCnnData = new publicationsConnection.PublicationConnectionData(pubName, frm.ConnectionMode);
					this._ClientHandlerData.AddPublicationConnectionData(publicationCnnData);
					
					
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClearErorLog_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstErrorLog.Items.Clear();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void lstAvailablePubications_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAvailablePubications.SelectedIndex >= 0)
				{
					string publicationNAme = "";
					publicationNAme = this.GetSelectedPublicationName();
					if (!(publicationNAme == null))
					{
						this.LoadListOfPublicationPublishedVariables(publicationNAme, this.lstListOfPublicationPublishedVariables);
					}
				}
				else
				{
					this.lstListOfPublicationPublishedVariables.Items.Clear();
				}
			}
			catch (Exception ex)
			{
				this.lstErrorLog.Items.Add(ex.Message);
			}
		}
		
		
		public void btnUpdatePostedPublications_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.UpdateClientPostedPublications();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.UpdateAvailablePublications();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnUpdateConnections_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.UpdateClientSubscriptions();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstPostedPublications_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstPostedPublications.Items.Count > 0)
				{
					if (this.lstPostedPublications.SelectedIndex >= 0)
					{
						string pubName = System.Convert.ToString(this.lstPostedPublications.SelectedItem);
						this._PublicationsHandlersContainer.SetPublicationTab(pubName);
					}
					else
					{
						this._PublicationsHandlersContainer.SetPublicationTab();
					}
				}
				else
				{
					this._PublicationsHandlersContainer.SetPublicationTab();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
		
		public void btnCreateRandomPublication_Click(System.Object sender, System.EventArgs e)
		{
			frm_DPE_RandomPublicationCreation frm = null;
			try
			{
				frm = new frm_DPE_RandomPublicationCreation(this._client);
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._PublicationsHandlersContainer.AddPublicationHandler(frm.PublicationPostingData.PublicationName);
					this.UpdateClientPostedPublications();
				}
				//data serialization
				this._ClientHandlerData.AddPublicationPostDefinition(frm.PublicationPostingData);
				
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				try
				{
					frm.Dispose();
				}
				catch (Exception)
				{
				}
			}
		}
		
		
		public void btnConnectToAllPublications_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAvailablePubications.Items.Count <= 0)
				{
					throw (new Exception("No publications available to connect to"));
				}
				CF_DPE_ConnectionMode frm = new CF_DPE_ConnectionMode();
				
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					IEnumerator enumm = this.lstAvailablePubications.Items.GetEnumerator();
					string pubName = "";
					
					while (enumm.MoveNext())
					{
						pubName = System.Convert.ToString(enumm.Current);
						
						this._client.ConnectToADataPublication(pubName, frm.ConnectionMode);
						this._PublicationsConnectionsHandlersContainer.AddPublicationConnectionHandler(pubName);
						
						//serialization of data
						publicationsConnection.PublicationConnectionData publicationCnnData = new publicationsConnection.PublicationConnectionData(pubName, frm.ConnectionMode);
						
						this._ClientHandlerData.AddPublicationConnectionData(publicationCnnData);
						
					}
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnDisconnectFromAllPublications_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstSubscribedPublications.Items.Count <= 0)
				{
					throw (new Exception("No subscriptions available te deattach from."));
				}
				
				
				IEnumerator enumm = this.lstSubscribedPublications.Items.GetEnumerator();
				string publicationName = "";
				
				while (enumm.MoveNext())
				{
					publicationName = System.Convert.ToString(enumm.Current);
					this._client.DisconnectFromDataPublication(publicationName);
					//serialization of data
					publicationsConnection.PublicationConnectionData data = this._ClientHandlerData.GetPublicationConnectionData(publicationName);
					this._ClientHandlerData.RemovePublicationConnectionData(data);
					
				}
				
				this.UpdateClientSubscriptions();
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstSubscribedPublications_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstSubscribedPublications.Items.Count > 0)
				{
					if (this.lstSubscribedPublications.SelectedIndex >= 0)
					{
						string pubName = System.Convert.ToString(this.lstSubscribedPublications.SelectedItem);
						this._PublicationsConnectionsHandlersContainer.SetPublicationTab(pubName);
					}
					else
					{
						this._PublicationsConnectionsHandlersContainer.SetPublicationTab();
					}
				}
				else
				{
					this._PublicationsConnectionsHandlersContainer.SetPublicationTab();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnHideShowPublicationsSubscriptionList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!this.spltrCurrentPublicationsSubscrioption.Panel1Collapsed)
				{
					this.spltrCurrentPublicationsSubscrioption.Panel1Collapsed = true;
					this.btnHideShowPublicationsSubscriptionList.Text = ">>  Show List";
				}
				else
				{
					this.spltrCurrentPublicationsSubscrioption.Panel1Collapsed = false;
					this.btnHideShowPublicationsSubscriptionList.Text = ">>  Hide List";
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnHideShowPublicationsPostList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!this.spltrPublicationsPostMainSpliterCtrl.Panel1Collapsed)
				{
					this.spltrPublicationsPostMainSpliterCtrl.Panel1Collapsed = true;
					this.btnHideShowPublicationsPostList.Text = ">>  Show List";
				}
				else
				{
					this.spltrPublicationsPostMainSpliterCtrl.Panel1Collapsed = false;
					this.btnHideShowPublicationsPostList.Text = "<<  Hide List";
				}
			}
			catch (Exception)
			{
				
			}
		}
		
#endregion
		
		
		
		
	}
	
}
