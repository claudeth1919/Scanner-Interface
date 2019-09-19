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
using CommunicationsLibrary.CNDCommunicationsEnvironment;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using UtilitiesLibrary.EventLoging;



namespace CNDServiceClient
{
	public partial class frmCNDClientMAinform
	{
		public frmCNDClientMAinform()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmCNDClientMAinform defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmCNDClientMAinform Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmCNDClientMAinform();
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
		
#region  < DATA MEMBERS >
		
		private CNDClient _CNDClient;
		private CustomEventLog _eventLog;
		
#endregion
		
#region  < DELEGATES >
		
		delegate void DataGridDataSourceCallBack(DataGridView DataGridC, object Data);
		public void DataGrid_DataSource(DataGridView DataGridCtrl, object DataC)
		{
			try
			{
				if (DataGridCtrl.InvokeRequired)
				{
					DataGridDataSourceCallBack d = new DataGridDataSourceCallBack(DataGrid_DataSource);
					DataGridCtrl.Invoke(d, new object[] {DataGridCtrl, DataC});
				}
				else
				{
					DataGridCtrl.DataSource = DataC;
				}
			}
			catch (Exception)
			{
				
			}
			
		}
		
#endregion
		
#region  < SAFE UI ACCESS >
		
		delegate void ListBoxItemsAddCallBack(ListBox ListBoxC, object data);
		public void ListBox_Items_Add(ListBox ListBoxCtrl, object DataC)
		{
			try
			{
				if (ListBoxCtrl.InvokeRequired)
				{
					ListBoxItemsAddCallBack d = new ListBoxItemsAddCallBack(ListBox_Items_Add);
					ListBoxCtrl.Invoke(d, new object[] {ListBoxCtrl, DataC});
				}
				else
				{
					ListBoxCtrl.Items.Add((DataC).ToString());
				}
			}
			catch (Exception)
			{
				
			}
			
		}
		
		
#endregion
		
#region  < EVENT HANDLING  >
		
		private void _CNDClient_TableUpdatedByServer(DataTable dt)
		{
			try
			{
				DataGrid_DataSource(this.dgrdConnectedComponents, dt);
			}
			catch (Exception)
			{
			}
		}
		
		private void _STXEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				string msg = LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine);
				ListBox_Items_Add(this.lstSTXEventLog, msg);
			}
			catch (Exception)
			{
			}
		}
		
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmCNDClientMAinform_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._CNDClient.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void frmCNDClientMAinform_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._eventLog = CustomEventLog.GetInstance();
				this._eventLog.LogEntryReceived += this._STXEventLog_LogEntryReceived;
			}
			catch (Exception)
			{
			}
			try
			{
				this._CNDClient = new CNDClient();
				this._CNDClient.TableUpdatedByServer += this._CNDClient_TableUpdatedByServer;
				this._CNDClient.Connect();
				this.dgrdConnectedComponents.DataSource = this._CNDClient.GetCNDTableFromServer();
                this.dgrdServicePArams.DataSource = this._CNDClient.ServiceParametersTable;
			}
			catch (Exception)
			{
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstSTXEventLog.Items.Clear();
			}
			catch (Exception)
			{
				
			}
		}
		
		
		public void lstSTXEventLog_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstSTXEventLog.Items.Count > 0)
				{
					if (this.lstSTXEventLog.SelectedIndex >= 0)
					{
						MessageBox.Show(System.Convert.ToString(this.lstSTXEventLog.SelectedItem));
					}
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void btnRefresh_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				DataTable dt = this._CNDClient.GetCNDTableFromServer();
				DataGrid_DataSource(this.dgrdConnectedComponents, dt);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, null);
			}
		}
		
#endregion
		
		
		
	}
}
