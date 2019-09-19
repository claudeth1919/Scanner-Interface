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
using UtilitiesLibrary.EventLoging;
using UtilitiesLibrary.Parametrization;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsUISupportLibrary;






namespace SocketsServerTestApp
{
	public partial class frmSocketsServerTest
	{
		
#region  <  COSNTRUCTORS >
		
		public frmSocketsServerTest(int listeningPort)
		{
			InitializeComponent();
			try
			{
				this._stxEventLog = CustomEventLog.GetInstance();
				this._stxEventLog.LogEntryReceived += this._stxEventLog_LogEntryReceived;
			}
			catch (Exception)
			{
			}
			
			this._DataSocketServer = new SocketsServer(listeningPort);
			this._DataSocketServer.NewClientConnection += this.NewClientConnection;
			this._DataSocketServer.ClientDataReceived += this.ClientDataReceived;
			this._DataSocketServer.ClientConnectionFinished += this.ClientConnectionFinished;
			
			this.Text = "Sockets Server : " + System.Convert.ToString(listeningPort);
			
			
		}
		
#endregion
		
#region  < DATA MEMBERS >
		
		private CustomEventLog _stxEventLog;
		private CommunicationsLibrary.Services.SocketsDataDistribution.SocketsServer _DataSocketServer;
		private int _dataReceptionCount;
		private long _dataBroadCastedCounter;
		
#endregion
		
#region  < CONTROL SAFE ACCESS >
		
		delegate void SetListBoxItemCallBack(System.Windows.Forms.ListBox listBox, object item);
        delegate void RemoveItemFromListBoxCallBack(System.Windows.Forms.ListBox listBox, object item);
        delegate void SetTextBoxTextCallBack(TextBox listbox, string text);
		delegate void ListBoxItemsClearCallBack(ListBox ListBoxC);
		
		
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
		
		public void ListBox_Items_Clear(ListBox ListBoxCtrl)
		{
			try
			{
				if (ListBoxCtrl.InvokeRequired)
				{
					ListBoxItemsClearCallBack d = new ListBoxItemsClearCallBack(ListBox_Items_Clear);
					ListBoxCtrl.Invoke(d, new object[] {ListBoxCtrl});
				}
				else
				{
					ListBoxCtrl.Items.Clear();
				}
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBAKS >
		
		private void DataSocketServerTestForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._DataSocketServer.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
#region  < DataSocketServer >
		
		private void NewClientConnection(SocketsServerClientConnectionHandler ClientHandler)
		{
			try
			{
				//adds the client to the clients
				this.SetListBoxItem(this.lstConnectedClients, ClientHandler);
				string msg = "";
				msg = ClientHandler.ConnectionDateTime + " -> " + ClientHandler.IdentityString;
				this.SetListBoxItem(this.lstIncommingConnections, msg);
			}
			catch (Exception)
			{
				//MsgBox(ex.Message)
			}
		}
		
		private void ClientDataReceived(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler, SocketData data)
		{
			try
			{
				this._dataReceptionCount++;
				this.SetTextBoxText(this.txtDataReceivedCount, System.Convert.ToString(this._dataReceptionCount));
				this.ListBox_Items_Clear(this.lstDataAttributes);
				if (this.chkPutIncommingDataIntoList.Checked)
				{
					string msg = "[FROM=" + ClientHandler.IdentityString + "]->[DATA LENGTH = " + System.Convert.ToString(data.DataLenght) + "][DATANAME= " + data.DataName + "][DATA = " + data.XMLDataString + "]";
					this.SetListBoxItem(this.lstBoxDataReceived, data);
				}
				if (this.chkBroadCastReceivedData.Checked)
				{
					server.BroadCastData(data);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void ClientConnectionFinished(SocketsServer server, SocketsServerClientConnectionHandler ClientHandler)
		{
			try
			{
				string msg = DateTime.Now.ToString() + " -> " + ClientHandler.IdentityString;
				this.SetListBoxItem(this.lstOutgoingConnections, msg);
				this.RemoveListBoxItem(this.lstConnectedClients, ClientHandler);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
#endregion
		
#region  < STX EVENT LOG >
		
		private void _stxEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				
				if (UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess.UIControlsSafeAccessFunctions.ListBox_Items_Count(this.lstSTXEventLog) > 250)
				{
					ListBox_Items_Clear(this.lstSTXEventLog);
				}
				string item = LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine);
				UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess.UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstSTXEventLog, item);
			}
			catch (Exception ex)
			{
				UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess.UIControlsSafeAccessFunctions.ListBox_Items_Add(this.lstSTXEventLog, ex.Message);
			}
		}
		
		
#endregion
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private SocketsServerClientConnectionHandler GetSelectedClient()
		{
			if (this.lstConnectedClients.Items.Count > 0)
			{
				if (this.lstConnectedClients.SelectedIndex >= 0)
				{
					SocketsServerClientConnectionHandler client = default(SocketsServerClientConnectionHandler);
					client = (CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionHandler) this.lstConnectedClients.SelectedItem;
					return client;
				}
				else
				{
					throw (new Exception("No selected client from list"));
				}
			}
			else
			{
				throw (new Exception("No clients available on List"));
			}
		}
		
		private dynamic GetSocketData(Data data)
		{
			SocketData sockDat = default(SocketData);
            string dataType = data.data.GetType().ToString();

            switch (dataType)
			{
				case "System.String":
					sockDat = new SocketData(data.DataName, System.Convert.ToString(data.data));
					break;
				case "System.Int32":
					sockDat = new SocketData(data.DataName, System.Convert.ToInt32(data.data));
					break;
				case "System.Decimal":
					sockDat = new SocketData(data.DataName, System.Convert.ToDecimal(data.data));
					break;
				case "System.Boolean":
					sockDat = new SocketData(data.DataName, System.Convert.ToBoolean(data.data));
					break;
				case "System.Data.DataTable":
					sockDat = new SocketData(data.DataName, (DataTable) data.data);
					break;
				case "UtilitiesLibrary.Data.CustomHashTable":
					sockDat = new SocketData(data.DataName, (CustomHashTable) data.data);
					break;
				case "UtilitiesLibrary.Data.CustomList":
					sockDat = new SocketData(data.DataName, (CustomList) data.data);
					break;
				case "UtilitiesLibrary.Data.CustomSortedList":
					sockDat = new SocketData(data.DataName, (CustomSortedList) data.data);
					break;
			}
			return sockDat;
		}
		
#endregion
		
#region  <  UI CALLBACKS >
		
		public void btnSendData_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CFDataManagerCointainer1.DataCount <= 0)
				{
					throw (new Exception("No data available to send"));
				}
				SocketData data = this.CFDataManagerCointainer1.SelectedData;
				if (!(data == null))
				{
					SocketsServerClientConnectionHandler client = this.GetSelectedClient();
					this._DataSocketServer.SendDataToClient(client, data);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnIndBroadCast_Click_1(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CFDataManagerCointainer1.DataCount <= 0)
				{
					throw (new Exception("No data to broad cast"));
				}
				SocketData dat = this.CFDataManagerCointainer1.SelectedData;
				this._DataSocketServer.BroadCastData(dat);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void chkAutoBroadCast_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkAutoBroadCast.Checked)
				{
					if (this.lstAutoBroadCast.Items.Count <= 0)
					{
						this.chkAutoBroadCast.Checked = false;
						throw (new Exception("No data to send"));
					}
					else
					{
						this.chkAutoBroadCast.Text = "STOP" + Constants.vbNewLine + "Automatic BroadCast";
						this.tmrAutoBroadCast.Interval = (int) this.nudIntegerAutoBroadCastRAte.Value;
						this.tmrAutoBroadCast.Start();
						this.btnRemoveFromAutoBroadcastList.Enabled = false;
					}
				}
				else
				{
					this.btnRemoveFromAutoBroadcastList.Enabled = true;
					this.chkAutoBroadCast.Text = "Automatic" + Constants.vbNewLine + "BroadCast";
					this.tmrAutoBroadCast.Stop();
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnAddDataToAutoBrodCast_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CFDataManagerCointainer1.DataCount <= 0)
				{
					throw (new Exception("No data to add to the auto broadcast list"));
				}
				this.lstAutoBroadCast.Items.Add(this.CFDataManagerCointainer1.SelectedData);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnRemoveFromAutoBroadcastList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAutoBroadCast.SelectedIndex >= 0)
				{
					this.lstAutoBroadCast.Items.Remove(this.lstAutoBroadCast.SelectedItem);
				}
				else
				{
					throw (new Exception("No data to remove"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnDisconnect_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._DataSocketServer.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void tmrAutoBroadCast_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				IEnumerator enumm = default(IEnumerator);
				enumm = this.lstAutoBroadCast.Items.GetEnumerator();
				SocketData sockdat = default(SocketData);
				while (enumm.MoveNext())
				{
					sockdat = (CommunicationsLibrary.Services.SocketsDataDistribution.Data.SocketData) enumm.Current;
					this._dataBroadCastedCounter++;
					this.txtAutoBroadCastCounter.Text = this._dataBroadCastedCounter.ToString();
					this._DataSocketServer.BroadCastData(sockdat);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void chkAutoSendToClient_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkAutoSendToClient.Checked)
				{
					if (this.lstConnectedClients.Items.Count <= 0)
					{
						this.chkAutoSendToClient.Checked = false;
						throw (new Exception("No clients connected to send"));
					}
					if (this.lstAutoBroadCast.Items.Count <= 0)
					{
						this.chkAutoSendToClient.Checked = false;
						throw (new Exception("No data available to send"));
					}
					if (this.lstConnectedClients.SelectedIndex < 0)
					{
						this.chkAutoSendToClient.Checked = false;
						throw (new Exception("No selected connected client to send data"));
					}
					this.chkAutoSendToClient.Text = "STOP" + Constants.vbNewLine + "Automatic Client Send";
					this.tmrAutomaticSendToSelectedClient.Interval = (int) this.nudIntegerAutoBroadCastRAte.Value;
					this.tmrAutomaticSendToSelectedClient.Start();
					this.btnRemoveFromAutoBroadcastList.Enabled = false;
					this.lstConnectedClients.Enabled = false;
				}
				else
				{
					this.btnRemoveFromAutoBroadcastList.Enabled = true;
					this.chkAutoSendToClient.Text = "Automatic Send to " + Constants.vbNewLine + "the selected Client";
					this.tmrAutomaticSendToSelectedClient.Stop();
					this.lstConnectedClients.Enabled = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void tmrAutomaticSendToSelectedClient_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				SocketsServerClientConnectionHandler clnt = default(SocketsServerClientConnectionHandler);
				clnt = (CommunicationsLibrary.Services.SocketsDataDistribution.ClientConnectionsHandling.SocketsServerClientConnectionHandler) this.lstConnectedClients.SelectedItem;
				IEnumerator enumm = default(IEnumerator);
				enumm = this.lstAutoBroadCast.Items.GetEnumerator();
				Data dat = default(Data);
				SocketData sockdat = default(SocketData);
				while (enumm.MoveNext())
				{
					dat = (CommunicationsUISupportLibrary.Data) enumm.Current;
					sockdat = this.GetSocketData(dat);
					this._DataSocketServer.SendDataToClient(clnt, sockdat);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			this._dataReceptionCount = 0;
			this.SetTextBoxText(this.txtDataReceivedCount, System.Convert.ToString(this._dataReceptionCount));
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
			catch (Exception)
			{
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				ListBox_Items_Clear(this.lstSTXEventLog);
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
				this._dataBroadCastedCounter = 0;
				this.txtAutoBroadCastCounter.Text = this._dataBroadCastedCounter.ToString();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstBoxDataReceived.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
		public void lstBoxDataReceived_MouseDoubleClick(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstBoxDataReceived.SelectedIndex >= 0)
				{
					SocketData data = (SocketData) this.lstBoxDataReceived.SelectedItem;
					frmDataReceivedView frm = new frmDataReceivedView(data);
					frm.ShowDialog();
					frm.Dispose();
				}
				
				
			}
			catch (Exception)
			{
				
			}
		}
		
		
#endregion
		
		
		public void lstBoxDataReceived_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstDataAttributes.Items.Clear();
				SocketData data = (SocketData) this.lstBoxDataReceived.SelectedItem;
				if (!(data == null))
				{
					if (data.AttributesTable.Count > 0)
					{
                        UtilitiesLibrary.Parametrization.Attribute attr = null;
						string attrStr = "";
						IEnumerator attrEnumm = data.AttributesTable.GetEnumerator();
						while (attrEnumm.MoveNext())
						{
							attr = (UtilitiesLibrary.Parametrization.Attribute) attrEnumm.Current;
							attrStr = attr.Name + "   -   " + attr.Value;
							this.lstDataAttributes.Items.Add(attrStr);
						}
					}
					
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void frmSocketsServerTest_Load(object sender, EventArgs e)
        {

        }
	}
}
