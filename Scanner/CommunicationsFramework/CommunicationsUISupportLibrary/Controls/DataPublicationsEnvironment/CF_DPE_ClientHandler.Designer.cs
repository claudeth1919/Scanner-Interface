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
	partial class CF_DPE_ClientHandler : System.Windows.Forms.UserControl
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
			this.lstSubscribedPublications = new System.Windows.Forms.ListBox();
			base.Load += new System.EventHandler(STXDSS_ClientHandler_Load);
			this.lstSubscribedPublications.SelectedIndexChanged += new System.EventHandler(this.lstSubscribedPublications_SelectedIndexChanged);
			this.btnDisconnectFromPublication = new System.Windows.Forms.Button();
			this.btnDisconnectFromPublication.Click += new System.EventHandler(this.btnRemoveFromPublication_Click);
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.lblSErverConnectionStatus = new System.Windows.Forms.Label();
			this.txtClientName = new System.Windows.Forms.TextBox();
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.TabControl4 = new System.Windows.Forms.TabControl();
			this.TabPage7 = new System.Windows.Forms.TabPage();
			this.spltrPublicationsPostMainSpliterCtrl = new System.Windows.Forms.SplitContainer();
			this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
			this.Label6 = new System.Windows.Forms.Label();
			this.lstPostedPublications = new System.Windows.Forms.ListBox();
			this.lstPostedPublications.SelectedIndexChanged += new System.EventHandler(this.lstPostedPublications_SelectedIndexChanged);
			this.C1OutBar1 = new C1.Win.C1Command.C1OutBar();
			this.C1OutPage1 = new C1.Win.C1Command.C1OutPage();
			this.C1ToolBar1 = new C1.Win.C1Command.C1ToolBar();
			this.C1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
			this.C1CommandControl1 = new C1.Win.C1Command.C1CommandControl();
			this.btnCreatePublication = new System.Windows.Forms.Button();
			this.btnCreatePublication.Click += new System.EventHandler(this.btnCreatePublication_Click);
			this.C1CommandControl2 = new C1.Win.C1Command.C1CommandControl();
			this.btnCreateRandomPublication = new System.Windows.Forms.Button();
			this.btnCreateRandomPublication.Click += new System.EventHandler(this.btnCreateRandomPublication_Click);
			this.C1CommandControl3 = new C1.Win.C1Command.C1CommandControl();
			this.btnDeletePublication = new System.Windows.Forms.Button();
			this.btnDeletePublication.Click += new System.EventHandler(this.btnDeletePublication_Click);
			this.C1CommandControl4 = new C1.Win.C1Command.C1CommandControl();
			this.btnUpdatePostedPublications = new System.Windows.Forms.Button();
			this.btnUpdatePostedPublications.Click += new System.EventHandler(this.btnUpdatePostedPublications_Click);
			this.C1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
			this.C1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
			this.spltrPublicationsContainer = new System.Windows.Forms.SplitContainer();
			this.btnHideShowPublicationsPostList = new System.Windows.Forms.Button();
			this.btnHideShowPublicationsPostList.Click += new System.EventHandler(this.btnHideShowPublicationsPostList_Click);
			this.TabPage9 = new System.Windows.Forms.TabPage();
			this.TabControl2 = new System.Windows.Forms.TabControl();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
			this.Label1 = new System.Windows.Forms.Label();
			this.btnConnectToAllPublications = new System.Windows.Forms.Button();
			this.btnConnectToAllPublications.Click += new System.EventHandler(this.btnConnectToAllPublications_Click);
			this.btnConnectToPublication = new System.Windows.Forms.Button();
			this.btnConnectToPublication.Click += new System.EventHandler(this.btnConnectToPublication_Click);
			this.btnUpdate = new System.Windows.Forms.Button();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.lstAvailablePubications = new System.Windows.Forms.ListBox();
			this.lstAvailablePubications.SelectedIndexChanged += new System.EventHandler(this.lstAvailablePubications_SelectedIndexChanged);
			this.Label2 = new System.Windows.Forms.Label();
			this.lstListOfPublicationPublishedVariables = new System.Windows.Forms.ListBox();
			this.TabPage5 = new System.Windows.Forms.TabPage();
			this.spltrCurrentPublicationsSubscrioption = new System.Windows.Forms.SplitContainer();
			this.btnDisconnectFromAllPublications = new System.Windows.Forms.Button();
			this.btnDisconnectFromAllPublications.Click += new System.EventHandler(this.btnDisconnectFromAllPublications_Click);
			this.Label3 = new System.Windows.Forms.Label();
			this.btnUpdateConnections = new System.Windows.Forms.Button();
			this.btnUpdateConnections.Click += new System.EventHandler(this.btnUpdateConnections_Click);
			this.spltrPublicationsSubscriptionsContainer = new System.Windows.Forms.SplitContainer();
			this.btnHideShowPublicationsSubscriptionList = new System.Windows.Forms.Button();
			this.btnHideShowPublicationsSubscriptionList.Click += new System.EventHandler(this.btnHideShowPublicationsSubscriptionList_Click);
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.btnClearErorLog = new System.Windows.Forms.Button();
			this.btnClearErorLog.Click += new System.EventHandler(this.btnClearErorLog_Click);
			this.lstErrorLog = new System.Windows.Forms.ListBox();
			this.spltrMain = new System.Windows.Forms.SplitContainer();
			this.GroupBox2.SuspendLayout();
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			this.TabControl4.SuspendLayout();
			this.TabPage7.SuspendLayout();
			this.spltrPublicationsPostMainSpliterCtrl.Panel1.SuspendLayout();
			this.spltrPublicationsPostMainSpliterCtrl.Panel2.SuspendLayout();
			this.spltrPublicationsPostMainSpliterCtrl.SuspendLayout();
			this.SplitContainer2.Panel1.SuspendLayout();
			this.SplitContainer2.Panel2.SuspendLayout();
			this.SplitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1OutBar1).BeginInit();
			this.C1OutBar1.SuspendLayout();
			this.C1OutPage1.SuspendLayout();
			this.C1ToolBar1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.C1CommandHolder1).BeginInit();
			this.spltrPublicationsContainer.Panel1.SuspendLayout();
			this.spltrPublicationsContainer.SuspendLayout();
			this.TabPage9.SuspendLayout();
			this.TabControl2.SuspendLayout();
			this.TabPage4.SuspendLayout();
			this.SplitContainer1.Panel1.SuspendLayout();
			this.SplitContainer1.Panel2.SuspendLayout();
			this.SplitContainer1.SuspendLayout();
			this.TabPage5.SuspendLayout();
			this.spltrCurrentPublicationsSubscrioption.Panel1.SuspendLayout();
			this.spltrCurrentPublicationsSubscrioption.Panel2.SuspendLayout();
			this.spltrCurrentPublicationsSubscrioption.SuspendLayout();
			this.spltrPublicationsSubscriptionsContainer.Panel1.SuspendLayout();
			this.spltrPublicationsSubscriptionsContainer.SuspendLayout();
			this.TabPage3.SuspendLayout();
			this.spltrMain.Panel1.SuspendLayout();
			this.spltrMain.Panel2.SuspendLayout();
			this.spltrMain.SuspendLayout();
			this.SuspendLayout();
			//
			//lstSubscribedPublications
			//
			this.lstSubscribedPublications.FormattingEnabled = true;
			this.lstSubscribedPublications.HorizontalScrollbar = true;
			this.lstSubscribedPublications.ItemHeight = 16;
			this.lstSubscribedPublications.Location = new System.Drawing.Point(3, 24);
			this.lstSubscribedPublications.Name = "lstSubscribedPublications";
			this.lstSubscribedPublications.ScrollAlwaysVisible = true;
			this.lstSubscribedPublications.Size = new System.Drawing.Size(279, 404);
			this.lstSubscribedPublications.TabIndex = 1;
			//
			//btnDisconnectFromPublication
			//
			this.btnDisconnectFromPublication.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnDisconnectFromPublication.Location = new System.Drawing.Point(6, 434);
			this.btnDisconnectFromPublication.Name = "btnDisconnectFromPublication";
			this.btnDisconnectFromPublication.Size = new System.Drawing.Size(228, 36);
			this.btnDisconnectFromPublication.TabIndex = 2;
			this.btnDisconnectFromPublication.Text = "Disconnect From Publication";
			this.btnDisconnectFromPublication.UseVisualStyleBackColor = true;
			//
			//GroupBox2
			//
			this.GroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.GroupBox2.Controls.Add(this.lblSErverConnectionStatus);
			this.GroupBox2.Controls.Add(this.txtClientName);
			this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GroupBox2.Location = new System.Drawing.Point(0, 0);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(1032, 50);
			this.GroupBox2.TabIndex = 8;
			this.GroupBox2.TabStop = false;
			this.GroupBox2.Text = "STX Data Socket Client Name";
			//
			//lblSErverConnectionStatus
			//
			this.lblSErverConnectionStatus.AutoSize = true;
			this.lblSErverConnectionStatus.BackColor = System.Drawing.Color.Yellow;
			this.lblSErverConnectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblSErverConnectionStatus.Location = new System.Drawing.Point(772, 18);
			this.lblSErverConnectionStatus.Name = "lblSErverConnectionStatus";
			this.lblSErverConnectionStatus.Size = new System.Drawing.Size(210, 18);
			this.lblSErverConnectionStatus.TabIndex = 8;
			this.lblSErverConnectionStatus.Text = "Status: Not connected to Server";
			//
			//txtClientName
			//
			this.txtClientName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtClientName.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtClientName.Location = new System.Drawing.Point(10, 18);
			this.txtClientName.Name = "txtClientName";
			this.txtClientName.ReadOnly = true;
			this.txtClientName.Size = new System.Drawing.Size(756, 26);
			this.txtClientName.TabIndex = 0;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl1.Location = new System.Drawing.Point(0, 0);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(1032, 668);
			this.TabControl1.TabIndex = 9;
			//
			//TabPage1
			//
			this.TabPage1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TabPage1.Controls.Add(this.TabControl4);
			this.TabPage1.Location = new System.Drawing.Point(4, 25);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(1024, 639);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Publications";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//TabControl4
			//
			this.TabControl4.Controls.Add(this.TabPage7);
			this.TabControl4.Controls.Add(this.TabPage9);
			this.TabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl4.Location = new System.Drawing.Point(3, 3);
			this.TabControl4.Name = "TabControl4";
			this.TabControl4.SelectedIndex = 0;
			this.TabControl4.Size = new System.Drawing.Size(1018, 633);
			this.TabControl4.TabIndex = 7;
			//
			//TabPage7
			//
			this.TabPage7.Controls.Add(this.spltrPublicationsPostMainSpliterCtrl);
			this.TabPage7.Location = new System.Drawing.Point(4, 25);
			this.TabPage7.Name = "TabPage7";
			this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage7.Size = new System.Drawing.Size(1010, 604);
			this.TabPage7.TabIndex = 0;
			this.TabPage7.Text = "Publications Posting";
			this.TabPage7.UseVisualStyleBackColor = true;
			//
			//spltrPublicationsPostMainSpliterCtrl
			//
			this.spltrPublicationsPostMainSpliterCtrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.spltrPublicationsPostMainSpliterCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrPublicationsPostMainSpliterCtrl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrPublicationsPostMainSpliterCtrl.IsSplitterFixed = true;
			this.spltrPublicationsPostMainSpliterCtrl.Location = new System.Drawing.Point(3, 3);
			this.spltrPublicationsPostMainSpliterCtrl.Name = "spltrPublicationsPostMainSpliterCtrl";
			//
			//spltrPublicationsPostMainSpliterCtrl.Panel1
			//
			this.spltrPublicationsPostMainSpliterCtrl.Panel1.Controls.Add(this.SplitContainer2);
			//
			//spltrPublicationsPostMainSpliterCtrl.Panel2
			//
			this.spltrPublicationsPostMainSpliterCtrl.Panel2.Controls.Add(this.spltrPublicationsContainer);
			this.spltrPublicationsPostMainSpliterCtrl.Size = new System.Drawing.Size(1004, 598);
			this.spltrPublicationsPostMainSpliterCtrl.SplitterDistance = 228;
			this.spltrPublicationsPostMainSpliterCtrl.TabIndex = 20;
			//
			//SplitContainer2
			//
			this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainer2.IsSplitterFixed = true;
			this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
			this.SplitContainer2.Name = "SplitContainer2";
			this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//SplitContainer2.Panel1
			//
			this.SplitContainer2.Panel1.Controls.Add(this.Label6);
			this.SplitContainer2.Panel1.Controls.Add(this.lstPostedPublications);
			//
			//SplitContainer2.Panel2
			//
			this.SplitContainer2.Panel2.Controls.Add(this.C1OutBar1);
			this.SplitContainer2.Size = new System.Drawing.Size(224, 594);
			this.SplitContainer2.SplitterDistance = 347;
			this.SplitContainer2.TabIndex = 0;
			//
			//Label6
			//
			this.Label6.AutoSize = true;
			this.Label6.ForeColor = System.Drawing.Color.Blue;
			this.Label6.Location = new System.Drawing.Point(3, 2);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(133, 16);
			this.Label6.TabIndex = 14;
			this.Label6.Text = "Publications Posted";
			//
			//lstPostedPublications
			//
			this.lstPostedPublications.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstPostedPublications.FormattingEnabled = true;
			this.lstPostedPublications.HorizontalScrollbar = true;
			this.lstPostedPublications.ItemHeight = 20;
			this.lstPostedPublications.Location = new System.Drawing.Point(6, 21);
			this.lstPostedPublications.Name = "lstPostedPublications";
			this.lstPostedPublications.ScrollAlwaysVisible = true;
			this.lstPostedPublications.Size = new System.Drawing.Size(216, 324);
			this.lstPostedPublications.TabIndex = 6;
			//
			//C1OutBar1
			//
			this.C1OutBar1.Controls.Add(this.C1OutPage1);
			this.C1OutBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1OutBar1.Location = new System.Drawing.Point(0, 0);
			this.C1OutBar1.LookAndFeel = C1.Win.C1Command.LookAndFeelEnum.Office2003;
			this.C1OutBar1.Name = "C1OutBar1";
			this.C1OutBar1.SelectedIndex = 0;
			this.C1OutBar1.Size = new System.Drawing.Size(224, 243);
			this.C1OutBar1.Text = "C1OutBar1";
			//
			//C1OutPage1
			//
			this.C1OutPage1.Controls.Add(this.C1ToolBar1);
			this.C1OutPage1.ImageIndex = -1;
			this.C1OutPage1.Location = new System.Drawing.Point(0, 20);
			this.C1OutPage1.Name = "C1OutPage1";
			this.C1OutPage1.Size = new System.Drawing.Size(224, 203);
			this.C1OutPage1.TabIndex = 0;
			this.C1OutPage1.Text = "Commands";
			//
			//C1ToolBar1
			//
			this.C1ToolBar1.ButtonLookVert = (C1.Win.C1Command.ButtonLookFlags) (C1.Win.C1Command.ButtonLookFlags.Text | C1.Win.C1Command.ButtonLookFlags.Image);
			this.C1ToolBar1.CommandHolder = this.C1CommandHolder1;
			this.C1ToolBar1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {this.C1CommandLink1, this.C1CommandLink2, this.C1CommandLink3, this.C1CommandLink4});
			this.C1ToolBar1.Controls.Add(this.btnCreatePublication);
			this.C1ToolBar1.Controls.Add(this.btnCreateRandomPublication);
			this.C1ToolBar1.Controls.Add(this.btnDeletePublication);
			this.C1ToolBar1.Controls.Add(this.btnUpdatePostedPublications);
			this.C1ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.C1ToolBar1.Horizontal = false;
			this.C1ToolBar1.Location = new System.Drawing.Point(0, 0);
			this.C1ToolBar1.Movable = false;
			this.C1ToolBar1.Name = "C1ToolBar1";
			this.C1ToolBar1.Size = new System.Drawing.Size(224, 203);
			this.C1ToolBar1.Text = "Page1";
			//
			//C1CommandHolder1
			//
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl1);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl2);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl3);
			this.C1CommandHolder1.Commands.Add(this.C1CommandControl4);
			this.C1CommandHolder1.Owner = this;
			//
			//C1CommandControl1
			//
			this.C1CommandControl1.Control = this.btnCreatePublication;
			this.C1CommandControl1.Name = "C1CommandControl1";
			//
			//btnCreatePublication
			//
			this.btnCreatePublication.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnCreatePublication.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnCreatePublication.Location = new System.Drawing.Point(3, 1);
			this.btnCreatePublication.Name = "btnCreatePublication";
			this.btnCreatePublication.Size = new System.Drawing.Size(216, 33);
			this.btnCreatePublication.TabIndex = 6;
			this.btnCreatePublication.TabStop = false;
			this.btnCreatePublication.Text = "Manually Create New Publication";
			this.btnCreatePublication.UseVisualStyleBackColor = false;
			//
			//C1CommandControl2
			//
			this.C1CommandControl2.Control = this.btnCreateRandomPublication;
			this.C1CommandControl2.Name = "C1CommandControl2";
			//
			//btnCreateRandomPublication
			//
			this.btnCreateRandomPublication.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnCreateRandomPublication.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnCreateRandomPublication.Location = new System.Drawing.Point(3, 36);
			this.btnCreateRandomPublication.Name = "btnCreateRandomPublication";
			this.btnCreateRandomPublication.Size = new System.Drawing.Size(216, 29);
			this.btnCreateRandomPublication.TabIndex = 18;
			this.btnCreateRandomPublication.TabStop = false;
			this.btnCreateRandomPublication.Text = "Create Random Publication";
			this.btnCreateRandomPublication.UseVisualStyleBackColor = false;
			//
			//C1CommandControl3
			//
			this.C1CommandControl3.Control = this.btnDeletePublication;
			this.C1CommandControl3.Name = "C1CommandControl3";
			//
			//btnDeletePublication
			//
			this.btnDeletePublication.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnDeletePublication.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnDeletePublication.Location = new System.Drawing.Point(3, 67);
			this.btnDeletePublication.Name = "btnDeletePublication";
			this.btnDeletePublication.Size = new System.Drawing.Size(216, 29);
			this.btnDeletePublication.TabIndex = 7;
			this.btnDeletePublication.TabStop = false;
			this.btnDeletePublication.Text = "Delete Publication";
			this.btnDeletePublication.UseVisualStyleBackColor = false;
			//
			//C1CommandControl4
			//
			this.C1CommandControl4.Control = this.btnUpdatePostedPublications;
			this.C1CommandControl4.Name = "C1CommandControl4";
			//
			//btnUpdatePostedPublications
			//
			this.btnUpdatePostedPublications.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(192)), System.Convert.ToInt32(System.Convert.ToByte(255)), System.Convert.ToInt32(System.Convert.ToByte(192)));
			this.btnUpdatePostedPublications.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnUpdatePostedPublications.Location = new System.Drawing.Point(3, 98);
			this.btnUpdatePostedPublications.Name = "btnUpdatePostedPublications";
			this.btnUpdatePostedPublications.Size = new System.Drawing.Size(216, 31);
			this.btnUpdatePostedPublications.TabIndex = 8;
			this.btnUpdatePostedPublications.TabStop = false;
			this.btnUpdatePostedPublications.Text = "Update";
			this.btnUpdatePostedPublications.UseVisualStyleBackColor = false;
			//
			//C1CommandLink1
			//
			this.C1CommandLink1.Command = this.C1CommandControl1;
			//
			//C1CommandLink2
			//
			this.C1CommandLink2.Command = this.C1CommandControl2;
			//
			//C1CommandLink3
			//
			this.C1CommandLink3.Command = this.C1CommandControl3;
			//
			//C1CommandLink4
			//
			this.C1CommandLink4.Command = this.C1CommandControl4;
			//
			//spltrPublicationsContainer
			//
			this.spltrPublicationsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrPublicationsContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrPublicationsContainer.IsSplitterFixed = true;
			this.spltrPublicationsContainer.Location = new System.Drawing.Point(0, 0);
			this.spltrPublicationsContainer.Name = "spltrPublicationsContainer";
			this.spltrPublicationsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrPublicationsContainer.Panel1
			//
			this.spltrPublicationsContainer.Panel1.Controls.Add(this.btnHideShowPublicationsPostList);
			this.spltrPublicationsContainer.Size = new System.Drawing.Size(768, 594);
			this.spltrPublicationsContainer.SplitterDistance = 25;
			this.spltrPublicationsContainer.TabIndex = 0;
			//
			//btnHideShowPublicationsPostList
			//
			this.btnHideShowPublicationsPostList.Location = new System.Drawing.Point(3, 2);
			this.btnHideShowPublicationsPostList.Name = "btnHideShowPublicationsPostList";
			this.btnHideShowPublicationsPostList.Size = new System.Drawing.Size(123, 23);
			this.btnHideShowPublicationsPostList.TabIndex = 0;
			this.btnHideShowPublicationsPostList.Text = "<<   Hide List";
			this.btnHideShowPublicationsPostList.UseVisualStyleBackColor = true;
			//
			//TabPage9
			//
			this.TabPage9.Controls.Add(this.TabControl2);
			this.TabPage9.Location = new System.Drawing.Point(4, 25);
			this.TabPage9.Name = "TabPage9";
			this.TabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage9.Size = new System.Drawing.Size(1010, 604);
			this.TabPage9.TabIndex = 1;
			this.TabPage9.Text = "Publications Subscription";
			this.TabPage9.UseVisualStyleBackColor = true;
			//
			//TabControl2
			//
			this.TabControl2.Controls.Add(this.TabPage4);
			this.TabControl2.Controls.Add(this.TabPage5);
			this.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TabControl2.Location = new System.Drawing.Point(3, 3);
			this.TabControl2.Name = "TabControl2";
			this.TabControl2.SelectedIndex = 0;
			this.TabControl2.Size = new System.Drawing.Size(1004, 598);
			this.TabControl2.TabIndex = 6;
			//
			//TabPage4
			//
			this.TabPage4.Controls.Add(this.SplitContainer1);
			this.TabPage4.Location = new System.Drawing.Point(4, 25);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage4.Size = new System.Drawing.Size(996, 569);
			this.TabPage4.TabIndex = 0;
			this.TabPage4.Text = "Available Publications";
			this.TabPage4.UseVisualStyleBackColor = true;
			//
			//SplitContainer1
			//
			this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.SplitContainer1.IsSplitterFixed = true;
			this.SplitContainer1.Location = new System.Drawing.Point(3, 3);
			this.SplitContainer1.Name = "SplitContainer1";
			//
			//SplitContainer1.Panel1
			//
			this.SplitContainer1.Panel1.Controls.Add(this.Label1);
			this.SplitContainer1.Panel1.Controls.Add(this.btnConnectToAllPublications);
			this.SplitContainer1.Panel1.Controls.Add(this.btnConnectToPublication);
			this.SplitContainer1.Panel1.Controls.Add(this.btnUpdate);
			this.SplitContainer1.Panel1.Controls.Add(this.lstAvailablePubications);
			//
			//SplitContainer1.Panel2
			//
			this.SplitContainer1.Panel2.Controls.Add(this.Label2);
			this.SplitContainer1.Panel2.Controls.Add(this.lstListOfPublicationPublishedVariables);
			this.SplitContainer1.Size = new System.Drawing.Size(990, 563);
			this.SplitContainer1.SplitterDistance = 483;
			this.SplitContainer1.TabIndex = 15;
			//
			//Label1
			//
			this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.Label1.AutoSize = true;
			this.Label1.Location = new System.Drawing.Point(3, 9);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(150, 16);
			this.Label1.TabIndex = 12;
			this.Label1.Text = "Available Publications";
			//
			//btnConnectToAllPublications
			//
			this.btnConnectToAllPublications.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnConnectToAllPublications.Location = new System.Drawing.Point(6, 370);
			this.btnConnectToAllPublications.Name = "btnConnectToAllPublications";
			this.btnConnectToAllPublications.Size = new System.Drawing.Size(238, 33);
			this.btnConnectToAllPublications.TabIndex = 14;
			this.btnConnectToAllPublications.Text = "Connect Client to ALL Publications";
			this.btnConnectToAllPublications.UseVisualStyleBackColor = true;
			//
			//btnConnectToPublication
			//
			this.btnConnectToPublication.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnConnectToPublication.Location = new System.Drawing.Point(6, 336);
			this.btnConnectToPublication.Name = "btnConnectToPublication";
			this.btnConnectToPublication.Size = new System.Drawing.Size(238, 33);
			this.btnConnectToPublication.TabIndex = 5;
			this.btnConnectToPublication.Text = "Connect Client to Publication";
			this.btnConnectToPublication.UseVisualStyleBackColor = true;
			//
			//btnUpdate
			//
			this.btnUpdate.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnUpdate.Location = new System.Drawing.Point(6, 409);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(238, 30);
			this.btnUpdate.TabIndex = 13;
			this.btnUpdate.Text = "Update Publications";
			this.btnUpdate.UseVisualStyleBackColor = true;
			//
			//lstAvailablePubications
			//
			this.lstAvailablePubications.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstAvailablePubications.FormattingEnabled = true;
			this.lstAvailablePubications.HorizontalScrollbar = true;
			this.lstAvailablePubications.ItemHeight = 20;
			this.lstAvailablePubications.Location = new System.Drawing.Point(0, 26);
			this.lstAvailablePubications.Name = "lstAvailablePubications";
			this.lstAvailablePubications.ScrollAlwaysVisible = true;
			this.lstAvailablePubications.Size = new System.Drawing.Size(480, 304);
			this.lstAvailablePubications.TabIndex = 2;
			//
			//Label2
			//
			this.Label2.Anchor = (System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(1, 8);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(144, 16);
			this.Label2.TabIndex = 10;
			this.Label2.Text = "Publication Variables";
			//
			//lstListOfPublicationPublishedVariables
			//
			this.lstListOfPublicationPublishedVariables.Font = new System.Drawing.Font("Arial", (float) (12.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstListOfPublicationPublishedVariables.FormattingEnabled = true;
			this.lstListOfPublicationPublishedVariables.HorizontalScrollbar = true;
			this.lstListOfPublicationPublishedVariables.ItemHeight = 20;
			this.lstListOfPublicationPublishedVariables.Location = new System.Drawing.Point(4, 25);
			this.lstListOfPublicationPublishedVariables.Name = "lstListOfPublicationPublishedVariables";
			this.lstListOfPublicationPublishedVariables.ScrollAlwaysVisible = true;
			this.lstListOfPublicationPublishedVariables.Size = new System.Drawing.Size(475, 404);
			this.lstListOfPublicationPublishedVariables.TabIndex = 11;
			//
			//TabPage5
			//
			this.TabPage5.Controls.Add(this.spltrCurrentPublicationsSubscrioption);
			this.TabPage5.Location = new System.Drawing.Point(4, 22);
			this.TabPage5.Name = "TabPage5";
			this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage5.Size = new System.Drawing.Size(996, 575);
			this.TabPage5.TabIndex = 1;
			this.TabPage5.Text = "Publications Subscriptions";
			this.TabPage5.UseVisualStyleBackColor = true;
			//
			//spltrCurrentPublicationsSubscrioption
			//
			this.spltrCurrentPublicationsSubscrioption.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrCurrentPublicationsSubscrioption.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrCurrentPublicationsSubscrioption.IsSplitterFixed = true;
			this.spltrCurrentPublicationsSubscrioption.Location = new System.Drawing.Point(3, 3);
			this.spltrCurrentPublicationsSubscrioption.Name = "spltrCurrentPublicationsSubscrioption";
			//
			//spltrCurrentPublicationsSubscrioption.Panel1
			//
			this.spltrCurrentPublicationsSubscrioption.Panel1.Controls.Add(this.btnDisconnectFromPublication);
			this.spltrCurrentPublicationsSubscrioption.Panel1.Controls.Add(this.btnDisconnectFromAllPublications);
			this.spltrCurrentPublicationsSubscrioption.Panel1.Controls.Add(this.Label3);
			this.spltrCurrentPublicationsSubscrioption.Panel1.Controls.Add(this.btnUpdateConnections);
			this.spltrCurrentPublicationsSubscrioption.Panel1.Controls.Add(this.lstSubscribedPublications);
			//
			//spltrCurrentPublicationsSubscrioption.Panel2
			//
			this.spltrCurrentPublicationsSubscrioption.Panel2.Controls.Add(this.spltrPublicationsSubscriptionsContainer);
			this.spltrCurrentPublicationsSubscrioption.Size = new System.Drawing.Size(990, 569);
			this.spltrCurrentPublicationsSubscrioption.SplitterDistance = 285;
			this.spltrCurrentPublicationsSubscrioption.TabIndex = 16;
			//
			//btnDisconnectFromAllPublications
			//
			this.btnDisconnectFromAllPublications.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnDisconnectFromAllPublications.Location = new System.Drawing.Point(6, 476);
			this.btnDisconnectFromAllPublications.Name = "btnDisconnectFromAllPublications";
			this.btnDisconnectFromAllPublications.Size = new System.Drawing.Size(228, 36);
			this.btnDisconnectFromAllPublications.TabIndex = 15;
			this.btnDisconnectFromAllPublications.Text = "Disconnect From All Publications";
			this.btnDisconnectFromAllPublications.UseVisualStyleBackColor = true;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(3, 7);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(257, 16);
			this.Label3.TabIndex = 13;
			this.Label3.Text = "Publications where Client Is Connected";
			//
			//btnUpdateConnections
			//
			this.btnUpdateConnections.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.btnUpdateConnections.Location = new System.Drawing.Point(6, 518);
			this.btnUpdateConnections.Name = "btnUpdateConnections";
			this.btnUpdateConnections.Size = new System.Drawing.Size(228, 36);
			this.btnUpdateConnections.TabIndex = 14;
			this.btnUpdateConnections.Text = "Update";
			this.btnUpdateConnections.UseVisualStyleBackColor = true;
			//
			//spltrPublicationsSubscriptionsContainer
			//
			this.spltrPublicationsSubscriptionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrPublicationsSubscriptionsContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrPublicationsSubscriptionsContainer.IsSplitterFixed = true;
			this.spltrPublicationsSubscriptionsContainer.Location = new System.Drawing.Point(0, 0);
			this.spltrPublicationsSubscriptionsContainer.Name = "spltrPublicationsSubscriptionsContainer";
			this.spltrPublicationsSubscriptionsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrPublicationsSubscriptionsContainer.Panel1
			//
			this.spltrPublicationsSubscriptionsContainer.Panel1.Controls.Add(this.btnHideShowPublicationsSubscriptionList);
			this.spltrPublicationsSubscriptionsContainer.Size = new System.Drawing.Size(701, 569);
			this.spltrPublicationsSubscriptionsContainer.SplitterDistance = 25;
			this.spltrPublicationsSubscriptionsContainer.TabIndex = 0;
			//
			//btnHideShowPublicationsSubscriptionList
			//
			this.btnHideShowPublicationsSubscriptionList.Location = new System.Drawing.Point(3, 0);
			this.btnHideShowPublicationsSubscriptionList.Name = "btnHideShowPublicationsSubscriptionList";
			this.btnHideShowPublicationsSubscriptionList.Size = new System.Drawing.Size(116, 23);
			this.btnHideShowPublicationsSubscriptionList.TabIndex = 0;
			this.btnHideShowPublicationsSubscriptionList.Text = "<<  Hide List";
			this.btnHideShowPublicationsSubscriptionList.UseVisualStyleBackColor = true;
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.btnClearErorLog);
			this.TabPage3.Controls.Add(this.lstErrorLog);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(1024, 642);
			this.TabPage3.TabIndex = 2;
			this.TabPage3.Text = "Errors Log ";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//btnClearErorLog
			//
			this.btnClearErorLog.Location = new System.Drawing.Point(613, 336);
			this.btnClearErorLog.Name = "btnClearErorLog";
			this.btnClearErorLog.Size = new System.Drawing.Size(113, 30);
			this.btnClearErorLog.TabIndex = 1;
			this.btnClearErorLog.Text = "Clear Log";
			this.btnClearErorLog.UseVisualStyleBackColor = true;
			//
			//lstErrorLog
			//
			this.lstErrorLog.Font = new System.Drawing.Font("Arial", (float) (11.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstErrorLog.FormattingEnabled = true;
			this.lstErrorLog.HorizontalScrollbar = true;
			this.lstErrorLog.ItemHeight = 20;
			this.lstErrorLog.Location = new System.Drawing.Point(6, 3);
			this.lstErrorLog.Name = "lstErrorLog";
			this.lstErrorLog.ScrollAlwaysVisible = true;
			this.lstErrorLog.Size = new System.Drawing.Size(967, 324);
			this.lstErrorLog.TabIndex = 0;
			//
			//spltrMain
			//
			this.spltrMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spltrMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.spltrMain.IsSplitterFixed = true;
			this.spltrMain.Location = new System.Drawing.Point(0, 0);
			this.spltrMain.Name = "spltrMain";
			this.spltrMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			//
			//spltrMain.Panel1
			//
			this.spltrMain.Panel1.Controls.Add(this.GroupBox2);
			//
			//spltrMain.Panel2
			//
			this.spltrMain.Panel2.Controls.Add(this.TabControl1);
			this.spltrMain.Size = new System.Drawing.Size(1032, 722);
			this.spltrMain.TabIndex = 10;
			//
			//CF_DPE_ClientHandler
			//
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.spltrMain);
			this.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "CF_DPE_ClientHandler";
			this.Size = new System.Drawing.Size(1032, 722);
			this.GroupBox2.ResumeLayout(false);
			this.GroupBox2.PerformLayout();
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabControl4.ResumeLayout(false);
			this.TabPage7.ResumeLayout(false);
			this.spltrPublicationsPostMainSpliterCtrl.Panel1.ResumeLayout(false);
			this.spltrPublicationsPostMainSpliterCtrl.Panel2.ResumeLayout(false);
			this.spltrPublicationsPostMainSpliterCtrl.ResumeLayout(false);
			this.SplitContainer2.Panel1.ResumeLayout(false);
			this.SplitContainer2.Panel1.PerformLayout();
			this.SplitContainer2.Panel2.ResumeLayout(false);
			this.SplitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1OutBar1).EndInit();
			this.C1OutBar1.ResumeLayout(false);
			this.C1OutPage1.ResumeLayout(false);
			this.C1ToolBar1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.C1CommandHolder1).EndInit();
			this.spltrPublicationsContainer.Panel1.ResumeLayout(false);
			this.spltrPublicationsContainer.ResumeLayout(false);
			this.TabPage9.ResumeLayout(false);
			this.TabControl2.ResumeLayout(false);
			this.TabPage4.ResumeLayout(false);
			this.SplitContainer1.Panel1.ResumeLayout(false);
			this.SplitContainer1.Panel1.PerformLayout();
			this.SplitContainer1.Panel2.ResumeLayout(false);
			this.SplitContainer1.Panel2.PerformLayout();
			this.SplitContainer1.ResumeLayout(false);
			this.TabPage5.ResumeLayout(false);
			this.spltrCurrentPublicationsSubscrioption.Panel1.ResumeLayout(false);
			this.spltrCurrentPublicationsSubscrioption.Panel1.PerformLayout();
			this.spltrCurrentPublicationsSubscrioption.Panel2.ResumeLayout(false);
			this.spltrCurrentPublicationsSubscrioption.ResumeLayout(false);
			this.spltrPublicationsSubscriptionsContainer.Panel1.ResumeLayout(false);
			this.spltrPublicationsSubscriptionsContainer.ResumeLayout(false);
			this.TabPage3.ResumeLayout(false);
			this.spltrMain.Panel1.ResumeLayout(false);
			this.spltrMain.Panel2.ResumeLayout(false);
			this.spltrMain.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.ListBox lstSubscribedPublications;
		internal System.Windows.Forms.Button btnDisconnectFromPublication;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.TextBox txtClientName;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.ListBox lstPostedPublications;
		internal System.Windows.Forms.Button btnDeletePublication;
		internal System.Windows.Forms.Button btnCreatePublication;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.Button btnClearErorLog;
		internal System.Windows.Forms.ListBox lstErrorLog;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ListBox lstListOfPublicationPublishedVariables;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListBox lstAvailablePubications;
		internal System.Windows.Forms.Button btnConnectToPublication;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Button btnUpdatePostedPublications;
		internal System.Windows.Forms.Button btnUpdate;
		internal System.Windows.Forms.Button btnUpdateConnections;
		internal System.Windows.Forms.TabControl TabControl4;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TabPage TabPage9;
		internal System.Windows.Forms.Label lblSErverConnectionStatus;
		internal System.Windows.Forms.Button btnCreateRandomPublication;
		internal System.Windows.Forms.Button btnConnectToAllPublications;
		internal System.Windows.Forms.Button btnDisconnectFromAllPublications;
		internal System.Windows.Forms.SplitContainer spltrMain;
		internal System.Windows.Forms.SplitContainer spltrPublicationsPostMainSpliterCtrl;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.SplitContainer spltrCurrentPublicationsSubscrioption;
		internal System.Windows.Forms.SplitContainer spltrPublicationsSubscriptionsContainer;
		internal System.Windows.Forms.Button btnHideShowPublicationsSubscriptionList;
		internal System.Windows.Forms.SplitContainer spltrPublicationsContainer;
		internal System.Windows.Forms.Button btnHideShowPublicationsPostList;
		internal System.Windows.Forms.SplitContainer SplitContainer2;
		internal C1.Win.C1Command.C1OutBar C1OutBar1;
		internal C1.Win.C1Command.C1OutPage C1OutPage1;
		internal C1.Win.C1Command.C1ToolBar C1ToolBar1;
		internal C1.Win.C1Command.C1CommandHolder C1CommandHolder1;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl1;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl2;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl3;
		internal C1.Win.C1Command.C1CommandControl C1CommandControl4;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink1;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink2;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink3;
		internal C1.Win.C1Command.C1CommandLink C1CommandLink4;
		
	}
	
}
