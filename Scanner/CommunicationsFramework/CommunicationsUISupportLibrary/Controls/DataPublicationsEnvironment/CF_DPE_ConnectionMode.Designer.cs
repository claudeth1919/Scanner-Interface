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
	partial class CF_DPE_ConnectionMode : System.Windows.Forms.Form
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
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtnNotReceiveLastStatus = new System.Windows.Forms.RadioButton();
			this.rbtnREceiveLastStatus = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.rbtnNotReceiveLastStatus);
			this.GroupBox1.Controls.Add(this.rbtnREceiveLastStatus);
			this.GroupBox1.Location = new System.Drawing.Point(12, 12);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(397, 114);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Connection Mode";
			//
			//rbtnNotReceiveLastStatus
			//
			this.rbtnNotReceiveLastStatus.AutoSize = true;
			this.rbtnNotReceiveLastStatus.Location = new System.Drawing.Point(23, 72);
			this.rbtnNotReceiveLastStatus.Name = "rbtnNotReceiveLastStatus";
			this.rbtnNotReceiveLastStatus.Size = new System.Drawing.Size(275, 22);
			this.rbtnNotReceiveLastStatus.TabIndex = 1;
			this.rbtnNotReceiveLastStatus.Text = "Not Receive last Publication Status";
			this.rbtnNotReceiveLastStatus.UseVisualStyleBackColor = true;
			//
			//rbtnREceiveLastStatus
			//
			this.rbtnREceiveLastStatus.AutoSize = true;
			this.rbtnREceiveLastStatus.Checked = true;
			this.rbtnREceiveLastStatus.Location = new System.Drawing.Point(23, 33);
			this.rbtnREceiveLastStatus.Name = "rbtnREceiveLastStatus";
			this.rbtnREceiveLastStatus.Size = new System.Drawing.Size(246, 22);
			this.rbtnREceiveLastStatus.TabIndex = 0;
			this.rbtnREceiveLastStatus.TabStop = true;
			this.rbtnREceiveLastStatus.Text = "Receive last Publication Status";
			this.rbtnREceiveLastStatus.UseVisualStyleBackColor = true;
			//
			//btnOK
			//
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(77, 147);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(116, 59);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Button2.Location = new System.Drawing.Point(233, 147);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(116, 59);
			this.Button2.TabIndex = 3;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//CF_DPE_ConnectionMode
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (18.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(430, 234);
			this.ControlBox = false;
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.GroupBox1);
			this.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CF_DPE_ConnectionMode";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuration of Connection to a publication";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton rbtnNotReceiveLastStatus;
		internal System.Windows.Forms.RadioButton rbtnREceiveLastStatus;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.Button Button2;
	}
	
}
