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
using System.Net;
using CommunicationsLibrary.Services.P2PCommunicationsScheme;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;
using CommunicationsUISupportLibrary;


namespace P2PPortClientTestApp
{
	public partial class frmP2PPortClientMainform
	{
		
#region  < DATA MEMBERS >
		
		private P2PPortClient _p2pPortclient;
		
		private Hashtable _dataAttributesTable = new Hashtable();
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public frmP2PPortClientMainform(string hostName, int port)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
            IPAddress addr;
            bool parsed = false;

            parsed = IPAddress.TryParse(hostName, out addr);
            if (parsed)
                this._p2pPortclient = new P2PPortClient(hostName , addr.ToString(), port);
            else
                this._p2pPortclient = new P2PPortClient(hostName, port);
			
			this._p2pPortclient.ConnectionLost += this.connectionLost;
			this._p2pPortclient.Connect();
			this.Text = this.Text + " -> Connected to  [" + hostName + ":" + System.Convert.ToString(port) + "]";
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private void ShowDataAttributes()
		{
			try
			{
				this.lstDataAttr.Items.Clear();
				
				Data dat = this.CfDataManagerContainer1.SelectedData;
				if (!(dat == null))
				{
					if (this._dataAttributesTable.ContainsKey(dat.DataName))
					{
						Hashtable table = (Hashtable) (this._dataAttributesTable[dat.DataName]);
						IEnumerator enumm = table.GetEnumerator();
						string str = "";
						string attrName = "";
						string attrValue = "";
						while (enumm.MoveNext())
						{
							attrName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
							attrValue = System.Convert.ToString(((DictionaryEntry) enumm.Current).Value);
							str = attrName + "," + attrValue;
							this.lstDataAttr.Items.Add(str);
						}
					}
				}
				
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		
		private P2PData GetP2PDataToSend()
		{
			
			if (this.CfDataManagerContainer1.DataCount > 0)
			{
				Data dat = this.CfDataManagerContainer1.SelectedData;
				P2PData p2pDat = default(P2PData);
				if (!(dat == null))
				{
					p2pDat = P2PData.GetP2PDataObject(dat.DataName, dat.data);
                    if (!(p2pDat == null))
                    {
                        this.AssingDataAttributesToP2PData(p2pDat);
                        return p2pDat;
                    }
                    else
                    {
                        throw new Exception("No valid p2p data to return");
                    }
				}
				else
				{
					throw (new Exception("No selected data to send"));
				}
			}
			else
			{
				throw (new Exception("No data available to send"));
			}
		}
		
		private P2PData GetP2PDataToSend(Data dat)
		{
			P2PData p2pDat = default(P2PData);
            string dataType = dat.data.GetType().ToString();
            switch (dataType)
			{
				case "System.String":
					p2pDat = new P2PData(dat.DataName, System.Convert.ToString(dat.data));
					break;
				case "System.Int32":
					p2pDat = new P2PData(dat.DataName, System.Convert.ToInt32(dat.data));
					break;
				case "System.Boolean":
					p2pDat = new P2PData(dat.DataName, System.Convert.ToBoolean(dat.data));
					break;
				case "System.Decimal":
					p2pDat = new P2PData(dat.DataName, System.Convert.ToDecimal(dat.data));
					break;
				case "System.Data.DataTable":
					p2pDat = new P2PData(dat.DataName, (DataTable) dat.data);
					break;
				case "UtilitiesLibrary.Data.CustomHashTable":
					p2pDat = new P2PData(dat.DataName, (CustomHashTable) dat.data);
					break;
				case "UtilitiesLibrary.Data.CustomList":
					p2pDat = new P2PData(dat.DataName, (CustomList) dat.data);
					break;
				case "UtilitiesLibrary.Data.CustomSortedList":
					p2pDat = new P2PData(dat.DataName, (CustomSortedList) dat.data);
					break;
			}
			return p2pDat;
		}
		
		private void AssingDataAttributesToP2PData(P2PData data)
		{
			if (this._dataAttributesTable.ContainsKey(data.DataName))
			{
				//the data has attributes
				Hashtable attrTable = (Hashtable) (this._dataAttributesTable[data.DataName]);
				IEnumerator enumm = attrTable.GetEnumerator();
				string attrName = "";
				string attrValue = "";
				while (enumm.MoveNext())
				{
					attrName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
					attrValue = System.Convert.ToString(((DictionaryEntry) enumm.Current).Value);
					data.DataAttributesTable.AddAttribute(attrName, attrValue);
				}
			}
		}
		
#endregion
		
#region  < EVENT HANDLING >
		
		private void connectionLost(CommunicationsLibrary.Services.P2PCommunicationsScheme.P2PPortClient client)
		{
			MessageBox.Show("Connection with remote port lost");
		}
		
		public void SelectionDataChange(Data data)
		{
			try
			{
				this.ShowDataAttributes();
			}
			catch (Exception)
			{
				
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void btnSendData_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				P2PData dat = this.GetP2PDataToSend();
				this._p2pPortclient.SendData(P2PDataSendMode.SyncrhonicalSend, dat);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.dgrdGeneralStatistics.DataSource = this._p2pPortclient.Statistics.GeneralStatisticsTable;
				this.dgrdSendStats.DataSource = this._p2pPortclient.Statistics.DataSendingStatisticsTable;
			}
		}
		
		public void frmP2PSocketPortClientTestApplicationForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._p2pPortclient.Dispose();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnRequestData_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (this.txtDataNameToRequest.Text.Length <= 0)
				{
					throw (new Exception("No data name to request"));
				}
				P2PData data = default(P2PData);
				P2PDataRequest request = new P2PDataRequest(this.txtDataNameToRequest.Text);
				data = this._p2pPortclient.RetrieveData(request);
				this.CfDataDisplayCtrl1.ShowData(data.Value);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				this.Cursor = Cursors.Default;
				this.dgrdGeneralStatistics.DataSource = this._p2pPortclient.Statistics.GeneralStatisticsTable;
				this.dgrdRequestStats.DataSource = this._p2pPortclient.Statistics.DataRequestsStatisticsTable;
			}
		}
		
		
		
		public void btnAddAttr_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CfDataManagerContainer1.DataCount > 0)
				{
					Data dat = default(Data);
					dat = this.CfDataManagerContainer1.SelectedData;
					if (!(dat == null))
					{
						Hashtable attrTable = default(Hashtable);
						if (!this._dataAttributesTable.ContainsKey(dat.DataName))
						{
							attrTable = new Hashtable();
							string attrName = "";
							string attrValue = "";
							attrName = Interaction.InputBox("Enter an attribute NAME", "", "", -1, -1);
							if (attrName.Length > 0)
							{
								attrValue = Interaction.InputBox("Enter a attribute VALUE", "", "", -1, -1);
								if (attrValue.Length > 0)
								{
									attrName = attrName.ToUpper();
									attrTable.Add(attrName, attrValue);
									this._dataAttributesTable.Add(dat.DataName, attrTable);
									this.ShowDataAttributes();
								}
							}
						}
						else
						{
							attrTable = (Hashtable) (this._dataAttributesTable[dat.DataName]);
							string attrName = "";
							string attrValue = "";
							attrName = Interaction.InputBox("Enter an attribute NAME", "", "", -1, -1);
							if (attrName.Length > 0)
							{
								attrName = attrName.ToUpper();
								if (attrTable.ContainsKey(attrName))
								{
									throw (new Exception("The attribute already exists"));
								}
								attrValue = Interaction.InputBox("Enter an attribute VALUE", "", "", -1, -1);
								if (attrValue.Length > 0)
								{
									attrTable.Add(attrName, attrValue);
									this.ShowDataAttributes();
								}
							}
						}
					}
					else
					{
						throw (new Exception("No data selected"));
					}
				}
				else
				{
					throw (new Exception("No available data"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		
		public void btnRemoveDataAttr_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.CfDataManagerContainer1.SelectedData == null)
				{
					throw (new Exception("No selected Data"));
				}
				
				if (this.lstDataAttr.Items.Count > 0)
				{
					if (this.lstDataAttr.SelectedIndex >= 0)
					{
						string attr = System.Convert.ToString(this.lstDataAttr.SelectedItem);
						int indexOf = attr.IndexOf(",");
						string attrName = attr.Substring(0, indexOf);
						Data dat = this.CfDataManagerContainer1.SelectedData;
						
						if (this._dataAttributesTable.ContainsKey(dat.DataName))
						{
							Hashtable attrTable = (Hashtable) (this._dataAttributesTable[dat.DataName]);
							attrTable.Remove(attrName);
							this.lstDataAttr.Items.Remove(this.lstDataAttr.SelectedItem);
							this.ShowDataAttributes();
							if (attrTable.Count <= 0)
							{
								this._dataAttributesTable.Remove(dat.DataName);
							}
						}
					}
					else
					{
						throw (new Exception("No data attribute selected to remove"));
					}
				}
				else
				{
					throw (new Exception("No data attributes to remove"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._p2pPortclient.Dispose();
				this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
			}
			catch (Exception)
			{
			}
		}
		
		public void btnSEndToAutoList_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				Data dat = default(Data);
				dat = this.CfDataManagerContainer1.SelectedData;
				if (!(dat == null))
				{
					this.lstAutoSend.Items.Add(dat);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAutoSend.SelectedIndex >= 0)
				{
					this.lstAutoSend.Items.Remove(this.lstAutoSend.SelectedItem);
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		
		public void chkAutoSEnd_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkAutoSEnd.Checked)
				{
					if (this.lstAutoSend.Items.Count > 0)
					{
						this.chkAutoSEnd.Text = "STOP " + Constants.vbNewLine + "Automatic" + Constants.vbNewLine + "Data Send";
						this.tmrAutoSend.Interval = (int) this.nudSendRate.Value;
						this.tmrAutoSend.Start();
						this.btnRemoveAutoSendElement.Enabled = false;
					}
					else
					{
						this.tmrAutoSend.Stop();
						this.chkAutoSEnd.Checked = false;
					}
				}
				else
				{
					this.tmrAutoSend.Stop();
					this.btnRemoveAutoSendElement.Enabled = true;
					this.chkAutoSEnd.Text = "START " + Constants.vbNewLine + "Automatic" + Constants.vbNewLine + "Data Send";
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void tmrAutoSend_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				IEnumerator enumm = this.lstAutoSend.Items.GetEnumerator();
				Data dat = default(Data);
				P2PData p2pdat = default(P2PData);
				while (enumm.MoveNext())
				{
					dat = (CommunicationsUISupportLibrary.Data) enumm.Current;
					p2pdat = GetP2PDataToSend(dat);
					AssingDataAttributesToP2PData(p2pdat);
					try
					{
						this._p2pPortclient.SendData(P2PDataSendMode.SyncrhonicalSend, p2pdat);
					}
					catch (Exception ex)
					{
						this.lstErrorsOnAutoSEnd.Items.Add(ex.Message);
					}
				}
				this.dgrdGeneralStatistics.DataSource = this._p2pPortclient.Statistics.GeneralStatisticsTable;
				this.dgrdSendStats.DataSource = this._p2pPortclient.Statistics.DataSendingStatisticsTable;
			}
			catch (Exception ex)
			{
				this.lstErrorsOnAutoSEnd.Items.Add(ex.Message);
			}
		}
		
		public void btnUpdateStatistics_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.dgrdGeneralStatistics.DataSource = this._p2pPortclient.Statistics.GeneralStatisticsTable;
				this.dgrdSendStats.DataSource = this._p2pPortclient.Statistics.DataSendingStatisticsTable;
				this.dgrdRequestStats.DataSource = this._p2pPortclient.Statistics.DataRequestsStatisticsTable;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		public void chkAutomaticREquest_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.chkAutomaticREquest.Checked)
				{
					if (this.txtDataNameToRequest.Text.Length <= 0)
					{
						this.chkAutomaticREquest.Checked = false;
						this.tmrAutoRequest.Stop();
						throw (new Exception("No data name to request"));
					}
					else
					{
						this.chkAutomaticREquest.Text = "STOP " + Constants.vbNewLine + "Automatic" + Constants.vbNewLine + "Data Request";
						this.txtDataNameToRequest.Enabled = false;
						this.tmrAutoRequest.Interval = (int) this.nudRequestRate.Value;
						this.tmrAutoRequest.Start();
					}
				}
				else
				{
					this.chkAutomaticREquest.Text = "START " + Constants.vbNewLine + "Automatic" + Constants.vbNewLine + "Data Request";
					this.txtDataNameToRequest.Enabled = true;
					this.tmrAutoRequest.Stop();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button2_Click_1(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstErrorsOnAutoSEnd.Items.Clear();
			}
			catch (Exception)
			{
			}
		}
		
		
		public void tmrAutoRequest_Tick(System.Object sender, System.EventArgs e)
		{
			try
			{
				P2PData data = default(P2PData);
				P2PDataRequest request = new P2PDataRequest(this.txtDataNameToRequest.Text);
				data = this._p2pPortclient.RetrieveData(request);
				this.CfDataDisplayCtrl1.ShowData(data.Value);
			}
			catch (Exception ex)
			{
				this.lstErrorsOnAutoRequest.Items.Add(ex.Message);
			}
			finally
			{
				this.dgrdGeneralStatistics.DataSource = this._p2pPortclient.Statistics.GeneralStatisticsTable;
				this.dgrdRequestStats.DataSource = this._p2pPortclient.Statistics.DataRequestsStatisticsTable;
			}
		}
		
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			this.lstErrorsOnAutoRequest.Items.Clear();
		}
		
#endregion
		
		
		
	}
	
}
