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
	partial class frm_DPE_RandomPublicationCreation : System.Windows.Forms.Form
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
            this.Label4 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDataTable = new System.Windows.Forms.CheckBox();
            this.chkString = new System.Windows.Forms.CheckBox();
            this.chkBoolean = new System.Windows.Forms.CheckBox();
            this.chkDEcimal = new System.Windows.Forms.CheckBox();
            this.chkInteger = new System.Windows.Forms.CheckBox();
            this.nudNumberOfVariables = new System.Windows.Forms.NumericUpDown();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtPublicationName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.GroupBox1.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfVariables)).BeginInit();
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
            this.btnCancel.Location = new System.Drawing.Point(224, 440);
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
            this.btnOK.Location = new System.Drawing.Point(93, 440);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(121, 36);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Generate ";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtPublicationsGroup);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.GroupBox3);
            this.GroupBox1.Controls.Add(this.txtPublicationName);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Location = new System.Drawing.Point(12, 61);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(432, 372);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Publication Parameters";
            // 
            // txtPublicationsGroup
            // 
            this.txtPublicationsGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPublicationsGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPublicationsGroup.Location = new System.Drawing.Point(147, 24);
            this.txtPublicationsGroup.Name = "txtPublicationsGroup";
            this.txtPublicationsGroup.Size = new System.Drawing.Size(267, 25);
            this.txtPublicationsGroup.TabIndex = 13;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(5, 27);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(135, 18);
            this.Label4.TabIndex = 12;
            this.Label4.Text = "Pulications Group";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.GroupBox2);
            this.GroupBox3.Controls.Add(this.nudNumberOfVariables);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Location = new System.Drawing.Point(8, 88);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(370, 271);
            this.GroupBox3.TabIndex = 11;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Variables Definition";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.chkDataTable);
            this.GroupBox2.Controls.Add(this.chkString);
            this.GroupBox2.Controls.Add(this.chkBoolean);
            this.GroupBox2.Controls.Add(this.chkDEcimal);
            this.GroupBox2.Controls.Add(this.chkInteger);
            this.GroupBox2.Location = new System.Drawing.Point(14, 75);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(164, 180);
            this.GroupBox2.TabIndex = 10;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Type Of Variables";
            // 
            // chkDataTable
            // 
            this.chkDataTable.AutoSize = true;
            this.chkDataTable.Checked = true;
            this.chkDataTable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDataTable.Location = new System.Drawing.Point(18, 136);
            this.chkDataTable.Name = "chkDataTable";
            this.chkDataTable.Size = new System.Drawing.Size(102, 22);
            this.chkDataTable.TabIndex = 4;
            this.chkDataTable.Text = "Data Table";
            this.chkDataTable.UseVisualStyleBackColor = true;
            // 
            // chkString
            // 
            this.chkString.AutoSize = true;
            this.chkString.Checked = true;
            this.chkString.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkString.Location = new System.Drawing.Point(18, 108);
            this.chkString.Name = "chkString";
            this.chkString.Size = new System.Drawing.Size(70, 22);
            this.chkString.TabIndex = 3;
            this.chkString.Text = "String";
            this.chkString.UseVisualStyleBackColor = true;
            // 
            // chkBoolean
            // 
            this.chkBoolean.AutoSize = true;
            this.chkBoolean.Checked = true;
            this.chkBoolean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoolean.Location = new System.Drawing.Point(18, 80);
            this.chkBoolean.Name = "chkBoolean";
            this.chkBoolean.Size = new System.Drawing.Size(86, 22);
            this.chkBoolean.TabIndex = 2;
            this.chkBoolean.Text = "Boolean";
            this.chkBoolean.UseVisualStyleBackColor = true;
            // 
            // chkDEcimal
            // 
            this.chkDEcimal.AutoSize = true;
            this.chkDEcimal.Checked = true;
            this.chkDEcimal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDEcimal.Location = new System.Drawing.Point(18, 52);
            this.chkDEcimal.Name = "chkDEcimal";
            this.chkDEcimal.Size = new System.Drawing.Size(87, 22);
            this.chkDEcimal.TabIndex = 1;
            this.chkDEcimal.Text = "Decimal ";
            this.chkDEcimal.UseVisualStyleBackColor = true;
            // 
            // chkInteger
            // 
            this.chkInteger.AutoSize = true;
            this.chkInteger.Checked = true;
            this.chkInteger.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInteger.Location = new System.Drawing.Point(18, 24);
            this.chkInteger.Name = "chkInteger";
            this.chkInteger.Size = new System.Drawing.Size(82, 22);
            this.chkInteger.TabIndex = 0;
            this.chkInteger.Text = "Integer ";
            this.chkInteger.UseVisualStyleBackColor = true;
            // 
            // nudNumberOfVariables
            // 
            this.nudNumberOfVariables.Location = new System.Drawing.Point(172, 24);
            this.nudNumberOfVariables.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudNumberOfVariables.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfVariables.Name = "nudNumberOfVariables";
            this.nudNumberOfVariables.Size = new System.Drawing.Size(120, 25);
            this.nudNumberOfVariables.TabIndex = 9;
            this.nudNumberOfVariables.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(11, 26);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(153, 18);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Number Of Variables";
            // 
            // txtPublicationName
            // 
            this.txtPublicationName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPublicationName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPublicationName.Location = new System.Drawing.Point(130, 57);
            this.txtPublicationName.Name = "txtPublicationName";
            this.txtPublicationName.Size = new System.Drawing.Size(284, 25);
            this.txtPublicationName.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(5, 60);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(122, 18);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Pulication Name";
            // 
            // frm_DPE_RandomPublicationCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 489);
            this.ControlBox = false;
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSTXDSSCName);
            this.Controls.Add(this.Label1);
            this.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_DPE_RandomPublicationCreation";
            this.Text = "Publication Creation ";
            this.Load += new System.EventHandler(this.frmPublicationCreation_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfVariables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtSTXDSSCName;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtPublicationName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.NumericUpDown nudNumberOfVariables;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.CheckBox chkDEcimal;
		internal System.Windows.Forms.CheckBox chkInteger;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.CheckBox chkDataTable;
		internal System.Windows.Forms.CheckBox chkString;
		internal System.Windows.Forms.CheckBox chkBoolean;
		internal System.Windows.Forms.TextBox txtPublicationsGroup;
		internal System.Windows.Forms.Label Label4;
	}
	
}
