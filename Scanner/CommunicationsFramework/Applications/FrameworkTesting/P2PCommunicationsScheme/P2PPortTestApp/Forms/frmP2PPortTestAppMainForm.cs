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
using UtilitiesLibrary.Data;
using CommunicationsUISupportLibrary;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;





namespace P2PPortTestApp
{
	public partial class frmP2PPortTestAppMainForm : IUseP2PCommunicationsScheme
	{
		
		
#region  < DATAMEMBERS  >
		
		private P2PPort _P2PPort;
		
#endregion
		
#region  < CONSTURCTORS >
		
		public frmP2PPortTestAppMainForm(int portNumber)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._P2PPort = new P2PPort(this, portNumber);
			this._P2PPort.NewClientConnection += this.NewClientConnection;
			this._P2PPort.ClientDisconnection += this.ClientDisconnection;
		}
		
		public frmP2PPortTestAppMainForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._P2PPort = new P2PPort(this);
			this._P2PPort.NewClientConnection += this.NewClientConnection;
			this._P2PPort.ClientDisconnection += this.ClientDisconnection;
		}
		
#endregion
		
#region  < CONTROL SAFE ACCESS >
		
		delegate void SetListBoxItemCallBack(System.Windows.Forms.ListBox  listBox, object item);
        delegate void RemoveItemFromListBoxCallBack(System.Windows.Forms.ListBox listBox, object item);
        delegate void SetTextBoxTextCallBack(TextBox listbox, string text);
		delegate void SetDataGridDataSourceCallBack(DataGridView dataGrid, DataTable dataSource);
		
		
		private void SetListBoxItem(System.Windows.Forms.ListBox ListBox, object item)
		{
			if (ListBox.InvokeRequired)
			{
				SetListBoxItemCallBack d = new SetListBoxItemCallBack(SetListBoxItem);
				this.Invoke(d, new object[] {ListBox, item});
			}
			else
			{
				ListBox.Items.Add(item);
			}
		}
		
		private void RemoveListBoxItem(System.Windows.Forms.ListBox ListBox, object item)
		{
			if (ListBox.InvokeRequired)
			{
				RemoveItemFromListBoxCallBack d = new RemoveItemFromListBoxCallBack(RemoveListBoxItem);
				this.Invoke(d, new object[] {ListBox, item});
			}
			else
			{
				ListBox.Items.Remove(item);
			}
		}
		
		private void SetTextBoxText(TextBox textBoxCtrl, string text)
		{
			if (textBoxCtrl.InvokeRequired)
			{
				SetTextBoxTextCallBack d = new SetTextBoxTextCallBack(SetTextBoxText);
				this.Invoke(d, new object[] {textBoxCtrl, text});
			}
			else
			{
				textBoxCtrl.Text = text;
			}
		}
		
		private void SetDataGridDataSource(DataGridView dataGrid, DataTable data)
		{
			if (dataGrid.InvokeRequired)
			{
				SetDataGridDataSourceCallBack d = new SetDataGridDataSourceCallBack(SetDataGridDataSource);
				this.Invoke(d, new object[] {dataGrid, data});
			}
			else
			{
				dataGrid.DataSource = data;
			}
		}
		
		
#endregion
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IUseP2PCommunicationsScheme >
		
CommunicationsLibrary.Services.P2PCommunicationsScheme.P2PPort CommunicationsLibrary.Services.P2PCommunicationsScheme.IUseP2PCommunicationsScheme.P2PSocketPort
		{
			get
			{
				return this.P2PPort;
			}
		}
		
public CommunicationsLibrary.Services.P2PCommunicationsScheme.P2PPort P2PPort
		{
			get
			{
				return this._P2PPort;
			}
		}
		
public string P2PPortOwnerName
		{
			get
			{
				return "P2P PORT TEST APPLICATION";
			}
		}
		
		public void ReceiveData(CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PData data, int HandlerP2PPortNumber)
		{
			if (this.chkEmulateErrorOnReception.Checked)
			{
				if (this.txtErrorEmulation.Text.Length > 0)
				{
					throw (new Exception(this.txtErrorEmulation.Text));
				}
				else
				{
					throw (new Exception("Error at the remote port data reception"));
				}
			}
			if (this.chkShowDataReceivedOnTable.Checked)
			{
				this.SetListBoxItem(this.lstDataReceived, data);
			}
			this.SetDataGridDataSource(this.dgrGeneralStatistics, this._P2PPort.Statistics.GeneralStatisticsTable);
			this.SetDataGridDataSource(this.drgReceptionStatistics, this._P2PPort.Statistics.DataReceptionStatisticsTable);
		}
		
		public CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PData RetrieveData(CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PDataRequest request, int HandlerP2PPortNumber)
		{
			string dataName = request.RequestedDataName;
			
			if (this.chkSimulateHaltExecution.Checked)
			{
				while (true)
				{
					System.Threading.Thread.Sleep(10);
					if (!this.chkSimulateHaltExecution.Checked)
					{
						break;
					}
				}
			}
			
			if (this.chkSimulateFailure.Checked)
			{
				if (rbtnSimulateNull.Checked)
				{
					return null;
				}
				else
				{
					throw (new Exception(this.txtExceptionText.Text));
				}
			}
			
			
			if (this.chkRequestLog.Checked)
			{
				string msgStr = "Data Requested : " + dataName;
				this.SetListBoxItem(this.lstRequestReceived, msgStr);
				
			}
			
			
			this.SetDataGridDataSource(this.dgrGeneralStatistics, this._P2PPort.Statistics.GeneralStatisticsTable);
			this.SetDataGridDataSource(this.dgrRequestStatistics, this._P2PPort.Statistics.DataRequestsStatisticsTable);
			
			if (this.CfDataManagerContainer1.ContainsData(dataName))
			{
				Data dat = this.CfDataManagerContainer1.DataItem(dataName);
				P2PData data = default(P2PData);
				data = P2PData.GetP2PDataObject(dataName, dat.data);
				return data;
			}
			else
			{
				return null;
			}
		}
		
#endregion
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private void LoadDataAttributes(P2PData data)
		{
			this.lstDataAttributes.Items.Clear();
			IEnumerator enumm = default(IEnumerator);
			enumm = data.DataAttributesTable.GetEnumerator();
			CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PDataAttributesTable.P2PDataAttribute attr = default(CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PDataAttributesTable.P2PDataAttribute);
			string str = "";
			while (enumm.MoveNext())
			{
				attr = (CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PDataAttributesTable.P2PDataAttribute) enumm.Current;
				str = attr.AttrName + " , " + attr.AttrValue;
				this.lstDataAttributes.Items.Add(str);
			}
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void NewClientConnection(string ClientID)
		{
			try
			{
				this.SetTextBoxText(this.txtConnectedClients, System.Convert.ToString(this._P2PPort.NoOfConnectedP2PClients));
			}
			catch (Exception)
			{
			}
		}
		
		private void ClientDisconnection(string ClientID)
		{
			try
			{
				this.SetTextBoxText(this.txtConnectedClients, System.Convert.ToString(this._P2PPort.NoOfConnectedP2PClients));
			}
			catch (Exception)
			{
			}
		}
		
		public void ClearData()
		{
			try
			{
				this.txtXMLDataString.Text = "";
				this.lstDataReceived.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmP2PSocketPortTestAppMainForm_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.txtListeningPort.Text = System.Convert.ToString(this._P2PPort.ListeningPortNumber);
				this.txtStartDateTime.Text = this._P2PPort.StartDateTime.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnClearRequestLog_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstRequestReceived.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
		private void btnClearDataReceptionLog_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstDataReceived.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClosePort_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._P2PPort.Dispose();
				this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
			}
			catch (Exception)
			{
				
			}
		}
		
		public void lstDataReceived_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			this.txtXMLDataString.Text = "";
			this.lstDataAttributes.Items.Clear();
			
			if (this.lstDataReceived.SelectedIndex >= 0)
			{
				P2PData dat = default(P2PData);
				dat = (CommunicationsLibrary.Services.P2PCommunicationsScheme.Data.P2PData) this.lstDataReceived.SelectedItem;
				
				this.CfDataDisplayCtrl1.ShowData(dat.Value);
				this.txtXMLDataString.Text = dat.XMLDataString;
				if (dat.DataAttributesTable.count > 0)
				{
					this.LoadDataAttributes(dat);
				}
			}
		}
		
		public void txtExceptionText_TextChanged(System.Object sender, System.EventArgs e)
		{
			if (this.txtExceptionText.Text.Length <= 0)
			{
				this.txtExceptionText.Text = "Default Exception Message";
			}
		}
		
#endregion
		
		
		
	}
}
