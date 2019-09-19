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


namespace BroadCastListenerTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmBroadcastListenerTest : System.Windows.Forms.Form
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(broadCastTestForm_FormClosing);
			base.Load += new System.EventHandler(broadCastTestForm_Load);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.lstReplyError = new System.Windows.Forms.ListBox();
			this.Label11 = new System.Windows.Forms.Label();
			this.txtReplayNameID = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.chkReplyToBroadcaster = new System.Windows.Forms.CheckBox();
			this.chkReplyToBroadcaster.CheckedChanged += new System.EventHandler(this.chkReplyToBroadcaster_CheckedChanged);
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.txtBroadcastedDataReceivedAsXML = new System.Windows.Forms.TextBox();
			this.txtBroadcasterInfo = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
			this.CfDataDisplayCtrl1.DataCleared += new CommunicationsUISupportLibrary.CFDataDisplayCtrl.DataClearedEventHandler(this.CfDataDisplayCtrl1_DataCleared);
			this.CfDataManagerContainer1 = new CommunicationsUISupportLibrary.CFDataManagerContainer();
			this.GroupBox1.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.SuspendLayout();
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.CfDataManagerContainer1);
			this.GroupBox1.Controls.Add(this.lstReplyError);
			this.GroupBox1.Controls.Add(this.Label11);
			this.GroupBox1.Controls.Add(this.txtReplayNameID);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.chkReplyToBroadcaster);
			this.GroupBox1.Location = new System.Drawing.Point(3, 358);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(845, 349);
			this.GroupBox1.TabIndex = 1;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Broad Cast Reply Mode Test";
			//
			//lstReplyError
			//
			this.lstReplyError.FormattingEnabled = true;
			this.lstReplyError.Location = new System.Drawing.Point(0, 277);
			this.lstReplyError.Name = "lstReplyError";
			this.lstReplyError.Size = new System.Drawing.Size(845, 69);
			this.lstReplyError.TabIndex = 13;
			//
			//Label11
			//
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(3, 262);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(80, 13);
			this.Label11.TabIndex = 12;
			this.Label11.Text = "Reply Error Log";
			//
			//txtReplayNameID
			//
			this.txtReplayNameID.Location = new System.Drawing.Point(234, 19);
			this.txtReplayNameID.Name = "txtReplayNameID";
			this.txtReplayNameID.Size = new System.Drawing.Size(232, 20);
			this.txtReplayNameID.TabIndex = 2;
			this.txtReplayNameID.Text = "DEFAULT_REPLY_NAME_ID";
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(149, 22);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(79, 13);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Reply Name ID";
			//
			//chkReplyToBroadcaster
			//
			this.chkReplyToBroadcaster.AutoSize = true;
			this.chkReplyToBroadcaster.Location = new System.Drawing.Point(6, 19);
			this.chkReplyToBroadcaster.Name = "chkReplyToBroadcaster";
			this.chkReplyToBroadcaster.Size = new System.Drawing.Size(126, 17);
			this.chkReplyToBroadcaster.TabIndex = 0;
			this.chkReplyToBroadcaster.Text = "Reply to BroadCaster";
			this.chkReplyToBroadcaster.UseVisualStyleBackColor = true;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.TabControl1);
			this.GroupBox3.Controls.Add(this.txtBroadcasterInfo);
			this.GroupBox3.Controls.Add(this.Label10);
			this.GroupBox3.Location = new System.Drawing.Point(2, 5);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(734, 353);
			this.GroupBox3.TabIndex = 2;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Broadcasted Data Received";
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(3, 88);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(731, 259);
			this.TabControl1.TabIndex = 5;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.CfDataDisplayCtrl1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(723, 233);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "BroadCast Data Received";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.txtBroadcastedDataReceivedAsXML);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(723, 233);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Broadcast Data Received as XML String";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//txtBroadcastedDataReceivedAsXML
			//
			this.txtBroadcastedDataReceivedAsXML.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBroadcastedDataReceivedAsXML.Location = new System.Drawing.Point(3, 3);
			this.txtBroadcastedDataReceivedAsXML.Multiline = true;
			this.txtBroadcastedDataReceivedAsXML.Name = "txtBroadcastedDataReceivedAsXML";
			this.txtBroadcastedDataReceivedAsXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtBroadcastedDataReceivedAsXML.Size = new System.Drawing.Size(717, 227);
			this.txtBroadcastedDataReceivedAsXML.TabIndex = 0;
			//
			//txtBroadcasterInfo
			//
			this.txtBroadcasterInfo.Location = new System.Drawing.Point(134, 13);
			this.txtBroadcasterInfo.Multiline = true;
			this.txtBroadcasterInfo.Name = "txtBroadcasterInfo";
			this.txtBroadcasterInfo.Size = new System.Drawing.Size(493, 69);
			this.txtBroadcasterInfo.TabIndex = 4;
			//
			//Label10
			//
			this.Label10.AutoSize = true;
			this.Label10.Location = new System.Drawing.Point(2, 16);
			this.Label10.Name = "Label10";
			this.Label10.Size = new System.Drawing.Size(126, 13);
			this.Label10.TabIndex = 3;
			this.Label10.Text = "Broad Caster Information ";
			//
			//CfDataDisplayCtrl1
			//
			this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
			this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
			this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(612, 228);
			this.CfDataDisplayCtrl1.TabIndex = 0;
			//
			//CfDataManagerContainer1
			//
			this.CfDataManagerContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataManagerContainer1.Location = new System.Drawing.Point(4, 40);
			this.CfDataManagerContainer1.Name = "CfDataManagerContainer1";
			this.CfDataManagerContainer1.Size = new System.Drawing.Size(807, 205);
			this.CfDataManagerContainer1.TabIndex = 14;
			//
			//frmBroadcastListenerTest
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 708);
			this.Controls.Add(this.GroupBox3);
			this.Controls.Add(this.GroupBox1);
			this.Name = "frmBroadcastListenerTest";
			this.Text = "Broad Cast Listener Test Application";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.TextBox txtReplayNameID;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.CheckBox chkReplyToBroadcaster;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.TextBox txtBroadcasterInfo;
		internal System.Windows.Forms.Label Label10;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.ListBox lstReplyError;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox txtBroadcastedDataReceivedAsXML;
		internal CommunicationsUISupportLibrary.CFDataManagerContainer CfDataManagerContainer1;
	}
	
}
