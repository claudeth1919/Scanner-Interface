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
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;
using CommunicationsLibrary.Services;


namespace CNDServerApplication
{
	public partial class frmCNDServerApplication
	{
		public frmCNDServerApplication()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmCNDServerApplication defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmCNDServerApplication Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmCNDServerApplication();
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
		
#region  < DATAMEMBERS>
		
		private CNDService _CNDService;
		private CustomEventLog _stxeventLog;
		
#endregion
		
#region  < SAFE UI ACCESS >
		
		delegate void SetDataGrid_DataSourceCallBackDelegate(System.Windows.Forms.DataGridView datagridview, DataTable item);
		
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
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void CNDTableStatusChanged()
		{
			try
			{
				this.SetDataGrid_DataSource(this.dgrdCNDTable, this._CNDService.ComponentNetworkDirectoryTable);
			}
			catch (Exception)
			{
			}
		}
		
		private void _stxeventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				if (this.lstSTXEventLog.Items.Count > 1000)
				{
					UIControlsSafeAccessFunctions.ListBox_Items_Clear(this.lstSTXEventLog);
				}
				string item = LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine);
				UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstSTXEventLog, item);
			}
			catch (Exception)
			{
			}
		}
		
		
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmCNDServiceApplication_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				_CNDService.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void frmCNDServiceApplication_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._stxeventLog = CustomEventLog.GetInstance();
				this._stxeventLog.LogEntryReceived += this._stxeventLog_LogEntryReceived;
			}
			catch (Exception)
			{
				
			}
			frmServiceIndex frm = new frmServiceIndex();
			try
			{
				this._CNDService = CNDService.GetInstance();
				this._CNDService.CNDTableStatusChanged += this.CNDTableStatusChanged;
				this.dgrdServiceParameters.DataSource = this._CNDService.ServiceParametersTable;
				this.dgrdCNDTable.DataSource = this._CNDService.ComponentNetworkDirectoryTable;
				this.dgrdCNDTable.Columns[0].Width = (int) ((double) dgrdCNDTable.Width / 2);
				this.dgrdCNDTable.Columns[1].Width = (int) ((double) dgrdCNDTable.Width / 2);
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				frm.Dispose();
			}
		}
		
		
		public void btnCloseService_Click(System.Object sender, System.EventArgs e)
		{
			string str = "";
			str = Interaction.InputBox("Enter password", "", "", -1, -1);
			if (str.Length > 0)
			{
				str = str.ToUpper();
				if (str == "1004HEX")
				{
					try
					{
						this._CNDService.Dispose();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
					try
					{
						this.Dispose();
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
			}
		}
		
		public void btnUpdateCNDTable_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.dgrdCNDTable.DataSource = this._CNDService.ComponentNetworkDirectoryTable;
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
		
				
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.FolderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._CNDService.ExportServerParametersToFile(this.FolderBrowserDialog1.SelectedPath);
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
