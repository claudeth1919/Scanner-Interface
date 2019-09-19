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



namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_PublicationVariableSimulationHandlerContainer : IEnumerable
	{
		
		
#region  < DATAMEMBERS >
		
		private Hashtable _variablesTabPagesTable;
		private Hashtable _handlersTable;
		private DPE_DataPublicationsClient _client;
		
#endregion
		
		
#region  < CONSTRUCTORS >
		
		
		public CF_DPE_PublicationVariableSimulationHandlerContainer(DPE_DataPublicationsClient client)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._variablesTabPagesTable = new Hashtable();
			this._handlersTable = new Hashtable();
			this._client = client;
			if (!this._client.IsConnected)
			{
				this._client.ConnectToServer();
			}
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void EventHandling_VariableSimulationHandler_simulationStatusChanged(CF_DPE_PublicationVariableSimulationHandler handler)
		{
			ClientHandlersDataContainer.GetInstance().SaveData();
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void AddVariableHandler(string publicationNAme, ref publicationsPosting.PublicationVariableDefinitionData variableDefinition)
		{
			if (!this._handlersTable.ContainsKey(variableDefinition.VariableName))
			{
				System.Windows.Forms.TabPage TabPage = new System.Windows.Forms.TabPage(variableDefinition.VariableName);
				CF_DPE_PublicationVariableSimulationHandler handler = new CF_DPE_PublicationVariableSimulationHandler(this._client, publicationNAme, variableDefinition);
				handler.SimulationStatusChanged += EventHandling_VariableSimulationHandler_simulationStatusChanged;
				handler.Dock = System.Windows.Forms.DockStyle.Fill;
				TabPage.Controls.Add(handler);
				
				TabPage_Add(this.tabVariablesSimulationHandler, TabPage);
				
				this._variablesTabPagesTable.Add(variableDefinition.VariableName, TabPage);
				this._handlersTable.Add(variableDefinition.VariableName, handler);
			}
			else
			{
				throw (new Exception("The variable \'" + variableDefinition.VariableName + "\' already has a handler"));
			}
		}
		
		public void RemoveVariableHandler(string variableName)
		{
			if (this._variablesTabPagesTable.ContainsKey(variableName))
			{
				System.Windows.Forms.TabPage tab = default(System.Windows.Forms.TabPage);
                tab = (System.Windows.Forms.TabPage)this._variablesTabPagesTable[variableName];
				this.tabVariablesSimulationHandler.TabPages.Remove(tab);
				try
				{
					tab.Dispose();
				}
				catch (Exception)
				{
				}
				CF_DPE_PublicationVariableSimulationHandler handler = default(CF_DPE_PublicationVariableSimulationHandler);
                handler = (CF_DPE_PublicationVariableSimulationHandler)this._handlersTable[variableName];
				
				handler.SimulationStatusChanged -= EventHandling_VariableSimulationHandler_simulationStatusChanged;
				handler.DisposeHandler();
				
				this._variablesTabPagesTable.Remove(variableName);
				this._handlersTable.Remove(variableName);
			}
		}
		
		public void SetVariableTab(string VariableName)
		{
			if (this._handlersTable.ContainsKey(VariableName))
			{
				System.Windows.Forms.TabPage tabPage = default(System.Windows.Forms.TabPage);
				tabPage = (System.Windows.Forms.TabPage)this._variablesTabPagesTable[VariableName];
				this.tabVariablesSimulationHandler.SelectedTab = tabPage;
			}
		}
		
		public CF_DPE_PublicationVariableSimulationHandler GetVariableSimulationHandler(string variablename)
		{
            return (CF_DPE_PublicationVariableSimulationHandler)this._handlersTable[variablename];
		}
		
#endregion
		
#region  < UI CALLBACKS>
		
#endregion
		
#region  < DELEGATES >

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
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IEnumerable >
		
		public System.Collections.IEnumerator GetEnumerator()
		{
			return this._handlersTable.GetEnumerator();
		}
		
#endregion
		
#endregion
		
		
		
		
		
	}
	
}
