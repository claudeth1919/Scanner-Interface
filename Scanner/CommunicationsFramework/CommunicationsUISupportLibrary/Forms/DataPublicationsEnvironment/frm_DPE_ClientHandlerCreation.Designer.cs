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
	partial class frm_DPE_ClientHandlerCreation : System.Windows.Forms.Form
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.STXDataSocketClientName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.chkKeepDataStatistics = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(233, 98);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 44);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(58, 98);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(161, 44);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK ";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // STXDataSocketClientName
            // 
            this.STXDataSocketClientName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.STXDataSocketClientName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.STXDataSocketClientName.Location = new System.Drawing.Point(13, 32);
            this.STXDataSocketClientName.Margin = new System.Windows.Forms.Padding(4);
            this.STXDataSocketClientName.Name = "STXDataSocketClientName";
            this.STXDataSocketClientName.Size = new System.Drawing.Size(436, 22);
            this.STXDataSocketClientName.TabIndex = 5;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 8);
            this.Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(201, 16);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Data Publications Client Name";
            // 
            // chkKeepDataStatistics
            // 
            this.chkKeepDataStatistics.AutoSize = true;
            this.chkKeepDataStatistics.Location = new System.Drawing.Point(13, 61);
            this.chkKeepDataStatistics.Name = "chkKeepDataStatistics";
            this.chkKeepDataStatistics.Size = new System.Drawing.Size(221, 20);
            this.chkKeepDataStatistics.TabIndex = 8;
            this.chkKeepDataStatistics.Text = "Keep Data Reception Statistics";
            this.chkKeepDataStatistics.UseVisualStyleBackColor = true;
            // 
            // frm_DPE_ClientHandlerCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 171);
            this.ControlBox = false;
            this.Controls.Add(this.chkKeepDataStatistics);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.STXDataSocketClientName);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DPE_ClientHandlerCreation";
            this.Text = "Data Publications Client Handler Creation Form";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.TextBox STXDataSocketClientName;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox chkKeepDataStatistics;
	}
	
}
