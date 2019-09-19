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
	partial class CF_DPE_PublicationPostHandler : System.Windows.Forms.UserControl
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
			this.btnRemoveSimulationHandlerForAllVariables = new System.Windows.Forms.Button();
			this.btnRemoveVariableHandler = new System.Windows.Forms.Button();
			this.lstPostedPublicationVariables = new System.Windows.Forms.ListBox();
			this.lstPostedPublicationVariables.SelectedIndexChanged += new System.EventHandler(this.lstPostedPublicationVariables_SelectedIndexChanged);
			this.pnlVariablesHandler = new System.Windows.Forms.Panel();
			this.bntStartAll = new System.Windows.Forms.Button();
			this.bntStartAll.Click += new System.EventHandler(this.bntStartAll_Click);
			this.btnSTOPall = new System.Windows.Forms.Button();
			this.btnSTOPall.Click += new System.EventHandler(this.btnSTOPall_Click);
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.spltrMainSpliterCtrl = new System.Windows.Forms.SplitContainer();
			this.spltr1 = new System.Windows.Forms.SplitContainer();
			this.C1OutBar1 = new C1.Win.C1Command.C1OutBar();
			this.C1OutPage1 = new C1.Win.C1Command.C1OutPage();
			this.C1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
			this.C1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
			this.C1Command1 = new C1.Win.C1Command.C1Command();
			this.C1Command2 = new C1.Win.C1Command.C1Command();
			this.C1CommandControl1 = new C1.Win.C1Command.C1CommandControl();
			this.Button7 = new System.Windows.Forms.Button();
			this.Button7.Click += new System.EventHandler(this.Button7_Click);
			this.C1CommandControl2 = new C1.Win.C1Command.C1CommandControl();
			this.Button8 = new System.Windows.Forms.Button();
			this.Button8.Click += new System.EventHandler(this.Button8_Click);
			this.C1CommandControl3 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl4 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl5 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl6 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl7 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl8 = new C1.Win.C1Command.C1CommandControl();
			this.Button6 = new System.Windows.Forms.Button();
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			this.C1CommandControl9 = new C1.Win.C1Command.C1CommandControl();
			this.Button5 = new System.Windows.Forms.Button();
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.C1CommandControl10 = new C1.Win.C1Command.C1CommandControl();
			this.Button4 = new System.Windows.Forms.Button();
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.C1CommandControl11 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl12 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl13 = new C1.Win.C1Command.C1CommandControl();
			this.Button3 = new System.Windows.Forms.Button();
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.C1CommandControl14 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl15 = new C1.Win.C1Command.C1CommandControl();
			this.C1CommandControl16 = new C1.Win.C1Command.C1CommandControl();
			this.Button9 = new System.Windows.Forms.Button();
			this.Button9.Click += new System.EventHandler(this.Button9_Click);
			this.C1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink5 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink14 = new C1.Win.C1Command.C1CommandLink();
			this.splterSimulContainer = new System.Windows.Forms.SplitContainer();
			this.btnHideShowList = new System.Windows.Forms.Button();
			this.btnHideShowList.Click += new System.EventHandler(this.btnHideShowList_Click);
			this.spltrContainer = new System.Windows.Forms.SplitContainer();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.C1OutBar2 = new C1.Win.C1Command.C1OutBar();
			this.C1OutPage2 = new C1.Win.C1Command.C1OutPage();
			this.C1ToolBar2 = new C1.Win.C1Command.C1ToolBar();
			this.C1CommandLink9 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink10 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink11 = new C1.Win.C1Command.C1CommandLink();
			this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
			this.C1OutBar3 = new C1.Win.C1Command.C1OutBar();
			this.C1OutPage3 = new C1.Win.C1Command.C1OutPage();
			this.C1ToolBar3 = new C1.Win.C1Command.C1ToolBar();
			this.C1CommandLink6 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink7 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink8 = new C1.Win.C1Command.C1CommandLink();
			this.C1OutBar4 = new C1.Win.C1Command.C1OutBar();
			this.C1OutPage4 = new C1.Win.C1Command.C1OutPage();
			this.C1ToolBar4 = new C1.Win.C1Command.C1ToolBar();
			this.C1CommandLink12 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink13 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
			this.spltrMainSpliterCtrl.Panel1.SuspendLayout();
			this.spltrMainSpliterCtrl.Panel2.SuspendLayout();
			this.spltrMainSpliterCtrl.SuspendLayout();
			this.spltr1.Panel1.SuspendLayout();
			this.spltr1.Panel2.SuspendLayout();
			this.spltr1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1OutBar1).BeginInit();
			this.C1OutBar1.SuspendLayout();
			this.C1OutPage1.SuspendLayout();
			this.C1ToolBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1CommandHolder1).BeginInit();
			this.splterSimulContainer.Panel1.SuspendLayout();
			this.splterSimulContainer.Panel2.SuspendLayout();
			this.splterSimulContainer.SuspendLayout();
			this.spltrContainer.Panel1.SuspendLayout();
			this.spltrContainer.Panel2.SuspendLayout();
			this.spltrContainer.SuspendLayout();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1OutBar2).BeginInit();
			this.C1OutBar2.SuspendLayout();
			this.C1OutPage2.SuspendLayout();
			this.C1ToolBar2.SuspendLayout();
			this.SplitContainer2.Panel1.SuspendLayout();
			this.SplitContainer2.Panel2.SuspendLayout();
			this.SplitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1OutBar3).BeginInit();
			this.C1OutBar3.SuspendLayout();
			this.C1OutPage3.SuspendLayout();
			this.C1ToolBar3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1OutBar4).BeginInit();
			this.C1OutBar4.SuspendLayout();
			this.C1OutPage4.SuspendLayout();
			this.C1ToolBar4.SuspendLayout();
			this.SuspendLayout();
			//
			//btnRemoveSimulationHandlerForAllVariables
			//
			this.btnRemoveSimulationHandlerForAllVariables.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnRemoveSimulationHandlerForAllVariables.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnRemoveSimulationHandlerForAllVariables.Location = new System.Drawing.Point(44, 105);
			this.btnRemoveSimulationHandlerForAllVariables.Name = "btnRemoveSimulationHandlerForAllVariables";
			this.btnRemoveSimulationHandlerForAllVariables.Size = new System.Drawing.Size(190, 42);
			this.btnRemoveSimulationHandlerForAllVariables.TabIndex = 16;
			this.btnRemoveSimulationHandlerForAllVariables.TabStop = false;
			this.btnRemoveSimulationHandlerForAllVariables.Text = "Remove Variable All Simulation Handlers";
			this.btnRemoveSimulationHandlerForAllVariables.UseVisualStyleBackColor = false;
			//
			//btnRemoveVariableHandler
			//
			this.btnRemoveVariableHandler.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnRemoveVariableHandler.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnRemoveVariableHandler.Location = new System.Drawing.Point(44, 74);
			this.btnRemoveVariableHandler.Name = "btnRemoveVariableHandler";
			this.btnRemoveVariableHandler.Size = new System.Drawing.Size(190, 29);
			this.btnRemoveVariableHandler.TabIndex = 14;
			this.btnRemoveVariableHandler.TabStop = false;
			this.btnRemoveVariableHandler.Text = "Remove Variable  Simulation Handler";
			this.btnRemoveVariableHandler.UseVisualStyleBackColor = false;
			//
			//lstPostedPublicationVariables
			//
			this.lstPostedPublicationVariables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstPostedPublicationVariables.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstPostedPublicationVariables.FormattingEnabled = true;
			this.lstPostedPublicationVariables.HorizontalScrollbar = true;
			this.lstPostedPublicationVariables.ItemHeight = 17;
			this.lstPostedPublicationVariables.Location = new System.Drawing.Point(0, 0);
			this.lstPostedPublicationVariables.Name = "lstPostedPublicationVariables";
			this.lstPostedPublicationVariables.ScrollAlwaysVisible = true;
			this.lstPostedPublicationVariables.Size = new System.Drawing.Size(281, 225);
			this.lstPostedPublicationVariables.TabIndex = 12;
			//
			//pnlVariablesHandler
			//
			this.pnlVariablesHandler.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlVariablesHandler.Location = new System.Drawing.Point(0, 0);
			this.pnlVariablesHandler.Name = "pnlVariablesHandler";
			this.pnlVariablesHandler.Size = new System.Drawing.Size(497, 254);
			this.pnlVariablesHandler.TabIndex = 17;
			//
			//bntStartAll
			//
			this.bntStartAll.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.bntStartAll.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.bntStartAll.Location = new System.Drawing.Point(18, 1);
			this.bntStartAll.Name = "bntStartAll";
			this.bntStartAll.Size = new System.Drawing.Size(123, 30);
			this.bntStartAll.TabIndex = 20;
			this.bntStartAll.TabStop = false;
			this.bntStartAll.Text = "START All";
			this.bntStartAll.UseVisualStyleBackColor = false;
			//
			//btnSTOPall
			//
			this.btnSTOPall.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnSTOPall.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnSTOPall.Location = new System.Drawing.Point(18, 33);
			this.btnSTOPall.Name = "btnSTOPall";
			this.btnSTOPall.Size = new System.Drawing.Size(123, 30);
			this.btnSTOPall.TabIndex = 19;
			this.btnSTOPall.TabStop = false;
			this.btnSTOPall.Text = "STOP  All ";
			this.btnSTOPall.UseVisualStyleBackColor = false;
			//
			//Button1
			//
			this.Button1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button1.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button1.Location = new System.Drawing.Point(16, 52);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(123, 30);
			this.Button1.TabIndex = 21;
			this.Button1.TabStop = false;
			this.Button1.Text = "Reset All Statistics";
			this.Button1.UseVisualStyleBackColor = false;
			//
			//Button2
			//
			this.Button2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button2.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button2.Location = new System.Drawing.Point(16, 1);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(123, 49);
			this.Button2.TabIndex = 22;
			this.Button2.TabStop = false;
			this.Button2.Text = "View StatisticsResume";
			this.Button2.UseVisualStyleBackColor = false;
			//
			//spltrMainSpliterCtrl
			//
			this.spltrMainSpliterCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.spltrMainSpliterCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrMainSpliterCtrl.IsSplitterFixed = true;
			this.spltrMainSpliterCtrl.Location = new System.Drawing.Point(0, 0);
			this.spltrMainSpliterCtrl.Name = "spltrMainSpliterCtrl";
			//
			//spltrMainSpliterCtrl.Panel1
			//
			this.spltrMainSpliterCtrl.Panel1.Controls.Add(this.spltr1);
			//
			//spltrMainSpliterCtrl.Panel2
			//
			this.spltrMainSpliterCtrl.Panel2.Controls.Add(this.splterSimulContainer);
			this.spltrMainSpliterCtrl.Size = new System.Drawing.Size(790, 514);
			this.spltrMainSpliterCtrl.SplitterDistance = 285;
			this.spltrMainSpliterCtrl.TabIndex = 23;
			//
			//spltr1
			//
			this.spltr1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltr1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltr1.Location = new System.Drawing.Point(0, 0);
			this.spltr1.Name = "spltr1";
			this.spltr1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltr1.Panel1
			//
			this.spltr1.Panel1.Controls.Add(this.lstPostedPublicationVariables);
			//
			//spltr1.Panel2
			//
			this.spltr1.Panel2.Controls.Add(this.C1OutBar1);
			this.spltr1.Size = new System.Drawing.Size(281, 510);
			this.spltr1.SplitterDistance = 229;
			this.spltr1.TabIndex = 0;
			//
			//C1OutBar1
			//
			this.C1OutBar1.Controls.Add(this.C1OutPage1);
			this.C1OutBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1OutBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.C1OutBar1.Location = new System.Drawing.Point(0, 0);
			this.C1OutBar1.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.Office2003;
			this.C1OutBar1.Name = "C1OutBar1";
			this.C1OutBar1.SelectedIndex = 0;
			this.C1OutBar1.Size = new System.Drawing.Size(281, 277);
			this.C1OutBar1.Text = "C1OutBar1";
			//
			//C1OutPage1
			//
			this.C1OutPage1.Controls.Add(this.C1ToolBar1);
			this.C1OutPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.C1OutPage1.ImageIndex = -1;
			this.C1OutPage1.Location = new System.Drawing.Point(0, 20);
			this.C1OutPage1.Name = "C1OutPage1";
			this.C1OutPage1.Size = new System.Drawing.Size(281, 237);
			this.C1OutPage1.TabIndex = 0;
			this.C1OutPage1.Text = "Commands";
			//
			//C1ToolBar1
			//
			this.C1ToolBar1.ButtonLookVert = (C1.Win.C1Command.ButtonLookFlags) (C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image);
			this.C1ToolBar1.CommandHolder = this.C1CommandHolder1;
			this.C1ToolBar1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {this.C1CommandLink1, this.C1CommandLink3, this.C1CommandLink4, this.C1CommandLink5, this.C1CommandLink14});
			this.C1ToolBar1.Controls.Add(this.Button7);
			this.C1ToolBar1.Controls.Add(this.Button8);
			this.C1ToolBar1.Controls.Add(this.btnRemoveVariableHandler);
			this.C1ToolBar1.Controls.Add(this.btnRemoveSimulationHandlerForAllVariables);
			this.C1ToolBar1.Controls.Add(this.Button9);
			this.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1ToolBar1.Horizontal = false;
			this.C1ToolBar1.Location = new System.Drawing.Point(0, 0);
			this.C1ToolBar1.Movable = false;
			this.C1ToolBar1.Name = "C1ToolBar1";
			this.C1ToolBar1.Size = new System.Drawing.Size(281, 237);
			this.C1ToolBar1.Text = "Page1";
			//
			//C1CommandHolder1
			//
			this.C1CommandHolder1.Commands.Add(this.C1Command1);
			this.C1CommandHolder1.Commands.Add(this.C1Command2);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl1);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl2);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl3);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl4);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl5);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl6);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl7);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl8);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl9);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl10);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl11);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl12);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl13);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl14);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl15);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl16);
			this.C1CommandHolder1.Owner = this;
			//
			//C1Command1
			//
			this.C1Command1.Name = "C1Command1";
			this.C1Command1.Text = "Create Variable Simulation";
			//
			//C1Command2
			//
			this.C1Command2.Name = "C1Command2";
			this.C1Command2.Text = "Create Variable Simulation Handler for All Variables";
			//
			//C1CommandControl1
			//
			this.C1CommandControl1.Control = this.Button7;
			this.C1CommandControl1.Name = "C1CommandControl1";
			//
			//Button7
			//
			this.Button7.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button7.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button7.Location = new System.Drawing.Point(44, 1);
			this.Button7.Name = "Button7";
			this.Button7.Size = new System.Drawing.Size(190, 27);
			this.Button7.TabIndex = 26;
			this.Button7.TabStop = false;
			this.Button7.Text = "Create Variable Simulation";
			this.Button7.UseVisualStyleBackColor = false;
			//
			//C1CommandControl2
			//
			this.C1CommandControl2.Control = this.Button8;
			this.C1CommandControl2.Name = "C1CommandControl2";
			//
			//Button8
			//
			this.Button8.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button8.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button8.Location = new System.Drawing.Point(44, 30);
			this.Button8.Name = "Button8";
			this.Button8.Size = new System.Drawing.Size(190, 42);
			this.Button8.TabIndex = 27;
			this.Button8.TabStop = false;
			this.Button8.Text = "Create Variable Simulation Handler for All Variables";
			this.Button8.UseVisualStyleBackColor = false;
			//
			//C1CommandControl3
			//
			this.C1CommandControl3.Control = this.btnRemoveVariableHandler;
			this.C1CommandControl3.Name = "C1CommandControl3";
			//
			//C1CommandControl4
			//
			this.C1CommandControl4.Control = this.btnRemoveSimulationHandlerForAllVariables;
			this.C1CommandControl4.Name = "C1CommandControl4";
			//
			//C1CommandControl5
			//
			this.C1CommandControl5.Name = "C1CommandControl5";
			//
			//C1CommandControl6
			//
			this.C1CommandControl6.Name = "C1CommandControl6";
			//
			//C1CommandControl7
			//
			this.C1CommandControl7.Name = "C1CommandControl7";
			//
			//C1CommandControl8
			//
			this.C1CommandControl8.Control = this.Button6;
			this.C1CommandControl8.Name = "C1CommandControl8";
			//
			//Button6
			//
			this.Button6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button6.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button6.Location = new System.Drawing.Point(22, 1);
			this.Button6.Name = "Button6";
			this.Button6.Size = new System.Drawing.Size(123, 30);
			this.Button6.TabIndex = 20;
			this.Button6.TabStop = false;
			this.Button6.Text = "START All";
			this.Button6.UseVisualStyleBackColor = false;
			//
			//C1CommandControl9
			//
			this.C1CommandControl9.Control = this.Button5;
			this.C1CommandControl9.Name = "C1CommandControl9";
			//
			//Button5
			//
			this.Button5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button5.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button5.Location = new System.Drawing.Point(22, 33);
			this.Button5.Name = "Button5";
			this.Button5.Size = new System.Drawing.Size(123, 30);
			this.Button5.TabIndex = 19;
			this.Button5.TabStop = false;
			this.Button5.Text = "STOP  All ";
			this.Button5.UseVisualStyleBackColor = false;
			//
			//C1CommandControl10
			//
			this.C1CommandControl10.Control = this.Button4;
			this.C1CommandControl10.Name = "C1CommandControl10";
			//
			//Button4
			//
			this.Button4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button4.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button4.Location = new System.Drawing.Point(22, 65);
			this.Button4.Name = "Button4";
			this.Button4.Size = new System.Drawing.Size(123, 43);
			this.Button4.TabIndex = 23;
			this.Button4.TabStop = false;
			this.Button4.Text = "Set RESET  Rate  For All";
			this.Button4.UseVisualStyleBackColor = false;
			//
			//C1CommandControl11
			//
			this.C1CommandControl11.Control = this.bntStartAll;
			this.C1CommandControl11.Name = "C1CommandControl11";
			//
			//C1CommandControl12
			//
			this.C1CommandControl12.Control = this.btnSTOPall;
			this.C1CommandControl12.Name = "C1CommandControl12";
			//
			//C1CommandControl13
			//
			this.C1CommandControl13.Control = this.Button3;
			this.C1CommandControl13.Name = "C1CommandControl13";
			//
			//Button3
			//
			this.Button3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button3.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button3.Location = new System.Drawing.Point(18, 65);
			this.Button3.Name = "Button3";
			this.Button3.Size = new System.Drawing.Size(123, 43);
			this.Button3.TabIndex = 23;
			this.Button3.TabStop = false;
			this.Button3.Text = "Set UPDATE Rate  For All";
			this.Button3.UseVisualStyleBackColor = false;
			//
			//C1CommandControl14
			//
			this.C1CommandControl14.Control = this.Button2;
			this.C1CommandControl14.Name = "C1CommandControl14";
			//
			//C1CommandControl15
			//
			this.C1CommandControl15.Control = this.Button1;
			this.C1CommandControl15.Name = "C1CommandControl15";
			//
			//C1CommandControl16
			//
			this.C1CommandControl16.Control = this.Button9;
			this.C1CommandControl16.Name = "C1CommandControl16";
			//
			//Button9
			//
			this.Button9.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.Button9.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Button9.Location = new System.Drawing.Point(44, 149);
			this.Button9.Name = "Button9";
			this.Button9.Size = new System.Drawing.Size(190, 42);
			this.Button9.TabIndex = 17;
			this.Button9.TabStop = false;
			this.Button9.Text = "Update Variables List";
			this.Button9.UseVisualStyleBackColor = false;
			//
			//C1CommandLink1
			//
			this.C1CommandLink1.Command = this.C1CommandControl1;
			//
			//C1CommandLink3
			//
			this.C1CommandLink3.Command = this.C1CommandControl2;
			//
			//C1CommandLink4
			//
			this.C1CommandLink4.Command = this.C1CommandControl3;
			//
			//C1CommandLink5
			//
			this.C1CommandLink5.Command = this.C1CommandControl4;
			//
			//C1CommandLink14
			//
			this.C1CommandLink14.Command = this.C1CommandControl16;
			//
			//splterSimulContainer
			//
			this.splterSimulContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splterSimulContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splterSimulContainer.IsSplitterFixed = true;
			this.splterSimulContainer.Location = new System.Drawing.Point(0, 0);
			this.splterSimulContainer.Name = "splterSimulContainer";
			this.splterSimulContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//splterSimulContainer.Panel1
			//
			this.splterSimulContainer.Panel1.Controls.Add(this.btnHideShowList);
			//
			//splterSimulContainer.Panel2
			//
			this.splterSimulContainer.Panel2.Controls.Add(this.spltrContainer);
			this.splterSimulContainer.Size = new System.Drawing.Size(497, 510);
			this.splterSimulContainer.SplitterDistance = 28;
			this.splterSimulContainer.TabIndex = 0;
			//
			//btnHideShowList
			//
			this.btnHideShowList.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnHideShowList.Location = new System.Drawing.Point(3, 4);
			this.btnHideShowList.Name = "btnHideShowList";
			this.btnHideShowList.Size = new System.Drawing.Size(119, 23);
			this.btnHideShowList.TabIndex = 0;
			this.btnHideShowList.Text = "<<  Hide List";
			this.btnHideShowList.UseVisualStyleBackColor = true;
			//
			//spltrContainer
			//
			this.spltrContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrContainer.IsSplitterFixed = true;
			this.spltrContainer.Location = new System.Drawing.Point(0, 0);
			this.spltrContainer.Name = "spltrContainer";
			this.spltrContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrContainer.Panel1
			//
			this.spltrContainer.Panel1.Controls.Add(this.pnlVariablesHandler);
			//
			//spltrContainer.Panel2
			//
			this.spltrContainer.Panel2.Controls.Add(this.SplitContainer1);
			this.spltrContainer.Size = new System.Drawing.Size(497, 478);
			this.spltrContainer.SplitterDistance = 254;
			this.spltrContainer.TabIndex = 23;
			//
			//SplitContainer1
			//
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainer1.IsSplitterFixed = true;
			this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer1.Name = "SplitContainer1";
			//
			//SplitContainer1.Panel1
			//
			this.SplitContainer1.Panel1.Controls.Add(this.C1OutBar2);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.SplitContainer2);
			this.SplitContainer1.Size = new System.Drawing.Size(497, 220);
			this.SplitContainer1.SplitterDistance = 162;
			this.SplitContainer1.TabIndex = 0;
			//
			//C1OutBar2
			//
			this.C1OutBar2.Controls.Add(this.C1OutPage2);
			this.C1OutBar2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1OutBar2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.C1OutBar2.Location = new System.Drawing.Point(0, 0);
			this.C1OutBar2.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.Office2003;
			this.C1OutBar2.Name = "C1OutBar2";
			this.C1OutBar2.SelectedIndex = 0;
			this.C1OutBar2.Size = new System.Drawing.Size(162, 220);
			this.C1OutBar2.Text = "C1OutBar2";
			//
			//C1OutPage2
			//
			this.C1OutPage2.Controls.Add(this.C1ToolBar2);
			this.C1OutPage2.ImageIndex = -1;
			this.C1OutPage2.Location = new System.Drawing.Point(0, 20);
			this.C1OutPage2.Name = "C1OutPage2";
			this.C1OutPage2.Size = new System.Drawing.Size(162, 180);
			this.C1OutPage2.TabIndex = 0;
			this.C1OutPage2.Text = "Data UPDATE";
			//
			//C1ToolBar2
			//
			this.C1ToolBar2.ButtonLookVert = (C1.Win.C1Command.ButtonLookFlags) (C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image);
			this.C1ToolBar2.CommandHolder = this.C1CommandHolder1;
			this.C1ToolBar2.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {this.C1CommandLink9, this.C1CommandLink10, this.C1CommandLink11});
			this.C1ToolBar2.Controls.Add(this.bntStartAll);
			this.C1ToolBar2.Controls.Add(this.btnSTOPall);
			this.C1ToolBar2.Controls.Add(this.Button3);
			this.C1ToolBar2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1ToolBar2.Horizontal = false;
			this.C1ToolBar2.Location = new System.Drawing.Point(0, 0);
			this.C1ToolBar2.Movable = false;
			this.C1ToolBar2.Name = "C1ToolBar2";
			this.C1ToolBar2.Size = new System.Drawing.Size(162, 180);
			this.C1ToolBar2.Text = "Page2";
			//
			//C1CommandLink9
			//
			this.C1CommandLink9.Command = this.C1CommandControl11;
			//
			//C1CommandLink10
			//
			this.C1CommandLink10.Command = this.C1CommandControl12;
			//
			//C1CommandLink11
			//
			this.C1CommandLink11.Command = this.C1CommandControl13;
			//
			//SplitContainer2
			//
			this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainer2.IsSplitterFixed = true;
			this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer2.Name = "SplitContainer2";
			//
			//SplitContainer2.Panel1
			//
			this.SplitContainer2.Panel1.Controls.Add(this.C1OutBar3);
			//
			//SplitContainer2.Panel2
			//
			this.SplitContainer2.Panel2.Controls.Add(this.C1OutBar4);
			this.SplitContainer2.Size = new System.Drawing.Size(331, 220);
			this.SplitContainer2.SplitterDistance = 170;
			this.SplitContainer2.TabIndex = 0;
			//
			//C1OutBar3
			//
			this.C1OutBar3.Controls.Add(this.C1OutPage3);
			this.C1OutBar3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1OutBar3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.C1OutBar3.Location = new System.Drawing.Point(0, 0);
			this.C1OutBar3.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.Office2003;
			this.C1OutBar3.Name = "C1OutBar3";
			this.C1OutBar3.SelectedIndex = 0;
			this.C1OutBar3.Size = new System.Drawing.Size(170, 220);
			this.C1OutBar3.Text = "C1OutBar3";
			//
			//C1OutPage3
			//
			this.C1OutPage3.Controls.Add(this.C1ToolBar3);
			this.C1OutPage3.ImageIndex = -1;
			this.C1OutPage3.Location = new System.Drawing.Point(0, 20);
			this.C1OutPage3.Name = "C1OutPage3";
			this.C1OutPage3.Size = new System.Drawing.Size(170, 180);
			this.C1OutPage3.TabIndex = 0;
			this.C1OutPage3.Text = "Data RESET";
			//
			//C1ToolBar3
			//
			this.C1ToolBar3.ButtonLookVert = (C1.Win.C1Command.ButtonLookFlags) (C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image);
			this.C1ToolBar3.CommandHolder = this.C1CommandHolder1;
			this.C1ToolBar3.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {this.C1CommandLink6, this.C1CommandLink7, this.C1CommandLink8});
			this.C1ToolBar3.Controls.Add(this.Button6);
			this.C1ToolBar3.Controls.Add(this.Button5);
			this.C1ToolBar3.Controls.Add(this.Button4);
			this.C1ToolBar3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1ToolBar3.Horizontal = false;
			this.C1ToolBar3.Location = new System.Drawing.Point(0, 0);
			this.C1ToolBar3.Movable = false;
			this.C1ToolBar3.Name = "C1ToolBar3";
			this.C1ToolBar3.Size = new System.Drawing.Size(170, 180);
			this.C1ToolBar3.Text = "Page2";
			//
			//C1CommandLink6
			//
			this.C1CommandLink6.Command = this.C1CommandControl8;
			//
			//C1CommandLink7
			//
			this.C1CommandLink7.Command = this.C1CommandControl9;
			//
			//C1CommandLink8
			//
			this.C1CommandLink8.Command = this.C1CommandControl10;
			//
			//C1OutBar4
			//
			this.C1OutBar4.Controls.Add(this.C1OutPage4);
			this.C1OutBar4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1OutBar4.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.C1OutBar4.Location = new System.Drawing.Point(0, 0);
			this.C1OutBar4.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.Office2003;
			this.C1OutBar4.Name = "C1OutBar4";
			this.C1OutBar4.SelectedIndex = 0;
			this.C1OutBar4.Size = new System.Drawing.Size(157, 220);
			this.C1OutBar4.Text = "C1OutBar4";
			//
			//C1OutPage4
			//
			this.C1OutPage4.Controls.Add(this.C1ToolBar4);
			this.C1OutPage4.ImageIndex = -1;
			this.C1OutPage4.Location = new System.Drawing.Point(0, 20);
			this.C1OutPage4.Name = "C1OutPage4";
			this.C1OutPage4.Size = new System.Drawing.Size(157, 180);
			this.C1OutPage4.TabIndex = 0;
			this.C1OutPage4.Text = "Statistics";
			//
			//C1ToolBar4
			//
			this.C1ToolBar4.ButtonLookVert = (C1.Win.C1Command.ButtonLookFlags) (C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image);
			this.C1ToolBar4.CommandHolder = this.C1CommandHolder1;
			this.C1ToolBar4.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {this.C1CommandLink12, this.C1CommandLink13});
			this.C1ToolBar4.Controls.Add(this.Button2);
			this.C1ToolBar4.Controls.Add(this.Button1);
			this.C1ToolBar4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1ToolBar4.Horizontal = false;
			this.C1ToolBar4.Location = new System.Drawing.Point(0, 0);
			this.C1ToolBar4.Movable = false;
			this.C1ToolBar4.Name = "C1ToolBar4";
			this.C1ToolBar4.Size = new System.Drawing.Size(157, 180);
			this.C1ToolBar4.Text = "Page2";
			//
			//C1CommandLink12
			//
			this.C1CommandLink12.Command = this.C1CommandControl14;
			//
			//C1CommandLink13
			//
			this.C1CommandLink13.Command = this.C1CommandControl15;
			//
			//CF_DPE_PublicationPostHandler
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.spltrMainSpliterCtrl);
			this.Name = "CF_DPE_PublicationPostHandler";
			this.Size = new System.Drawing.Size(790, 514);
			this.spltrMainSpliterCtrl.Panel1.ResumeLayout(false);
			this.spltrMainSpliterCtrl.Panel2.ResumeLayout(false);
			this.spltrMainSpliterCtrl.ResumeLayout(false);
			this.spltr1.Panel1.ResumeLayout(false);
			this.spltr1.Panel2.ResumeLayout(false);
			this.spltr1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1OutBar1).EndInit();
			this.C1OutBar1.ResumeLayout(false);
			this.C1OutPage1.ResumeLayout(false);
			this.C1ToolBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1CommandHolder1).EndInit();
			this.splterSimulContainer.Panel1.ResumeLayout(false);
			this.splterSimulContainer.Panel2.ResumeLayout(false);
			this.splterSimulContainer.ResumeLayout(false);
			this.spltrContainer.Panel1.ResumeLayout(false);
			this.spltrContainer.Panel2.ResumeLayout(false);
			this.spltrContainer.ResumeLayout(false);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1OutBar2).EndInit();
			this.C1OutBar2.ResumeLayout(false);
			this.C1OutPage2.ResumeLayout(false);
			this.C1ToolBar2.ResumeLayout(false);
			this.SplitContainer2.Panel1.ResumeLayout(false);
			this.SplitContainer2.Panel2.ResumeLayout(false);
			this.SplitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1OutBar3).EndInit();
			this.C1OutBar3.ResumeLayout(false);
			this.C1OutPage3.ResumeLayout(false);
			this.C1ToolBar3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1OutBar4).EndInit();
			this.C1OutBar4.ResumeLayout(false);
			this.C1OutPage4.ResumeLayout(false);
			this.C1ToolBar4.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button btnRemoveSimulationHandlerForAllVariables;
		internal System.Windows.Forms.Button btnRemoveVariableHandler;
		internal System.Windows.Forms.ListBox lstPostedPublicationVariables;
		internal System.Windows.Forms.Panel pnlVariablesHandler;
		internal System.Windows.Forms.Button bntStartAll;
		internal System.Windows.Forms.Button btnSTOPall;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.SplitContainer spltrMainSpliterCtrl;
		internal System.Windows.Forms.SplitContainer splterSimulContainer;
		internal System.Windows.Forms.SplitContainer spltrContainer;
		internal System.Windows.Forms.Button btnHideShowList;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.Button Button6;
		internal System.Windows.Forms.SplitContainer spltr1;
		internal C1.Win.C1Command.C1CommandHolder C1CommandHolder1;
		internal C1.Win.C1Command.C1OutBar C1OutBar1;
		internal C1.Win.C1Command.C1OutPage C1OutPage1;
		internal C1.Win.C1Command.C1ToolBar C1ToolBar1;
		internal C1.Win.C1Command.C1Command C1Command1;
		internal C1.Win.C1Command.C1Command C1Command2;
		internal System.Windows.Forms.Button Button7;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink2;
		internal System.Windows.Forms.Button Button8;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl1;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl2;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl3;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl4;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink1;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink3;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink4;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink5;
		internal C1.Win.C1Command.C1OutBar C1OutBar2;
		internal C1.Win.C1Command.C1OutPage C1OutPage2;
		internal C1.Win.C1Command.C1ToolBar C1ToolBar2;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl5;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl6;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl7;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl8;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl9;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl10;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl11;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl12;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink9;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink10;
		internal System.Windows.Forms.SplitContainer SplitContainer2;
		internal C1.Win.C1Command.C1OutBar C1OutBar3;
		internal C1.Win.C1Command.C1OutPage C1OutPage3;
		internal C1.Win.C1Command.C1ToolBar C1ToolBar3;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink6;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink7;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink8;
		internal C1.Win.C1Command.C1OutBar C1OutBar4;
		internal C1.Win.C1Command.C1OutPage C1OutPage4;
		internal C1.Win.C1Command.C1ToolBar C1ToolBar4;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl13;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink11;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl14;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl15;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink12;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink13;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl16;
		internal System.Windows.Forms.Button Button9;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink14;
		
	}
	
}
