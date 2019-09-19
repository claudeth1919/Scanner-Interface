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
	partial class frmSocketsServerTest : System.Windows.Forms.Form
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.lstConnectedClients = new System.Windows.Forms.ListBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.nudIntegerAutoBroadCastRAte = new System.Windows.Forms.NumericUpDown();
            this.btnIndBroadCast = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.chkAutoBroadCast = new System.Windows.Forms.CheckBox();
            this.grpDataSEnding = new System.Windows.Forms.GroupBox();
            this.btnAddDataToAutoBrodCast = new System.Windows.Forms.Button();
            this.CFDataManagerCointainer1 = new CommunicationsUISupportLibrary.CF_SocketsSErver_DataManagerContainer();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button4 = new System.Windows.Forms.Button();
            this.txtAutoBroadCastCounter = new System.Windows.Forms.TextBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.chkAutoSendToClient = new System.Windows.Forms.CheckBox();
            this.btnRemoveFromAutoBroadcastList = new System.Windows.Forms.Button();
            this.lstAutoBroadCast = new System.Windows.Forms.ListBox();
            this.lstOutgoingConnections = new System.Windows.Forms.ListBox();
            this.lstBoxDataReceived = new System.Windows.Forms.ListBox();
            this.TabControl3 = new System.Windows.Forms.TabControl();
            this.TabPage8 = new System.Windows.Forms.TabPage();
            this.lstIncommingConnections = new System.Windows.Forms.ListBox();
            this.TabPage9 = new System.Windows.Forms.TabPage();
            this.TabPage10 = new System.Windows.Forms.TabPage();
            this.lstDataAttributes = new System.Windows.Forms.ListBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkBroadCastReceivedData = new System.Windows.Forms.CheckBox();
            this.chkPutIncommingDataIntoList = new System.Windows.Forms.CheckBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.txtDataReceivedCount = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.Button2 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.tmrAutoBroadCast = new System.Windows.Forms.Timer(this.components);
            this.tmrAutomaticSendToSelectedClient = new System.Windows.Forms.Timer(this.components);
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.Button1 = new System.Windows.Forms.Button();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegerAutoBroadCastRAte)).BeginInit();
            this.grpDataSEnding.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.TabControl3.SuspendLayout();
            this.TabPage8.SuspendLayout();
            this.TabPage9.SuspendLayout();
            this.TabPage10.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.btnDisconnect);
            this.GroupBox1.Controls.Add(this.lstConnectedClients);
            this.GroupBox1.Location = new System.Drawing.Point(6, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(813, 121);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Connected Clients";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.btnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisconnect.Location = new System.Drawing.Point(20, 19);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(127, 23);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // lstConnectedClients
            // 
            this.lstConnectedClients.FormattingEnabled = true;
            this.lstConnectedClients.HorizontalScrollbar = true;
            this.lstConnectedClients.Location = new System.Drawing.Point(173, 7);
            this.lstConnectedClients.Name = "lstConnectedClients";
            this.lstConnectedClients.ScrollAlwaysVisible = true;
            this.lstConnectedClients.Size = new System.Drawing.Size(628, 108);
            this.lstConnectedClients.TabIndex = 0;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(121, 10);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(52, 13);
            this.Label10.TabIndex = 12;
            this.Label10.Text = "Rate (ms)";
            // 
            // nudIntegerAutoBroadCastRAte
            // 
            this.nudIntegerAutoBroadCastRAte.Location = new System.Drawing.Point(124, 29);
            this.nudIntegerAutoBroadCastRAte.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudIntegerAutoBroadCastRAte.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntegerAutoBroadCastRAte.Name = "nudIntegerAutoBroadCastRAte";
            this.nudIntegerAutoBroadCastRAte.Size = new System.Drawing.Size(60, 20);
            this.nudIntegerAutoBroadCastRAte.TabIndex = 11;
            this.nudIntegerAutoBroadCastRAte.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnIndBroadCast
            // 
            this.btnIndBroadCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIndBroadCast.Location = new System.Drawing.Point(6, 298);
            this.btnIndBroadCast.Name = "btnIndBroadCast";
            this.btnIndBroadCast.Size = new System.Drawing.Size(74, 70);
            this.btnIndBroadCast.TabIndex = 5;
            this.btnIndBroadCast.Text = "Broad Cast Data";
            this.btnIndBroadCast.UseVisualStyleBackColor = true;
            this.btnIndBroadCast.Click += new System.EventHandler(this.btnIndBroadCast_Click_1);
            // 
            // btnSendData
            // 
            this.btnSendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendData.Location = new System.Drawing.Point(8, 221);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(74, 66);
            this.btnSendData.TabIndex = 4;
            this.btnSendData.Text = "Send Data to Client";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // chkAutoBroadCast
            // 
            this.chkAutoBroadCast.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoBroadCast.AutoSize = true;
            this.chkAutoBroadCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoBroadCast.Location = new System.Drawing.Point(6, 10);
            this.chkAutoBroadCast.Name = "chkAutoBroadCast";
            this.chkAutoBroadCast.Size = new System.Drawing.Size(91, 42);
            this.chkAutoBroadCast.TabIndex = 7;
            this.chkAutoBroadCast.Text = "Automatic \r\nBroadCast";
            this.chkAutoBroadCast.UseVisualStyleBackColor = true;
            this.chkAutoBroadCast.CheckedChanged += new System.EventHandler(this.chkAutoBroadCast_CheckedChanged);
            // 
            // grpDataSEnding
            // 
            this.grpDataSEnding.Controls.Add(this.btnAddDataToAutoBrodCast);
            this.grpDataSEnding.Controls.Add(this.CFDataManagerCointainer1);
            this.grpDataSEnding.Controls.Add(this.GroupBox2);
            this.grpDataSEnding.Controls.Add(this.btnSendData);
            this.grpDataSEnding.Controls.Add(this.btnIndBroadCast);
            this.grpDataSEnding.Location = new System.Drawing.Point(6, 130);
            this.grpDataSEnding.Name = "grpDataSEnding";
            this.grpDataSEnding.Size = new System.Drawing.Size(1085, 372);
            this.grpDataSEnding.TabIndex = 1;
            this.grpDataSEnding.TabStop = false;
            this.grpDataSEnding.Text = "Data Sending";
            // 
            // btnAddDataToAutoBrodCast
            // 
            this.btnAddDataToAutoBrodCast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDataToAutoBrodCast.Location = new System.Drawing.Point(266, 163);
            this.btnAddDataToAutoBrodCast.Name = "btnAddDataToAutoBrodCast";
            this.btnAddDataToAutoBrodCast.Size = new System.Drawing.Size(90, 61);
            this.btnAddDataToAutoBrodCast.TabIndex = 14;
            this.btnAddDataToAutoBrodCast.Text = "Add data to\r\nauto Broadcast \r\nlist";
            this.btnAddDataToAutoBrodCast.UseVisualStyleBackColor = true;
            this.btnAddDataToAutoBrodCast.Click += new System.EventHandler(this.btnAddDataToAutoBrodCast_Click);
            // 
            // CFDataManagerCointainer1
            // 
            this.CFDataManagerCointainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CFDataManagerCointainer1.Location = new System.Drawing.Point(8, 19);
            this.CFDataManagerCointainer1.Name = "CFDataManagerCointainer1";
            this.CFDataManagerCointainer1.Size = new System.Drawing.Size(1071, 205);
            this.CFDataManagerCointainer1.TabIndex = 14;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.GroupBox5);
            this.GroupBox2.Controls.Add(this.GroupBox3);
            this.GroupBox2.Controls.Add(this.btnRemoveFromAutoBroadcastList);
            this.GroupBox2.Controls.Add(this.lstAutoBroadCast);
            this.GroupBox2.Location = new System.Drawing.Point(85, 221);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(716, 151);
            this.GroupBox2.TabIndex = 13;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Auto Broad Cast";
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.Label1);
            this.GroupBox5.Controls.Add(this.Button4);
            this.GroupBox5.Controls.Add(this.txtAutoBroadCastCounter);
            this.GroupBox5.Location = new System.Drawing.Point(313, 12);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(200, 133);
            this.GroupBox5.TabIndex = 21;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Statistics ";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(120, 13);
            this.Label1.TabIndex = 17;
            this.Label1.Text = "Auto Broadcast Counter";
            // 
            // Button4
            // 
            this.Button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button4.Location = new System.Drawing.Point(127, 18);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(70, 36);
            this.Button4.TabIndex = 19;
            this.Button4.Text = "Reset";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // txtAutoBroadCastCounter
            // 
            this.txtAutoBroadCastCounter.Location = new System.Drawing.Point(8, 32);
            this.txtAutoBroadCastCounter.Name = "txtAutoBroadCastCounter";
            this.txtAutoBroadCastCounter.ReadOnly = true;
            this.txtAutoBroadCastCounter.Size = new System.Drawing.Size(100, 20);
            this.txtAutoBroadCastCounter.TabIndex = 18;
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.chkAutoBroadCast);
            this.GroupBox3.Controls.Add(this.chkAutoSendToClient);
            this.GroupBox3.Controls.Add(this.Label10);
            this.GroupBox3.Controls.Add(this.nudIntegerAutoBroadCastRAte);
            this.GroupBox3.Location = new System.Drawing.Point(517, 5);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(200, 100);
            this.GroupBox3.TabIndex = 20;
            this.GroupBox3.TabStop = false;
            // 
            // chkAutoSendToClient
            // 
            this.chkAutoSendToClient.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkAutoSendToClient.AutoSize = true;
            this.chkAutoSendToClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutoSendToClient.Location = new System.Drawing.Point(6, 55);
            this.chkAutoSendToClient.Name = "chkAutoSendToClient";
            this.chkAutoSendToClient.Size = new System.Drawing.Size(147, 42);
            this.chkAutoSendToClient.TabIndex = 16;
            this.chkAutoSendToClient.Text = "Automatic Send to \r\nthe selected Client";
            this.chkAutoSendToClient.UseVisualStyleBackColor = true;
            this.chkAutoSendToClient.CheckedChanged += new System.EventHandler(this.chkAutoSendToClient_CheckedChanged);
            // 
            // btnRemoveFromAutoBroadcastList
            // 
            this.btnRemoveFromAutoBroadcastList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveFromAutoBroadcastList.Location = new System.Drawing.Point(6, 112);
            this.btnRemoveFromAutoBroadcastList.Name = "btnRemoveFromAutoBroadcastList";
            this.btnRemoveFromAutoBroadcastList.Size = new System.Drawing.Size(140, 33);
            this.btnRemoveFromAutoBroadcastList.TabIndex = 15;
            this.btnRemoveFromAutoBroadcastList.Text = "Remove From list\r\n";
            this.btnRemoveFromAutoBroadcastList.UseVisualStyleBackColor = true;
            this.btnRemoveFromAutoBroadcastList.Click += new System.EventHandler(this.btnRemoveFromAutoBroadcastList_Click);
            // 
            // lstAutoBroadCast
            // 
            this.lstAutoBroadCast.FormattingEnabled = true;
            this.lstAutoBroadCast.Location = new System.Drawing.Point(6, 15);
            this.lstAutoBroadCast.Name = "lstAutoBroadCast";
            this.lstAutoBroadCast.Size = new System.Drawing.Size(301, 95);
            this.lstAutoBroadCast.TabIndex = 13;
            // 
            // lstOutgoingConnections
            // 
            this.lstOutgoingConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstOutgoingConnections.FormattingEnabled = true;
            this.lstOutgoingConnections.HorizontalScrollbar = true;
            this.lstOutgoingConnections.Location = new System.Drawing.Point(3, 3);
            this.lstOutgoingConnections.Name = "lstOutgoingConnections";
            this.lstOutgoingConnections.ScrollAlwaysVisible = true;
            this.lstOutgoingConnections.Size = new System.Drawing.Size(1068, 174);
            this.lstOutgoingConnections.TabIndex = 1;
            // 
            // lstBoxDataReceived
            // 
            this.lstBoxDataReceived.FormattingEnabled = true;
            this.lstBoxDataReceived.HorizontalScrollbar = true;
            this.lstBoxDataReceived.Location = new System.Drawing.Point(3, 3);
            this.lstBoxDataReceived.Name = "lstBoxDataReceived";
            this.lstBoxDataReceived.ScrollAlwaysVisible = true;
            this.lstBoxDataReceived.Size = new System.Drawing.Size(638, 121);
            this.lstBoxDataReceived.TabIndex = 1;
            this.lstBoxDataReceived.SelectedIndexChanged += new System.EventHandler(this.lstBoxDataReceived_SelectedIndexChanged);
            this.lstBoxDataReceived.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstBoxDataReceived_MouseDoubleClick);
            // 
            // TabControl3
            // 
            this.TabControl3.Controls.Add(this.TabPage8);
            this.TabControl3.Controls.Add(this.TabPage9);
            this.TabControl3.Controls.Add(this.TabPage10);
            this.TabControl3.Location = new System.Drawing.Point(2, 19);
            this.TabControl3.Name = "TabControl3";
            this.TabControl3.SelectedIndex = 0;
            this.TabControl3.Size = new System.Drawing.Size(1082, 206);
            this.TabControl3.TabIndex = 7;
            // 
            // TabPage8
            // 
            this.TabPage8.Controls.Add(this.lstIncommingConnections);
            this.TabPage8.Location = new System.Drawing.Point(4, 22);
            this.TabPage8.Name = "TabPage8";
            this.TabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage8.Size = new System.Drawing.Size(1074, 180);
            this.TabPage8.TabIndex = 0;
            this.TabPage8.Text = "Incomming Connections";
            this.TabPage8.UseVisualStyleBackColor = true;
            // 
            // lstIncommingConnections
            // 
            this.lstIncommingConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstIncommingConnections.FormattingEnabled = true;
            this.lstIncommingConnections.HorizontalScrollbar = true;
            this.lstIncommingConnections.Location = new System.Drawing.Point(3, 3);
            this.lstIncommingConnections.Name = "lstIncommingConnections";
            this.lstIncommingConnections.ScrollAlwaysVisible = true;
            this.lstIncommingConnections.Size = new System.Drawing.Size(1068, 174);
            this.lstIncommingConnections.TabIndex = 2;
            // 
            // TabPage9
            // 
            this.TabPage9.Controls.Add(this.lstOutgoingConnections);
            this.TabPage9.Location = new System.Drawing.Point(4, 22);
            this.TabPage9.Name = "TabPage9";
            this.TabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage9.Size = new System.Drawing.Size(1074, 180);
            this.TabPage9.TabIndex = 1;
            this.TabPage9.Text = "Out Going Connections";
            this.TabPage9.UseVisualStyleBackColor = true;
            // 
            // TabPage10
            // 
            this.TabPage10.Controls.Add(this.lstDataAttributes);
            this.TabPage10.Controls.Add(this.Label2);
            this.TabPage10.Controls.Add(this.lstBoxDataReceived);
            this.TabPage10.Controls.Add(this.chkBroadCastReceivedData);
            this.TabPage10.Controls.Add(this.chkPutIncommingDataIntoList);
            this.TabPage10.Controls.Add(this.Button3);
            this.TabPage10.Controls.Add(this.txtDataReceivedCount);
            this.TabPage10.Controls.Add(this.Label14);
            this.TabPage10.Controls.Add(this.Button2);
            this.TabPage10.Location = new System.Drawing.Point(4, 22);
            this.TabPage10.Name = "TabPage10";
            this.TabPage10.Size = new System.Drawing.Size(1074, 180);
            this.TabPage10.TabIndex = 2;
            this.TabPage10.Text = "Data Reception From Clients";
            this.TabPage10.UseVisualStyleBackColor = true;
            // 
            // lstDataAttributes
            // 
            this.lstDataAttributes.FormattingEnabled = true;
            this.lstDataAttributes.Location = new System.Drawing.Point(647, 19);
            this.lstDataAttributes.Name = "lstDataAttributes";
            this.lstDataAttributes.Size = new System.Drawing.Size(301, 95);
            this.lstDataAttributes.TabIndex = 36;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(647, 3);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 13);
            this.Label2.TabIndex = 35;
            this.Label2.Text = "Data Attributes ";
            // 
            // chkBroadCastReceivedData
            // 
            this.chkBroadCastReceivedData.AutoSize = true;
            this.chkBroadCastReceivedData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBroadCastReceivedData.Location = new System.Drawing.Point(339, 160);
            this.chkBroadCastReceivedData.Name = "chkBroadCastReceivedData";
            this.chkBroadCastReceivedData.Size = new System.Drawing.Size(212, 20);
            this.chkBroadCastReceivedData.TabIndex = 34;
            this.chkBroadCastReceivedData.Text = "Broad Cast Received Data";
            this.chkBroadCastReceivedData.UseVisualStyleBackColor = true;
            // 
            // chkPutIncommingDataIntoList
            // 
            this.chkPutIncommingDataIntoList.AutoSize = true;
            this.chkPutIncommingDataIntoList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPutIncommingDataIntoList.Location = new System.Drawing.Point(339, 136);
            this.chkPutIncommingDataIntoList.Name = "chkPutIncommingDataIntoList";
            this.chkPutIncommingDataIntoList.Size = new System.Drawing.Size(162, 20);
            this.chkPutIncommingDataIntoList.TabIndex = 33;
            this.chkPutIncommingDataIntoList.Text = "Show  Data into List";
            this.chkPutIncommingDataIntoList.UseVisualStyleBackColor = true;
            // 
            // Button3
            // 
            this.Button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button3.Location = new System.Drawing.Point(716, 137);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(71, 41);
            this.Button3.TabIndex = 32;
            this.Button3.Text = "Clear List";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // txtDataReceivedCount
            // 
            this.txtDataReceivedCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataReceivedCount.Location = new System.Drawing.Point(168, 147);
            this.txtDataReceivedCount.Name = "txtDataReceivedCount";
            this.txtDataReceivedCount.ReadOnly = true;
            this.txtDataReceivedCount.Size = new System.Drawing.Size(126, 26);
            this.txtDataReceivedCount.TabIndex = 31;
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label14.Location = new System.Drawing.Point(1, 144);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(137, 32);
            this.Label14.TabIndex = 30;
            this.Label14.Text = "Data Received\rFrom Clients Count";
            // 
            // Button2
            // 
            this.Button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.Location = new System.Drawing.Point(639, 137);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(71, 41);
            this.Button2.TabIndex = 2;
            this.Button2.Text = "Reset  \r\nCount";
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.TabControl3);
            this.GroupBox4.Location = new System.Drawing.Point(6, 502);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(1085, 265);
            this.GroupBox4.TabIndex = 8;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Server Events";
            // 
            // tmrAutoBroadCast
            // 
            this.tmrAutoBroadCast.Tick += new System.EventHandler(this.tmrAutoBroadCast_Tick);
            // 
            // tmrAutomaticSendToSelectedClient
            // 
            this.tmrAutomaticSendToSelectedClient.Tick += new System.EventHandler(this.tmrAutomaticSendToSelectedClient_Tick);
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl1.Location = new System.Drawing.Point(0, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1101, 753);
            this.TabControl1.TabIndex = 9;
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox4);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Controls.Add(this.grpDataSEnding);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(1093, 727);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Sockets Server";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.Button1);
            this.TabPage2.Controls.Add(this.lstSTXEventLog);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1093, 727);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "STXEventLog";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(688, 707);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(114, 37);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Clear List";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.Location = new System.Drawing.Point(0, 3);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.Size = new System.Drawing.Size(807, 693);
            this.lstSTXEventLog.TabIndex = 0;
            this.lstSTXEventLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSTXEventLog_MouseDoubleClick);
            // 
            // frmSocketsServerTest
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 753);
            this.ControlBox = false;
            this.Controls.Add(this.TabControl1);
            this.Name = "frmSocketsServerTest";
            this.Text = "DataSocketServerTestForm";
            this.Load += new System.EventHandler(this.frmSocketsServerTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIntegerAutoBroadCastRAte)).EndInit();
            this.grpDataSEnding.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.TabControl3.ResumeLayout(false);
            this.TabPage8.ResumeLayout(false);
            this.TabPage9.ResumeLayout(false);
            this.TabPage10.ResumeLayout(false);
            this.TabPage10.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.TabControl1.ResumeLayout(false);
            this.TabPage1.ResumeLayout(false);
            this.TabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.GroupBox grpDataSEnding;
		internal System.Windows.Forms.Button btnSendData;
		internal System.Windows.Forms.ListBox lstConnectedClients;
		internal System.Windows.Forms.Button btnIndBroadCast;
		internal System.Windows.Forms.ListBox lstOutgoingConnections;
		internal System.Windows.Forms.ListBox lstBoxDataReceived;
		internal System.Windows.Forms.CheckBox chkAutoBroadCast;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.NumericUpDown nudIntegerAutoBroadCastRAte;
		internal System.Windows.Forms.TabControl TabControl3;
		internal System.Windows.Forms.TabPage TabPage8;
		internal System.Windows.Forms.TabPage TabPage9;
		internal System.Windows.Forms.ListBox lstIncommingConnections;
		internal System.Windows.Forms.TabPage TabPage10;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.TextBox txtDataReceivedCount;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.CheckBox chkPutIncommingDataIntoList;
		internal System.Windows.Forms.Button btnDisconnect;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Button btnAddDataToAutoBrodCast;
		internal System.Windows.Forms.ListBox lstAutoBroadCast;
		internal System.Windows.Forms.Button btnRemoveFromAutoBroadcastList;
		internal System.Windows.Forms.CheckBox chkAutoSendToClient;
		internal System.Windows.Forms.Timer tmrAutoBroadCast;
		internal System.Windows.Forms.Timer tmrAutomaticSendToSelectedClient;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.TextBox txtAutoBroadCastCounter;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.CheckBox chkBroadCastReceivedData;
		internal CommunicationsUISupportLibrary.CF_SocketsSErver_DataManagerContainer CFDataManagerCointainer1;
		internal System.Windows.Forms.ListBox lstDataAttributes;
		internal System.Windows.Forms.Label Label2;
        private System.ComponentModel.IContainer components;
	}
	
}
