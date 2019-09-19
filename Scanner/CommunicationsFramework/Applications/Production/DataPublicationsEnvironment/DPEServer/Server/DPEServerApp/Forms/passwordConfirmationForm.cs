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


namespace DPEServerApp
{
	namespace GeneralPurposeForms
	{
		
		public partial class passwordConfirmationForm
		{
			
			private string _passwordToVerify;
			
			public passwordConfirmationForm(string passwordToVerify)
			{
				
				// This call is required by the Windows Form Designer.
				InitializeComponent();
				
				// Add any initialization after the InitializeComponent() call.
				this._passwordToVerify = passwordToVerify;
			}
			
			
			public void btnOk_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					if (this.txtPassword.Text.Length <= 0)
					{
						throw (new Exception("No password specified"));
					}
					if (this.txtPassword.Text == this._passwordToVerify)
					{
						this.DialogResult = System.Windows.Forms.DialogResult.OK;
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			
			public void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				}
				catch (Exception)
				{
				}
			}
			
			public void txtPassword_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
			{
				try
				{
					if (e.KeyCode == System.Windows.Forms.Keys.Enter)
					{
						this.btnOk_Click(null, null);
					}
				}
				catch (Exception)
				{
					
				}
			}
			
			
			public void passwordConfirmationForm_Load(System.Object sender, System.EventArgs e)
			{
				try
				{
					this.txtPassword.Focus();
				}
				catch (Exception)
				{
				}
			}
			
			
		}
		
		
	}
	
	
}
