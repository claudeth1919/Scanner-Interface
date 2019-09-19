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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmStartForm : System.Windows.Forms.Form
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
			this.btnStartPort = new System.Windows.Forms.Button();
			this.btnStartPort.Click += new System.EventHandler(this.btnStartPort_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtnManualP2PPort = new System.Windows.Forms.RadioButton();
			this.rbtnAutoP2PPort = new System.Windows.Forms.RadioButton();
			this.rbtnAutoP2PPort.CheckedChanged += new System.EventHandler(this.rbtnAutoP2PPort_CheckedChanged);
			this.Label1 = new System.Windows.Forms.Label();
			this.mtxtPortNumber = new System.Windows.Forms.MaskedTextBox();
			this.pnlPortNumber = new System.Windows.Forms.Panel();
			this.GroupBox1.SuspendLayout();
			this.pnlPortNumber.SuspendLayout();
			this.SuspendLayout();
			//
			//btnStartPort
			//
			this.btnStartPort.Location = new System.Drawing.Point(42, 200);
			this.btnStartPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnStartPort.Name = "btnStartPort";
			this.btnStartPort.Size = new System.Drawing.Size(150, 41);
			this.btnStartPort.TabIndex = 0;
			this.btnStartPort.Text = "Create Port";
			this.btnStartPort.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(200, 200);
			this.Button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(150, 41);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "Close";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.rbtnManualP2PPort);
			this.GroupBox1.Controls.Add(this.rbtnAutoP2PPort);
			this.GroupBox1.Location = new System.Drawing.Point(0, 4);
			this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBox1.Size = new System.Drawing.Size(392, 123);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Port Mode";
			//
			//rbtnManualP2PPort
			//
			this.rbtnManualP2PPort.AutoSize = true;
			this.rbtnManualP2PPort.Location = new System.Drawing.Point(24, 73);
			this.rbtnManualP2PPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rbtnManualP2PPort.Name = "rbtnManualP2PPort";
			this.rbtnManualP2PPort.Size = new System.Drawing.Size(193, 20);
			this.rbtnManualP2PPort.TabIndex = 1;
			this.rbtnManualP2PPort.Text = "Manual Port Assignation";
			this.rbtnManualP2PPort.UseVisualStyleBackColor = true;
			//
			//rbtnAutoP2PPort
			//
			this.rbtnAutoP2PPort.AutoSize = true;
			this.rbtnAutoP2PPort.Checked = true;
			this.rbtnAutoP2PPort.Location = new System.Drawing.Point(24, 33);
			this.rbtnAutoP2PPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rbtnAutoP2PPort.Name = "rbtnAutoP2PPort";
			this.rbtnAutoP2PPort.Size = new System.Drawing.Size(269, 20);
			this.rbtnAutoP2PPort.TabIndex = 0;
			this.rbtnAutoP2PPort.TabStop = true;
			this.rbtnAutoP2PPort.Text = "Automatic Port Number Assignation";
			this.rbtnAutoP2PPort.UseVisualStyleBackColor = true;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(84, 4);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(94, 16);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Port Number";
			//
			//mtxtPortNumber
			//
			this.mtxtPortNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (18.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.mtxtPortNumber.Location = new System.Drawing.Point(84, 23);
			this.mtxtPortNumber.Mask = "99999";
			this.mtxtPortNumber.Name = "mtxtPortNumber";
			this.mtxtPortNumber.Size = new System.Drawing.Size(205, 35);
			this.mtxtPortNumber.TabIndex = 4;
			this.mtxtPortNumber.ValidatingType = typeof(int);
			//
			//pnlPortNumber
			//
			this.pnlPortNumber.Controls.Add(this.mtxtPortNumber);
			this.pnlPortNumber.Controls.Add(this.Label1);
			this.pnlPortNumber.Location = new System.Drawing.Point(0, 131);
			this.pnlPortNumber.Name = "pnlPortNumber";
			this.pnlPortNumber.Size = new System.Drawing.Size(391, 62);
			this.pnlPortNumber.TabIndex = 3;
			this.pnlPortNumber.Visible = false;
			//
			//frmStartForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (16.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(403, 251);
			this.ControlBox = false;
			this.Controls.Add(this.pnlPortNumber);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.btnStartPort);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmStartForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "P2P Port Test App Start Form";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.pnlPortNumber.ResumeLayout(false);
			this.pnlPortNumber.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button btnStartPort;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton rbtnManualP2PPort;
		internal System.Windows.Forms.RadioButton rbtnAutoP2PPort;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.MaskedTextBox mtxtPortNumber;
		internal System.Windows.Forms.Panel pnlPortNumber;
	}
	
}
