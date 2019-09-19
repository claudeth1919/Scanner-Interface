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
			
			
namespace SDHClientTestApp
{
	public partial class frmDSH_ClientTestAppMainForm
	{
		public frmDSH_ClientTestAppMainForm()
		{
		    InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmDSH_ClientTestAppMainForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmDSH_ClientTestAppMainForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmDSH_ClientTestAppMainForm();
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
		
#region  < DATAMEMBERS >


        private DiscoverableServiceDefinitionHandlingClient _STXServiceClient;
		
#endregion
		
		public void frmSTXServiceHandlerClient_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			try
			{
				this._STXServiceClient.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void Form1_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
                string clientName = Interaction.InputBox("Define a Client Name for the Discoverable Service Emulation Client", "", "", -1, -1);
				if (!(clientName == null))
				{
                    this._STXServiceClient = new DiscoverableServiceDefinitionHandlingClient(clientName.ToUpper());
					this.txtClientName.Text = System.Convert.ToString(this._STXServiceClient.Name);
				}
				else
				{
					this.Dispose();
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void btnSearchService_Click(System.Object sender, System.EventArgs e)
		{
			this.btnClear_Click(sender, e);
			try
			{
				this.Cursor = Cursors.WaitCursor;
				
				if (this.txtServiceNameToLookfor.Text.Length > 0)
				{
                    DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition serviceDefinition = default(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition);
					serviceDefinition = this._STXServiceClient.FindService(this.txtServiceNameToLookfor.Text);
					this.lstSErverParameters.Items.Clear();
					IEnumerator enumm = serviceDefinition.ServiceParameters.GetEnumerator();
					DiscoverableServiceParameter param = default(DiscoverableServiceParameter);
					while (enumm.MoveNext())
					{
						param = (DiscoverableServiceParameter)enumm.Current;
						this.lstSErverParameters.Items.Add(param);
					}
					this.txtServiceName.Text = System.Convert.ToString(serviceDefinition.ServiceName);
					this.txtOperationMode.Text = System.Convert.ToString(serviceDefinition.ServiceOperationMode.ToString());
				}
				else
				{
					MessageBox.Show("No service Name specified");
				}
				
			}
			catch (DiscoverableServiceDefinitionHandlingSearchFailureException exx)
			{
				MessageBox.Show(System.Convert.ToString(exx.Message));
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
		
		public void btnClear_Click(System.Object sender, System.EventArgs e)
		{
			this.txtServiceName.Text = "";
			this.txtOperationMode.Text = "";
			this.lstSErverParameters.Items.Clear();
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.btnClear_Click(sender, e);
			try
			{
				this.Cursor = Cursors.WaitCursor;
				
				if (this.txtServiceNameToLookfor.Text.Length > 0)
				{
					DiscoverableServiceDefinitionsContainer serviceDefinitionContainer = default(DiscoverableServiceDefinitionsContainer);
					serviceDefinitionContainer = this._STXServiceClient.DiscoverServicesNumOfInstances(this.txtServiceNameToLookfor.Text, 2);
					this.lstSErverParameters.Items.Clear();
                    DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition def = default(DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition);
					IEnumerator enumm = serviceDefinitionContainer.GetEnumerator();
					while (enumm.MoveNext())
					{
                        def = (DiscoverableServiceHandlingOperativeDefs.DiscoverableServiceDefinition)enumm.Current;
						this.lstSErverParameters.Items.Add(def.ServiceName);
					}
					
					
				}
				else
				{
					MessageBox.Show("No service Name specified");
				}
				
			}
			catch (DiscoverableServiceDefinitionHandlingSearchFailureException exx)
			{
				MessageBox.Show(System.Convert.ToString(exx.Message));
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
