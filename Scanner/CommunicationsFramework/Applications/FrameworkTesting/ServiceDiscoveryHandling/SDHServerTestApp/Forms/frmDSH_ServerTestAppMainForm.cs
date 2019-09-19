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
using CommunicationsLibrary.Services.DiscoverableServiceHandling;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Definitions;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;
			
			
			namespace STXServiceHandlerServerTestApplication
			{
				public partial class frmDSH_ServerTestAppMainForm
				{
					public frmDSH_ServerTestAppMainForm()
					{
						InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmDSH_ServerTestAppMainForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmDSH_ServerTestAppMainForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDSH_ServerTestAppMainForm();
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
		
		private DiscoverableServiceDefinitionHandlingServer _STXServiceHandler;
		private DiscoverableServiceDefinitionParametersContainer _STXServicePArametersCont;
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private void LoadSErviceParameters()
		{
			this.lstServiceParameters.Items.Clear();
			IEnumerator enumm = this._STXServicePArametersCont.GetEnumerator();
			DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
			
			while (enumm.MoveNext())
			{
				param = (DiscoverableServiceParameter)enumm.Current;
				this.lstServiceParameters.Items.Add(param);
			}
		}
		
#endregion
		
#region  < CONTROL SAFE ACCESS >
		
	        delegate void SetListBoxItemCallBack(System.Windows.Forms.ListBox listBox, object item);
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

        delegate void RemoveItemFromListBoxCallBack(System.Windows.Forms.ListBox listBox, object item);
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

        delegate void SetTextBoxTextCallBack(TextBox listbox, string text);
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
		
#region  < EVENTHANDLING >
		
		private void QueryReceived(string ServiceName, string ClientName, string ClientHost)
		{
			try
			{
				this.SetTextBoxText(this.txtCountQueriesCount, System.Convert.ToString(this._STXServiceHandler.ClientQueriesReceivedCount));
				string str = "[SERVICE WANTED= " + ServiceName + "] [CLIENT NAME=" + ClientName + "] [CLIENT HOST=" + ClientHost + "]";
				this.SetListBoxItem(this.lstReceivedQueries, str);
			}
			catch (Exception)
			{
			}
		}
		
		private void SuccessFullQuerieREsult(string ServiceName, string ClientName, string ClientHost)
		{
			try
			{
				this.SetTextBoxText(this.txtSuccesfullQueriesCount, System.Convert.ToString(this._STXServiceHandler.SuccessfullClientQueriesCount));
				string str = "[SERVICE WANTED= " + ServiceName + "] [CLIENT NAME=" + ClientName + "] [CLIENT HOST=" + ClientHost + "]";
				this.SetListBoxItem(this.lstSuccesfullQueries, str);
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBACKS  >
		
		public void btnAddParameter_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				frmNewParameter newparam = new frmNewParameter();
				if (newparam.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this._STXServicePArametersCont.AddParameter(newparam.txtParamName.Text, newparam.txtParamValue.Text);
					this.LoadSErviceParameters();
				}
				newparam.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void frmSTXServiceTestApplication_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				if (!(this._STXServiceHandler == null))
				{
					this._STXServiceHandler.Dispose();
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void frmSTXServiceTestApplication_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._STXServicePArametersCont = new DiscoverableServiceDefinitionParametersContainer();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void chkEmulate_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			
			if (this.chkEmulate.Checked)
			{
				
				if (this._STXServicePArametersCont.Count <= 0)
				{
					MessageBox.Show("No service parameters defined");
					this.chkEmulate.Checked = false;
					return;
				}
				
				if (this.txtSErviceName.Text.Length <= 0)
				{
					MessageBox.Show("No service name defined");
					this.chkEmulate.Checked = false;
					return;
				}
				
				if (this.chkEmulate.Checked)
				{
					this.chkEmulate.Text = "Stop" + Constants.vbNewLine + "Emulation";
					if (this.rbtnNormalMode.Checked)
					{
                        this._STXServiceHandler = new DiscoverableServiceDefinitionHandlingServer(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode.multipleNetworkInstancesService, this.txtSErviceName.Text, this._STXServicePArametersCont);
						this._STXServiceHandler.STXServiceQueryReceived += new DiscoverableServiceDefinitionHandlingServer.STXServiceQueryReceivedEventHandler(this.QueryReceived);
						this._STXServiceHandler.STXServiceSuccesfullQueryResult += new  DiscoverableServiceDefinitionHandlingServer.STXServiceSuccesfullQueryResultEventHandler(this.SuccessFullQuerieREsult);
					}
					else
					{
                        this._STXServiceHandler = new DiscoverableServiceDefinitionHandlingServer(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceMode.singletonInstanceNetworkService, this.txtSErviceName.Text, this._STXServicePArametersCont);
						this._STXServiceHandler.STXServiceQueryReceived += new DiscoverableServiceDefinitionHandlingServer.STXServiceQueryReceivedEventHandler (this.QueryReceived);
						this._STXServiceHandler.STXServiceSuccesfullQueryResult += new  DiscoverableServiceDefinitionHandlingServer.STXServiceSuccesfullQueryResultEventHandler(this.SuccessFullQuerieREsult);
					}
				}
				else
				{
					this.chkEmulate.Text = "Emulate STX Service";
					if (!(this._STXServiceHandler == null))
					{
						this._STXServiceHandler.Dispose();
					}
				}
			}
			else
			{
				this.chkEmulate.Text = "Emulate " + Constants.vbNewLine + "STX Service";
				if (!(this._STXServiceHandler == null))
				{
					this._STXServiceHandler.Dispose();
				}
			}
			
		}
		
#endregion
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstReceivedQueries.Items.Clear();
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.lstSuccesfullQueries.Items.Clear();
			}
			catch (Exception)
			{
				
			}
		}
	}
	
}
