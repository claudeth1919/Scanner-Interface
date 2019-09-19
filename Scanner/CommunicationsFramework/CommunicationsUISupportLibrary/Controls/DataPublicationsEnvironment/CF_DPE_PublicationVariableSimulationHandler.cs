using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.DataPublicationsEnvironment;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using System.Windows.Forms;



namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_PublicationVariableSimulationHandler
	{
		
#region  < DATAMEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private publicationsPosting.PublicationVariableDefinitionData _variableDefinition;
		private string _publicationName;
		private System.Timers.Timer _statsUpdateTimer;
		
#endregion
		
#region  < EVENTS  >
		
		public delegate void SimulationStatusChangedEventHandler(CF_DPE_PublicationVariableSimulationHandler handler);
		private SimulationStatusChangedEventHandler SimulationStatusChangedEvent;
		
		public event SimulationStatusChangedEventHandler SimulationStatusChanged
		{
			add
			{
				SimulationStatusChangedEvent = (SimulationStatusChangedEventHandler) System.Delegate.Combine(SimulationStatusChangedEvent, value);
			}
			remove
			{
				SimulationStatusChangedEvent = (SimulationStatusChangedEventHandler) System.Delegate.Remove(SimulationStatusChangedEvent, value);
			}
		}
		
		
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public CF_DPE_PublicationVariableSimulationHandler(DPE_DataPublicationsClient client, string publicationName, publicationsPosting.PublicationVariableDefinitionData variableDefinition)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._publicationName = publicationName;
			this._variableDefinition = variableDefinition;
			this._client = client;
			if (!this._client.IsConnected)
			{
				this._client.ConnectToServer();
			}
			variableDefinition.SimulationHandlerExists = true;
			
			this._statsUpdateTimer = new System.Timers.Timer(250);
			this._statsUpdateTimer.Elapsed += this._statsUpdateTimer_Elapsed;
			this._statsUpdateTimer.AutoReset = false;
			this._statsUpdateTimer.Stop();
			
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private bool GetBooleanData()
		{
			Random RandomClass = new Random();
			int RandomNumber = 0;
			RandomNumber = RandomClass.Next(0, 1);
			if (RandomNumber <= 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		private CustomHashTable GetCFHashTable()
		{
			CustomHashTable table = new CustomHashTable();
			int i = 0;
			string key = "";
			for (i = 0; i <= 10; i++)
			{
				key = this._client.ClientName + System.Convert.ToString(i);
				table.Add(key, i);
			}
			return table;
		}
		
		private CustomList GetCFList()
		{
			CustomList list = new CustomList();
			int i = 0;
			string key = "";
			for (i = 0; i <= 10; i++)
			{
				key = this._client.ClientName + System.Convert.ToString(i);
				list.Add(key);
			}
			return list;
		}
		
		private CustomSortedList GetCFSortedList()
		{
			CustomSortedList list = new CustomSortedList();
			int i = 0;
			for (i = 0; i <= 10; i++)
			{
				list.Add(Guid.NewGuid().ToString(), i);
			}
			return list;
		}
		
		private DataTable GetDataTable()
		{
			string tableName = Guid.NewGuid().ToString();
			DataTable dt = new DataTable(tableName);
			Random RandomClass = new Random();
			
			dt.Columns.Add("Col1");
			dt.Columns.Add("Col2");
			dt.Columns.Add("Col3");
			DataRow row = default(DataRow);
			
			for (var i = 0; i <= 10; i++)
			{
				row = dt.NewRow();
				row[0] = Guid.NewGuid().ToString();
				row[1] = System.Convert.ToString(RandomClass.Next(1, 100));
				row[2] = DateTime.Now.ToString();
				dt.Rows.Add(row);
			}
			return dt;
		}
		
		private DataSet GetDataSet()
		{
			DataSet ds = new DataSet(Guid.NewGuid().ToString());
			for (var i = 0; i <= 3; i++)
			{
				ds.Tables.Add(this.GetDataTable());
			}
			return ds;
		}
		
		private decimal GetDecimal()
		{
			Random RandomClass = new Random();
			decimal RandomNumber = new decimal();
			RandomNumber = System.Convert.ToDecimal(RandomClass.Next(0, 1000));
			return RandomNumber;
		}
		
		private string GetString()
		{
			return Guid.NewGuid().ToString();
		}
		
		private int GetInteger()
		{
			Random RandomClass = new Random();
			int RandomNumber = 0;
			RandomNumber = RandomClass.Next(0, 1000);
			return RandomNumber;
		}
		
		
		private void UpdatePublication()
		{
            if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, System.Convert.ToString(GetBooleanData()));
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFHashTable)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetCFHashTable());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFList)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetCFList());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFSortedList)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetCFSortedList());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataSet)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetDataSet());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetDataTable());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetDecimal());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetString());
				this._client.UpdatePublicationData(data);
			}
            else if (this._variableDefinition.DataType == DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer)
			{
				DPE_PublicationData data = new DPE_PublicationData(this._publicationName, this._variableDefinition.VariableName, GetInteger());
				this._client.UpdatePublicationData(data);
			}
		}
		
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void DisposeHandler()
		{
			try
			{
				this.tmrAutoUpdateTimer.Stop();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void STXDSS_PublicationVariableHandler_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.txtVariableName.Text = this._variableDefinition.VariableName;
                this.txtDataType.Text = System.Convert.ToString(DPE_ServerDefs.Get_String_FromPublicationVariableDataType(this._variableDefinition.DataType));
			}
			catch (Exception)
			{
			}
		}
		
		public void btnManualDataUpdate_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.UpdatePublication();
				this._statsUpdateTimer.Start();
			}
			catch (Exception)
			{
				this.nudErrors.Value++;
			}
		}
		
		
		
		public void chkStartSimulation_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkStartUPDATESimulation.Checked)
				{
					this._variableDefinition.DataUPDATESimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.running;
					this.tmrAutoUpdateTimer.Interval = (int) this.nudUpdateRate.Value;
					this.chkStartUPDATESimulation.Text = "Stop Simulation";
					this.tmrAutoUpdateTimer.Start();
					this._variableDefinition.DataUPDATESimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.running;
					try
					{
						if (SimulationStatusChangedEvent != null)
							SimulationStatusChangedEvent(this);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					this._variableDefinition.DataUPDATESimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.stopped;
					this.chkStartUPDATESimulation.Text = "Start Simulation";
					this._variableDefinition.DataUPDATESimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.stopped;
					this.tmrAutoUpdateTimer.Stop();
					try
					{
						if (SimulationStatusChangedEvent != null)
							SimulationStatusChangedEvent(this);
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void tmrAutoUpdateTimer_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.btnManualDataUpdate_Click(sender, e);
			}
			catch (Exception)
			{
			}
		}
		
		public void btnReset_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._client.ResetPublicationData(this._publicationName, this._variableDefinition.VariableName);
				this._statsUpdateTimer.Start();
			}
			catch (Exception)
			{
				this.nudErrors.Value++;
			}
		}
		
		
		public void btnUpdateStats_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Set_TextBox_Text(this.txtResetCount, System.Convert.ToString(this._client.Statistics.VariableResetWriteCount(this._publicationName, this._variableDefinition.VariableName)));
				this.Set_TextBox_Text(this.txtSendCount, System.Convert.ToString(this._client.Statistics.VariableUpdateWriteCount(this._publicationName, this._variableDefinition.VariableName)));
			}
			catch (Exception)
			{
			}
			
		}
		
		public void btnResetResetCount_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (Interaction.MsgBox("Clear all statistics?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
				{
					this.ResetStatistics();
				}
				
			}
			catch (Exception)
			{
				
			}
		}
		
		public void chkStartRESETSimulation_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkStartRESETSimulation.Checked)
				{
					this._variableDefinition.DataRESETSimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.running;
					this.tmrAutoResetTimer.Interval = (int) this.nudResetRate.Value;
					this.chkStartRESETSimulation.Text = "Stop Simulation";
					this.tmrAutoResetTimer.Start();
					this._variableDefinition.DataRESETSimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.running;
					try
					{
						if (SimulationStatusChangedEvent != null)
							SimulationStatusChangedEvent(this);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					this._variableDefinition.DataRESETSimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.stopped;
					this.chkStartRESETSimulation.Text = "Start Simulation";
					this._variableDefinition.DataRESETSimulationStatus = publicationsPosting.PublicationVariableDefinitionData.variableSimulationStatus.stopped;
					this.tmrAutoResetTimer.Stop();
					try
					{
						if (SimulationStatusChangedEvent != null)
							SimulationStatusChangedEvent(this);
					}
					catch (Exception)
					{
					}
				}
			}
			catch (Exception)
			{
			}
		}
		
		
		public void tmrAutoResetTimer_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.btnReset_Click(sender, e);
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < FRIEND METHODS >
		
		internal void StartUPDATESimulation()
		{
			try
			{
				CheckBox_Checked(this.chkStartUPDATESimulation, true);
				this.btnUpdateStats_Click(null, null);
			}
			catch (Exception)
			{
			}
			
		}
		
		internal void StopUPDATESimulation()
		{
			try
			{
				CheckBox_Checked(this.chkStartUPDATESimulation, false);
				this.btnUpdateStats_Click(null, null);
			}
			catch (Exception)
			{
			}
			
		}
		
		
		internal void StartRESETSimulation()
		{
			try
			{
				CheckBox_Checked(this.chkStartRESETSimulation, true);
				this.btnUpdateStats_Click(null, null);
			}
			catch (Exception)
			{
			}
			
		}
		
		internal void StopRESETimulation()
		{
			try
			{
				CheckBox_Checked(this.chkStartRESETSimulation, false);
				this.btnUpdateStats_Click(null, null);
			}
			catch (Exception)
			{
			}
			
		}
		
		
		internal void DefineUPDATERateInterval(int value)
		{
			this.nudUpdateRate.Value = value;
			this.tmrAutoUpdateTimer.Interval = (int) this.nudUpdateRate.Value;
		}
		
		internal void DefineRESETRateInterval(int value)
		{
			this.nudUpdateRate.Value = value;
			this.tmrAutoUpdateTimer.Interval = (int) this.nudUpdateRate.Value;
		}
		
		
		internal void ResetStatistics()
		{
			try
			{
				this._client.Statistics.ResetPublicationWriteStatistics(this._publicationName, this._variableDefinition.VariableName);
				this.txtResetCount.Text = System.Convert.ToString(this._client.Statistics.VariableResetWriteCount(this._publicationName, this._variableDefinition.VariableName));
				this.txtSendCount.Text = System.Convert.ToString(this._client.Statistics.VariableUpdateWriteCount(this._publicationName, this._variableDefinition.VariableName));
				
			}
			catch (Exception)
			{
			}
			
		}
		
		
		
#endregion
		
#region  < EVENT HANDLING  >
		
		private void _statsUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				this.btnUpdateStats_Click(null, null);
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < DELEGATES >
		
		delegate void checkBox_Checked_CallBack(System.Windows.Forms.CheckBox checkBox, bool checkStatus);
		
		public void CheckBox_Checked(System.Windows.Forms.CheckBox checkBoxCtrl, bool checkStatus)
		{
			try
			{
				if (checkBoxCtrl.InvokeRequired)
				{
					checkBox_Checked_CallBack d = new checkBox_Checked_CallBack(CheckBox_Checked);
					checkBoxCtrl.Invoke(d, new object[] {checkBoxCtrl, checkStatus});
				}
				else
				{
					checkBoxCtrl.Checked = checkStatus;
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void CheckBox1_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.nudErrors.Value = 0;
			}
			catch (Exception)
			{
			}
		}
		
		
	


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

        delegate void SetListBox_ItemCallBackDelegate(System.Windows.Forms.ListBox listBox, object item);
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

        delegate void ClearListBox_CallBackDelegate(System.Windows.Forms.ListBox listBox);
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


        delegate void Set_TextBox_Text_CallBack_Delegate(System.Windows.Forms.TextBox textBox, string text);
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

        delegate void Set_Label_Text_CallBack_Delegate(System.Windows.Forms.Label label, string text);
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
		
		
		
		
		
		
		
		
		
		
		
	}
	
}
