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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmSocketsServerStart : System.Windows.Forms.Form
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
			this.Button4 = new System.Windows.Forms.Button();
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.txtListeningPort = new System.Windows.Forms.MaskedTextBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Label1 = new System.Windows.Forms.Label();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.SuspendLayout();
			//
			//Button4
			//
			this.Button4.Location = new System.Drawing.Point(244, 178);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(112, 41);
			this.Button4.TabIndex = 10;
			this.Button4.Text = "Test Socket Data XML  Strings";
			this.Button4.UseVisualStyleBackColor = true;
			//
			//txtListeningPort
			//
			this.txtListeningPort.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtListeningPort.Location = new System.Drawing.Point(186, 85);
			this.txtListeningPort.Mask = "99999";
			this.txtListeningPort.Name = "txtListeningPort";
			this.txtListeningPort.Size = new System.Drawing.Size(116, 26);
			this.txtListeningPort.TabIndex = 1;
			this.txtListeningPort.Text = "8000";
			this.txtListeningPort.ValidatingType = typeof(int);
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(8, 178);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(112, 41);
			this.Button1.TabIndex = 11;
			this.Button1.Text = "Start Server";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(60, 88);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(120, 20);
			this.Label1.TabIndex = 12;
			this.Label1.Text = "Listening Port";
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(126, 178);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(112, 41);
			this.Button2.TabIndex = 13;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//frmSocketsServerStart
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(365, 231);
			this.ControlBox = false;
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.txtListeningPort);
			this.Controls.Add(this.Button4);
			this.Name = "frmSocketsServerStart";
			this.Text = "Sockets Server Start";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.MaskedTextBox txtListeningPort;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button2;
	}
	
}
