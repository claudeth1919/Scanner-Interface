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


namespace P2PPortTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmP2PPortTestAppMainForm : System.Windows.Forms.Form
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
			base.Load += new System.EventHandler(frmP2PSocketPortTestAppMainForm_Load);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtConnectedClients = new System.Windows.Forms.TextBox();
			this.txtStartDateTime = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtListeningPort = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.dgrGeneralStatistics = new System.Windows.Forms.DataGridView();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.txtErrorEmulation = new System.Windows.Forms.TextBox();
			this.chkEmulateErrorOnReception = new System.Windows.Forms.CheckBox();
			this.chkShowDataReceivedOnTable = new System.Windows.Forms.CheckBox();
			this.TabControl2 = new System.Windows.Forms.TabControl();
			this.TabPage6 = new System.Windows.Forms.TabPage();
			this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
			this.CfDataDisplayCtrl1.DataCleared += new CommunicationsUISupportLibrary.CFDataDisplayCtrl.DataClearedEventHandler(this.ClearData);
			this.TabPage7 = new System.Windows.Forms.TabPage();
			this.txtXMLDataString = new System.Windows.Forms.TextBox();
			this.TabPage8 = new System.Windows.Forms.TabPage();
			this.lstDataAttributes = new System.Windows.Forms.ListBox();
			this.lstDataReceived = new System.Windows.Forms.ListBox();
			this.lstDataReceived.SelectedIndexChanged += new System.EventHandler(this.lstDataReceived_SelectedIndexChanged);
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.drgReceptionStatistics = new System.Windows.Forms.DataGridView();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.tabDataToRetrieve = new System.Windows.Forms.TabControl();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.btnClearRequestLog = new System.Windows.Forms.Button();
			this.btnClearRequestLog.Click += new System.EventHandler(this.btnClearRequestLog_Click);
			this.lstRequestReceived = new System.Windows.Forms.ListBox();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.dgrRequestStatistics = new System.Windows.Forms.DataGridView();
			this.TabPage5 = new System.Windows.Forms.TabPage();
			this.CfDataManagerContainer1 = new CommunicationsUISupportLibrary.CFDataManagerContainer();
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.GroupBox5 = new System.Windows.Forms.GroupBox();
			this.txtExceptionText = new System.Windows.Forms.TextBox();
			this.txtExceptionText.TextChanged += new System.EventHandler(this.txtExceptionText_TextChanged);
			this.rbtnSimulateUnhandledExepction = new System.Windows.Forms.RadioButton();
			this.rbtnSimulateNull = new System.Windows.Forms.RadioButton();
			this.chkSimulateFailure = new System.Windows.Forms.CheckBox();
			this.chkSimulateHaltExecution = new System.Windows.Forms.CheckBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.btnClosePort = new System.Windows.Forms.Button();
			this.btnClosePort.Click += new System.EventHandler(this.btnClosePort_Click);
			this.chkRequestLog = new System.Windows.Forms.CheckBox();
			this.GroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrGeneralStatistics).BeginInit();
			this.GroupBox2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabControl2.SuspendLayout();
			this.TabPage6.SuspendLayout();
			this.TabPage7.SuspendLayout();
			this.TabPage8.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.drgReceptionStatistics).BeginInit();
			this.GroupBox3.SuspendLayout();
			this.tabDataToRetrieve.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.TabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrRequestStatistics).BeginInit();
			this.TabPage5.SuspendLayout();
			this.GroupBox4.SuspendLayout();
			this.GroupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.SuspendLayout();
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.txtConnectedClients);
			this.GroupBox1.Controls.Add(this.txtStartDateTime);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.Label3);
			this.GroupBox1.Controls.Add(this.txtListeningPort);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.dgrGeneralStatistics);
			this.GroupBox1.Location = new System.Drawing.Point(3, 2);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(738, 117);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Socket Port Parameters & Statistics";
			//
			//txtConnectedClients
			//
			this.txtConnectedClients.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtConnectedClients.Location = new System.Drawing.Point(427, 71);
			this.txtConnectedClients.Name = "txtConnectedClients";
			this.txtConnectedClients.ReadOnly = true;
			this.txtConnectedClients.Size = new System.Drawing.Size(132, 20);
			this.txtConnectedClients.TabIndex = 5;
			//
			//txtStartDateTime
			//
			this.txtStartDateTime.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.txtStartDateTime.Location = new System.Drawing.Point(278, 32);
			this.txtStartDateTime.Name = "txtStartDateTime";
			this.txtStartDateTime.ReadOnly = true;
			this.txtStartDateTime.Size = new System.Drawing.Size(265, 20);
			this.txtStartDateTime.TabIndex = 5;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label5.Location = new System.Drawing.Point(427, 55);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(134, 13);
			this.Label5.TabIndex = 4;
			this.Label5.Text = "No. Connected Clients";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.Location = new System.Drawing.Point(278, 16);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(96, 13);
			this.Label3.TabIndex = 4;
			this.Label3.Text = "Start Date Time";
			//
			//txtListeningPort
			//
			this.txtListeningPort.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtListeningPort.Location = new System.Drawing.Point(278, 71);
			this.txtListeningPort.Name = "txtListeningPort";
			this.txtListeningPort.ReadOnly = true;
			this.txtListeningPort.Size = new System.Drawing.Size(132, 20);
			this.txtListeningPort.TabIndex = 3;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.Location = new System.Drawing.Point(278, 55);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(85, 13);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Listening Port";
			//
			//dgrGeneralStatistics
			//
			this.dgrGeneralStatistics.AllowUserToAddRows = false;
			this.dgrGeneralStatistics.AllowUserToDeleteRows = false;
			this.dgrGeneralStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrGeneralStatistics.Location = new System.Drawing.Point(7, 15);
			this.dgrGeneralStatistics.Name = "dgrGeneralStatistics";
			this.dgrGeneralStatistics.ReadOnly = true;
			this.dgrGeneralStatistics.Size = new System.Drawing.Size(265, 92);
			this.dgrGeneralStatistics.TabIndex = 1;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.TabControl1);
			this.GroupBox2.Location = new System.Drawing.Point(3, 115);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(869, 316);
			this.GroupBox2.TabIndex = 1;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Socket Port Data Receptions";
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(3, 16);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(864, 296);
			this.TabControl1.TabIndex = 0;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.txtErrorEmulation);
			this.TabPage1.Controls.Add(this.chkEmulateErrorOnReception);
			this.TabPage1.Controls.Add(this.chkShowDataReceivedOnTable);
			this.TabPage1.Controls.Add(this.TabControl2);
			this.TabPage1.Controls.Add(this.lstDataReceived);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(856, 270);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data Reception Log";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//txtErrorEmulation
			//
			this.txtErrorEmulation.Location = new System.Drawing.Point(240, 235);
			this.txtErrorEmulation.Name = "txtErrorEmulation";
			this.txtErrorEmulation.Size = new System.Drawing.Size(352, 20);
			this.txtErrorEmulation.TabIndex = 7;
			this.txtErrorEmulation.Text = "Error by default";
			//
			//chkEmulateErrorOnReception
			//
			this.chkEmulateErrorOnReception.AutoSize = true;
			this.chkEmulateErrorOnReception.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.chkEmulateErrorOnReception.Location = new System.Drawing.Point(3, 237);
			this.chkEmulateErrorOnReception.Name = "chkEmulateErrorOnReception";
			this.chkEmulateErrorOnReception.Size = new System.Drawing.Size(236, 17);
			this.chkEmulateErrorOnReception.TabIndex = 6;
			this.chkEmulateErrorOnReception.Text = "Emualate Error on Remote Reception";
			this.chkEmulateErrorOnReception.UseVisualStyleBackColor = true;
			//
			//chkShowDataReceivedOnTable
			//
			this.chkShowDataReceivedOnTable.AutoSize = true;
			this.chkShowDataReceivedOnTable.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.chkShowDataReceivedOnTable.Location = new System.Drawing.Point(6, 186);
			this.chkShowDataReceivedOnTable.Name = "chkShowDataReceivedOnTable";
			this.chkShowDataReceivedOnTable.Size = new System.Drawing.Size(174, 17);
			this.chkShowDataReceivedOnTable.TabIndex = 5;
			this.chkShowDataReceivedOnTable.Text = "Log Data Received on list";
			this.chkShowDataReceivedOnTable.UseVisualStyleBackColor = true;
			//
			//TabControl2
			//
			this.TabControl2.Controls.Add(this.TabPage6);
			this.TabControl2.Controls.Add(this.TabPage7);
			this.TabControl2.Controls.Add(this.TabPage8);
			this.TabControl2.Location = new System.Drawing.Point(236, 2);
			this.TabControl2.Name = "TabControl2";
			this.TabControl2.SelectedIndex = 0;
			this.TabControl2.Size = new System.Drawing.Size(620, 227);
			this.TabControl2.TabIndex = 4;
			//
			//TabPage6
			//
			this.TabPage6.Controls.Add(this.CfDataDisplayCtrl1);
			this.TabPage6.Location = new System.Drawing.Point(4, 22);
			this.TabPage6.Name = "TabPage6";
			this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage6.Size = new System.Drawing.Size(612, 201);
			this.TabPage6.TabIndex = 0;
			this.TabPage6.Text = "View Data";
			this.TabPage6.UseVisualStyleBackColor = true;
			//
			//CfDataDisplayCtrl1
			//
			this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataDisplayCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CfDataDisplayCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
			this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
			this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(606, 195);
			this.CfDataDisplayCtrl1.TabIndex = 4;
			//
			//TabPage7
			//
			this.TabPage7.Controls.Add(this.txtXMLDataString);
			this.TabPage7.Location = new System.Drawing.Point(4, 22);
			this.TabPage7.Name = "TabPage7";
			this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage7.Size = new System.Drawing.Size(612, 201);
			this.TabPage7.TabIndex = 1;
			this.TabPage7.Text = "View data as XML";
			this.TabPage7.UseVisualStyleBackColor = true;
			//
			//txtXMLDataString
			//
			this.txtXMLDataString.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtXMLDataString.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtXMLDataString.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtXMLDataString.Location = new System.Drawing.Point(3, 3);
			this.txtXMLDataString.Multiline = true;
			this.txtXMLDataString.Name = "txtXMLDataString";
			this.txtXMLDataString.ReadOnly = true;
			this.txtXMLDataString.Size = new System.Drawing.Size(606, 195);
			this.txtXMLDataString.TabIndex = 0;
			//
			//TabPage8
			//
			this.TabPage8.Controls.Add(this.lstDataAttributes);
			this.TabPage8.Location = new System.Drawing.Point(4, 22);
			this.TabPage8.Name = "TabPage8";
			this.TabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage8.Size = new System.Drawing.Size(612, 201);
			this.TabPage8.TabIndex = 2;
			this.TabPage8.Text = "Data Attributes";
			this.TabPage8.UseVisualStyleBackColor = true;
			//
			//lstDataAttributes
			//
			this.lstDataAttributes.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstDataAttributes.FormattingEnabled = true;
			this.lstDataAttributes.ItemHeight = 16;
			this.lstDataAttributes.Location = new System.Drawing.Point(1, 3);
			this.lstDataAttributes.Name = "lstDataAttributes";
			this.lstDataAttributes.Size = new System.Drawing.Size(409, 196);
			this.lstDataAttributes.TabIndex = 4;
			//
			//lstDataReceived
			//
			this.lstDataReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstDataReceived.FormattingEnabled = true;
			this.lstDataReceived.ItemHeight = 16;
			this.lstDataReceived.Location = new System.Drawing.Point(-1, 0);
			this.lstDataReceived.Name = "lstDataReceived";
			this.lstDataReceived.Size = new System.Drawing.Size(236, 180);
			this.lstDataReceived.TabIndex = 3;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.drgReceptionStatistics);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(856, 270);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "ReceptionStatistics";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//drgReceptionStatistics
			//
			this.drgReceptionStatistics.AllowUserToAddRows = false;
			this.drgReceptionStatistics.AllowUserToDeleteRows = false;
			this.drgReceptionStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.drgReceptionStatistics.Location = new System.Drawing.Point(2, 6);
			this.drgReceptionStatistics.Name = "drgReceptionStatistics";
			this.drgReceptionStatistics.ReadOnly = true;
			this.drgReceptionStatistics.Size = new System.Drawing.Size(851, 237);
			this.drgReceptionStatistics.TabIndex = 2;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.tabDataToRetrieve);
			this.GroupBox3.Location = new System.Drawing.Point(3, 433);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(867, 351);
			this.GroupBox3.TabIndex = 2;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Socket Port Data REQUEST Receptions";
			//
			//tabDataToRetrieve
			//
			this.tabDataToRetrieve.Controls.Add(this.TabPage3);
			this.tabDataToRetrieve.Controls.Add(this.TabPage4);
			this.tabDataToRetrieve.Controls.Add(this.TabPage5);
			this.tabDataToRetrieve.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabDataToRetrieve.Location = new System.Drawing.Point(3, 16);
			this.tabDataToRetrieve.Name = "tabDataToRetrieve";
			this.tabDataToRetrieve.SelectedIndex = 0;
			this.tabDataToRetrieve.Size = new System.Drawing.Size(861, 332);
			this.tabDataToRetrieve.TabIndex = 1;
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.chkRequestLog);
			this.TabPage3.Controls.Add(this.btnClearRequestLog);
			this.TabPage3.Controls.Add(this.lstRequestReceived);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(853, 306);
			this.TabPage3.TabIndex = 0;
			this.TabPage3.Text = "Data Request Log";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//btnClearRequestLog
			//
			this.btnClearRequestLog.Location = new System.Drawing.Point(561, 229);
			this.btnClearRequestLog.Name = "btnClearRequestLog";
			this.btnClearRequestLog.Size = new System.Drawing.Size(160, 23);
			this.btnClearRequestLog.TabIndex = 1;
			this.btnClearRequestLog.Text = "Clear";
			this.btnClearRequestLog.UseVisualStyleBackColor = true;
			//
			//lstRequestReceived
			//
			this.lstRequestReceived.FormattingEnabled = true;
			this.lstRequestReceived.HorizontalScrollbar = true;
			this.lstRequestReceived.Location = new System.Drawing.Point(3, 3);
			this.lstRequestReceived.Name = "lstRequestReceived";
			this.lstRequestReceived.ScrollAlwaysVisible = true;
			this.lstRequestReceived.Size = new System.Drawing.Size(721, 225);
			this.lstRequestReceived.TabIndex = 0;
			//
			//TabPage4
			//
			this.TabPage4.Controls.Add(this.dgrRequestStatistics);
			this.TabPage4.Location = new System.Drawing.Point(4, 22);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage4.Size = new System.Drawing.Size(853, 306);
			this.TabPage4.TabIndex = 1;
			this.TabPage4.Text = "Request Statistics";
			this.TabPage4.UseVisualStyleBackColor = true;
			//
			//dgrRequestStatistics
			//
			this.dgrRequestStatistics.AllowUserToAddRows = false;
			this.dgrRequestStatistics.AllowUserToDeleteRows = false;
			this.dgrRequestStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrRequestStatistics.Location = new System.Drawing.Point(2, 6);
			this.dgrRequestStatistics.Name = "dgrRequestStatistics";
			this.dgrRequestStatistics.ReadOnly = true;
			this.dgrRequestStatistics.Size = new System.Drawing.Size(453, 246);
			this.dgrRequestStatistics.TabIndex = 2;
			//
			//TabPage5
			//
			this.TabPage5.Controls.Add(this.CfDataManagerContainer1);
			this.TabPage5.Controls.Add(this.GroupBox4);
			this.TabPage5.Controls.Add(this.Label4);
			this.TabPage5.Location = new System.Drawing.Point(4, 22);
			this.TabPage5.Name = "TabPage5";
			this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage5.Size = new System.Drawing.Size(853, 306);
			this.TabPage5.TabIndex = 2;
			this.TabPage5.Text = "Request Reply Test";
			this.TabPage5.UseVisualStyleBackColor = true;
			//
			//CfDataManagerContainer1
			//
			this.CfDataManagerContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataManagerContainer1.Location = new System.Drawing.Point(3, 16);
			this.CfDataManagerContainer1.Name = "CfDataManagerContainer1";
			this.CfDataManagerContainer1.Size = new System.Drawing.Size(807, 205);
			this.CfDataManagerContainer1.TabIndex = 12;
			//
			//GroupBox4
			//
			this.GroupBox4.Controls.Add(this.GroupBox5);
			this.GroupBox4.Controls.Add(this.chkSimulateFailure);
			this.GroupBox4.Controls.Add(this.chkSimulateHaltExecution);
			this.GroupBox4.Location = new System.Drawing.Point(6, 219);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(810, 84);
			this.GroupBox4.TabIndex = 11;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Request Failure test";
			//
			//GroupBox5
			//
			this.GroupBox5.Controls.Add(this.txtExceptionText);
			this.GroupBox5.Controls.Add(this.rbtnSimulateUnhandledExepction);
			this.GroupBox5.Controls.Add(this.rbtnSimulateNull);
			this.GroupBox5.Location = new System.Drawing.Point(117, 8);
			this.GroupBox5.Name = "GroupBox5";
			this.GroupBox5.Size = new System.Drawing.Size(549, 72);
			this.GroupBox5.TabIndex = 11;
			this.GroupBox5.TabStop = false;
			//
			//txtExceptionText
			//
			this.txtExceptionText.Location = new System.Drawing.Point(127, 49);
			this.txtExceptionText.Name = "txtExceptionText";
			this.txtExceptionText.Size = new System.Drawing.Size(368, 20);
			this.txtExceptionText.TabIndex = 2;
			this.txtExceptionText.Text = "Default Exception Message";
			//
			//rbtnSimulateUnhandledExepction
			//
			this.rbtnSimulateUnhandledExepction.AutoSize = true;
			this.rbtnSimulateUnhandledExepction.Location = new System.Drawing.Point(6, 50);
			this.rbtnSimulateUnhandledExepction.Name = "rbtnSimulateUnhandledExepction";
			this.rbtnSimulateUnhandledExepction.Size = new System.Drawing.Size(115, 17);
			this.rbtnSimulateUnhandledExepction.TabIndex = 1;
			this.rbtnSimulateUnhandledExepction.Text = "Simulate Exception";
			this.rbtnSimulateUnhandledExepction.UseVisualStyleBackColor = true;
			//
			//rbtnSimulateNull
			//
			this.rbtnSimulateNull.AutoSize = true;
			this.rbtnSimulateNull.Checked = true;
			this.rbtnSimulateNull.Location = new System.Drawing.Point(6, 18);
			this.rbtnSimulateNull.Name = "rbtnSimulateNull";
			this.rbtnSimulateNull.Size = new System.Drawing.Size(180, 17);
			this.rbtnSimulateNull.TabIndex = 0;
			this.rbtnSimulateNull.TabStop = true;
			this.rbtnSimulateNull.Text = "Simulate a null Object Reference";
			this.rbtnSimulateNull.UseVisualStyleBackColor = true;
			//
			//chkSimulateFailure
			//
			this.chkSimulateFailure.AutoSize = true;
			this.chkSimulateFailure.Location = new System.Drawing.Point(21, 31);
			this.chkSimulateFailure.Name = "chkSimulateFailure";
			this.chkSimulateFailure.Size = new System.Drawing.Size(92, 30);
			this.chkSimulateFailure.TabIndex = 10;
			this.chkSimulateFailure.Text = "Simulate a  " + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10)) + "request failure";
			this.chkSimulateFailure.UseVisualStyleBackColor = true;
			//
			//chkSimulateHaltExecution
			//
			this.chkSimulateHaltExecution.AutoSize = true;
			this.chkSimulateHaltExecution.Location = new System.Drawing.Point(687, 25);
			this.chkSimulateHaltExecution.Name = "chkSimulateHaltExecution";
			this.chkSimulateHaltExecution.Size = new System.Drawing.Size(98, 43);
			this.chkSimulateHaltExecution.TabIndex = 9;
			this.chkSimulateHaltExecution.Text = "Simulate a halt " + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10)) + "execution on " + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(13)) + System.Convert.ToString(global::Microsoft.VisualBasic.Strings.ChrW(10)) + "rata retrieval";
			this.chkSimulateHaltExecution.UseVisualStyleBackColor = true;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label4.Location = new System.Drawing.Point(6, 3);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(243, 13);
			this.Label4.TabIndex = 5;
			this.Label4.Text = "List of Datanames That Can Be Retrieved";
			//
			//btnClosePort
			//
			this.btnClosePort.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnClosePort.Location = new System.Drawing.Point(751, 8);
			this.btnClosePort.Name = "btnClosePort";
			this.btnClosePort.Size = new System.Drawing.Size(108, 46);
			this.btnClosePort.TabIndex = 3;
			this.btnClosePort.Text = "Close Port";
			this.btnClosePort.UseVisualStyleBackColor = true;
			//
			//chkRequestLog
			//
			this.chkRequestLog.AutoSize = true;
			this.chkRequestLog.Location = new System.Drawing.Point(26, 234);
			this.chkRequestLog.Name = "chkRequestLog";
			this.chkRequestLog.Size = new System.Drawing.Size(151, 17);
			this.chkRequestLog.TabIndex = 2;
			this.chkRequestLog.Text = "Show data request to Log ";
			this.chkRequestLog.UseVisualStyleBackColor = true;
			//
			//frmP2PPortTestAppMainForm
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(875, 778);
			this.ControlBox = false;
			this.Controls.Add(this.btnClosePort);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.GroupBox1);
			this.Name = "frmP2PPortTestAppMainForm";
			this.Text = "P2P Port Test Application";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrGeneralStatistics).EndInit();
			this.GroupBox2.ResumeLayout(false);
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.TabControl2.ResumeLayout(false);
			this.TabPage6.ResumeLayout(false);
			this.TabPage7.ResumeLayout(false);
			this.TabPage7.PerformLayout();
			this.TabPage8.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.drgReceptionStatistics).EndInit();
			this.GroupBox3.ResumeLayout(false);
			this.tabDataToRetrieve.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			this.TabPage3.PerformLayout();
			this.TabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrRequestStatistics).EndInit();
			this.TabPage5.ResumeLayout(false);
			this.TabPage5.PerformLayout();
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox4.PerformLayout();
			this.GroupBox5.ResumeLayout(false);
			this.GroupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.DataGridView dgrGeneralStatistics;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.TextBox txtListeningPort;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.DataGridView drgReceptionStatistics;
		internal System.Windows.Forms.TabControl tabDataToRetrieve;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.ListBox lstRequestReceived;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.DataGridView dgrRequestStatistics;
		internal System.Windows.Forms.TextBox txtStartDateTime;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.TextBox txtConnectedClients;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button btnClearRequestLog;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckBox chkSimulateHaltExecution;
		internal System.Windows.Forms.CheckBox chkSimulateFailure;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.RadioButton rbtnSimulateUnhandledExepction;
		internal System.Windows.Forms.RadioButton rbtnSimulateNull;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.ListBox lstDataReceived;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage6;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.TextBox txtXMLDataString;
		internal CommunicationsUISupportLibrary.CFDataManagerContainer CfDataManagerContainer1;
		internal System.Windows.Forms.Button btnClosePort;
		internal System.Windows.Forms.TabPage TabPage8;
		internal System.Windows.Forms.ListBox lstDataAttributes;
		internal System.Windows.Forms.CheckBox chkShowDataReceivedOnTable;
		internal System.Windows.Forms.TextBox txtErrorEmulation;
		internal System.Windows.Forms.CheckBox chkEmulateErrorOnReception;
		internal System.Windows.Forms.TextBox txtExceptionText;
		internal System.Windows.Forms.CheckBox chkRequestLog;
	}
	
}
