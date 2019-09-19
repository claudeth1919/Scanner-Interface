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



namespace SocketsServerClientTestApp
{
	public partial class frmSocketsServerConnection
	{
		public frmSocketsServerConnection()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmSocketsServerConnection defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmSocketsServerConnection Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmSocketsServerConnection();
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
		
		
		public void btnConnect_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtServerHostName.Text.Length <= 0)
				{
					throw (new Exception("No host name specified"));
				}
				
				if (this.txtPort.Text.Length <= 0)
				{
					throw (new Exception("No port specified"));
				}
				frmSocketsServerClientTest frm = default(frmSocketsServerClientTest);
				try
				{
					this.Hide();
					frm = new frmSocketsServerClientTest(this.txtServerHostName.Text, System.Convert.ToInt32(this.txtPort.Text));
					frm.ShowDialog(this);
					frm.Dispose();
					this.Show();
				}
				catch (Exception ex)
				{
					try
					{
						MessageBox.Show(ex.Message);
						this.DialogResult = System.Windows.Forms.DialogResult.None;
						frm.Dispose();
					}
					catch (Exception)
					{
					}
				}
				finally
				{
					this.Show();
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
			
		}
		
		
		public void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			this.Dispose();
		}
	}
}
