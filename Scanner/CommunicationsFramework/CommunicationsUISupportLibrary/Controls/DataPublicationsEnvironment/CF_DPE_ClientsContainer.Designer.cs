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
	partial class CF_DPE_ClientsContainer : System.Windows.Forms.UserControl
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
			this.lstBoxClients = new System.Windows.Forms.ListBox();
			this.lstBoxClients.SelectedIndexChanged += new System.EventHandler(this.lstBoxClients_SelectedIndexChanged);
			base.Load += new System.EventHandler(CFSTXDSS_ClientsContainer_Load);
			this.TabClients = new System.Windows.Forms.TabControl();
			this.Label1 = new System.Windows.Forms.Label();
			this.btnCreateClient = new System.Windows.Forms.Button();
			this.btnCreateClient.Click += new System.EventHandler(this.btnCreateClient_Click);
			this.btnDisposeClient = new System.Windows.Forms.Button();
			this.btnDisposeClient.Click += new System.EventHandler(this.btnDisposeClient_Click);
			this.spCtnrMainContainer = new System.Windows.Forms.SplitContainer();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
			this.spltrClients = new System.Windows.Forms.SplitContainer();
			this.btnHideShowClientsList = new System.Windows.Forms.Button();
			this.btnHideShowClientsList.Click += new System.EventHandler(this.btnHideShowClientsList_Click);
			this.spCtnrMainContainer.Panel1.SuspendLayout();
			this.spCtnrMainContainer.Panel2.SuspendLayout();
			this.spCtnrMainContainer.SuspendLayout();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.SplitContainer2.Panel1.SuspendLayout();
			this.SplitContainer2.Panel2.SuspendLayout();
			this.SplitContainer2.SuspendLayout();
			this.spltrClients.Panel1.SuspendLayout();
			this.spltrClients.Panel2.SuspendLayout();
			this.spltrClients.SuspendLayout();
			this.SuspendLayout();
			//
			//lstBoxClients
			//
			this.lstBoxClients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstBoxClients.FormattingEnabled = true;
			this.lstBoxClients.ItemHeight = 16;
			this.lstBoxClients.Location = new System.Drawing.Point(0, 0);
			this.lstBoxClients.Margin = new System.Windows.Forms.Padding(4);
			this.lstBoxClients.Name = "lstBoxClients";
			this.lstBoxClients.Size = new System.Drawing.Size(216, 516);
			this.lstBoxClients.TabIndex = 0;
			//
			//TabClients
			//
			this.TabClients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabClients.Location = new System.Drawing.Point(0, 0);
			this.TabClients.Name = "TabClients";
			this.TabClients.SelectedIndex = 0;
			this.TabClients.Size = new System.Drawing.Size(713, 609);
			this.TabClients.TabIndex = 1;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 0);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(115, 16);
			this.Label1.TabIndex = 2;
			this.Label1.Text = "Available Clients";
			//
			//btnCreateClient
			//
			this.btnCreateClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnCreateClient.Location = new System.Drawing.Point(0, 0);
			this.btnCreateClient.Name = "btnCreateClient";
			this.btnCreateClient.Size = new System.Drawing.Size(216, 49);
			this.btnCreateClient.TabIndex = 3;
			this.btnCreateClient.Text = "Create new Client";
			this.btnCreateClient.UseVisualStyleBackColor = true;
			//
			//btnDisposeClient
			//
			this.btnDisposeClient.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnDisposeClient.Location = new System.Drawing.Point(0, 0);
			this.btnDisposeClient.Name = "btnDisposeClient";
			this.btnDisposeClient.Size = new System.Drawing.Size(216, 50);
			this.btnDisposeClient.TabIndex = 4;
			this.btnDisposeClient.Text = "Dispose Client";
			this.btnDisposeClient.UseVisualStyleBackColor = true;
			//
			//spCtnrMainContainer
			//
			this.spCtnrMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spCtnrMainContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spCtnrMainContainer.IsSplitterFixed = true;
			this.spCtnrMainContainer.Location = new System.Drawing.Point(0, 0);
			this.spCtnrMainContainer.Name = "spCtnrMainContainer";
			//
			//spCtnrMainContainer.Panel1
			//
			this.spCtnrMainContainer.Panel1.Controls.Add(this.SplitContainer1);
			this.spCtnrMainContainer.Panel1.Controls.Add(this.Label1);
			//
			//spCtnrMainContainer.Panel2
			//
			this.spCtnrMainContainer.Panel2.Controls.Add(this.spltrClients);
			this.spCtnrMainContainer.Size = new System.Drawing.Size(933, 638);
			this.spCtnrMainContainer.SplitterDistance = 216;
			this.spCtnrMainContainer.TabIndex = 5;
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
			this.SplitContainer1.Panel1.Controls.Add(this.lstBoxClients);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
			this.SplitContainer1.Size = new System.Drawing.Size(216, 638);
			this.SplitContainer1.SplitterDistance = 531;
			this.SplitContainer1.TabIndex = 5;
			//
			//SplitContainer2
			//
			this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer2.IsSplitterFixed = true;
			this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer2.Name = "SplitContainer2";
			this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//SplitContainer2.Panel1
			//
			this.SplitContainer2.Panel1.Controls.Add(this.btnCreateClient);
			//
			//SplitContainer2.Panel2
			//
			this.SplitContainer2.Panel2.Controls.Add(this.btnDisposeClient);
			this.SplitContainer2.Size = new System.Drawing.Size(216, 103);
			this.SplitContainer2.SplitterDistance = 49;
			this.SplitContainer2.TabIndex = 0;
			//
			//spltrClients
			//
			this.spltrClients.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrClients.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrClients.Location = new System.Drawing.Point(0, 0);
			this.spltrClients.Name = "spltrClients";
			this.spltrClients.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrClients.Panel1
			//
			this.spltrClients.Panel1.Controls.Add(this.btnHideShowClientsList);
			//
			//spltrClients.Panel2
			//
			this.spltrClients.Panel2.Controls.Add(this.TabClients);
			this.spltrClients.Size = new System.Drawing.Size(713, 638);
			this.spltrClients.SplitterDistance = 25;
			this.spltrClients.TabIndex = 2;
			//
			//btnHideShowClientsList
			//
			this.btnHideShowClientsList.Location = new System.Drawing.Point(17, 3);
			this.btnHideShowClientsList.Name = "btnHideShowClientsList";
			this.btnHideShowClientsList.Size = new System.Drawing.Size(123, 23);
			this.btnHideShowClientsList.TabIndex = 1;
			this.btnHideShowClientsList.Text = "<<   Hide List";
			this.btnHideShowClientsList.UseVisualStyleBackColor = true;
			//
			//CF_DPE_ClientsContainer
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (8.0F), (float) (16.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.spCtnrMainContainer);
			this.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CF_DPE_ClientsContainer";
			this.Size = new System.Drawing.Size(933, 638);
			this.spCtnrMainContainer.Panel1.ResumeLayout(false);
			this.spCtnrMainContainer.Panel1.PerformLayout();
			this.spCtnrMainContainer.Panel2.ResumeLayout(false);
			this.spCtnrMainContainer.ResumeLayout(false);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			this.SplitContainer2.Panel1.ResumeLayout(false);
			this.SplitContainer2.Panel2.ResumeLayout(false);
			this.SplitContainer2.ResumeLayout(false);
			this.spltrClients.Panel1.ResumeLayout(false);
			this.spltrClients.Panel2.ResumeLayout(false);
			this.spltrClients.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.ListBox lstBoxClients;
		internal System.Windows.Forms.TabControl TabClients;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnCreateClient;
		internal System.Windows.Forms.Button btnDisposeClient;
		internal System.Windows.Forms.SplitContainer spCtnrMainContainer;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.SplitContainer SplitContainer2;
		internal System.Windows.Forms.SplitContainer spltrClients;
		internal System.Windows.Forms.Button btnHideShowClientsList;
		
	}
	
}
