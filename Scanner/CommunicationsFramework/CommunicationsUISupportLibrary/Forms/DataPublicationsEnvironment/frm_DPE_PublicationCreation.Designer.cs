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
	partial class frm_DPE_PublicationCreation : System.Windows.Forms.Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.txtSTXDSSCName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPublicationsGroup = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnRemoveVariable = new System.Windows.Forms.Button();
            this.btnAddVariable = new System.Windows.Forms.Button();
            this.lstBoxPublicationVariables = new System.Windows.Forms.ListBox();
            this.txtPublicationName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 9);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(177, 18);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Data Publications Client";
            // 
            // txtSTXDSSCName
            // 
            this.txtSTXDSSCName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtSTXDSSCName.Location = new System.Drawing.Point(16, 30);
            this.txtSTXDSSCName.Name = "txtSTXDSSCName";
            this.txtSTXDSSCName.ReadOnly = true;
            this.txtSTXDSSCName.Size = new System.Drawing.Size(410, 25);
            this.txtSTXDSSCName.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(288, 560);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 36);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(157, 560);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 36);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK ";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtPublicationsGroup);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.btnRemoveVariable);
            this.GroupBox1.Controls.Add(this.btnAddVariable);
            this.GroupBox1.Controls.Add(this.lstBoxPublicationVariables);
            this.GroupBox1.Controls.Add(this.txtPublicationName);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(12, 61);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(549, 492);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Publication Parameters";
            // 
            // txtPublicationsGroup
            // 
            this.txtPublicationsGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPublicationsGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPublicationsGroup.Location = new System.Drawing.Point(145, 25);
            this.txtPublicationsGroup.Name = "txtPublicationsGroup";
            this.txtPublicationsGroup.Size = new System.Drawing.Size(397, 25);
            this.txtPublicationsGroup.TabIndex = 8;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 28);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(135, 18);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Pulications Group";
            // 
            // btnRemoveVariable
            // 
            this.btnRemoveVariable.Location = new System.Drawing.Point(411, 179);
            this.btnRemoveVariable.Name = "btnRemoveVariable";
            this.btnRemoveVariable.Size = new System.Drawing.Size(132, 47);
            this.btnRemoveVariable.TabIndex = 6;
            this.btnRemoveVariable.Text = "Remove Variable";
            this.btnRemoveVariable.UseVisualStyleBackColor = true;
            // 
            // btnAddVariable
            // 
            this.btnAddVariable.Location = new System.Drawing.Point(410, 122);
            this.btnAddVariable.Name = "btnAddVariable";
            this.btnAddVariable.Size = new System.Drawing.Size(132, 51);
            this.btnAddVariable.TabIndex = 5;
            this.btnAddVariable.Text = "Add Variable";
            this.btnAddVariable.UseVisualStyleBackColor = true;
            this.btnAddVariable.Click += new System.EventHandler(this.btnAddVariable_Click);
            // 
            // lstBoxPublicationVariables
            // 
            this.lstBoxPublicationVariables.FormattingEnabled = true;
            this.lstBoxPublicationVariables.ItemHeight = 18;
            this.lstBoxPublicationVariables.Location = new System.Drawing.Point(10, 122);
            this.lstBoxPublicationVariables.Name = "lstBoxPublicationVariables";
            this.lstBoxPublicationVariables.Size = new System.Drawing.Size(387, 364);
            this.lstBoxPublicationVariables.TabIndex = 4;
            // 
            // txtPublicationName
            // 
            this.txtPublicationName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPublicationName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPublicationName.Location = new System.Drawing.Point(132, 56);
            this.txtPublicationName.Name = "txtPublicationName";
            this.txtPublicationName.Size = new System.Drawing.Size(410, 25);
            this.txtPublicationName.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 59);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(122, 18);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Pulication Name";
            // 
            // frm_DPE_PublicationCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 609);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSTXDSSCName);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DPE_PublicationCreation";
            this.Text = "Publication Creation ";
            this.Load += new System.EventHandler(this.frmPublicationCreation_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtSTXDSSCName;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button btnRemoveVariable;
		internal System.Windows.Forms.Button btnAddVariable;
		internal System.Windows.Forms.ListBox lstBoxPublicationVariables;
		internal System.Windows.Forms.TextBox txtPublicationName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtPublicationsGroup;
		internal System.Windows.Forms.Label Label3;
	}
	
}
