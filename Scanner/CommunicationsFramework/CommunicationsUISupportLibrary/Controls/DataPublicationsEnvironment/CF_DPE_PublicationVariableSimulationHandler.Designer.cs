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
	partial class CF_DPE_PublicationVariableSimulationHandler : System.Windows.Forms.UserControl
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
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(STXDSS_PublicationVariableHandler_Load);
			this.Label2 = new System.Windows.Forms.Label();
			this.txtDataType = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtVariableName = new System.Windows.Forms.TextBox();
			this.tmrAutoUpdateTimer = new System.Windows.Forms.Timer(this.components);
			this.tmrAutoUpdateTimer.Tick += new System.EventHandler(this.tmrAutoUpdateTimer_Tick);
			this.btnManualDataUpdate = new System.Windows.Forms.Button();
			this.btnManualDataUpdate.Click += new System.EventHandler(this.btnManualDataUpdate_Click);
			this.txtSendCount = new System.Windows.Forms.TextBox();
			this.chkStartUPDATESimulation = new System.Windows.Forms.CheckBox();
			this.chkStartUPDATESimulation.CheckedChanged += new System.EventHandler(this.chkStartSimulation_CheckedChanged);
			this.nudUpdateRate = new System.Windows.Forms.NumericUpDown();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.CheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
			this.nudErrors = new System.Windows.Forms.NumericUpDown();
			this.chkStartRESETSimulation = new System.Windows.Forms.CheckBox();
			this.chkStartRESETSimulation.CheckedChanged += new System.EventHandler(this.chkStartRESETSimulation_CheckedChanged);
			this.nudResetRate = new System.Windows.Forms.NumericUpDown();
			this.Label6 = new System.Windows.Forms.Label();
			this.Label5 = new System.Windows.Forms.Label();
			this.txtResetCount = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			this.btnResetResetCount = new System.Windows.Forms.Button();
			this.btnResetResetCount.Click += new System.EventHandler(this.btnResetResetCount_Click);
			this.btnUpdateStats = new System.Windows.Forms.Button();
			this.btnUpdateStats.Click += new System.EventHandler(this.btnUpdateStats_Click);
			this.tmrAutoResetTimer = new System.Windows.Forms.Timer(this.components);
			this.tmrAutoResetTimer.Tick += new System.EventHandler(this.tmrAutoResetTimer_Tick);
			this.spltrMain = new System.Windows.Forms.SplitContainer();
			this.Label7 = new System.Windows.Forms.Label();
			this.spltrSim = new System.Windows.Forms.SplitContainer();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize) this.nudUpdateRate).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudErrors).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudResetRate).BeginInit();
			this.spltrMain.Panel1.SuspendLayout();
			this.spltrMain.Panel2.SuspendLayout();
			this.spltrMain.SuspendLayout();
			this.spltrSim.Panel1.SuspendLayout();
			this.spltrSim.Panel2.SuspendLayout();
			this.spltrSim.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.SuspendLayout();
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.Location = new System.Drawing.Point(31, 36);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(62, 15);
			this.Label2.TabIndex = 12;
			this.Label2.Text = "Data Type";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//txtDataType
			//
			this.txtDataType.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtDataType.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtDataType.Location = new System.Drawing.Point(99, 31);
			this.txtDataType.Name = "txtDataType";
			this.txtDataType.ReadOnly = true;
			this.txtDataType.Size = new System.Drawing.Size(235, 25);
			this.txtDataType.TabIndex = 11;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(4, 11);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(89, 15);
			this.Label1.TabIndex = 10;
			this.Label1.Text = "Variable Name";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//txtVariableName
			//
			this.txtVariableName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtVariableName.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtVariableName.Location = new System.Drawing.Point(99, 5);
			this.txtVariableName.Name = "txtVariableName";
			this.txtVariableName.ReadOnly = true;
			this.txtVariableName.Size = new System.Drawing.Size(234, 26);
			this.txtVariableName.TabIndex = 0;
			//
			//tmrAutoUpdateTimer
			//
			//
			//btnManualDataUpdate
			//
			this.btnManualDataUpdate.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnManualDataUpdate.Location = new System.Drawing.Point(6, 4);
			this.btnManualDataUpdate.Name = "btnManualDataUpdate";
			this.btnManualDataUpdate.Size = new System.Drawing.Size(65, 42);
			this.btnManualDataUpdate.TabIndex = 0;
			this.btnManualDataUpdate.Text = "Manual Update";
			this.btnManualDataUpdate.UseVisualStyleBackColor = false;
			//
			//txtSendCount
			//
			this.txtSendCount.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtSendCount.Location = new System.Drawing.Point(80, 22);
			this.txtSendCount.Name = "txtSendCount";
			this.txtSendCount.Size = new System.Drawing.Size(79, 26);
			this.txtSendCount.TabIndex = 1;
			//
			//chkStartUPDATESimulation
			//
			this.chkStartUPDATESimulation.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkStartUPDATESimulation.AutoSize = true;
			this.chkStartUPDATESimulation.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.chkStartUPDATESimulation.Location = new System.Drawing.Point(186, 26);
			this.chkStartUPDATESimulation.Name = "chkStartUPDATESimulation";
			this.chkStartUPDATESimulation.Size = new System.Drawing.Size(140, 23);
			this.chkStartUPDATESimulation.TabIndex = 13;
			this.chkStartUPDATESimulation.Text = "Start Automatic Simulation";
			this.chkStartUPDATESimulation.UseVisualStyleBackColor = false;
			//
			//nudUpdateRate
			//
			this.nudUpdateRate.Location = new System.Drawing.Point(272, 4);
			this.nudUpdateRate.Maximum = new decimal(new int[] {60000, 0, 0, 0});
			this.nudUpdateRate.Minimum = new decimal(new int[] {250, 0, 0, 0});
			this.nudUpdateRate.Name = "nudUpdateRate";
			this.nudUpdateRate.Size = new System.Drawing.Size(53, 20);
			this.nudUpdateRate.TabIndex = 12;
			this.nudUpdateRate.Value = new decimal(new int[] {1000, 0, 0, 0});
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(180, 6);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(90, 13);
			this.Label3.TabIndex = 11;
			this.Label3.Text = "Update Rate (ms)";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(80, 6);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(72, 13);
			this.Label4.TabIndex = 14;
			this.Label4.Text = "Send Counter";
			//
			//CheckBox1
			//
			this.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button;
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Location = new System.Drawing.Point(112, 12);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(41, 23);
			this.CheckBox1.TabIndex = 13;
			this.CheckBox1.Text = "Clear";
			this.CheckBox1.UseVisualStyleBackColor = true;
			//
			//nudErrors
			//
			this.nudErrors.Increment = new decimal(new int[] {0, 0, 0, 0});
			this.nudErrors.Location = new System.Drawing.Point(53, 15);
			this.nudErrors.Maximum = new decimal(new int[] {60000, 0, 0, 0});
			this.nudErrors.Name = "nudErrors";
			this.nudErrors.ReadOnly = true;
			this.nudErrors.Size = new System.Drawing.Size(53, 20);
			this.nudErrors.TabIndex = 12;
			//
			//chkStartRESETSimulation
			//
			this.chkStartRESETSimulation.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkStartRESETSimulation.AutoSize = true;
			this.chkStartRESETSimulation.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.chkStartRESETSimulation.Location = new System.Drawing.Point(185, 25);
			this.chkStartRESETSimulation.Name = "chkStartRESETSimulation";
			this.chkStartRESETSimulation.Size = new System.Drawing.Size(140, 23);
			this.chkStartRESETSimulation.TabIndex = 18;
			this.chkStartRESETSimulation.Text = "Start Automatic Simulation";
			this.chkStartRESETSimulation.UseVisualStyleBackColor = false;
			//
			//nudResetRate
			//
			this.nudResetRate.Location = new System.Drawing.Point(271, 3);
			this.nudResetRate.Maximum = new decimal(new int[] {60000, 0, 0, 0});
			this.nudResetRate.Minimum = new decimal(new int[] {250, 0, 0, 0});
			this.nudResetRate.Name = "nudResetRate";
			this.nudResetRate.Size = new System.Drawing.Size(53, 20);
			this.nudResetRate.TabIndex = 17;
			this.nudResetRate.Value = new decimal(new int[] {1000, 0, 0, 0});
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(181, 5);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(90, 13);
			this.Label6.TabIndex = 16;
			this.Label6.Text = "Update Rate (ms)";
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(84, 6);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(75, 13);
			this.Label5.TabIndex = 15;
			this.Label5.Text = "Reset Counter";
			//
			//txtResetCount
			//
			this.txtResetCount.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtResetCount.Location = new System.Drawing.Point(82, 21);
			this.txtResetCount.Name = "txtResetCount";
			this.txtResetCount.Size = new System.Drawing.Size(77, 26);
			this.txtResetCount.TabIndex = 3;
			//
			//btnReset
			//
			this.btnReset.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnReset.Location = new System.Drawing.Point(5, 5);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(66, 41);
			this.btnReset.TabIndex = 0;
			this.btnReset.Text = "Maual Reset";
			this.btnReset.UseVisualStyleBackColor = false;
			//
			//btnResetResetCount
			//
			this.btnResetResetCount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnResetResetCount.Location = new System.Drawing.Point(191, 27);
			this.btnResetResetCount.Name = "btnResetResetCount";
			this.btnResetResetCount.Size = new System.Drawing.Size(105, 21);
			this.btnResetResetCount.TabIndex = 2;
			this.btnResetResetCount.Text = "Reset Statistics";
			this.btnResetResetCount.UseVisualStyleBackColor = false;
			//
			//btnUpdateStats
			//
			this.btnUpdateStats.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnUpdateStats.Location = new System.Drawing.Point(191, 2);
			this.btnUpdateStats.Name = "btnUpdateStats";
			this.btnUpdateStats.Size = new System.Drawing.Size(105, 21);
			this.btnUpdateStats.TabIndex = 15;
			this.btnUpdateStats.Text = "Update Statistics";
			this.btnUpdateStats.UseVisualStyleBackColor = false;
			//
			//tmrAutoResetTimer
			//
			//
			//spltrMain
			//
			this.spltrMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrMain.Location = new System.Drawing.Point(0, 0);
			this.spltrMain.Name = "spltrMain";
			this.spltrMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrMain.Panel1
			//
			this.spltrMain.Panel1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(224)), System.Convert.ToInt32(System.Convert.ToByte(224)), System.Convert.ToInt32(System.Convert.ToByte(224)));
			this.spltrMain.Panel1.Controls.Add(this.Label2);
			this.spltrMain.Panel1.Controls.Add(this.Label1);
			this.spltrMain.Panel1.Controls.Add(this.txtDataType);
			this.spltrMain.Panel1.Controls.Add(this.txtVariableName);
			//
			//spltrMain.Panel2
			//
			this.spltrMain.Panel2.Controls.Add(this.spltrSim);
			this.spltrMain.Size = new System.Drawing.Size(352, 218);
			this.spltrMain.SplitterDistance = 66;
			this.spltrMain.TabIndex = 16;
			//
			//Label7
			//
			this.Label7.AutoSize = true;
			this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label7.Location = new System.Drawing.Point(4, 7);
			this.Label7.Name = "Label7";
			this.Label7.Size = new System.Drawing.Size(43, 30);
			this.Label7.TabIndex = 13;
			this.Label7.Text = "Errors " + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10)) + "Count";
			this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//spltrSim
			//
			this.spltrSim.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrSim.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrSim.IsSplitterFixed = true;
			this.spltrSim.Location = new System.Drawing.Point(0, 0);
			this.spltrSim.Name = "spltrSim";
			this.spltrSim.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrSim.Panel1
			//
			this.spltrSim.Panel1.Controls.Add(this.TabControl1);
			//
			//spltrSim.Panel2
			//
			this.spltrSim.Panel2.Controls.Add(this.CheckBox1);
			this.spltrSim.Panel2.Controls.Add(this.btnUpdateStats);
			this.spltrSim.Panel2.Controls.Add(this.btnResetResetCount);
			this.spltrSim.Panel2.Controls.Add(this.Label7);
			this.spltrSim.Panel2.Controls.Add(this.nudErrors);
			this.spltrSim.Size = new System.Drawing.Size(352, 148);
			this.spltrSim.SplitterDistance = 88;
			this.spltrSim.TabIndex = 0;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(352, 88);
			this.TabControl1.TabIndex = 0;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.chkStartUPDATESimulation);
			this.TabPage1.Controls.Add(this.txtSendCount);
			this.TabPage1.Controls.Add(this.nudUpdateRate);
			this.TabPage1.Controls.Add(this.btnManualDataUpdate);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.Label4);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(344, 62);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data UPDATE Simulation";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.chkStartRESETSimulation);
			this.TabPage2.Controls.Add(this.Label6);
			this.TabPage2.Controls.Add(this.nudResetRate);
			this.TabPage2.Controls.Add(this.btnReset);
			this.TabPage2.Controls.Add(this.txtResetCount);
			this.TabPage2.Controls.Add(this.Label5);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(344, 62);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Data RESET Simulation";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//CF_DPE_PublicationVariableSimulationHandler
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.Controls.Add(this.spltrMain);
			this.Name = "CF_DPE_PublicationVariableSimulationHandler";
			this.Size = new System.Drawing.Size(352, 218);
			((System.ComponentModel.ISupportInitialize) this.nudUpdateRate).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudErrors).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudResetRate).EndInit();
			this.spltrMain.Panel1.ResumeLayout(false);
			this.spltrMain.Panel1.PerformLayout();
			this.spltrMain.Panel2.ResumeLayout(false);
			this.spltrMain.ResumeLayout(false);
			this.spltrSim.Panel1.ResumeLayout(false);
			this.spltrSim.Panel2.ResumeLayout(false);
			this.spltrSim.Panel2.PerformLayout();
			this.spltrSim.ResumeLayout(false);
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.TextBox txtVariableName;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtDataType;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Timer tmrAutoUpdateTimer;
		internal System.Windows.Forms.Button btnManualDataUpdate;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.NumericUpDown nudUpdateRate;
		internal System.Windows.Forms.CheckBox chkStartUPDATESimulation;
		internal System.Windows.Forms.TextBox txtSendCount;
		internal System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.NumericUpDown nudErrors;
		internal System.Windows.Forms.TextBox txtResetCount;
		internal System.Windows.Forms.Button btnResetResetCount;
		internal System.Windows.Forms.Button btnReset;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Button btnUpdateStats;
		internal System.Windows.Forms.Timer tmrAutoResetTimer;
		internal System.Windows.Forms.CheckBox chkStartRESETSimulation;
		internal System.Windows.Forms.NumericUpDown nudResetRate;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.SplitContainer spltrMain;
		internal System.Windows.Forms.SplitContainer spltrSim;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		
	}
	
}
