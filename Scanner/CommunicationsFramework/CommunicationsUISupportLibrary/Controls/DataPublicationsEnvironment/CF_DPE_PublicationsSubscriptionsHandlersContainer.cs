using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_PublicationsSubscriptionsHandlersContainer
	{
		
		
#region  < DATAMEMBERS >
		
		private Hashtable _handlerContainersTable;
		private Hashtable _handlersTabPagesTable;
		private DPE_DataPublicationsClient _client;
		private ClientHandlerData _ClientHandlerData;
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public CF_DPE_PublicationsSubscriptionsHandlersContainer(DPE_DataPublicationsClient client, ClientHandlerData ClientHandlerData)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._ClientHandlerData = ClientHandlerData;
			this._handlersTabPagesTable = new Hashtable();
			this._handlerContainersTable = new Hashtable();
			this._client = client;
			if (!this._client.IsConnected)
			{
				this._client.ConnectToServer();
			}
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void AddPublicationConnectionHandler(string publicationNAme)
		{
			
			if (!this._handlerContainersTable.ContainsKey(publicationNAme))
			{
				
				System.Windows.Forms.TabPage TabPage = new System.Windows.Forms.TabPage(publicationNAme);
				
				CF_DPE_PublicationSubscriptionHandler handler = new CF_DPE_PublicationSubscriptionHandler(this._client, publicationNAme);
				handler.Dock = System.Windows.Forms.DockStyle.Fill;
				TabPage.Controls.Add(handler);
				TabPage_Add(this.tabPublicationHandlers, TabPage);
				
				this._handlerContainersTable.Add(publicationNAme, handler);
				this._handlersTabPagesTable.Add(publicationNAme, TabPage);
				
				try
				{
					handler.UpdateStatistics();
					this.SetPublicationTab(publicationNAme);
				}
				catch (Exception)
				{
				}
				
			}
		}
		
		public void RemovePublicationConnectionHandler(string publicationNAme)
		{
			
			
			if (this._handlerContainersTable.ContainsKey(publicationNAme))
			{
				
				CF_DPE_PublicationSubscriptionHandler handler = default(CF_DPE_PublicationSubscriptionHandler);
				handler = (CF_DPE_PublicationSubscriptionHandler)this._handlerContainersTable[publicationNAme];
				try
				{
					handler.Dispose();
				}
				catch (Exception)
				{
				}
				try
				{
					this._handlerContainersTable.Remove(publicationNAme);
				}
				catch (Exception)
				{
				}
				
			}
			
			if (this._handlersTabPagesTable.ContainsKey(publicationNAme))
			{
                System.Windows.Forms.TabPage tab = (System.Windows.Forms.TabPage)this._handlersTabPagesTable[publicationNAme];
				this.tabPublicationHandlers.TabPages.Remove(tab);
				try
				{
					tab.Dispose();
				}
				catch (Exception)
				{
				}
			}
			
			
		}
		
		public void SetPublicationTab(string PublicationName)
		{
			if (this._handlersTabPagesTable.ContainsKey(PublicationName))
			{
				this.Visible = true;
				System.Windows.Forms.TabPage tabPage = default(System.Windows.Forms.TabPage);
                tabPage = (System.Windows.Forms.TabPage)this._handlersTabPagesTable[PublicationName];
				this.tabPublicationHandlers.SelectedTab = tabPage;
			}
		}
		
		public void SetPublicationTab()
		{
			this.Visible = false;
		}
		
		
		
#endregion
		
#region  < SAFE UI ACCESS >

        delegate void TabPage_Controls_Add_CallBack(System.Windows.Forms.TabControl TabPageCtrl, System.Windows.Forms.TabPage control);
        public void TabPage_Add(System.Windows.Forms.TabControl TabPageCtrl, System.Windows.Forms.TabPage control)
		{
			try
			{
				if (TabPageCtrl.InvokeRequired)
				{
					TabPage_Controls_Add_CallBack d = new TabPage_Controls_Add_CallBack(TabPage_Add);
					TabPageCtrl.Invoke(d, new object[] {TabPageCtrl, control});
				}
				else
				{
					TabPageCtrl.TabPages.Add(control);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		
#endregion
		
#region  < UI CALLBACKS  >
		
		public void btnUpdateStatistics_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				IEnumerator enumm = this._handlerContainersTable.GetEnumerator();
				CF_DPE_PublicationSubscriptionHandler hnd = null;
				while (enumm.MoveNext())
				{
					hnd = (CF_DPE_PublicationSubscriptionHandler) (((DictionaryEntry) enumm.Current).Value);
					hnd.UpdateStatistics();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion
		
	}
	
}
