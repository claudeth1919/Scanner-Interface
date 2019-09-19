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
	partial class frmCFHashTableDataCreationForm : System.Windows.Forms.Form
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
			this.Button4 = new System.Windows.Forms.Button();
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.lstHashTable = new System.Windows.Forms.ListBox();
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
			this.btnCancel.Location = new System.Drawing.Point(248, 342);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 36);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(148, 342);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(94, 36);
			this.btnOk.TabIndex = 11;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			//
			//Button4
			//
			this.Button4.Location = new System.Drawing.Point(324, 88);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(122, 23);
			this.Button4.TabIndex = 15;
			this.Button4.Text = "Remove Element";
			this.Button4.UseVisualStyleBackColor = true;
			//
			//Button3
			//
			this.Button3.Location = new System.Drawing.Point(324, 59);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(122, 23);
			this.Button3.TabIndex = 14;
			this.Button3.Text = "Add Element";
			this.Button3.UseVisualStyleBackColor = true;
			//
			//lstHashTable
			//
			this.lstHashTable.FormattingEnabled = true;
			this.lstHashTable.Location = new System.Drawing.Point(15, 59);
			this.lstHashTable.Name = "lstHashTable";
			this.lstHashTable.Size = new System.Drawing.Size(290, 277);
			this.lstHashTable.TabIndex = 13;
			//
			//frmHashTableDataCreationForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 390);
			this.ControlBox = false;
			this.Controls.Add(this.Button4);
			this.Controls.Add(this.Button3);
			this.Controls.Add(this.lstHashTable);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtDataName);
			this.Controls.Add(this.Label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmHashTableDataCreationForm";
			this.Text = "HashTable  Data Creation";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.TextBox txtDataName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.ListBox lstHashTable;
	}
	
}
