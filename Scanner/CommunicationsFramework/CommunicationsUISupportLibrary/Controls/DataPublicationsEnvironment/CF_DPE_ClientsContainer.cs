using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using UtilitiesLibrary.Services.Serialization;
using System.Windows.Forms;



namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_ClientsContainer
	{
		public CF_DPE_ClientsContainer()
		{
			InitializeComponent();
		}
		
#region  < DATA MEMBERES >
		
		private ClientHandlersDataContainer _ClientHandlersDataContainer;
		
#endregion
		
		
		
		public void btnCreateClient_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				
				frm_DPE_ClientHandlerCreation frm = new frm_DPE_ClientHandlerCreation();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					CF_DPE_ClientHandler clientHandler = new CF_DPE_ClientHandler(frm.NewClientHandlerName, frm.KeepDataStatisticsTracking);
					
					
					System.Windows.Forms.TabPage clientTab = new System.Windows.Forms.TabPage(clientHandler.STXDSS_Client.ClientName);
					clientHandler.Size = new System.Drawing.Size(clientTab.Size.Width, clientTab.Size.Height);
					
					clientTab.Controls.Add(clientHandler);
					
					this.TabClients.TabPages.Add(clientTab);
					this.lstBoxClients.Items.Add(clientHandler.STXDSS_Client);
					
					this._ClientHandlersDataContainer.AddClientHandlerData(clientHandler.ClientHandlerData);
					
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		
		public void lstBoxClients_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.TabClients.SelectedIndex = this.lstBoxClients.SelectedIndex;
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnDisposeClient_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstBoxClients.Items.Count <= 0)
				{
					throw (new Exception("No clients available to dispose"));
				}
				
				if (this.lstBoxClients.SelectedIndex < 0)
				{
					throw (new Exception("No client selected from list"));
				}
				
				int clientTabIndex = this.lstBoxClients.SelectedIndex;
				
				DPE_DataPublicationsClient client = (DPE_DataPublicationsClient) this.lstBoxClients.SelectedItem;
				if (Interaction.MsgBox("Dispose the client \'" + client.ClientName + "\'", (Microsoft.VisualBasic.MsgBoxStyle) 0, null) == MsgBoxResult.Ok)
				{
					client.DisconnectFromServer();
					client.Dispose();
					this.lstBoxClients.Items.Remove(client);
					this.TabClients.TabPages[clientTabIndex].Dispose();
				}
				
				this._ClientHandlersDataContainer.RemoveClientHandlerData(client.ClientName);
				this._ClientHandlersDataContainer.SaveData();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		public void CFSTXDSS_ClientsContainer_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._ClientHandlersDataContainer = ClientHandlersDataContainer.GetInstance();
				
				if (this._ClientHandlersDataContainer.Count > 0)
				{
					//starts to create the handler for each one
					IEnumerator enumm = this._ClientHandlersDataContainer.GetEnumerator();
					ClientHandlerData hnd = default(ClientHandlerData);
					
					while (enumm.MoveNext())
					{
						hnd = (ClientHandlerData)enumm.Current;
						
						CF_DPE_ClientHandler clientHandler = new CF_DPE_ClientHandler(hnd);
						System.Windows.Forms.TabPage clientTab = new System.Windows.Forms.TabPage(clientHandler.STXDSS_Client.ClientName);
						clientTab.Controls.Add(clientHandler);
						clientHandler.Dock = System.Windows.Forms.DockStyle.Fill;
						this.TabClients.TabPages.Add(clientTab);
						this.lstBoxClients.Items.Add(clientHandler.STXDSS_Client);
						
					}
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnHideShowClientsList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!this.spCtnrMainContainer.Panel1Collapsed)
				{
					this.spCtnrMainContainer.Panel1Collapsed = true;
					this.btnHideShowClientsList.Text = ">>  Show List";
				}
				else
				{
					this.spCtnrMainContainer.Panel1Collapsed = false;
					this.btnHideShowClientsList.Text = "<<  Hide List";
				}
			}
			catch (Exception)
			{
				
			}
		}
	}
	
}
