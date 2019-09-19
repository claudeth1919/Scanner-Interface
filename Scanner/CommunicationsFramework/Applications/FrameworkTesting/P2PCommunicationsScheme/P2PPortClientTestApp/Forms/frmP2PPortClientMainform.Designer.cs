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


namespace P2PPortClientTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmP2PPortClientMainform : System.Windows.Forms.Form
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
            this.grpDataSendTest = new System.Windows.Forms.GroupBox();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.btnSEndToAutoList = new System.Windows.Forms.Button();
            this.grpDataAttr = new System.Windows.Forms.GroupBox();
            this.lstDataAttr = new System.Windows.Forms.ListBox();
            this.btnRemoveDataAttr = new System.Windows.Forms.Button();
            this.btnAddAttr = new System.Windows.Forms.Button();
            this.CfDataManagerContainer1 = new CommunicationsUISupportLibrary.CFDataManagerContainer();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.Label4 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.lstErrorsOnAutoSEnd = new System.Windows.Forms.ListBox();
            this.nudSendRate = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.lstAutoSend = new System.Windows.Forms.ListBox();
            this.chkAutoSEnd = new System.Windows.Forms.CheckBox();
            this.btnRemoveAutoSendElement = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.grpDataRequestTest = new System.Windows.Forms.GroupBox();
            this.TabControl3 = new System.Windows.Forms.TabControl();
            this.TabPage6 = new System.Windows.Forms.TabPage();
            this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
            this.TabPage7 = new System.Windows.Forms.TabPage();
            this.Button3 = new System.Windows.Forms.Button();
            this.lstErrorsOnAutoRequest = new System.Windows.Forms.ListBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutomaticREquest = new System.Windows.Forms.CheckBox();
            this.nudRequestRate = new System.Windows.Forms.NumericUpDown();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnRequestData = new System.Windows.Forms.Button();
            this.txtDataNameToRequest = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.tmrAutoSend = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.dgrdGeneralStatistics = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.dgrdSendStats = new System.Windows.Forms.DataGridView();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.dgrdRequestStats = new System.Windows.Forms.DataGridView();
            this.btnUpdateStatistics = new System.Windows.Forms.Button();
            this.tmrAutoRequest = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.grpDataSendTest.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage4.SuspendLayout();
            this.grpDataAttr.SuspendLayout();
            this.TabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendRate)).BeginInit();
            this.grpDataRequestTest.SuspendLayout();
            this.TabControl3.SuspendLayout();
            this.TabPage6.SuspendLayout();
            this.TabPage7.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequestRate)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdGeneralStatistics)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSendStats)).BeginInit();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdRequestStats)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDataSendTest
            // 
            this.grpDataSendTest.Controls.Add(this.TabControl1);
            this.grpDataSendTest.Controls.Add(this.btnSendData);
            this.grpDataSendTest.Location = new System.Drawing.Point(3, 208);
            this.grpDataSendTest.Name = "grpDataSendTest";
            this.grpDataSendTest.Size = new System.Drawing.Size(1203, 304);
            this.grpDataSendTest.TabIndex = 16;
            this.grpDataSendTest.TabStop = false;
            this.grpDataSendTest.Text = "Data Sending Test";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage4);
            this.TabControl1.Controls.Add(this.TabPage5);
            this.TabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(0, 16);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1210, 245);
            this.TabControl1.TabIndex = 25;
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.btnSEndToAutoList);
            this.TabPage4.Controls.Add(this.grpDataAttr);
            this.TabPage4.Controls.Add(this.CfDataManagerContainer1);
            this.TabPage4.Location = new System.Drawing.Point(4, 25);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(1202, 216);
            this.TabPage4.TabIndex = 0;
            this.TabPage4.Text = "Manual Data Sending";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // btnSEndToAutoList
            // 
            this.btnSEndToAutoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEndToAutoList.Location = new System.Drawing.Point(253, 97);
            this.btnSEndToAutoList.Name = "btnSEndToAutoList";
            this.btnSEndToAutoList.Size = new System.Drawing.Size(91, 108);
            this.btnSEndToAutoList.TabIndex = 18;
            this.btnSEndToAutoList.Text = "Add To Auto Send\r\nList >>>\r\n";
            this.btnSEndToAutoList.UseVisualStyleBackColor = true;
            this.btnSEndToAutoList.Click += new System.EventHandler(this.btnSEndToAutoList_Click);
            // 
            // grpDataAttr
            // 
            this.grpDataAttr.Controls.Add(this.lstDataAttr);
            this.grpDataAttr.Controls.Add(this.btnRemoveDataAttr);
            this.grpDataAttr.Controls.Add(this.btnAddAttr);
            this.grpDataAttr.Location = new System.Drawing.Point(805, -1);
            this.grpDataAttr.Name = "grpDataAttr";
            this.grpDataAttr.Size = new System.Drawing.Size(384, 217);
            this.grpDataAttr.TabIndex = 28;
            this.grpDataAttr.TabStop = false;
            this.grpDataAttr.Text = "Data Attributes";
            // 
            // lstDataAttr
            // 
            this.lstDataAttr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDataAttr.FormattingEnabled = true;
            this.lstDataAttr.HorizontalScrollbar = true;
            this.lstDataAttr.ItemHeight = 16;
            this.lstDataAttr.Location = new System.Drawing.Point(3, 13);
            this.lstDataAttr.Name = "lstDataAttr";
            this.lstDataAttr.ScrollAlwaysVisible = true;
            this.lstDataAttr.Size = new System.Drawing.Size(269, 196);
            this.lstDataAttr.TabIndex = 25;
            // 
            // btnRemoveDataAttr
            // 
            this.btnRemoveDataAttr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDataAttr.Location = new System.Drawing.Point(274, 73);
            this.btnRemoveDataAttr.Name = "btnRemoveDataAttr";
            this.btnRemoveDataAttr.Size = new System.Drawing.Size(107, 62);
            this.btnRemoveDataAttr.TabIndex = 27;
            this.btnRemoveDataAttr.Text = "Remove Data Attribute";
            this.btnRemoveDataAttr.UseVisualStyleBackColor = true;
            this.btnRemoveDataAttr.Click += new System.EventHandler(this.btnRemoveDataAttr_Click);
            // 
            // btnAddAttr
            // 
            this.btnAddAttr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAttr.Location = new System.Drawing.Point(274, 13);
            this.btnAddAttr.Name = "btnAddAttr";
            this.btnAddAttr.Size = new System.Drawing.Size(107, 54);
            this.btnAddAttr.TabIndex = 26;
            this.btnAddAttr.Text = "Add Attribute to Data";
            this.btnAddAttr.UseVisualStyleBackColor = true;
            this.btnAddAttr.Click += new System.EventHandler(this.btnAddAttr_Click);
            // 
            // CfDataManagerContainer1
            // 
            this.CfDataManagerContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CfDataManagerContainer1.Location = new System.Drawing.Point(-2, 0);
            this.CfDataManagerContainer1.Name = "CfDataManagerContainer1";
            this.CfDataManagerContainer1.Size = new System.Drawing.Size(807, 205);
            this.CfDataManagerContainer1.TabIndex = 0;
            this.CfDataManagerContainer1.DataSelectionChanged += new CommunicationsUISupportLibrary.CFDataManagerContainer.DataSelectionChangedEventHandler(this.SelectionDataChange);
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.Label4);
            this.TabPage5.Controls.Add(this.Button2);
            this.TabPage5.Controls.Add(this.lstErrorsOnAutoSEnd);
            this.TabPage5.Controls.Add(this.nudSendRate);
            this.TabPage5.Controls.Add(this.Label1);
            this.TabPage5.Controls.Add(this.lstAutoSend);
            this.TabPage5.Controls.Add(this.chkAutoSEnd);
            this.TabPage5.Controls.Add(this.btnRemoveAutoSendElement);
            this.TabPage5.Location = new System.Drawing.Point(4, 25);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(1202, 216);
            this.TabPage5.TabIndex = 1;
            this.TabPage5.Text = "Automatic Data Sending";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(540, 3);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(316, 16);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Errors registered during automatic data send";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(1070, 0);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(127, 29);
            this.Button2.TabIndex = 28;
            this.Button2.Text = "Clear Errors";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // lstErrorsOnAutoSEnd
            // 
            this.lstErrorsOnAutoSEnd.FormattingEnabled = true;
            this.lstErrorsOnAutoSEnd.HorizontalScrollbar = true;
            this.lstErrorsOnAutoSEnd.ItemHeight = 16;
            this.lstErrorsOnAutoSEnd.Location = new System.Drawing.Point(540, 27);
            this.lstErrorsOnAutoSEnd.Name = "lstErrorsOnAutoSEnd";
            this.lstErrorsOnAutoSEnd.ScrollAlwaysVisible = true;
            this.lstErrorsOnAutoSEnd.Size = new System.Drawing.Size(659, 180);
            this.lstErrorsOnAutoSEnd.TabIndex = 27;
            // 
            // nudSendRate
            // 
            this.nudSendRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSendRate.Location = new System.Drawing.Point(410, 93);
            this.nudSendRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSendRate.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSendRate.Name = "nudSendRate";
            this.nudSendRate.Size = new System.Drawing.Size(120, 29);
            this.nudSendRate.TabIndex = 26;
            this.nudSendRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(407, 74);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(111, 16);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "send rate  (ms)";
            // 
            // lstAutoSend
            // 
            this.lstAutoSend.FormattingEnabled = true;
            this.lstAutoSend.HorizontalScrollbar = true;
            this.lstAutoSend.ItemHeight = 16;
            this.lstAutoSend.Location = new System.Drawing.Point(0, 1);
            this.lstAutoSend.Name = "lstAutoSend";
            this.lstAutoSend.ScrollAlwaysVisible = true;
            this.lstAutoSend.Size = new System.Drawing.Size(401, 212);
            this.lstAutoSend.TabIndex = 20;
            // 
            // chkAutoSEnd
            // 
            this.chkAutoSEnd.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoSEnd.AutoSize = true;
            this.chkAutoSEnd.Location = new System.Drawing.Point(407, 128);
            this.chkAutoSEnd.Name = "chkAutoSEnd";
            this.chkAutoSEnd.Size = new System.Drawing.Size(82, 58);
            this.chkAutoSEnd.TabIndex = 24;
            this.chkAutoSEnd.Text = "START \r\nAutomatic \r\nData Send";
            this.chkAutoSEnd.UseVisualStyleBackColor = true;
            this.chkAutoSEnd.CheckedChanged += new System.EventHandler(this.chkAutoSEnd_CheckedChanged);
            // 
            // btnRemoveAutoSendElement
            // 
            this.btnRemoveAutoSendElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAutoSendElement.Location = new System.Drawing.Point(407, 1);
            this.btnRemoveAutoSendElement.Name = "btnRemoveAutoSendElement";
            this.btnRemoveAutoSendElement.Size = new System.Drawing.Size(127, 70);
            this.btnRemoveAutoSendElement.TabIndex = 23;
            this.btnRemoveAutoSendElement.Text = "<<< Remove from automatic send list";
            this.btnRemoveAutoSendElement.UseVisualStyleBackColor = true;
            this.btnRemoveAutoSendElement.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.BackColor = System.Drawing.Color.Lime;
            this.btnSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendData.Location = new System.Drawing.Point(0, 264);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(107, 40);
            this.btnSendData.TabIndex = 16;
            this.btnSendData.Text = "Send Data";
            this.btnSendData.UseVisualStyleBackColor = false;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.Lime;
            this.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Location = new System.Drawing.Point(1106, 0);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(107, 40);
            this.Button1.TabIndex = 29;
            this.Button1.Text = "Close Client";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // grpDataRequestTest
            // 
            this.grpDataRequestTest.Controls.Add(this.TabControl3);
            this.grpDataRequestTest.Controls.Add(this.GroupBox2);
            this.grpDataRequestTest.Controls.Add(this.btnRequestData);
            this.grpDataRequestTest.Controls.Add(this.txtDataNameToRequest);
            this.grpDataRequestTest.Controls.Add(this.Label3);
            this.grpDataRequestTest.Location = new System.Drawing.Point(3, 510);
            this.grpDataRequestTest.Name = "grpDataRequestTest";
            this.grpDataRequestTest.Size = new System.Drawing.Size(1203, 213);
            this.grpDataRequestTest.TabIndex = 17;
            this.grpDataRequestTest.TabStop = false;
            this.grpDataRequestTest.Text = "Data Request Test";
            // 
            // TabControl3
            // 
            this.TabControl3.Controls.Add(this.TabPage6);
            this.TabControl3.Controls.Add(this.TabPage7);
            this.TabControl3.Location = new System.Drawing.Point(7, 39);
            this.TabControl3.Name = "TabControl3";
            this.TabControl3.SelectedIndex = 0;
            this.TabControl3.Size = new System.Drawing.Size(932, 174);
            this.TabControl3.TabIndex = 31;
            // 
            // TabPage6
            // 
            this.TabPage6.Controls.Add(this.CfDataDisplayCtrl1);
            this.TabPage6.Location = new System.Drawing.Point(4, 22);
            this.TabPage6.Name = "TabPage6";
            this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage6.Size = new System.Drawing.Size(924, 148);
            this.TabPage6.TabIndex = 0;
            this.TabPage6.Text = "Data Requested";
            this.TabPage6.UseVisualStyleBackColor = true;
            // 
            // CfDataDisplayCtrl1
            // 
            this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CfDataDisplayCtrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CfDataDisplayCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
            this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
            this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(918, 142);
            this.CfDataDisplayCtrl1.TabIndex = 18;
            // 
            // TabPage7
            // 
            this.TabPage7.Controls.Add(this.Button3);
            this.TabPage7.Controls.Add(this.lstErrorsOnAutoRequest);
            this.TabPage7.Location = new System.Drawing.Point(4, 22);
            this.TabPage7.Name = "TabPage7";
            this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage7.Size = new System.Drawing.Size(924, 148);
            this.TabPage7.TabIndex = 1;
            this.TabPage7.Text = "Automatic Request Errors";
            this.TabPage7.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(843, 1);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(81, 47);
            this.Button3.TabIndex = 29;
            this.Button3.Text = "Clear Errors";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lstErrorsOnAutoRequest
            // 
            this.lstErrorsOnAutoRequest.FormattingEnabled = true;
            this.lstErrorsOnAutoRequest.HorizontalScrollbar = true;
            this.lstErrorsOnAutoRequest.Location = new System.Drawing.Point(-2, 0);
            this.lstErrorsOnAutoRequest.Name = "lstErrorsOnAutoRequest";
            this.lstErrorsOnAutoRequest.ScrollAlwaysVisible = true;
            this.lstErrorsOnAutoRequest.Size = new System.Drawing.Size(839, 147);
            this.lstErrorsOnAutoRequest.TabIndex = 28;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.chkAutomaticREquest);
            this.GroupBox2.Controls.Add(this.nudRequestRate);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Location = new System.Drawing.Point(936, 66);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(259, 91);
            this.GroupBox2.TabIndex = 30;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Automatic Data Request";
            // 
            // chkAutomaticREquest
            // 
            this.chkAutomaticREquest.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutomaticREquest.AutoSize = true;
            this.chkAutomaticREquest.Location = new System.Drawing.Point(159, 23);
            this.chkAutomaticREquest.Name = "chkAutomaticREquest";
            this.chkAutomaticREquest.Size = new System.Drawing.Size(83, 49);
            this.chkAutomaticREquest.TabIndex = 27;
            this.chkAutomaticREquest.Text = "START \r\nAutomatic \r\nData Request";
            this.chkAutomaticREquest.UseVisualStyleBackColor = true;
            this.chkAutomaticREquest.CheckedChanged += new System.EventHandler(this.chkAutomaticREquest_CheckedChanged);
            // 
            // nudRequestRate
            // 
            this.nudRequestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudRequestRate.Location = new System.Drawing.Point(12, 42);
            this.nudRequestRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRequestRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRequestRate.Name = "nudRequestRate";
            this.nudRequestRate.Size = new System.Drawing.Size(120, 29);
            this.nudRequestRate.TabIndex = 29;
            this.nudRequestRate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(9, 23);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(141, 16);
            this.Label2.TabIndex = 28;
            this.Label2.Text = "Request Rate  (ms)";
            // 
            // btnRequestData
            // 
            this.btnRequestData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequestData.Location = new System.Drawing.Point(1073, 13);
            this.btnRequestData.Name = "btnRequestData";
            this.btnRequestData.Size = new System.Drawing.Size(124, 47);
            this.btnRequestData.TabIndex = 17;
            this.btnRequestData.Text = "Request Data";
            this.btnRequestData.UseVisualStyleBackColor = true;
            this.btnRequestData.Click += new System.EventHandler(this.btnRequestData_Click);
            // 
            // txtDataNameToRequest
            // 
            this.txtDataNameToRequest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtDataNameToRequest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDataNameToRequest.Location = new System.Drawing.Point(149, 13);
            this.txtDataNameToRequest.Name = "txtDataNameToRequest";
            this.txtDataNameToRequest.Size = new System.Drawing.Size(265, 20);
            this.txtDataNameToRequest.TabIndex = 11;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(7, 16);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(136, 13);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "Data Name to Request";
            // 
            // tmrAutoSend
            // 
            this.tmrAutoSend.Tick += new System.EventHandler(this.tmrAutoSend_Tick);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TabControl2);
            this.GroupBox1.Location = new System.Drawing.Point(3, 0);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(634, 202);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Client Statistics";
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage1);
            this.TabControl2.Controls.Add(this.TabPage2);
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl2.Location = new System.Drawing.Point(3, 16);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(628, 183);
            this.TabControl2.TabIndex = 0;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.dgrdGeneralStatistics);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(620, 157);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "General Statistics";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // dgrdGeneralStatistics
            // 
            this.dgrdGeneralStatistics.AllowUserToAddRows = false;
            this.dgrdGeneralStatistics.AllowUserToDeleteRows = false;
            this.dgrdGeneralStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdGeneralStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdGeneralStatistics.Location = new System.Drawing.Point(3, 3);
            this.dgrdGeneralStatistics.Name = "dgrdGeneralStatistics";
            this.dgrdGeneralStatistics.ReadOnly = true;
            this.dgrdGeneralStatistics.Size = new System.Drawing.Size(614, 151);
            this.dgrdGeneralStatistics.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.dgrdSendStats);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(620, 157);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Data Send Statistics";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // dgrdSendStats
            // 
            this.dgrdSendStats.AllowUserToAddRows = false;
            this.dgrdSendStats.AllowUserToDeleteRows = false;
            this.dgrdSendStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdSendStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdSendStats.Location = new System.Drawing.Point(3, 3);
            this.dgrdSendStats.Name = "dgrdSendStats";
            this.dgrdSendStats.ReadOnly = true;
            this.dgrdSendStats.Size = new System.Drawing.Size(614, 151);
            this.dgrdSendStats.TabIndex = 1;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.dgrdRequestStats);
            this.TabPage3.Location = new System.Drawing.Point(4, 22);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(620, 157);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "Data Request Statistics";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // dgrdRequestStats
            // 
            this.dgrdRequestStats.AllowUserToAddRows = false;
            this.dgrdRequestStats.AllowUserToDeleteRows = false;
            this.dgrdRequestStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdRequestStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdRequestStats.Location = new System.Drawing.Point(3, 3);
            this.dgrdRequestStats.Name = "dgrdRequestStats";
            this.dgrdRequestStats.ReadOnly = true;
            this.dgrdRequestStats.Size = new System.Drawing.Size(614, 151);
            this.dgrdRequestStats.TabIndex = 1;
            // 
            // btnUpdateStatistics
            // 
            this.btnUpdateStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatistics.Location = new System.Drawing.Point(655, 12);
            this.btnUpdateStatistics.Name = "btnUpdateStatistics";
            this.btnUpdateStatistics.Size = new System.Drawing.Size(132, 60);
            this.btnUpdateStatistics.TabIndex = 30;
            this.btnUpdateStatistics.Text = "Update Statistics";
            this.btnUpdateStatistics.UseVisualStyleBackColor = true;
            this.btnUpdateStatistics.Click += new System.EventHandler(this.btnUpdateStatistics_Click);
            // 
            // tmrAutoRequest
            // 
            this.tmrAutoRequest.Tick += new System.EventHandler(this.tmrAutoRequest_Tick);
            // 
            // frmP2PPortClientMainform
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 725);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdateStatistics);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.grpDataRequestTest);
            this.Controls.Add(this.grpDataSendTest);
            this.Name = "frmP2PPortClientMainform";
            this.Text = "P2P Socket Port Client Test Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmP2PSocketPortClientTestApplicationForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.grpDataSendTest.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage4.ResumeLayout(false);
            this.grpDataAttr.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            this.TabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendRate)).EndInit();
            this.grpDataRequestTest.ResumeLayout(false);
            this.grpDataRequestTest.PerformLayout();
            this.TabControl3.ResumeLayout(false);
            this.TabPage6.ResumeLayout(false);
            this.TabPage7.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRequestRate)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdGeneralStatistics)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdSendStats)).EndInit();
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdRequestStats)).EndInit();
            this.ResumeLayout(false);

		}
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.GroupBox grpDataSendTest;
		internal System.Windows.Forms.Button btnSendData;
		internal System.Windows.Forms.GroupBox grpDataRequestTest;
		internal System.Windows.Forms.TextBox txtDataNameToRequest;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnRequestData;
		internal System.Windows.Forms.ListBox lstAutoSend;
		internal System.Windows.Forms.Timer tmrAutoSend;
		internal System.Windows.Forms.Button btnRemoveAutoSendElement;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.CheckBox chkAutoSEnd;
		internal System.Windows.Forms.ListBox lstDataAttr;
		internal System.Windows.Forms.Button btnAddAttr;
		internal System.Windows.Forms.Button btnRemoveDataAttr;
		internal System.Windows.Forms.GroupBox grpDataAttr;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.Button btnSEndToAutoList;
		internal CommunicationsUISupportLibrary.CFDataManagerContainer CfDataManagerContainer1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.NumericUpDown nudSendRate;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.DataGridView dgrdGeneralStatistics;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.DataGridView dgrdSendStats;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.DataGridView dgrdRequestStats;
		internal System.Windows.Forms.Button btnUpdateStatistics;
		internal System.Windows.Forms.Timer tmrAutoRequest;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.CheckBox chkAutomaticREquest;
		internal System.Windows.Forms.NumericUpDown nudRequestRate;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.ListBox lstErrorsOnAutoSEnd;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TabControl TabControl3;
		internal System.Windows.Forms.TabPage TabPage6;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.ListBox lstErrorsOnAutoRequest;
        private System.ComponentModel.IContainer components;
		
	}
	
}
