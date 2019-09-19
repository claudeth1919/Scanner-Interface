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
	public partial class frmBooleanDataCreationForm
	{
		public frmBooleanDataCreationForm()
		{
			InitializeComponent();
		}
		
public bool Data
		{
			get
			{
				if (this.rbtnFalse.Checked)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}
		
public string DataName
		{
			get
			{
				return this.txtDataName.Text;
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
