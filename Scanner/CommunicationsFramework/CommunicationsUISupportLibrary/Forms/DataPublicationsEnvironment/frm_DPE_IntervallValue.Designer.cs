// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports


namespace CommunicationsUISupportLibrary
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frm_DPE_IntervallValue : System.Windows.Forms.Form
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
			this.nudREadInterval = new System.Windows.Forms.NumericUpDown();
			this.Label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.nudREadInterval).BeginInit();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button1.Location = new System.Drawing.Point(75, 112);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(111, 46);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "OK";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button2.Location = new System.Drawing.Point(193, 111);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(111, 47);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//nudREadInterval
			//
			this.nudREadInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (15.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.nudREadInterval.Location = new System.Drawing.Point(140, 61);
			this.nudREadInterval.Maximum = new decimal(new int[] {6000000, 0, 0, 0});
			this.nudREadInterval.Minimum = new decimal(new int[] {500, 0, 0, 0});
			this.nudREadInterval.Name = "nudREadInterval";
			this.nudREadInterval.Size = new System.Drawing.Size(120, 31);
			this.nudREadInterval.TabIndex = 2;
			this.nudREadInterval.Value = new decimal(new int[] {500, 0, 0, 0});
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(77, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(227, 24);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "Simulation Interval (ms)";
			//
			//frm_DPE_IntervallValue
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 185);
			this.ControlBox = false;
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.nudREadInterval);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frm_DPE_IntervallValue";
			this.Text = "frm_DPE_IntervallValue";
			((System.ComponentModel.ISupportInitialize) this.nudREadInterval).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.NumericUpDown nudREadInterval;
		internal System.Windows.Forms.Label Label1;
	}
	
}
