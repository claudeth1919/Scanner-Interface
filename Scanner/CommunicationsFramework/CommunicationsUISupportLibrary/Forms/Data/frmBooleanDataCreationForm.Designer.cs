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
	partial class frmBooleanDataCreationForm : System.Windows.Forms.Form
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
			this.txtDataName = new System.Windows.Forms.TextBox();
			base.Load += new System.EventHandler(frmIntegerDataCreationForm_Load);
			this.Label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.rbtnTrue = new System.Windows.Forms.RadioButton();
			this.rbtnFalse = new System.Windows.Forms.RadioButton();
			this.GroupBox2.SuspendLayout();
			this.SuspendLayout();
			//
			//txtDataName
			//
			this.txtDataName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtDataName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDataName.Location = new System.Drawing.Point(13, 25);
			this.txtDataName.Name = "txtDataName";
			this.txtDataName.Size = new System.Drawing.Size(462, 20);
			this.txtDataName.TabIndex = 9;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.Location = new System.Drawing.Point(12, 9);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(70, 13);
			this.Label3.TabIndex = 8;
			this.Label3.Text = "Data Name";
			//
			//btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(244, 148);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 36);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(144, 148);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(94, 36);
			this.btnOk.TabIndex = 11;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.rbtnTrue);
			this.GroupBox2.Controls.Add(this.rbtnFalse);
			this.GroupBox2.Location = new System.Drawing.Point(92, 51);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(300, 72);
			this.GroupBox2.TabIndex = 13;
			this.GroupBox2.TabStop = false;
			//
			//rbtnTrue
			//
			this.rbtnTrue.AutoSize = true;
			this.rbtnTrue.Checked = true;
			this.rbtnTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (27.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.rbtnTrue.Location = new System.Drawing.Point(18, 19);
			this.rbtnTrue.Name = "rbtnTrue";
			this.rbtnTrue.Size = new System.Drawing.Size(117, 46);
			this.rbtnTrue.TabIndex = 1;
			this.rbtnTrue.TabStop = true;
			this.rbtnTrue.Text = "True";
			this.rbtnTrue.UseVisualStyleBackColor = true;
			//
			//rbtnFalse
			//
			this.rbtnFalse.AutoSize = true;
			this.rbtnFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (27.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.rbtnFalse.Location = new System.Drawing.Point(152, 19);
			this.rbtnFalse.Name = "rbtnFalse";
			this.rbtnFalse.Size = new System.Drawing.Size(133, 46);
			this.rbtnFalse.TabIndex = 0;
			this.rbtnFalse.Text = "False";
			this.rbtnFalse.UseVisualStyleBackColor = true;
			//
			//frmBooleanDataCreationForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 204);
			this.ControlBox = false;
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtDataName);
			this.Controls.Add(this.Label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmBooleanDataCreationForm";
			this.Text = "Boolean  Data Creation";
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.TextBox txtDataName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.RadioButton rbtnTrue;
		internal System.Windows.Forms.RadioButton rbtnFalse;
	}
	
}
