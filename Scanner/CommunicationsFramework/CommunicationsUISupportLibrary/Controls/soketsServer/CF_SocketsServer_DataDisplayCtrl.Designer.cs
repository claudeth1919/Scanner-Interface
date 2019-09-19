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
	partial class CF_SocketsServer_DataDisplayCtrl : System.Windows.Forms.UserControl
	{
		
		//UserControl overrides dispose to clean up the component list.
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
			this.txtIntDecStringBol = new System.Windows.Forms.TextBox();
			this.dgrDataTable = new System.Windows.Forms.DataGridView();
			this.lstCollectionsDataType = new System.Windows.Forms.ListBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			((System.ComponentModel.ISupportInitialize) this.dgrDataTable).BeginInit();
			this.SuspendLayout();
			//
			//txtIntDecStringBol
			//
			this.txtIntDecStringBol.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtIntDecStringBol.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtIntDecStringBol.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtIntDecStringBol.Location = new System.Drawing.Point(3, 3);
			this.txtIntDecStringBol.Multiline = true;
			this.txtIntDecStringBol.Name = "txtIntDecStringBol";
			this.txtIntDecStringBol.ReadOnly = true;
			this.txtIntDecStringBol.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtIntDecStringBol.Size = new System.Drawing.Size(603, 194);
			this.txtIntDecStringBol.TabIndex = 0;
			this.txtIntDecStringBol.Visible = false;
			//
			//dgrDataTable
			//
			this.dgrDataTable.AllowUserToAddRows = false;
			this.dgrDataTable.AllowUserToDeleteRows = false;
			this.dgrDataTable.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.dgrDataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrDataTable.Location = new System.Drawing.Point(3, 3);
			this.dgrDataTable.Name = "dgrDataTable";
			this.dgrDataTable.ReadOnly = true;
			this.dgrDataTable.Size = new System.Drawing.Size(606, 194);
			this.dgrDataTable.TabIndex = 0;
			this.dgrDataTable.Visible = false;
			//
			//lstCollectionsDataType
			//
			this.lstCollectionsDataType.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lstCollectionsDataType.FormattingEnabled = true;
			this.lstCollectionsDataType.Location = new System.Drawing.Point(3, 3);
			this.lstCollectionsDataType.Name = "lstCollectionsDataType";
			this.lstCollectionsDataType.Size = new System.Drawing.Size(603, 186);
			this.lstCollectionsDataType.TabIndex = 0;
			this.lstCollectionsDataType.Visible = false;
			//
			//btnClear
			//
			this.btnClear.Anchor = (System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.btnClear.Location = new System.Drawing.Point(3, 195);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(189, 30);
			this.btnClear.TabIndex = 23;
			this.btnClear.Text = "Clear Data";
			this.btnClear.UseVisualStyleBackColor = true;
			//
			//CFDataDisplayCtrl
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (96.0F), (float) (96.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.lstCollectionsDataType);
			this.Controls.Add(this.dgrDataTable);
			this.Controls.Add(this.txtIntDecStringBol);
			this.Controls.Add(this.btnClear);
			this.Name = "CFDataDisplayCtrl";
			this.Size = new System.Drawing.Size(612, 228);
			((System.ComponentModel.ISupportInitialize) this.dgrDataTable).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		private System.Windows.Forms.TextBox txtIntDecStringBol;
		private System.Windows.Forms.DataGridView dgrDataTable;
		private System.Windows.Forms.ListBox lstCollectionsDataType;
		private System.Windows.Forms.Button btnClear;
		
	}
	
}
