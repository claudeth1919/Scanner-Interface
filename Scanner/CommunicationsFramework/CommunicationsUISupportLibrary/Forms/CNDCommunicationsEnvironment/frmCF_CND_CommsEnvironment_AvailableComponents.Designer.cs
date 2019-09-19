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
	partial class frmCF_CND_CommsEnvironment_AvailableComponents : System.Windows.Forms.Form
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
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			base.Load += new System.EventHandler(frmAvailableComponents_Load);
			this.btnOk = new System.Windows.Forms.Button();
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.lstBoxAvailableComponents = new System.Windows.Forms.ListBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.lstBoxAvailableComponents);
			this.GroupBox2.Location = new System.Drawing.Point(0, 1);
			this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.GroupBox2.Size = new System.Drawing.Size(376, 364);
			this.GroupBox2.TabIndex = 6;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Available Components on STX Communications Environment";
			//
			//btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(61, 367);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(107, 58);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			//
			//lstBoxAvailableComponents
			//
			this.lstBoxAvailableComponents.FormattingEnabled = true;
			this.lstBoxAvailableComponents.ItemHeight = 16;
			this.lstBoxAvailableComponents.Location = new System.Drawing.Point(8, 34);
			this.lstBoxAvailableComponents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.lstBoxAvailableComponents.Name = "lstBoxAvailableComponents";
			this.lstBoxAvailableComponents.Size = new System.Drawing.Size(360, 324);
			this.lstBoxAvailableComponents.TabIndex = 0;
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(205, 367);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(107, 58);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//frmAvailableComponents
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (8.0F), (float) (16.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 433);
			this.ControlBox = false;
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.GroupBox2);
			this.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "frmAvailableComponents";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Component Selection Form";
			this.GroupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.ListBox lstBoxAvailableComponents;
		internal System.Windows.Forms.Button btnCancel;
	}
	
}
