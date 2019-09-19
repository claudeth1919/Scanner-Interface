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
using CommunicationsLibrary.DataPublicationsEnvironment.Server;
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Services;
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;




namespace DPEServerApp
{
	public partial class frm_DataPublicationsServerApplication
	{
		public frm_DataPublicationsServerApplication()
		{
			InitializeComponent();
		}
		
#region  < DATA MEMBERS >
		
		private DPE_DataPublicationsServer _DPEDataPublicationsServer;
		private CustomEventLog _eventLog;
		private int _errorsCount;
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void _stxEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				switch (LogEntryInfo.Type)
				{
					case EventLogEntryType.Error:
					case EventLogEntryType.FailureAudit:
					case EventLogEntryType.Warning:
						this._errorsCount++;
						UIControlsSafeAccessFunctions.TextBox_Text(this.txtErrorsCount, System.Convert.ToString(this._errorsCount));
						break;
				}
				if (this.lststxEventLog.Items.Count >= 255)
				{
					UIControlsSafeAccessFunctions.ListBox_Items_Clear(this.lststxEventLog);
				}
				UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lststxEventLog, LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine));
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmDataSocketServerApplication_Load(System.Object sender, System.EventArgs e)
		{
			
			AppRunCheck.Check_If_IAm_Running_ExitIfTrue_And_ShowMessage();
			
			try
			{
				_eventLog = CustomEventLog.GetInstance();
				_eventLog.LogEntryReceived += _stxEventLog_LogEntryReceived;
			}
			catch (Exception)
			{
			}
			this._errorsCount = 0;
			
			this.txtErrorsCount.Text = System.Convert.ToString(this._errorsCount);
			
			try
			{
				this._DPEDataPublicationsServer = DPE_DataPublicationsServer.GetInstance();
				this.dgrdServiceParameters.DataSource = this._DPEDataPublicationsServer.ServiceParametersTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnCloseSErver_Click(System.Object sender, System.EventArgs e)
		{
			GeneralPurposeForms.passwordConfirmationForm frm = new GeneralPurposeForms.passwordConfirmationForm("1004HEX");
			try
			{
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					try
					{
						this._DPEDataPublicationsServer.Dispose();
					}
					catch (Exception)
					{
					}
					try
					{
						this.Dispose();
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
			finally
			{
				frm.Dispose();
			}
			
			
			
		}
		
		public void lststxEventLog_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			try
			{
				if (this.lststxEventLog.SelectedIndex >= 0)
				{
					MessageBox.Show(System.Convert.ToString(this.lststxEventLog.SelectedItem));
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
				this.lststxEventLog.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.FolderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._DPEDataPublicationsServer.ExportServerParametersToFile(this.FolderBrowserDialog1.SelectedPath);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
	
}
