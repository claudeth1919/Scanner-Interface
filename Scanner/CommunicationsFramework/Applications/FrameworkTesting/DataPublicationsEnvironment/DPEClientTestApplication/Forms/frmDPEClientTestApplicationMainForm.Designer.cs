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


namespace DPEClientTestApplication
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDPEClientTestApplicationMainForm : System.Windows.Forms.Form
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
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssConnectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tapgae1 = new System.Windows.Forms.TabPage();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Button2 = new System.Windows.Forms.Button();
            this.dgrdPublications = new System.Windows.Forms.DataGridView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.dgrdPublihsers = new System.Windows.Forms.DataGridView();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.dgrdSTXDSSClients = new System.Windows.Forms.DataGridView();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.dgrdServerParameters = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.CfstxdsS_ClientsContainer1 = new CommunicationsUISupportLibrary.CF_DPE_ClientsContainer();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.txtErrorsCount = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.StatusStrip1.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tapgae1.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPublications)).BeginInit();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPublihsers)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSTXDSSClients)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServerParameters)).BeginInit();
            this.TabPage2.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssConnectionLabel,
            this.ToolStripStatusLabel1,
            this.ToolStripStatusLabel2,
            this.ToolStripProgressBar1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 666);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(702, 22);
            this.StatusStrip1.TabIndex = 0;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ssConnectionLabel
            // 
            this.ssConnectionLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ssConnectionLabel.Name = "ssConnectionLabel";
            this.ssConnectionLabel.Size = new System.Drawing.Size(125, 17);
            this.ssConnectionLabel.Text = "Not connected to Server";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(157, 17);
            this.ToolStripStatusLabel1.Text = "                                                  ";
            // 
            // ToolStripStatusLabel2
            // 
            this.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2";
            this.ToolStripStatusLabel2.Size = new System.Drawing.Size(105, 17);
            this.ToolStripStatusLabel2.Text = "Loading Clients Data";
            // 
            // ToolStripProgressBar1
            // 
            this.ToolStripProgressBar1.Name = "ToolStripProgressBar1";
            this.ToolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tapgae1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(702, 666);
            this.TabControl1.TabIndex = 1;
            // 
            // tapgae1
            // 
            this.tapgae1.Controls.Add(this.GroupBox4);
            this.tapgae1.Controls.Add(this.GroupBox3);
            this.tapgae1.Controls.Add(this.GroupBox2);
            this.tapgae1.Controls.Add(this.GroupBox1);
            this.tapgae1.Location = new System.Drawing.Point(4, 25);
            this.tapgae1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tapgae1.Name = "tapgae1";
            this.tapgae1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tapgae1.Size = new System.Drawing.Size(694, 637);
            this.tapgae1.TabIndex = 0;
            this.tapgae1.Text = "Server Status";
            this.tapgae1.UseVisualStyleBackColor = true;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Button2);
            this.GroupBox4.Controls.Add(this.dgrdPublications);
            this.GroupBox4.Location = new System.Drawing.Point(0, 496);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(694, 138);
            this.GroupBox4.TabIndex = 4;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Publications";
            // 
            // Button2
            // 
            this.Button2.Location = new System.Drawing.Point(616, 8);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(75, 26);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "Refresh";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // dgrdPublications
            // 
            this.dgrdPublications.AllowUserToAddRows = false;
            this.dgrdPublications.AllowUserToDeleteRows = false;
            this.dgrdPublications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdPublications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdPublications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdPublications.Location = new System.Drawing.Point(3, 18);
            this.dgrdPublications.MultiSelect = false;
            this.dgrdPublications.Name = "dgrdPublications";
            this.dgrdPublications.ReadOnly = true;
            this.dgrdPublications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdPublications.Size = new System.Drawing.Size(688, 117);
            this.dgrdPublications.TabIndex = 3;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Button1);
            this.GroupBox3.Controls.Add(this.dgrdPublihsers);
            this.GroupBox3.Location = new System.Drawing.Point(1, 339);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(690, 154);
            this.GroupBox3.TabIndex = 3;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Publishers";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(612, 7);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 26);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Refresh";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // dgrdPublihsers
            // 
            this.dgrdPublihsers.AllowUserToAddRows = false;
            this.dgrdPublihsers.AllowUserToDeleteRows = false;
            this.dgrdPublihsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdPublihsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdPublihsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdPublihsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdPublihsers.Location = new System.Drawing.Point(3, 18);
            this.dgrdPublihsers.MultiSelect = false;
            this.dgrdPublihsers.Name = "dgrdPublihsers";
            this.dgrdPublihsers.ReadOnly = true;
            this.dgrdPublihsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdPublihsers.Size = new System.Drawing.Size(684, 133);
            this.dgrdPublihsers.TabIndex = 2;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Button3);
            this.GroupBox2.Controls.Add(this.dgrdSTXDSSClients);
            this.GroupBox2.Location = new System.Drawing.Point(1, 159);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(691, 177);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Subscriptors";
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(615, 6);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 26);
            this.Button3.TabIndex = 3;
            this.Button3.Text = "Refresh";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // dgrdSTXDSSClients
            // 
            this.dgrdSTXDSSClients.AllowUserToAddRows = false;
            this.dgrdSTXDSSClients.AllowUserToDeleteRows = false;
            this.dgrdSTXDSSClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdSTXDSSClients.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdSTXDSSClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdSTXDSSClients.Location = new System.Drawing.Point(3, 18);
            this.dgrdSTXDSSClients.MultiSelect = false;
            this.dgrdSTXDSSClients.Name = "dgrdSTXDSSClients";
            this.dgrdSTXDSSClients.ReadOnly = true;
            this.dgrdSTXDSSClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdSTXDSSClients.Size = new System.Drawing.Size(684, 156);
            this.dgrdSTXDSSClients.TabIndex = 1;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.dgrdServerParameters);
            this.GroupBox1.Location = new System.Drawing.Point(0, 2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(694, 157);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Server Parameters";
            // 
            // dgrdServerParameters
            // 
            this.dgrdServerParameters.AllowUserToAddRows = false;
            this.dgrdServerParameters.AllowUserToDeleteRows = false;
            this.dgrdServerParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdServerParameters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdServerParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdServerParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdServerParameters.Location = new System.Drawing.Point(3, 18);
            this.dgrdServerParameters.MultiSelect = false;
            this.dgrdServerParameters.Name = "dgrdServerParameters";
            this.dgrdServerParameters.ReadOnly = true;
            this.dgrdServerParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdServerParameters.Size = new System.Drawing.Size(688, 136);
            this.dgrdServerParameters.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.CfstxdsS_ClientsContainer1);
            this.TabPage2.Location = new System.Drawing.Point(4, 25);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabPage2.Size = new System.Drawing.Size(694, 637);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Data Publications Test";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // CfstxdsS_ClientsContainer1
            // 
            this.CfstxdsS_ClientsContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CfstxdsS_ClientsContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CfstxdsS_ClientsContainer1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CfstxdsS_ClientsContainer1.Location = new System.Drawing.Point(3, 4);
            this.CfstxdsS_ClientsContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.CfstxdsS_ClientsContainer1.Name = "CfstxdsS_ClientsContainer1";
            this.CfstxdsS_ClientsContainer1.Size = new System.Drawing.Size(688, 629);
            this.CfstxdsS_ClientsContainer1.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.txtErrorsCount);
            this.TabPage1.Controls.Add(this.Label1);
            this.TabPage1.Controls.Add(this.btnClearLog);
            this.TabPage1.Controls.Add(this.lstSTXEventLog);
            this.TabPage1.Location = new System.Drawing.Point(4, 25);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(694, 637);
            this.TabPage1.TabIndex = 2;
            this.TabPage1.Text = "STX Event Log";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // txtErrorsCount
            // 
            this.txtErrorsCount.Location = new System.Drawing.Point(113, 599);
            this.txtErrorsCount.Name = "txtErrorsCount";
            this.txtErrorsCount.ReadOnly = true;
            this.txtErrorsCount.Size = new System.Drawing.Size(143, 22);
            this.txtErrorsCount.TabIndex = 7;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 602);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(86, 16);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Errors Count";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(532, 590);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(154, 41);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.HorizontalScrollbar = true;
            this.lstSTXEventLog.ItemHeight = 16;
            this.lstSTXEventLog.Location = new System.Drawing.Point(0, 3);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.ScrollAlwaysVisible = true;
            this.lstSTXEventLog.Size = new System.Drawing.Size(691, 580);
            this.lstSTXEventLog.TabIndex = 0;
            this.lstSTXEventLog.DoubleClick += new System.EventHandler(this.lstSTXEventLog_DoubleClick);
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.Location = new System.Drawing.Point(546, 666);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(133, 23);
            this.btnConnectToServer.TabIndex = 2;
            this.btnConnectToServer.Text = "Connect to server";
            this.btnConnectToServer.UseVisualStyleBackColor = true;
            this.btnConnectToServer.Visible = false;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            // 
            // frmDPEClientTestApplicationMainForm
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 688);
            this.Controls.Add(this.btnConnectToServer);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.StatusStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDPEClientTestApplicationMainForm";
            this.Text = "Data Publications Test Client Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSTXDataSocketClient_FormClosing);
            this.Load += new System.EventHandler(this.STXDataSocketClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tapgae1.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPublications)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdPublihsers)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSTXDSSClients)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServerParameters)).EndInit();
            this.TabPage2.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.StatusStrip StatusStrip1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage tapgae1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.DataGridView dgrdServerParameters;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.DataGridView dgrdPublihsers;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.DataGridView dgrdSTXDSSClients;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.DataGridView dgrdPublications;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.ToolStripStatusLabel ssConnectionLabel;
		internal System.Windows.Forms.Button btnConnectToServer;
		internal CommunicationsUISupportLibrary.CF_DPE_ClientsContainer CfstxdsS_ClientsContainer1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Button btnClearLog;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
		internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel2;
		internal System.Windows.Forms.ToolStripProgressBar ToolStripProgressBar1;
		internal System.Windows.Forms.TextBox txtErrorsCount;
		internal System.Windows.Forms.Label Label1;
        private System.ComponentModel.IContainer components;
		
	}
	
}
