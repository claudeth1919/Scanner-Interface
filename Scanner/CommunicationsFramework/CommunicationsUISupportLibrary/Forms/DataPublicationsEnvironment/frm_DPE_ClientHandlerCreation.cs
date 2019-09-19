using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;

using System.Windows.Forms;

namespace CommunicationsUISupportLibrary
{
	public partial class frm_DPE_ClientHandlerCreation
	{
		public frm_DPE_ClientHandlerCreation()
		{
			InitializeComponent();
		}
		
		
		
#region  <  properties >
		
public string NewClientHandlerName
		{
			get
			{
				return this.STXDataSocketClientName.Text;
			}
		}
		
public bool KeepDataStatisticsTracking
		{
			get
			{
				return this.chkKeepDataStatistics.Checked;
			}
		}
		
#endregion
		
		public void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.STXDataSocketClientName.Text.Length <= 0)
				{
					throw (new Exception("No Data specified "));
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
