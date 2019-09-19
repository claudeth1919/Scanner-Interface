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
	partial class CF_CNDCommsEnvironment_ComponentHandler : System.Windows.Forms.UserControl
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
			this.Label1 = new System.Windows.Forms.Label();
			base.Load += new System.EventHandler(CFSTXCommsEnvironment_ComponentSimulationHandler_Load);
			this.txtComponentName = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.tabpDataReception = new System.Windows.Forms.TabPage();
			this.pnlDataReception = new System.Windows.Forms.Panel();
			this.btnClearDataReception = new System.Windows.Forms.Button();
			this.btnClearDataReception.Click += new System.EventHandler(this.btnClearDataReception_Click);
			this.lstBoxDataReception = new System.Windows.Forms.ListBox();
			this.lstBoxDataReception.SelectedIndexChanged += new System.EventHandler(this.lstBoxDataReception_SelectedIndexChanged);
			this.chkLogDataReception = new System.Windows.Forms.CheckBox();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.TabControl2 = new System.Windows.Forms.TabControl();
			this.TabPage7 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.pnlDataRequest = new System.Windows.Forms.Panel();
			this.TabPage8 = new System.Windows.Forms.TabPage();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.btnChoseComponentForDataRequest = new System.Windows.Forms.Button();
			this.btnChoseComponentForDataRequest.Click += new System.EventHandler(this.btnChoseComponentForDataRequest_Click);
			this.txtRemoteComponentToRequestData = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtDataNameToRequest = new System.Windows.Forms.TextBox();
			this.pnlDataRequestedResult = new System.Windows.Forms.Panel();
			this.Label5 = new System.Windows.Forms.Label();
			this.btnRequestFromRemotecomponent = new System.Windows.Forms.Button();
			this.btnRequestFromRemotecomponent.Click += new System.EventHandler(this.btnRequestFromRemotecomponent_Click);
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.btnSendDataToComponent = new System.Windows.Forms.Button();
			this.btnSendDataToComponent.Click += new System.EventHandler(this.btnSendDataToComponent_Click);
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.btnChoseComponentToDataSend = new System.Windows.Forms.Button();
			this.btnChoseComponentToDataSend.Click += new System.EventHandler(this.btnChoseComponentToDataSend_Click);
			this.txtRemoteComponentNameToSendData = new System.Windows.Forms.TextBox();
			this.Label6 = new System.Windows.Forms.Label();
			this.pnlDatacontainerForDataSend = new System.Windows.Forms.Panel();
			this.Label3 = new System.Windows.Forms.Label();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.btnUpdateStatistics = new System.Windows.Forms.Button();
			this.btnUpdateStatistics.Click += new System.EventHandler(this.btnUpdateStatistics_Click);
			this.tabStatistics = new System.Windows.Forms.TabControl();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.dgrdGeneralStatistics = new System.Windows.Forms.DataGridView();
			this.TabPage5 = new System.Windows.Forms.TabPage();
			this.dgrdReceptionStatistics = new System.Windows.Forms.DataGridView();
			this.TabPage6 = new System.Windows.Forms.TabPage();
			this.dgrdRequestStatistics = new System.Windows.Forms.DataGridView();
			this.TabControl1.SuspendLayout();
			this.tabpDataReception.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.TabControl2.SuspendLayout();
			this.TabPage7.SuspendLayout();
			this.TabPage8.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.tabStatistics.SuspendLayout();
			this.TabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdGeneralStatistics).BeginInit();
			this.TabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdReceptionStatistics).BeginInit();
			this.TabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.dgrdRequestStatistics).BeginInit();
			this.SuspendLayout();
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(7, 5);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(105, 15);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "ComponentName";
			//
			//txtComponentName
			//
			this.txtComponentName.BackColor = System.Drawing.Color.Yellow;
			this.txtComponentName.Location = new System.Drawing.Point(118, 3);
			this.txtComponentName.Name = "txtComponentName";
			this.txtComponentName.ReadOnly = true;
			this.txtComponentName.Size = new System.Drawing.Size(405, 21);
			this.txtComponentName.TabIndex = 1;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.tabpDataReception);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Location = new System.Drawing.Point(3, 30);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(671, 414);
			this.TabControl1.TabIndex = 2;
			//
			//tabpDataReception
			//
			this.tabpDataReception.Controls.Add(this.pnlDataReception);
			this.tabpDataReception.Controls.Add(this.btnClearDataReception);
			this.tabpDataReception.Controls.Add(this.lstBoxDataReception);
			this.tabpDataReception.Controls.Add(this.chkLogDataReception);
			this.tabpDataReception.Location = new System.Drawing.Point(4, 24);
			this.tabpDataReception.Name = "tabpDataReception";
			this.tabpDataReception.Padding = new System.Windows.Forms.Padding(3);
			this.tabpDataReception.Size = new System.Drawing.Size(663, 386);
			this.tabpDataReception.TabIndex = 0;
			this.tabpDataReception.Text = "Data Reception Handling";
			this.tabpDataReception.UseVisualStyleBackColor = true;
			//
			//pnlDataReception
			//
			this.pnlDataReception.Location = new System.Drawing.Point(160, 0);
			this.pnlDataReception.Name = "pnlDataReception";
			this.pnlDataReception.Size = new System.Drawing.Size(503, 260);
			this.pnlDataReception.TabIndex = 3;
			//
			//btnClearDataReception
			//
			this.btnClearDataReception.Location = new System.Drawing.Point(568, 266);
			this.btnClearDataReception.Name = "btnClearDataReception";
			this.btnClearDataReception.Size = new System.Drawing.Size(89, 23);
			this.btnClearDataReception.TabIndex = 2;
			this.btnClearDataReception.Text = "Clear ";
			this.btnClearDataReception.UseVisualStyleBackColor = true;
			//
			//lstBoxDataReception
			//
			this.lstBoxDataReception.FormattingEnabled = true;
			this.lstBoxDataReception.ItemHeight = 15;
			this.lstBoxDataReception.Location = new System.Drawing.Point(0, 0);
			this.lstBoxDataReception.Name = "lstBoxDataReception";
			this.lstBoxDataReception.Size = new System.Drawing.Size(157, 334);
			this.lstBoxDataReception.TabIndex = 1;
			//
			//chkLogDataReception
			//
			this.chkLogDataReception.AutoSize = true;
			this.chkLogDataReception.Location = new System.Drawing.Point(6, 349);
			this.chkLogDataReception.Name = "chkLogDataReception";
			this.chkLogDataReception.Size = new System.Drawing.Size(136, 19);
			this.chkLogDataReception.TabIndex = 0;
			this.chkLogDataReception.Text = "Log Data Reception";
			this.chkLogDataReception.UseVisualStyleBackColor = true;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.TabControl2);
			this.TabPage2.Location = new System.Drawing.Point(4, 24);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(663, 386);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Data Requesting Handling";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//TabControl2
			//
			this.TabControl2.Controls.Add(this.TabPage7);
			this.TabControl2.Controls.Add(this.TabPage8);
			this.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl2.Location = new System.Drawing.Point(3, 3);
			this.TabControl2.Name = "TabControl2";
			this.TabControl2.SelectedIndex = 0;
			this.TabControl2.Size = new System.Drawing.Size(657, 380);
			this.TabControl2.TabIndex = 3;
			//
			//TabPage7
			//
			this.TabPage7.Controls.Add(this.Label2);
			this.TabPage7.Controls.Add(this.pnlDataRequest);
			this.TabPage7.Location = new System.Drawing.Point(4, 24);
			this.TabPage7.Name = "TabPage7";
			this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage7.Size = new System.Drawing.Size(649, 352);
			this.TabPage7.TabIndex = 0;
			this.TabPage7.Text = "Local Data Retrieval";
			this.TabPage7.UseVisualStyleBackColor = true;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.ForeColor = System.Drawing.Color.Blue;
			this.Label2.Location = new System.Drawing.Point(6, 3);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(291, 15);
			this.Label2.TabIndex = 1;
			this.Label2.Text = "Data to be Retrieved Back from other Components";
			//
			//pnlDataRequest
			//
			this.pnlDataRequest.Location = new System.Drawing.Point(3, 21);
			this.pnlDataRequest.Name = "pnlDataRequest";
			this.pnlDataRequest.Size = new System.Drawing.Size(646, 325);
			this.pnlDataRequest.TabIndex = 2;
			//
			//TabPage8
			//
			this.TabPage8.Controls.Add(this.GroupBox1);
			this.TabPage8.Location = new System.Drawing.Point(4, 24);
			this.TabPage8.Name = "TabPage8";
			this.TabPage8.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage8.Size = new System.Drawing.Size(649, 352);
			this.TabPage8.TabIndex = 1;
			this.TabPage8.Text = "Remote Data Requesting ";
			this.TabPage8.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.GroupBox2);
			this.GroupBox1.Controls.Add(this.txtDataNameToRequest);
			this.GroupBox1.Controls.Add(this.pnlDataRequestedResult);
			this.GroupBox1.Controls.Add(this.Label5);
			this.GroupBox1.Controls.Add(this.btnRequestFromRemotecomponent);
			this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GroupBox1.Location = new System.Drawing.Point(3, 3);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(643, 346);
			this.GroupBox1.TabIndex = 5;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Data Request From another Components";
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.btnChoseComponentForDataRequest);
			this.GroupBox2.Controls.Add(this.txtRemoteComponentToRequestData);
			this.GroupBox2.Controls.Add(this.Label4);
			this.GroupBox2.Location = new System.Drawing.Point(6, 47);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(498, 63);
			this.GroupBox2.TabIndex = 6;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Remote Component to Request Data";
			//
			//btnChoseComponentForDataRequest
			//
			this.btnChoseComponentForDataRequest.Location = new System.Drawing.Point(367, 11);
			this.btnChoseComponentForDataRequest.Name = "btnChoseComponentForDataRequest";
			this.btnChoseComponentForDataRequest.Size = new System.Drawing.Size(125, 25);
			this.btnChoseComponentForDataRequest.TabIndex = 7;
			this.btnChoseComponentForDataRequest.Text = "Chose Component";
			this.btnChoseComponentForDataRequest.UseVisualStyleBackColor = true;
			//
			//txtRemoteComponentToRequestData
			//
			this.txtRemoteComponentToRequestData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemoteComponentToRequestData.Location = new System.Drawing.Point(6, 39);
			this.txtRemoteComponentToRequestData.Name = "txtRemoteComponentToRequestData";
			this.txtRemoteComponentToRequestData.ReadOnly = true;
			this.txtRemoteComponentToRequestData.Size = new System.Drawing.Size(486, 21);
			this.txtRemoteComponentToRequestData.TabIndex = 8;
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(11, 21);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(72, 15);
			this.Label4.TabIndex = 7;
			this.Label4.Text = "Component";
			//
			//txtDataNameToRequest
			//
			this.txtDataNameToRequest.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtDataNameToRequest.Location = new System.Drawing.Point(154, 20);
			this.txtDataNameToRequest.Name = "txtDataNameToRequest";
			this.txtDataNameToRequest.Size = new System.Drawing.Size(369, 21);
			this.txtDataNameToRequest.TabIndex = 4;
			//
			//pnlDataRequestedResult
			//
			this.pnlDataRequestedResult.Location = new System.Drawing.Point(6, 113);
			this.pnlDataRequestedResult.Name = "pnlDataRequestedResult";
			this.pnlDataRequestedResult.Size = new System.Drawing.Size(625, 226);
			this.pnlDataRequestedResult.TabIndex = 6;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(15, 23);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(133, 15);
			this.Label5.TabIndex = 3;
			this.Label5.Text = "Data Name to Request";
			//
			//btnRequestFromRemotecomponent
			//
			this.btnRequestFromRemotecomponent.Location = new System.Drawing.Point(510, 74);
			this.btnRequestFromRemotecomponent.Name = "btnRequestFromRemotecomponent";
			this.btnRequestFromRemotecomponent.Size = new System.Drawing.Size(130, 35);
			this.btnRequestFromRemotecomponent.TabIndex = 5;
			this.btnRequestFromRemotecomponent.Text = "Request Data ";
			this.btnRequestFromRemotecomponent.UseVisualStyleBackColor = true;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.btnSendDataToComponent);
			this.TabPage1.Controls.Add(this.GroupBox3);
			this.TabPage1.Controls.Add(this.pnlDatacontainerForDataSend);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Location = new System.Drawing.Point(4, 24);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(663, 386);
			this.TabPage1.TabIndex = 2;
			this.TabPage1.Text = "Data Sending Handling ";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//btnSendDataToComponent
			//
			this.btnSendDataToComponent.Location = new System.Drawing.Point(510, 58);
			this.btnSendDataToComponent.Name = "btnSendDataToComponent";
			this.btnSendDataToComponent.Size = new System.Drawing.Size(130, 35);
			this.btnSendDataToComponent.TabIndex = 8;
			this.btnSendDataToComponent.Text = "Send Data";
			this.btnSendDataToComponent.UseVisualStyleBackColor = true;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.btnChoseComponentToDataSend);
			this.GroupBox3.Controls.Add(this.txtRemoteComponentNameToSendData);
			this.GroupBox3.Controls.Add(this.Label6);
			this.GroupBox3.Location = new System.Drawing.Point(6, 33);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(498, 63);
			this.GroupBox3.TabIndex = 7;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Remote Component to Send Data";
			//
			//btnChoseComponentToDataSend
			//
			this.btnChoseComponentToDataSend.Location = new System.Drawing.Point(367, 11);
			this.btnChoseComponentToDataSend.Name = "btnChoseComponentToDataSend";
			this.btnChoseComponentToDataSend.Size = new System.Drawing.Size(125, 25);
			this.btnChoseComponentToDataSend.TabIndex = 7;
			this.btnChoseComponentToDataSend.Text = "Chose Component";
			this.btnChoseComponentToDataSend.UseVisualStyleBackColor = true;
			//
			//txtRemoteComponentNameToSendData
			//
			this.txtRemoteComponentNameToSendData.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtRemoteComponentNameToSendData.Location = new System.Drawing.Point(6, 39);
			this.txtRemoteComponentNameToSendData.Name = "txtRemoteComponentNameToSendData";
			this.txtRemoteComponentNameToSendData.ReadOnly = true;
			this.txtRemoteComponentNameToSendData.Size = new System.Drawing.Size(486, 21);
			this.txtRemoteComponentNameToSendData.TabIndex = 8;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.Location = new System.Drawing.Point(11, 21);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(72, 15);
			this.Label6.TabIndex = 7;
			this.Label6.Text = "Component";
			//
			//pnlDatacontainerForDataSend
			//
			this.pnlDatacontainerForDataSend.Location = new System.Drawing.Point(3, 102);
			this.pnlDatacontainerForDataSend.Name = "pnlDatacontainerForDataSend";
			this.pnlDatacontainerForDataSend.Size = new System.Drawing.Size(654, 273);
			this.pnlDatacontainerForDataSend.TabIndex = 3;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.ForeColor = System.Drawing.Color.Blue;
			this.Label3.Location = new System.Drawing.Point(0, 3);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(224, 15);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Data to be sent to remote components";
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.btnUpdateStatistics);
			this.TabPage3.Controls.Add(this.tabStatistics);
			this.TabPage3.Location = new System.Drawing.Point(4, 24);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(663, 386);
			this.TabPage3.TabIndex = 3;
			this.TabPage3.Text = "Statistics";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//btnUpdateStatistics
			//
			this.btnUpdateStatistics.Location = new System.Drawing.Point(520, 357);
			this.btnUpdateStatistics.Name = "btnUpdateStatistics";
			this.btnUpdateStatistics.Size = new System.Drawing.Size(140, 23);
			this.btnUpdateStatistics.TabIndex = 1;
			this.btnUpdateStatistics.Text = "Update Statistics";
			this.btnUpdateStatistics.UseVisualStyleBackColor = true;
			//
			//tabStatistics
			//
			this.tabStatistics.Controls.Add(this.TabPage4);
			this.tabStatistics.Controls.Add(this.TabPage5);
			this.tabStatistics.Controls.Add(this.TabPage6);
			this.tabStatistics.Location = new System.Drawing.Point(0, 1);
			this.tabStatistics.Name = "tabStatistics";
			this.tabStatistics.SelectedIndex = 0;
			this.tabStatistics.Size = new System.Drawing.Size(657, 350);
			this.tabStatistics.TabIndex = 0;
			//
			//TabPage4
			//
			this.TabPage4.Controls.Add(this.dgrdGeneralStatistics);
			this.TabPage4.Location = new System.Drawing.Point(4, 24);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage4.Size = new System.Drawing.Size(649, 322);
			this.TabPage4.TabIndex = 0;
			this.TabPage4.Text = "General Statistics";
			this.TabPage4.UseVisualStyleBackColor = true;
			//
			//dgrdGeneralStatistics
			//
			this.dgrdGeneralStatistics.AllowUserToAddRows = false;
			this.dgrdGeneralStatistics.AllowUserToDeleteRows = false;
			this.dgrdGeneralStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrdGeneralStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdGeneralStatistics.Location = new System.Drawing.Point(3, 3);
			this.dgrdGeneralStatistics.Name = "dgrdGeneralStatistics";
			this.dgrdGeneralStatistics.ReadOnly = true;
			this.dgrdGeneralStatistics.Size = new System.Drawing.Size(643, 316);
			this.dgrdGeneralStatistics.TabIndex = 0;
			//
			//TabPage5
			//
			this.TabPage5.Controls.Add(this.dgrdReceptionStatistics);
			this.TabPage5.Location = new System.Drawing.Point(4, 24);
			this.TabPage5.Name = "TabPage5";
			this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage5.Size = new System.Drawing.Size(649, 322);
			this.TabPage5.TabIndex = 1;
			this.TabPage5.Text = "Data Reception Statistics";
			this.TabPage5.UseVisualStyleBackColor = true;
			//
			//dgrdReceptionStatistics
			//
			this.dgrdReceptionStatistics.AllowUserToAddRows = false;
			this.dgrdReceptionStatistics.AllowUserToDeleteRows = false;
			this.dgrdReceptionStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrdReceptionStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdReceptionStatistics.Location = new System.Drawing.Point(3, 3);
			this.dgrdReceptionStatistics.Name = "dgrdReceptionStatistics";
			this.dgrdReceptionStatistics.ReadOnly = true;
			this.dgrdReceptionStatistics.Size = new System.Drawing.Size(643, 316);
			this.dgrdReceptionStatistics.TabIndex = 0;
			//
			//TabPage6
			//
			this.TabPage6.Controls.Add(this.dgrdRequestStatistics);
			this.TabPage6.Location = new System.Drawing.Point(4, 24);
			this.TabPage6.Name = "TabPage6";
			this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage6.Size = new System.Drawing.Size(649, 322);
			this.TabPage6.TabIndex = 2;
			this.TabPage6.Text = "Requests Statistics";
			this.TabPage6.UseVisualStyleBackColor = true;
			//
			//dgrdRequestStatistics
			//
			this.dgrdRequestStatistics.AllowUserToAddRows = false;
			this.dgrdRequestStatistics.AllowUserToDeleteRows = false;
			this.dgrdRequestStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgrdRequestStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgrdRequestStatistics.Location = new System.Drawing.Point(3, 3);
			this.dgrdRequestStatistics.Name = "dgrdRequestStatistics";
			this.dgrdRequestStatistics.ReadOnly = true;
			this.dgrdRequestStatistics.Size = new System.Drawing.Size(643, 316);
			this.dgrdRequestStatistics.TabIndex = 0;
			//
			//CFSTXCommsEnvironment_ComponentSimulationHandler
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (7.0F), (float) (15.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TabControl1);
			this.Controls.Add(this.txtComponentName);
			this.Controls.Add(this.Label1);
			this.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Name = "CFSTXCommsEnvironment_ComponentSimulationHandler";
			this.Size = new System.Drawing.Size(677, 447);
			this.TabControl1.ResumeLayout(false);
			this.tabpDataReception.ResumeLayout(false);
			this.tabpDataReception.PerformLayout();
			this.TabPage2.ResumeLayout(false);
			this.TabControl2.ResumeLayout(false);
			this.TabPage7.ResumeLayout(false);
			this.TabPage7.PerformLayout();
			this.TabPage8.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.TabPage3.ResumeLayout(false);
			this.tabStatistics.ResumeLayout(false);
			this.TabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdGeneralStatistics).EndInit();
			this.TabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdReceptionStatistics).EndInit();
			this.TabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.dgrdRequestStatistics).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox txtComponentName;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage tabpDataReception;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Panel pnlDataReception;
		internal System.Windows.Forms.Button btnClearDataReception;
		internal System.Windows.Forms.ListBox lstBoxDataReception;
		internal System.Windows.Forms.CheckBox chkLogDataReception;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.TabControl tabStatistics;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.DataGridView dgrdGeneralStatistics;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.DataGridView dgrdReceptionStatistics;
		internal System.Windows.Forms.TabPage TabPage6;
		internal System.Windows.Forms.Button btnUpdateStatistics;
		internal System.Windows.Forms.DataGridView dgrdRequestStatistics;
		internal System.Windows.Forms.Panel pnlDataRequest;
		internal System.Windows.Forms.Panel pnlDatacontainerForDataSend;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.TabPage TabPage8;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtDataNameToRequest;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Button btnRequestFromRemotecomponent;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Panel pnlDataRequestedResult;
		internal System.Windows.Forms.TextBox txtRemoteComponentToRequestData;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Button btnChoseComponentForDataRequest;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.Button btnChoseComponentToDataSend;
		internal System.Windows.Forms.TextBox txtRemoteComponentNameToSendData;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Button btnSendDataToComponent;
		
	}
	
}
