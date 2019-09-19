// VBConversions Note: VB project level imports
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
// End of VB project level imports


namespace CNDServerApplication
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmCNDServerApplication : System.Windows.Forms.Form
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
            this.dgrdServiceParameters = new System.Windows.Forms.DataGridView();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabpServiceParameters = new System.Windows.Forms.TabPage();
            this.tabpCNDTable = new System.Windows.Forms.TabPage();
            this.btnUpdateCNDTable = new System.Windows.Forms.Button();
            this.dgrdCNDTable = new System.Windows.Forms.DataGridView();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.btnCloseService = new System.Windows.Forms.Button();
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.Button1 = new System.Windows.Forms.Button();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cF_NetworkStatistics1 = new CommunicationsLibrary.VisualControlsUtilities.NetworkStatistics.CF_NetworkStatistics();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServiceParameters)).BeginInit();
            this.TabControl1.SuspendLayout();
            this.tabpServiceParameters.SuspendLayout();
            this.tabpCNDTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCNDTable)).BeginInit();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrdServiceParameters
            // 
            this.dgrdServiceParameters.AllowUserToAddRows = false;
            this.dgrdServiceParameters.AllowUserToDeleteRows = false;
            this.dgrdServiceParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdServiceParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdServiceParameters.Location = new System.Drawing.Point(3, 3);
            this.dgrdServiceParameters.Name = "dgrdServiceParameters";
            this.dgrdServiceParameters.ReadOnly = true;
            this.dgrdServiceParameters.Size = new System.Drawing.Size(868, 451);
            this.dgrdServiceParameters.TabIndex = 0;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.tabpServiceParameters);
            this.TabControl1.Controls.Add(this.tabpCNDTable);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Location = new System.Drawing.Point(1, 1);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(882, 486);
            this.TabControl1.TabIndex = 1;
            // 
            // tabpServiceParameters
            // 
            this.tabpServiceParameters.Controls.Add(this.dgrdServiceParameters);
            this.tabpServiceParameters.Location = new System.Drawing.Point(4, 25);
            this.tabpServiceParameters.Name = "tabpServiceParameters";
            this.tabpServiceParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabpServiceParameters.Size = new System.Drawing.Size(874, 457);
            this.tabpServiceParameters.TabIndex = 0;
            this.tabpServiceParameters.Text = "Service Parameters";
            this.tabpServiceParameters.UseVisualStyleBackColor = true;
            // 
            // tabpCNDTable
            // 
            this.tabpCNDTable.Controls.Add(this.btnUpdateCNDTable);
            this.tabpCNDTable.Controls.Add(this.dgrdCNDTable);
            this.tabpCNDTable.Location = new System.Drawing.Point(4, 25);
            this.tabpCNDTable.Name = "tabpCNDTable";
            this.tabpCNDTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabpCNDTable.Size = new System.Drawing.Size(874, 457);
            this.tabpCNDTable.TabIndex = 1;
            this.tabpCNDTable.Text = "CND Table";
            this.tabpCNDTable.UseVisualStyleBackColor = true;
            // 
            // btnUpdateCNDTable
            // 
            this.btnUpdateCNDTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateCNDTable.Location = new System.Drawing.Point(0, 351);
            this.btnUpdateCNDTable.Name = "btnUpdateCNDTable";
            this.btnUpdateCNDTable.Size = new System.Drawing.Size(137, 29);
            this.btnUpdateCNDTable.TabIndex = 2;
            this.btnUpdateCNDTable.Text = "Update CND Table";
            this.btnUpdateCNDTable.UseVisualStyleBackColor = true;
            this.btnUpdateCNDTable.Click += new System.EventHandler(this.btnUpdateCNDTable_Click);
            // 
            // dgrdCNDTable
            // 
            this.dgrdCNDTable.AllowUserToAddRows = false;
            this.dgrdCNDTable.AllowUserToDeleteRows = false;
            this.dgrdCNDTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrdCNDTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdCNDTable.Location = new System.Drawing.Point(3, 3);
            this.dgrdCNDTable.Name = "dgrdCNDTable";
            this.dgrdCNDTable.ReadOnly = true;
            this.dgrdCNDTable.Size = new System.Drawing.Size(805, 342);
            this.dgrdCNDTable.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.btnClearLog);
            this.TabPage1.Controls.Add(this.lstSTXEventLog);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(874, 457);
            this.TabPage1.TabIndex = 2;
            this.TabPage1.Text = "STX Event Log";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(3, 418);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(103, 33);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.HorizontalScrollbar = true;
            this.lstSTXEventLog.ItemHeight = 15;
            this.lstSTXEventLog.Location = new System.Drawing.Point(3, 3);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.ScrollAlwaysVisible = true;
            this.lstSTXEventLog.Size = new System.Drawing.Size(871, 409);
            this.lstSTXEventLog.TabIndex = 0;
            this.lstSTXEventLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSTXEventLog_MouseDoubleClick);
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.cF_NetworkStatistics1);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(874, 457);
            this.TabPage2.TabIndex = 3;
            this.TabPage2.Text = "Network Statistics";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCloseService
            // 
            this.btnCloseService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseService.Location = new System.Drawing.Point(8, 493);
            this.btnCloseService.Name = "btnCloseService";
            this.btnCloseService.Size = new System.Drawing.Size(106, 42);
            this.btnCloseService.TabIndex = 1;
            this.btnCloseService.Text = "Close Service";
            this.btnCloseService.UseVisualStyleBackColor = true;
            this.btnCloseService.Click += new System.EventHandler(this.btnCloseService_Click);
            // 
            // C1SizerLight1
            // 
            this.C1SizerLight1.ResizeFonts = false;
            // 
            // Button1
            // 
            this.Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Button1.Location = new System.Drawing.Point(632, 493);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(225, 42);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Export Service Parameters  to File";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // cF_NetworkStatistics1
            // 
            this.cF_NetworkStatistics1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cF_NetworkStatistics1.Location = new System.Drawing.Point(3, 3);
            this.cF_NetworkStatistics1.Margin = new System.Windows.Forms.Padding(4);
            this.cF_NetworkStatistics1.Name = "cF_NetworkStatistics1";
            this.cF_NetworkStatistics1.Size = new System.Drawing.Size(868, 451);
            this.cF_NetworkStatistics1.TabIndex = 0;
            // 
            // frmCNDServerApplication
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 547);
            this.ControlBox = false;
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.btnCloseService);
            this.Controls.Add(this.TabControl1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCNDServerApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CND Service Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCNDServiceApplication_FormClosing);
            this.Load += new System.EventHandler(this.frmCNDServiceApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServiceParameters)).EndInit();
            this.TabControl1.ResumeLayout(false);
            this.tabpServiceParameters.ResumeLayout(false);
            this.tabpCNDTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCNDTable)).EndInit();
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.DataGridView dgrdServiceParameters;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage tabpServiceParameters;
		internal System.Windows.Forms.TabPage tabpCNDTable;
		internal System.Windows.Forms.DataGridView dgrdCNDTable;
		internal System.Windows.Forms.Button btnCloseService;
		internal System.Windows.Forms.Button btnUpdateCNDTable;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.Button btnClearLog;
        internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        private System.ComponentModel.IContainer components;
        private CommunicationsLibrary.VisualControlsUtilities.NetworkStatistics.CF_NetworkStatistics cF_NetworkStatistics1;
		
	}
	
}
