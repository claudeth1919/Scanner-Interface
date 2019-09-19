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
	partial class frmDataCreationSelectionForm : System.Windows.Forms.Form
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.grpDataType = new System.Windows.Forms.GroupBox();
			this.rbtnCFList = new System.Windows.Forms.RadioButton();
			this.rbtnDataTable = new System.Windows.Forms.RadioButton();
			this.rbtnSortedList = new System.Windows.Forms.RadioButton();
			this.rbtnHash = new System.Windows.Forms.RadioButton();
			this.rbtnHash.CheckedChanged += new System.EventHandler(this.rbtnHash_CheckedChanged);
			this.rbtnString = new System.Windows.Forms.RadioButton();
			this.rbtnBoolean = new System.Windows.Forms.RadioButton();
			this.rbtnDecimal = new System.Windows.Forms.RadioButton();
			this.rbtnInteger = new System.Windows.Forms.RadioButton();
			this.rbtnDataSet = new System.Windows.Forms.RadioButton();
			this.grpDataType.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Button1.Location = new System.Drawing.Point(8, 303);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(94, 36);
			this.Button1.TabIndex = 8;
			this.Button1.Text = "Create Data";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Button2.Location = new System.Drawing.Point(108, 303);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(94, 36);
			this.Button2.TabIndex = 9;
			this.Button2.Text = "Cancel";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//grpDataType
			//
			this.grpDataType.Controls.Add(this.rbtnDataSet);
			this.grpDataType.Controls.Add(this.rbtnCFList);
			this.grpDataType.Controls.Add(this.rbtnDataTable);
			this.grpDataType.Controls.Add(this.rbtnSortedList);
			this.grpDataType.Controls.Add(this.rbtnHash);
			this.grpDataType.Controls.Add(this.rbtnString);
			this.grpDataType.Controls.Add(this.rbtnBoolean);
			this.grpDataType.Controls.Add(this.rbtnDecimal);
			this.grpDataType.Controls.Add(this.rbtnInteger);
			this.grpDataType.Location = new System.Drawing.Point(40, 12);
			this.grpDataType.Name = "grpDataType";
			this.grpDataType.Size = new System.Drawing.Size(130, 285);
			this.grpDataType.TabIndex = 10;
			this.grpDataType.TabStop = false;
			this.grpDataType.Text = "Data Type ";
			//
			//rbtnCFList
			//
			this.rbtnCFList.AutoSize = true;
			this.rbtnCFList.Location = new System.Drawing.Point(20, 219);
			this.rbtnCFList.Name = "rbtnCFList";
			this.rbtnCFList.Size = new System.Drawing.Size(41, 17);
			this.rbtnCFList.TabIndex = 15;
			this.rbtnCFList.Text = "List";
			this.rbtnCFList.UseVisualStyleBackColor = true;
			//
			//rbtnDataTable
			//
			this.rbtnDataTable.AutoSize = true;
			this.rbtnDataTable.Location = new System.Drawing.Point(20, 94);
			this.rbtnDataTable.Name = "rbtnDataTable";
			this.rbtnDataTable.Size = new System.Drawing.Size(75, 17);
			this.rbtnDataTable.TabIndex = 14;
			this.rbtnDataTable.Text = "DataTable";
			this.rbtnDataTable.UseVisualStyleBackColor = true;
			//
			//rbtnSortedList
			//
			this.rbtnSortedList.AutoSize = true;
			this.rbtnSortedList.Location = new System.Drawing.Point(20, 194);
			this.rbtnSortedList.Name = "rbtnSortedList";
			this.rbtnSortedList.Size = new System.Drawing.Size(72, 17);
			this.rbtnSortedList.TabIndex = 13;
			this.rbtnSortedList.Text = "SortedList";
			this.rbtnSortedList.UseVisualStyleBackColor = true;
			//
			//rbtnHash
			//
			this.rbtnHash.AutoSize = true;
			this.rbtnHash.Location = new System.Drawing.Point(20, 169);
			this.rbtnHash.Name = "rbtnHash";
			this.rbtnHash.Size = new System.Drawing.Size(77, 17);
			this.rbtnHash.TabIndex = 12;
			this.rbtnHash.Text = "HashTable";
			this.rbtnHash.UseVisualStyleBackColor = true;
			//
			//rbtnString
			//
			this.rbtnString.AutoSize = true;
			this.rbtnString.Location = new System.Drawing.Point(20, 144);
			this.rbtnString.Name = "rbtnString";
			this.rbtnString.Size = new System.Drawing.Size(52, 17);
			this.rbtnString.TabIndex = 11;
			this.rbtnString.Text = "String";
			this.rbtnString.UseVisualStyleBackColor = true;
			//
			//rbtnBoolean
			//
			this.rbtnBoolean.AutoSize = true;
			this.rbtnBoolean.Location = new System.Drawing.Point(20, 69);
			this.rbtnBoolean.Name = "rbtnBoolean";
			this.rbtnBoolean.Size = new System.Drawing.Size(64, 17);
			this.rbtnBoolean.TabIndex = 2;
			this.rbtnBoolean.Text = "Boolean";
			this.rbtnBoolean.UseVisualStyleBackColor = true;
			//
			//rbtnDecimal
			//
			this.rbtnDecimal.AutoSize = true;
			this.rbtnDecimal.Location = new System.Drawing.Point(20, 44);
			this.rbtnDecimal.Name = "rbtnDecimal";
			this.rbtnDecimal.Size = new System.Drawing.Size(63, 17);
			this.rbtnDecimal.TabIndex = 1;
			this.rbtnDecimal.Text = "Decimal";
			this.rbtnDecimal.UseVisualStyleBackColor = true;
			//
			//rbtnInteger
			//
			this.rbtnInteger.AutoSize = true;
			this.rbtnInteger.Checked = true;
			this.rbtnInteger.Location = new System.Drawing.Point(20, 19);
			this.rbtnInteger.Name = "rbtnInteger";
			this.rbtnInteger.Size = new System.Drawing.Size(58, 17);
			this.rbtnInteger.TabIndex = 0;
			this.rbtnInteger.TabStop = true;
			this.rbtnInteger.Text = "Integer";
			this.rbtnInteger.UseVisualStyleBackColor = true;
			//
			//rbtnDataSet
			//
			this.rbtnDataSet.AutoSize = true;
			this.rbtnDataSet.Location = new System.Drawing.Point(20, 119);
			this.rbtnDataSet.Name = "rbtnDataSet";
			this.rbtnDataSet.Size = new System.Drawing.Size(64, 17);
			this.rbtnDataSet.TabIndex = 16;
			this.rbtnDataSet.Text = "DataSet";
			this.rbtnDataSet.UseVisualStyleBackColor = true;
			//
			//frmDataCreationSelectionForm
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(214, 351);
			this.ControlBox = false;
			this.Controls.Add(this.grpDataType);
			this.Controls.Add(this.Button2);
			this.Controls.Add(this.Button1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmDataCreationSelectionForm";
			this.Text = " ";
			this.grpDataType.ResumeLayout(false);
			this.grpDataType.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.GroupBox grpDataType;
		internal System.Windows.Forms.RadioButton rbtnInteger;
		internal System.Windows.Forms.RadioButton rbtnDataTable;
		internal System.Windows.Forms.RadioButton rbtnSortedList;
		internal System.Windows.Forms.RadioButton rbtnHash;
		internal System.Windows.Forms.RadioButton rbtnString;
		internal System.Windows.Forms.RadioButton rbtnBoolean;
		internal System.Windows.Forms.RadioButton rbtnDecimal;
		internal System.Windows.Forms.RadioButton rbtnCFList;
		internal System.Windows.Forms.RadioButton rbtnDataSet;
	}
	
}
