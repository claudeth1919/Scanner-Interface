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
	partial class CF_DPE_PublicationsPostHandlersContainer : System.Windows.Forms.UserControl
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
			this.tabPublicationHandlers = new System.Windows.Forms.TabControl();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SuspendLayout();
			//
			//tabPublicationHandlers
			//
			this.tabPublicationHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPublicationHandlers.Location = new System.Drawing.Point(0, 0);
			this.tabPublicationHandlers.Name = "tabPublicationHandlers";
			this.tabPublicationHandlers.SelectedIndex = 0;
			this.tabPublicationHandlers.Size = new System.Drawing.Size(740, 415);
			this.tabPublicationHandlers.TabIndex = 0;
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
			this.SplitContainer1.Panel1.Controls.Add(this.tabPublicationHandlers);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.Button2);
			this.SplitContainer1.Panel2.Controls.Add(this.Button1);
			this.SplitContainer1.Size = new System.Drawing.Size(740, 485);
			this.SplitContainer1.SplitterDistance = 415;
			this.SplitContainer1.TabIndex = 1;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(158, 1);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(149, 28);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "STOP All Simulations ";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(3, 0);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(149, 28);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "START All Simulations ";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//CF_DPE_PublicationsPostHandlersContainer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SplitContainer1);
			this.Name = "CF_DPE_PublicationsPostHandlersContainer";
			this.Size = new System.Drawing.Size(740, 485);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.TabControl tabPublicationHandlers;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button1;
		
	}
	
}
