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
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;
using UtilitiesLibrary.EventLoging;



namespace CNDEnvTestApp
{
	public partial class frmSTXCommunicationsEnvironmentTestForm
	{
		public frmSTXCommunicationsEnvironmentTestForm()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmSTXCommunicationsEnvironmentTestForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmSTXCommunicationsEnvironmentTestForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmSTXCommunicationsEnvironmentTestForm();
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
		
		private CommunicationsManager manager;
		private CustomEventLog _eventLog;
		
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void manager_CNDTableChanged(DataTable table)
		{
			try
			{
                UIControlsSafeAccessFunctions.DataGridView_DataSource(this.dgrdCNDTable, CommunicationsManager.GetInstance().CNDTable);
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
		
		public void btnUpdateCNDTable_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
                UIControlsSafeAccessFunctions.DataGridView_DataSource(this.dgrdCNDTable, CommunicationsManager.GetInstance().CNDTable);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void frmSTXCommunicationsEnvironmentTestForm_Load(System.Object sender, System.EventArgs e)
		{
			
			try
			{
				this._eventLog = CustomEventLog.GetInstance();
                this._eventLog.LogEntryReceived += new CustomEventLog.LogEntryReceivedEventHandler(this._stxeventLog_LogEntryReceived);
			}
			catch (Exception)
			{
			}
			try
			{
				manager = CommunicationsManager.GetInstance();
				manager.CNDTableChanged += new  CommunicationsManager.CNDTableChangedEventHandler(this.manager_CNDTableChanged);
				this.dgrdCNDTable.DataSource = manager.CNDTable;
			}
			catch (Exception ex)
			{
                Interaction.MsgBox(ex.Message);
			}
			
		}
		
#endregion
		
		
		
	}
	
}
