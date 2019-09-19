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
	partial class frmListViewItemZoomView : System.Windows.Forms.Form
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
			this.Resize += new System.EventHandler(frmListViewItemZoomView_Resize);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListViewItemZoomView));
			this.KFormManager1 = new Klik.Windows.Forms.v1.Common.KFormManager(this.components);
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.c1FlxGrdListview = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.btnOk = new Klik.Windows.Forms.v1.EntryLib.ELButton();
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			((System.ComponentModel.ISupportInitialize) this.KFormManager1).BeginInit();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.c1FlxGrdListview).BeginInit();
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
			//SplitContainer1
			//
			this.SplitContainer1.BackColor = System.Drawing.Color.Transparent;
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.SplitContainer1.Name = "SplitContainer1";
			this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//SplitContainer1.Panel1
			//
			this.SplitContainer1.Panel1.Controls.Add(this.c1FlxGrdListview);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.btnOk);
			this.SplitContainer1.Size = new System.Drawing.Size(706, 618);
			this.SplitContainer1.SplitterDistance = 552;
			this.SplitContainer1.SplitterWidth = 6;
			this.SplitContainer1.TabIndex = 0;
			//
			//c1FlxGrdListview
			//
			this.c1FlxGrdListview.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
			this.c1FlxGrdListview.AllowEditing = false;
			this.c1FlxGrdListview.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
			this.c1FlxGrdListview.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes;
			this.c1FlxGrdListview.ColumnInfo = "2,1,0,0,0,110,Columns:";
			this.c1FlxGrdListview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.c1FlxGrdListview.EditOptions = C1.Win.C1FlexGrid.EditFlags.None;
			this.c1FlxGrdListview.ExtendLastCol = true;
			this.c1FlxGrdListview.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Heavy;
			this.c1FlxGrdListview.Location = new System.Drawing.Point(0, 0);
			this.c1FlxGrdListview.Name = "c1FlxGrdListview";
			this.c1FlxGrdListview.Rows.Count = 0;
			this.c1FlxGrdListview.Rows.DefaultSize = 22;
			this.c1FlxGrdListview.Rows.Fixed = 0;
			this.c1FlxGrdListview.ShowSort = false;
			this.c1FlxGrdListview.Size = new System.Drawing.Size(706, 552);
			this.c1FlxGrdListview.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("c1FlxGrdListview.Styles"));
			this.c1FlxGrdListview.TabIndex = 1;
			//
			//btnOk
			//
			this.btnOk.BackgroundImageStyle.Alpha = 100;
			this.btnOk.BackgroundImageStyle.Image = (System.Drawing.Image) (resources.GetObject("resource.Image"));
			this.btnOk.BackgroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
			this.btnOk.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(253)), System.Convert.ToInt32(System.Convert.ToByte(240)), System.Convert.ToInt32(System.Convert.ToByte(191)));
			this.btnOk.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnOk.Location = new System.Drawing.Point(266, 4);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
			this.btnOk.Size = new System.Drawing.Size(144, 47);
			this.btnOk.TabIndex = 49;
			this.btnOk.TextStyle.BackColor = System.Drawing.Color.Black;
			this.btnOk.TextStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (16.25F), System.Drawing.FontStyle.Bold);
			this.btnOk.TextStyle.ForeColor = System.Drawing.Color.Lime;
			this.btnOk.TextStyle.Text = "Close ";
			this.btnOk.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnOk.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
			//
			//frmListViewItemZoomView
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (9.0F), (float) (18.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(706, 618);
			this.ControlBox = false;
			this.Controls.Add(this.SplitContainer1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "frmListViewItemZoomView";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "View";
			((System.ComponentModel.ISupportInitialize) this.KFormManager1).EndInit();
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.c1FlxGrdListview).EndInit();
			((System.ComponentModel.ISupportInitialize) this.btnOk).EndInit();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			
		}
		internal Klik.Windows.Forms.v1.Common.KFormManager KFormManager1;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnOk;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal C1.Win.C1FlexGrid.C1FlexGrid c1FlxGrdListview;
	}
	
}
