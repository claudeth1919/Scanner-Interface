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
	partial class CF_DPE_PublicationSubscriptionHandler : System.Windows.Forms.UserControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CF_DPE_PublicationSubscriptionHandler));
			this.TabControl1 = new System.Windows.Forms.TabControl();
			base.Load += new System.EventHandler(CFSTXDSS_PublicationConnectionHandler_Load);
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.dgrdUPDATEStatistics = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.dgrdResetStatistics = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdUPDATEStatistics).BeginInit();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdResetStatistics).BeginInit();
			this.SuspendLayout();
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
			this.TabControl1.Size = new System.Drawing.Size(596, 417);
			this.TabControl1.TabIndex = 0;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.dgrdUPDATEStatistics);
			this.TabPage1.Location = new System.Drawing.Point(4, 24);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(588, 389);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data UPDATE Statistics";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//dgrdUPDATEStatistics
			//
			this.dgrdUPDATEStatistics.ColumnInfo = "0,0,0,0,0,90,Columns:";
			this.dgrdUPDATEStatistics.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgrdUPDATEStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdUPDATEStatistics.Location = new System.Drawing.Point(3, 3);
			this.dgrdUPDATEStatistics.Name = "dgrdUPDATEStatistics";
			this.dgrdUPDATEStatistics.Rows.DefaultSize = 18;
			this.dgrdUPDATEStatistics.Size = new System.Drawing.Size(582, 383);
			this.dgrdUPDATEStatistics.TabIndex = 1;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.dgrdResetStatistics);
			this.TabPage2.Location = new System.Drawing.Point(4, 24);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(588, 389);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Data RESET Statistics";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//dgrdResetStatistics
			//
			this.dgrdResetStatistics.ColumnInfo = "0,0,0,0,0,90,Columns:";
			this.dgrdResetStatistics.Cursor = System.Windows.Forms.Cursors.Default;
			this.dgrdResetStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdResetStatistics.Location = new System.Drawing.Point(3, 3);
			this.dgrdResetStatistics.Name = "dgrdResetStatistics";
			this.dgrdResetStatistics.Rows.DefaultSize = 18;
			this.dgrdResetStatistics.Size = new System.Drawing.Size(582, 383);
			this.dgrdResetStatistics.TabIndex = 1;
			//
			//CFSTXDSS_PublicationConnectionHandler
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TabControl1);
			this.Name = "CFSTXDSS_PublicationConnectionHandler";
			this.Size = new System.Drawing.Size(596, 417);
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdUPDATEStatistics).EndInit();
			this.TabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdResetStatistics).EndInit();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal C1.Win.C1FlexGrid.C1FlexGrid dgrdUPDATEStatistics;
		internal C1.Win.C1FlexGrid.C1FlexGrid dgrdResetStatistics;
		
	}
	
}
