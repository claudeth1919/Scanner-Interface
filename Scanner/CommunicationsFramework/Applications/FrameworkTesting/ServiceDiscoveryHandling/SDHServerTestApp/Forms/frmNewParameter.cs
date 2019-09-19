// VBConversions Note: VB project level imports
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
// End of VB project level imports


namespace STXServiceHandlerServerTestApplication
{
	public partial class frmNewParameter
	{
		public frmNewParameter()
		{
			InitializeComponent();
		}
		
		public void TextBox2_TextChanged(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void Label1_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			if (this.txtParamName.Text.Length <= 0)
			{
				MessageBox.Show("No parameter name specified");
				this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}
			
			if (this.txtParamValue.Text.Length <= 0)
			{
				MessageBox.Show("No parameter value specified");
				this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}
			
		}
	}
}
