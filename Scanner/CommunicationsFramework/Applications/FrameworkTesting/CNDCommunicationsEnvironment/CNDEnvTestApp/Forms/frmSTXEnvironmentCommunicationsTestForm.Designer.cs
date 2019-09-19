using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;


namespace CNDEnvTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmSTXCommunicationsEnvironmentTestForm : System.Windows.Forms.Form
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
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnUpdateCNDTable = new System.Windows.Forms.Button();
            this.dgrdCNDTable = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.CfstxCommsEnvironment_ComponentsContainer1 = new CommunicationsUISupportLibrary.CF_CNDCommsEnvironment_ComponentsContainer();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCNDTable)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1053, 617);
            this.TabControl1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btnUpdateCNDTable);
            this.TabPage1.Controls.Add(this.dgrdCNDTable);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage1.Size = new System.Drawing.Size(1045, 588);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Local STX Component Network Directory Table";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCNDTable
            // 
            this.btnUpdateCNDTable.Location = new System.Drawing.Point(876, 550);
            this.btnUpdateCNDTable.Name = "btnUpdateCNDTable";
            this.btnUpdateCNDTable.Size = new System.Drawing.Size(155, 37);
            this.btnUpdateCNDTable.TabIndex = 1;
            this.btnUpdateCNDTable.Text = "Update CND table";
            this.btnUpdateCNDTable.UseVisualStyleBackColor = true;
            this.btnUpdateCNDTable.Click += new System.EventHandler(this.btnUpdateCNDTable_Click);
            // 
            // dgrdCNDTable
            // 
            this.dgrdCNDTable.AllowUserToAddRows = false;
            this.dgrdCNDTable.AllowUserToDeleteRows = false;
            this.dgrdCNDTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdCNDTable.Location = new System.Drawing.Point(7, 7);
            this.dgrdCNDTable.Name = "dgrdCNDTable";
            this.dgrdCNDTable.ReadOnly = true;
            this.dgrdCNDTable.Size = new System.Drawing.Size(1035, 543);
            this.dgrdCNDTable.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.CfstxCommsEnvironment_ComponentsContainer1);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage2.Size = new System.Drawing.Size(1045, 588);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Communications Components Emulation";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // CfstxCommsEnvironment_ComponentsContainer1
            // 
            this.CfstxCommsEnvironment_ComponentsContainer1.AutoSize = true;
            this.CfstxCommsEnvironment_ComponentsContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CfstxCommsEnvironment_ComponentsContainer1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CfstxCommsEnvironment_ComponentsContainer1.Location = new System.Drawing.Point(4, 4);
            this.CfstxCommsEnvironment_ComponentsContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.CfstxCommsEnvironment_ComponentsContainer1.Name = "CfstxCommsEnvironment_ComponentsContainer1";
            this.CfstxCommsEnvironment_ComponentsContainer1.Size = new System.Drawing.Size(1037, 580);
            this.CfstxCommsEnvironment_ComponentsContainer1.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.SplitContainer1);
            this.TabPage3.Location = new System.Drawing.Point(4, 25);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(1045, 588);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "EVent Log";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.lstSTXEventLog);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.btnClearLog);
            this.SplitContainer1.Size = new System.Drawing.Size(1039, 582);
            this.SplitContainer1.SplitterDistance = 539;
            this.SplitContainer1.TabIndex = 4;
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSTXEventLog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.HorizontalScrollbar = true;
            this.lstSTXEventLog.ItemHeight = 15;
            this.lstSTXEventLog.Location = new System.Drawing.Point(0, 0);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.ScrollAlwaysVisible = true;
            this.lstSTXEventLog.Size = new System.Drawing.Size(1039, 539);
            this.lstSTXEventLog.TabIndex = 2;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(931, 3);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(103, 33);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // frmSTXCommunicationsEnvironmentTestForm
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 617);
            this.Controls.Add(this.TabControl1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSTXCommunicationsEnvironmentTestForm";
            this.Text = "STX Communications Environment Test Application";
            this.Load += new System.EventHandler(this.frmSTXCommunicationsEnvironmentTestForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCNDTable)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage2.PerformLayout();
            this.TabPage3.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal CommunicationsUISupportLibrary.CF_CNDCommsEnvironment_ComponentsContainer CfstxCommsEnvironment_ComponentsContainer1;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.Button btnUpdateCNDTable;
		internal System.Windows.Forms.DataGridView dgrdCNDTable;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.Button btnClearLog;
        private System.ComponentModel.IContainer components;
		
	}
	
}
