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



namespace P2PPortClientTestApp
{
	public partial class frmP2PPortClientStartForm
	{
		public frmP2PPortClientStartForm()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmP2PPortClientStartForm defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmP2PPortClientStartForm Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmP2PPortClientStartForm();
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
		
		public void btnClose_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnCreateClient_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtHost.Text.Length <= 0)
				{
					throw (new Exception("No host name specified"));
				}
				if (this.mtxtPortNumber.Text.Length <= 0)
				{
					throw (new Exception("No port number specified"));
				}
				
				int port = System.Convert.ToInt32(this.mtxtPortNumber.Text);
				this.Hide();
                frmP2PPortClientMainform frm = new frmP2PPortClientMainform(this.txtHost.Text, port);
			    frm.ShowDialog();
				frm.Dispose();
				this.Show();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.Show();
			}
		}
	}
}
