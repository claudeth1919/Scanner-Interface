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



namespace SocketsServerTestApp
{
	public partial class frmSocketsServerStart
	{
		public frmSocketsServerStart()
		{
			InitializeComponent();
			
			//Added to support default instance behavour in C#
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmSocketsServerStart defaultInstance;
		
		/// <summary>
		/// Added by the VB.Net to C# Converter to support default instance behavour in C#
		/// </summary>
public static frmSocketsServerStart Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmSocketsServerStart();
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
		
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			frmSocketDataTest frm = new frmSocketDataTest();
			frm.ShowDialog();
			frm.Dispose();
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtListeningPort.Text.Length <= 0)
				{
					throw (new Exception("No port specified to start a server"));
				}
				this.Hide();
				frmSocketsServerTest frm = default(frmSocketsServerTest);
				frm = new frmSocketsServerTest(System.Convert.ToInt32(this.txtListeningPort.Text));
				frm.ShowDialog();
				frm.Dispose();
				this.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
