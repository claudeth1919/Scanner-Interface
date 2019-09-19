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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmSocketsServerConnection : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.txtPort = new System.Windows.Forms.MaskedTextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtServerHostName = new System.Windows.Forms.TextBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			this.Label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.SuspendLayout();
			//
			//txtPort
			//
			this.txtPort.Location = new System.Drawing.Point(125, 45);
			this.txtPort.Margin = new System.Windows.Forms.Padding(4);
			this.txtPort.Mask = "999999";
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(148, 22);
			this.txtPort.TabIndex = 4;
			this.txtPort.Text = "8000";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(77, 49);
			this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(36, 16);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Port";
			//
			//txtServerHostName
			//
			this.txtServerHostName.Location = new System.Drawing.Point(125, 13);
			this.txtServerHostName.Margin = new System.Windows.Forms.Padding(4);
			this.txtServerHostName.Name = "txtServerHostName";
			this.txtServerHostName.Size = new System.Drawing.Size(211, 22);
			this.txtServerHostName.TabIndex = 2;
			this.txtServerHostName.Text = "localhost";
			//
			//btnConnect
			//
			this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnConnect.Location = new System.Drawing.Point(36, 89);
			this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(120, 43);
			this.btnConnect.TabIndex = 1;
			this.btnConnect.Text = "connect to SocketsServer";
			this.btnConnect.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(21, 17);
			this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(90, 16);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Server Host";
			//
			//btnCancel
			//
			this.btnCancel.Location = new System.Drawing.Point(176, 89);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(120, 43);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//frmSocketsServerConnection
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (16.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(344, 152);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtServerHostName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.btnConnect);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmSocketsServerConnection";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Connection To Sockets Server";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button btnConnect;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.MaskedTextBox txtPort;
		private System.Windows.Forms.TextBox txtServerHostName;
	}
	
}
