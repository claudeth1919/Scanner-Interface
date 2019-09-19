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
	partial class frm_DPE_SimulationStatistics : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DPE_SimulationStatistics));
			this.Button1 = new System.Windows.Forms.Button();
			base.Load += new System.EventHandler(frmSTXDSS_SimulationStatistics_Load);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.dgrdUPDATEStatisticsTable = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.dgrdRESETStatiticsTAble = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdUPDATEStatisticsTable).BeginInit();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdRESETStatiticsTAble).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(418, 3);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(121, 50);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Close";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(963, 559);
			this.TabControl1.TabIndex = 1;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.dgrdUPDATEStatisticsTable);
			this.TabPage1.Location = new System.Drawing.Point(4, 24);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(955, 531);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data UPDATE Statistics";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//dgrdUPDATEStatisticsTable
			//
			this.dgrdUPDATEStatisticsTable.AllowEditing = false;
			this.dgrdUPDATEStatisticsTable.ColumnInfo = "0,0,0,0,0,90,Columns:";
			this.dgrdUPDATEStatisticsTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdUPDATEStatisticsTable.Location = new System.Drawing.Point(3, 3);
			this.dgrdUPDATEStatisticsTable.Name = "dgrdUPDATEStatisticsTable";
			this.dgrdUPDATEStatisticsTable.Rows.DefaultSize = 18;
			this.dgrdUPDATEStatisticsTable.Size = new System.Drawing.Size(949, 525);
			this.dgrdUPDATEStatisticsTable.TabIndex = 1;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.dgrdRESETStatiticsTAble);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(955, 533);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Data RESET Statistics";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//dgrdRESETStatiticsTAble
			//
			this.dgrdRESETStatiticsTAble.AllowEditing = false;
			this.dgrdRESETStatiticsTAble.ColumnInfo = "0,0,0,0,0,90,Columns:";
			this.dgrdRESETStatiticsTAble.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdRESETStatiticsTAble.Location = new System.Drawing.Point(3, 3);
			this.dgrdRESETStatiticsTAble.Name = "dgrdRESETStatiticsTAble";
			this.dgrdRESETStatiticsTAble.Rows.DefaultSize = 18;
			this.dgrdRESETStatiticsTAble.Size = new System.Drawing.Size(949, 527);
			this.dgrdRESETStatiticsTAble.TabIndex = 2;
			//
			//SplitContainer1
			//
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//SplitContainer1.Panel1
			//
			this.SplitContainer1.Panel1.Controls.Add(this.TabControl1);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.Button1);
			this.SplitContainer1.Size = new System.Drawing.Size(963, 632);
			this.SplitContainer1.SplitterDistance = 559;
			this.SplitContainer1.TabIndex = 2;
			//
			//frm_DPE_SimulationStatistics
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(963, 632);
			this.ControlBox = false;
			this.Controls.Add(this.SplitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frm_DPE_SimulationStatistics";
			this.ShowInTaskbar = false;
			this.Text = "frm_DPE_SimulationStatistics";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdUPDATEStatisticsTable).EndInit();
			this.TabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdRESETStatiticsTAble).EndInit();
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal C1.Win.C1FlexGrid.C1FlexGrid dgrdUPDATEStatisticsTable;
		internal C1.Win.C1FlexGrid.C1FlexGrid dgrdRESETStatiticsTAble;
	}
	
}
