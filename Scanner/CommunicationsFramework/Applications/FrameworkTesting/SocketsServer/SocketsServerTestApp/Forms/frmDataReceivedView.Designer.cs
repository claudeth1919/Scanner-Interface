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


namespace SocketsServerTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDataReceivedView : System.Windows.Forms.Form
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
			this.TabControl1 = new System.Windows.Forms.TabControl();
			base.Load += new System.EventHandler(frmDataReceivedView_Load);
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.txtXML = new System.Windows.Forms.TextBox();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SuspendLayout();
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(819, 494);
			this.TabControl1.TabIndex = 0;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.CfDataDisplayCtrl1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(811, 468);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data View";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//CfDataDisplayCtrl1
			//
			this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataDisplayCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
			this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
			this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(805, 462);
			this.CfDataDisplayCtrl1.TabIndex = 1;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.txtXML);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(811, 468);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "XML";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//txtXML
			//
			this.txtXML.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtXML.Location = new System.Drawing.Point(3, 3);
			this.txtXML.Multiline = true;
			this.txtXML.Name = "txtXML";
			this.txtXML.ReadOnly = true;
			this.txtXML.Size = new System.Drawing.Size(805, 462);
			this.txtXML.TabIndex = 0;
			//
			//SplitContainer1
			//
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.SplitContainer1.IsSplitterFixed = true;
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
			this.SplitContainer1.Size = new System.Drawing.Size(819, 554);
			this.SplitContainer1.SplitterDistance = 494;
			this.SplitContainer1.TabIndex = 1;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(343, 12);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(121, 32);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Ok";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//frmDataReceivedView
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(819, 554);
			this.ControlBox = false;
			this.Controls.Add(this.SplitContainer1);
			this.Name = "frmDataReceivedView";
			this.Text = "frmDataReceivedView";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.TextBox txtXML;
		internal System.Windows.Forms.Button Button1;
	}
	
}
