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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmP2PPortClientStartForm : System.Windows.Forms.Form
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
            this.btnCreateClient = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.mtxtPortNumber = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnCreateClient
            // 
            this.btnCreateClient.Location = new System.Drawing.Point(20, 139);
            this.btnCreateClient.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateClient.Name = "btnCreateClient";
            this.btnCreateClient.Size = new System.Drawing.Size(148, 43);
            this.btnCreateClient.TabIndex = 0;
            this.btnCreateClient.Text = "Start Client";
            this.btnCreateClient.UseVisualStyleBackColor = true;
            this.btnCreateClient.Click += new System.EventHandler(this.btnCreateClient_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(196, 139);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(148, 43);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(28, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(175, 16);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Remote Port Host Name";
            // 
            // txtHost
            // 
            this.txtHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(31, 28);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(221, 26);
            this.txtHost.TabIndex = 3;
            this.txtHost.Text = "192.168.1.65";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(28, 71);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(149, 16);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Remote Port number";
            // 
            // mtxtPortNumber
            // 
            this.mtxtPortNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtxtPortNumber.Location = new System.Drawing.Point(31, 90);
            this.mtxtPortNumber.Mask = "99999";
            this.mtxtPortNumber.Name = "mtxtPortNumber";
            this.mtxtPortNumber.Size = new System.Drawing.Size(227, 29);
            this.mtxtPortNumber.TabIndex = 5;
            this.mtxtPortNumber.Text = "4000";
            this.mtxtPortNumber.ValidatingType = typeof(int);
            // 
            // frmP2PPortClientStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 205);
            this.ControlBox = false;
            this.Controls.Add(this.mtxtPortNumber);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateClient);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmP2PPortClientStartForm";
            this.Text = "P2PPort client Test Start";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Button btnCreateClient;
		internal System.Windows.Forms.Button btnClose;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtHost;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.MaskedTextBox mtxtPortNumber;
	}
	
}
