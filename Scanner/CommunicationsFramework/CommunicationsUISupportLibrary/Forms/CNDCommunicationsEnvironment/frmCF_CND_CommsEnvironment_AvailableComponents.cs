using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using CommunicationsLibrary.CNDCommunicationsEnvironment;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;


namespace CommunicationsUISupportLibrary
{
	public partial class frmCF_CND_CommsEnvironment_AvailableComponents
	{
		public frmCF_CND_CommsEnvironment_AvailableComponents()
		{
			InitializeComponent();
		}
		
public string SelectedComponentName
		{
			get
			{
				return System.Convert.ToString(this.lstBoxAvailableComponents.SelectedItem);
			}
		}
		
		public void frmAvailableComponents_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				CommunicationsManager comsMan = CommunicationsManager.GetInstance();
				DataTable dt = comsMan.CNDTable;
				DataRow row = default(DataRow);
				IEnumerator enumm = dt.Rows.GetEnumerator();
				string componentName = "";
				while (enumm.MoveNext())
				{
					row = (DataRow)enumm.Current;
                    componentName = System.Convert.ToString(row[CNDServiceDefinitions.CND_TABLE_COMPONENT_NAME]);
					this.lstBoxAvailableComponents.Items.Add(componentName);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstBoxAvailableComponents.Items.Count <= 0)
				{
					throw (new Exception("No available components to select from list"));
				}
				
				if (this.lstBoxAvailableComponents.SelectedIndex < 0)
				{
					throw (new Exception("No component selected from list"));
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
			
		}
	}
}
