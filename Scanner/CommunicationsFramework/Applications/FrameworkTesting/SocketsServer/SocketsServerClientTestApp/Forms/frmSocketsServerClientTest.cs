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
using UtilitiesLibrary.VisualUtilities.UIControlsThreadSafeAccess;
using CommunicationsLibrary.Services.SocketsDataDistribution;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsUISupportLibrary;




namespace SocketsServerClientTestApp
{
	public partial class frmSocketsServerClientTest
	{
		
		private SocketsServerClient _dataSocketClient;
		private CustomEventLog _stxEventLog;
		private int _dataCount;
		private int _dataSendCount;
		private int _dataErrorsCount;
		
#region  < CONSTRUCTORS >
		
		public frmSocketsServerClientTest(string host, int port)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			try
			{
				// Add any initialization after the InitializeComponent() call.
				this._dataSocketClient = new SocketsServerClient(host, port);
				this._dataSocketClient.DataReceived += this.DataReceived;
				this._dataSocketClient.ConnectionLost += this.Disconnection;
				this._dataSocketClient.Connect();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			try
			{
				this._stxEventLog = CustomEventLog.GetInstance();
				this._stxEventLog.LogEntryReceived += this._stxEventLog_LogEntryReceived;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			try
			{
				this.Text = "Sockets Server Client on : " + host + " : " + System.Convert.ToString(port);
			}
			catch (Exception)
			{
			}
			
		}
		
#endregion
		
#region  < CONTROL SAFE ACCESS >
		
		delegate void SetListBoxItemCallBack(System.Windows.Forms.ListBox  listBox, object item);
        delegate void RemoveItemFromListBoxCallBack(System.Windows.Forms.ListBox listBox, object item);
		delegate void SetTextBoxTextCallBack(TextBox listbox, string text);
		
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
		
#endregion
		
#region  < PRIVATE METHODS >
		
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
		
#region  < THREAD SAFE UI ACCESS>
		
		delegate void ListBoxItemsClearCallBack(ListBox ListBoxC);
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
		
		private void DataReceived(SocketData Data, SocketsServerClient sender)
		{
			try
			{
				this._dataCount++;
				this.SetTextBoxText(this.txtDataReceivedCount, System.Convert.ToString(this._dataCount));
				
				if (this.chkshowIncommingData.Checked)
				{
					this.SetListBoxItem(this.lstServerData, Data);
					string logStr = DateTime.Now.ToString() + "-> " + Data.XMLDataString;
					this.SetListBoxItem(this.lstReceptionLog, logStr);
					//displays the attributes list
					ListBox_Items_Clear(this.lstDataAttributes);
                    UtilitiesLibrary.Parametrization.Attribute attr = default(UtilitiesLibrary.Parametrization.Attribute);
					IEnumerator enumm = Data.AttributesTable.GetEnumerator();
					string attrString = "";
					while (enumm.MoveNext())
					{
                        attr = (UtilitiesLibrary.Parametrization.Attribute)enumm.Current;
						attrString = attr.Name + "   -   " + attr.Value;
						ListBox_Items_Add(this.lstDataAttributes, attrString);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void Disconnection(CommunicationsLibrary.Services.SocketsDataDistribution.SocketsServerClient sender)
		{
			MessageBox.Show("Connection with Server Lost");
		}
		
		private void _stxEventLog_LogEntryReceived(CustomEventLogEntry LogEntryInfo)
		{
			try
			{
				
				if (UIControlsSafeAccessFunctions.ListBox_Items_Count(this.lstSTXEventLog) > 250)
				{
					ListBox_Items_Clear(this.lstSTXEventLog);
				}
				string item = LogEntryInfo.ToString(CustomEventLogEntry.toStringMode.singleLine);
				ListBox_Items_Add(this.lstSTXEventLog, item);
				
				this._dataErrorsCount++;
				this.SetTextBoxText(this.txtErrorsCount, System.Convert.ToString(this._dataErrorsCount));
			}
			catch (Exception ex)
			{
				ListBox_Items_Add(this.lstSTXEventLog, ex.Message);
			}
		}
		
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmSocketsServerClientTest_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._dataCount = 0;
				this._dataErrorsCount = 0;
			}
			catch (Exception)
			{
			}
		}
		
		private void DataSocketClientApplication_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._dataSocketClient.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		
		public void Button5_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._dataSocketClient.DisconnectFromServer();
				this.btnDisconnect.Enabled = false;
				this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			}
			catch (Exception)
			{
			}
		}
		
		public void chkStringAutoIntegerDataSend_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				if (this.chkStringAutoIntegerDataSend.Checked)
				{
					if (this.CfDataManagerContainer1.DataCount <= 0)
					{
						this.chkStringAutoIntegerDataSend.Checked = false;
						throw (new Exception("No data to send"));
					}
					this.tmrAutoDataSend.Interval = (int) this.nudIntegerAutoSendRate.Value;
					this.tmrAutoDataSend.Start();
					this.chkStringAutoIntegerDataSend.Text = "Stop Auto Send";
				}
				else
				{
					this.tmrAutoDataSend.Stop();
					this.chkStringAutoIntegerDataSend.Text = "Start Auto Send";
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void tmrInteger_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				IEnumerator enumm = default(IEnumerator);
				enumm = this.CfDataManagerContainer1.GetEnumerator();
			    SocketData sockdat = default(SocketData);
              	while (enumm.MoveNext())
				{
                    sockdat = (SocketData)enumm.Current;
					this._dataSocketClient.SendDataToServer(sockdat);
					this._dataSendCount++;
					this.SetTextBoxText(this.txtDataSendedCounter, System.Convert.ToString(this._dataSendCount));
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void Button5_Click_1(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstServerData.Items.Clear();
				this.lstReceptionLog.Items.Clear();
				this.CfDataDisplayCtrl1.ClearData();
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
				this._dataCount = 0;
				this.txtDataReceivedCount.Text = "";
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button7_Click(System.Object sender, System.EventArgs e)
		{
			this.txtDataSendedCounter.Text = "";
			this._dataSendCount = 0;
		}
		
		
		public void lstServerData_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstServerData.SelectedIndex >= 0)
				{
					SocketData dat = (SocketData) this.lstServerData.SelectedItem;
					this.CfDataDisplayCtrl1.ShowData(dat.Value);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		
		public void btnSendData_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CfDataManagerContainer1.DataCount <= 0)
				{
					throw (new Exception("No data to select"));
				}
				SocketData dat = this.CfDataManagerContainer1.SelectedData;
				this._dataSocketClient.SendDataToServer(dat);
				this._dataSendCount++;
				this.SetTextBoxText(this.txtDataSendedCounter, System.Convert.ToString(this._dataSendCount));
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
			catch (Exception)
			{
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstSTXEventLog.Items.Clear();
				this.Button2_Click(sender, e);
			}
			catch (Exception)
			{
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._dataErrorsCount = 0;
				this.txtErrorsCount.Text = System.Convert.ToString(this._dataErrorsCount);
			}
			catch (Exception)
			{
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._dataSocketClient.Connect();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion
		
		
		
		
		
	}
}
