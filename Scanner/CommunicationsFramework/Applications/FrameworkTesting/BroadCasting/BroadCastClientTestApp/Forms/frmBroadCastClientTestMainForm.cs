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
using CommunicationsLibrary.Services.BroadCasting;
using CommunicationsLibrary.Services.BroadCasting.Data;
using CommunicationsUISupportLibrary;
//using CommunicationsLibrary.Services.STXServiceDefinitionHandling.Definitions.STXServiceOperativeDefinitions;


namespace BroadCastClientTestApp
	{
		public partial class frmBroadCastClientTestMainForm
		{
			public frmBroadCastClientTestMainForm()
			{
				InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmBroadCastClientTestMainForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmBroadCastClientTestMainForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmBroadCastClientTestMainForm();
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
		
		private DataBroadcastClient _client;
		
		private const string BROAD_CAST_IP_ADDRESS = "224.5.6.7";
		private const int BROAD_CAST_PORT = 4000;
		
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			
			if (this.txtBroadCastIDName.Text.Length > 0)
			{
				
				Data data = this.CfDataManagerContainer1.SelectedData;
				if (!(data == null))
				{
					this._client.BroadCastData(this.txtBroadCastIDName.Text, data.DataName, System.Convert.ToString(data.data));
				}
				else
				{
					MessageBox.Show("No data available to send");
				}
			}
			else
			{
				MessageBox.Show("No ID specified for the broad cast operation");
			}
		}
		
		public void BroadCastCliientTest_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._client.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void BroadCastCliientTest_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				string ClientName = Interaction.InputBox("Set a broadcast client name", "", "", -1, -1);
				if (ClientName.Length > 0)
				{
					_client = new DataBroadcastClient(ClientName.ToUpper(), BROAD_CAST_IP_ADDRESS, BROAD_CAST_PORT);
				}
				else
				{
					this.Close();
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
				this.Cursor = Cursors.WaitCursor;
				this.txtREsult.Text = "";
				this.txtReceivedReplies.Text = "";
				this.txtDataREpliedAsXML.Text = "";
				this.lstDataReplied.Items.Clear();
				
				if (this.txtBroadCastIDName.Text.Length <= 0)
				{
					throw (new Exception("No broad cast id specified"));
				}
				
				Data data = default(Data);
				data = this.CfDataManagerContainer1.SelectedData;
				if (data == null)
				{
					throw (new Exception("No available data to bro"));
				}
				
				BroadCastRepliesContainer broadCastRepliesReceived = default(BroadCastRepliesContainer);
				int timeout = (int) this.nudTimeOut.Value;
				broadCastRepliesReceived = this._client.BroadCastDataAndWaitSeveralRepliesWithinTimeIntervall(this.txtBroadCastIDName.Text, data.DataName, System.Convert.ToString(data.data), timeout);
				//print the replies received
				if (broadCastRepliesReceived.Count > 0)
				{
					BroadCastReply reply = default(BroadCastReply);
					IEnumerator enumm = broadCastRepliesReceived.GetEnumerator();
					while (enumm.MoveNext())
					{
						reply = (CommunicationsLibrary.Services.BroadCasting.Data.BroadCastReply) enumm.Current;
						this.lstDataReplied.Items.Add(reply);
					}
				}
				this.txtReceivedReplies.Text = System.Convert.ToString(broadCastRepliesReceived.Count);
				if (chkCheckReplyIDName.Checked && this.txtReplyIDName.Text.Length > 0)
				{
					if (broadCastRepliesReceived.ContainsReplyIDName(this.txtReplyIDName.Text))
					{
						this.txtREsult.Text = "It contains the Reply";
					}
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
		
		
		public void lstDataReplied_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstDataReplied.SelectedIndex >= 0)
				{
					BroadCastReply reply = (BroadCastReply) this.lstDataReplied.SelectedItem;
					this.CfDataDisplayCtrl1.ShowData(reply.Value);
					this.txtDataREpliedAsXML.Text = reply.XMLDataString;
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
				this.txtDataREpliedAsXML.Text = "";
			}
			catch (Exception)
			{
			}
		}
		
		
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.txtREsult.Text = "";
				this.txtReceivedReplies.Text = "";
				this.txtDataREpliedAsXML.Text = "";
				this.lstDataReplied.Items.Clear();
				
				if (this.txtBroadCastIDName.Text.Length <= 0)
				{
					throw (new Exception("No broad cast id specified"));
				}
				
				Data data = default(Data);
				data = this.CfDataManagerContainer1.SelectedData;
				if (data == null)
				{
					throw (new Exception("No available data to bro"));
				}
				
				BroadCastRepliesContainer broadCastRepliesReceived = default(BroadCastRepliesContainer);
				broadCastRepliesReceived = this._client.BroadCastDataAndWaitOneFirstReply(this.txtBroadCastIDName.Text, data.DataName, System.Convert.ToString(data.data));
				//print the replies received
				if (broadCastRepliesReceived.Count > 0)
				{
					BroadCastReply reply = default(BroadCastReply);
					IEnumerator enumm = broadCastRepliesReceived.GetEnumerator();
					while (enumm.MoveNext())
					{
						reply = (CommunicationsLibrary.Services.BroadCasting.Data.BroadCastReply) enumm.Current;
						this.lstDataReplied.Items.Add(reply);
					}
				}
				this.txtReceivedReplies.Text = System.Convert.ToString(broadCastRepliesReceived.Count);
				if (chkCheckReplyIDName.Checked && this.txtReplyIDName.Text.Length > 0)
				{
					if (broadCastRepliesReceived.ContainsReplyIDName(this.txtReplyIDName.Text))
					{
						this.txtREsult.Text = "It contains the Reply";
					}
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}
	}
}
