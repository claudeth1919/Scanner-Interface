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
	partial class frmDataTableDataCreationForm : System.Windows.Forms.Form
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
			this.txtSQLServerName = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtDataBase = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.txtQuery = new System.Windows.Forms.TextBox();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.dgrvDataTable = new System.Windows.Forms.DataGridView();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrvDataTable).BeginInit();
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
			this.btnCancel.Location = new System.Drawing.Point(355, 465);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 36);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			//
			//btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(255, 465);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(94, 36);
			this.btnOk.TabIndex = 11;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			//
			//txtSQLServerName
			//
			this.txtSQLServerName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtSQLServerName.Location = new System.Drawing.Point(7, 32);
			this.txtSQLServerName.Name = "txtSQLServerName";
			this.txtSQLServerName.Size = new System.Drawing.Size(191, 20);
			this.txtSQLServerName.TabIndex = 14;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(6, 16);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(104, 13);
			this.Label1.TabIndex = 13;
			this.Label1.Text = "SQLServer Name";
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.dgrvDataTable);
			this.GroupBox1.Controls.Add(this.Button1);
			this.GroupBox1.Controls.Add(this.Label6);
			this.GroupBox1.Controls.Add(this.txtQuery);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.txtDataBase);
			this.GroupBox1.Controls.Add(this.Label4);
			this.GroupBox1.Controls.Add(this.txtPassword);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.txtUser);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.txtSQLServerName);
			this.GroupBox1.Location = new System.Drawing.Point(15, 51);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(678, 399);
			this.GroupBox1.TabIndex = 15;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Data Table Definition";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.Location = new System.Drawing.Point(212, 16);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(33, 13);
			this.Label2.TabIndex = 15;
			this.Label2.Text = "User";
			//
			//txtUser
			//
			this.txtUser.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtUser.Location = new System.Drawing.Point(213, 32);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(191, 20);
			this.txtUser.TabIndex = 16;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label4.Location = new System.Drawing.Point(419, 16);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(61, 13);
			this.Label4.TabIndex = 17;
			this.Label4.Text = "Password";
			//
			//txtPassword
			//
			this.txtPassword.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtPassword.Location = new System.Drawing.Point(420, 32);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = global::Microsoft.VisualBasic.Strings.ChrW(42);
			this.txtPassword.Size = new System.Drawing.Size(191, 20);
			this.txtPassword.TabIndex = 18;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label5.Location = new System.Drawing.Point(6, 55);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(66, 13);
			this.Label5.TabIndex = 19;
			this.Label5.Text = "Data Base";
			//
			//txtDataBase
			//
			this.txtDataBase.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtDataBase.Location = new System.Drawing.Point(7, 71);
			this.txtDataBase.Name = "txtDataBase";
			this.txtDataBase.Size = new System.Drawing.Size(191, 20);
			this.txtDataBase.TabIndex = 20;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label6.Location = new System.Drawing.Point(212, 55);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(40, 13);
			this.Label6.TabIndex = 21;
			this.Label6.Text = "Query";
			//
			//txtQuery
			//
			this.txtQuery.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtQuery.Location = new System.Drawing.Point(213, 71);
			this.txtQuery.Multiline = true;
			this.txtQuery.Name = "txtQuery";
			this.txtQuery.Size = new System.Drawing.Size(459, 64);
			this.txtQuery.TabIndex = 22;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(7, 97);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(94, 38);
			this.Button1.TabIndex = 23;
			this.Button1.Text = "Get Table";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//dgrvDataTable
			//
			this.dgrvDataTable.AllowUserToAddRows = false;
			this.dgrvDataTable.AllowUserToDeleteRows = false;
			this.dgrvDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrvDataTable.Location = new System.Drawing.Point(7, 150);
			this.dgrvDataTable.Name = "dgrvDataTable";
			this.dgrvDataTable.ReadOnly = true;
			this.dgrvDataTable.Size = new System.Drawing.Size(661, 243);
			this.dgrvDataTable.TabIndex = 24;
			//
			//frmDataTableDataCreationForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(695, 513);
			this.ControlBox = false;
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtDataName);
			this.Controls.Add(this.Label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmDataTableDataCreationForm";
			this.Text = "SortedList  Data Creation";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrvDataTable).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.TextBox txtDataName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOk;
		internal System.Windows.Forms.TextBox txtSQLServerName;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtQuery;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtDataBase;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtUser;
		internal System.Windows.Forms.DataGridView dgrvDataTable;
	}
	
}
