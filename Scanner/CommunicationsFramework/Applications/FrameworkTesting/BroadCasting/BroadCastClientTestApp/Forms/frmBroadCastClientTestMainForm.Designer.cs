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


namespace BroadCastClientTestApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmBroadCastClientTestMainForm : System.Windows.Forms.Form
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
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(BroadCastCliientTest_FormClosing);
			base.Load += new System.EventHandler(BroadCastCliientTest_Load);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox5 = new System.Windows.Forms.GroupBox();
			this.lstDataReplied = new System.Windows.Forms.ListBox();
			this.lstDataReplied.SelectedIndexChanged += new System.EventHandler(this.lstDataReplied_SelectedIndexChanged);
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabPage2 = new System.Windows.Forms.TabPage();
			this.txtDataREpliedAsXML = new System.Windows.Forms.TextBox();
			this.txtReceivedReplies = new System.Windows.Forms.TextBox();
			this.GroupBox3 = new System.Windows.Forms.GroupBox();
			this.txtREsult = new System.Windows.Forms.TextBox();
			this.txtReplyIDName = new System.Windows.Forms.TextBox();
			this.chkCheckReplyIDName = new System.Windows.Forms.CheckBox();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
			this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
			this.GroupBox4 = new System.Windows.Forms.GroupBox();
			this.txtBroadCastIDName = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.CfDataManagerContainer1 = new CommunicationsUISupportLibrary.CFDataManagerContainer();
			this.CfDataDisplayCtrl1 = new CommunicationsUISupportLibrary.CFDataDisplayCtrl();
			this.CfDataDisplayCtrl1.DataCleared += new CommunicationsUISupportLibrary.CFDataDisplayCtrl.DataClearedEventHandler(this.CfDataDisplayCtrl1_DataCleared);
			this.GroupBox6 = new System.Windows.Forms.GroupBox();
			this.GroupBox7 = new System.Windows.Forms.GroupBox();
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.GroupBox1.SuspendLayout();
			this.GroupBox5.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabPage2.SuspendLayout();
			this.GroupBox3.SuspendLayout();
			this.GroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudTimeOut).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).BeginInit();
			this.GroupBox4.SuspendLayout();
			this.GroupBox6.SuspendLayout();
			this.GroupBox7.SuspendLayout();
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.Location = new System.Drawing.Point(17, 19);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(110, 35);
			this.Button1.TabIndex = 5;
			this.Button1.Text = "BroadCastData";
			this.Button1.UseVisualStyleBackColor = true;
			//
			//Button2
			//
			this.Button2.Location = new System.Drawing.Point(4, 15);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(110, 65);
			this.Button2.TabIndex = 6;
			this.Button2.Text = "BroadCastData and wait Reply";
			this.Button2.UseVisualStyleBackColor = true;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.GroupBox7);
			this.GroupBox1.Controls.Add(this.GroupBox6);
			this.GroupBox1.Controls.Add(this.GroupBox5);
			this.GroupBox1.Controls.Add(this.GroupBox3);
			this.GroupBox1.Location = new System.Drawing.Point(3, 281);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(808, 461);
			this.GroupBox1.TabIndex = 9;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Broad Casting in Reply Waiting mode";
			//
			//GroupBox5
			//
			this.GroupBox5.Controls.Add(this.lstDataReplied);
			this.GroupBox5.Controls.Add(this.TabControl1);
			this.GroupBox5.Controls.Add(this.txtReceivedReplies);
			this.GroupBox5.Location = new System.Drawing.Point(6, 138);
			this.GroupBox5.Name = "GroupBox5";
			this.GroupBox5.Size = new System.Drawing.Size(802, 325);
			this.GroupBox5.TabIndex = 11;
			this.GroupBox5.TabStop = false;
			this.GroupBox5.Text = "Received Replies";
			//
			//lstDataReplied
			//
			this.lstDataReplied.FormattingEnabled = true;
			this.lstDataReplied.Location = new System.Drawing.Point(0, 42);
			this.lstDataReplied.Name = "lstDataReplied";
			this.lstDataReplied.Size = new System.Drawing.Size(259, 277);
			this.lstDataReplied.TabIndex = 0;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage2);
			this.TabControl1.Location = new System.Drawing.Point(260, 11);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(538, 308);
			this.TabControl1.TabIndex = 13;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.CfDataDisplayCtrl1);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(530, 282);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Data Replied";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//TabPage2
			//
			this.TabPage2.Controls.Add(this.txtDataREpliedAsXML);
			this.TabPage2.Location = new System.Drawing.Point(4, 22);
			this.TabPage2.Name = "TabPage2";
			this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage2.Size = new System.Drawing.Size(530, 282);
			this.TabPage2.TabIndex = 1;
			this.TabPage2.Text = "Data Replied as XML String";
			this.TabPage2.UseVisualStyleBackColor = true;
			//
			//txtDataREpliedAsXML
			//
			this.txtDataREpliedAsXML.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDataREpliedAsXML.Location = new System.Drawing.Point(3, 3);
			this.txtDataREpliedAsXML.Multiline = true;
			this.txtDataREpliedAsXML.Name = "txtDataREpliedAsXML";
			this.txtDataREpliedAsXML.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDataREpliedAsXML.Size = new System.Drawing.Size(524, 276);
			this.txtDataREpliedAsXML.TabIndex = 0;
			//
			//txtReceivedReplies
			//
			this.txtReceivedReplies.Location = new System.Drawing.Point(7, 17);
			this.txtReceivedReplies.Name = "txtReceivedReplies";
			this.txtReceivedReplies.ReadOnly = true;
			this.txtReceivedReplies.Size = new System.Drawing.Size(100, 20);
			this.txtReceivedReplies.TabIndex = 0;
			//
			//GroupBox3
			//
			this.GroupBox3.Controls.Add(this.txtREsult);
			this.GroupBox3.Controls.Add(this.txtReplyIDName);
			this.GroupBox3.Controls.Add(this.chkCheckReplyIDName);
			this.GroupBox3.Location = new System.Drawing.Point(273, 8);
			this.GroupBox3.Name = "GroupBox3";
			this.GroupBox3.Size = new System.Drawing.Size(530, 78);
			this.GroupBox3.TabIndex = 10;
			this.GroupBox3.TabStop = false;
			this.GroupBox3.Text = "Broad Cast Reply Verification";
			//
			//txtREsult
			//
			this.txtREsult.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtREsult.Location = new System.Drawing.Point(16, 47);
			this.txtREsult.Name = "txtREsult";
			this.txtREsult.Size = new System.Drawing.Size(457, 20);
			this.txtREsult.TabIndex = 11;
			//
			//txtReplyIDName
			//
			this.txtReplyIDName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtReplyIDName.Location = new System.Drawing.Point(163, 15);
			this.txtReplyIDName.Name = "txtReplyIDName";
			this.txtReplyIDName.Size = new System.Drawing.Size(310, 20);
			this.txtReplyIDName.TabIndex = 10;
			//
			//chkCheckReplyIDName
			//
			this.chkCheckReplyIDName.AutoSize = true;
			this.chkCheckReplyIDName.Location = new System.Drawing.Point(16, 19);
			this.chkCheckReplyIDName.Name = "chkCheckReplyIDName";
			this.chkCheckReplyIDName.Size = new System.Drawing.Size(141, 17);
			this.chkCheckReplyIDName.TabIndex = 9;
			this.chkCheckReplyIDName.Text = "Check a Reply ID Name";
			this.chkCheckReplyIDName.UseVisualStyleBackColor = true;
			//
			//GroupBox2
			//
			this.GroupBox2.Controls.Add(this.Label2);
			this.GroupBox2.Controls.Add(this.nudTimeOut);
			this.GroupBox2.Location = new System.Drawing.Point(120, 19);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(113, 61);
			this.GroupBox2.TabIndex = 9;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "Time out";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(57, 20);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(47, 13);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "seconds";
			//
			//nudTimeOut
			//
			this.nudTimeOut.Location = new System.Drawing.Point(6, 18);
			this.nudTimeOut.Name = "nudTimeOut";
			this.nudTimeOut.Size = new System.Drawing.Size(41, 20);
			this.nudTimeOut.TabIndex = 0;
			this.nudTimeOut.Value = new decimal(new int[] {15, 0, 0, 0});
			//
			//GroupBox4
			//
			this.GroupBox4.Controls.Add(this.Button1);
			this.GroupBox4.Location = new System.Drawing.Point(646, 3);
			this.GroupBox4.Name = "GroupBox4";
			this.GroupBox4.Size = new System.Drawing.Size(168, 59);
			this.GroupBox4.TabIndex = 10;
			this.GroupBox4.TabStop = false;
			this.GroupBox4.Text = "Broad Cast in one way mode";
			//
			//txtBroadCastIDName
			//
			this.txtBroadCastIDName.Location = new System.Drawing.Point(166, 11);
			this.txtBroadCastIDName.Name = "txtBroadCastIDName";
			this.txtBroadCastIDName.Size = new System.Drawing.Size(237, 20);
			this.txtBroadCastIDName.TabIndex = 12;
			this.txtBroadCastIDName.Text = "DEFAULT_ID_NAME";
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.Location = new System.Drawing.Point(23, 11);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(137, 16);
			this.Label3.TabIndex = 11;
			this.Label3.Text = "BroadCastIDName";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(7, 35);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(150, 13);
			this.Label4.TabIndex = 14;
			this.Label4.Text = "Available Data To Broad Cast ";
			//
			//CfDataManagerContainer1
			//
			this.CfDataManagerContainer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataManagerContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.CfDataManagerContainer1.Location = new System.Drawing.Point(4, 65);
			this.CfDataManagerContainer1.Name = "CfDataManagerContainer1";
			this.CfDataManagerContainer1.Size = new System.Drawing.Size(807, 210);
			this.CfDataManagerContainer1.TabIndex = 15;
			//
			//CfDataDisplayCtrl1
			//
			this.CfDataDisplayCtrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CfDataDisplayCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.CfDataDisplayCtrl1.Location = new System.Drawing.Point(3, 3);
			this.CfDataDisplayCtrl1.Name = "CfDataDisplayCtrl1";
			this.CfDataDisplayCtrl1.Size = new System.Drawing.Size(524, 276);
			this.CfDataDisplayCtrl1.TabIndex = 0;
			//
			//GroupBox6
			//
			this.GroupBox6.Controls.Add(this.Button2);
			this.GroupBox6.Controls.Add(this.GroupBox2);
			this.GroupBox6.Location = new System.Drawing.Point(7, 19);
			this.GroupBox6.Name = "GroupBox6";
			this.GroupBox6.Size = new System.Drawing.Size(258, 89);
			this.GroupBox6.TabIndex = 12;
			this.GroupBox6.TabStop = false;
			this.GroupBox6.Text = "broadCast and wait within time";
			//
			//GroupBox7
			//
			this.GroupBox7.Controls.Add(this.Button3);
			this.GroupBox7.Location = new System.Drawing.Point(274, 91);
			this.GroupBox7.Name = "GroupBox7";
			this.GroupBox7.Size = new System.Drawing.Size(529, 50);
			this.GroupBox7.TabIndex = 13;
			this.GroupBox7.TabStop = false;
			this.GroupBox7.Text = "Broad Cast and Wait only one reply";
			//
			//Button3
			//
			this.Button3.Location = new System.Drawing.Point(196, 13);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(196, 28);
			this.Button3.TabIndex = 14;
			this.Button3.Text = "BroadCastData and wait Reply";
			this.Button3.UseVisualStyleBackColor = true;
			//
			//frmBroadCastCliientTest
			//
			this.C1SizerLight1.SetAutoResize(this, true);
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(816, 749);
			this.Controls.Add(this.CfDataManagerContainer1);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.txtBroadCastIDName);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.GroupBox4);
			this.Controls.Add(this.GroupBox1);
			this.Name = "frmBroadCastCliientTest";
			this.Text = "Broadcast Client Test Application";
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox5.ResumeLayout(false);
			this.GroupBox5.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage2.ResumeLayout(false);
			this.TabPage2.PerformLayout();
			this.GroupBox3.ResumeLayout(false);
			this.GroupBox3.PerformLayout();
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudTimeOut).EndInit();
			((System.ComponentModel.ISupportInitialize) this.C1SizerLight1).EndInit();
			this.GroupBox4.ResumeLayout(false);
			this.GroupBox6.ResumeLayout(false);
			this.GroupBox7.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.NumericUpDown nudTimeOut;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.TextBox txtReplyIDName;
		internal System.Windows.Forms.CheckBox chkCheckReplyIDName;
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.TextBox txtREsult;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.TextBox txtReceivedReplies;
		internal System.Windows.Forms.TextBox txtBroadCastIDName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage2;
		internal System.Windows.Forms.TextBox txtDataREpliedAsXML;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.ListBox lstDataReplied;
		internal CommunicationsUISupportLibrary.CFDataManagerContainer CfDataManagerContainer1;
		internal CommunicationsUISupportLibrary.CFDataDisplayCtrl CfDataDisplayCtrl1;
		internal System.Windows.Forms.GroupBox GroupBox7;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.GroupBox GroupBox6;
	}
	
}
