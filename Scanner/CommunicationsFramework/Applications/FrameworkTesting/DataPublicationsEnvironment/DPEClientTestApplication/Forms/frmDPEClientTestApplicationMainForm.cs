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
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using UtilitiesLibrary.EventLoging;


namespace DPEClientTestApplication
{
	public partial class frmDPEClientTestApplicationMainForm
	{
		public frmDPEClientTestApplicationMainForm()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmDPEClientTestApplicationMainForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmDPEClientTestApplicationMainForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDPEClientTestApplicationMainForm();
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
		
		private DPE_DataPublicationsClient _STXDataSocketClient;
		private CustomEventLog _STXEventLog;
		private int _errorsCount;
		
#endregion
		
#region  < SAFE UI ACCESS >
		
		delegate void SetDataGrid_DataSource_CallBack_Delegate(System.Windows.Forms.DataGridView datagridview, DataTable item);
		delegate void SetButton_VisubleState_CallBack_Delegate(System.Windows.Forms.Button button, bool status);
		
		delegate void listBox_clearItems_CallBack_Delegate(System.Windows.Forms.ListBox listBox);
		delegate dynamic  listBox_Count_CallBack_Delegate(System.Windows.Forms.ListBox listBox);
		delegate void listBox_AddItem_CallBack_Delegate(System.Windows.Forms.ListBox listBox, object item);
		
		
		private void listBox_clearItems(System.Windows.Forms.ListBox listBox)
		{
			if (listBox.InvokeRequired)
			{
				listBox_clearItems_CallBack_Delegate d = new listBox_clearItems_CallBack_Delegate(listBox_clearItems);
				this.Invoke(d, new object[] {listBox});
			}
			else
			{
				listBox.Items.Clear();
			}
		}
		
		private dynamic listBox_Count(System.Windows.Forms.ListBox listBox)
		{
			if (listBox.InvokeRequired)
			{
				listBox_Count_CallBack_Delegate d = new listBox_Count_CallBack_Delegate(listBox_Count);
				this.Invoke(d, new object[] {listBox});
                return listBox.Items.Count;
        	}
			else
			{
				return listBox.Items.Count;
			}
		}
		
		private void listBox_AddItem(System.Windows.Forms.ListBox listBox, object item)
		{
			if (listBox.InvokeRequired)
			{
				listBox_AddItem_CallBack_Delegate d = new listBox_AddItem_CallBack_Delegate(listBox_AddItem);
				this.Invoke(d, new object[] {listBox, item});
			}
			else
			{
				listBox.Items.Add(item);
			}
		}
		
		
		private void SetDataGrid_DataSource(System.Windows.Forms.DataGridView datagridview, DataTable item)
		{
			if (datagridview.InvokeRequired)
			{
				SetDataGrid_DataSource_CallBack_Delegate d = new SetDataGrid_DataSource_CallBack_Delegate(SetDataGrid_DataSource);
				this.Invoke(d, new object[] {datagridview, item});
			}
			else
			{
				datagridview.DataSource = item;
			}
		}
		
		private void SetButton_VisibleStatus(System.Windows.Forms.Button button, bool status)
		{
			if (button.InvokeRequired)
			{
				SetButton_VisubleState_CallBack_Delegate d = new SetButton_VisubleState_CallBack_Delegate(SetButton_VisibleStatus);
				this.Invoke(d, new object[] {button, status});
			}
			else
			{
				button.Visible = status;
			}
		}
		
		//Private Sub Set_ToolStripLabel_Text(ByVal label As Windows.Forms.ToolStripLabel, ByVal text As String)
		//    If label.InvokeRequired Then
		//        Dim d As New Set_ToolStripLabel_Text_CallBack_Delegate(AddressOf SetButton_VisibleStatus)
		//        Me.Invoke(d, New Object() {Button, status})
		//    Else
		//        Button.Visible = status
		//    End If
		//End Sub
		delegate void TextBoxTextSetCallBack(TextBox TextBoxC, object data);
		public void TextBox_Text(TextBox TextBoxCtrl, object data)
		{
			try
			{
				if (TextBoxCtrl.InvokeRequired)
				{
					TextBoxTextSetCallBack d = new TextBoxTextSetCallBack(TextBox_Text);
					TextBoxCtrl.Invoke(d, new object[] {TextBoxCtrl, data});
				}
				else
				{
					TextBoxCtrl.Text = System.Convert.ToString(data);
				}
			}
			catch (Exception)
			{
				
			}
			
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
#endregion
		
#region  < EVENT HANDLING >
		
		
		private void ConnectionWithServerLost()
		{
			this.ssConnectionLabel.Text = "Connection With Server Lost!!!!";
			this.SetButton_VisibleStatus(this.btnConnectToServer, true);
		}
		
		private void _STXEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				switch (LogEntryInfo.Type)
				{
					case EventLogEntryType.Error:
					case EventLogEntryType.FailureAudit:
					case EventLogEntryType.Warning:
						this._errorsCount++;
						TextBox_Text(this.txtErrorsCount, System.Convert.ToString(this._errorsCount));
						break;
				}
				
				if (this.listBox_Count(this.lstSTXEventLog) > 500)
				{
					this.listBox_clearItems(this.lstSTXEventLog);
				}
				this.listBox_AddItem(this.lstSTXEventLog, LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmSTXDataSocketClient_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._STXDataSocketClient.DisconnectFromServer();
				this._STXDataSocketClient.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void STXDataSocketClient_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._STXEventLog = CustomEventLog.GetInstance();
				this._STXEventLog.LogEntryReceived += this._STXEventLog_LogEntryReceived;
			}
			catch (Exception)
			{
			}
			
			this._errorsCount = 0;
			this.txtErrorsCount.Text = System.Convert.ToString(this._errorsCount);
			
			try
			{
				this._STXDataSocketClient = new DPE_DataPublicationsClient();
				this._STXDataSocketClient.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
				this._STXDataSocketClient.ConnectToServer();
				this.ssConnectionLabel.Text = "Connected to Server";
				
				try
				{
					this.dgrdServerParameters.DataSource = this._STXDataSocketClient.ServerParametersTable;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				try
				{
					this.dgrdSTXDSSClients.DataSource = this._STXDataSocketClient.GetClientsRegistryTable();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				try
				{
					this.dgrdPublihsers.DataSource = this._STXDataSocketClient.GetPublihsersRegistryTable();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
				try
				{
					this.dgrdPublications.DataSource = this._STXDataSocketClient.GetPublicationsRegistryTable();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			catch (Exception ex)
			{
				this.btnConnectToServer.Visible = true;
				MessageBox.Show(ex.Message);
			}
			
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dgrdPublihsers.DataSource = this._STXDataSocketClient.GetPublihsersRegistryTable();
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
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dgrdPublications.DataSource = this._STXDataSocketClient.GetPublicationsRegistryTable();
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
		
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.dgrdSTXDSSClients.DataSource = this._STXDataSocketClient.GetClientsRegistryTable();
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
		
		
		public void btnConnectToServer_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this._STXDataSocketClient = new DPE_DataPublicationsClient();
				this._STXDataSocketClient.ConnectionWithSTXDataServerLost += this.ConnectionWithServerLost;
				this._STXDataSocketClient.ConnectToServer();
				this.btnConnectToServer.Visible = false;
				this.ssConnectionLabel.Text = "Connected to Server";
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
		
		public void btnClearLog_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstSTXEventLog.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
		public void lstSTXEventLog_DoubleClick(System.Object sender, System.EventArgs e)
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
		
#endregion
		
		
	}
	
}
