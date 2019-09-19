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


namespace SocketsServerClientTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmSocketsServerClientTest : System.Windows.Forms.Form
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
			base.Load += new System.EventHandler(frmSocketsServerClientTest_Load);
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.btnDisconnect.Click += new System.EventHandler(this.Button5_Click);
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.grpClient = new System.Windows.Forms.GroupBox();
			this.TabControl2 = new System.Windows.Forms.TabControl();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.chkshowIncommingData = new System.Windows.Forms.CheckBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.lstReceptionLog = new System.Windows.Forms.ListBox();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.Button6 = new System.Windows.Forms.Button();
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			this.Button5 = new System.Windows.Forms.Button();
			this.Button5.Click += new System.EventHandler(this.Button5_Click_1);
			this.txtDataReceivedCount = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.lstServerData = new System.Windows.Forms.ListBox();
			this.lstServerData.SelectedIndexChanged += new System.EventHandler(this.lstServerData_SelectedIndexChanged);
			this.grpDataSend = new System.Windows.Forms.GroupBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.nudIntegerAutoSendRate = new System.Windows.Forms.NumericUpDown();
			this.Label13 = new System.Windows.Forms.Label();
			this.chkStringAutoIntegerDataSend = new System.Windows.Forms.CheckBox();
			this.chkStringAutoIntegerDataSend.CheckedChanged += new System.EventHandler(this.chkStringAutoIntegerDataSend_CheckedChanged);
			this.btnSendData = new System.Windows.Forms.Button();
			this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
			this.Button7 = new System.Windows.Forms.Button();
			this.Button7.Click += new System.EventHandler(this.Button7_Click);
			this.txtDataSendedCounter = new System.Windows.Forms.TextBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.tmrAutoDataSend = new System.Windows.Forms.Timer(this.components);
			this.tmrAutoDataSend.Tick += new System.EventHandler(this.tmrInteger_Tick);
			this.TabControl3 = new System.Windows.Forms.TabControl();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.txtErrorsCount = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.TabPage5 = new System.Windows.Forms.TabPage();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.lstSTXEventLog = new System.Windows.Forms.ListBox();
			this.lstSTXEventLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSTXEventLog_MouseDoubleClick);
			this.TabPage6 = new System.Windows.Forms.TabPage();
			this.lstDataAttributes = new System.Windows.Forms.ListBox();
			this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
			this.CfDataManagerContainer1 = new CommunicationsUISupportLibrary.CF_SocketsSErver_DataManagerContainer();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.grpClient.SuspendLayout();
			this.TabControl2.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.grpDataSend.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudIntegerAutoSendRate).BeginInit();
			this.TabControl3.SuspendLayout();
			this.TabPage4.SuspendLayout();
			this.TabPage5.SuspendLayout();
			this.TabPage6.SuspendLayout();
			this.SuspendLayout();
			//
			//btnDisconnect
			//
			this.btnDisconnect.Location = new System.Drawing.Point(8, 6);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(140, 25);
			this.btnDisconnect.TabIndex = 5;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			//
			//grpClient
			//
			this.grpClient.Controls.Add(this.TabControl2);
			this.grpClient.Location = new System.Drawing.Point(6, 37);
			this.grpClient.Name = "grpClient";
			this.grpClient.Size = new System.Drawing.Size(869, 320);
			this.grpClient.TabIndex = 1;
			this.grpClient.TabStop = false;
			this.grpClient.Text = "Client Events";
			//
			//TabControl2
			//
			this.TabControl2.Controls.Add(this.TabPage2);
			this.TabControl2.Location = new System.Drawing.Point(6, 12);
			this.TabControl2.Name = "TabControl2";
			this.TabControl2.SelectedIndex = 0;
			this.TabControl2.Size = new System.Drawing.Size(863, 302);
			this.TabControl2.TabIndex = 0;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.chkshowIncommingData);
			this.TabPage2.Controls.Add(this.TabControl1);
			this.TabPage2.Controls.Add(this.Button6);
			this.TabPage2.Controls.Add(this.Button5);
			this.TabPage2.Controls.Add(this.txtDataReceivedCount);
			this.TabPage2.Controls.Add(this.Label10);
			this.TabPage2.Controls.Add(this.lstServerData);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(855, 276);
			this.TabPage2.TabIndex = 0;
			this.TabPage2.Text = "Data Received from Server";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//chkshowIncommingData
			//
			this.chkshowIncommingData.AutoSize = true;
			this.chkshowIncommingData.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.chkshowIncommingData.Location = new System.Drawing.Point(281, 249);
			this.chkshowIncommingData.Name = "chkshowIncommingData";
			this.chkshowIncommingData.Size = new System.Drawing.Size(224, 20);
			this.chkshowIncommingData.TabIndex = 8;
			this.chkshowIncommingData.Text = "Show Incoming Data Into List";
			this.chkshowIncommingData.UseVisualStyleBackColor = true;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Controls.Add(this.TabPage6);
			this.TabControl1.Location = new System.Drawing.Point(263, 3);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(589, 238);
			this.TabControl1.TabIndex = 7;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.lstReceptionLog);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(581, 212);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "ReceptionLog";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//lstReceptionLog
			//
			this.lstReceptionLog.FormattingEnabled = true;
			this.lstReceptionLog.HorizontalScrollbar = true;
			this.lstReceptionLog.Location = new System.Drawing.Point(0, 0);
			this.lstReceptionLog.Name = "lstReceptionLog";
			this.lstReceptionLog.ScrollAlwaysVisible = true;
			this.lstReceptionLog.Size = new System.Drawing.Size(578, 212);
			this.lstReceptionLog.TabIndex = 1;
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.CfDataDisplayCtrl1);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(581, 212);
			this.TabPage3.TabIndex = 1;
			this.TabPage3.Text = "View data";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//Button6
			//
			this.Button6.Location = new System.Drawing.Point(6, 247);
			this.Button6.Name = "Button6";
			this.Button6.Size = new System.Drawing.Size(120, 27);
			this.Button6.TabIndex = 6;
			this.Button6.Text = "Reset Count";
			this.Button6.UseVisualStyleBackColor = true;
			//
			//Button5
			//
			this.Button5.Location = new System.Drawing.Point(137, 246);
			this.Button5.Name = "Button5";
			this.Button5.Size = new System.Drawing.Size(120, 27);
			this.Button5.TabIndex = 5;
			this.Button5.Text = "Cleat List";
			this.Button5.UseVisualStyleBackColor = true;
			//
			//txtDataReceivedCount
			//
			this.txtDataReceivedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtDataReceivedCount.Location = new System.Drawing.Point(707, 241);
			this.txtDataReceivedCount.Name = "txtDataReceivedCount";
			this.txtDataReceivedCount.ReadOnly = true;
			this.txtDataReceivedCount.Size = new System.Drawing.Size(142, 29);
			this.txtDataReceivedCount.TabIndex = 4;
			//
			//Label10
			//
			this.Label10.AutoSize = true;
			this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label10.Location = new System.Drawing.Point(546, 247);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(155, 16);
			this.Label10.TabIndex = 3;
			this.Label10.Text = "Data Received Count";
			//
			//lstServerData
			//
			this.lstServerData.FormattingEnabled = true;
			this.lstServerData.HorizontalScrollbar = true;
			this.lstServerData.Location = new System.Drawing.Point(2, 3);
			this.lstServerData.Name = "lstServerData";
			this.lstServerData.ScrollAlwaysVisible = true;
			this.lstServerData.Size = new System.Drawing.Size(255, 238);
			this.lstServerData.TabIndex = 0;
			//
			//grpDataSend
			//
			this.grpDataSend.Controls.Add(this.CfDataManagerContainer1);
			this.grpDataSend.Controls.Add(this.GroupBox1);
			this.grpDataSend.Controls.Add(this.Button7);
			this.grpDataSend.Controls.Add(this.txtDataSendedCounter);
			this.grpDataSend.Controls.Add(this.Label11);
			this.grpDataSend.Location = new System.Drawing.Point(6, 363);
			this.grpDataSend.Name = "grpDataSend";
			this.grpDataSend.Size = new System.Drawing.Size(1077, 305);
			this.grpDataSend.TabIndex = 2;
			this.grpDataSend.TabStop = false;
			this.grpDataSend.Text = "Data Send To Sockets Server";
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.nudIntegerAutoSendRate);
			this.GroupBox1.Controls.Add(this.Label13);
			this.GroupBox1.Controls.Add(this.chkStringAutoIntegerDataSend);
			this.GroupBox1.Controls.Add(this.btnSendData);
			this.GroupBox1.Location = new System.Drawing.Point(351, 217);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(412, 79);
			this.GroupBox1.TabIndex = 34;
			this.GroupBox1.TabStop = false;
			//
			//nudIntegerAutoSendRate
			//
			this.nudIntegerAutoSendRate.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.nudIntegerAutoSendRate.Location = new System.Drawing.Point(10, 40);
			this.nudIntegerAutoSendRate.Maximum = new decimal(new int[] {100000, 0, 0, 0});
			this.nudIntegerAutoSendRate.Minimum = new decimal(new int[] {1, 0, 0, 0});
			this.nudIntegerAutoSendRate.Name = "nudIntegerAutoSendRate";
			this.nudIntegerAutoSendRate.Size = new System.Drawing.Size(60, 26);
			this.nudIntegerAutoSendRate.TabIndex = 31;
			this.nudIntegerAutoSendRate.Value = new decimal(new int[] {50, 0, 0, 0});
			//
			//Label13
			//
			this.Label13.AutoSize = true;
			this.Label13.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label13.Location = new System.Drawing.Point(6, 18);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(162, 19);
			this.Label13.TabIndex = 32;
			this.Label13.Text = "Data send Rate (ms)";
			//
			//chkStringAutoIntegerDataSend
			//
			this.chkStringAutoIntegerDataSend.Appearance = System.Windows.Forms.Appearance.Button;
			this.chkStringAutoIntegerDataSend.AutoSize = true;
			this.chkStringAutoIntegerDataSend.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.chkStringAutoIntegerDataSend.Location = new System.Drawing.Point(197, 52);
			this.chkStringAutoIntegerDataSend.Name = "chkStringAutoIntegerDataSend";
			this.chkStringAutoIntegerDataSend.Size = new System.Drawing.Size(126, 26);
			this.chkStringAutoIntegerDataSend.TabIndex = 30;
			this.chkStringAutoIntegerDataSend.Text = "Automatic Send";
			this.chkStringAutoIntegerDataSend.UseVisualStyleBackColor = true;
			//
			//btnSendData
			//
			this.btnSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnSendData.Location = new System.Drawing.Point(197, 9);
			this.btnSendData.Name = "btnSendData";
			this.btnSendData.Size = new System.Drawing.Size(176, 38);
			this.btnSendData.TabIndex = 4;
			this.btnSendData.Text = "Send Data to Server";
			this.btnSendData.UseVisualStyleBackColor = true;
			//
			//Button7
			//
			this.Button7.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button7.Location = new System.Drawing.Point(225, 245);
			this.Button7.Name = "Button7";
			this.Button7.Size = new System.Drawing.Size(120, 27);
			this.Button7.TabIndex = 14;
			this.Button7.Text = "Reset Count";
			this.Button7.UseVisualStyleBackColor = true;
			//
			//txtDataSendedCounter
			//
			this.txtDataSendedCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtDataSendedCounter.Location = new System.Drawing.Point(6, 245);
			this.txtDataSendedCounter.Name = "txtDataSendedCounter";
			this.txtDataSendedCounter.ReadOnly = true;
			this.txtDataSendedCounter.Size = new System.Drawing.Size(213, 29);
			this.txtDataSendedCounter.TabIndex = 13;
			//
			//Label11
			//
			this.Label11.AutoSize = true;
			this.Label11.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label11.Location = new System.Drawing.Point(4, 226);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(215, 16);
			this.Label11.TabIndex = 12;
			this.Label11.Text = "Data Sended To Server Count";
			//
			//tmrAutoDataSend
			//
			//
			//TabControl3
			//
			this.TabControl3.Controls.Add(this.TabPage4);
			this.TabControl3.Controls.Add(this.TabPage5);
			this.TabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl3.Location = new System.Drawing.Point(0, 0);
			this.TabControl3.Name = "TabControl3";
			this.TabControl3.SelectedIndex = 0;
			this.TabControl3.Size = new System.Drawing.Size(1093, 703);
			this.TabControl3.TabIndex = 6;
			//
			//TabPage4
			//
			this.TabPage4.Controls.Add(this.Button3);
			this.TabPage4.Controls.Add(this.Button2);
			this.TabPage4.Controls.Add(this.txtErrorsCount);
			this.TabPage4.Controls.Add(this.Label1);
			this.TabPage4.Controls.Add(this.btnDisconnect);
			this.TabPage4.Controls.Add(this.grpDataSend);
			this.TabPage4.Controls.Add(this.grpClient);
			this.TabPage4.Location = new System.Drawing.Point(4, 22);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage4.Size = new System.Drawing.Size(1085, 677);
			this.TabPage4.TabIndex = 0;
			this.TabPage4.Text = "Client";
			this.TabPage4.UseVisualStyleBackColor = true;
			//
			//Button3
			//
			this.Button3.Location = new System.Drawing.Point(154, 6);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(119, 25);
			this.Button3.TabIndex = 17;
			this.Button3.Text = "Re connect";
			this.Button3.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(723, 8);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(120, 27);
			this.Button2.TabIndex = 16;
			this.Button2.Text = "Reset Counter";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//txtErrorsCount
			//
			this.txtErrorsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtErrorsCount.Location = new System.Drawing.Point(504, 6);
			this.txtErrorsCount.Name = "txtErrorsCount";
			this.txtErrorsCount.ReadOnly = true;
			this.txtErrorsCount.Size = new System.Drawing.Size(213, 29);
			this.txtErrorsCount.TabIndex = 15;
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(280, 12);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(215, 16);
			this.Label1.TabIndex = 14;
			this.Label1.Text = "Data Sended To Server Count";
			//
			//TabPage5
			//
			this.TabPage5.Controls.Add(this.Button1);
			this.TabPage5.Controls.Add(this.lstSTXEventLog);
			this.TabPage5.Location = new System.Drawing.Point(4, 22);
			this.TabPage5.Name = "TabPage5";
			this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage5.Size = new System.Drawing.Size(863, 677);
			this.TabPage5.TabIndex = 1;
			this.TabPage5.Text = "STX Event Log";
			this.TabPage5.UseVisualStyleBackColor = true;
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(748, 597);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(107, 34);
			this.Button1.TabIndex = 2;
			this.Button1.Text = "Clear List";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//lstSTXEventLog
			//
			this.lstSTXEventLog.FormattingEnabled = true;
			this.lstSTXEventLog.Location = new System.Drawing.Point(0, 2);
			this.lstSTXEventLog.Name = "lstSTXEventLog";
			this.lstSTXEventLog.Size = new System.Drawing.Size(863, 589);
			this.lstSTXEventLog.TabIndex = 1;
			//
			//TabPage6
			//
			this.TabPage6.Controls.Add(this.lstDataAttributes);
			this.TabPage6.Location = new System.Drawing.Point(4, 22);
			this.TabPage6.Name = "TabPage6";
			this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage6.Size = new System.Drawing.Size(581, 212);
			this.TabPage6.TabIndex = 2;
			this.TabPage6.Text = "Data Attributes";
			this.TabPage6.UseVisualStyleBackColor = true;
			//
			//lstDataAttributes
			//
			this.lstDataAttributes.FormattingEnabled = true;
			this.lstDataAttributes.HorizontalScrollbar = true;
			this.lstDataAttributes.Location = new System.Drawing.Point(3, 0);
			this.lstDataAttributes.Name = "lstDataAttributes";
			this.lstDataAttributes.ScrollAlwaysVisible = true;
			this.lstDataAttributes.Size = new System.Drawing.Size(577, 212);
			this.lstDataAttributes.TabIndex = 1;
			//
			//CfDataDisplayCtrl1
			//
			this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataDisplayCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
			this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
			this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(575, 206);
			this.CfDataDisplayCtrl1.TabIndex = 0;
			//
			//CfDataManagerContainer1
			//
			this.CfDataManagerContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataManagerContainer1.Location = new System.Drawing.Point(2, 19);
			this.CfDataManagerContainer1.Name = "CfDataManagerContainer1";
			this.CfDataManagerContainer1.Size = new System.Drawing.Size(1071, 205);
			this.CfDataManagerContainer1.TabIndex = 35;
			//
			//frmSocketsServerClientTest
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1093, 703);
			this.ControlBox = false;
			this.Controls.Add(this.TabControl3);
			this.Name = "frmSocketsServerClientTest";
			this.Text = "DataSocketClientApplication";
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.grpClient.ResumeLayout(false);
			this.TabControl2.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			this.grpDataSend.ResumeLayout(false);
			this.grpDataSend.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudIntegerAutoSendRate).EndInit();
			this.TabControl3.ResumeLayout(false);
			this.TabPage4.ResumeLayout(false);
			this.TabPage4.PerformLayout();
			this.TabPage5.ResumeLayout(false);
			this.TabPage6.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.GroupBox grpClient;
		internal System.Windows.Forms.ListBox lstServerData;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.GroupBox grpDataSend;
		internal System.Windows.Forms.Button btnSendData;
		internal System.Windows.Forms.TextBox txtDataReceivedCount;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Button btnDisconnect;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.NumericUpDown nudIntegerAutoSendRate;
		internal System.Windows.Forms.CheckBox chkStringAutoIntegerDataSend;
		internal System.Windows.Forms.Timer tmrAutoDataSend;
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.Button Button6;
		internal System.Windows.Forms.TextBox txtDataSendedCounter;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Button Button7;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.ListBox lstReceptionLog;
		internal System.Windows.Forms.TabPage TabPage3;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.CheckBox chkshowIncommingData;
		internal System.Windows.Forms.TabControl TabControl3;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.TextBox txtErrorsCount;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.TabPage TabPage6;
		internal System.Windows.Forms.ListBox lstDataAttributes;
		internal CommunicationsUISupportLibrary.CF_SocketsSErver_DataManagerContainer CfDataManagerContainer1;
	}
	
}
