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
using CommunicationsUISupportLibrary.publicationsPosting;
using CommunicationsUISupportLibrary.publicationsPosting.containers;
using CommunicationsUISupportLibrary.publicationsConnection;
using CommunicationsUISupportLibrary.publicationsConnection.containers;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_PublicationPostHandler
	{
		
#region  < DATA MEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private string _publicationName;
		private CF_DPE_PublicationVariableSimulationHandlerContainer _variablesHandlerContainer;
		private ClientHandlerData _ClientHandlerData;
		
#endregion
		
#region  < PROPERTIES  >
		
internal DPE_DataPublicationsClient DSSClient
		{
			get
			{
				return this._client;
			}
		}
		
internal string PublicationName
		{
			get
			{
				return this._publicationName;
			}
		}
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public CF_DPE_PublicationPostHandler(DPE_DataPublicationsClient client, string publicationName, ClientHandlerData ClientHandlerData)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._client = client;
			this._publicationName = publicationName;
			this._ClientHandlerData = ClientHandlerData;
			this._variablesHandlerContainer = new CF_DPE_PublicationVariableSimulationHandlerContainer(this._client);
			this._variablesHandlerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlVariablesHandler.Controls.Add(this._variablesHandlerContainer);
			
			PostedPublicationDefinitionData data = this._ClientHandlerData.GetPublicationPostDefinition(this._publicationName);
			if (!(data == null))
			{
				IEnumerator enumm = data.VariablesDefinitionContainer.GetEnumerator();
				PublicationVariableDefinitionData var = null;
				while (enumm.MoveNext())
				{
					var = (PublicationVariableDefinitionData)enumm.Current;
					this._variablesHandlerContainer.AddVariableHandler(this._publicationName, ref var);
				}
				
				enumm = data.VariablesDefinitionContainer.GetEnumerator();
				CF_DPE_PublicationVariableSimulationHandler simHadler = null;
				while (enumm.MoveNext())
				{
                    var = (PublicationVariableDefinitionData)enumm.Current;
					simHadler = this._variablesHandlerContainer.GetVariableSimulationHandler(var.VariableName);
					if (var.DataUPDATESimulationStatus == PublicationVariableDefinitionData.variableSimulationStatus.running)
					{
						simHadler.StartUPDATESimulation();
					}
					if (var.DataRESETSimulationStatus == PublicationVariableDefinitionData.variableSimulationStatus.running)
					{
						simHadler.StartRESETSimulation();
					}
				}
				
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
		
#region  < PRIVATE METHODS  >
		
		private string GetSelectedPublicationVariableName()
		{
			if (this.lstPostedPublicationVariables.SelectedIndex >= 0)
			{
				string element = System.Convert.ToString(this.lstPostedPublicationVariables.SelectedItem);
				string[] keys = element.Split(new char[] {','});
				string VariableName = keys[0];
				string varTypeStr = keys[1];
				VariableName = VariableName.TrimStart(' ');
				VariableName = VariableName.TrimEnd(' ');
				return VariableName;
			}
			else
			{
				return null;
			}
		}
		
		private string GetSelectedPublicationVariableName(string listElement)
		{
			
			string element = listElement;
			string[] keys = element.Split(new char[] {','});
			string VariableName = keys[0];
			string varTypeStr = keys[1];
			VariableName = VariableName.TrimStart(' ');
			VariableName = VariableName.TrimEnd(' ');
			return VariableName;
			
		}

        private DPE_ServerDefs.PublicationVariableDataType GetSelectedPublicationVariableDataType()
		{
			if (this.lstPostedPublicationVariables.SelectedIndex >= 0)
			{
				string element = System.Convert.ToString(this.lstPostedPublicationVariables.SelectedItem);
				string[] keys = element.Split(new char[] {','});
				string VariableName = keys[0];
				string varTypeStr = keys[1];
				varTypeStr = varTypeStr.TrimEnd(' ');
				varTypeStr = varTypeStr.TrimStart(' ');
                DPE_ServerDefs.PublicationVariableDataType varType = DPE_ServerDefs.Get_PublicationVariableDataType_FromString(varTypeStr);
				return varType;
			}
			else
			{
				throw new Exception ("No selected element");
			}
		}

        private DPE_ServerDefs.PublicationVariableDataType GetSelectedPublicationVariableDataType(string listElement)
		{
			
			string element = listElement;
			string[] keys = element.Split(new char[] {','});
			string VariableName = keys[0];
			string varTypeStr = keys[1];
			varTypeStr = varTypeStr.TrimEnd(' ');
			varTypeStr = varTypeStr.TrimStart(' ');
            DPE_ServerDefs.PublicationVariableDataType varType = DPE_ServerDefs.Get_PublicationVariableDataType_FromString(varTypeStr);
			return varType;
			
		}
		
		
		
#endregion
		
#region  < FRIEND METHODS >
		
		internal void LoadPublicationVariables()
		{
			ClearListBox(this.lstPostedPublicationVariables);
			DataTable dt = this._client.GetListOfVariablesPublishedOnAPublication(this._publicationName);
			
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
				SetListBox_Item(this.lstPostedPublicationVariables, str);
			}
			
		}
		
#region  < DATA UPDATE METHODS >
		
		internal void StartAll_DATA_UPDATE_Simulations()
		{
			
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.StartUPDATESimulation();
			}
			
		}
		
		private void DefineUPDATEntervallForAllHandlers(int Interval)
		{
			
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.DefineUPDATERateInterval(Interval);
			}
			
		}
		
		internal void StopAll_DATA_UPDATE_Simulations()
		{
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.StopUPDATESimulation();
			}
		}
		
#endregion
		
#region  < DATA RESET METHODS >
		
		internal void StartAll_DATA_RESET_Simulations()
		{
			
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.StartRESETSimulation();
			}
			
		}
		
		internal void StopAll_DATA_RESET_Simulations()
		{
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.StopRESETimulation();
			}
		}
		
		private void DefineRESETIntervallForAllHandlers(int Interval)
		{
			
			IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
			CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
			
			while (enumm.MoveNext())
			{
                handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
				handler.DefineRESETRateInterval(Interval);
			}
			
		}
		
		
#endregion
		
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void bntStartAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.StartAll_DATA_UPDATE_Simulations();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnSTOPall_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.StopAll_DATA_UPDATE_Simulations();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void lstPostedPublicationVariables_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstPostedPublicationVariables.SelectedIndex >= 0)
				{
					string VariableName = this.GetSelectedPublicationVariableName();
					this._variablesHandlerContainer.SetVariableTab(VariableName);
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
				if (Interaction.MsgBox("Reset Statistics?", MsgBoxStyle.YesNo, null) == MsgBoxResult.Yes)
				{
					IEnumerator enumm = this._variablesHandlerContainer.GetEnumerator();
					CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
					
					while (enumm.MoveNext())
					{
                        handler = (CF_DPE_PublicationVariableSimulationHandler)((DictionaryEntry)enumm.Current).Value;
						handler.ResetStatistics();
					}
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				using (frm_DPE_SimulationStatistics frm = new frm_DPE_SimulationStatistics(this))
				{
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						
					}
				}
				
			}
			catch (Exception)
			{
			}
		}
		
		public void btnHideShowList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (!this.spltrMainSpliterCtrl.Panel1Collapsed)
				{
					this.spltrMainSpliterCtrl.Panel1Collapsed = true;
					this.btnHideShowList.Text = ">>  Show List";
				}
				else
				{
					this.spltrMainSpliterCtrl.Panel1Collapsed = false;
					this.btnHideShowList.Text = "<<  Hide List";
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frm_DPE_IntervallValue frm = new frm_DPE_IntervallValue();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.DefineUPDATEntervallForAllHandlers(frm.Interval);
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button6_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.StartAll_DATA_RESET_Simulations();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button5_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.StopAll_DATA_RESET_Simulations();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frm_DPE_IntervallValue frm = new frm_DPE_IntervallValue();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.DefineRESETIntervallForAllHandlers(frm.Interval);
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		
		public void Button7_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				if (this.lstPostedPublicationVariables.SelectedIndex >= 0)
				{
					string VariableName = this.GetSelectedPublicationVariableName();
                    DPE_ServerDefs.PublicationVariableDataType varType = this.GetSelectedPublicationVariableDataType();
					
					//modifies the handler data for the
					publicationsPosting.PublicationVariableDefinitionData varDef = this._ClientHandlerData.GetPublicationPostDefinition(this._publicationName).GetVariableDefinition(VariableName);
					this._variablesHandlerContainer.AddVariableHandler(this._publicationName, ref varDef);
					
					ClientHandlersDataContainer.GetInstance().SaveData();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button8_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				IEnumerator enumm = default(IEnumerator);
				string listElement = "";
				
				
				if (this.lstPostedPublicationVariables.Items.Count >= 0)
				{
					
					enumm = this.lstPostedPublicationVariables.Items.GetEnumerator();
					
					while (enumm.MoveNext())
					{
						listElement = System.Convert.ToString(enumm.Current);
						
						string VariableName = this.GetSelectedPublicationVariableName(listElement);
                        DPE_ServerDefs.PublicationVariableDataType varType = this.GetSelectedPublicationVariableDataType(listElement);
						
						//modifies the handler data for the
						publicationsPosting.PublicationVariableDefinitionData varDef = this._ClientHandlerData.GetPublicationPostDefinition(this._publicationName).GetVariableDefinition(VariableName);
						this._variablesHandlerContainer.AddVariableHandler(this._publicationName, ref varDef);
						
					}
					
					
					ClientHandlersDataContainer.GetInstance().SaveData();
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button9_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.LoadPublicationVariables();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion
		
		
		
		
		
		
		
	}
	
}
