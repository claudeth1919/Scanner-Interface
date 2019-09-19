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
	partial class frm_DPE_PublicationVariableCreation : System.Windows.Forms.Form
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
			base.Load += new System.EventHandler(frmPublicationVariable_Load);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.txtVariableName = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cboDataType = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(278, 151);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(154, 50);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOK
			//
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(82, 151);
			this.btnOK.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(154, 50);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK ";
			this.btnOK.UseVisualStyleBackColor = true;
			//
			//txtVariableName
			//
			this.txtVariableName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtVariableName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtVariableName.Location = new System.Drawing.Point(13, 31);
			this.txtVariableName.Margin = new System.Windows.Forms.Padding(4);
			this.txtVariableName.Name = "txtVariableName";
			this.txtVariableName.Size = new System.Drawing.Size(495, 25);
			this.txtVariableName.TabIndex = 7;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(13, 9);
			this.Label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(109, 18);
			this.Label2.TabIndex = 6;
			this.Label2.Text = "Variable Name";
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(13, 79);
			this.Label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(140, 18);
			this.Label1.TabIndex = 8;
			this.Label1.Text = "Variable Data Type";
			//
			//cboDataType
			//
			this.cboDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDataType.FormattingEnabled = true;
			this.cboDataType.Location = new System.Drawing.Point(12, 100);
			this.cboDataType.Name = "cboDataType";
			this.cboDataType.Size = new System.Drawing.Size(494, 26);
			this.cboDataType.TabIndex = 9;
			//
			//frmPublicationVariableCreation
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (18.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 226);
			this.ControlBox = false;
			this.Controls.Add(this.cboDataType);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.txtVariableName);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmPublicationVariableCreation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Publication Variable";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.TextBox txtVariableName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ComboBox cboDataType;
	}
	
}
