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


namespace DPEClientTestApplication
{
	public partial class frmDPEClientName
	{
		public frmDPEClientName()
		{
			InitializeComponent();
		}
		
		
		
public string STXDataSocketClientName
		{
			get
			{
				return this.txtSTXDataSocketClientName.Text;
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			this.Dispose();
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtSTXDataSocketClientName.Text.Length <= 0)
				{
					throw (new Exception("No name specified for the Data Publications Client"));
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
