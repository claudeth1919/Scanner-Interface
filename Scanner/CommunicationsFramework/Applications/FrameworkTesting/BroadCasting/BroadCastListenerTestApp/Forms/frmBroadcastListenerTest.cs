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
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsLibrary.Services.BroadCasting.Handling;
using CommunicationsUISupportLibrary;



namespace BroadCastListenerTestApp
{
	public partial class frmBroadcastListenerTest
	{
		public frmBroadcastListenerTest()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmBroadcastListenerTest defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmBroadcastListenerTest Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmBroadcastListenerTest();
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
		
		private DataBroadcastListener _broadCastDataReceiver;
		private const string BROAD_CAST_IP_ADDRESS = "224.5.6.7";
		private const int BROAD_CAST_PORT = 4000;
		
		
		
#region  < CONTROL SAFE ACCESS >
		
		delegate void SetListBoxItemCallBack(System.Windows.Forms.ListBox  listBox, object item);
		delegate void RemoveItemFromListBoxCallBack(System.Windows.Forms.ListBox listbox, object item);
		delegate void SetTextBoxTextCallBack(System.Windows.Forms.TextBox textbox, string text);
		delegate int  getTabIndex(TabControl tapControl);
		delegate void SetCFDisplayCtrlData(CFDataDisplayCtrl ctrl, object data);
		delegate Data  GetSelectedData(CFDataManagerContainer ctrl);
		
		
		
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
		
		private int GetTabSelectedIndex(TabControl tabControl)
		{
			if (tabControl.InvokeRequired)
			{
				getTabIndex d = new getTabIndex(GetTabSelectedIndex);
				this.Invoke(d, new object[] {tabControl});
                int INDEX = tabControl.SelectedIndex;
                return INDEX;
			}
			else
			{
				int INDEX = tabControl.SelectedIndex;
				return INDEX;
			}
		}
		
		private void SetCFDataDisplayControlShowData(CFDataDisplayCtrl ctrl, object data)
		{
			if (ctrl.InvokeRequired)
			{
				SetCFDisplayCtrlData d = new SetCFDisplayCtrlData(SetCFDataDisplayControlShowData);
				this.Invoke(d, new object[] {ctrl, data});
			}
			else
			{
				ctrl.ShowData(data);
			}
		}
		
		private Data GetAvailableSelectedData(CFDataManagerContainer ctrl)
		{
			if (ctrl.InvokeRequired)
			{
				GetSelectedData d = new GetSelectedData(GetAvailableSelectedData);
				return (Data)this.Invoke(d, new object[] {ctrl});
			}
			else
			{
				return ctrl.SelectedData;
			}
		}
		
#endregion
		
#region  < PRIVATE METHODS  >
		
		private void SendBroadCastReply(DataBroadCastHandler handler)
		{
			if (this.chkReplyToBroadcaster.Checked)
			{
				switch (handler.BroadcastingMode)
				{
					case DataBroadCastHandler.BroadCastMode.BroadCasterIsNotWaitingReply:
						break;
					case DataBroadCastHandler.BroadCastMode.BroadCasterIsWaitingReply:
						if (this.CfDataManagerContainer1.DataCount > 0)
						{
							Data dat = this.GetAvailableSelectedData(this.CfDataManagerContainer1);
                            if (dat != null)
                            {
                                BroadCastReply reply = default(BroadCastReply);
                                string dataType = dat.data.GetType().ToString();
                                switch (dataType)
                                {
                                    case "System.String":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, System.Convert.ToString(dat.data));
                                        break;
                                    case "System.Int32":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, System.Convert.ToInt32(dat.data));
                                        break;
                                    case "System.Decimal":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, System.Convert.ToDecimal(dat.data));
                                        break;
                                    case "System.Boolean":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, System.Convert.ToBoolean(dat.data));
                                        break;
                                    case "System.Data.DataTable":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, (DataTable)dat.data);
                                        break;
                                    case "UtilitiesLibrary.Data.CustomHashTable":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, (CustomHashTable)dat.data);
                                        break;
                                    case "UtilitiesLibrary.Data.CustomList":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, (CustomList)dat.data);
                                        break;
                                    case "UtilitiesLibrary.Data.CustomSortedList":
                                        reply = new BroadCastReply(this.txtReplayNameID.Text, dat.DataName, (CustomSortedList)dat.data);
                                        break;
                                }
                                handler.SendReplyToBroadcaster(reply);
                            }
                            else
                            {
                                throw new Exception("No data selected from Data List");
                            }

						}
						break;
					default:
						break;
				}
			}
		}
		
#endregion
		
#region  <  EVENT HANDLING >
		
		private void DataReceived(DataBroadCastHandler handler)
		{
			try
			{
				this.SetCFDataDisplayControlShowData(this.CfDataDisplayCtrl1, handler.BroadCastedData.Value);
				this.SetTextBoxText(this.txtBroadcastedDataReceivedAsXML, handler.BroadCastedData.XMLDataString);
				
				string broadCasterinfo = "NAME = " + handler.BroadCastedData.BroadCasterInformation.BroadcasterName + Constants.vbNewLine + "HOST = " + handler.BroadCastedData.BroadCasterInformation.Host + Constants.vbNewLine + "REPLY PORT = " + System.Convert.ToString(handler.BroadCastedData.BroadCasterInformation.ReplyListeningPort);
				this.SetTextBoxText(this.txtBroadcasterInfo, broadCasterinfo);
				this.SendBroadCastReply(handler);
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void broadCastTestForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._broadCastDataReceiver.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void broadCastTestForm_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				_broadCastDataReceiver = new DataBroadcastListener(BROAD_CAST_IP_ADDRESS, BROAD_CAST_PORT);
				_broadCastDataReceiver.DataReceived += DataReceived;
			}
			catch (Exception)
			{
				
			}
		}
		
		public void chkReplyToBroadcaster_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkReplyToBroadcaster.Checked)
				{
					if (this.CfDataManagerContainer1.DataCount <= 0)
					{
						this.chkReplyToBroadcaster.Checked = false;
						throw (new Exception("No data available to reply"));
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void CfDataDisplayCtrl1_DataCleared()
		{
			try
			{
				this.txtBroadcastedDataReceivedAsXML.Text = "";
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
	}
}
