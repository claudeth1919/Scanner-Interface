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


namespace CNDServiceClient
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmCNDClientMAinform : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCNDClientMAinform));
            this.tabMainTab = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.dgrdServicePArams = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdConnectedComponents = new System.Windows.Forms.DataGridView();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.Button1 = new System.Windows.Forms.Button();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabMainTab.SuspendLayout();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServicePArams)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdConnectedComponents)).BeginInit();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMainTab
            // 
            this.tabMainTab.Controls.Add(this.TabPage3);
            this.tabMainTab.Controls.Add(this.TabPage2);
            this.tabMainTab.Controls.Add(this.TabPage1);
            this.tabMainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMainTab.Location = new System.Drawing.Point(0, 0);
            this.tabMainTab.Margin = new System.Windows.Forms.Padding(4);
            this.tabMainTab.Name = "tabMainTab";
            this.tabMainTab.SelectedIndex = 0;
            this.tabMainTab.Size = new System.Drawing.Size(979, 328);
            this.tabMainTab.TabIndex = 0;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.dgrdServicePArams);
            this.TabPage3.Location = new System.Drawing.Point(4, 25);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(971, 299);
            this.TabPage3.TabIndex = 3;
            this.TabPage3.Text = "SErvice Parameters";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // dgrdServicePArams
            // 
            this.dgrdServicePArams.AllowUserToAddRows = false;
            this.dgrdServicePArams.AllowUserToDeleteRows = false;
            this.dgrdServicePArams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdServicePArams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdServicePArams.Location = new System.Drawing.Point(3, 3);
            this.dgrdServicePArams.Name = "dgrdServicePArams";
            this.dgrdServicePArams.ReadOnly = true;
            this.dgrdServicePArams.Size = new System.Drawing.Size(965, 293);
            this.dgrdServicePArams.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.dgrdConnectedComponents);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.TabPage2.Size = new System.Drawing.Size(971, 299);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Connections To Service";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdConnectedComponents
            // 
            this.dgrdConnectedComponents.AllowUserToAddRows = false;
            this.dgrdConnectedComponents.AllowUserToDeleteRows = false;
            this.dgrdConnectedComponents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdConnectedComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdConnectedComponents.Location = new System.Drawing.Point(4, 4);
            this.dgrdConnectedComponents.Margin = new System.Windows.Forms.Padding(4);
            this.dgrdConnectedComponents.Name = "dgrdConnectedComponents";
            this.dgrdConnectedComponents.ReadOnly = true;
            this.dgrdConnectedComponents.Size = new System.Drawing.Size(963, 291);
            this.dgrdConnectedComponents.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.Button1);
            this.TabPage1.Controls.Add(this.lstSTXEventLog);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(971, 302);
            this.TabPage1.TabIndex = 2;
            this.TabPage1.Text = "STX Event Log";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(821, 325);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(142, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.ItemHeight = 16;
            this.lstSTXEventLog.Location = new System.Drawing.Point(0, 0);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.Size = new System.Drawing.Size(971, 324);
            this.lstSTXEventLog.TabIndex = 0;
            this.lstSTXEventLog.DoubleClick += new System.EventHandler(this.lstSTXEventLog_DoubleClick);
            // 
            // C1SizerLight1
            // 
            this.C1SizerLight1.ResizeFonts = false;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.tabMainTab);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.btnRefresh);
            this.SplitContainer1.Size = new System.Drawing.Size(979, 380);
            this.SplitContainer1.SplitterDistance = 328;
            this.SplitContainer1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(872, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 42);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmCNDClientMAinform
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 380);
            this.Controls.Add(this.SplitContainer1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCNDClientMAinform";
            this.Text = "STX - SVMet  CND Service Client ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCNDClientMAinform_FormClosing);
            this.Load += new System.EventHandler(this.frmCNDClientMAinform_Load);
            this.tabMainTab.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServicePArams)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdConnectedComponents)).EndInit();
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.TabControl tabMainTab;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.DataGridView dgrdConnectedComponents;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.Button btnRefresh;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.DataGridView dgrdServicePArams;
        private System.ComponentModel.IContainer components;
	}
	
}
