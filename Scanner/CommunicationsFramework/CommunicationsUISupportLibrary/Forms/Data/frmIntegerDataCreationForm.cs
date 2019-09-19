// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using System.Windows.Forms;

namespace CommunicationsUISupportLibrary
{
	public partial class frmIntegerDataCreationForm
	{
		public frmIntegerDataCreationForm()
		{
			InitializeComponent();
		}
		
public int Data
		{
			get
			{
				return System.Convert.ToInt32(this.mtxtIntegerData.Text);
			}
		}
		
public string DataName
		{
			get
			{
				return this.txtDataName.Text.ToUpper();
			}
		}
		
		public void frmIntegerDataCreationForm_Load(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtDataName.Text.Length <= 0)
				{
					MessageBox.Show("No dataname specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
				if (this.mtxtIntegerData.Text.Length <= 0)
				{
					MessageBox.Show("No data specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
			}
			catch (Exception)
			{
				
			}
		}
	}
}
