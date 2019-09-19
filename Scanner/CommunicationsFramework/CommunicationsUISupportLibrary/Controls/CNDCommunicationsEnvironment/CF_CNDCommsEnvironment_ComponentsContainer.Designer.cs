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
	partial class CF_CNDCommsEnvironment_ComponentsContainer : System.Windows.Forms.UserControl
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
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.Label1 = new System.Windows.Forms.Label();
			this.lstComponents = new System.Windows.Forms.ListBox();
			this.lstComponents.SelectedIndexChanged += new System.EventHandler(this.lstComponents_SelectedIndexChanged);
			this.btnAddNewComponent = new System.Windows.Forms.Button();
			this.btnAddNewComponent.Click += new System.EventHandler(this.btnAddNewComponent_Click);
			this.btnRemoveComponent = new System.Windows.Forms.Button();
			this.btnRemoveComponent.Click += new System.EventHandler(this.btnRemoveComponent_Click);
			this.tabComponentHandlers = new System.Windows.Forms.TabControl();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SuspendLayout();
			//
			//SplitContainer1
			//
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer1.Name = "SplitContainer1";
			//
			//SplitContainer1.Panel1
			//
			this.SplitContainer1.Panel1.Controls.Add(this.btnRemoveComponent);
			this.SplitContainer1.Panel1.Controls.Add(this.btnAddNewComponent);
			this.SplitContainer1.Panel1.Controls.Add(this.lstComponents);
			this.SplitContainer1.Panel1.Controls.Add(this.Label1);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.tabComponentHandlers);
			this.SplitContainer1.Size = new System.Drawing.Size(778, 473);
			this.SplitContainer1.SplitterDistance = 203;
			this.SplitContainer1.TabIndex = 0;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 7);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(200, 32);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Components that uses the " + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10)) + "STX Communications Scheme" + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10));
			//
			//lstComponents
			//
			this.lstComponents.FormattingEnabled = true;
			this.lstComponents.ItemHeight = 16;
			this.lstComponents.Location = new System.Drawing.Point(3, 42);
			this.lstComponents.Name = "lstComponents";
			this.lstComponents.Size = new System.Drawing.Size(197, 340);
			this.lstComponents.TabIndex = 1;
			//
			//btnAddNewComponent
			//
			this.btnAddNewComponent.Location = new System.Drawing.Point(6, 390);
			this.btnAddNewComponent.Name = "btnAddNewComponent";
			this.btnAddNewComponent.Size = new System.Drawing.Size(197, 35);
			this.btnAddNewComponent.TabIndex = 0;
			this.btnAddNewComponent.Text = "Add New Component";
			this.btnAddNewComponent.UseVisualStyleBackColor = true;
			//
			//btnRemoveComponent
			//
			this.btnRemoveComponent.Location = new System.Drawing.Point(6, 431);
			this.btnRemoveComponent.Name = "btnRemoveComponent";
			this.btnRemoveComponent.Size = new System.Drawing.Size(197, 35);
			this.btnRemoveComponent.TabIndex = 1;
			this.btnRemoveComponent.Text = "Remove Component";
			this.btnRemoveComponent.UseVisualStyleBackColor = true;
			//
			//tabComponentHandlers
			//
			this.tabComponentHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabComponentHandlers.Location = new System.Drawing.Point(0, 0);
			this.tabComponentHandlers.Name = "tabComponentHandlers";
			this.tabComponentHandlers.SelectedIndex = 0;
			this.tabComponentHandlers.Size = new System.Drawing.Size(571, 473);
			this.tabComponentHandlers.TabIndex = 0;
			//
			//CFSTXCommsEnvironment_ComponentsContainer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (8.0F), (float) (16.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.SplitContainer1);
			this.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "CFSTXCommsEnvironment_ComponentsContainer";
			this.Size = new System.Drawing.Size(778, 473);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel1.PerformLayout();
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ListBox lstComponents;
		internal System.Windows.Forms.Button btnRemoveComponent;
		internal System.Windows.Forms.Button btnAddNewComponent;
		internal System.Windows.Forms.TabControl tabComponentHandlers;
		
	}
	
}
