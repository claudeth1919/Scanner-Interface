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


namespace DPEServerClientApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmTreeViewZoomView : System.Windows.Forms.Form
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
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(frmZoomView_Load);
			this.Resize += new System.EventHandler(frmZoomView_Resize);
			Klik.Windows.Forms.v1.Common.PaintStyle PaintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
			this.KFormManager1 = new Klik.Windows.Forms.v1.Common.KFormManager(this.components);
			this.spltrMain = new System.Windows.Forms.SplitContainer();
			this.spltrHeader = new System.Windows.Forms.SplitContainer();
			this.lblHEaderLabelTExt = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
			this.btnClientConnsTreeViewCollapseAll = new System.Windows.Forms.Button();
			this.btnClientConnsTreeViewCollapseAll.Click += new System.EventHandler(this.btnClientConnsTreeViewCollapseAll_Click);
			this.btnClientConnsTreeViewExpandAll = new System.Windows.Forms.Button();
			this.btnClientConnsTreeViewExpandAll.Click += new System.EventHandler(this.btnClientConnsTreeViewExpandAll_Click);
			this.btnOk = new Klik.Windows.Forms.v1.EntryLib.ELButton();
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			((System.ComponentModel.ISupportInitialize) this.KFormManager1).BeginInit();
			this.spltrMain.Panel1.SuspendLayout();
			this.spltrMain.SuspendLayout();
			this.spltrHeader.Panel1.SuspendLayout();
			this.spltrHeader.Panel2.SuspendLayout();
			this.spltrHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.lblHEaderLabelTExt).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.btnOk).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.SuspendLayout();
			//
			//KFormManager1
			//
			this.KFormManager1.BackgroundImageStyle.Alpha = 100;
			this.KFormManager1.BackgroundImageStyle.ImageEffect = Klik.Windows.Forms.v1.Common.ImageEffect.Mirror;
			this.KFormManager1.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
			this.KFormManager1.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Rectangle;
			this.KFormManager1.FormOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
			this.KFormManager1.MainContainer = this;
			this.KFormManager1.ToolStripOffice2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
			//
			//spltrMain
			//
			this.spltrMain.BackColor = System.Drawing.Color.Transparent;
			this.spltrMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrMain.IsSplitterFixed = true;
			this.spltrMain.Location = new System.Drawing.Point(0, 0);
			this.spltrMain.Margin = new System.Windows.Forms.Padding(4);
			this.spltrMain.Name = "spltrMain";
			this.spltrMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrMain.Panel1
			//
			this.spltrMain.Panel1.Controls.Add(this.spltrHeader);
			this.spltrMain.Size = new System.Drawing.Size(1284, 778);
			this.spltrMain.SplitterDistance = 41;
			this.spltrMain.SplitterWidth = 6;
			this.spltrMain.TabIndex = 0;
			//
			//spltrHeader
			//
			this.spltrHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.spltrHeader.IsSplitterFixed = true;
			this.spltrHeader.Location = new System.Drawing.Point(0, 0);
			this.spltrHeader.Name = "spltrHeader";
			//
			//spltrHeader.Panel1
			//
			this.spltrHeader.Panel1.Controls.Add(this.lblHEaderLabelTExt);
			//
			//spltrHeader.Panel2
			//
			this.spltrHeader.Panel2.Controls.Add(this.btnClientConnsTreeViewCollapseAll);
			this.spltrHeader.Panel2.Controls.Add(this.btnClientConnsTreeViewExpandAll);
			this.spltrHeader.Panel2.Controls.Add(this.btnOk);
			this.spltrHeader.Size = new System.Drawing.Size(1284, 41);
			this.spltrHeader.SplitterDistance = 1114;
			this.spltrHeader.TabIndex = 0;
			//
			//lblHEaderLabelTExt
			//
			this.lblHEaderLabelTExt.Dock = System.Windows.Forms.DockStyle.Fill;
			PaintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
			PaintStyle1.SolidColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(253)), System.Convert.ToInt32(System.Convert.ToByte(240)), System.Convert.ToInt32(System.Convert.ToByte(191)));
			this.lblHEaderLabelTExt.FlashStyle = PaintStyle1;
			this.lblHEaderLabelTExt.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
			this.lblHEaderLabelTExt.Location = new System.Drawing.Point(0, 0);
			this.lblHEaderLabelTExt.Name = "lblHEaderLabelTExt";
			this.lblHEaderLabelTExt.Size = new System.Drawing.Size(1114, 41);
			this.lblHEaderLabelTExt.TabIndex = 50;
			this.lblHEaderLabelTExt.TabStop = false;
			this.lblHEaderLabelTExt.TextStyle.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lblHEaderLabelTExt.TextStyle.Text = "None";
			this.lblHEaderLabelTExt.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//btnClientConnsTreeViewCollapseAll
			//
			this.btnClientConnsTreeViewCollapseAll.BackgroundImage = global::My.Resources.Resources.CollapseTree;
			this.btnClientConnsTreeViewCollapseAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnClientConnsTreeViewCollapseAll.Location = new System.Drawing.Point(112, 0);
			this.btnClientConnsTreeViewCollapseAll.Name = "btnClientConnsTreeViewCollapseAll";
			this.btnClientConnsTreeViewCollapseAll.Size = new System.Drawing.Size(53, 41);
			this.btnClientConnsTreeViewCollapseAll.TabIndex = 51;
			this.btnClientConnsTreeViewCollapseAll.UseVisualStyleBackColor = true;
			//
			//btnClientConnsTreeViewExpandAll
			//
			this.btnClientConnsTreeViewExpandAll.BackgroundImage = global::My.Resources.Resources.ExpandTree;
			this.btnClientConnsTreeViewExpandAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnClientConnsTreeViewExpandAll.Location = new System.Drawing.Point(61, 0);
			this.btnClientConnsTreeViewExpandAll.Name = "btnClientConnsTreeViewExpandAll";
			this.btnClientConnsTreeViewExpandAll.Size = new System.Drawing.Size(53, 41);
			this.btnClientConnsTreeViewExpandAll.TabIndex = 50;
			this.btnClientConnsTreeViewExpandAll.UseVisualStyleBackColor = true;
			//
			//btnOk
			//
			this.btnOk.BackgroundImageStyle.Alpha = 100;
			this.btnOk.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
			this.btnOk.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(253)), System.Convert.ToInt32(System.Convert.ToByte(240)), System.Convert.ToInt32(System.Convert.ToByte(191)));
			this.btnOk.ForegroundImageStyle.Image = global::My.Resources.Resources.zoom_out;
			this.btnOk.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnOk.Location = new System.Drawing.Point(0, 0);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
			this.btnOk.Size = new System.Drawing.Size(53, 41);
			this.btnOk.TabIndex = 49;
			this.btnOk.TextStyle.BackColor = System.Drawing.Color.Black;
			this.btnOk.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (16.25F), System.Drawing.FontStyle.Bold);
			this.btnOk.TextStyle.ForeColor = System.Drawing.Color.Lime;
			this.btnOk.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
			this.btnOk.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.System;
			//
			//frmTreeViewZoomView
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1284, 778);
			this.ControlBox = false;
			this.Controls.Add(this.spltrMain);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmTreeViewZoomView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "View";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize) this.KFormManager1).EndInit();
			this.spltrMain.Panel1.ResumeLayout(false);
			this.spltrMain.ResumeLayout(false);
			this.spltrHeader.Panel1.ResumeLayout(false);
			this.spltrHeader.Panel2.ResumeLayout(false);
			this.spltrHeader.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.lblHEaderLabelTExt).EndInit();
			((System.ComponentModel.ISupportInitialize) this.btnOk).EndInit();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			
		}
		internal Klik.Windows.Forms.v1.Common.KFormManager KFormManager1;
		internal System.Windows.Forms.SplitContainer spltrMain;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnOk;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel lblHEaderLabelTExt;
		internal System.Windows.Forms.SplitContainer spltrHeader;
		internal System.Windows.Forms.Button btnClientConnsTreeViewCollapseAll;
		internal System.Windows.Forms.Button btnClientConnsTreeViewExpandAll;
	}
	
}
