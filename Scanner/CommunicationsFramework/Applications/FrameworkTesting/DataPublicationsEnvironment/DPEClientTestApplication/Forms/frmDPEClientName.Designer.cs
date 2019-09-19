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


namespace DPEClientTestApplication
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDPEClientName : System.Windows.Forms.Form
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
            this.Button1 = new System.Windows.Forms.Button();
            this.Button2 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSTXDataSocketClientName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Button1.Location = new System.Drawing.Point(56, 86);
            this.Button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(172, 63);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "OK ";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Button2
            // 
            this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button2.Location = new System.Drawing.Point(256, 86);
            this.Button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(172, 63);
            this.Button2.TabIndex = 1;
            this.Button2.Text = "Cancel";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(200, 19);
            this.Label1.TabIndex = 3;
            this.Label1.Text = "Publications Client Name";
            // 
            // txtSTXDataSocketClientName
            // 
            this.txtSTXDataSocketClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSTXDataSocketClientName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSTXDataSocketClientName.Location = new System.Drawing.Point(12, 50);
            this.txtSTXDataSocketClientName.Name = "txtSTXDataSocketClientName";
            this.txtSTXDataSocketClientName.Size = new System.Drawing.Size(471, 29);
            this.txtSTXDataSocketClientName.TabIndex = 4;
            // 
            // frmDPEClientName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 166);
            this.ControlBox = false;
            this.Controls.Add(this.txtSTXDataSocketClientName);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.Button1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDPEClientName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtSTXDataSocketClientName;
	}
	
}
