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


namespace P2PPortTestApp
{
	public partial class frmStartForm
	{
		public frmStartForm()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmStartForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmStartForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmStartForm();
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
		
		public void rbtnAutoP2PPort_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			if (this.rbtnAutoP2PPort.Checked)
			{
				this.pnlPortNumber.Visible = false;
			}
			else
			{
				this.pnlPortNumber.Visible = true;
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnStartPort_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.rbtnAutoP2PPort.Checked)
				{
					this.Hide();
					frmP2PPortTestAppMainForm frm = new frmP2PPortTestAppMainForm();
					frm.ShowDialog();
					frm.Dispose();
					this.Show();
				}
				else
				{
					if (this.mtxtPortNumber.Text.Length <= 0)
					{
						throw (new Exception("No port number specified"));
					}
					else
					{
						int port = System.Convert.ToInt32(this.mtxtPortNumber.Text);
						this.Hide();
						frmP2PPortTestAppMainForm frm = new frmP2PPortTestAppMainForm(port);
						frm.ShowDialog();
						frm.Dispose();
						this.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.Show();
			}
		}
	}
}
