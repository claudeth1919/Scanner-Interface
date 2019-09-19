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
	public partial class frmDecimalDataCreationForm
	{
		public frmDecimalDataCreationForm()
		{
			InitializeComponent();
		}
		
		
public decimal Data
		{
			get
			{
				return System.Convert.ToDecimal(this.mtxtDecimal.Text);
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
				
				if (this.mtxtDecimal.Text.Length <= 0)
				{
					MessageBox.Show("No data especified");
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
