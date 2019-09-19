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


namespace DPEServerClientApp
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class frmDPEServerClientAppMainForm : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDPEServerClientAppMainForm));
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle1 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle2 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle3 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle4 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle5 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle6 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle7 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle8 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle9 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle10 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle11 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle12 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle13 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle14 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle15 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle16 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle17 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle18 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle19 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle20 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle21 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle22 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle23 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle24 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle25 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            Klik.Windows.Forms.v1.Common.PaintStyle paintStyle26 = new Klik.Windows.Forms.v1.Common.PaintStyle();
            this.C1SizerLight1 = new C1.Win.C1Sizer.C1SizerLight(this.components);
            this.spltrPublicationsTreeViewMainSpliter = new System.Windows.Forms.TabControl();
            this.tapgae1 = new System.Windows.Forms.TabPage();
            this.spltrServerParameters = new System.Windows.Forms.SplitContainer();
            this.Label6 = new System.Windows.Forms.Label();
            this.dgrdServerParameters = new System.Windows.Forms.DataGridView();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.ElPanel3 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.tabClientConnections = new System.Windows.Forms.TabControl();
            this.tabpConnectedClients = new System.Windows.Forms.TabPage();
            this.TabSubscibedClients = new System.Windows.Forms.TabControl();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.ElPanel5 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.spltrClientCnnTableviewMainSpliter = new System.Windows.Forms.SplitContainer();
            this.spltrClientCnnTableviewHeaderSpliter = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.Button4 = new System.Windows.Forms.Button();
            this.btnClientCnnsListViewAdjustCols = new System.Windows.Forms.Button();
            this.btnClientsCnnListViewZoom = new System.Windows.Forms.Button();
            this.lstvClientSubscriptors = new System.Windows.Forms.ListView();
            this.imglstClientConnectionsRegistry = new System.Windows.Forms.ImageList(this.components);
            this.splAllClientsViewPublicationsCnnStatus = new System.Windows.Forms.SplitContainer();
            this.spltrClientsAllViewPostedPubsMain = new System.Windows.Forms.SplitContainer();
            this.spltrClientsAllViewPostedPubsMainHeader = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.btnZoomAllClientsTableViewPostedPubsList = new System.Windows.Forms.Button();
            this.lsvAllConnectionsPostedPublications = new System.Windows.Forms.ListView();
            this.imgLstClientPublicatiosRegistry = new System.Windows.Forms.ImageList(this.components);
            this.spltrClientsAllViewPubsConnectionsMain = new System.Windows.Forms.SplitContainer();
            this.spltrClientsAllViewPubsConnectionsMainHeader = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.btnZoomAllClientsTableViewPubsConnectionsList = new System.Windows.Forms.Button();
            this.lsvAllConnectionsConnectionToPublications = new System.Windows.Forms.ListView();
            this.TabPage6 = new System.Windows.Forms.TabPage();
            this.ElPanel6 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltrClientCnnsTreeViewMain = new System.Windows.Forms.SplitContainer();
            this.spltrClientCnnsTreeViewAndHeader = new System.Windows.Forms.SplitContainer();
            this.spltrClientCnnsTitleAndButtons = new System.Windows.Forms.SplitContainer();
            this.ElLabel26 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnClientConnsTreeViewCollapseNode = new System.Windows.Forms.Button();
            this.btnClientConnsTreeViewCollapseAll = new System.Windows.Forms.Button();
            this.btnClientConnsTreeViewExpandAll = new System.Windows.Forms.Button();
            this.btnClientConnsTreeViewZoom = new System.Windows.Forms.Button();
            this.tvwClientSubscriptors = new System.Windows.Forms.TreeView();
            this.SplitContainer4 = new System.Windows.Forms.SplitContainer();
            this.ElPanel15 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltrClienCnnsTreeViewPostedPublications = new System.Windows.Forms.SplitContainer();
            this.spltrClienCnnsTreeViewPostedHeader = new System.Windows.Forms.SplitContainer();
            this.ElLabel27 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnClientCnnsTreeViewPostedPubsZoom = new System.Windows.Forms.Button();
            this.lsvAllConnectionsByHostPublicationsPosted = new System.Windows.Forms.ListView();
            this.ElButton6 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.ElPanel16 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltrClienCnnsTreeViewPublicationsConnsMain = new System.Windows.Forms.SplitContainer();
            this.spltrClienCnnsTreeViewPubsConnectionsHeader = new System.Windows.Forms.SplitContainer();
            this.ElLabel28 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnClienCnnsTreeViewPubcConnsZoom = new System.Windows.Forms.Button();
            this.lsvAllConnectionsByHostConnectionToPublications = new System.Windows.Forms.ListView();
            this.ElButton7 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.imgViewsImagesList = new System.Windows.Forms.ImageList(this.components);
            this.tabpPublisherClients = new System.Windows.Forms.TabPage();
            this.ElPanel4 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.TabControl4 = new System.Windows.Forms.TabControl();
            this.TabPage7 = new System.Windows.Forms.TabPage();
            this.ElPanel7 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer5 = new System.Windows.Forms.SplitContainer();
            this.spltrPublisherClientsListMain = new System.Windows.Forms.SplitContainer();
            this.spltrPublisherClientsListHeader = new System.Windows.Forms.SplitContainer();
            this.ElLabel29 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Button5 = new System.Windows.Forms.Button();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.lsvPublisherClients = new System.Windows.Forms.ListView();
            this.imglstPublisherClientConnectionsRegistry = new System.Windows.Forms.ImageList(this.components);
            this.ElPanel17 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.ElGroupBox1 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.SplitContainer10 = new System.Windows.Forms.SplitContainer();
            this.ElPanel20 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltrPublicationsPostedPublishersTableView = new System.Windows.Forms.SplitContainer();
            this.SplitContainer16 = new System.Windows.Forms.SplitContainer();
            this.ElLabel3 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnAllPublihsersPubliationsListZoomView = new System.Windows.Forms.Button();
            this.lsvPublisherConnectionsAllPublicationsPosted = new System.Windows.Forms.ListView();
            this.ElButton11 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.ElPanel21 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer12 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer56 = new System.Windows.Forms.SplitContainer();
            this.ElLabel4 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnAllPublishersPublicationVariablesZoom = new System.Windows.Forms.Button();
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList = new System.Windows.Forms.ListView();
            this.ElButton12 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.ElButton8 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.TabPage8 = new System.Windows.Forms.TabPage();
            this.ElPanel8 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer6 = new System.Windows.Forms.SplitContainer();
            this.spltrPublisherstreeView = new System.Windows.Forms.SplitContainer();
            this.spltrClientConnsPublishersTreeViewHEader = new System.Windows.Forms.SplitContainer();
            this.ElLabel30 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnClientCnnsPublishersTreeViewNodeCollapse = new System.Windows.Forms.Button();
            this.btnClientCnnsPublishersTreeViewCollapseAll = new System.Windows.Forms.Button();
            this.btnClientCnnsPublishersTreeViewExpandAll = new System.Windows.Forms.Button();
            this.btnClientCnnsPublishersTreeViewZoom = new System.Windows.Forms.Button();
            this.tvwPublisherClients = new System.Windows.Forms.TreeView();
            this.ElGroupBox8 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.SplitContainer7 = new System.Windows.Forms.SplitContainer();
            this.ElPanel19 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer8 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer57 = new System.Windows.Forms.SplitContainer();
            this.ElLabel1 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Button1 = new System.Windows.Forms.Button();
            this.lsvPublisherClientsViewByHostPostedPublications = new System.Windows.Forms.ListView();
            this.ElButton10 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.ElPanel18 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer9 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer58 = new System.Windows.Forms.SplitContainer();
            this.ElLabel2 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Button2 = new System.Windows.Forms.Button();
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList = new System.Windows.Forms.ListView();
            this.ElButton9 = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.ElPanel11 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.tabPublicationsStatus = new System.Windows.Forms.TabControl();
            this.TabPage9 = new System.Windows.Forms.TabPage();
            this.ElPanel9 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer13 = new System.Windows.Forms.SplitContainer();
            this.spltrPublicationsREsumeMainSpliter = new System.Windows.Forms.SplitContainer();
            this.spltrPublicationsREsumeHeaderSplitter = new System.Windows.Forms.SplitContainer();
            this.ElLabel22 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.Button7 = new System.Windows.Forms.Button();
            this.Button8 = new System.Windows.Forms.Button();
            this.btnZoomAvailablePublications = new System.Windows.Forms.Button();
            this.lstAvailablePublications = new System.Windows.Forms.ListView();
            this.imgLstPublicationsREgistry = new System.Windows.Forms.ImageList(this.components);
            this.SplitContainer14 = new System.Windows.Forms.SplitContainer();
            this.ElPanel12 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltCtnrPublicationVariablesHEaderResumeView = new System.Windows.Forms.SplitContainer();
            this.SplitContainer17 = new System.Windows.Forms.SplitContainer();
            this.ElLabel20 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnZoomPubsVariablesListView = new System.Windows.Forms.Button();
            this.lsvPublicationREsumeTableViewVariablesList = new System.Windows.Forms.ListView();
            this.ElGroupBox9 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton1 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton2 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton3 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel22 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer15 = new System.Windows.Forms.SplitContainer();
            this.ElPanel23 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltCntrConnectedClientsResumeView = new System.Windows.Forms.SplitContainer();
            this.SplitContainer49 = new System.Windows.Forms.SplitContainer();
            this.ElLabel6 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnZoomPubsClientsListView = new System.Windows.Forms.Button();
            this.lsvPublicationsREsumeConnectedCLientsList = new System.Windows.Forms.ListView();
            this.ElGroupBox11 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton10 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton11 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton12 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel24 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltrPublicationsTableStatsMainSpliter = new System.Windows.Forms.SplitContainer();
            this.splitCtnrStatisticsHeader = new System.Windows.Forms.SplitContainer();
            this.ElLabel7 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.SplitContainer50 = new System.Windows.Forms.SplitContainer();
            this.btnZoomPubsStatisticsListView = new System.Windows.Forms.Button();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnPublicationsResumtStatisticsUpdate = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btnPublicationsResumtStatisticsReset = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.dgrPublicationDataUpdateStatisticsListView = new System.Windows.Forms.DataGridView();
            this.ElGroupBox12 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton13 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton14 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton15 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElGroupBox10 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton4 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton8 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton9 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.TabPage10 = new System.Windows.Forms.TabPage();
            this.ElPanel10 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer19 = new System.Windows.Forms.SplitContainer();
            this.spltrPublicationsTreeViewSpliter = new System.Windows.Forms.SplitContainer();
            this.spltrPublicationsTreeViewHeaderSpliter = new System.Windows.Forms.SplitContainer();
            this.ElLabel23 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse = new System.Windows.Forms.Button();
            this.btnAvaibalePublicationsTreeViewTreeCollapse = new System.Windows.Forms.Button();
            this.btnAvaibalePublicationsTreeViewTreeExpand = new System.Windows.Forms.Button();
            this.btnPublicationsTreeViewZoomView = new System.Windows.Forms.Button();
            this.tvwPublicationsREsumeTreeView = new System.Windows.Forms.TreeView();
            this.imgLstPublicationsTreeView = new System.Windows.Forms.ImageList(this.components);
            this.SplitContainer20 = new System.Windows.Forms.SplitContainer();
            this.ElPanel25 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltCtnrPublicationVariablesHEadrTreeView = new System.Windows.Forms.SplitContainer();
            this.SplitContainer52 = new System.Windows.Forms.SplitContainer();
            this.ElLabel17 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnZoomPubsVariablesTreeView = new System.Windows.Forms.Button();
            this.lsvPublicationTreeViewVariablesList = new System.Windows.Forms.ListView();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.ElPanel26 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer22 = new System.Windows.Forms.SplitContainer();
            this.ListView1 = new System.Windows.Forms.ListView();
            this.SplitContainer23 = new System.Windows.Forms.SplitContainer();
            this.ElPanel27 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer24 = new System.Windows.Forms.SplitContainer();
            this.ElLabel8 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView2 = new System.Windows.Forms.ListView();
            this.ElGroupBox13 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton16 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton17 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton18 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel28 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer25 = new System.Windows.Forms.SplitContainer();
            this.ElPanel29 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer26 = new System.Windows.Forms.SplitContainer();
            this.ElLabel9 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView3 = new System.Windows.Forms.ListView();
            this.ElGroupBox14 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton19 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton20 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton21 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel30 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer27 = new System.Windows.Forms.SplitContainer();
            this.ElLabel10 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.ElGroupBox15 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton22 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton23 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton24 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElGroupBox16 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton25 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton26 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton27 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.TabPage4 = new System.Windows.Forms.TabPage();
            this.ElPanel31 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer28 = new System.Windows.Forms.SplitContainer();
            this.TreeView2 = new System.Windows.Forms.TreeView();
            this.SplitContainer29 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer30 = new System.Windows.Forms.SplitContainer();
            this.ElGroupBox17 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton28 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton29 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton30 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.SplitContainer21 = new System.Windows.Forms.SplitContainer();
            this.ElPanel32 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.spltCntrConnectedClientsTreeView = new System.Windows.Forms.SplitContainer();
            this.SplitContainer53 = new System.Windows.Forms.SplitContainer();
            this.ElLabel18 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.btnZoomPubsClientsTreeView = new System.Windows.Forms.Button();
            this.lsvPublicationsREsumeTreeviewConnectedClients = new System.Windows.Forms.ListView();
            this.TabControl3 = new System.Windows.Forms.TabControl();
            this.TabPage11 = new System.Windows.Forms.TabPage();
            this.ElPanel33 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer31 = new System.Windows.Forms.SplitContainer();
            this.ListView4 = new System.Windows.Forms.ListView();
            this.SplitContainer32 = new System.Windows.Forms.SplitContainer();
            this.ElPanel34 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer33 = new System.Windows.Forms.SplitContainer();
            this.ElLabel11 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView5 = new System.Windows.Forms.ListView();
            this.ElGroupBox18 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton31 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton32 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton33 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel35 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer34 = new System.Windows.Forms.SplitContainer();
            this.ElPanel36 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer35 = new System.Windows.Forms.SplitContainer();
            this.ElLabel12 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView6 = new System.Windows.Forms.ListView();
            this.ElGroupBox19 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton34 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton35 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton36 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel37 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer36 = new System.Windows.Forms.SplitContainer();
            this.ElLabel13 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.DataGridView2 = new System.Windows.Forms.DataGridView();
            this.ElGroupBox20 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton37 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton38 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton39 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElGroupBox21 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton40 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton41 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton42 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.TabPage12 = new System.Windows.Forms.TabPage();
            this.ElPanel38 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer37 = new System.Windows.Forms.SplitContainer();
            this.TreeView3 = new System.Windows.Forms.TreeView();
            this.SplitContainer38 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer39 = new System.Windows.Forms.SplitContainer();
            this.ElGroupBox22 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton43 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton44 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton45 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel39 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer51 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer54 = new System.Windows.Forms.SplitContainer();
            this.ElLabel5 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.SplitContainer55 = new System.Windows.Forms.SplitContainer();
            this.btnZoomPubsStatisticsTreeView = new System.Windows.Forms.Button();
            this.SplitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnPublicationsResumTreeViewStatisticsUpdate = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.btnPublicationsResumTreeViewStatisticsReset = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.dgrPublicationDataUpdateStatisticsTreeView = new System.Windows.Forms.DataGridView();
            this.TabControl6 = new System.Windows.Forms.TabControl();
            this.TabPage13 = new System.Windows.Forms.TabPage();
            this.ElPanel40 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer40 = new System.Windows.Forms.SplitContainer();
            this.ListView7 = new System.Windows.Forms.ListView();
            this.SplitContainer41 = new System.Windows.Forms.SplitContainer();
            this.ElPanel41 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer42 = new System.Windows.Forms.SplitContainer();
            this.ElLabel14 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView8 = new System.Windows.Forms.ListView();
            this.ElGroupBox23 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton46 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton47 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton48 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel42 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer43 = new System.Windows.Forms.SplitContainer();
            this.ElPanel43 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer44 = new System.Windows.Forms.SplitContainer();
            this.ElLabel15 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.ListView9 = new System.Windows.Forms.ListView();
            this.ElGroupBox24 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton49 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton50 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton51 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElPanel44 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer45 = new System.Windows.Forms.SplitContainer();
            this.ElLabel16 = new Klik.Windows.Forms.v1.EntryLib.ELLabel();
            this.DataGridView3 = new System.Windows.Forms.DataGridView();
            this.ElGroupBox25 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton52 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton53 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton54 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElGroupBox26 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton55 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton56 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton57 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.TabPage14 = new System.Windows.Forms.TabPage();
            this.ElPanel45 = new Klik.Windows.Forms.v1.EntryLib.ELPanel();
            this.SplitContainer46 = new System.Windows.Forms.SplitContainer();
            this.TreeView4 = new System.Windows.Forms.TreeView();
            this.SplitContainer47 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer48 = new System.Windows.Forms.SplitContainer();
            this.ElGroupBox27 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton58 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton59 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton60 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElGroupBox3 = new Klik.Windows.Forms.v1.EntryLib.ELGroupBox();
            this.ElRadioButton7 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton5 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.ElRadioButton6 = new Klik.Windows.Forms.v1.EntryLib.ELRadioButton();
            this.TabPage15 = new System.Windows.Forms.TabPage();
            this.btnClearLog = new Klik.Windows.Forms.v1.EntryLib.ELButton();
            this.lstSTXEventLog = new System.Windows.Forms.ListBox();
            this.TabPage20 = new System.Windows.Forms.TabPage();
            this.SplitContainer11 = new System.Windows.Forms.SplitContainer();
            this.TabControl5 = new System.Windows.Forms.TabControl();
            this.TabPage21 = new System.Windows.Forms.TabPage();
            this.dgrdNetworkStatisticsIPv4 = new System.Windows.Forms.DataGridView();
            this.TabPage22 = new System.Windows.Forms.TabPage();
            this.dgrdNetworkStatisticsIPv6 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.spltMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.spltStatusBarLikeSpliter = new System.Windows.Forms.SplitContainer();
            this.txtConnectionStatusLabel = new System.Windows.Forms.TextBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.imgLstClientConnections = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).BeginInit();
            this.spltrPublicationsTreeViewMainSpliter.SuspendLayout();
            this.tapgae1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrServerParameters)).BeginInit();
            this.spltrServerParameters.Panel1.SuspendLayout();
            this.spltrServerParameters.Panel2.SuspendLayout();
            this.spltrServerParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServerParameters)).BeginInit();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel3)).BeginInit();
            this.ElPanel3.SuspendLayout();
            this.tabClientConnections.SuspendLayout();
            this.tabpConnectedClients.SuspendLayout();
            this.TabSubscibedClients.SuspendLayout();
            this.TabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel5)).BeginInit();
            this.ElPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnTableviewMainSpliter)).BeginInit();
            this.spltrClientCnnTableviewMainSpliter.Panel1.SuspendLayout();
            this.spltrClientCnnTableviewMainSpliter.Panel2.SuspendLayout();
            this.spltrClientCnnTableviewMainSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnTableviewHeaderSpliter)).BeginInit();
            this.spltrClientCnnTableviewHeaderSpliter.Panel1.SuspendLayout();
            this.spltrClientCnnTableviewHeaderSpliter.Panel2.SuspendLayout();
            this.spltrClientCnnTableviewHeaderSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splAllClientsViewPublicationsCnnStatus)).BeginInit();
            this.splAllClientsViewPublicationsCnnStatus.Panel1.SuspendLayout();
            this.splAllClientsViewPublicationsCnnStatus.Panel2.SuspendLayout();
            this.splAllClientsViewPublicationsCnnStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPostedPubsMain)).BeginInit();
            this.spltrClientsAllViewPostedPubsMain.Panel1.SuspendLayout();
            this.spltrClientsAllViewPostedPubsMain.Panel2.SuspendLayout();
            this.spltrClientsAllViewPostedPubsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPostedPubsMainHeader)).BeginInit();
            this.spltrClientsAllViewPostedPubsMainHeader.Panel1.SuspendLayout();
            this.spltrClientsAllViewPostedPubsMainHeader.Panel2.SuspendLayout();
            this.spltrClientsAllViewPostedPubsMainHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPubsConnectionsMain)).BeginInit();
            this.spltrClientsAllViewPubsConnectionsMain.Panel1.SuspendLayout();
            this.spltrClientsAllViewPubsConnectionsMain.Panel2.SuspendLayout();
            this.spltrClientsAllViewPubsConnectionsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPubsConnectionsMainHeader)).BeginInit();
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel1.SuspendLayout();
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel2.SuspendLayout();
            this.spltrClientsAllViewPubsConnectionsMainHeader.SuspendLayout();
            this.TabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel6)).BeginInit();
            this.ElPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTreeViewMain)).BeginInit();
            this.spltrClientCnnsTreeViewMain.Panel1.SuspendLayout();
            this.spltrClientCnnsTreeViewMain.Panel2.SuspendLayout();
            this.spltrClientCnnsTreeViewMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTreeViewAndHeader)).BeginInit();
            this.spltrClientCnnsTreeViewAndHeader.Panel1.SuspendLayout();
            this.spltrClientCnnsTreeViewAndHeader.Panel2.SuspendLayout();
            this.spltrClientCnnsTreeViewAndHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTitleAndButtons)).BeginInit();
            this.spltrClientCnnsTitleAndButtons.Panel1.SuspendLayout();
            this.spltrClientCnnsTitleAndButtons.Panel2.SuspendLayout();
            this.spltrClientCnnsTitleAndButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).BeginInit();
            this.SplitContainer4.Panel1.SuspendLayout();
            this.SplitContainer4.Panel2.SuspendLayout();
            this.SplitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel15)).BeginInit();
            this.ElPanel15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPostedPublications)).BeginInit();
            this.spltrClienCnnsTreeViewPostedPublications.Panel1.SuspendLayout();
            this.spltrClienCnnsTreeViewPostedPublications.Panel2.SuspendLayout();
            this.spltrClienCnnsTreeViewPostedPublications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPostedHeader)).BeginInit();
            this.spltrClienCnnsTreeViewPostedHeader.Panel1.SuspendLayout();
            this.spltrClienCnnsTreeViewPostedHeader.Panel2.SuspendLayout();
            this.spltrClienCnnsTreeViewPostedHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel16)).BeginInit();
            this.ElPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPublicationsConnsMain)).BeginInit();
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel1.SuspendLayout();
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel2.SuspendLayout();
            this.spltrClienCnnsTreeViewPublicationsConnsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPubsConnectionsHeader)).BeginInit();
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel1.SuspendLayout();
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel2.SuspendLayout();
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton7)).BeginInit();
            this.tabpPublisherClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel4)).BeginInit();
            this.ElPanel4.SuspendLayout();
            this.TabControl4.SuspendLayout();
            this.TabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel7)).BeginInit();
            this.ElPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer5)).BeginInit();
            this.SplitContainer5.Panel1.SuspendLayout();
            this.SplitContainer5.Panel2.SuspendLayout();
            this.SplitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherClientsListMain)).BeginInit();
            this.spltrPublisherClientsListMain.Panel1.SuspendLayout();
            this.spltrPublisherClientsListMain.Panel2.SuspendLayout();
            this.spltrPublisherClientsListMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherClientsListHeader)).BeginInit();
            this.spltrPublisherClientsListHeader.Panel1.SuspendLayout();
            this.spltrPublisherClientsListHeader.Panel2.SuspendLayout();
            this.spltrPublisherClientsListHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel17)).BeginInit();
            this.ElPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox1)).BeginInit();
            this.ElGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer10)).BeginInit();
            this.SplitContainer10.Panel1.SuspendLayout();
            this.SplitContainer10.Panel2.SuspendLayout();
            this.SplitContainer10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel20)).BeginInit();
            this.ElPanel20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsPostedPublishersTableView)).BeginInit();
            this.spltrPublicationsPostedPublishersTableView.Panel1.SuspendLayout();
            this.spltrPublicationsPostedPublishersTableView.Panel2.SuspendLayout();
            this.spltrPublicationsPostedPublishersTableView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer16)).BeginInit();
            this.SplitContainer16.Panel1.SuspendLayout();
            this.SplitContainer16.Panel2.SuspendLayout();
            this.SplitContainer16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel21)).BeginInit();
            this.ElPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer12)).BeginInit();
            this.SplitContainer12.Panel1.SuspendLayout();
            this.SplitContainer12.Panel2.SuspendLayout();
            this.SplitContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer56)).BeginInit();
            this.SplitContainer56.Panel1.SuspendLayout();
            this.SplitContainer56.Panel2.SuspendLayout();
            this.SplitContainer56.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton8)).BeginInit();
            this.TabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel8)).BeginInit();
            this.ElPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer6)).BeginInit();
            this.SplitContainer6.Panel1.SuspendLayout();
            this.SplitContainer6.Panel2.SuspendLayout();
            this.SplitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherstreeView)).BeginInit();
            this.spltrPublisherstreeView.Panel1.SuspendLayout();
            this.spltrPublisherstreeView.Panel2.SuspendLayout();
            this.spltrPublisherstreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientConnsPublishersTreeViewHEader)).BeginInit();
            this.spltrClientConnsPublishersTreeViewHEader.Panel1.SuspendLayout();
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.SuspendLayout();
            this.spltrClientConnsPublishersTreeViewHEader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox8)).BeginInit();
            this.ElGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer7)).BeginInit();
            this.SplitContainer7.Panel1.SuspendLayout();
            this.SplitContainer7.Panel2.SuspendLayout();
            this.SplitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel19)).BeginInit();
            this.ElPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer8)).BeginInit();
            this.SplitContainer8.Panel1.SuspendLayout();
            this.SplitContainer8.Panel2.SuspendLayout();
            this.SplitContainer8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer57)).BeginInit();
            this.SplitContainer57.Panel1.SuspendLayout();
            this.SplitContainer57.Panel2.SuspendLayout();
            this.SplitContainer57.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel18)).BeginInit();
            this.ElPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer9)).BeginInit();
            this.SplitContainer9.Panel1.SuspendLayout();
            this.SplitContainer9.Panel2.SuspendLayout();
            this.SplitContainer9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer58)).BeginInit();
            this.SplitContainer58.Panel1.SuspendLayout();
            this.SplitContainer58.Panel2.SuspendLayout();
            this.SplitContainer58.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton9)).BeginInit();
            this.TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel11)).BeginInit();
            this.ElPanel11.SuspendLayout();
            this.tabPublicationsStatus.SuspendLayout();
            this.TabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel9)).BeginInit();
            this.ElPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer13)).BeginInit();
            this.SplitContainer13.Panel1.SuspendLayout();
            this.SplitContainer13.Panel2.SuspendLayout();
            this.SplitContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsREsumeMainSpliter)).BeginInit();
            this.spltrPublicationsREsumeMainSpliter.Panel1.SuspendLayout();
            this.spltrPublicationsREsumeMainSpliter.Panel2.SuspendLayout();
            this.spltrPublicationsREsumeMainSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsREsumeHeaderSplitter)).BeginInit();
            this.spltrPublicationsREsumeHeaderSplitter.Panel1.SuspendLayout();
            this.spltrPublicationsREsumeHeaderSplitter.Panel2.SuspendLayout();
            this.spltrPublicationsREsumeHeaderSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer14)).BeginInit();
            this.SplitContainer14.Panel1.SuspendLayout();
            this.SplitContainer14.Panel2.SuspendLayout();
            this.SplitContainer14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel12)).BeginInit();
            this.ElPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCtnrPublicationVariablesHEaderResumeView)).BeginInit();
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel1.SuspendLayout();
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel2.SuspendLayout();
            this.spltCtnrPublicationVariablesHEaderResumeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer17)).BeginInit();
            this.SplitContainer17.Panel1.SuspendLayout();
            this.SplitContainer17.Panel2.SuspendLayout();
            this.SplitContainer17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox9)).BeginInit();
            this.ElGroupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel22)).BeginInit();
            this.ElPanel22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer15)).BeginInit();
            this.SplitContainer15.Panel1.SuspendLayout();
            this.SplitContainer15.Panel2.SuspendLayout();
            this.SplitContainer15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel23)).BeginInit();
            this.ElPanel23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCntrConnectedClientsResumeView)).BeginInit();
            this.spltCntrConnectedClientsResumeView.Panel1.SuspendLayout();
            this.spltCntrConnectedClientsResumeView.Panel2.SuspendLayout();
            this.spltCntrConnectedClientsResumeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer49)).BeginInit();
            this.SplitContainer49.Panel1.SuspendLayout();
            this.SplitContainer49.Panel2.SuspendLayout();
            this.SplitContainer49.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox11)).BeginInit();
            this.ElGroupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel24)).BeginInit();
            this.ElPanel24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTableStatsMainSpliter)).BeginInit();
            this.spltrPublicationsTableStatsMainSpliter.Panel1.SuspendLayout();
            this.spltrPublicationsTableStatsMainSpliter.Panel2.SuspendLayout();
            this.spltrPublicationsTableStatsMainSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitCtnrStatisticsHeader)).BeginInit();
            this.splitCtnrStatisticsHeader.Panel1.SuspendLayout();
            this.splitCtnrStatisticsHeader.Panel2.SuspendLayout();
            this.splitCtnrStatisticsHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer50)).BeginInit();
            this.SplitContainer50.Panel1.SuspendLayout();
            this.SplitContainer50.Panel2.SuspendLayout();
            this.SplitContainer50.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumtStatisticsUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumtStatisticsReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPublicationDataUpdateStatisticsListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox12)).BeginInit();
            this.ElGroupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox10)).BeginInit();
            this.ElGroupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton9)).BeginInit();
            this.TabPage10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel10)).BeginInit();
            this.ElPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer19)).BeginInit();
            this.SplitContainer19.Panel1.SuspendLayout();
            this.SplitContainer19.Panel2.SuspendLayout();
            this.SplitContainer19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTreeViewSpliter)).BeginInit();
            this.spltrPublicationsTreeViewSpliter.Panel1.SuspendLayout();
            this.spltrPublicationsTreeViewSpliter.Panel2.SuspendLayout();
            this.spltrPublicationsTreeViewSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTreeViewHeaderSpliter)).BeginInit();
            this.spltrPublicationsTreeViewHeaderSpliter.Panel1.SuspendLayout();
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.SuspendLayout();
            this.spltrPublicationsTreeViewHeaderSpliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer20)).BeginInit();
            this.SplitContainer20.Panel1.SuspendLayout();
            this.SplitContainer20.Panel2.SuspendLayout();
            this.SplitContainer20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel25)).BeginInit();
            this.ElPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCtnrPublicationVariablesHEadrTreeView)).BeginInit();
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel1.SuspendLayout();
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel2.SuspendLayout();
            this.spltCtnrPublicationVariablesHEadrTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer52)).BeginInit();
            this.SplitContainer52.Panel1.SuspendLayout();
            this.SplitContainer52.Panel2.SuspendLayout();
            this.SplitContainer52.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel17)).BeginInit();
            this.TabControl2.SuspendLayout();
            this.TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel26)).BeginInit();
            this.ElPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer22)).BeginInit();
            this.SplitContainer22.Panel1.SuspendLayout();
            this.SplitContainer22.Panel2.SuspendLayout();
            this.SplitContainer22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer23)).BeginInit();
            this.SplitContainer23.Panel1.SuspendLayout();
            this.SplitContainer23.Panel2.SuspendLayout();
            this.SplitContainer23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel27)).BeginInit();
            this.ElPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer24)).BeginInit();
            this.SplitContainer24.Panel1.SuspendLayout();
            this.SplitContainer24.Panel2.SuspendLayout();
            this.SplitContainer24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox13)).BeginInit();
            this.ElGroupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel28)).BeginInit();
            this.ElPanel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer25)).BeginInit();
            this.SplitContainer25.Panel1.SuspendLayout();
            this.SplitContainer25.Panel2.SuspendLayout();
            this.SplitContainer25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel29)).BeginInit();
            this.ElPanel29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer26)).BeginInit();
            this.SplitContainer26.Panel1.SuspendLayout();
            this.SplitContainer26.Panel2.SuspendLayout();
            this.SplitContainer26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox14)).BeginInit();
            this.ElGroupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel30)).BeginInit();
            this.ElPanel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer27)).BeginInit();
            this.SplitContainer27.Panel1.SuspendLayout();
            this.SplitContainer27.Panel2.SuspendLayout();
            this.SplitContainer27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox15)).BeginInit();
            this.ElGroupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox16)).BeginInit();
            this.ElGroupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton27)).BeginInit();
            this.TabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel31)).BeginInit();
            this.ElPanel31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer28)).BeginInit();
            this.SplitContainer28.Panel1.SuspendLayout();
            this.SplitContainer28.Panel2.SuspendLayout();
            this.SplitContainer28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer29)).BeginInit();
            this.SplitContainer29.Panel2.SuspendLayout();
            this.SplitContainer29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer30)).BeginInit();
            this.SplitContainer30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox17)).BeginInit();
            this.ElGroupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer21)).BeginInit();
            this.SplitContainer21.Panel1.SuspendLayout();
            this.SplitContainer21.Panel2.SuspendLayout();
            this.SplitContainer21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel32)).BeginInit();
            this.ElPanel32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltCntrConnectedClientsTreeView)).BeginInit();
            this.spltCntrConnectedClientsTreeView.Panel1.SuspendLayout();
            this.spltCntrConnectedClientsTreeView.Panel2.SuspendLayout();
            this.spltCntrConnectedClientsTreeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer53)).BeginInit();
            this.SplitContainer53.Panel1.SuspendLayout();
            this.SplitContainer53.Panel2.SuspendLayout();
            this.SplitContainer53.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel18)).BeginInit();
            this.TabControl3.SuspendLayout();
            this.TabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel33)).BeginInit();
            this.ElPanel33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer31)).BeginInit();
            this.SplitContainer31.Panel1.SuspendLayout();
            this.SplitContainer31.Panel2.SuspendLayout();
            this.SplitContainer31.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer32)).BeginInit();
            this.SplitContainer32.Panel1.SuspendLayout();
            this.SplitContainer32.Panel2.SuspendLayout();
            this.SplitContainer32.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel34)).BeginInit();
            this.ElPanel34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer33)).BeginInit();
            this.SplitContainer33.Panel1.SuspendLayout();
            this.SplitContainer33.Panel2.SuspendLayout();
            this.SplitContainer33.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox18)).BeginInit();
            this.ElGroupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel35)).BeginInit();
            this.ElPanel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer34)).BeginInit();
            this.SplitContainer34.Panel1.SuspendLayout();
            this.SplitContainer34.Panel2.SuspendLayout();
            this.SplitContainer34.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel36)).BeginInit();
            this.ElPanel36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer35)).BeginInit();
            this.SplitContainer35.Panel1.SuspendLayout();
            this.SplitContainer35.Panel2.SuspendLayout();
            this.SplitContainer35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox19)).BeginInit();
            this.ElGroupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel37)).BeginInit();
            this.ElPanel37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer36)).BeginInit();
            this.SplitContainer36.Panel1.SuspendLayout();
            this.SplitContainer36.Panel2.SuspendLayout();
            this.SplitContainer36.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox20)).BeginInit();
            this.ElGroupBox20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox21)).BeginInit();
            this.ElGroupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton41)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton42)).BeginInit();
            this.TabPage12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel38)).BeginInit();
            this.ElPanel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer37)).BeginInit();
            this.SplitContainer37.Panel1.SuspendLayout();
            this.SplitContainer37.Panel2.SuspendLayout();
            this.SplitContainer37.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer38)).BeginInit();
            this.SplitContainer38.Panel2.SuspendLayout();
            this.SplitContainer38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer39)).BeginInit();
            this.SplitContainer39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox22)).BeginInit();
            this.ElGroupBox22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton43)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton44)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton45)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel39)).BeginInit();
            this.ElPanel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer51)).BeginInit();
            this.SplitContainer51.Panel1.SuspendLayout();
            this.SplitContainer51.Panel2.SuspendLayout();
            this.SplitContainer51.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer54)).BeginInit();
            this.SplitContainer54.Panel1.SuspendLayout();
            this.SplitContainer54.Panel2.SuspendLayout();
            this.SplitContainer54.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer55)).BeginInit();
            this.SplitContainer55.Panel1.SuspendLayout();
            this.SplitContainer55.Panel2.SuspendLayout();
            this.SplitContainer55.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).BeginInit();
            this.SplitContainer3.Panel1.SuspendLayout();
            this.SplitContainer3.Panel2.SuspendLayout();
            this.SplitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumTreeViewStatisticsUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumTreeViewStatisticsReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPublicationDataUpdateStatisticsTreeView)).BeginInit();
            this.TabControl6.SuspendLayout();
            this.TabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel40)).BeginInit();
            this.ElPanel40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer40)).BeginInit();
            this.SplitContainer40.Panel1.SuspendLayout();
            this.SplitContainer40.Panel2.SuspendLayout();
            this.SplitContainer40.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer41)).BeginInit();
            this.SplitContainer41.Panel1.SuspendLayout();
            this.SplitContainer41.Panel2.SuspendLayout();
            this.SplitContainer41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel41)).BeginInit();
            this.ElPanel41.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer42)).BeginInit();
            this.SplitContainer42.Panel1.SuspendLayout();
            this.SplitContainer42.Panel2.SuspendLayout();
            this.SplitContainer42.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox23)).BeginInit();
            this.ElGroupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton46)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton47)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton48)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel42)).BeginInit();
            this.ElPanel42.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer43)).BeginInit();
            this.SplitContainer43.Panel1.SuspendLayout();
            this.SplitContainer43.Panel2.SuspendLayout();
            this.SplitContainer43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel43)).BeginInit();
            this.ElPanel43.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer44)).BeginInit();
            this.SplitContainer44.Panel1.SuspendLayout();
            this.SplitContainer44.Panel2.SuspendLayout();
            this.SplitContainer44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox24)).BeginInit();
            this.ElGroupBox24.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton50)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton51)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel44)).BeginInit();
            this.ElPanel44.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer45)).BeginInit();
            this.SplitContainer45.Panel1.SuspendLayout();
            this.SplitContainer45.Panel2.SuspendLayout();
            this.SplitContainer45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox25)).BeginInit();
            this.ElGroupBox25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton52)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton53)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton54)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox26)).BeginInit();
            this.ElGroupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton55)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton57)).BeginInit();
            this.TabPage14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel45)).BeginInit();
            this.ElPanel45.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer46)).BeginInit();
            this.SplitContainer46.Panel1.SuspendLayout();
            this.SplitContainer46.Panel2.SuspendLayout();
            this.SplitContainer46.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer47)).BeginInit();
            this.SplitContainer47.Panel2.SuspendLayout();
            this.SplitContainer47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer48)).BeginInit();
            this.SplitContainer48.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox27)).BeginInit();
            this.ElGroupBox27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton58)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton59)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton60)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox3)).BeginInit();
            this.ElGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton6)).BeginInit();
            this.TabPage15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnClearLog)).BeginInit();
            this.TabPage20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer11)).BeginInit();
            this.SplitContainer11.Panel1.SuspendLayout();
            this.SplitContainer11.Panel2.SuspendLayout();
            this.SplitContainer11.SuspendLayout();
            this.TabControl5.SuspendLayout();
            this.TabPage21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv4)).BeginInit();
            this.TabPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv6)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltMainSplitContainer)).BeginInit();
            this.spltMainSplitContainer.Panel1.SuspendLayout();
            this.spltMainSplitContainer.Panel2.SuspendLayout();
            this.spltMainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltStatusBarLikeSpliter)).BeginInit();
            this.spltStatusBarLikeSpliter.Panel1.SuspendLayout();
            this.spltStatusBarLikeSpliter.Panel2.SuspendLayout();
            this.spltStatusBarLikeSpliter.SuspendLayout();
            this.SuspendLayout();
            // 
            // C1SizerLight1
            // 
            this.C1SizerLight1.ResizeFonts = false;
            // 
            // spltrPublicationsTreeViewMainSpliter
            // 
            this.spltrPublicationsTreeViewMainSpliter.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.spltrPublicationsTreeViewMainSpliter.Controls.Add(this.tapgae1);
            this.spltrPublicationsTreeViewMainSpliter.Controls.Add(this.TabPage2);
            this.spltrPublicationsTreeViewMainSpliter.Controls.Add(this.TabPage1);
            this.spltrPublicationsTreeViewMainSpliter.Controls.Add(this.TabPage15);
            this.spltrPublicationsTreeViewMainSpliter.Controls.Add(this.TabPage20);
            this.spltrPublicationsTreeViewMainSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsTreeViewMainSpliter.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spltrPublicationsTreeViewMainSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsTreeViewMainSpliter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spltrPublicationsTreeViewMainSpliter.Name = "spltrPublicationsTreeViewMainSpliter";
            this.spltrPublicationsTreeViewMainSpliter.SelectedIndex = 0;
            this.spltrPublicationsTreeViewMainSpliter.Size = new System.Drawing.Size(944, 488);
            this.spltrPublicationsTreeViewMainSpliter.TabIndex = 1;
            // 
            // tapgae1
            // 
            this.tapgae1.BackColor = System.Drawing.Color.White;
            this.tapgae1.Controls.Add(this.spltrServerParameters);
            this.tapgae1.Location = new System.Drawing.Point(4, 28);
            this.tapgae1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tapgae1.Name = "tapgae1";
            this.tapgae1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tapgae1.Size = new System.Drawing.Size(936, 456);
            this.tapgae1.TabIndex = 0;
            this.tapgae1.Text = "Service Parameters";
            // 
            // spltrServerParameters
            // 
            this.spltrServerParameters.BackColor = System.Drawing.Color.White;
            this.spltrServerParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrServerParameters.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrServerParameters.IsSplitterFixed = true;
            this.spltrServerParameters.Location = new System.Drawing.Point(3, 4);
            this.spltrServerParameters.Name = "spltrServerParameters";
            this.spltrServerParameters.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrServerParameters.Panel1
            // 
            this.spltrServerParameters.Panel1.Controls.Add(this.Label6);
            // 
            // spltrServerParameters.Panel2
            // 
            this.spltrServerParameters.Panel2.Controls.Add(this.dgrdServerParameters);
            this.spltrServerParameters.Size = new System.Drawing.Size(930, 448);
            this.spltrServerParameters.SplitterDistance = 38;
            this.spltrServerParameters.TabIndex = 7;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Black;
            this.Label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Image = global::My.Resources.Resources.ListOfPublications;
            this.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Label6.Location = new System.Drawing.Point(0, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(930, 38);
            this.Label6.TabIndex = 58;
            this.Label6.Text = "Publications Server Parameters";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgrdServerParameters
            // 
            this.dgrdServerParameters.AllowUserToAddRows = false;
            this.dgrdServerParameters.AllowUserToDeleteRows = false;
            this.dgrdServerParameters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdServerParameters.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdServerParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdServerParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdServerParameters.Location = new System.Drawing.Point(0, 0);
            this.dgrdServerParameters.MultiSelect = false;
            this.dgrdServerParameters.Name = "dgrdServerParameters";
            this.dgrdServerParameters.ReadOnly = true;
            this.dgrdServerParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrdServerParameters.Size = new System.Drawing.Size(930, 406);
            this.dgrdServerParameters.TabIndex = 5;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.ElPanel3);
            this.TabPage2.Location = new System.Drawing.Point(4, 28);
            this.TabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TabPage2.Size = new System.Drawing.Size(936, 456);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Client Connections";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // ElPanel3
            // 
            this.ElPanel3.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel3.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel3.Controls.Add(this.tabClientConnections);
            this.ElPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel3.Location = new System.Drawing.Point(3, 4);
            this.ElPanel3.Name = "ElPanel3";
            this.ElPanel3.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel3.Size = new System.Drawing.Size(930, 448);
            this.ElPanel3.TabIndex = 14;
            this.ElPanel3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // tabClientConnections
            // 
            this.tabClientConnections.Controls.Add(this.tabpConnectedClients);
            this.tabClientConnections.Controls.Add(this.tabpPublisherClients);
            this.tabClientConnections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClientConnections.Location = new System.Drawing.Point(0, 0);
            this.tabClientConnections.Name = "tabClientConnections";
            this.tabClientConnections.SelectedIndex = 0;
            this.tabClientConnections.Size = new System.Drawing.Size(930, 448);
            this.tabClientConnections.TabIndex = 1;
            // 
            // tabpConnectedClients
            // 
            this.tabpConnectedClients.Controls.Add(this.TabSubscibedClients);
            this.tabpConnectedClients.Location = new System.Drawing.Point(4, 25);
            this.tabpConnectedClients.Name = "tabpConnectedClients";
            this.tabpConnectedClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabpConnectedClients.Size = new System.Drawing.Size(922, 419);
            this.tabpConnectedClients.TabIndex = 1;
            this.tabpConnectedClients.Text = "All Client Connections";
            this.tabpConnectedClients.UseVisualStyleBackColor = true;
            // 
            // TabSubscibedClients
            // 
            this.TabSubscibedClients.Controls.Add(this.TabPage5);
            this.TabSubscibedClients.Controls.Add(this.TabPage6);
            this.TabSubscibedClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabSubscibedClients.ImageList = this.imgViewsImagesList;
            this.TabSubscibedClients.Location = new System.Drawing.Point(3, 3);
            this.TabSubscibedClients.Name = "TabSubscibedClients";
            this.TabSubscibedClients.SelectedIndex = 0;
            this.TabSubscibedClients.Size = new System.Drawing.Size(916, 413);
            this.TabSubscibedClients.TabIndex = 1;
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.ElPanel5);
            this.TabPage5.ImageIndex = 0;
            this.TabPage5.Location = new System.Drawing.Point(4, 29);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(908, 380);
            this.TabPage5.TabIndex = 0;
            this.TabPage5.Text = "List View";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // ElPanel5
            // 
            this.ElPanel5.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel5.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel5.Controls.Add(this.SplitContainer1);
            this.ElPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel5.Location = new System.Drawing.Point(3, 3);
            this.ElPanel5.Name = "ElPanel5";
            this.ElPanel5.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel5.Size = new System.Drawing.Size(902, 374);
            this.ElPanel5.TabIndex = 13;
            this.ElPanel5.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.spltrClientCnnTableviewMainSpliter);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.splAllClientsViewPublicationsCnnStatus);
            this.SplitContainer1.Size = new System.Drawing.Size(902, 374);
            this.SplitContainer1.SplitterDistance = 167;
            this.SplitContainer1.TabIndex = 19;
            // 
            // spltrClientCnnTableviewMainSpliter
            // 
            this.spltrClientCnnTableviewMainSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientCnnTableviewMainSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClientCnnTableviewMainSpliter.IsSplitterFixed = true;
            this.spltrClientCnnTableviewMainSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrClientCnnTableviewMainSpliter.Name = "spltrClientCnnTableviewMainSpliter";
            this.spltrClientCnnTableviewMainSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClientCnnTableviewMainSpliter.Panel1
            // 
            this.spltrClientCnnTableviewMainSpliter.Panel1.Controls.Add(this.spltrClientCnnTableviewHeaderSpliter);
            // 
            // spltrClientCnnTableviewMainSpliter.Panel2
            // 
            this.spltrClientCnnTableviewMainSpliter.Panel2.Controls.Add(this.lstvClientSubscriptors);
            this.spltrClientCnnTableviewMainSpliter.Size = new System.Drawing.Size(902, 167);
            this.spltrClientCnnTableviewMainSpliter.SplitterDistance = 36;
            this.spltrClientCnnTableviewMainSpliter.TabIndex = 2;
            // 
            // spltrClientCnnTableviewHeaderSpliter
            // 
            this.spltrClientCnnTableviewHeaderSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientCnnTableviewHeaderSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClientCnnTableviewHeaderSpliter.IsSplitterFixed = true;
            this.spltrClientCnnTableviewHeaderSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrClientCnnTableviewHeaderSpliter.Name = "spltrClientCnnTableviewHeaderSpliter";
            // 
            // spltrClientCnnTableviewHeaderSpliter.Panel1
            // 
            this.spltrClientCnnTableviewHeaderSpliter.Panel1.Controls.Add(this.label1);
            // 
            // spltrClientCnnTableviewHeaderSpliter.Panel2
            // 
            this.spltrClientCnnTableviewHeaderSpliter.Panel2.Controls.Add(this.Button4);
            this.spltrClientCnnTableviewHeaderSpliter.Panel2.Controls.Add(this.btnClientCnnsListViewAdjustCols);
            this.spltrClientCnnTableviewHeaderSpliter.Panel2.Controls.Add(this.btnClientsCnnListViewZoom);
            this.spltrClientCnnTableviewHeaderSpliter.Size = new System.Drawing.Size(902, 36);
            this.spltrClientCnnTableviewHeaderSpliter.SplitterDistance = 756;
            this.spltrClientCnnTableviewHeaderSpliter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = global::My.Resources.Resources.usersGroup;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(756, 36);
            this.label1.TabIndex = 59;
            this.label1.Text = "Client Connections";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button4
            // 
            this.Button4.BackgroundImage = global::My.Resources.Resources.reload;
            this.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button4.Location = new System.Drawing.Point(95, 0);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(46, 36);
            this.Button4.TabIndex = 12;
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // btnClientCnnsListViewAdjustCols
            // 
            this.btnClientCnnsListViewAdjustCols.BackgroundImage = global::My.Resources.Resources.ColumnsAdjustment;
            this.btnClientCnnsListViewAdjustCols.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsListViewAdjustCols.Location = new System.Drawing.Point(49, 0);
            this.btnClientCnnsListViewAdjustCols.Name = "btnClientCnnsListViewAdjustCols";
            this.btnClientCnnsListViewAdjustCols.Size = new System.Drawing.Size(46, 36);
            this.btnClientCnnsListViewAdjustCols.TabIndex = 6;
            this.btnClientCnnsListViewAdjustCols.UseVisualStyleBackColor = true;
            this.btnClientCnnsListViewAdjustCols.Click += new System.EventHandler(this.btnClientCnnsListViewAdjustCols_Click);
            // 
            // btnClientsCnnListViewZoom
            // 
            this.btnClientsCnnListViewZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnClientsCnnListViewZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientsCnnListViewZoom.Location = new System.Drawing.Point(3, 0);
            this.btnClientsCnnListViewZoom.Name = "btnClientsCnnListViewZoom";
            this.btnClientsCnnListViewZoom.Size = new System.Drawing.Size(46, 36);
            this.btnClientsCnnListViewZoom.TabIndex = 5;
            this.btnClientsCnnListViewZoom.UseVisualStyleBackColor = true;
            this.btnClientsCnnListViewZoom.Click += new System.EventHandler(this.btnClientsCnnListViewZoom_Click);
            // 
            // lstvClientSubscriptors
            // 
            this.lstvClientSubscriptors.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstvClientSubscriptors.BackColor = System.Drawing.Color.LemonChiffon;
            this.lstvClientSubscriptors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvClientSubscriptors.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvClientSubscriptors.FullRowSelect = true;
            this.lstvClientSubscriptors.GridLines = true;
            this.lstvClientSubscriptors.HideSelection = false;
            this.lstvClientSubscriptors.Location = new System.Drawing.Point(0, 0);
            this.lstvClientSubscriptors.Name = "lstvClientSubscriptors";
            this.lstvClientSubscriptors.Size = new System.Drawing.Size(902, 127);
            this.lstvClientSubscriptors.SmallImageList = this.imglstClientConnectionsRegistry;
            this.lstvClientSubscriptors.TabIndex = 1;
            this.lstvClientSubscriptors.UseCompatibleStateImageBehavior = false;
            this.lstvClientSubscriptors.SelectedIndexChanged += new System.EventHandler(this.lstvClientSubscriptors_SelectedIndexChanged);
            // 
            // imglstClientConnectionsRegistry
            // 
            this.imglstClientConnectionsRegistry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstClientConnectionsRegistry.ImageStream")));
            this.imglstClientConnectionsRegistry.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstClientConnectionsRegistry.Images.SetKeyName(0, "HostNodeIcon.ico");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(1, "ApplicationNodeIcon.ico");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(2, "ClientNodeIcon.ico");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(3, "ClientIDNodeIcon.ico");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(4, "NetworkIDNodeIcon.ICO");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(5, "connectionDatetimeNodeIcon.gif");
            this.imglstClientConnectionsRegistry.Images.SetKeyName(6, "ClientIDNodeIcon.gif");
            // 
            // splAllClientsViewPublicationsCnnStatus
            // 
            this.splAllClientsViewPublicationsCnnStatus.BackColor = System.Drawing.SystemColors.Control;
            this.splAllClientsViewPublicationsCnnStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splAllClientsViewPublicationsCnnStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splAllClientsViewPublicationsCnnStatus.Location = new System.Drawing.Point(0, 0);
            this.splAllClientsViewPublicationsCnnStatus.Name = "splAllClientsViewPublicationsCnnStatus";
            // 
            // splAllClientsViewPublicationsCnnStatus.Panel1
            // 
            this.splAllClientsViewPublicationsCnnStatus.Panel1.Controls.Add(this.spltrClientsAllViewPostedPubsMain);
            // 
            // splAllClientsViewPublicationsCnnStatus.Panel2
            // 
            this.splAllClientsViewPublicationsCnnStatus.Panel2.Controls.Add(this.spltrClientsAllViewPubsConnectionsMain);
            this.splAllClientsViewPublicationsCnnStatus.Size = new System.Drawing.Size(902, 203);
            this.splAllClientsViewPublicationsCnnStatus.SplitterDistance = 444;
            this.splAllClientsViewPublicationsCnnStatus.SplitterIncrement = 5;
            this.splAllClientsViewPublicationsCnnStatus.TabIndex = 0;
            // 
            // spltrClientsAllViewPostedPubsMain
            // 
            this.spltrClientsAllViewPostedPubsMain.BackColor = System.Drawing.Color.Transparent;
            this.spltrClientsAllViewPostedPubsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientsAllViewPostedPubsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClientsAllViewPostedPubsMain.IsSplitterFixed = true;
            this.spltrClientsAllViewPostedPubsMain.Location = new System.Drawing.Point(0, 0);
            this.spltrClientsAllViewPostedPubsMain.Name = "spltrClientsAllViewPostedPubsMain";
            this.spltrClientsAllViewPostedPubsMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClientsAllViewPostedPubsMain.Panel1
            // 
            this.spltrClientsAllViewPostedPubsMain.Panel1.Controls.Add(this.spltrClientsAllViewPostedPubsMainHeader);
            // 
            // spltrClientsAllViewPostedPubsMain.Panel2
            // 
            this.spltrClientsAllViewPostedPubsMain.Panel2.Controls.Add(this.lsvAllConnectionsPostedPublications);
            this.spltrClientsAllViewPostedPubsMain.Size = new System.Drawing.Size(440, 199);
            this.spltrClientsAllViewPostedPubsMain.SplitterDistance = 36;
            this.spltrClientsAllViewPostedPubsMain.TabIndex = 5;
            // 
            // spltrClientsAllViewPostedPubsMainHeader
            // 
            this.spltrClientsAllViewPostedPubsMainHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientsAllViewPostedPubsMainHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClientsAllViewPostedPubsMainHeader.IsSplitterFixed = true;
            this.spltrClientsAllViewPostedPubsMainHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrClientsAllViewPostedPubsMainHeader.Name = "spltrClientsAllViewPostedPubsMainHeader";
            // 
            // spltrClientsAllViewPostedPubsMainHeader.Panel1
            // 
            this.spltrClientsAllViewPostedPubsMainHeader.Panel1.Controls.Add(this.label2);
            // 
            // spltrClientsAllViewPostedPubsMainHeader.Panel2
            // 
            this.spltrClientsAllViewPostedPubsMainHeader.Panel2.Controls.Add(this.btnZoomAllClientsTableViewPostedPubsList);
            this.spltrClientsAllViewPostedPubsMainHeader.Size = new System.Drawing.Size(440, 36);
            this.spltrClientsAllViewPostedPubsMainHeader.SplitterDistance = 390;
            this.spltrClientsAllViewPostedPubsMainHeader.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::My.Resources.Resources.publicationVariables;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 36);
            this.label2.TabIndex = 60;
            this.label2.Text = "Posted Publications by Client ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomAllClientsTableViewPostedPubsList
            // 
            this.btnZoomAllClientsTableViewPostedPubsList.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomAllClientsTableViewPostedPubsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomAllClientsTableViewPostedPubsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomAllClientsTableViewPostedPubsList.Location = new System.Drawing.Point(0, 0);
            this.btnZoomAllClientsTableViewPostedPubsList.Name = "btnZoomAllClientsTableViewPostedPubsList";
            this.btnZoomAllClientsTableViewPostedPubsList.Size = new System.Drawing.Size(46, 36);
            this.btnZoomAllClientsTableViewPostedPubsList.TabIndex = 2;
            this.btnZoomAllClientsTableViewPostedPubsList.UseVisualStyleBackColor = true;
            this.btnZoomAllClientsTableViewPostedPubsList.Click += new System.EventHandler(this.btnZoomAllClientsTableViewPostedPubsList_Click);
            // 
            // lsvAllConnectionsPostedPublications
            // 
            this.lsvAllConnectionsPostedPublications.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAllConnectionsPostedPublications.BackColor = System.Drawing.Color.White;
            this.lsvAllConnectionsPostedPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAllConnectionsPostedPublications.FullRowSelect = true;
            this.lsvAllConnectionsPostedPublications.GridLines = true;
            this.lsvAllConnectionsPostedPublications.HideSelection = false;
            this.lsvAllConnectionsPostedPublications.Location = new System.Drawing.Point(0, 0);
            this.lsvAllConnectionsPostedPublications.MultiSelect = false;
            this.lsvAllConnectionsPostedPublications.Name = "lsvAllConnectionsPostedPublications";
            this.lsvAllConnectionsPostedPublications.Size = new System.Drawing.Size(440, 159);
            this.lsvAllConnectionsPostedPublications.SmallImageList = this.imgLstClientPublicatiosRegistry;
            this.lsvAllConnectionsPostedPublications.TabIndex = 2;
            this.lsvAllConnectionsPostedPublications.UseCompatibleStateImageBehavior = false;
            // 
            // imgLstClientPublicatiosRegistry
            // 
            this.imgLstClientPublicatiosRegistry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstClientPublicatiosRegistry.ImageStream")));
            this.imgLstClientPublicatiosRegistry.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(0, "PublicationNodeIcon.png");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(1, "CreationDatetimeNodeIcon.gif");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(2, "VariablesCountNodeIcon.ico");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(3, "socketsServerOPortNodeIcon.gif");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(4, "multicastIPNodeIcon.ICO");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(5, "MulticastPortNodeIcon.ICO");
            this.imgLstClientPublicatiosRegistry.Images.SetKeyName(6, "SubscriptorsCountNodeIcon.png");
            // 
            // spltrClientsAllViewPubsConnectionsMain
            // 
            this.spltrClientsAllViewPubsConnectionsMain.BackColor = System.Drawing.Color.Transparent;
            this.spltrClientsAllViewPubsConnectionsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientsAllViewPubsConnectionsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClientsAllViewPubsConnectionsMain.IsSplitterFixed = true;
            this.spltrClientsAllViewPubsConnectionsMain.Location = new System.Drawing.Point(0, 0);
            this.spltrClientsAllViewPubsConnectionsMain.Name = "spltrClientsAllViewPubsConnectionsMain";
            this.spltrClientsAllViewPubsConnectionsMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClientsAllViewPubsConnectionsMain.Panel1
            // 
            this.spltrClientsAllViewPubsConnectionsMain.Panel1.Controls.Add(this.spltrClientsAllViewPubsConnectionsMainHeader);
            // 
            // spltrClientsAllViewPubsConnectionsMain.Panel2
            // 
            this.spltrClientsAllViewPubsConnectionsMain.Panel2.Controls.Add(this.lsvAllConnectionsConnectionToPublications);
            this.spltrClientsAllViewPubsConnectionsMain.Size = new System.Drawing.Size(450, 199);
            this.spltrClientsAllViewPubsConnectionsMain.SplitterDistance = 37;
            this.spltrClientsAllViewPubsConnectionsMain.TabIndex = 5;
            // 
            // spltrClientsAllViewPubsConnectionsMainHeader
            // 
            this.spltrClientsAllViewPubsConnectionsMainHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientsAllViewPubsConnectionsMainHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClientsAllViewPubsConnectionsMainHeader.IsSplitterFixed = true;
            this.spltrClientsAllViewPubsConnectionsMainHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrClientsAllViewPubsConnectionsMainHeader.Name = "spltrClientsAllViewPubsConnectionsMainHeader";
            // 
            // spltrClientsAllViewPubsConnectionsMainHeader.Panel1
            // 
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel1.Controls.Add(this.label3);
            // 
            // spltrClientsAllViewPubsConnectionsMainHeader.Panel2
            // 
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel2.Controls.Add(this.btnZoomAllClientsTableViewPubsConnectionsList);
            this.spltrClientsAllViewPubsConnectionsMainHeader.Size = new System.Drawing.Size(450, 37);
            this.spltrClientsAllViewPubsConnectionsMainHeader.SplitterDistance = 398;
            this.spltrClientsAllViewPubsConnectionsMainHeader.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::My.Resources.Resources.publicationVariables;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(398, 37);
            this.label3.TabIndex = 61;
            this.label3.Text = "Client Publications Connections";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomAllClientsTableViewPubsConnectionsList
            // 
            this.btnZoomAllClientsTableViewPubsConnectionsList.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomAllClientsTableViewPubsConnectionsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomAllClientsTableViewPubsConnectionsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomAllClientsTableViewPubsConnectionsList.Location = new System.Drawing.Point(0, 0);
            this.btnZoomAllClientsTableViewPubsConnectionsList.Name = "btnZoomAllClientsTableViewPubsConnectionsList";
            this.btnZoomAllClientsTableViewPubsConnectionsList.Size = new System.Drawing.Size(48, 37);
            this.btnZoomAllClientsTableViewPubsConnectionsList.TabIndex = 3;
            this.btnZoomAllClientsTableViewPubsConnectionsList.UseVisualStyleBackColor = true;
            this.btnZoomAllClientsTableViewPubsConnectionsList.Click += new System.EventHandler(this.btnZoomAllClientsTableViewPubsConnectionsList_Click);
            // 
            // lsvAllConnectionsConnectionToPublications
            // 
            this.lsvAllConnectionsConnectionToPublications.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAllConnectionsConnectionToPublications.BackColor = System.Drawing.Color.White;
            this.lsvAllConnectionsConnectionToPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAllConnectionsConnectionToPublications.FullRowSelect = true;
            this.lsvAllConnectionsConnectionToPublications.GridLines = true;
            this.lsvAllConnectionsConnectionToPublications.HideSelection = false;
            this.lsvAllConnectionsConnectionToPublications.Location = new System.Drawing.Point(0, 0);
            this.lsvAllConnectionsConnectionToPublications.MultiSelect = false;
            this.lsvAllConnectionsConnectionToPublications.Name = "lsvAllConnectionsConnectionToPublications";
            this.lsvAllConnectionsConnectionToPublications.Size = new System.Drawing.Size(450, 158);
            this.lsvAllConnectionsConnectionToPublications.TabIndex = 3;
            this.lsvAllConnectionsConnectionToPublications.UseCompatibleStateImageBehavior = false;
            // 
            // TabPage6
            // 
            this.TabPage6.Controls.Add(this.ElPanel6);
            this.TabPage6.ImageIndex = 1;
            this.TabPage6.Location = new System.Drawing.Point(4, 29);
            this.TabPage6.Name = "TabPage6";
            this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage6.Size = new System.Drawing.Size(908, 380);
            this.TabPage6.TabIndex = 1;
            this.TabPage6.Text = "Tree View";
            this.TabPage6.UseVisualStyleBackColor = true;
            // 
            // ElPanel6
            // 
            this.ElPanel6.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel6.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel6.Controls.Add(this.spltrClientCnnsTreeViewMain);
            this.ElPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel6.Location = new System.Drawing.Point(3, 3);
            this.ElPanel6.Name = "ElPanel6";
            this.ElPanel6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel6.Size = new System.Drawing.Size(902, 374);
            this.ElPanel6.TabIndex = 13;
            this.ElPanel6.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltrClientCnnsTreeViewMain
            // 
            this.spltrClientCnnsTreeViewMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientCnnsTreeViewMain.Location = new System.Drawing.Point(0, 0);
            this.spltrClientCnnsTreeViewMain.Name = "spltrClientCnnsTreeViewMain";
            this.spltrClientCnnsTreeViewMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClientCnnsTreeViewMain.Panel1
            // 
            this.spltrClientCnnsTreeViewMain.Panel1.Controls.Add(this.spltrClientCnnsTreeViewAndHeader);
            // 
            // spltrClientCnnsTreeViewMain.Panel2
            // 
            this.spltrClientCnnsTreeViewMain.Panel2.Controls.Add(this.SplitContainer4);
            this.spltrClientCnnsTreeViewMain.Size = new System.Drawing.Size(902, 374);
            this.spltrClientCnnsTreeViewMain.SplitterDistance = 167;
            this.spltrClientCnnsTreeViewMain.TabIndex = 22;
            // 
            // spltrClientCnnsTreeViewAndHeader
            // 
            this.spltrClientCnnsTreeViewAndHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientCnnsTreeViewAndHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClientCnnsTreeViewAndHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrClientCnnsTreeViewAndHeader.Name = "spltrClientCnnsTreeViewAndHeader";
            this.spltrClientCnnsTreeViewAndHeader.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClientCnnsTreeViewAndHeader.Panel1
            // 
            this.spltrClientCnnsTreeViewAndHeader.Panel1.Controls.Add(this.spltrClientCnnsTitleAndButtons);
            // 
            // spltrClientCnnsTreeViewAndHeader.Panel2
            // 
            this.spltrClientCnnsTreeViewAndHeader.Panel2.Controls.Add(this.tvwClientSubscriptors);
            this.spltrClientCnnsTreeViewAndHeader.Size = new System.Drawing.Size(902, 167);
            this.spltrClientCnnsTreeViewAndHeader.SplitterDistance = 36;
            this.spltrClientCnnsTreeViewAndHeader.TabIndex = 0;
            // 
            // spltrClientCnnsTitleAndButtons
            // 
            this.spltrClientCnnsTitleAndButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientCnnsTitleAndButtons.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClientCnnsTitleAndButtons.IsSplitterFixed = true;
            this.spltrClientCnnsTitleAndButtons.Location = new System.Drawing.Point(0, 0);
            this.spltrClientCnnsTitleAndButtons.Name = "spltrClientCnnsTitleAndButtons";
            // 
            // spltrClientCnnsTitleAndButtons.Panel1
            // 
            this.spltrClientCnnsTitleAndButtons.Panel1.Controls.Add(this.ElLabel26);
            // 
            // spltrClientCnnsTitleAndButtons.Panel2
            // 
            this.spltrClientCnnsTitleAndButtons.Panel2.Controls.Add(this.btnClientConnsTreeViewCollapseNode);
            this.spltrClientCnnsTitleAndButtons.Panel2.Controls.Add(this.btnClientConnsTreeViewCollapseAll);
            this.spltrClientCnnsTitleAndButtons.Panel2.Controls.Add(this.btnClientConnsTreeViewExpandAll);
            this.spltrClientCnnsTitleAndButtons.Panel2.Controls.Add(this.btnClientConnsTreeViewZoom);
            this.spltrClientCnnsTitleAndButtons.Size = new System.Drawing.Size(902, 36);
            this.spltrClientCnnsTitleAndButtons.SplitterDistance = 711;
            this.spltrClientCnnsTitleAndButtons.TabIndex = 0;
            // 
            // ElLabel26
            // 
            this.ElLabel26.Cursor = System.Windows.Forms.Cursors.Default;
            this.ElLabel26.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle1.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle1.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel26.FlashStyle = paintStyle1;
            this.ElLabel26.ForegroundImageStyle.Image = global::My.Resources.Resources.usersGroup;
            this.ElLabel26.Location = new System.Drawing.Point(0, 0);
            this.ElLabel26.Name = "ElLabel26";
            this.ElLabel26.Size = new System.Drawing.Size(711, 36);
            this.ElLabel26.TabIndex = 12;
            this.ElLabel26.TabStop = false;
            this.ElLabel26.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel26.TextStyle.Text = "Client Connections";
            this.ElLabel26.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClientConnsTreeViewCollapseNode
            // 
            this.btnClientConnsTreeViewCollapseNode.BackgroundImage = global::My.Resources.Resources.reload;
            this.btnClientConnsTreeViewCollapseNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientConnsTreeViewCollapseNode.Location = new System.Drawing.Point(140, 0);
            this.btnClientConnsTreeViewCollapseNode.Name = "btnClientConnsTreeViewCollapseNode";
            this.btnClientConnsTreeViewCollapseNode.Size = new System.Drawing.Size(46, 36);
            this.btnClientConnsTreeViewCollapseNode.TabIndex = 11;
            this.btnClientConnsTreeViewCollapseNode.UseVisualStyleBackColor = true;
            this.btnClientConnsTreeViewCollapseNode.Click += new System.EventHandler(this.btnClientConnsTreeViewCollapseNode_Click);
            // 
            // btnClientConnsTreeViewCollapseAll
            // 
            this.btnClientConnsTreeViewCollapseAll.BackgroundImage = global::My.Resources.Resources.CollapseTree;
            this.btnClientConnsTreeViewCollapseAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientConnsTreeViewCollapseAll.Location = new System.Drawing.Point(94, 0);
            this.btnClientConnsTreeViewCollapseAll.Name = "btnClientConnsTreeViewCollapseAll";
            this.btnClientConnsTreeViewCollapseAll.Size = new System.Drawing.Size(46, 36);
            this.btnClientConnsTreeViewCollapseAll.TabIndex = 9;
            this.btnClientConnsTreeViewCollapseAll.UseVisualStyleBackColor = true;
            this.btnClientConnsTreeViewCollapseAll.Click += new System.EventHandler(this.btnClientConnsTreeViewCollapseAll_Click);
            // 
            // btnClientConnsTreeViewExpandAll
            // 
            this.btnClientConnsTreeViewExpandAll.BackgroundImage = global::My.Resources.Resources.ExpandTree;
            this.btnClientConnsTreeViewExpandAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientConnsTreeViewExpandAll.Location = new System.Drawing.Point(48, 0);
            this.btnClientConnsTreeViewExpandAll.Name = "btnClientConnsTreeViewExpandAll";
            this.btnClientConnsTreeViewExpandAll.Size = new System.Drawing.Size(46, 36);
            this.btnClientConnsTreeViewExpandAll.TabIndex = 8;
            this.btnClientConnsTreeViewExpandAll.UseVisualStyleBackColor = true;
            this.btnClientConnsTreeViewExpandAll.Click += new System.EventHandler(this.btnClientConnsTreeViewExpandAll_Click);
            // 
            // btnClientConnsTreeViewZoom
            // 
            this.btnClientConnsTreeViewZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnClientConnsTreeViewZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientConnsTreeViewZoom.Location = new System.Drawing.Point(2, 0);
            this.btnClientConnsTreeViewZoom.Name = "btnClientConnsTreeViewZoom";
            this.btnClientConnsTreeViewZoom.Size = new System.Drawing.Size(46, 36);
            this.btnClientConnsTreeViewZoom.TabIndex = 7;
            this.btnClientConnsTreeViewZoom.UseVisualStyleBackColor = true;
            this.btnClientConnsTreeViewZoom.Click += new System.EventHandler(this.btnClientConnsTreeViewZoom_Click);
            // 
            // tvwClientSubscriptors
            // 
            this.tvwClientSubscriptors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwClientSubscriptors.HideSelection = false;
            this.tvwClientSubscriptors.ImageIndex = 0;
            this.tvwClientSubscriptors.ImageList = this.imglstClientConnectionsRegistry;
            this.tvwClientSubscriptors.Location = new System.Drawing.Point(0, 0);
            this.tvwClientSubscriptors.Name = "tvwClientSubscriptors";
            this.tvwClientSubscriptors.SelectedImageIndex = 0;
            this.tvwClientSubscriptors.Size = new System.Drawing.Size(902, 127);
            this.tvwClientSubscriptors.TabIndex = 1;
            this.tvwClientSubscriptors.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwClientSubscriptors_AfterSelect);
            // 
            // SplitContainer4
            // 
            this.SplitContainer4.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer4.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer4.Name = "SplitContainer4";
            // 
            // SplitContainer4.Panel1
            // 
            this.SplitContainer4.Panel1.Controls.Add(this.ElPanel15);
            // 
            // SplitContainer4.Panel2
            // 
            this.SplitContainer4.Panel2.Controls.Add(this.ElPanel16);
            this.SplitContainer4.Size = new System.Drawing.Size(902, 203);
            this.SplitContainer4.SplitterDistance = 450;
            this.SplitContainer4.TabIndex = 0;
            // 
            // ElPanel15
            // 
            this.ElPanel15.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel15.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel15.Controls.Add(this.spltrClienCnnsTreeViewPostedPublications);
            this.ElPanel15.Controls.Add(this.ElButton6);
            this.ElPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel15.Location = new System.Drawing.Point(0, 0);
            this.ElPanel15.Name = "ElPanel15";
            this.ElPanel15.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel15.Size = new System.Drawing.Size(446, 199);
            this.ElPanel15.TabIndex = 20;
            this.ElPanel15.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltrClienCnnsTreeViewPostedPublications
            // 
            this.spltrClienCnnsTreeViewPostedPublications.BackColor = System.Drawing.Color.Transparent;
            this.spltrClienCnnsTreeViewPostedPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClienCnnsTreeViewPostedPublications.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClienCnnsTreeViewPostedPublications.Location = new System.Drawing.Point(0, 0);
            this.spltrClienCnnsTreeViewPostedPublications.Name = "spltrClienCnnsTreeViewPostedPublications";
            this.spltrClienCnnsTreeViewPostedPublications.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClienCnnsTreeViewPostedPublications.Panel1
            // 
            this.spltrClienCnnsTreeViewPostedPublications.Panel1.Controls.Add(this.spltrClienCnnsTreeViewPostedHeader);
            // 
            // spltrClienCnnsTreeViewPostedPublications.Panel2
            // 
            this.spltrClienCnnsTreeViewPostedPublications.Panel2.Controls.Add(this.lsvAllConnectionsByHostPublicationsPosted);
            this.spltrClienCnnsTreeViewPostedPublications.Size = new System.Drawing.Size(446, 199);
            this.spltrClienCnnsTreeViewPostedPublications.SplitterDistance = 37;
            this.spltrClienCnnsTreeViewPostedPublications.TabIndex = 5;
            // 
            // spltrClienCnnsTreeViewPostedHeader
            // 
            this.spltrClienCnnsTreeViewPostedHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClienCnnsTreeViewPostedHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClienCnnsTreeViewPostedHeader.IsSplitterFixed = true;
            this.spltrClienCnnsTreeViewPostedHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrClienCnnsTreeViewPostedHeader.Name = "spltrClienCnnsTreeViewPostedHeader";
            // 
            // spltrClienCnnsTreeViewPostedHeader.Panel1
            // 
            this.spltrClienCnnsTreeViewPostedHeader.Panel1.Controls.Add(this.ElLabel27);
            // 
            // spltrClienCnnsTreeViewPostedHeader.Panel2
            // 
            this.spltrClienCnnsTreeViewPostedHeader.Panel2.Controls.Add(this.btnClientCnnsTreeViewPostedPubsZoom);
            this.spltrClienCnnsTreeViewPostedHeader.Size = new System.Drawing.Size(446, 37);
            this.spltrClienCnnsTreeViewPostedHeader.SplitterDistance = 396;
            this.spltrClienCnnsTreeViewPostedHeader.TabIndex = 0;
            // 
            // ElLabel27
            // 
            this.ElLabel27.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle2.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle2.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel27.FlashStyle = paintStyle2;
            this.ElLabel27.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel27.Location = new System.Drawing.Point(0, 0);
            this.ElLabel27.Name = "ElLabel27";
            this.ElLabel27.Size = new System.Drawing.Size(396, 37);
            this.ElLabel27.TabIndex = 11;
            this.ElLabel27.TabStop = false;
            this.ElLabel27.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel27.TextStyle.Text = "Posted Publications by Client ";
            this.ElLabel27.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClientCnnsTreeViewPostedPubsZoom
            // 
            this.btnClientCnnsTreeViewPostedPubsZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnClientCnnsTreeViewPostedPubsZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsTreeViewPostedPubsZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClientCnnsTreeViewPostedPubsZoom.Location = new System.Drawing.Point(0, 0);
            this.btnClientCnnsTreeViewPostedPubsZoom.Name = "btnClientCnnsTreeViewPostedPubsZoom";
            this.btnClientCnnsTreeViewPostedPubsZoom.Size = new System.Drawing.Size(46, 37);
            this.btnClientCnnsTreeViewPostedPubsZoom.TabIndex = 3;
            this.btnClientCnnsTreeViewPostedPubsZoom.UseVisualStyleBackColor = true;
            this.btnClientCnnsTreeViewPostedPubsZoom.Click += new System.EventHandler(this.btnClientCnnsTreeViewPostedPubsZoom_Click);
            // 
            // lsvAllConnectionsByHostPublicationsPosted
            // 
            this.lsvAllConnectionsByHostPublicationsPosted.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAllConnectionsByHostPublicationsPosted.BackColor = System.Drawing.Color.White;
            this.lsvAllConnectionsByHostPublicationsPosted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAllConnectionsByHostPublicationsPosted.FullRowSelect = true;
            this.lsvAllConnectionsByHostPublicationsPosted.GridLines = true;
            this.lsvAllConnectionsByHostPublicationsPosted.HideSelection = false;
            this.lsvAllConnectionsByHostPublicationsPosted.Location = new System.Drawing.Point(0, 0);
            this.lsvAllConnectionsByHostPublicationsPosted.MultiSelect = false;
            this.lsvAllConnectionsByHostPublicationsPosted.Name = "lsvAllConnectionsByHostPublicationsPosted";
            this.lsvAllConnectionsByHostPublicationsPosted.Size = new System.Drawing.Size(446, 158);
            this.lsvAllConnectionsByHostPublicationsPosted.SmallImageList = this.imgLstClientPublicatiosRegistry;
            this.lsvAllConnectionsByHostPublicationsPosted.TabIndex = 3;
            this.lsvAllConnectionsByHostPublicationsPosted.UseCompatibleStateImageBehavior = false;
            // 
            // ElButton6
            // 
            this.ElButton6.BorderStyle.EdgeRadius = 7;
            this.ElButton6.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton6.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton6.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton6.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton6.Location = new System.Drawing.Point(619, 583);
            this.ElButton6.Name = "ElButton6";
            this.ElButton6.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton6.Size = new System.Drawing.Size(128, 34);
            this.ElButton6.TabIndex = 3;
            this.ElButton6.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton6.TextStyle.Text = "Update Views";
            // 
            // ElPanel16
            // 
            this.ElPanel16.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel16.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel16.Controls.Add(this.spltrClienCnnsTreeViewPublicationsConnsMain);
            this.ElPanel16.Controls.Add(this.ElButton7);
            this.ElPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel16.Location = new System.Drawing.Point(0, 0);
            this.ElPanel16.Name = "ElPanel16";
            this.ElPanel16.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel16.Size = new System.Drawing.Size(444, 199);
            this.ElPanel16.TabIndex = 21;
            this.ElPanel16.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltrClienCnnsTreeViewPublicationsConnsMain
            // 
            this.spltrClienCnnsTreeViewPublicationsConnsMain.BackColor = System.Drawing.Color.Transparent;
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClienCnnsTreeViewPublicationsConnsMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrClienCnnsTreeViewPublicationsConnsMain.IsSplitterFixed = true;
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Location = new System.Drawing.Point(0, 0);
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Name = "spltrClienCnnsTreeViewPublicationsConnsMain";
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrClienCnnsTreeViewPublicationsConnsMain.Panel1
            // 
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel1.Controls.Add(this.spltrClienCnnsTreeViewPubsConnectionsHeader);
            // 
            // spltrClienCnnsTreeViewPublicationsConnsMain.Panel2
            // 
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel2.Controls.Add(this.lsvAllConnectionsByHostConnectionToPublications);
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Size = new System.Drawing.Size(444, 199);
            this.spltrClienCnnsTreeViewPublicationsConnsMain.SplitterDistance = 38;
            this.spltrClienCnnsTreeViewPublicationsConnsMain.TabIndex = 5;
            // 
            // spltrClienCnnsTreeViewPubsConnectionsHeader
            // 
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.IsSplitterFixed = true;
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Name = "spltrClienCnnsTreeViewPubsConnectionsHeader";
            // 
            // spltrClienCnnsTreeViewPubsConnectionsHeader.Panel1
            // 
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel1.Controls.Add(this.ElLabel28);
            // 
            // spltrClienCnnsTreeViewPubsConnectionsHeader.Panel2
            // 
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel2.Controls.Add(this.btnClienCnnsTreeViewPubcConnsZoom);
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Size = new System.Drawing.Size(444, 38);
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.SplitterDistance = 392;
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.TabIndex = 0;
            // 
            // ElLabel28
            // 
            this.ElLabel28.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle3.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle3.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel28.FlashStyle = paintStyle3;
            this.ElLabel28.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel28.Location = new System.Drawing.Point(0, 0);
            this.ElLabel28.Name = "ElLabel28";
            this.ElLabel28.Size = new System.Drawing.Size(392, 38);
            this.ElLabel28.TabIndex = 12;
            this.ElLabel28.TabStop = false;
            this.ElLabel28.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel28.TextStyle.Text = "Client Publications Connections";
            this.ElLabel28.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClienCnnsTreeViewPubcConnsZoom
            // 
            this.btnClienCnnsTreeViewPubcConnsZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnClienCnnsTreeViewPubcConnsZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClienCnnsTreeViewPubcConnsZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClienCnnsTreeViewPubcConnsZoom.Location = new System.Drawing.Point(0, 0);
            this.btnClienCnnsTreeViewPubcConnsZoom.Name = "btnClienCnnsTreeViewPubcConnsZoom";
            this.btnClienCnnsTreeViewPubcConnsZoom.Size = new System.Drawing.Size(48, 38);
            this.btnClienCnnsTreeViewPubcConnsZoom.TabIndex = 4;
            this.btnClienCnnsTreeViewPubcConnsZoom.UseVisualStyleBackColor = true;
            this.btnClienCnnsTreeViewPubcConnsZoom.Click += new System.EventHandler(this.btnClienCnnsTreeViewPubcConnsZoom_Click);
            // 
            // lsvAllConnectionsByHostConnectionToPublications
            // 
            this.lsvAllConnectionsByHostConnectionToPublications.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvAllConnectionsByHostConnectionToPublications.BackColor = System.Drawing.Color.White;
            this.lsvAllConnectionsByHostConnectionToPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvAllConnectionsByHostConnectionToPublications.FullRowSelect = true;
            this.lsvAllConnectionsByHostConnectionToPublications.GridLines = true;
            this.lsvAllConnectionsByHostConnectionToPublications.HideSelection = false;
            this.lsvAllConnectionsByHostConnectionToPublications.Location = new System.Drawing.Point(0, 0);
            this.lsvAllConnectionsByHostConnectionToPublications.MultiSelect = false;
            this.lsvAllConnectionsByHostConnectionToPublications.Name = "lsvAllConnectionsByHostConnectionToPublications";
            this.lsvAllConnectionsByHostConnectionToPublications.Size = new System.Drawing.Size(444, 157);
            this.lsvAllConnectionsByHostConnectionToPublications.TabIndex = 3;
            this.lsvAllConnectionsByHostConnectionToPublications.UseCompatibleStateImageBehavior = false;
            // 
            // ElButton7
            // 
            this.ElButton7.BorderStyle.EdgeRadius = 7;
            this.ElButton7.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton7.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton7.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton7.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton7.Location = new System.Drawing.Point(619, 583);
            this.ElButton7.Name = "ElButton7";
            this.ElButton7.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton7.Size = new System.Drawing.Size(128, 34);
            this.ElButton7.TabIndex = 3;
            this.ElButton7.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton7.TextStyle.Text = "Update Views";
            // 
            // imgViewsImagesList
            // 
            this.imgViewsImagesList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgViewsImagesList.ImageStream")));
            this.imgViewsImagesList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgViewsImagesList.Images.SetKeyName(0, "TableList.ICO");
            this.imgViewsImagesList.Images.SetKeyName(1, "TreeView.ICO");
            // 
            // tabpPublisherClients
            // 
            this.tabpPublisherClients.Controls.Add(this.ElPanel4);
            this.tabpPublisherClients.Location = new System.Drawing.Point(4, 25);
            this.tabpPublisherClients.Name = "tabpPublisherClients";
            this.tabpPublisherClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabpPublisherClients.Size = new System.Drawing.Size(922, 419);
            this.tabpPublisherClients.TabIndex = 2;
            this.tabpPublisherClients.Text = "Publisher Clients";
            this.tabpPublisherClients.UseVisualStyleBackColor = true;
            // 
            // ElPanel4
            // 
            this.ElPanel4.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel4.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel4.Controls.Add(this.TabControl4);
            this.ElPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel4.Location = new System.Drawing.Point(3, 3);
            this.ElPanel4.Name = "ElPanel4";
            this.ElPanel4.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel4.Size = new System.Drawing.Size(916, 413);
            this.ElPanel4.TabIndex = 14;
            this.ElPanel4.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // TabControl4
            // 
            this.TabControl4.Controls.Add(this.TabPage7);
            this.TabControl4.Controls.Add(this.TabPage8);
            this.TabControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl4.ImageList = this.imgViewsImagesList;
            this.TabControl4.Location = new System.Drawing.Point(0, 0);
            this.TabControl4.Name = "TabControl4";
            this.TabControl4.SelectedIndex = 0;
            this.TabControl4.Size = new System.Drawing.Size(916, 413);
            this.TabControl4.TabIndex = 2;
            // 
            // TabPage7
            // 
            this.TabPage7.Controls.Add(this.ElPanel7);
            this.TabPage7.ImageIndex = 0;
            this.TabPage7.Location = new System.Drawing.Point(4, 29);
            this.TabPage7.Name = "TabPage7";
            this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage7.Size = new System.Drawing.Size(908, 380);
            this.TabPage7.TabIndex = 0;
            this.TabPage7.Text = "List View";
            this.TabPage7.UseVisualStyleBackColor = true;
            // 
            // ElPanel7
            // 
            this.ElPanel7.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel7.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel7.Controls.Add(this.SplitContainer5);
            this.ElPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel7.Location = new System.Drawing.Point(3, 3);
            this.ElPanel7.Name = "ElPanel7";
            this.ElPanel7.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel7.Size = new System.Drawing.Size(902, 374);
            this.ElPanel7.TabIndex = 13;
            this.ElPanel7.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer5
            // 
            this.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer5.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer5.Name = "SplitContainer5";
            this.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer5.Panel1
            // 
            this.SplitContainer5.Panel1.Controls.Add(this.spltrPublisherClientsListMain);
            this.SplitContainer5.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer5.Panel2
            // 
            this.SplitContainer5.Panel2.Controls.Add(this.ElPanel17);
            this.SplitContainer5.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer5.Size = new System.Drawing.Size(902, 374);
            this.SplitContainer5.SplitterDistance = 170;
            this.SplitContainer5.TabIndex = 4;
            // 
            // spltrPublisherClientsListMain
            // 
            this.spltrPublisherClientsListMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublisherClientsListMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublisherClientsListMain.IsSplitterFixed = true;
            this.spltrPublisherClientsListMain.Location = new System.Drawing.Point(0, 0);
            this.spltrPublisherClientsListMain.Name = "spltrPublisherClientsListMain";
            this.spltrPublisherClientsListMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublisherClientsListMain.Panel1
            // 
            this.spltrPublisherClientsListMain.Panel1.Controls.Add(this.spltrPublisherClientsListHeader);
            this.spltrPublisherClientsListMain.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // spltrPublisherClientsListMain.Panel2
            // 
            this.spltrPublisherClientsListMain.Panel2.Controls.Add(this.lsvPublisherClients);
            this.spltrPublisherClientsListMain.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spltrPublisherClientsListMain.Size = new System.Drawing.Size(902, 170);
            this.spltrPublisherClientsListMain.SplitterDistance = 38;
            this.spltrPublisherClientsListMain.TabIndex = 0;
            // 
            // spltrPublisherClientsListHeader
            // 
            this.spltrPublisherClientsListHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublisherClientsListHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrPublisherClientsListHeader.IsSplitterFixed = true;
            this.spltrPublisherClientsListHeader.Location = new System.Drawing.Point(0, 0);
            this.spltrPublisherClientsListHeader.Name = "spltrPublisherClientsListHeader";
            // 
            // spltrPublisherClientsListHeader.Panel1
            // 
            this.spltrPublisherClientsListHeader.Panel1.Controls.Add(this.ElLabel29);
            this.spltrPublisherClientsListHeader.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // spltrPublisherClientsListHeader.Panel2
            // 
            this.spltrPublisherClientsListHeader.Panel2.Controls.Add(this.Button5);
            this.spltrPublisherClientsListHeader.Panel2.Controls.Add(this.Button6);
            this.spltrPublisherClientsListHeader.Panel2.Controls.Add(this.Button3);
            this.spltrPublisherClientsListHeader.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spltrPublisherClientsListHeader.Size = new System.Drawing.Size(902, 38);
            this.spltrPublisherClientsListHeader.SplitterDistance = 759;
            this.spltrPublisherClientsListHeader.TabIndex = 0;
            // 
            // ElLabel29
            // 
            this.ElLabel29.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle4.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle4.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel29.FlashStyle = paintStyle4;
            this.ElLabel29.ForegroundImageStyle.Image = global::My.Resources.Resources.usersGroup;
            this.ElLabel29.Location = new System.Drawing.Point(0, 0);
            this.ElLabel29.Name = "ElLabel29";
            this.ElLabel29.Size = new System.Drawing.Size(759, 38);
            this.ElLabel29.TabIndex = 13;
            this.ElLabel29.TabStop = false;
            this.ElLabel29.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel29.TextStyle.Text = "Publisher Clients Connections";
            this.ElLabel29.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button5
            // 
            this.Button5.BackgroundImage = global::My.Resources.Resources.reload;
            this.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button5.Location = new System.Drawing.Point(91, 1);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(46, 36);
            this.Button5.TabIndex = 14;
            this.Button5.UseVisualStyleBackColor = true;
            this.Button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Button6
            // 
            this.Button6.BackgroundImage = global::My.Resources.Resources.ColumnsAdjustment;
            this.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button6.Location = new System.Drawing.Point(46, 1);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(46, 36);
            this.Button6.TabIndex = 13;
            this.Button6.UseVisualStyleBackColor = true;
            this.Button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // Button3
            // 
            this.Button3.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button3.Location = new System.Drawing.Point(0, 1);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(46, 36);
            this.Button3.TabIndex = 8;
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // lsvPublisherClients
            // 
            this.lsvPublisherClients.BackColor = System.Drawing.Color.LemonChiffon;
            this.lsvPublisherClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublisherClients.HideSelection = false;
            this.lsvPublisherClients.Location = new System.Drawing.Point(0, 0);
            this.lsvPublisherClients.MultiSelect = false;
            this.lsvPublisherClients.Name = "lsvPublisherClients";
            this.lsvPublisherClients.Size = new System.Drawing.Size(902, 128);
            this.lsvPublisherClients.SmallImageList = this.imglstPublisherClientConnectionsRegistry;
            this.lsvPublisherClients.TabIndex = 2;
            this.lsvPublisherClients.UseCompatibleStateImageBehavior = false;
            this.lsvPublisherClients.SelectedIndexChanged += new System.EventHandler(this.lsvPublisherClients_SelectedIndexChanged);
            // 
            // imglstPublisherClientConnectionsRegistry
            // 
            this.imglstPublisherClientConnectionsRegistry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstPublisherClientConnectionsRegistry.ImageStream")));
            this.imglstPublisherClientConnectionsRegistry.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(0, "HostNodeIcon.ico");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(1, "ApplicationNodeIcon.ico");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(2, "ClientNodeIcon.ico");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(3, "ClientIDNodeIcon.ico");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(4, "NetworkIDNodeIcon.ICO");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(5, "ClientP2PPortNode.ico");
            this.imglstPublisherClientConnectionsRegistry.Images.SetKeyName(6, "PublicationsPostedNodeIcon.ico");
            // 
            // ElPanel17
            // 
            this.ElPanel17.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel17.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel17.Controls.Add(this.ElGroupBox1);
            this.ElPanel17.Controls.Add(this.ElButton8);
            this.ElPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel17.Location = new System.Drawing.Point(0, 0);
            this.ElPanel17.Name = "ElPanel17";
            this.ElPanel17.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel17.Size = new System.Drawing.Size(902, 200);
            this.ElPanel17.TabIndex = 16;
            this.ElPanel17.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElGroupBox1
            // 
            this.ElGroupBox1.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox1.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox1.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox1.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox1.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox1.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox1.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox1.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox1.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox1.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox1.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox1.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox1.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox1.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox1.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox1.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox1.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox1.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox1.CaptionStyle.TextStyle.Text = "Publications Posted";
            this.ElGroupBox1.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox1.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox1.Controls.Add(this.SplitContainer10);
            this.ElGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ElGroupBox1.Name = "ElGroupBox1";
            this.ElGroupBox1.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox1.Size = new System.Drawing.Size(902, 200);
            this.ElGroupBox1.TabIndex = 18;
            this.ElGroupBox1.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer10
            // 
            this.SplitContainer10.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer10.Location = new System.Drawing.Point(4, 23);
            this.SplitContainer10.Name = "SplitContainer10";
            // 
            // SplitContainer10.Panel1
            // 
            this.SplitContainer10.Panel1.Controls.Add(this.ElPanel20);
            this.SplitContainer10.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer10.Panel2
            // 
            this.SplitContainer10.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer10.Panel2.Controls.Add(this.ElPanel21);
            this.SplitContainer10.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer10.Size = new System.Drawing.Size(894, 174);
            this.SplitContainer10.SplitterDistance = 598;
            this.SplitContainer10.TabIndex = 4;
            // 
            // ElPanel20
            // 
            this.ElPanel20.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel20.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel20.Controls.Add(this.spltrPublicationsPostedPublishersTableView);
            this.ElPanel20.Controls.Add(this.ElButton11);
            this.ElPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel20.Location = new System.Drawing.Point(0, 0);
            this.ElPanel20.Name = "ElPanel20";
            this.ElPanel20.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel20.Size = new System.Drawing.Size(594, 170);
            this.ElPanel20.TabIndex = 16;
            this.ElPanel20.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltrPublicationsPostedPublishersTableView
            // 
            this.spltrPublicationsPostedPublishersTableView.BackColor = System.Drawing.Color.Transparent;
            this.spltrPublicationsPostedPublishersTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsPostedPublishersTableView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublicationsPostedPublishersTableView.IsSplitterFixed = true;
            this.spltrPublicationsPostedPublishersTableView.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsPostedPublishersTableView.Name = "spltrPublicationsPostedPublishersTableView";
            this.spltrPublicationsPostedPublishersTableView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublicationsPostedPublishersTableView.Panel1
            // 
            this.spltrPublicationsPostedPublishersTableView.Panel1.Controls.Add(this.SplitContainer16);
            this.spltrPublicationsPostedPublishersTableView.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // spltrPublicationsPostedPublishersTableView.Panel2
            // 
            this.spltrPublicationsPostedPublishersTableView.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.spltrPublicationsPostedPublishersTableView.Panel2.Controls.Add(this.lsvPublisherConnectionsAllPublicationsPosted);
            this.spltrPublicationsPostedPublishersTableView.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.spltrPublicationsPostedPublishersTableView.Size = new System.Drawing.Size(594, 170);
            this.spltrPublicationsPostedPublishersTableView.SplitterDistance = 35;
            this.spltrPublicationsPostedPublishersTableView.TabIndex = 0;
            // 
            // SplitContainer16
            // 
            this.SplitContainer16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer16.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer16.IsSplitterFixed = true;
            this.SplitContainer16.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer16.Name = "SplitContainer16";
            // 
            // SplitContainer16.Panel1
            // 
            this.SplitContainer16.Panel1.Controls.Add(this.ElLabel3);
            this.SplitContainer16.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer16.Panel2
            // 
            this.SplitContainer16.Panel2.Controls.Add(this.btnAllPublihsersPubliationsListZoomView);
            this.SplitContainer16.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer16.Size = new System.Drawing.Size(594, 35);
            this.SplitContainer16.SplitterDistance = 539;
            this.SplitContainer16.TabIndex = 0;
            // 
            // ElLabel3
            // 
            this.ElLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle5.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle5.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel3.FlashStyle = paintStyle5;
            this.ElLabel3.ForegroundImageStyle.Image = global::My.Resources.Resources.ListOfPublications;
            this.ElLabel3.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel3.ForegroundImageStyle.ImageSize = new System.Drawing.Size(25, 25);
            this.ElLabel3.Location = new System.Drawing.Point(0, 0);
            this.ElLabel3.Name = "ElLabel3";
            this.ElLabel3.Size = new System.Drawing.Size(539, 35);
            this.ElLabel3.TabIndex = 6;
            this.ElLabel3.TabStop = false;
            this.ElLabel3.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel3.TextStyle.Text = "Publications List";
            this.ElLabel3.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAllPublihsersPubliationsListZoomView
            // 
            this.btnAllPublihsersPubliationsListZoomView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnAllPublihsersPubliationsListZoomView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAllPublihsersPubliationsListZoomView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllPublihsersPubliationsListZoomView.Location = new System.Drawing.Point(0, 0);
            this.btnAllPublihsersPubliationsListZoomView.Name = "btnAllPublihsersPubliationsListZoomView";
            this.btnAllPublihsersPubliationsListZoomView.Size = new System.Drawing.Size(51, 35);
            this.btnAllPublihsersPubliationsListZoomView.TabIndex = 4;
            this.btnAllPublihsersPubliationsListZoomView.UseVisualStyleBackColor = true;
            this.btnAllPublihsersPubliationsListZoomView.Click += new System.EventHandler(this.btnAllPublihsersPubliationsListZoomView_Click);
            // 
            // lsvPublisherConnectionsAllPublicationsPosted
            // 
            this.lsvPublisherConnectionsAllPublicationsPosted.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublisherConnectionsAllPublicationsPosted.BackColor = System.Drawing.Color.White;
            this.lsvPublisherConnectionsAllPublicationsPosted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublisherConnectionsAllPublicationsPosted.FullRowSelect = true;
            this.lsvPublisherConnectionsAllPublicationsPosted.GridLines = true;
            this.lsvPublisherConnectionsAllPublicationsPosted.HideSelection = false;
            this.lsvPublisherConnectionsAllPublicationsPosted.Location = new System.Drawing.Point(0, 0);
            this.lsvPublisherConnectionsAllPublicationsPosted.MultiSelect = false;
            this.lsvPublisherConnectionsAllPublicationsPosted.Name = "lsvPublisherConnectionsAllPublicationsPosted";
            this.lsvPublisherConnectionsAllPublicationsPosted.Size = new System.Drawing.Size(594, 131);
            this.lsvPublisherConnectionsAllPublicationsPosted.SmallImageList = this.imgLstClientPublicatiosRegistry;
            this.lsvPublisherConnectionsAllPublicationsPosted.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublisherConnectionsAllPublicationsPosted.TabIndex = 2;
            this.lsvPublisherConnectionsAllPublicationsPosted.UseCompatibleStateImageBehavior = false;
            this.lsvPublisherConnectionsAllPublicationsPosted.SelectedIndexChanged += new System.EventHandler(this.lsvPublisherConnectionsAllPublicationsPosted_SelectedIndexChanged);
            // 
            // ElButton11
            // 
            this.ElButton11.BorderStyle.EdgeRadius = 7;
            this.ElButton11.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton11.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton11.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton11.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton11.Location = new System.Drawing.Point(619, 583);
            this.ElButton11.Name = "ElButton11";
            this.ElButton11.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton11.Size = new System.Drawing.Size(128, 34);
            this.ElButton11.TabIndex = 3;
            this.ElButton11.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton11.TextStyle.Text = "Update Views";
            // 
            // ElPanel21
            // 
            this.ElPanel21.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel21.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel21.Controls.Add(this.SplitContainer12);
            this.ElPanel21.Controls.Add(this.ElButton12);
            this.ElPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel21.Location = new System.Drawing.Point(0, 0);
            this.ElPanel21.Name = "ElPanel21";
            this.ElPanel21.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel21.Size = new System.Drawing.Size(288, 170);
            this.ElPanel21.TabIndex = 16;
            this.ElPanel21.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer12
            // 
            this.SplitContainer12.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer12.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer12.IsSplitterFixed = true;
            this.SplitContainer12.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer12.Name = "SplitContainer12";
            this.SplitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer12.Panel1
            // 
            this.SplitContainer12.Panel1.Controls.Add(this.SplitContainer56);
            this.SplitContainer12.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer12.Panel2
            // 
            this.SplitContainer12.Panel2.Controls.Add(this.lsvPublisherConnectionsAllPublicationsPostedVariablesList);
            this.SplitContainer12.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer12.Size = new System.Drawing.Size(288, 170);
            this.SplitContainer12.SplitterDistance = 36;
            this.SplitContainer12.TabIndex = 5;
            // 
            // SplitContainer56
            // 
            this.SplitContainer56.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer56.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer56.IsSplitterFixed = true;
            this.SplitContainer56.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer56.Name = "SplitContainer56";
            // 
            // SplitContainer56.Panel1
            // 
            this.SplitContainer56.Panel1.Controls.Add(this.ElLabel4);
            this.SplitContainer56.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // SplitContainer56.Panel2
            // 
            this.SplitContainer56.Panel2.Controls.Add(this.btnAllPublishersPublicationVariablesZoom);
            this.SplitContainer56.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplitContainer56.Size = new System.Drawing.Size(288, 36);
            this.SplitContainer56.SplitterDistance = 232;
            this.SplitContainer56.TabIndex = 0;
            // 
            // ElLabel4
            // 
            this.ElLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle6.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle6.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel4.FlashStyle = paintStyle6;
            this.ElLabel4.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel4.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel4.ForegroundImageStyle.ImageSize = new System.Drawing.Size(25, 25);
            this.ElLabel4.Location = new System.Drawing.Point(0, 0);
            this.ElLabel4.Name = "ElLabel4";
            this.ElLabel4.Size = new System.Drawing.Size(232, 36);
            this.ElLabel4.TabIndex = 7;
            this.ElLabel4.TabStop = false;
            this.ElLabel4.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel4.TextStyle.Text = "Publication Variables";
            this.ElLabel4.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAllPublishersPublicationVariablesZoom
            // 
            this.btnAllPublishersPublicationVariablesZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnAllPublishersPublicationVariablesZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAllPublishersPublicationVariablesZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllPublishersPublicationVariablesZoom.Location = new System.Drawing.Point(0, 0);
            this.btnAllPublishersPublicationVariablesZoom.Name = "btnAllPublishersPublicationVariablesZoom";
            this.btnAllPublishersPublicationVariablesZoom.Size = new System.Drawing.Size(52, 36);
            this.btnAllPublishersPublicationVariablesZoom.TabIndex = 5;
            this.btnAllPublishersPublicationVariablesZoom.UseVisualStyleBackColor = true;
            this.btnAllPublishersPublicationVariablesZoom.Click += new System.EventHandler(this.btnAllPublishersPublicationVariablesZoom_Click);
            // 
            // lsvPublisherConnectionsAllPublicationsPostedVariablesList
            // 
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.BackColor = System.Drawing.Color.White;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.FullRowSelect = true;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.GridLines = true;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.HideSelection = false;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Location = new System.Drawing.Point(0, 0);
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.MultiSelect = false;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Name = "lsvPublisherConnectionsAllPublicationsPostedVariablesList";
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Size = new System.Drawing.Size(288, 130);
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.TabIndex = 3;
            this.lsvPublisherConnectionsAllPublicationsPostedVariablesList.UseCompatibleStateImageBehavior = false;
            // 
            // ElButton12
            // 
            this.ElButton12.BorderStyle.EdgeRadius = 7;
            this.ElButton12.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton12.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton12.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton12.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton12.Location = new System.Drawing.Point(619, 583);
            this.ElButton12.Name = "ElButton12";
            this.ElButton12.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton12.Size = new System.Drawing.Size(128, 34);
            this.ElButton12.TabIndex = 3;
            this.ElButton12.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton12.TextStyle.Text = "Update Views";
            // 
            // ElButton8
            // 
            this.ElButton8.BorderStyle.EdgeRadius = 7;
            this.ElButton8.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton8.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton8.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton8.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton8.Location = new System.Drawing.Point(619, 583);
            this.ElButton8.Name = "ElButton8";
            this.ElButton8.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton8.Size = new System.Drawing.Size(128, 34);
            this.ElButton8.TabIndex = 3;
            this.ElButton8.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton8.TextStyle.Text = "Update Views";
            // 
            // TabPage8
            // 
            this.TabPage8.Controls.Add(this.ElPanel8);
            this.TabPage8.ImageIndex = 1;
            this.TabPage8.Location = new System.Drawing.Point(4, 29);
            this.TabPage8.Name = "TabPage8";
            this.TabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage8.Size = new System.Drawing.Size(908, 383);
            this.TabPage8.TabIndex = 1;
            this.TabPage8.Text = "Tree View";
            this.TabPage8.UseVisualStyleBackColor = true;
            // 
            // ElPanel8
            // 
            this.ElPanel8.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel8.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel8.Controls.Add(this.SplitContainer6);
            this.ElPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel8.Location = new System.Drawing.Point(3, 3);
            this.ElPanel8.Name = "ElPanel8";
            this.ElPanel8.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel8.Size = new System.Drawing.Size(902, 377);
            this.ElPanel8.TabIndex = 13;
            this.ElPanel8.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer6
            // 
            this.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer6.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer6.Name = "SplitContainer6";
            this.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer6.Panel1
            // 
            this.SplitContainer6.Panel1.Controls.Add(this.spltrPublisherstreeView);
            // 
            // SplitContainer6.Panel2
            // 
            this.SplitContainer6.Panel2.Controls.Add(this.ElGroupBox8);
            this.SplitContainer6.Size = new System.Drawing.Size(902, 377);
            this.SplitContainer6.SplitterDistance = 169;
            this.SplitContainer6.TabIndex = 17;
            // 
            // spltrPublisherstreeView
            // 
            this.spltrPublisherstreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublisherstreeView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublisherstreeView.IsSplitterFixed = true;
            this.spltrPublisherstreeView.Location = new System.Drawing.Point(0, 0);
            this.spltrPublisherstreeView.Name = "spltrPublisherstreeView";
            this.spltrPublisherstreeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublisherstreeView.Panel1
            // 
            this.spltrPublisherstreeView.Panel1.Controls.Add(this.spltrClientConnsPublishersTreeViewHEader);
            // 
            // spltrPublisherstreeView.Panel2
            // 
            this.spltrPublisherstreeView.Panel2.Controls.Add(this.tvwPublisherClients);
            this.spltrPublisherstreeView.Size = new System.Drawing.Size(902, 169);
            this.spltrPublisherstreeView.SplitterDistance = 35;
            this.spltrPublisherstreeView.TabIndex = 16;
            // 
            // spltrClientConnsPublishersTreeViewHEader
            // 
            this.spltrClientConnsPublishersTreeViewHEader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrClientConnsPublishersTreeViewHEader.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrClientConnsPublishersTreeViewHEader.IsSplitterFixed = true;
            this.spltrClientConnsPublishersTreeViewHEader.Location = new System.Drawing.Point(0, 0);
            this.spltrClientConnsPublishersTreeViewHEader.Name = "spltrClientConnsPublishersTreeViewHEader";
            // 
            // spltrClientConnsPublishersTreeViewHEader.Panel1
            // 
            this.spltrClientConnsPublishersTreeViewHEader.Panel1.Controls.Add(this.ElLabel30);
            // 
            // spltrClientConnsPublishersTreeViewHEader.Panel2
            // 
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.Controls.Add(this.btnClientCnnsPublishersTreeViewNodeCollapse);
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.Controls.Add(this.btnClientCnnsPublishersTreeViewCollapseAll);
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.Controls.Add(this.btnClientCnnsPublishersTreeViewExpandAll);
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.Controls.Add(this.btnClientCnnsPublishersTreeViewZoom);
            this.spltrClientConnsPublishersTreeViewHEader.Size = new System.Drawing.Size(902, 35);
            this.spltrClientConnsPublishersTreeViewHEader.SplitterDistance = 711;
            this.spltrClientConnsPublishersTreeViewHEader.TabIndex = 0;
            // 
            // ElLabel30
            // 
            this.ElLabel30.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle7.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle7.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel30.FlashStyle = paintStyle7;
            this.ElLabel30.ForegroundImageStyle.Image = global::My.Resources.Resources.usersGroup;
            this.ElLabel30.Location = new System.Drawing.Point(0, 0);
            this.ElLabel30.Name = "ElLabel30";
            this.ElLabel30.Size = new System.Drawing.Size(711, 35);
            this.ElLabel30.TabIndex = 14;
            this.ElLabel30.TabStop = false;
            this.ElLabel30.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel30.TextStyle.Text = "Publisher Clients Connections";
            this.ElLabel30.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClientCnnsPublishersTreeViewNodeCollapse
            // 
            this.btnClientCnnsPublishersTreeViewNodeCollapse.BackgroundImage = global::My.Resources.Resources.reload;
            this.btnClientCnnsPublishersTreeViewNodeCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsPublishersTreeViewNodeCollapse.Location = new System.Drawing.Point(140, 0);
            this.btnClientCnnsPublishersTreeViewNodeCollapse.Name = "btnClientCnnsPublishersTreeViewNodeCollapse";
            this.btnClientCnnsPublishersTreeViewNodeCollapse.Size = new System.Drawing.Size(46, 36);
            this.btnClientCnnsPublishersTreeViewNodeCollapse.TabIndex = 16;
            this.btnClientCnnsPublishersTreeViewNodeCollapse.UseVisualStyleBackColor = true;
            this.btnClientCnnsPublishersTreeViewNodeCollapse.Click += new System.EventHandler(this.btnClientCnnsPublishersTreeViewNodeCollapse_Click);
            // 
            // btnClientCnnsPublishersTreeViewCollapseAll
            // 
            this.btnClientCnnsPublishersTreeViewCollapseAll.BackgroundImage = global::My.Resources.Resources.CollapseTree;
            this.btnClientCnnsPublishersTreeViewCollapseAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsPublishersTreeViewCollapseAll.Location = new System.Drawing.Point(94, 0);
            this.btnClientCnnsPublishersTreeViewCollapseAll.Name = "btnClientCnnsPublishersTreeViewCollapseAll";
            this.btnClientCnnsPublishersTreeViewCollapseAll.Size = new System.Drawing.Size(46, 36);
            this.btnClientCnnsPublishersTreeViewCollapseAll.TabIndex = 14;
            this.btnClientCnnsPublishersTreeViewCollapseAll.UseVisualStyleBackColor = true;
            this.btnClientCnnsPublishersTreeViewCollapseAll.Click += new System.EventHandler(this.btnClientCnnsPublishersTreeViewCollapseAll_Click);
            // 
            // btnClientCnnsPublishersTreeViewExpandAll
            // 
            this.btnClientCnnsPublishersTreeViewExpandAll.BackgroundImage = global::My.Resources.Resources.ExpandTree;
            this.btnClientCnnsPublishersTreeViewExpandAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsPublishersTreeViewExpandAll.Location = new System.Drawing.Point(48, 0);
            this.btnClientCnnsPublishersTreeViewExpandAll.Name = "btnClientCnnsPublishersTreeViewExpandAll";
            this.btnClientCnnsPublishersTreeViewExpandAll.Size = new System.Drawing.Size(46, 36);
            this.btnClientCnnsPublishersTreeViewExpandAll.TabIndex = 13;
            this.btnClientCnnsPublishersTreeViewExpandAll.UseVisualStyleBackColor = true;
            this.btnClientCnnsPublishersTreeViewExpandAll.Click += new System.EventHandler(this.btnClientCnnsPublishersTreeViewExpandAll_Click);
            // 
            // btnClientCnnsPublishersTreeViewZoom
            // 
            this.btnClientCnnsPublishersTreeViewZoom.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnClientCnnsPublishersTreeViewZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClientCnnsPublishersTreeViewZoom.Location = new System.Drawing.Point(2, 0);
            this.btnClientCnnsPublishersTreeViewZoom.Name = "btnClientCnnsPublishersTreeViewZoom";
            this.btnClientCnnsPublishersTreeViewZoom.Size = new System.Drawing.Size(46, 36);
            this.btnClientCnnsPublishersTreeViewZoom.TabIndex = 12;
            this.btnClientCnnsPublishersTreeViewZoom.UseVisualStyleBackColor = true;
            this.btnClientCnnsPublishersTreeViewZoom.Click += new System.EventHandler(this.btnClientCnnsPublishersTreeViewZoom_Click);
            // 
            // tvwPublisherClients
            // 
            this.tvwPublisherClients.BackColor = System.Drawing.Color.White;
            this.tvwPublisherClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwPublisherClients.ImageIndex = 0;
            this.tvwPublisherClients.ImageList = this.imglstPublisherClientConnectionsRegistry;
            this.tvwPublisherClients.Location = new System.Drawing.Point(0, 0);
            this.tvwPublisherClients.Name = "tvwPublisherClients";
            this.tvwPublisherClients.SelectedImageIndex = 0;
            this.tvwPublisherClients.Size = new System.Drawing.Size(902, 130);
            this.tvwPublisherClients.TabIndex = 15;
            this.tvwPublisherClients.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwPublisherClients_AfterSelect);
            // 
            // ElGroupBox8
            // 
            this.ElGroupBox8.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox8.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox8.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox8.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox8.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox8.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox8.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox8.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox8.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox8.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox8.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox8.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox8.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox8.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox8.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox8.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox8.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox8.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox8.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox8.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox8.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox8.CaptionStyle.TextStyle.Text = "Publications Posted";
            this.ElGroupBox8.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox8.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox8.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox8.Controls.Add(this.SplitContainer7);
            this.ElGroupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElGroupBox8.Location = new System.Drawing.Point(0, 0);
            this.ElGroupBox8.Name = "ElGroupBox8";
            this.ElGroupBox8.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox8.Size = new System.Drawing.Size(902, 204);
            this.ElGroupBox8.TabIndex = 19;
            this.ElGroupBox8.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer7
            // 
            this.SplitContainer7.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer7.Location = new System.Drawing.Point(4, 23);
            this.SplitContainer7.Name = "SplitContainer7";
            // 
            // SplitContainer7.Panel1
            // 
            this.SplitContainer7.Panel1.Controls.Add(this.ElPanel19);
            // 
            // SplitContainer7.Panel2
            // 
            this.SplitContainer7.Panel2.Controls.Add(this.ElPanel18);
            this.SplitContainer7.Size = new System.Drawing.Size(894, 178);
            this.SplitContainer7.SplitterDistance = 601;
            this.SplitContainer7.TabIndex = 4;
            // 
            // ElPanel19
            // 
            this.ElPanel19.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel19.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel19.Controls.Add(this.SplitContainer8);
            this.ElPanel19.Controls.Add(this.ElButton10);
            this.ElPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel19.Location = new System.Drawing.Point(0, 0);
            this.ElPanel19.Name = "ElPanel19";
            this.ElPanel19.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel19.Size = new System.Drawing.Size(597, 174);
            this.ElPanel19.TabIndex = 17;
            this.ElPanel19.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer8
            // 
            this.SplitContainer8.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer8.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer8.IsSplitterFixed = true;
            this.SplitContainer8.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer8.Name = "SplitContainer8";
            this.SplitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer8.Panel1
            // 
            this.SplitContainer8.Panel1.Controls.Add(this.SplitContainer57);
            // 
            // SplitContainer8.Panel2
            // 
            this.SplitContainer8.Panel2.Controls.Add(this.lsvPublisherClientsViewByHostPostedPublications);
            this.SplitContainer8.Size = new System.Drawing.Size(597, 174);
            this.SplitContainer8.SplitterDistance = 35;
            this.SplitContainer8.TabIndex = 5;
            // 
            // SplitContainer57
            // 
            this.SplitContainer57.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer57.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer57.IsSplitterFixed = true;
            this.SplitContainer57.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer57.Name = "SplitContainer57";
            // 
            // SplitContainer57.Panel1
            // 
            this.SplitContainer57.Panel1.Controls.Add(this.ElLabel1);
            // 
            // SplitContainer57.Panel2
            // 
            this.SplitContainer57.Panel2.Controls.Add(this.Button1);
            this.SplitContainer57.Size = new System.Drawing.Size(597, 35);
            this.SplitContainer57.SplitterDistance = 542;
            this.SplitContainer57.TabIndex = 0;
            // 
            // ElLabel1
            // 
            this.ElLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle8.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle8.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel1.FlashStyle = paintStyle8;
            this.ElLabel1.ForegroundImageStyle.Image = global::My.Resources.Resources.ListOfPublications;
            this.ElLabel1.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ElLabel1.ForegroundImageStyle.ImageSize = new System.Drawing.Size(25, 25);
            this.ElLabel1.Location = new System.Drawing.Point(0, 0);
            this.ElLabel1.Name = "ElLabel1";
            this.ElLabel1.Size = new System.Drawing.Size(542, 35);
            this.ElLabel1.TabIndex = 5;
            this.ElLabel1.TabStop = false;
            this.ElLabel1.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel1.TextStyle.Text = "Publications List";
            this.ElLabel1.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button1
            // 
            this.Button1.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button1.Location = new System.Drawing.Point(0, 0);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(51, 35);
            this.Button1.TabIndex = 5;
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lsvPublisherClientsViewByHostPostedPublications
            // 
            this.lsvPublisherClientsViewByHostPostedPublications.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublisherClientsViewByHostPostedPublications.BackColor = System.Drawing.Color.White;
            this.lsvPublisherClientsViewByHostPostedPublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublisherClientsViewByHostPostedPublications.FullRowSelect = true;
            this.lsvPublisherClientsViewByHostPostedPublications.GridLines = true;
            this.lsvPublisherClientsViewByHostPostedPublications.Location = new System.Drawing.Point(0, 0);
            this.lsvPublisherClientsViewByHostPostedPublications.MultiSelect = false;
            this.lsvPublisherClientsViewByHostPostedPublications.Name = "lsvPublisherClientsViewByHostPostedPublications";
            this.lsvPublisherClientsViewByHostPostedPublications.Size = new System.Drawing.Size(597, 135);
            this.lsvPublisherClientsViewByHostPostedPublications.SmallImageList = this.imgLstClientPublicatiosRegistry;
            this.lsvPublisherClientsViewByHostPostedPublications.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublisherClientsViewByHostPostedPublications.TabIndex = 2;
            this.lsvPublisherClientsViewByHostPostedPublications.UseCompatibleStateImageBehavior = false;
            this.lsvPublisherClientsViewByHostPostedPublications.SelectedIndexChanged += new System.EventHandler(this.lsvPublisherClientsViewByHostPostedPublications_SelectedIndexChanged);
            // 
            // ElButton10
            // 
            this.ElButton10.BorderStyle.EdgeRadius = 7;
            this.ElButton10.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton10.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton10.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton10.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton10.Location = new System.Drawing.Point(619, 583);
            this.ElButton10.Name = "ElButton10";
            this.ElButton10.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton10.Size = new System.Drawing.Size(128, 34);
            this.ElButton10.TabIndex = 3;
            this.ElButton10.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton10.TextStyle.Text = "Update Views";
            // 
            // ElPanel18
            // 
            this.ElPanel18.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel18.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel18.Controls.Add(this.SplitContainer9);
            this.ElPanel18.Controls.Add(this.ElButton9);
            this.ElPanel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel18.Location = new System.Drawing.Point(0, 0);
            this.ElPanel18.Name = "ElPanel18";
            this.ElPanel18.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel18.Size = new System.Drawing.Size(285, 174);
            this.ElPanel18.TabIndex = 16;
            this.ElPanel18.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer9
            // 
            this.SplitContainer9.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer9.IsSplitterFixed = true;
            this.SplitContainer9.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer9.Name = "SplitContainer9";
            this.SplitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer9.Panel1
            // 
            this.SplitContainer9.Panel1.Controls.Add(this.SplitContainer58);
            // 
            // SplitContainer9.Panel2
            // 
            this.SplitContainer9.Panel2.Controls.Add(this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList);
            this.SplitContainer9.Size = new System.Drawing.Size(285, 174);
            this.SplitContainer9.SplitterDistance = 36;
            this.SplitContainer9.TabIndex = 5;
            // 
            // SplitContainer58
            // 
            this.SplitContainer58.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer58.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer58.IsSplitterFixed = true;
            this.SplitContainer58.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer58.Name = "SplitContainer58";
            // 
            // SplitContainer58.Panel1
            // 
            this.SplitContainer58.Panel1.Controls.Add(this.ElLabel2);
            // 
            // SplitContainer58.Panel2
            // 
            this.SplitContainer58.Panel2.Controls.Add(this.Button2);
            this.SplitContainer58.Size = new System.Drawing.Size(285, 36);
            this.SplitContainer58.SplitterDistance = 233;
            this.SplitContainer58.TabIndex = 0;
            // 
            // ElLabel2
            // 
            this.ElLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle9.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle9.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel2.FlashStyle = paintStyle9;
            this.ElLabel2.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel2.Location = new System.Drawing.Point(0, 0);
            this.ElLabel2.Name = "ElLabel2";
            this.ElLabel2.Size = new System.Drawing.Size(233, 36);
            this.ElLabel2.TabIndex = 6;
            this.ElLabel2.TabStop = false;
            this.ElLabel2.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel2.TextStyle.Text = "Publication Variables";
            this.ElLabel2.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button2
            // 
            this.Button2.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button2.Location = new System.Drawing.Point(0, 0);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(48, 36);
            this.Button2.TabIndex = 6;
            this.Button2.UseVisualStyleBackColor = true;
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // lsvPublisherClientsViewByHostPostedPublicationsVariablesList
            // 
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.BackColor = System.Drawing.Color.White;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.FullRowSelect = true;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.GridLines = true;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Location = new System.Drawing.Point(0, 0);
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.MultiSelect = false;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Name = "lsvPublisherClientsViewByHostPostedPublicationsVariablesList";
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Size = new System.Drawing.Size(285, 134);
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.TabIndex = 3;
            this.lsvPublisherClientsViewByHostPostedPublicationsVariablesList.UseCompatibleStateImageBehavior = false;
            // 
            // ElButton9
            // 
            this.ElButton9.BorderStyle.EdgeRadius = 7;
            this.ElButton9.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.ElButton9.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElButton9.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElButton9.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElButton9.Location = new System.Drawing.Point(619, 583);
            this.ElButton9.Name = "ElButton9";
            this.ElButton9.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.ElButton9.Size = new System.Drawing.Size(128, 34);
            this.ElButton9.TabIndex = 3;
            this.ElButton9.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElButton9.TextStyle.Text = "Update Views";
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.ElPanel11);
            this.TabPage1.Location = new System.Drawing.Point(4, 28);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(936, 456);
            this.TabPage1.TabIndex = 2;
            this.TabPage1.Text = "Publications";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // ElPanel11
            // 
            this.ElPanel11.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel11.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel11.Controls.Add(this.tabPublicationsStatus);
            this.ElPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel11.Location = new System.Drawing.Point(3, 3);
            this.ElPanel11.Name = "ElPanel11";
            this.ElPanel11.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel11.Size = new System.Drawing.Size(930, 450);
            this.ElPanel11.TabIndex = 15;
            this.ElPanel11.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // tabPublicationsStatus
            // 
            this.tabPublicationsStatus.Controls.Add(this.TabPage9);
            this.tabPublicationsStatus.Controls.Add(this.TabPage10);
            this.tabPublicationsStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPublicationsStatus.ImageList = this.imgViewsImagesList;
            this.tabPublicationsStatus.Location = new System.Drawing.Point(0, 0);
            this.tabPublicationsStatus.Name = "tabPublicationsStatus";
            this.tabPublicationsStatus.SelectedIndex = 0;
            this.tabPublicationsStatus.Size = new System.Drawing.Size(930, 450);
            this.tabPublicationsStatus.TabIndex = 3;
            // 
            // TabPage9
            // 
            this.TabPage9.Controls.Add(this.ElPanel9);
            this.TabPage9.ImageIndex = 0;
            this.TabPage9.Location = new System.Drawing.Point(4, 29);
            this.TabPage9.Name = "TabPage9";
            this.TabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage9.Size = new System.Drawing.Size(922, 417);
            this.TabPage9.TabIndex = 0;
            this.TabPage9.Text = "Publications Resume";
            this.TabPage9.UseVisualStyleBackColor = true;
            // 
            // ElPanel9
            // 
            this.ElPanel9.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel9.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel9.Controls.Add(this.SplitContainer13);
            this.ElPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel9.Location = new System.Drawing.Point(3, 3);
            this.ElPanel9.Name = "ElPanel9";
            this.ElPanel9.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel9.Size = new System.Drawing.Size(916, 411);
            this.ElPanel9.TabIndex = 13;
            this.ElPanel9.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer13
            // 
            this.SplitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer13.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer13.Name = "SplitContainer13";
            this.SplitContainer13.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer13.Panel1
            // 
            this.SplitContainer13.Panel1.Controls.Add(this.spltrPublicationsREsumeMainSpliter);
            // 
            // SplitContainer13.Panel2
            // 
            this.SplitContainer13.Panel2.Controls.Add(this.SplitContainer14);
            this.SplitContainer13.Size = new System.Drawing.Size(916, 411);
            this.SplitContainer13.SplitterDistance = 198;
            this.SplitContainer13.TabIndex = 4;
            // 
            // spltrPublicationsREsumeMainSpliter
            // 
            this.spltrPublicationsREsumeMainSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsREsumeMainSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublicationsREsumeMainSpliter.IsSplitterFixed = true;
            this.spltrPublicationsREsumeMainSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsREsumeMainSpliter.Name = "spltrPublicationsREsumeMainSpliter";
            this.spltrPublicationsREsumeMainSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublicationsREsumeMainSpliter.Panel1
            // 
            this.spltrPublicationsREsumeMainSpliter.Panel1.Controls.Add(this.spltrPublicationsREsumeHeaderSplitter);
            // 
            // spltrPublicationsREsumeMainSpliter.Panel2
            // 
            this.spltrPublicationsREsumeMainSpliter.Panel2.Controls.Add(this.lstAvailablePublications);
            this.spltrPublicationsREsumeMainSpliter.Size = new System.Drawing.Size(916, 198);
            this.spltrPublicationsREsumeMainSpliter.SplitterDistance = 34;
            this.spltrPublicationsREsumeMainSpliter.TabIndex = 3;
            // 
            // spltrPublicationsREsumeHeaderSplitter
            // 
            this.spltrPublicationsREsumeHeaderSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsREsumeHeaderSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrPublicationsREsumeHeaderSplitter.IsSplitterFixed = true;
            this.spltrPublicationsREsumeHeaderSplitter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsREsumeHeaderSplitter.Name = "spltrPublicationsREsumeHeaderSplitter";
            // 
            // spltrPublicationsREsumeHeaderSplitter.Panel1
            // 
            this.spltrPublicationsREsumeHeaderSplitter.Panel1.Controls.Add(this.ElLabel22);
            // 
            // spltrPublicationsREsumeHeaderSplitter.Panel2
            // 
            this.spltrPublicationsREsumeHeaderSplitter.Panel2.Controls.Add(this.Button7);
            this.spltrPublicationsREsumeHeaderSplitter.Panel2.Controls.Add(this.Button8);
            this.spltrPublicationsREsumeHeaderSplitter.Panel2.Controls.Add(this.btnZoomAvailablePublications);
            this.spltrPublicationsREsumeHeaderSplitter.Size = new System.Drawing.Size(916, 34);
            this.spltrPublicationsREsumeHeaderSplitter.SplitterDistance = 776;
            this.spltrPublicationsREsumeHeaderSplitter.TabIndex = 0;
            // 
            // ElLabel22
            // 
            this.ElLabel22.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle10.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle10.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel22.FlashStyle = paintStyle10;
            this.ElLabel22.ForegroundImageStyle.Image = global::My.Resources.Resources._NEWS1A;
            this.ElLabel22.Location = new System.Drawing.Point(0, 0);
            this.ElLabel22.Name = "ElLabel22";
            this.ElLabel22.Size = new System.Drawing.Size(776, 34);
            this.ElLabel22.TabIndex = 10;
            this.ElLabel22.TabStop = false;
            this.ElLabel22.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel22.TextStyle.Text = "Available Publications";
            this.ElLabel22.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button7
            // 
            this.Button7.BackgroundImage = global::My.Resources.Resources.reload;
            this.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button7.Location = new System.Drawing.Point(90, -1);
            this.Button7.Name = "Button7";
            this.Button7.Size = new System.Drawing.Size(46, 36);
            this.Button7.TabIndex = 14;
            this.Button7.UseVisualStyleBackColor = true;
            this.Button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // Button8
            // 
            this.Button8.BackgroundImage = global::My.Resources.Resources.ColumnsAdjustment;
            this.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button8.Location = new System.Drawing.Point(44, -1);
            this.Button8.Name = "Button8";
            this.Button8.Size = new System.Drawing.Size(46, 36);
            this.Button8.TabIndex = 13;
            this.Button8.UseVisualStyleBackColor = true;
            this.Button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // btnZoomAvailablePublications
            // 
            this.btnZoomAvailablePublications.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomAvailablePublications.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomAvailablePublications.Location = new System.Drawing.Point(0, 0);
            this.btnZoomAvailablePublications.Name = "btnZoomAvailablePublications";
            this.btnZoomAvailablePublications.Size = new System.Drawing.Size(44, 34);
            this.btnZoomAvailablePublications.TabIndex = 4;
            this.btnZoomAvailablePublications.UseVisualStyleBackColor = true;
            this.btnZoomAvailablePublications.Click += new System.EventHandler(this.btnZoomAvailablePublications_Click);
            // 
            // lstAvailablePublications
            // 
            this.lstAvailablePublications.BackColor = System.Drawing.Color.LemonChiffon;
            this.lstAvailablePublications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAvailablePublications.LargeImageList = this.imgLstPublicationsREgistry;
            this.lstAvailablePublications.Location = new System.Drawing.Point(0, 0);
            this.lstAvailablePublications.Name = "lstAvailablePublications";
            this.lstAvailablePublications.Size = new System.Drawing.Size(916, 160);
            this.lstAvailablePublications.SmallImageList = this.imgLstPublicationsREgistry;
            this.lstAvailablePublications.StateImageList = this.imgLstPublicationsREgistry;
            this.lstAvailablePublications.TabIndex = 2;
            this.lstAvailablePublications.UseCompatibleStateImageBehavior = false;
            this.lstAvailablePublications.SelectedIndexChanged += new System.EventHandler(this.lstAvailablePublications_SelectedIndexChanged);
            this.lstAvailablePublications.DoubleClick += new System.EventHandler(this.lstAvailablePublications_DoubleClick);
            // 
            // imgLstPublicationsREgistry
            // 
            this.imgLstPublicationsREgistry.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstPublicationsREgistry.ImageStream")));
            this.imgLstPublicationsREgistry.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstPublicationsREgistry.Images.SetKeyName(0, "Group.ICO");
            this.imgLstPublicationsREgistry.Images.SetKeyName(1, "PublicationNodeIcon.png");
            this.imgLstPublicationsREgistry.Images.SetKeyName(2, "CreationDatetimeNodeIcon.gif");
            this.imgLstPublicationsREgistry.Images.SetKeyName(3, "publicationOwnerNodeIcon.png");
            this.imgLstPublicationsREgistry.Images.SetKeyName(4, "publicationOwnerHostNodeIcon.ico");
            this.imgLstPublicationsREgistry.Images.SetKeyName(5, "ApplicationNodeIcon.ico");
            this.imgLstPublicationsREgistry.Images.SetKeyName(6, "VariablesCountNodeIcon.ico");
            this.imgLstPublicationsREgistry.Images.SetKeyName(7, "socketsServerOPortNodeIcon.gif");
            this.imgLstPublicationsREgistry.Images.SetKeyName(8, "multicastIPNodeIcon.ICO");
            this.imgLstPublicationsREgistry.Images.SetKeyName(9, "MulticastPortNodeIcon.ICO");
            this.imgLstPublicationsREgistry.Images.SetKeyName(10, "SubscriptorsCountNodeIcon.png");
            // 
            // SplitContainer14
            // 
            this.SplitContainer14.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer14.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer14.Name = "SplitContainer14";
            // 
            // SplitContainer14.Panel1
            // 
            this.SplitContainer14.Panel1.Controls.Add(this.ElPanel12);
            // 
            // SplitContainer14.Panel2
            // 
            this.SplitContainer14.Panel2.Controls.Add(this.ElPanel22);
            this.SplitContainer14.Size = new System.Drawing.Size(916, 209);
            this.SplitContainer14.SplitterDistance = 300;
            this.SplitContainer14.TabIndex = 0;
            // 
            // ElPanel12
            // 
            this.ElPanel12.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel12.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel12.Controls.Add(this.spltCtnrPublicationVariablesHEaderResumeView);
            this.ElPanel12.Controls.Add(this.ElGroupBox9);
            this.ElPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel12.Location = new System.Drawing.Point(0, 0);
            this.ElPanel12.Name = "ElPanel12";
            this.ElPanel12.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel12.Size = new System.Drawing.Size(296, 205);
            this.ElPanel12.TabIndex = 14;
            this.ElPanel12.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltCtnrPublicationVariablesHEaderResumeView
            // 
            this.spltCtnrPublicationVariablesHEaderResumeView.BackColor = System.Drawing.Color.Transparent;
            this.spltCtnrPublicationVariablesHEaderResumeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCtnrPublicationVariablesHEaderResumeView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCtnrPublicationVariablesHEaderResumeView.IsSplitterFixed = true;
            this.spltCtnrPublicationVariablesHEaderResumeView.Location = new System.Drawing.Point(0, 0);
            this.spltCtnrPublicationVariablesHEaderResumeView.Name = "spltCtnrPublicationVariablesHEaderResumeView";
            this.spltCtnrPublicationVariablesHEaderResumeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltCtnrPublicationVariablesHEaderResumeView.Panel1
            // 
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel1.Controls.Add(this.SplitContainer17);
            // 
            // spltCtnrPublicationVariablesHEaderResumeView.Panel2
            // 
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel2.Controls.Add(this.lsvPublicationREsumeTableViewVariablesList);
            this.spltCtnrPublicationVariablesHEaderResumeView.Size = new System.Drawing.Size(296, 205);
            this.spltCtnrPublicationVariablesHEaderResumeView.SplitterDistance = 35;
            this.spltCtnrPublicationVariablesHEaderResumeView.TabIndex = 18;
            // 
            // SplitContainer17
            // 
            this.SplitContainer17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer17.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer17.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer17.Name = "SplitContainer17";
            // 
            // SplitContainer17.Panel1
            // 
            this.SplitContainer17.Panel1.Controls.Add(this.ElLabel20);
            // 
            // SplitContainer17.Panel2
            // 
            this.SplitContainer17.Panel2.Controls.Add(this.btnZoomPubsVariablesListView);
            this.SplitContainer17.Size = new System.Drawing.Size(296, 35);
            this.SplitContainer17.SplitterDistance = 248;
            this.SplitContainer17.TabIndex = 0;
            // 
            // ElLabel20
            // 
            this.ElLabel20.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle11.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle11.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel20.FlashStyle = paintStyle11;
            this.ElLabel20.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel20.Location = new System.Drawing.Point(0, 0);
            this.ElLabel20.Name = "ElLabel20";
            this.ElLabel20.Size = new System.Drawing.Size(248, 35);
            this.ElLabel20.TabIndex = 9;
            this.ElLabel20.TabStop = false;
            this.ElLabel20.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel20.TextStyle.Text = "Publication Variables";
            this.ElLabel20.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomPubsVariablesListView
            // 
            this.btnZoomPubsVariablesListView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsVariablesListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsVariablesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPubsVariablesListView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsVariablesListView.Name = "btnZoomPubsVariablesListView";
            this.btnZoomPubsVariablesListView.Size = new System.Drawing.Size(44, 35);
            this.btnZoomPubsVariablesListView.TabIndex = 0;
            this.btnZoomPubsVariablesListView.UseVisualStyleBackColor = true;
            this.btnZoomPubsVariablesListView.Click += new System.EventHandler(this.btnZoomPubsVariablesListView_Click);
            // 
            // lsvPublicationREsumeTableViewVariablesList
            // 
            this.lsvPublicationREsumeTableViewVariablesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublicationREsumeTableViewVariablesList.BackColor = System.Drawing.Color.White;
            this.lsvPublicationREsumeTableViewVariablesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublicationREsumeTableViewVariablesList.FullRowSelect = true;
            this.lsvPublicationREsumeTableViewVariablesList.GridLines = true;
            this.lsvPublicationREsumeTableViewVariablesList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvPublicationREsumeTableViewVariablesList.HideSelection = false;
            this.lsvPublicationREsumeTableViewVariablesList.Location = new System.Drawing.Point(0, 0);
            this.lsvPublicationREsumeTableViewVariablesList.MultiSelect = false;
            this.lsvPublicationREsumeTableViewVariablesList.Name = "lsvPublicationREsumeTableViewVariablesList";
            this.lsvPublicationREsumeTableViewVariablesList.Size = new System.Drawing.Size(296, 166);
            this.lsvPublicationREsumeTableViewVariablesList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublicationREsumeTableViewVariablesList.TabIndex = 5;
            this.lsvPublicationREsumeTableViewVariablesList.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox9
            // 
            this.ElGroupBox9.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox9.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox9.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox9.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox9.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox9.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox9.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox9.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox9.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox9.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox9.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox9.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox9.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox9.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox9.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox9.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox9.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox9.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox9.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox9.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox9.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox9.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox9.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox9.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox9.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox9.Controls.Add(this.ElRadioButton1);
            this.ElGroupBox9.Controls.Add(this.ElRadioButton2);
            this.ElGroupBox9.Controls.Add(this.ElRadioButton3);
            this.ElGroupBox9.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox9.Name = "ElGroupBox9";
            this.ElGroupBox9.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox9.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox9.TabIndex = 16;
            this.ElGroupBox9.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton1
            // 
            this.ElRadioButton1.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton1.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton1.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton1.Name = "ElRadioButton1";
            this.ElRadioButton1.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton1.TabIndex = 20;
            this.ElRadioButton1.TabStop = false;
            this.ElRadioButton1.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton1.Value = false;
            // 
            // ElRadioButton2
            // 
            this.ElRadioButton2.Checked = true;
            this.ElRadioButton2.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton2.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton2.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton2.Name = "ElRadioButton2";
            this.ElRadioButton2.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton2.TabIndex = 18;
            this.ElRadioButton2.TextStyle.Text = "View By publication Name";
            this.ElRadioButton2.Value = true;
            // 
            // ElRadioButton3
            // 
            this.ElRadioButton3.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton3.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton3.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton3.Name = "ElRadioButton3";
            this.ElRadioButton3.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton3.TabIndex = 17;
            this.ElRadioButton3.TabStop = false;
            this.ElRadioButton3.TextStyle.Text = "View By Publisher";
            this.ElRadioButton3.Value = false;
            // 
            // ElPanel22
            // 
            this.ElPanel22.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel22.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel22.Controls.Add(this.SplitContainer15);
            this.ElPanel22.Controls.Add(this.ElGroupBox10);
            this.ElPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel22.Location = new System.Drawing.Point(0, 0);
            this.ElPanel22.Name = "ElPanel22";
            this.ElPanel22.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel22.Size = new System.Drawing.Size(608, 205);
            this.ElPanel22.TabIndex = 14;
            this.ElPanel22.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer15
            // 
            this.SplitContainer15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer15.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer15.Name = "SplitContainer15";
            // 
            // SplitContainer15.Panel1
            // 
            this.SplitContainer15.Panel1.Controls.Add(this.ElPanel23);
            // 
            // SplitContainer15.Panel2
            // 
            this.SplitContainer15.Panel2.Controls.Add(this.ElPanel24);
            this.SplitContainer15.Size = new System.Drawing.Size(608, 205);
            this.SplitContainer15.SplitterDistance = 299;
            this.SplitContainer15.TabIndex = 18;
            // 
            // ElPanel23
            // 
            this.ElPanel23.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel23.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel23.Controls.Add(this.spltCntrConnectedClientsResumeView);
            this.ElPanel23.Controls.Add(this.ElGroupBox11);
            this.ElPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel23.Location = new System.Drawing.Point(0, 0);
            this.ElPanel23.Name = "ElPanel23";
            this.ElPanel23.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel23.Size = new System.Drawing.Size(295, 201);
            this.ElPanel23.TabIndex = 14;
            this.ElPanel23.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltCntrConnectedClientsResumeView
            // 
            this.spltCntrConnectedClientsResumeView.BackColor = System.Drawing.Color.Transparent;
            this.spltCntrConnectedClientsResumeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCntrConnectedClientsResumeView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCntrConnectedClientsResumeView.IsSplitterFixed = true;
            this.spltCntrConnectedClientsResumeView.Location = new System.Drawing.Point(0, 0);
            this.spltCntrConnectedClientsResumeView.Name = "spltCntrConnectedClientsResumeView";
            this.spltCntrConnectedClientsResumeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltCntrConnectedClientsResumeView.Panel1
            // 
            this.spltCntrConnectedClientsResumeView.Panel1.Controls.Add(this.SplitContainer49);
            // 
            // spltCntrConnectedClientsResumeView.Panel2
            // 
            this.spltCntrConnectedClientsResumeView.Panel2.Controls.Add(this.lsvPublicationsREsumeConnectedCLientsList);
            this.spltCntrConnectedClientsResumeView.Size = new System.Drawing.Size(295, 201);
            this.spltCntrConnectedClientsResumeView.SplitterDistance = 34;
            this.spltCntrConnectedClientsResumeView.TabIndex = 19;
            // 
            // SplitContainer49
            // 
            this.SplitContainer49.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer49.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer49.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer49.Name = "SplitContainer49";
            // 
            // SplitContainer49.Panel1
            // 
            this.SplitContainer49.Panel1.Controls.Add(this.ElLabel6);
            // 
            // SplitContainer49.Panel2
            // 
            this.SplitContainer49.Panel2.Controls.Add(this.btnZoomPubsClientsListView);
            this.SplitContainer49.Size = new System.Drawing.Size(295, 34);
            this.SplitContainer49.SplitterDistance = 247;
            this.SplitContainer49.TabIndex = 10;
            // 
            // ElLabel6
            // 
            this.ElLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle12.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle12.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel6.FlashStyle = paintStyle12;
            this.ElLabel6.ForegroundImageStyle.Image = global::My.Resources.Resources.usersGroup;
            this.ElLabel6.Location = new System.Drawing.Point(0, 0);
            this.ElLabel6.Name = "ElLabel6";
            this.ElLabel6.Size = new System.Drawing.Size(247, 34);
            this.ElLabel6.TabIndex = 7;
            this.ElLabel6.TabStop = false;
            this.ElLabel6.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel6.TextStyle.Text = "Connected Clients";
            this.ElLabel6.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomPubsClientsListView
            // 
            this.btnZoomPubsClientsListView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsClientsListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsClientsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPubsClientsListView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsClientsListView.Name = "btnZoomPubsClientsListView";
            this.btnZoomPubsClientsListView.Size = new System.Drawing.Size(44, 34);
            this.btnZoomPubsClientsListView.TabIndex = 0;
            this.btnZoomPubsClientsListView.UseVisualStyleBackColor = true;
            this.btnZoomPubsClientsListView.Click += new System.EventHandler(this.btnZoomPubsClientsListView_Click);
            // 
            // lsvPublicationsREsumeConnectedCLientsList
            // 
            this.lsvPublicationsREsumeConnectedCLientsList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublicationsREsumeConnectedCLientsList.BackColor = System.Drawing.Color.White;
            this.lsvPublicationsREsumeConnectedCLientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublicationsREsumeConnectedCLientsList.FullRowSelect = true;
            this.lsvPublicationsREsumeConnectedCLientsList.GridLines = true;
            this.lsvPublicationsREsumeConnectedCLientsList.HideSelection = false;
            this.lsvPublicationsREsumeConnectedCLientsList.Location = new System.Drawing.Point(0, 0);
            this.lsvPublicationsREsumeConnectedCLientsList.MultiSelect = false;
            this.lsvPublicationsREsumeConnectedCLientsList.Name = "lsvPublicationsREsumeConnectedCLientsList";
            this.lsvPublicationsREsumeConnectedCLientsList.Size = new System.Drawing.Size(295, 163);
            this.lsvPublicationsREsumeConnectedCLientsList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublicationsREsumeConnectedCLientsList.TabIndex = 3;
            this.lsvPublicationsREsumeConnectedCLientsList.UseCompatibleStateImageBehavior = false;
            this.lsvPublicationsREsumeConnectedCLientsList.DoubleClick += new System.EventHandler(this.lsvPublicationsREsumeConnectedCLientsList_DoubleClick);
            // 
            // ElGroupBox11
            // 
            this.ElGroupBox11.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox11.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox11.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox11.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox11.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox11.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox11.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox11.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox11.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox11.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox11.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox11.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox11.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox11.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox11.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox11.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox11.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox11.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox11.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox11.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox11.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox11.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox11.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox11.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox11.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox11.Controls.Add(this.ElRadioButton10);
            this.ElGroupBox11.Controls.Add(this.ElRadioButton11);
            this.ElGroupBox11.Controls.Add(this.ElRadioButton12);
            this.ElGroupBox11.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox11.Name = "ElGroupBox11";
            this.ElGroupBox11.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox11.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox11.TabIndex = 16;
            this.ElGroupBox11.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton10
            // 
            this.ElRadioButton10.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton10.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton10.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton10.Name = "ElRadioButton10";
            this.ElRadioButton10.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton10.TabIndex = 20;
            this.ElRadioButton10.TabStop = false;
            this.ElRadioButton10.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton10.Value = false;
            // 
            // ElRadioButton11
            // 
            this.ElRadioButton11.Checked = true;
            this.ElRadioButton11.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton11.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton11.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton11.Name = "ElRadioButton11";
            this.ElRadioButton11.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton11.TabIndex = 18;
            this.ElRadioButton11.TextStyle.Text = "View By publication Name";
            this.ElRadioButton11.Value = true;
            // 
            // ElRadioButton12
            // 
            this.ElRadioButton12.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton12.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton12.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton12.Name = "ElRadioButton12";
            this.ElRadioButton12.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton12.TabIndex = 17;
            this.ElRadioButton12.TabStop = false;
            this.ElRadioButton12.TextStyle.Text = "View By Publisher";
            this.ElRadioButton12.Value = false;
            // 
            // ElPanel24
            // 
            this.ElPanel24.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel24.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel24.Controls.Add(this.spltrPublicationsTableStatsMainSpliter);
            this.ElPanel24.Controls.Add(this.ElGroupBox12);
            this.ElPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel24.Location = new System.Drawing.Point(0, 0);
            this.ElPanel24.Name = "ElPanel24";
            this.ElPanel24.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel24.Size = new System.Drawing.Size(301, 201);
            this.ElPanel24.TabIndex = 14;
            this.ElPanel24.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltrPublicationsTableStatsMainSpliter
            // 
            this.spltrPublicationsTableStatsMainSpliter.BackColor = System.Drawing.Color.Transparent;
            this.spltrPublicationsTableStatsMainSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsTableStatsMainSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublicationsTableStatsMainSpliter.IsSplitterFixed = true;
            this.spltrPublicationsTableStatsMainSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsTableStatsMainSpliter.Name = "spltrPublicationsTableStatsMainSpliter";
            this.spltrPublicationsTableStatsMainSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublicationsTableStatsMainSpliter.Panel1
            // 
            this.spltrPublicationsTableStatsMainSpliter.Panel1.Controls.Add(this.splitCtnrStatisticsHeader);
            // 
            // spltrPublicationsTableStatsMainSpliter.Panel2
            // 
            this.spltrPublicationsTableStatsMainSpliter.Panel2.Controls.Add(this.dgrPublicationDataUpdateStatisticsListView);
            this.spltrPublicationsTableStatsMainSpliter.Size = new System.Drawing.Size(301, 201);
            this.spltrPublicationsTableStatsMainSpliter.SplitterDistance = 35;
            this.spltrPublicationsTableStatsMainSpliter.TabIndex = 19;
            // 
            // splitCtnrStatisticsHeader
            // 
            this.splitCtnrStatisticsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCtnrStatisticsHeader.IsSplitterFixed = true;
            this.splitCtnrStatisticsHeader.Location = new System.Drawing.Point(0, 0);
            this.splitCtnrStatisticsHeader.Name = "splitCtnrStatisticsHeader";
            // 
            // splitCtnrStatisticsHeader.Panel1
            // 
            this.splitCtnrStatisticsHeader.Panel1.Controls.Add(this.ElLabel7);
            // 
            // splitCtnrStatisticsHeader.Panel2
            // 
            this.splitCtnrStatisticsHeader.Panel2.Controls.Add(this.SplitContainer50);
            this.splitCtnrStatisticsHeader.Size = new System.Drawing.Size(301, 35);
            this.splitCtnrStatisticsHeader.SplitterDistance = 118;
            this.splitCtnrStatisticsHeader.TabIndex = 0;
            // 
            // ElLabel7
            // 
            this.ElLabel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.ElLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle13.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle13.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel7.FlashStyle = paintStyle13;
            this.ElLabel7.ForegroundImageStyle.Image = global::My.Resources.Resources.Statistics;
            this.ElLabel7.Location = new System.Drawing.Point(0, 0);
            this.ElLabel7.Name = "ElLabel7";
            this.ElLabel7.Size = new System.Drawing.Size(118, 35);
            this.ElLabel7.TabIndex = 7;
            this.ElLabel7.TabStop = false;
            this.ElLabel7.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel7.TextStyle.Text = "Statistics";
            this.ElLabel7.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplitContainer50
            // 
            this.SplitContainer50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer50.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer50.IsSplitterFixed = true;
            this.SplitContainer50.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer50.Name = "SplitContainer50";
            // 
            // SplitContainer50.Panel1
            // 
            this.SplitContainer50.Panel1.Controls.Add(this.btnZoomPubsStatisticsListView);
            // 
            // SplitContainer50.Panel2
            // 
            this.SplitContainer50.Panel2.Controls.Add(this.SplitContainer2);
            this.SplitContainer50.Size = new System.Drawing.Size(179, 35);
            this.SplitContainer50.SplitterDistance = 46;
            this.SplitContainer50.TabIndex = 0;
            // 
            // btnZoomPubsStatisticsListView
            // 
            this.btnZoomPubsStatisticsListView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsStatisticsListView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsStatisticsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPubsStatisticsListView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsStatisticsListView.Name = "btnZoomPubsStatisticsListView";
            this.btnZoomPubsStatisticsListView.Size = new System.Drawing.Size(46, 35);
            this.btnZoomPubsStatisticsListView.TabIndex = 3;
            this.btnZoomPubsStatisticsListView.UseVisualStyleBackColor = true;
            this.btnZoomPubsStatisticsListView.Click += new System.EventHandler(this.btnZoomPubsStatisticsListView_Click);
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.btnPublicationsResumtStatisticsUpdate);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.btnPublicationsResumtStatisticsReset);
            this.SplitContainer2.Size = new System.Drawing.Size(129, 35);
            this.SplitContainer2.SplitterDistance = 59;
            this.SplitContainer2.TabIndex = 0;
            // 
            // btnPublicationsResumtStatisticsUpdate
            // 
            this.btnPublicationsResumtStatisticsUpdate.BackgroundStyle.GradientEndColor = System.Drawing.Color.Lime;
            this.btnPublicationsResumtStatisticsUpdate.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPublicationsResumtStatisticsUpdate.BorderStyle.EdgeRadius = 7;
            this.btnPublicationsResumtStatisticsUpdate.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnPublicationsResumtStatisticsUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublicationsResumtStatisticsUpdate.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnPublicationsResumtStatisticsUpdate.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnPublicationsResumtStatisticsUpdate.ForegroundImageStyle.Image = global::My.Resources.Resources.reload;
            this.btnPublicationsResumtStatisticsUpdate.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublicationsResumtStatisticsUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnPublicationsResumtStatisticsUpdate.Name = "btnPublicationsResumtStatisticsUpdate";
            this.btnPublicationsResumtStatisticsUpdate.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.btnPublicationsResumtStatisticsUpdate.Size = new System.Drawing.Size(59, 35);
            this.btnPublicationsResumtStatisticsUpdate.TabIndex = 7;
            this.btnPublicationsResumtStatisticsUpdate.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicationsResumtStatisticsUpdate.TextStyle.Text = "Update";
            this.btnPublicationsResumtStatisticsUpdate.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnPublicationsResumtStatisticsUpdate.Click += new System.EventHandler(this.btnPublicationsResumtStatisticsUpdate_Click);
            // 
            // btnPublicationsResumtStatisticsReset
            // 
            this.btnPublicationsResumtStatisticsReset.BackgroundStyle.GradientEndColor = System.Drawing.Color.Lime;
            this.btnPublicationsResumtStatisticsReset.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPublicationsResumtStatisticsReset.BorderStyle.EdgeRadius = 7;
            this.btnPublicationsResumtStatisticsReset.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnPublicationsResumtStatisticsReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublicationsResumtStatisticsReset.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnPublicationsResumtStatisticsReset.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnPublicationsResumtStatisticsReset.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublicationsResumtStatisticsReset.Location = new System.Drawing.Point(0, 0);
            this.btnPublicationsResumtStatisticsReset.Name = "btnPublicationsResumtStatisticsReset";
            this.btnPublicationsResumtStatisticsReset.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.btnPublicationsResumtStatisticsReset.Size = new System.Drawing.Size(66, 35);
            this.btnPublicationsResumtStatisticsReset.TabIndex = 8;
            this.btnPublicationsResumtStatisticsReset.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicationsResumtStatisticsReset.TextStyle.Text = "Reset";
            this.btnPublicationsResumtStatisticsReset.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnPublicationsResumtStatisticsReset.Click += new System.EventHandler(this.btnPublicationsResumtStatisticsReset_Click);
            // 
            // dgrPublicationDataUpdateStatisticsListView
            // 
            this.dgrPublicationDataUpdateStatisticsListView.AllowUserToAddRows = false;
            this.dgrPublicationDataUpdateStatisticsListView.AllowUserToDeleteRows = false;
            this.dgrPublicationDataUpdateStatisticsListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPublicationDataUpdateStatisticsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrPublicationDataUpdateStatisticsListView.Location = new System.Drawing.Point(0, 0);
            this.dgrPublicationDataUpdateStatisticsListView.Name = "dgrPublicationDataUpdateStatisticsListView";
            this.dgrPublicationDataUpdateStatisticsListView.ReadOnly = true;
            this.dgrPublicationDataUpdateStatisticsListView.Size = new System.Drawing.Size(301, 162);
            this.dgrPublicationDataUpdateStatisticsListView.TabIndex = 0;
            // 
            // ElGroupBox12
            // 
            this.ElGroupBox12.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox12.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox12.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox12.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox12.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox12.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox12.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox12.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox12.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox12.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox12.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox12.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox12.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox12.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox12.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox12.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox12.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox12.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox12.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox12.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox12.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox12.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox12.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox12.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox12.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox12.Controls.Add(this.ElRadioButton13);
            this.ElGroupBox12.Controls.Add(this.ElRadioButton14);
            this.ElGroupBox12.Controls.Add(this.ElRadioButton15);
            this.ElGroupBox12.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox12.Name = "ElGroupBox12";
            this.ElGroupBox12.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox12.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox12.TabIndex = 16;
            this.ElGroupBox12.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton13
            // 
            this.ElRadioButton13.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton13.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton13.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton13.Name = "ElRadioButton13";
            this.ElRadioButton13.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton13.TabIndex = 20;
            this.ElRadioButton13.TabStop = false;
            this.ElRadioButton13.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton13.Value = false;
            // 
            // ElRadioButton14
            // 
            this.ElRadioButton14.Checked = true;
            this.ElRadioButton14.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton14.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton14.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton14.Name = "ElRadioButton14";
            this.ElRadioButton14.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton14.TabIndex = 18;
            this.ElRadioButton14.TextStyle.Text = "View By publication Name";
            this.ElRadioButton14.Value = true;
            // 
            // ElRadioButton15
            // 
            this.ElRadioButton15.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton15.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton15.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton15.Name = "ElRadioButton15";
            this.ElRadioButton15.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton15.TabIndex = 17;
            this.ElRadioButton15.TabStop = false;
            this.ElRadioButton15.TextStyle.Text = "View By Publisher";
            this.ElRadioButton15.Value = false;
            // 
            // ElGroupBox10
            // 
            this.ElGroupBox10.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox10.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox10.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox10.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox10.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox10.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox10.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox10.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox10.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox10.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox10.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox10.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox10.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox10.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox10.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox10.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox10.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox10.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox10.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox10.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox10.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox10.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox10.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox10.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox10.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox10.Controls.Add(this.ElRadioButton4);
            this.ElGroupBox10.Controls.Add(this.ElRadioButton8);
            this.ElGroupBox10.Controls.Add(this.ElRadioButton9);
            this.ElGroupBox10.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox10.Name = "ElGroupBox10";
            this.ElGroupBox10.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox10.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox10.TabIndex = 16;
            this.ElGroupBox10.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton4
            // 
            this.ElRadioButton4.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton4.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton4.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton4.Name = "ElRadioButton4";
            this.ElRadioButton4.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton4.TabIndex = 20;
            this.ElRadioButton4.TabStop = false;
            this.ElRadioButton4.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton4.Value = false;
            // 
            // ElRadioButton8
            // 
            this.ElRadioButton8.Checked = true;
            this.ElRadioButton8.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton8.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton8.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton8.Name = "ElRadioButton8";
            this.ElRadioButton8.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton8.TabIndex = 18;
            this.ElRadioButton8.TextStyle.Text = "View By publication Name";
            this.ElRadioButton8.Value = true;
            // 
            // ElRadioButton9
            // 
            this.ElRadioButton9.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton9.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton9.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton9.Name = "ElRadioButton9";
            this.ElRadioButton9.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton9.TabIndex = 17;
            this.ElRadioButton9.TabStop = false;
            this.ElRadioButton9.TextStyle.Text = "View By Publisher";
            this.ElRadioButton9.Value = false;
            // 
            // TabPage10
            // 
            this.TabPage10.Controls.Add(this.ElPanel10);
            this.TabPage10.ImageIndex = 1;
            this.TabPage10.Location = new System.Drawing.Point(4, 29);
            this.TabPage10.Name = "TabPage10";
            this.TabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage10.Size = new System.Drawing.Size(922, 417);
            this.TabPage10.TabIndex = 1;
            this.TabPage10.Text = "Tree View";
            this.TabPage10.UseVisualStyleBackColor = true;
            // 
            // ElPanel10
            // 
            this.ElPanel10.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel10.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel10.Controls.Add(this.SplitContainer19);
            this.ElPanel10.Controls.Add(this.ElGroupBox3);
            this.ElPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel10.Location = new System.Drawing.Point(3, 3);
            this.ElPanel10.Name = "ElPanel10";
            this.ElPanel10.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel10.Size = new System.Drawing.Size(916, 411);
            this.ElPanel10.TabIndex = 13;
            this.ElPanel10.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer19
            // 
            this.SplitContainer19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer19.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer19.Name = "SplitContainer19";
            this.SplitContainer19.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer19.Panel1
            // 
            this.SplitContainer19.Panel1.Controls.Add(this.spltrPublicationsTreeViewSpliter);
            // 
            // SplitContainer19.Panel2
            // 
            this.SplitContainer19.Panel2.Controls.Add(this.SplitContainer20);
            this.SplitContainer19.Size = new System.Drawing.Size(916, 411);
            this.SplitContainer19.SplitterDistance = 202;
            this.SplitContainer19.TabIndex = 18;
            // 
            // spltrPublicationsTreeViewSpliter
            // 
            this.spltrPublicationsTreeViewSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsTreeViewSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltrPublicationsTreeViewSpliter.IsSplitterFixed = true;
            this.spltrPublicationsTreeViewSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsTreeViewSpliter.Name = "spltrPublicationsTreeViewSpliter";
            this.spltrPublicationsTreeViewSpliter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltrPublicationsTreeViewSpliter.Panel1
            // 
            this.spltrPublicationsTreeViewSpliter.Panel1.Controls.Add(this.spltrPublicationsTreeViewHeaderSpliter);
            // 
            // spltrPublicationsTreeViewSpliter.Panel2
            // 
            this.spltrPublicationsTreeViewSpliter.Panel2.Controls.Add(this.tvwPublicationsREsumeTreeView);
            this.spltrPublicationsTreeViewSpliter.Size = new System.Drawing.Size(916, 202);
            this.spltrPublicationsTreeViewSpliter.SplitterDistance = 37;
            this.spltrPublicationsTreeViewSpliter.SplitterWidth = 1;
            this.spltrPublicationsTreeViewSpliter.TabIndex = 1;
            // 
            // spltrPublicationsTreeViewHeaderSpliter
            // 
            this.spltrPublicationsTreeViewHeaderSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltrPublicationsTreeViewHeaderSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltrPublicationsTreeViewHeaderSpliter.IsSplitterFixed = true;
            this.spltrPublicationsTreeViewHeaderSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltrPublicationsTreeViewHeaderSpliter.Name = "spltrPublicationsTreeViewHeaderSpliter";
            // 
            // spltrPublicationsTreeViewHeaderSpliter.Panel1
            // 
            this.spltrPublicationsTreeViewHeaderSpliter.Panel1.Controls.Add(this.ElLabel23);
            // 
            // spltrPublicationsTreeViewHeaderSpliter.Panel2
            // 
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.Controls.Add(this.btnAvaibalePublicationsTreeViewTreeNodeCollapse);
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.Controls.Add(this.btnAvaibalePublicationsTreeViewTreeCollapse);
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.Controls.Add(this.btnAvaibalePublicationsTreeViewTreeExpand);
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.Controls.Add(this.btnPublicationsTreeViewZoomView);
            this.spltrPublicationsTreeViewHeaderSpliter.Size = new System.Drawing.Size(916, 37);
            this.spltrPublicationsTreeViewHeaderSpliter.SplitterDistance = 733;
            this.spltrPublicationsTreeViewHeaderSpliter.TabIndex = 10;
            // 
            // ElLabel23
            // 
            this.ElLabel23.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle14.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle14.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel23.FlashStyle = paintStyle14;
            this.ElLabel23.ForegroundImageStyle.Image = global::My.Resources.Resources._NEWS1A;
            this.ElLabel23.Location = new System.Drawing.Point(0, 0);
            this.ElLabel23.Name = "ElLabel23";
            this.ElLabel23.Size = new System.Drawing.Size(733, 37);
            this.ElLabel23.TabIndex = 11;
            this.ElLabel23.TabStop = false;
            this.ElLabel23.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel23.TextStyle.Text = "Available Publications";
            this.ElLabel23.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAvaibalePublicationsTreeViewTreeNodeCollapse
            // 
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.BackgroundImage = global::My.Resources.Resources.reload;
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.Location = new System.Drawing.Point(134, 0);
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.Name = "btnAvaibalePublicationsTreeViewTreeNodeCollapse";
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.Size = new System.Drawing.Size(44, 38);
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.TabIndex = 14;
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.UseVisualStyleBackColor = true;
            this.btnAvaibalePublicationsTreeViewTreeNodeCollapse.Click += new System.EventHandler(this.btnAvaibalePublicationsTreeViewTreeNodeCollapse_Click);
            // 
            // btnAvaibalePublicationsTreeViewTreeCollapse
            // 
            this.btnAvaibalePublicationsTreeViewTreeCollapse.BackgroundImage = global::My.Resources.Resources.CollapseTree;
            this.btnAvaibalePublicationsTreeViewTreeCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAvaibalePublicationsTreeViewTreeCollapse.Location = new System.Drawing.Point(90, 0);
            this.btnAvaibalePublicationsTreeViewTreeCollapse.Name = "btnAvaibalePublicationsTreeViewTreeCollapse";
            this.btnAvaibalePublicationsTreeViewTreeCollapse.Size = new System.Drawing.Size(44, 38);
            this.btnAvaibalePublicationsTreeViewTreeCollapse.TabIndex = 12;
            this.btnAvaibalePublicationsTreeViewTreeCollapse.UseVisualStyleBackColor = true;
            this.btnAvaibalePublicationsTreeViewTreeCollapse.Click += new System.EventHandler(this.btnAvaibalePublicationsTreeViewTreeCollapse_Click);
            // 
            // btnAvaibalePublicationsTreeViewTreeExpand
            // 
            this.btnAvaibalePublicationsTreeViewTreeExpand.BackgroundImage = global::My.Resources.Resources.ExpandTree;
            this.btnAvaibalePublicationsTreeViewTreeExpand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAvaibalePublicationsTreeViewTreeExpand.Location = new System.Drawing.Point(46, 0);
            this.btnAvaibalePublicationsTreeViewTreeExpand.Name = "btnAvaibalePublicationsTreeViewTreeExpand";
            this.btnAvaibalePublicationsTreeViewTreeExpand.Size = new System.Drawing.Size(44, 38);
            this.btnAvaibalePublicationsTreeViewTreeExpand.TabIndex = 11;
            this.btnAvaibalePublicationsTreeViewTreeExpand.UseVisualStyleBackColor = true;
            this.btnAvaibalePublicationsTreeViewTreeExpand.Click += new System.EventHandler(this.btnAvaibalePublicationsTreeViewTreeExpand_Click);
            // 
            // btnPublicationsTreeViewZoomView
            // 
            this.btnPublicationsTreeViewZoomView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnPublicationsTreeViewZoomView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPublicationsTreeViewZoomView.Location = new System.Drawing.Point(2, 0);
            this.btnPublicationsTreeViewZoomView.Name = "btnPublicationsTreeViewZoomView";
            this.btnPublicationsTreeViewZoomView.Size = new System.Drawing.Size(44, 38);
            this.btnPublicationsTreeViewZoomView.TabIndex = 10;
            this.btnPublicationsTreeViewZoomView.UseVisualStyleBackColor = true;
            this.btnPublicationsTreeViewZoomView.Click += new System.EventHandler(this.btnPublicationsTreeViewZoomView_Click);
            // 
            // tvwPublicationsREsumeTreeView
            // 
            this.tvwPublicationsREsumeTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwPublicationsREsumeTreeView.ImageIndex = 0;
            this.tvwPublicationsREsumeTreeView.ImageList = this.imgLstPublicationsTreeView;
            this.tvwPublicationsREsumeTreeView.Location = new System.Drawing.Point(0, 0);
            this.tvwPublicationsREsumeTreeView.Name = "tvwPublicationsREsumeTreeView";
            this.tvwPublicationsREsumeTreeView.SelectedImageIndex = 0;
            this.tvwPublicationsREsumeTreeView.Size = new System.Drawing.Size(916, 164);
            this.tvwPublicationsREsumeTreeView.TabIndex = 0;
            this.tvwPublicationsREsumeTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwPublicationsREsumeTreeView_AfterSelect);
            // 
            // imgLstPublicationsTreeView
            // 
            this.imgLstPublicationsTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLstPublicationsTreeView.ImageStream")));
            this.imgLstPublicationsTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLstPublicationsTreeView.Images.SetKeyName(0, "HostNodeIcon.ico");
            this.imgLstPublicationsTreeView.Images.SetKeyName(1, "Publisher.png");
            this.imgLstPublicationsTreeView.Images.SetKeyName(2, "Group.ICO");
            this.imgLstPublicationsTreeView.Images.SetKeyName(3, "{NEWS1A.ICO");
            this.imgLstPublicationsTreeView.Images.SetKeyName(4, "connectionDatetimeNodeIcon.gif");
            this.imgLstPublicationsTreeView.Images.SetKeyName(5, "PublicationsPostedNodeIcon.ico");
            this.imgLstPublicationsTreeView.Images.SetKeyName(6, "ClientP2PPortNode.ico");
            this.imgLstPublicationsTreeView.Images.SetKeyName(7, "multicastIPNodeIcon.ICO");
            this.imgLstPublicationsTreeView.Images.SetKeyName(8, "multicastPortIcon.ICO");
            // 
            // SplitContainer20
            // 
            this.SplitContainer20.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer20.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer20.Name = "SplitContainer20";
            // 
            // SplitContainer20.Panel1
            // 
            this.SplitContainer20.Panel1.Controls.Add(this.ElPanel25);
            // 
            // SplitContainer20.Panel2
            // 
            this.SplitContainer20.Panel2.Controls.Add(this.SplitContainer21);
            this.SplitContainer20.Size = new System.Drawing.Size(916, 205);
            this.SplitContainer20.SplitterDistance = 301;
            this.SplitContainer20.TabIndex = 0;
            // 
            // ElPanel25
            // 
            this.ElPanel25.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel25.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel25.Controls.Add(this.spltCtnrPublicationVariablesHEadrTreeView);
            this.ElPanel25.Controls.Add(this.TabControl2);
            this.ElPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel25.Location = new System.Drawing.Point(0, 0);
            this.ElPanel25.Name = "ElPanel25";
            this.ElPanel25.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel25.Size = new System.Drawing.Size(297, 201);
            this.ElPanel25.TabIndex = 16;
            this.ElPanel25.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltCtnrPublicationVariablesHEadrTreeView
            // 
            this.spltCtnrPublicationVariablesHEadrTreeView.BackColor = System.Drawing.Color.Transparent;
            this.spltCtnrPublicationVariablesHEadrTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCtnrPublicationVariablesHEadrTreeView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCtnrPublicationVariablesHEadrTreeView.IsSplitterFixed = true;
            this.spltCtnrPublicationVariablesHEadrTreeView.Location = new System.Drawing.Point(0, 0);
            this.spltCtnrPublicationVariablesHEadrTreeView.Name = "spltCtnrPublicationVariablesHEadrTreeView";
            this.spltCtnrPublicationVariablesHEadrTreeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltCtnrPublicationVariablesHEadrTreeView.Panel1
            // 
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel1.Controls.Add(this.SplitContainer52);
            // 
            // spltCtnrPublicationVariablesHEadrTreeView.Panel2
            // 
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel2.Controls.Add(this.lsvPublicationTreeViewVariablesList);
            this.spltCtnrPublicationVariablesHEadrTreeView.Size = new System.Drawing.Size(297, 201);
            this.spltCtnrPublicationVariablesHEadrTreeView.SplitterDistance = 36;
            this.spltCtnrPublicationVariablesHEadrTreeView.TabIndex = 5;
            // 
            // SplitContainer52
            // 
            this.SplitContainer52.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer52.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer52.IsSplitterFixed = true;
            this.SplitContainer52.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer52.Name = "SplitContainer52";
            // 
            // SplitContainer52.Panel1
            // 
            this.SplitContainer52.Panel1.Controls.Add(this.ElLabel17);
            // 
            // SplitContainer52.Panel2
            // 
            this.SplitContainer52.Panel2.Controls.Add(this.btnZoomPubsVariablesTreeView);
            this.SplitContainer52.Size = new System.Drawing.Size(297, 36);
            this.SplitContainer52.SplitterDistance = 248;
            this.SplitContainer52.TabIndex = 0;
            // 
            // ElLabel17
            // 
            this.ElLabel17.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle15.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle15.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel17.FlashStyle = paintStyle15;
            this.ElLabel17.ForegroundImageStyle.Image = global::My.Resources.Resources.publicationVariables;
            this.ElLabel17.Location = new System.Drawing.Point(0, 0);
            this.ElLabel17.Name = "ElLabel17";
            this.ElLabel17.Size = new System.Drawing.Size(248, 36);
            this.ElLabel17.TabIndex = 8;
            this.ElLabel17.TabStop = false;
            this.ElLabel17.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel17.TextStyle.Text = "Publication Variables";
            this.ElLabel17.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomPubsVariablesTreeView
            // 
            this.btnZoomPubsVariablesTreeView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsVariablesTreeView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsVariablesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPubsVariablesTreeView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsVariablesTreeView.Name = "btnZoomPubsVariablesTreeView";
            this.btnZoomPubsVariablesTreeView.Size = new System.Drawing.Size(45, 36);
            this.btnZoomPubsVariablesTreeView.TabIndex = 9;
            this.btnZoomPubsVariablesTreeView.UseVisualStyleBackColor = true;
            this.btnZoomPubsVariablesTreeView.Click += new System.EventHandler(this.btnZoomPubsVariablesTreeView_Click);
            // 
            // lsvPublicationTreeViewVariablesList
            // 
            this.lsvPublicationTreeViewVariablesList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublicationTreeViewVariablesList.BackColor = System.Drawing.Color.White;
            this.lsvPublicationTreeViewVariablesList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublicationTreeViewVariablesList.FullRowSelect = true;
            this.lsvPublicationTreeViewVariablesList.GridLines = true;
            this.lsvPublicationTreeViewVariablesList.HideSelection = false;
            this.lsvPublicationTreeViewVariablesList.Location = new System.Drawing.Point(0, 0);
            this.lsvPublicationTreeViewVariablesList.MultiSelect = false;
            this.lsvPublicationTreeViewVariablesList.Name = "lsvPublicationTreeViewVariablesList";
            this.lsvPublicationTreeViewVariablesList.Size = new System.Drawing.Size(297, 161);
            this.lsvPublicationTreeViewVariablesList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublicationTreeViewVariablesList.TabIndex = 5;
            this.lsvPublicationTreeViewVariablesList.UseCompatibleStateImageBehavior = false;
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage3);
            this.TabControl2.Controls.Add(this.TabPage4);
            this.TabControl2.Location = new System.Drawing.Point(0, 367);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(592, 264);
            this.TabControl2.TabIndex = 3;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.ElPanel26);
            this.TabPage3.Location = new System.Drawing.Point(4, 25);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(584, 235);
            this.TabPage3.TabIndex = 0;
            this.TabPage3.Text = "Publications Resume";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // ElPanel26
            // 
            this.ElPanel26.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel26.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel26.Controls.Add(this.SplitContainer22);
            this.ElPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel26.Location = new System.Drawing.Point(3, 3);
            this.ElPanel26.Name = "ElPanel26";
            this.ElPanel26.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel26.Size = new System.Drawing.Size(578, 229);
            this.ElPanel26.TabIndex = 13;
            this.ElPanel26.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer22
            // 
            this.SplitContainer22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer22.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer22.Name = "SplitContainer22";
            this.SplitContainer22.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer22.Panel1
            // 
            this.SplitContainer22.Panel1.Controls.Add(this.ListView1);
            // 
            // SplitContainer22.Panel2
            // 
            this.SplitContainer22.Panel2.Controls.Add(this.SplitContainer23);
            this.SplitContainer22.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer22.SplitterDistance = 114;
            this.SplitContainer22.TabIndex = 4;
            // 
            // ListView1
            // 
            this.ListView1.BackColor = System.Drawing.Color.LemonChiffon;
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.Location = new System.Drawing.Point(0, 0);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(578, 114);
            this.ListView1.TabIndex = 2;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            // 
            // SplitContainer23
            // 
            this.SplitContainer23.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer23.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer23.Name = "SplitContainer23";
            // 
            // SplitContainer23.Panel1
            // 
            this.SplitContainer23.Panel1.Controls.Add(this.ElPanel27);
            // 
            // SplitContainer23.Panel2
            // 
            this.SplitContainer23.Panel2.Controls.Add(this.ElPanel28);
            this.SplitContainer23.Size = new System.Drawing.Size(578, 111);
            this.SplitContainer23.SplitterDistance = 173;
            this.SplitContainer23.TabIndex = 0;
            // 
            // ElPanel27
            // 
            this.ElPanel27.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel27.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel27.Controls.Add(this.SplitContainer24);
            this.ElPanel27.Controls.Add(this.ElGroupBox13);
            this.ElPanel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel27.Location = new System.Drawing.Point(0, 0);
            this.ElPanel27.Name = "ElPanel27";
            this.ElPanel27.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel27.Size = new System.Drawing.Size(169, 107);
            this.ElPanel27.TabIndex = 14;
            this.ElPanel27.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer24
            // 
            this.SplitContainer24.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer24.IsSplitterFixed = true;
            this.SplitContainer24.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer24.Name = "SplitContainer24";
            this.SplitContainer24.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer24.Panel1
            // 
            this.SplitContainer24.Panel1.Controls.Add(this.ElLabel8);
            // 
            // SplitContainer24.Panel2
            // 
            this.SplitContainer24.Panel2.Controls.Add(this.ListView2);
            this.SplitContainer24.Size = new System.Drawing.Size(169, 107);
            this.SplitContainer24.SplitterDistance = 25;
            this.SplitContainer24.TabIndex = 18;
            // 
            // ElLabel8
            // 
            this.ElLabel8.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle16.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle16.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel8.FlashStyle = paintStyle16;
            this.ElLabel8.Location = new System.Drawing.Point(0, 0);
            this.ElLabel8.Name = "ElLabel8";
            this.ElLabel8.Size = new System.Drawing.Size(169, 25);
            this.ElLabel8.TabIndex = 7;
            this.ElLabel8.TabStop = false;
            this.ElLabel8.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel8.TextStyle.Text = "Publication Variables";
            this.ElLabel8.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView2
            // 
            this.ListView2.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView2.FullRowSelect = true;
            this.ListView2.GridLines = true;
            this.ListView2.HideSelection = false;
            this.ListView2.Location = new System.Drawing.Point(0, 0);
            this.ListView2.MultiSelect = false;
            this.ListView2.Name = "ListView2";
            this.ListView2.Size = new System.Drawing.Size(169, 78);
            this.ListView2.TabIndex = 3;
            this.ListView2.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox13
            // 
            this.ElGroupBox13.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox13.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox13.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox13.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox13.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox13.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox13.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox13.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox13.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox13.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox13.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox13.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox13.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox13.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox13.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox13.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox13.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox13.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox13.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox13.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox13.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox13.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox13.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox13.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox13.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox13.Controls.Add(this.ElRadioButton16);
            this.ElGroupBox13.Controls.Add(this.ElRadioButton17);
            this.ElGroupBox13.Controls.Add(this.ElRadioButton18);
            this.ElGroupBox13.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox13.Name = "ElGroupBox13";
            this.ElGroupBox13.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox13.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox13.TabIndex = 16;
            this.ElGroupBox13.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton16
            // 
            this.ElRadioButton16.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton16.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton16.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton16.Name = "ElRadioButton16";
            this.ElRadioButton16.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton16.TabIndex = 20;
            this.ElRadioButton16.TabStop = false;
            this.ElRadioButton16.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton16.Value = false;
            // 
            // ElRadioButton17
            // 
            this.ElRadioButton17.Checked = true;
            this.ElRadioButton17.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton17.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton17.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton17.Name = "ElRadioButton17";
            this.ElRadioButton17.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton17.TabIndex = 18;
            this.ElRadioButton17.TextStyle.Text = "View By publication Name";
            this.ElRadioButton17.Value = true;
            // 
            // ElRadioButton18
            // 
            this.ElRadioButton18.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton18.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton18.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton18.Name = "ElRadioButton18";
            this.ElRadioButton18.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton18.TabIndex = 17;
            this.ElRadioButton18.TabStop = false;
            this.ElRadioButton18.TextStyle.Text = "View By Publisher";
            this.ElRadioButton18.Value = false;
            // 
            // ElPanel28
            // 
            this.ElPanel28.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel28.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel28.Controls.Add(this.SplitContainer25);
            this.ElPanel28.Controls.Add(this.ElGroupBox16);
            this.ElPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel28.Location = new System.Drawing.Point(0, 0);
            this.ElPanel28.Name = "ElPanel28";
            this.ElPanel28.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel28.Size = new System.Drawing.Size(397, 107);
            this.ElPanel28.TabIndex = 14;
            this.ElPanel28.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer25
            // 
            this.SplitContainer25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer25.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer25.Name = "SplitContainer25";
            // 
            // SplitContainer25.Panel1
            // 
            this.SplitContainer25.Panel1.Controls.Add(this.ElPanel29);
            // 
            // SplitContainer25.Panel2
            // 
            this.SplitContainer25.Panel2.Controls.Add(this.ElPanel30);
            this.SplitContainer25.Size = new System.Drawing.Size(397, 107);
            this.SplitContainer25.SplitterDistance = 198;
            this.SplitContainer25.TabIndex = 18;
            // 
            // ElPanel29
            // 
            this.ElPanel29.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel29.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel29.Controls.Add(this.SplitContainer26);
            this.ElPanel29.Controls.Add(this.ElGroupBox14);
            this.ElPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel29.Location = new System.Drawing.Point(0, 0);
            this.ElPanel29.Name = "ElPanel29";
            this.ElPanel29.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel29.Size = new System.Drawing.Size(194, 103);
            this.ElPanel29.TabIndex = 14;
            this.ElPanel29.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer26
            // 
            this.SplitContainer26.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer26.IsSplitterFixed = true;
            this.SplitContainer26.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer26.Name = "SplitContainer26";
            this.SplitContainer26.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer26.Panel1
            // 
            this.SplitContainer26.Panel1.Controls.Add(this.ElLabel9);
            // 
            // SplitContainer26.Panel2
            // 
            this.SplitContainer26.Panel2.Controls.Add(this.ListView3);
            this.SplitContainer26.Size = new System.Drawing.Size(194, 103);
            this.SplitContainer26.SplitterDistance = 25;
            this.SplitContainer26.TabIndex = 19;
            // 
            // ElLabel9
            // 
            this.ElLabel9.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle17.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle17.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel9.FlashStyle = paintStyle17;
            this.ElLabel9.Location = new System.Drawing.Point(0, 0);
            this.ElLabel9.Name = "ElLabel9";
            this.ElLabel9.Size = new System.Drawing.Size(194, 25);
            this.ElLabel9.TabIndex = 7;
            this.ElLabel9.TabStop = false;
            this.ElLabel9.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel9.TextStyle.Text = "Connected Clients";
            this.ElLabel9.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView3
            // 
            this.ListView3.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView3.FullRowSelect = true;
            this.ListView3.GridLines = true;
            this.ListView3.HideSelection = false;
            this.ListView3.Location = new System.Drawing.Point(0, 0);
            this.ListView3.MultiSelect = false;
            this.ListView3.Name = "ListView3";
            this.ListView3.Size = new System.Drawing.Size(194, 74);
            this.ListView3.TabIndex = 3;
            this.ListView3.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox14
            // 
            this.ElGroupBox14.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox14.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox14.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox14.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox14.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox14.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox14.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox14.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox14.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox14.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox14.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox14.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox14.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox14.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox14.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox14.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox14.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox14.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox14.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox14.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox14.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox14.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox14.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox14.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox14.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox14.Controls.Add(this.ElRadioButton19);
            this.ElGroupBox14.Controls.Add(this.ElRadioButton20);
            this.ElGroupBox14.Controls.Add(this.ElRadioButton21);
            this.ElGroupBox14.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox14.Name = "ElGroupBox14";
            this.ElGroupBox14.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox14.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox14.TabIndex = 16;
            this.ElGroupBox14.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton19
            // 
            this.ElRadioButton19.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton19.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton19.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton19.Name = "ElRadioButton19";
            this.ElRadioButton19.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton19.TabIndex = 20;
            this.ElRadioButton19.TabStop = false;
            this.ElRadioButton19.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton19.Value = false;
            // 
            // ElRadioButton20
            // 
            this.ElRadioButton20.Checked = true;
            this.ElRadioButton20.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton20.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton20.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton20.Name = "ElRadioButton20";
            this.ElRadioButton20.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton20.TabIndex = 18;
            this.ElRadioButton20.TextStyle.Text = "View By publication Name";
            this.ElRadioButton20.Value = true;
            // 
            // ElRadioButton21
            // 
            this.ElRadioButton21.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton21.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton21.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton21.Name = "ElRadioButton21";
            this.ElRadioButton21.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton21.TabIndex = 17;
            this.ElRadioButton21.TabStop = false;
            this.ElRadioButton21.TextStyle.Text = "View By Publisher";
            this.ElRadioButton21.Value = false;
            // 
            // ElPanel30
            // 
            this.ElPanel30.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel30.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel30.Controls.Add(this.SplitContainer27);
            this.ElPanel30.Controls.Add(this.ElGroupBox15);
            this.ElPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel30.Location = new System.Drawing.Point(0, 0);
            this.ElPanel30.Name = "ElPanel30";
            this.ElPanel30.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel30.Size = new System.Drawing.Size(191, 103);
            this.ElPanel30.TabIndex = 14;
            this.ElPanel30.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer27
            // 
            this.SplitContainer27.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer27.IsSplitterFixed = true;
            this.SplitContainer27.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer27.Name = "SplitContainer27";
            this.SplitContainer27.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer27.Panel1
            // 
            this.SplitContainer27.Panel1.Controls.Add(this.ElLabel10);
            // 
            // SplitContainer27.Panel2
            // 
            this.SplitContainer27.Panel2.Controls.Add(this.DataGridView1);
            this.SplitContainer27.Size = new System.Drawing.Size(191, 103);
            this.SplitContainer27.SplitterDistance = 25;
            this.SplitContainer27.TabIndex = 19;
            // 
            // ElLabel10
            // 
            this.ElLabel10.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle18.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle18.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel10.FlashStyle = paintStyle18;
            this.ElLabel10.Location = new System.Drawing.Point(0, 0);
            this.ElLabel10.Name = "ElLabel10";
            this.ElLabel10.Size = new System.Drawing.Size(191, 25);
            this.ElLabel10.TabIndex = 7;
            this.ElLabel10.TabStop = false;
            this.ElLabel10.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel10.TextStyle.Text = "Statistics";
            this.ElLabel10.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView1.Location = new System.Drawing.Point(0, 0);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.Size = new System.Drawing.Size(191, 74);
            this.DataGridView1.TabIndex = 0;
            // 
            // ElGroupBox15
            // 
            this.ElGroupBox15.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox15.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox15.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox15.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox15.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox15.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox15.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox15.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox15.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox15.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox15.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox15.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox15.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox15.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox15.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox15.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox15.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox15.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox15.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox15.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox15.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox15.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox15.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox15.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox15.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox15.Controls.Add(this.ElRadioButton22);
            this.ElGroupBox15.Controls.Add(this.ElRadioButton23);
            this.ElGroupBox15.Controls.Add(this.ElRadioButton24);
            this.ElGroupBox15.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox15.Name = "ElGroupBox15";
            this.ElGroupBox15.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox15.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox15.TabIndex = 16;
            this.ElGroupBox15.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton22
            // 
            this.ElRadioButton22.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton22.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton22.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton22.Name = "ElRadioButton22";
            this.ElRadioButton22.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton22.TabIndex = 20;
            this.ElRadioButton22.TabStop = false;
            this.ElRadioButton22.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton22.Value = false;
            // 
            // ElRadioButton23
            // 
            this.ElRadioButton23.Checked = true;
            this.ElRadioButton23.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton23.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton23.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton23.Name = "ElRadioButton23";
            this.ElRadioButton23.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton23.TabIndex = 18;
            this.ElRadioButton23.TextStyle.Text = "View By publication Name";
            this.ElRadioButton23.Value = true;
            // 
            // ElRadioButton24
            // 
            this.ElRadioButton24.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton24.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton24.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton24.Name = "ElRadioButton24";
            this.ElRadioButton24.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton24.TabIndex = 17;
            this.ElRadioButton24.TabStop = false;
            this.ElRadioButton24.TextStyle.Text = "View By Publisher";
            this.ElRadioButton24.Value = false;
            // 
            // ElGroupBox16
            // 
            this.ElGroupBox16.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox16.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox16.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox16.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox16.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox16.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox16.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox16.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox16.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox16.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox16.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox16.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox16.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox16.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox16.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox16.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox16.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox16.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox16.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox16.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox16.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox16.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox16.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox16.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox16.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox16.Controls.Add(this.ElRadioButton25);
            this.ElGroupBox16.Controls.Add(this.ElRadioButton26);
            this.ElGroupBox16.Controls.Add(this.ElRadioButton27);
            this.ElGroupBox16.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox16.Name = "ElGroupBox16";
            this.ElGroupBox16.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox16.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox16.TabIndex = 16;
            this.ElGroupBox16.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton25
            // 
            this.ElRadioButton25.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton25.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton25.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton25.Name = "ElRadioButton25";
            this.ElRadioButton25.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton25.TabIndex = 20;
            this.ElRadioButton25.TabStop = false;
            this.ElRadioButton25.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton25.Value = false;
            // 
            // ElRadioButton26
            // 
            this.ElRadioButton26.Checked = true;
            this.ElRadioButton26.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton26.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton26.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton26.Name = "ElRadioButton26";
            this.ElRadioButton26.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton26.TabIndex = 18;
            this.ElRadioButton26.TextStyle.Text = "View By publication Name";
            this.ElRadioButton26.Value = true;
            // 
            // ElRadioButton27
            // 
            this.ElRadioButton27.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton27.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton27.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton27.Name = "ElRadioButton27";
            this.ElRadioButton27.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton27.TabIndex = 17;
            this.ElRadioButton27.TabStop = false;
            this.ElRadioButton27.TextStyle.Text = "View By Publisher";
            this.ElRadioButton27.Value = false;
            // 
            // TabPage4
            // 
            this.TabPage4.Controls.Add(this.ElPanel31);
            this.TabPage4.Location = new System.Drawing.Point(4, 25);
            this.TabPage4.Name = "TabPage4";
            this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage4.Size = new System.Drawing.Size(584, 235);
            this.TabPage4.TabIndex = 1;
            this.TabPage4.Text = "Tree View";
            this.TabPage4.UseVisualStyleBackColor = true;
            // 
            // ElPanel31
            // 
            this.ElPanel31.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel31.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel31.Controls.Add(this.SplitContainer28);
            this.ElPanel31.Controls.Add(this.ElGroupBox17);
            this.ElPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel31.Location = new System.Drawing.Point(3, 3);
            this.ElPanel31.Name = "ElPanel31";
            this.ElPanel31.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel31.Size = new System.Drawing.Size(578, 229);
            this.ElPanel31.TabIndex = 13;
            this.ElPanel31.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer28
            // 
            this.SplitContainer28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer28.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer28.Name = "SplitContainer28";
            this.SplitContainer28.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer28.Panel1
            // 
            this.SplitContainer28.Panel1.Controls.Add(this.TreeView2);
            // 
            // SplitContainer28.Panel2
            // 
            this.SplitContainer28.Panel2.Controls.Add(this.SplitContainer29);
            this.SplitContainer28.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer28.SplitterDistance = 89;
            this.SplitContainer28.TabIndex = 18;
            // 
            // TreeView2
            // 
            this.TreeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView2.Location = new System.Drawing.Point(0, 0);
            this.TreeView2.Name = "TreeView2";
            this.TreeView2.Size = new System.Drawing.Size(578, 89);
            this.TreeView2.TabIndex = 0;
            // 
            // SplitContainer29
            // 
            this.SplitContainer29.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer29.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer29.Name = "SplitContainer29";
            // 
            // SplitContainer29.Panel2
            // 
            this.SplitContainer29.Panel2.Controls.Add(this.SplitContainer30);
            this.SplitContainer29.Size = new System.Drawing.Size(578, 136);
            this.SplitContainer29.SplitterDistance = 192;
            this.SplitContainer29.TabIndex = 0;
            // 
            // SplitContainer30
            // 
            this.SplitContainer30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer30.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer30.Name = "SplitContainer30";
            this.SplitContainer30.Size = new System.Drawing.Size(382, 136);
            this.SplitContainer30.SplitterDistance = 193;
            this.SplitContainer30.TabIndex = 0;
            // 
            // ElGroupBox17
            // 
            this.ElGroupBox17.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox17.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox17.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox17.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox17.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox17.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox17.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox17.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox17.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox17.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox17.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox17.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox17.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox17.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox17.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox17.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox17.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox17.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox17.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox17.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox17.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox17.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox17.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox17.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox17.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox17.Controls.Add(this.ElRadioButton28);
            this.ElGroupBox17.Controls.Add(this.ElRadioButton29);
            this.ElGroupBox17.Controls.Add(this.ElRadioButton30);
            this.ElGroupBox17.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox17.Name = "ElGroupBox17";
            this.ElGroupBox17.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox17.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox17.TabIndex = 16;
            this.ElGroupBox17.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton28
            // 
            this.ElRadioButton28.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton28.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton28.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton28.Name = "ElRadioButton28";
            this.ElRadioButton28.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton28.TabIndex = 20;
            this.ElRadioButton28.TabStop = false;
            this.ElRadioButton28.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton28.Value = false;
            // 
            // ElRadioButton29
            // 
            this.ElRadioButton29.Checked = true;
            this.ElRadioButton29.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton29.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton29.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton29.Name = "ElRadioButton29";
            this.ElRadioButton29.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton29.TabIndex = 18;
            this.ElRadioButton29.TextStyle.Text = "View By publication Name";
            this.ElRadioButton29.Value = true;
            // 
            // ElRadioButton30
            // 
            this.ElRadioButton30.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton30.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton30.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton30.Name = "ElRadioButton30";
            this.ElRadioButton30.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton30.TabIndex = 17;
            this.ElRadioButton30.TabStop = false;
            this.ElRadioButton30.TextStyle.Text = "View By Publisher";
            this.ElRadioButton30.Value = false;
            // 
            // SplitContainer21
            // 
            this.SplitContainer21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer21.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer21.Name = "SplitContainer21";
            // 
            // SplitContainer21.Panel1
            // 
            this.SplitContainer21.Panel1.Controls.Add(this.ElPanel32);
            // 
            // SplitContainer21.Panel2
            // 
            this.SplitContainer21.Panel2.Controls.Add(this.ElPanel39);
            this.SplitContainer21.Size = new System.Drawing.Size(611, 205);
            this.SplitContainer21.SplitterDistance = 305;
            this.SplitContainer21.TabIndex = 0;
            // 
            // ElPanel32
            // 
            this.ElPanel32.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel32.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel32.Controls.Add(this.spltCntrConnectedClientsTreeView);
            this.ElPanel32.Controls.Add(this.TabControl3);
            this.ElPanel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel32.Location = new System.Drawing.Point(0, 0);
            this.ElPanel32.Name = "ElPanel32";
            this.ElPanel32.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel32.Size = new System.Drawing.Size(301, 201);
            this.ElPanel32.TabIndex = 17;
            this.ElPanel32.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // spltCntrConnectedClientsTreeView
            // 
            this.spltCntrConnectedClientsTreeView.BackColor = System.Drawing.Color.Transparent;
            this.spltCntrConnectedClientsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltCntrConnectedClientsTreeView.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltCntrConnectedClientsTreeView.IsSplitterFixed = true;
            this.spltCntrConnectedClientsTreeView.Location = new System.Drawing.Point(0, 0);
            this.spltCntrConnectedClientsTreeView.Name = "spltCntrConnectedClientsTreeView";
            this.spltCntrConnectedClientsTreeView.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltCntrConnectedClientsTreeView.Panel1
            // 
            this.spltCntrConnectedClientsTreeView.Panel1.Controls.Add(this.SplitContainer53);
            // 
            // spltCntrConnectedClientsTreeView.Panel2
            // 
            this.spltCntrConnectedClientsTreeView.Panel2.Controls.Add(this.lsvPublicationsREsumeTreeviewConnectedClients);
            this.spltCntrConnectedClientsTreeView.Size = new System.Drawing.Size(301, 201);
            this.spltCntrConnectedClientsTreeView.SplitterDistance = 36;
            this.spltCntrConnectedClientsTreeView.TabIndex = 6;
            // 
            // SplitContainer53
            // 
            this.SplitContainer53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer53.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer53.IsSplitterFixed = true;
            this.SplitContainer53.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer53.Name = "SplitContainer53";
            // 
            // SplitContainer53.Panel1
            // 
            this.SplitContainer53.Panel1.Controls.Add(this.ElLabel18);
            // 
            // SplitContainer53.Panel2
            // 
            this.SplitContainer53.Panel2.Controls.Add(this.btnZoomPubsClientsTreeView);
            this.SplitContainer53.Size = new System.Drawing.Size(301, 36);
            this.SplitContainer53.SplitterDistance = 252;
            this.SplitContainer53.TabIndex = 9;
            // 
            // ElLabel18
            // 
            this.ElLabel18.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle19.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle19.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel18.FlashStyle = paintStyle19;
            this.ElLabel18.ForegroundImageStyle.Image = global::My.Resources.Resources.usersGroup;
            this.ElLabel18.Location = new System.Drawing.Point(0, 0);
            this.ElLabel18.Name = "ElLabel18";
            this.ElLabel18.Size = new System.Drawing.Size(252, 36);
            this.ElLabel18.TabIndex = 8;
            this.ElLabel18.TabStop = false;
            this.ElLabel18.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel18.TextStyle.Text = "Connected Clients";
            this.ElLabel18.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnZoomPubsClientsTreeView
            // 
            this.btnZoomPubsClientsTreeView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsClientsTreeView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsClientsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnZoomPubsClientsTreeView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsClientsTreeView.Name = "btnZoomPubsClientsTreeView";
            this.btnZoomPubsClientsTreeView.Size = new System.Drawing.Size(45, 36);
            this.btnZoomPubsClientsTreeView.TabIndex = 9;
            this.btnZoomPubsClientsTreeView.UseVisualStyleBackColor = true;
            this.btnZoomPubsClientsTreeView.Click += new System.EventHandler(this.btnZoomPubsClientsTreeView_Click);
            // 
            // lsvPublicationsREsumeTreeviewConnectedClients
            // 
            this.lsvPublicationsREsumeTreeviewConnectedClients.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvPublicationsREsumeTreeviewConnectedClients.BackColor = System.Drawing.Color.White;
            this.lsvPublicationsREsumeTreeviewConnectedClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvPublicationsREsumeTreeviewConnectedClients.FullRowSelect = true;
            this.lsvPublicationsREsumeTreeviewConnectedClients.GridLines = true;
            this.lsvPublicationsREsumeTreeviewConnectedClients.HideSelection = false;
            this.lsvPublicationsREsumeTreeviewConnectedClients.Location = new System.Drawing.Point(0, 0);
            this.lsvPublicationsREsumeTreeviewConnectedClients.MultiSelect = false;
            this.lsvPublicationsREsumeTreeviewConnectedClients.Name = "lsvPublicationsREsumeTreeviewConnectedClients";
            this.lsvPublicationsREsumeTreeviewConnectedClients.Size = new System.Drawing.Size(301, 161);
            this.lsvPublicationsREsumeTreeviewConnectedClients.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lsvPublicationsREsumeTreeviewConnectedClients.TabIndex = 4;
            this.lsvPublicationsREsumeTreeviewConnectedClients.UseCompatibleStateImageBehavior = false;
            this.lsvPublicationsREsumeTreeviewConnectedClients.DoubleClick += new System.EventHandler(this.lsvPublicationsREsumeTreeviewConnectedClients_DoubleClick);
            // 
            // TabControl3
            // 
            this.TabControl3.Controls.Add(this.TabPage11);
            this.TabControl3.Controls.Add(this.TabPage12);
            this.TabControl3.Location = new System.Drawing.Point(0, 367);
            this.TabControl3.Name = "TabControl3";
            this.TabControl3.SelectedIndex = 0;
            this.TabControl3.Size = new System.Drawing.Size(592, 264);
            this.TabControl3.TabIndex = 3;
            // 
            // TabPage11
            // 
            this.TabPage11.Controls.Add(this.ElPanel33);
            this.TabPage11.Location = new System.Drawing.Point(4, 25);
            this.TabPage11.Name = "TabPage11";
            this.TabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage11.Size = new System.Drawing.Size(584, 235);
            this.TabPage11.TabIndex = 0;
            this.TabPage11.Text = "Publications Resume";
            this.TabPage11.UseVisualStyleBackColor = true;
            // 
            // ElPanel33
            // 
            this.ElPanel33.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel33.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel33.Controls.Add(this.SplitContainer31);
            this.ElPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel33.Location = new System.Drawing.Point(3, 3);
            this.ElPanel33.Name = "ElPanel33";
            this.ElPanel33.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel33.Size = new System.Drawing.Size(578, 229);
            this.ElPanel33.TabIndex = 13;
            this.ElPanel33.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer31
            // 
            this.SplitContainer31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer31.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer31.Name = "SplitContainer31";
            this.SplitContainer31.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer31.Panel1
            // 
            this.SplitContainer31.Panel1.Controls.Add(this.ListView4);
            // 
            // SplitContainer31.Panel2
            // 
            this.SplitContainer31.Panel2.Controls.Add(this.SplitContainer32);
            this.SplitContainer31.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer31.SplitterDistance = 114;
            this.SplitContainer31.TabIndex = 4;
            // 
            // ListView4
            // 
            this.ListView4.BackColor = System.Drawing.Color.LemonChiffon;
            this.ListView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView4.Location = new System.Drawing.Point(0, 0);
            this.ListView4.Name = "ListView4";
            this.ListView4.Size = new System.Drawing.Size(578, 114);
            this.ListView4.TabIndex = 2;
            this.ListView4.UseCompatibleStateImageBehavior = false;
            // 
            // SplitContainer32
            // 
            this.SplitContainer32.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer32.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer32.Name = "SplitContainer32";
            // 
            // SplitContainer32.Panel1
            // 
            this.SplitContainer32.Panel1.Controls.Add(this.ElPanel34);
            // 
            // SplitContainer32.Panel2
            // 
            this.SplitContainer32.Panel2.Controls.Add(this.ElPanel35);
            this.SplitContainer32.Size = new System.Drawing.Size(578, 111);
            this.SplitContainer32.SplitterDistance = 173;
            this.SplitContainer32.TabIndex = 0;
            // 
            // ElPanel34
            // 
            this.ElPanel34.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel34.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel34.Controls.Add(this.SplitContainer33);
            this.ElPanel34.Controls.Add(this.ElGroupBox18);
            this.ElPanel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel34.Location = new System.Drawing.Point(0, 0);
            this.ElPanel34.Name = "ElPanel34";
            this.ElPanel34.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel34.Size = new System.Drawing.Size(169, 107);
            this.ElPanel34.TabIndex = 14;
            this.ElPanel34.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer33
            // 
            this.SplitContainer33.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer33.IsSplitterFixed = true;
            this.SplitContainer33.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer33.Name = "SplitContainer33";
            this.SplitContainer33.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer33.Panel1
            // 
            this.SplitContainer33.Panel1.Controls.Add(this.ElLabel11);
            // 
            // SplitContainer33.Panel2
            // 
            this.SplitContainer33.Panel2.Controls.Add(this.ListView5);
            this.SplitContainer33.Size = new System.Drawing.Size(169, 107);
            this.SplitContainer33.SplitterDistance = 25;
            this.SplitContainer33.TabIndex = 18;
            // 
            // ElLabel11
            // 
            this.ElLabel11.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle20.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle20.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel11.FlashStyle = paintStyle20;
            this.ElLabel11.Location = new System.Drawing.Point(0, 0);
            this.ElLabel11.Name = "ElLabel11";
            this.ElLabel11.Size = new System.Drawing.Size(169, 25);
            this.ElLabel11.TabIndex = 7;
            this.ElLabel11.TabStop = false;
            this.ElLabel11.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel11.TextStyle.Text = "Publication Variables";
            this.ElLabel11.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView5
            // 
            this.ListView5.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView5.FullRowSelect = true;
            this.ListView5.GridLines = true;
            this.ListView5.HideSelection = false;
            this.ListView5.Location = new System.Drawing.Point(0, 0);
            this.ListView5.MultiSelect = false;
            this.ListView5.Name = "ListView5";
            this.ListView5.Size = new System.Drawing.Size(169, 78);
            this.ListView5.TabIndex = 3;
            this.ListView5.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox18
            // 
            this.ElGroupBox18.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox18.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox18.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox18.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox18.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox18.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox18.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox18.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox18.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox18.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox18.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox18.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox18.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox18.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox18.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox18.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox18.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox18.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox18.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox18.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox18.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox18.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox18.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox18.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox18.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox18.Controls.Add(this.ElRadioButton31);
            this.ElGroupBox18.Controls.Add(this.ElRadioButton32);
            this.ElGroupBox18.Controls.Add(this.ElRadioButton33);
            this.ElGroupBox18.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox18.Name = "ElGroupBox18";
            this.ElGroupBox18.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox18.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox18.TabIndex = 16;
            this.ElGroupBox18.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton31
            // 
            this.ElRadioButton31.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton31.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton31.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton31.Name = "ElRadioButton31";
            this.ElRadioButton31.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton31.TabIndex = 20;
            this.ElRadioButton31.TabStop = false;
            this.ElRadioButton31.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton31.Value = false;
            // 
            // ElRadioButton32
            // 
            this.ElRadioButton32.Checked = true;
            this.ElRadioButton32.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton32.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton32.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton32.Name = "ElRadioButton32";
            this.ElRadioButton32.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton32.TabIndex = 18;
            this.ElRadioButton32.TextStyle.Text = "View By publication Name";
            this.ElRadioButton32.Value = true;
            // 
            // ElRadioButton33
            // 
            this.ElRadioButton33.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton33.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton33.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton33.Name = "ElRadioButton33";
            this.ElRadioButton33.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton33.TabIndex = 17;
            this.ElRadioButton33.TabStop = false;
            this.ElRadioButton33.TextStyle.Text = "View By Publisher";
            this.ElRadioButton33.Value = false;
            // 
            // ElPanel35
            // 
            this.ElPanel35.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel35.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel35.Controls.Add(this.SplitContainer34);
            this.ElPanel35.Controls.Add(this.ElGroupBox21);
            this.ElPanel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel35.Location = new System.Drawing.Point(0, 0);
            this.ElPanel35.Name = "ElPanel35";
            this.ElPanel35.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel35.Size = new System.Drawing.Size(397, 107);
            this.ElPanel35.TabIndex = 14;
            this.ElPanel35.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer34
            // 
            this.SplitContainer34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer34.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer34.Name = "SplitContainer34";
            // 
            // SplitContainer34.Panel1
            // 
            this.SplitContainer34.Panel1.Controls.Add(this.ElPanel36);
            // 
            // SplitContainer34.Panel2
            // 
            this.SplitContainer34.Panel2.Controls.Add(this.ElPanel37);
            this.SplitContainer34.Size = new System.Drawing.Size(397, 107);
            this.SplitContainer34.SplitterDistance = 198;
            this.SplitContainer34.TabIndex = 18;
            // 
            // ElPanel36
            // 
            this.ElPanel36.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel36.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel36.Controls.Add(this.SplitContainer35);
            this.ElPanel36.Controls.Add(this.ElGroupBox19);
            this.ElPanel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel36.Location = new System.Drawing.Point(0, 0);
            this.ElPanel36.Name = "ElPanel36";
            this.ElPanel36.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel36.Size = new System.Drawing.Size(194, 103);
            this.ElPanel36.TabIndex = 14;
            this.ElPanel36.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer35
            // 
            this.SplitContainer35.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer35.IsSplitterFixed = true;
            this.SplitContainer35.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer35.Name = "SplitContainer35";
            this.SplitContainer35.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer35.Panel1
            // 
            this.SplitContainer35.Panel1.Controls.Add(this.ElLabel12);
            // 
            // SplitContainer35.Panel2
            // 
            this.SplitContainer35.Panel2.Controls.Add(this.ListView6);
            this.SplitContainer35.Size = new System.Drawing.Size(194, 103);
            this.SplitContainer35.SplitterDistance = 25;
            this.SplitContainer35.TabIndex = 19;
            // 
            // ElLabel12
            // 
            this.ElLabel12.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle21.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle21.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel12.FlashStyle = paintStyle21;
            this.ElLabel12.Location = new System.Drawing.Point(0, 0);
            this.ElLabel12.Name = "ElLabel12";
            this.ElLabel12.Size = new System.Drawing.Size(194, 25);
            this.ElLabel12.TabIndex = 7;
            this.ElLabel12.TabStop = false;
            this.ElLabel12.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel12.TextStyle.Text = "Connected Clients";
            this.ElLabel12.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView6
            // 
            this.ListView6.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView6.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView6.FullRowSelect = true;
            this.ListView6.GridLines = true;
            this.ListView6.HideSelection = false;
            this.ListView6.Location = new System.Drawing.Point(0, 0);
            this.ListView6.MultiSelect = false;
            this.ListView6.Name = "ListView6";
            this.ListView6.Size = new System.Drawing.Size(194, 74);
            this.ListView6.TabIndex = 3;
            this.ListView6.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox19
            // 
            this.ElGroupBox19.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox19.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox19.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox19.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox19.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox19.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox19.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox19.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox19.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox19.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox19.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox19.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox19.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox19.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox19.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox19.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox19.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox19.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox19.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox19.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox19.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox19.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox19.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox19.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox19.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox19.Controls.Add(this.ElRadioButton34);
            this.ElGroupBox19.Controls.Add(this.ElRadioButton35);
            this.ElGroupBox19.Controls.Add(this.ElRadioButton36);
            this.ElGroupBox19.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox19.Name = "ElGroupBox19";
            this.ElGroupBox19.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox19.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox19.TabIndex = 16;
            this.ElGroupBox19.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton34
            // 
            this.ElRadioButton34.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton34.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton34.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton34.Name = "ElRadioButton34";
            this.ElRadioButton34.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton34.TabIndex = 20;
            this.ElRadioButton34.TabStop = false;
            this.ElRadioButton34.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton34.Value = false;
            // 
            // ElRadioButton35
            // 
            this.ElRadioButton35.Checked = true;
            this.ElRadioButton35.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton35.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton35.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton35.Name = "ElRadioButton35";
            this.ElRadioButton35.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton35.TabIndex = 18;
            this.ElRadioButton35.TextStyle.Text = "View By publication Name";
            this.ElRadioButton35.Value = true;
            // 
            // ElRadioButton36
            // 
            this.ElRadioButton36.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton36.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton36.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton36.Name = "ElRadioButton36";
            this.ElRadioButton36.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton36.TabIndex = 17;
            this.ElRadioButton36.TabStop = false;
            this.ElRadioButton36.TextStyle.Text = "View By Publisher";
            this.ElRadioButton36.Value = false;
            // 
            // ElPanel37
            // 
            this.ElPanel37.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel37.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel37.Controls.Add(this.SplitContainer36);
            this.ElPanel37.Controls.Add(this.ElGroupBox20);
            this.ElPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel37.Location = new System.Drawing.Point(0, 0);
            this.ElPanel37.Name = "ElPanel37";
            this.ElPanel37.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel37.Size = new System.Drawing.Size(191, 103);
            this.ElPanel37.TabIndex = 14;
            this.ElPanel37.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer36
            // 
            this.SplitContainer36.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer36.IsSplitterFixed = true;
            this.SplitContainer36.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer36.Name = "SplitContainer36";
            this.SplitContainer36.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer36.Panel1
            // 
            this.SplitContainer36.Panel1.Controls.Add(this.ElLabel13);
            // 
            // SplitContainer36.Panel2
            // 
            this.SplitContainer36.Panel2.Controls.Add(this.DataGridView2);
            this.SplitContainer36.Size = new System.Drawing.Size(191, 103);
            this.SplitContainer36.SplitterDistance = 25;
            this.SplitContainer36.TabIndex = 19;
            // 
            // ElLabel13
            // 
            this.ElLabel13.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle22.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle22.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel13.FlashStyle = paintStyle22;
            this.ElLabel13.Location = new System.Drawing.Point(0, 0);
            this.ElLabel13.Name = "ElLabel13";
            this.ElLabel13.Size = new System.Drawing.Size(191, 25);
            this.ElLabel13.TabIndex = 7;
            this.ElLabel13.TabStop = false;
            this.ElLabel13.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel13.TextStyle.Text = "Statistics";
            this.ElLabel13.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridView2
            // 
            this.DataGridView2.AllowUserToAddRows = false;
            this.DataGridView2.AllowUserToDeleteRows = false;
            this.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView2.Location = new System.Drawing.Point(0, 0);
            this.DataGridView2.Name = "DataGridView2";
            this.DataGridView2.ReadOnly = true;
            this.DataGridView2.Size = new System.Drawing.Size(191, 74);
            this.DataGridView2.TabIndex = 0;
            // 
            // ElGroupBox20
            // 
            this.ElGroupBox20.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox20.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox20.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox20.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox20.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox20.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox20.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox20.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox20.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox20.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox20.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox20.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox20.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox20.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox20.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox20.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox20.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox20.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox20.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox20.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox20.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox20.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox20.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox20.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox20.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox20.Controls.Add(this.ElRadioButton37);
            this.ElGroupBox20.Controls.Add(this.ElRadioButton38);
            this.ElGroupBox20.Controls.Add(this.ElRadioButton39);
            this.ElGroupBox20.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox20.Name = "ElGroupBox20";
            this.ElGroupBox20.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox20.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox20.TabIndex = 16;
            this.ElGroupBox20.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton37
            // 
            this.ElRadioButton37.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton37.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton37.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton37.Name = "ElRadioButton37";
            this.ElRadioButton37.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton37.TabIndex = 20;
            this.ElRadioButton37.TabStop = false;
            this.ElRadioButton37.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton37.Value = false;
            // 
            // ElRadioButton38
            // 
            this.ElRadioButton38.Checked = true;
            this.ElRadioButton38.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton38.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton38.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton38.Name = "ElRadioButton38";
            this.ElRadioButton38.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton38.TabIndex = 18;
            this.ElRadioButton38.TextStyle.Text = "View By publication Name";
            this.ElRadioButton38.Value = true;
            // 
            // ElRadioButton39
            // 
            this.ElRadioButton39.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton39.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton39.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton39.Name = "ElRadioButton39";
            this.ElRadioButton39.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton39.TabIndex = 17;
            this.ElRadioButton39.TabStop = false;
            this.ElRadioButton39.TextStyle.Text = "View By Publisher";
            this.ElRadioButton39.Value = false;
            // 
            // ElGroupBox21
            // 
            this.ElGroupBox21.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox21.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox21.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox21.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox21.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox21.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox21.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox21.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox21.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox21.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox21.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox21.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox21.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox21.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox21.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox21.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox21.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox21.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox21.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox21.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox21.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox21.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox21.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox21.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox21.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox21.Controls.Add(this.ElRadioButton40);
            this.ElGroupBox21.Controls.Add(this.ElRadioButton41);
            this.ElGroupBox21.Controls.Add(this.ElRadioButton42);
            this.ElGroupBox21.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox21.Name = "ElGroupBox21";
            this.ElGroupBox21.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox21.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox21.TabIndex = 16;
            this.ElGroupBox21.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton40
            // 
            this.ElRadioButton40.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton40.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton40.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton40.Name = "ElRadioButton40";
            this.ElRadioButton40.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton40.TabIndex = 20;
            this.ElRadioButton40.TabStop = false;
            this.ElRadioButton40.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton40.Value = false;
            // 
            // ElRadioButton41
            // 
            this.ElRadioButton41.Checked = true;
            this.ElRadioButton41.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton41.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton41.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton41.Name = "ElRadioButton41";
            this.ElRadioButton41.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton41.TabIndex = 18;
            this.ElRadioButton41.TextStyle.Text = "View By publication Name";
            this.ElRadioButton41.Value = true;
            // 
            // ElRadioButton42
            // 
            this.ElRadioButton42.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton42.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton42.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton42.Name = "ElRadioButton42";
            this.ElRadioButton42.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton42.TabIndex = 17;
            this.ElRadioButton42.TabStop = false;
            this.ElRadioButton42.TextStyle.Text = "View By Publisher";
            this.ElRadioButton42.Value = false;
            // 
            // TabPage12
            // 
            this.TabPage12.Controls.Add(this.ElPanel38);
            this.TabPage12.Location = new System.Drawing.Point(4, 25);
            this.TabPage12.Name = "TabPage12";
            this.TabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage12.Size = new System.Drawing.Size(584, 235);
            this.TabPage12.TabIndex = 1;
            this.TabPage12.Text = "Tree View";
            this.TabPage12.UseVisualStyleBackColor = true;
            // 
            // ElPanel38
            // 
            this.ElPanel38.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel38.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel38.Controls.Add(this.SplitContainer37);
            this.ElPanel38.Controls.Add(this.ElGroupBox22);
            this.ElPanel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel38.Location = new System.Drawing.Point(3, 3);
            this.ElPanel38.Name = "ElPanel38";
            this.ElPanel38.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel38.Size = new System.Drawing.Size(578, 229);
            this.ElPanel38.TabIndex = 13;
            this.ElPanel38.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer37
            // 
            this.SplitContainer37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer37.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer37.Name = "SplitContainer37";
            this.SplitContainer37.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer37.Panel1
            // 
            this.SplitContainer37.Panel1.Controls.Add(this.TreeView3);
            // 
            // SplitContainer37.Panel2
            // 
            this.SplitContainer37.Panel2.Controls.Add(this.SplitContainer38);
            this.SplitContainer37.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer37.SplitterDistance = 89;
            this.SplitContainer37.TabIndex = 18;
            // 
            // TreeView3
            // 
            this.TreeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView3.Location = new System.Drawing.Point(0, 0);
            this.TreeView3.Name = "TreeView3";
            this.TreeView3.Size = new System.Drawing.Size(578, 89);
            this.TreeView3.TabIndex = 0;
            // 
            // SplitContainer38
            // 
            this.SplitContainer38.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer38.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer38.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer38.Name = "SplitContainer38";
            // 
            // SplitContainer38.Panel2
            // 
            this.SplitContainer38.Panel2.Controls.Add(this.SplitContainer39);
            this.SplitContainer38.Size = new System.Drawing.Size(578, 136);
            this.SplitContainer38.SplitterDistance = 192;
            this.SplitContainer38.TabIndex = 0;
            // 
            // SplitContainer39
            // 
            this.SplitContainer39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer39.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer39.Name = "SplitContainer39";
            this.SplitContainer39.Size = new System.Drawing.Size(382, 136);
            this.SplitContainer39.SplitterDistance = 193;
            this.SplitContainer39.TabIndex = 0;
            // 
            // ElGroupBox22
            // 
            this.ElGroupBox22.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox22.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox22.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox22.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox22.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox22.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox22.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox22.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox22.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox22.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox22.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox22.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox22.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox22.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox22.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox22.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox22.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox22.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox22.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox22.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox22.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox22.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox22.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox22.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox22.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox22.Controls.Add(this.ElRadioButton43);
            this.ElGroupBox22.Controls.Add(this.ElRadioButton44);
            this.ElGroupBox22.Controls.Add(this.ElRadioButton45);
            this.ElGroupBox22.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox22.Name = "ElGroupBox22";
            this.ElGroupBox22.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox22.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox22.TabIndex = 16;
            this.ElGroupBox22.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton43
            // 
            this.ElRadioButton43.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton43.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton43.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton43.Name = "ElRadioButton43";
            this.ElRadioButton43.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton43.TabIndex = 20;
            this.ElRadioButton43.TabStop = false;
            this.ElRadioButton43.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton43.Value = false;
            // 
            // ElRadioButton44
            // 
            this.ElRadioButton44.Checked = true;
            this.ElRadioButton44.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton44.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton44.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton44.Name = "ElRadioButton44";
            this.ElRadioButton44.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton44.TabIndex = 18;
            this.ElRadioButton44.TextStyle.Text = "View By publication Name";
            this.ElRadioButton44.Value = true;
            // 
            // ElRadioButton45
            // 
            this.ElRadioButton45.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton45.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton45.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton45.Name = "ElRadioButton45";
            this.ElRadioButton45.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton45.TabIndex = 17;
            this.ElRadioButton45.TabStop = false;
            this.ElRadioButton45.TextStyle.Text = "View By Publisher";
            this.ElRadioButton45.Value = false;
            // 
            // ElPanel39
            // 
            this.ElPanel39.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel39.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel39.Controls.Add(this.SplitContainer51);
            this.ElPanel39.Controls.Add(this.TabControl6);
            this.ElPanel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel39.Location = new System.Drawing.Point(0, 0);
            this.ElPanel39.Name = "ElPanel39";
            this.ElPanel39.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel39.Size = new System.Drawing.Size(298, 201);
            this.ElPanel39.TabIndex = 17;
            this.ElPanel39.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer51
            // 
            this.SplitContainer51.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer51.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer51.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer51.IsSplitterFixed = true;
            this.SplitContainer51.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer51.Name = "SplitContainer51";
            this.SplitContainer51.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer51.Panel1
            // 
            this.SplitContainer51.Panel1.Controls.Add(this.SplitContainer54);
            // 
            // SplitContainer51.Panel2
            // 
            this.SplitContainer51.Panel2.Controls.Add(this.dgrPublicationDataUpdateStatisticsTreeView);
            this.SplitContainer51.Size = new System.Drawing.Size(298, 201);
            this.SplitContainer51.SplitterDistance = 36;
            this.SplitContainer51.TabIndex = 6;
            // 
            // SplitContainer54
            // 
            this.SplitContainer54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer54.IsSplitterFixed = true;
            this.SplitContainer54.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer54.Name = "SplitContainer54";
            // 
            // SplitContainer54.Panel1
            // 
            this.SplitContainer54.Panel1.Controls.Add(this.ElLabel5);
            // 
            // SplitContainer54.Panel2
            // 
            this.SplitContainer54.Panel2.Controls.Add(this.SplitContainer55);
            this.SplitContainer54.Size = new System.Drawing.Size(298, 36);
            this.SplitContainer54.SplitterDistance = 124;
            this.SplitContainer54.TabIndex = 1;
            // 
            // ElLabel5
            // 
            this.ElLabel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.ElLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle23.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle23.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel5.FlashStyle = paintStyle23;
            this.ElLabel5.ForegroundImageStyle.Image = global::My.Resources.Resources.Statistics;
            this.ElLabel5.Location = new System.Drawing.Point(0, 0);
            this.ElLabel5.Name = "ElLabel5";
            this.ElLabel5.Size = new System.Drawing.Size(124, 36);
            this.ElLabel5.TabIndex = 7;
            this.ElLabel5.TabStop = false;
            this.ElLabel5.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel5.TextStyle.Text = "Statistics";
            this.ElLabel5.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SplitContainer55
            // 
            this.SplitContainer55.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer55.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplitContainer55.IsSplitterFixed = true;
            this.SplitContainer55.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer55.Name = "SplitContainer55";
            // 
            // SplitContainer55.Panel1
            // 
            this.SplitContainer55.Panel1.Controls.Add(this.btnZoomPubsStatisticsTreeView);
            // 
            // SplitContainer55.Panel2
            // 
            this.SplitContainer55.Panel2.Controls.Add(this.SplitContainer3);
            this.SplitContainer55.Size = new System.Drawing.Size(170, 36);
            this.SplitContainer55.SplitterDistance = 46;
            this.SplitContainer55.TabIndex = 0;
            // 
            // btnZoomPubsStatisticsTreeView
            // 
            this.btnZoomPubsStatisticsTreeView.BackgroundImage = global::My.Resources.Resources.zoom_in;
            this.btnZoomPubsStatisticsTreeView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnZoomPubsStatisticsTreeView.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnZoomPubsStatisticsTreeView.Location = new System.Drawing.Point(0, 0);
            this.btnZoomPubsStatisticsTreeView.Name = "btnZoomPubsStatisticsTreeView";
            this.btnZoomPubsStatisticsTreeView.Size = new System.Drawing.Size(46, 36);
            this.btnZoomPubsStatisticsTreeView.TabIndex = 3;
            this.btnZoomPubsStatisticsTreeView.UseVisualStyleBackColor = true;
            this.btnZoomPubsStatisticsTreeView.Click += new System.EventHandler(this.btnZoomPubsStatisticsTreeView_Click);
            // 
            // SplitContainer3
            // 
            this.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer3.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer3.Name = "SplitContainer3";
            // 
            // SplitContainer3.Panel1
            // 
            this.SplitContainer3.Panel1.Controls.Add(this.btnPublicationsResumTreeViewStatisticsUpdate);
            // 
            // SplitContainer3.Panel2
            // 
            this.SplitContainer3.Panel2.Controls.Add(this.btnPublicationsResumTreeViewStatisticsReset);
            this.SplitContainer3.Size = new System.Drawing.Size(120, 36);
            this.SplitContainer3.SplitterDistance = 59;
            this.SplitContainer3.TabIndex = 0;
            // 
            // btnPublicationsResumTreeViewStatisticsUpdate
            // 
            this.btnPublicationsResumTreeViewStatisticsUpdate.BackgroundStyle.GradientEndColor = System.Drawing.Color.Lime;
            this.btnPublicationsResumTreeViewStatisticsUpdate.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPublicationsResumTreeViewStatisticsUpdate.BorderStyle.EdgeRadius = 7;
            this.btnPublicationsResumTreeViewStatisticsUpdate.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnPublicationsResumTreeViewStatisticsUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublicationsResumTreeViewStatisticsUpdate.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnPublicationsResumTreeViewStatisticsUpdate.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnPublicationsResumTreeViewStatisticsUpdate.ForegroundImageStyle.Image = global::My.Resources.Resources.reload;
            this.btnPublicationsResumTreeViewStatisticsUpdate.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublicationsResumTreeViewStatisticsUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnPublicationsResumTreeViewStatisticsUpdate.Name = "btnPublicationsResumTreeViewStatisticsUpdate";
            this.btnPublicationsResumTreeViewStatisticsUpdate.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.btnPublicationsResumTreeViewStatisticsUpdate.Size = new System.Drawing.Size(59, 36);
            this.btnPublicationsResumTreeViewStatisticsUpdate.TabIndex = 7;
            this.btnPublicationsResumTreeViewStatisticsUpdate.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicationsResumTreeViewStatisticsUpdate.TextStyle.Text = "Update";
            this.btnPublicationsResumTreeViewStatisticsUpdate.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnPublicationsResumTreeViewStatisticsUpdate.Click += new System.EventHandler(this.btnPublicationsResumTreeViewStatisticsUpdate_Click);
            // 
            // btnPublicationsResumTreeViewStatisticsReset
            // 
            this.btnPublicationsResumTreeViewStatisticsReset.BackgroundStyle.GradientEndColor = System.Drawing.Color.Lime;
            this.btnPublicationsResumTreeViewStatisticsReset.BackgroundStyle.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPublicationsResumTreeViewStatisticsReset.BorderStyle.EdgeRadius = 7;
            this.btnPublicationsResumTreeViewStatisticsReset.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnPublicationsResumTreeViewStatisticsReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPublicationsResumTreeViewStatisticsReset.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnPublicationsResumTreeViewStatisticsReset.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnPublicationsResumTreeViewStatisticsReset.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPublicationsResumTreeViewStatisticsReset.Location = new System.Drawing.Point(0, 0);
            this.btnPublicationsResumTreeViewStatisticsReset.Name = "btnPublicationsResumTreeViewStatisticsReset";
            this.btnPublicationsResumTreeViewStatisticsReset.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.btnPublicationsResumTreeViewStatisticsReset.Size = new System.Drawing.Size(57, 36);
            this.btnPublicationsResumTreeViewStatisticsReset.TabIndex = 8;
            this.btnPublicationsResumTreeViewStatisticsReset.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublicationsResumTreeViewStatisticsReset.TextStyle.Text = "Reset";
            this.btnPublicationsResumTreeViewStatisticsReset.VisualStyle = Klik.Windows.Forms.v1.EntryLib.ButtonVisualStyles.Custom;
            this.btnPublicationsResumTreeViewStatisticsReset.Click += new System.EventHandler(this.btnPublicationsResumTreeViewStatisticsReset_Click);
            // 
            // dgrPublicationDataUpdateStatisticsTreeView
            // 
            this.dgrPublicationDataUpdateStatisticsTreeView.AllowUserToAddRows = false;
            this.dgrPublicationDataUpdateStatisticsTreeView.AllowUserToDeleteRows = false;
            this.dgrPublicationDataUpdateStatisticsTreeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrPublicationDataUpdateStatisticsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrPublicationDataUpdateStatisticsTreeView.Location = new System.Drawing.Point(0, 0);
            this.dgrPublicationDataUpdateStatisticsTreeView.Name = "dgrPublicationDataUpdateStatisticsTreeView";
            this.dgrPublicationDataUpdateStatisticsTreeView.ReadOnly = true;
            this.dgrPublicationDataUpdateStatisticsTreeView.Size = new System.Drawing.Size(298, 161);
            this.dgrPublicationDataUpdateStatisticsTreeView.TabIndex = 0;
            // 
            // TabControl6
            // 
            this.TabControl6.Controls.Add(this.TabPage13);
            this.TabControl6.Controls.Add(this.TabPage14);
            this.TabControl6.Location = new System.Drawing.Point(0, 367);
            this.TabControl6.Name = "TabControl6";
            this.TabControl6.SelectedIndex = 0;
            this.TabControl6.Size = new System.Drawing.Size(592, 264);
            this.TabControl6.TabIndex = 3;
            // 
            // TabPage13
            // 
            this.TabPage13.Controls.Add(this.ElPanel40);
            this.TabPage13.Location = new System.Drawing.Point(4, 25);
            this.TabPage13.Name = "TabPage13";
            this.TabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage13.Size = new System.Drawing.Size(584, 235);
            this.TabPage13.TabIndex = 0;
            this.TabPage13.Text = "Publications Resume";
            this.TabPage13.UseVisualStyleBackColor = true;
            // 
            // ElPanel40
            // 
            this.ElPanel40.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel40.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel40.Controls.Add(this.SplitContainer40);
            this.ElPanel40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel40.Location = new System.Drawing.Point(3, 3);
            this.ElPanel40.Name = "ElPanel40";
            this.ElPanel40.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel40.Size = new System.Drawing.Size(578, 229);
            this.ElPanel40.TabIndex = 13;
            this.ElPanel40.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer40
            // 
            this.SplitContainer40.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer40.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer40.Name = "SplitContainer40";
            this.SplitContainer40.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer40.Panel1
            // 
            this.SplitContainer40.Panel1.Controls.Add(this.ListView7);
            // 
            // SplitContainer40.Panel2
            // 
            this.SplitContainer40.Panel2.Controls.Add(this.SplitContainer41);
            this.SplitContainer40.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer40.SplitterDistance = 114;
            this.SplitContainer40.TabIndex = 4;
            // 
            // ListView7
            // 
            this.ListView7.BackColor = System.Drawing.Color.LemonChiffon;
            this.ListView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView7.Location = new System.Drawing.Point(0, 0);
            this.ListView7.Name = "ListView7";
            this.ListView7.Size = new System.Drawing.Size(578, 114);
            this.ListView7.TabIndex = 2;
            this.ListView7.UseCompatibleStateImageBehavior = false;
            // 
            // SplitContainer41
            // 
            this.SplitContainer41.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer41.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer41.Name = "SplitContainer41";
            // 
            // SplitContainer41.Panel1
            // 
            this.SplitContainer41.Panel1.Controls.Add(this.ElPanel41);
            // 
            // SplitContainer41.Panel2
            // 
            this.SplitContainer41.Panel2.Controls.Add(this.ElPanel42);
            this.SplitContainer41.Size = new System.Drawing.Size(578, 111);
            this.SplitContainer41.SplitterDistance = 173;
            this.SplitContainer41.TabIndex = 0;
            // 
            // ElPanel41
            // 
            this.ElPanel41.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel41.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel41.Controls.Add(this.SplitContainer42);
            this.ElPanel41.Controls.Add(this.ElGroupBox23);
            this.ElPanel41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel41.Location = new System.Drawing.Point(0, 0);
            this.ElPanel41.Name = "ElPanel41";
            this.ElPanel41.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel41.Size = new System.Drawing.Size(169, 107);
            this.ElPanel41.TabIndex = 14;
            this.ElPanel41.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer42
            // 
            this.SplitContainer42.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer42.IsSplitterFixed = true;
            this.SplitContainer42.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer42.Name = "SplitContainer42";
            this.SplitContainer42.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer42.Panel1
            // 
            this.SplitContainer42.Panel1.Controls.Add(this.ElLabel14);
            // 
            // SplitContainer42.Panel2
            // 
            this.SplitContainer42.Panel2.Controls.Add(this.ListView8);
            this.SplitContainer42.Size = new System.Drawing.Size(169, 107);
            this.SplitContainer42.SplitterDistance = 25;
            this.SplitContainer42.TabIndex = 18;
            // 
            // ElLabel14
            // 
            this.ElLabel14.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle24.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle24.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel14.FlashStyle = paintStyle24;
            this.ElLabel14.Location = new System.Drawing.Point(0, 0);
            this.ElLabel14.Name = "ElLabel14";
            this.ElLabel14.Size = new System.Drawing.Size(169, 25);
            this.ElLabel14.TabIndex = 7;
            this.ElLabel14.TabStop = false;
            this.ElLabel14.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel14.TextStyle.Text = "Publication Variables";
            this.ElLabel14.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView8
            // 
            this.ListView8.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView8.FullRowSelect = true;
            this.ListView8.GridLines = true;
            this.ListView8.HideSelection = false;
            this.ListView8.Location = new System.Drawing.Point(0, 0);
            this.ListView8.MultiSelect = false;
            this.ListView8.Name = "ListView8";
            this.ListView8.Size = new System.Drawing.Size(169, 78);
            this.ListView8.TabIndex = 3;
            this.ListView8.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox23
            // 
            this.ElGroupBox23.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox23.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox23.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox23.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox23.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox23.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox23.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox23.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox23.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox23.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox23.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox23.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox23.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox23.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox23.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox23.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox23.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox23.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox23.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox23.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox23.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox23.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox23.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox23.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox23.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox23.Controls.Add(this.ElRadioButton46);
            this.ElGroupBox23.Controls.Add(this.ElRadioButton47);
            this.ElGroupBox23.Controls.Add(this.ElRadioButton48);
            this.ElGroupBox23.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox23.Name = "ElGroupBox23";
            this.ElGroupBox23.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox23.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox23.TabIndex = 16;
            this.ElGroupBox23.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton46
            // 
            this.ElRadioButton46.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton46.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton46.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton46.Name = "ElRadioButton46";
            this.ElRadioButton46.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton46.TabIndex = 20;
            this.ElRadioButton46.TabStop = false;
            this.ElRadioButton46.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton46.Value = false;
            // 
            // ElRadioButton47
            // 
            this.ElRadioButton47.Checked = true;
            this.ElRadioButton47.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton47.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton47.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton47.Name = "ElRadioButton47";
            this.ElRadioButton47.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton47.TabIndex = 18;
            this.ElRadioButton47.TextStyle.Text = "View By publication Name";
            this.ElRadioButton47.Value = true;
            // 
            // ElRadioButton48
            // 
            this.ElRadioButton48.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton48.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton48.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton48.Name = "ElRadioButton48";
            this.ElRadioButton48.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton48.TabIndex = 17;
            this.ElRadioButton48.TabStop = false;
            this.ElRadioButton48.TextStyle.Text = "View By Publisher";
            this.ElRadioButton48.Value = false;
            // 
            // ElPanel42
            // 
            this.ElPanel42.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel42.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel42.Controls.Add(this.SplitContainer43);
            this.ElPanel42.Controls.Add(this.ElGroupBox26);
            this.ElPanel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel42.Location = new System.Drawing.Point(0, 0);
            this.ElPanel42.Name = "ElPanel42";
            this.ElPanel42.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel42.Size = new System.Drawing.Size(397, 107);
            this.ElPanel42.TabIndex = 14;
            this.ElPanel42.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer43
            // 
            this.SplitContainer43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer43.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer43.Name = "SplitContainer43";
            // 
            // SplitContainer43.Panel1
            // 
            this.SplitContainer43.Panel1.Controls.Add(this.ElPanel43);
            // 
            // SplitContainer43.Panel2
            // 
            this.SplitContainer43.Panel2.Controls.Add(this.ElPanel44);
            this.SplitContainer43.Size = new System.Drawing.Size(397, 107);
            this.SplitContainer43.SplitterDistance = 198;
            this.SplitContainer43.TabIndex = 18;
            // 
            // ElPanel43
            // 
            this.ElPanel43.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel43.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel43.Controls.Add(this.SplitContainer44);
            this.ElPanel43.Controls.Add(this.ElGroupBox24);
            this.ElPanel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel43.Location = new System.Drawing.Point(0, 0);
            this.ElPanel43.Name = "ElPanel43";
            this.ElPanel43.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel43.Size = new System.Drawing.Size(194, 103);
            this.ElPanel43.TabIndex = 14;
            this.ElPanel43.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer44
            // 
            this.SplitContainer44.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer44.IsSplitterFixed = true;
            this.SplitContainer44.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer44.Name = "SplitContainer44";
            this.SplitContainer44.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer44.Panel1
            // 
            this.SplitContainer44.Panel1.Controls.Add(this.ElLabel15);
            // 
            // SplitContainer44.Panel2
            // 
            this.SplitContainer44.Panel2.Controls.Add(this.ListView9);
            this.SplitContainer44.Size = new System.Drawing.Size(194, 103);
            this.SplitContainer44.SplitterDistance = 25;
            this.SplitContainer44.TabIndex = 19;
            // 
            // ElLabel15
            // 
            this.ElLabel15.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle25.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle25.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel15.FlashStyle = paintStyle25;
            this.ElLabel15.Location = new System.Drawing.Point(0, 0);
            this.ElLabel15.Name = "ElLabel15";
            this.ElLabel15.Size = new System.Drawing.Size(194, 25);
            this.ElLabel15.TabIndex = 7;
            this.ElLabel15.TabStop = false;
            this.ElLabel15.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel15.TextStyle.Text = "Connected Clients";
            this.ElLabel15.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListView9
            // 
            this.ListView9.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListView9.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ListView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView9.FullRowSelect = true;
            this.ListView9.GridLines = true;
            this.ListView9.HideSelection = false;
            this.ListView9.Location = new System.Drawing.Point(0, 0);
            this.ListView9.MultiSelect = false;
            this.ListView9.Name = "ListView9";
            this.ListView9.Size = new System.Drawing.Size(194, 74);
            this.ListView9.TabIndex = 3;
            this.ListView9.UseCompatibleStateImageBehavior = false;
            // 
            // ElGroupBox24
            // 
            this.ElGroupBox24.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox24.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox24.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox24.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox24.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox24.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox24.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox24.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox24.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox24.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox24.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox24.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox24.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox24.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox24.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox24.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox24.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox24.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox24.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox24.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox24.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox24.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox24.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox24.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox24.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox24.Controls.Add(this.ElRadioButton49);
            this.ElGroupBox24.Controls.Add(this.ElRadioButton50);
            this.ElGroupBox24.Controls.Add(this.ElRadioButton51);
            this.ElGroupBox24.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox24.Name = "ElGroupBox24";
            this.ElGroupBox24.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox24.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox24.TabIndex = 16;
            this.ElGroupBox24.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton49
            // 
            this.ElRadioButton49.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton49.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton49.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton49.Name = "ElRadioButton49";
            this.ElRadioButton49.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton49.TabIndex = 20;
            this.ElRadioButton49.TabStop = false;
            this.ElRadioButton49.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton49.Value = false;
            // 
            // ElRadioButton50
            // 
            this.ElRadioButton50.Checked = true;
            this.ElRadioButton50.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton50.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton50.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton50.Name = "ElRadioButton50";
            this.ElRadioButton50.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton50.TabIndex = 18;
            this.ElRadioButton50.TextStyle.Text = "View By publication Name";
            this.ElRadioButton50.Value = true;
            // 
            // ElRadioButton51
            // 
            this.ElRadioButton51.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton51.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton51.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton51.Name = "ElRadioButton51";
            this.ElRadioButton51.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton51.TabIndex = 17;
            this.ElRadioButton51.TabStop = false;
            this.ElRadioButton51.TextStyle.Text = "View By Publisher";
            this.ElRadioButton51.Value = false;
            // 
            // ElPanel44
            // 
            this.ElPanel44.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel44.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel44.Controls.Add(this.SplitContainer45);
            this.ElPanel44.Controls.Add(this.ElGroupBox25);
            this.ElPanel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel44.Location = new System.Drawing.Point(0, 0);
            this.ElPanel44.Name = "ElPanel44";
            this.ElPanel44.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel44.Size = new System.Drawing.Size(191, 103);
            this.ElPanel44.TabIndex = 14;
            this.ElPanel44.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer45
            // 
            this.SplitContainer45.BackColor = System.Drawing.Color.Transparent;
            this.SplitContainer45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer45.IsSplitterFixed = true;
            this.SplitContainer45.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer45.Name = "SplitContainer45";
            this.SplitContainer45.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer45.Panel1
            // 
            this.SplitContainer45.Panel1.Controls.Add(this.ElLabel16);
            // 
            // SplitContainer45.Panel2
            // 
            this.SplitContainer45.Panel2.Controls.Add(this.DataGridView3);
            this.SplitContainer45.Size = new System.Drawing.Size(191, 103);
            this.SplitContainer45.SplitterDistance = 25;
            this.SplitContainer45.TabIndex = 19;
            // 
            // ElLabel16
            // 
            this.ElLabel16.Dock = System.Windows.Forms.DockStyle.Fill;
            paintStyle26.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            paintStyle26.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElLabel16.FlashStyle = paintStyle26;
            this.ElLabel16.Location = new System.Drawing.Point(0, 0);
            this.ElLabel16.Name = "ElLabel16";
            this.ElLabel16.Size = new System.Drawing.Size(191, 25);
            this.ElLabel16.TabIndex = 7;
            this.ElLabel16.TabStop = false;
            this.ElLabel16.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElLabel16.TextStyle.Text = "Statistics";
            this.ElLabel16.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridView3
            // 
            this.DataGridView3.AllowUserToAddRows = false;
            this.DataGridView3.AllowUserToDeleteRows = false;
            this.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView3.Location = new System.Drawing.Point(0, 0);
            this.DataGridView3.Name = "DataGridView3";
            this.DataGridView3.ReadOnly = true;
            this.DataGridView3.Size = new System.Drawing.Size(191, 74);
            this.DataGridView3.TabIndex = 0;
            // 
            // ElGroupBox25
            // 
            this.ElGroupBox25.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox25.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox25.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox25.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox25.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox25.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox25.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox25.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox25.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox25.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox25.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox25.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox25.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox25.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox25.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox25.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox25.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox25.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox25.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox25.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox25.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox25.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox25.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox25.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox25.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox25.Controls.Add(this.ElRadioButton52);
            this.ElGroupBox25.Controls.Add(this.ElRadioButton53);
            this.ElGroupBox25.Controls.Add(this.ElRadioButton54);
            this.ElGroupBox25.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox25.Name = "ElGroupBox25";
            this.ElGroupBox25.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox25.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox25.TabIndex = 16;
            this.ElGroupBox25.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton52
            // 
            this.ElRadioButton52.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton52.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton52.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton52.Name = "ElRadioButton52";
            this.ElRadioButton52.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton52.TabIndex = 20;
            this.ElRadioButton52.TabStop = false;
            this.ElRadioButton52.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton52.Value = false;
            // 
            // ElRadioButton53
            // 
            this.ElRadioButton53.Checked = true;
            this.ElRadioButton53.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton53.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton53.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton53.Name = "ElRadioButton53";
            this.ElRadioButton53.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton53.TabIndex = 18;
            this.ElRadioButton53.TextStyle.Text = "View By publication Name";
            this.ElRadioButton53.Value = true;
            // 
            // ElRadioButton54
            // 
            this.ElRadioButton54.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton54.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton54.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton54.Name = "ElRadioButton54";
            this.ElRadioButton54.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton54.TabIndex = 17;
            this.ElRadioButton54.TabStop = false;
            this.ElRadioButton54.TextStyle.Text = "View By Publisher";
            this.ElRadioButton54.Value = false;
            // 
            // ElGroupBox26
            // 
            this.ElGroupBox26.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox26.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox26.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox26.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox26.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox26.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox26.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox26.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox26.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox26.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox26.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox26.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox26.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox26.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox26.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox26.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox26.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox26.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox26.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox26.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox26.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox26.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox26.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox26.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox26.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox26.Controls.Add(this.ElRadioButton55);
            this.ElGroupBox26.Controls.Add(this.ElRadioButton56);
            this.ElGroupBox26.Controls.Add(this.ElRadioButton57);
            this.ElGroupBox26.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox26.Name = "ElGroupBox26";
            this.ElGroupBox26.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox26.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox26.TabIndex = 16;
            this.ElGroupBox26.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton55
            // 
            this.ElRadioButton55.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton55.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton55.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton55.Name = "ElRadioButton55";
            this.ElRadioButton55.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton55.TabIndex = 20;
            this.ElRadioButton55.TabStop = false;
            this.ElRadioButton55.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton55.Value = false;
            // 
            // ElRadioButton56
            // 
            this.ElRadioButton56.Checked = true;
            this.ElRadioButton56.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton56.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton56.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton56.Name = "ElRadioButton56";
            this.ElRadioButton56.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton56.TabIndex = 18;
            this.ElRadioButton56.TextStyle.Text = "View By publication Name";
            this.ElRadioButton56.Value = true;
            // 
            // ElRadioButton57
            // 
            this.ElRadioButton57.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton57.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton57.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton57.Name = "ElRadioButton57";
            this.ElRadioButton57.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton57.TabIndex = 17;
            this.ElRadioButton57.TabStop = false;
            this.ElRadioButton57.TextStyle.Text = "View By Publisher";
            this.ElRadioButton57.Value = false;
            // 
            // TabPage14
            // 
            this.TabPage14.Controls.Add(this.ElPanel45);
            this.TabPage14.Location = new System.Drawing.Point(4, 25);
            this.TabPage14.Name = "TabPage14";
            this.TabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage14.Size = new System.Drawing.Size(584, 235);
            this.TabPage14.TabIndex = 1;
            this.TabPage14.Text = "Tree View";
            this.TabPage14.UseVisualStyleBackColor = true;
            // 
            // ElPanel45
            // 
            this.ElPanel45.BackgroundStyle.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ElPanel45.BackgroundStyle.GradientStartColor = System.Drawing.Color.Silver;
            this.ElPanel45.Controls.Add(this.SplitContainer46);
            this.ElPanel45.Controls.Add(this.ElGroupBox27);
            this.ElPanel45.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElPanel45.Location = new System.Drawing.Point(3, 3);
            this.ElPanel45.Name = "ElPanel45";
            this.ElPanel45.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElPanel45.Size = new System.Drawing.Size(578, 229);
            this.ElPanel45.TabIndex = 13;
            this.ElPanel45.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // SplitContainer46
            // 
            this.SplitContainer46.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer46.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer46.Name = "SplitContainer46";
            this.SplitContainer46.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer46.Panel1
            // 
            this.SplitContainer46.Panel1.Controls.Add(this.TreeView4);
            // 
            // SplitContainer46.Panel2
            // 
            this.SplitContainer46.Panel2.Controls.Add(this.SplitContainer47);
            this.SplitContainer46.Size = new System.Drawing.Size(578, 229);
            this.SplitContainer46.SplitterDistance = 89;
            this.SplitContainer46.TabIndex = 18;
            // 
            // TreeView4
            // 
            this.TreeView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView4.Location = new System.Drawing.Point(0, 0);
            this.TreeView4.Name = "TreeView4";
            this.TreeView4.Size = new System.Drawing.Size(578, 89);
            this.TreeView4.TabIndex = 0;
            // 
            // SplitContainer47
            // 
            this.SplitContainer47.BackColor = System.Drawing.SystemColors.Control;
            this.SplitContainer47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer47.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer47.Name = "SplitContainer47";
            // 
            // SplitContainer47.Panel2
            // 
            this.SplitContainer47.Panel2.Controls.Add(this.SplitContainer48);
            this.SplitContainer47.Size = new System.Drawing.Size(578, 136);
            this.SplitContainer47.SplitterDistance = 192;
            this.SplitContainer47.TabIndex = 0;
            // 
            // SplitContainer48
            // 
            this.SplitContainer48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer48.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer48.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer48.Name = "SplitContainer48";
            this.SplitContainer48.Size = new System.Drawing.Size(382, 136);
            this.SplitContainer48.SplitterDistance = 193;
            this.SplitContainer48.TabIndex = 0;
            // 
            // ElGroupBox27
            // 
            this.ElGroupBox27.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox27.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox27.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox27.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox27.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox27.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox27.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox27.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox27.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox27.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox27.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox27.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox27.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox27.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox27.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox27.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox27.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox27.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox27.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox27.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox27.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox27.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox27.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox27.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox27.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox27.Controls.Add(this.ElRadioButton58);
            this.ElGroupBox27.Controls.Add(this.ElRadioButton59);
            this.ElGroupBox27.Controls.Add(this.ElRadioButton60);
            this.ElGroupBox27.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox27.Name = "ElGroupBox27";
            this.ElGroupBox27.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox27.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox27.TabIndex = 16;
            this.ElGroupBox27.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton58
            // 
            this.ElRadioButton58.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton58.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton58.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton58.Name = "ElRadioButton58";
            this.ElRadioButton58.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton58.TabIndex = 20;
            this.ElRadioButton58.TabStop = false;
            this.ElRadioButton58.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton58.Value = false;
            // 
            // ElRadioButton59
            // 
            this.ElRadioButton59.Checked = true;
            this.ElRadioButton59.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton59.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton59.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton59.Name = "ElRadioButton59";
            this.ElRadioButton59.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton59.TabIndex = 18;
            this.ElRadioButton59.TextStyle.Text = "View By publication Name";
            this.ElRadioButton59.Value = true;
            // 
            // ElRadioButton60
            // 
            this.ElRadioButton60.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton60.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton60.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton60.Name = "ElRadioButton60";
            this.ElRadioButton60.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton60.TabIndex = 17;
            this.ElRadioButton60.TabStop = false;
            this.ElRadioButton60.TextStyle.Text = "View By Publisher";
            this.ElRadioButton60.Value = false;
            // 
            // ElGroupBox3
            // 
            this.ElGroupBox3.BackgroundStyle.GradientAngle = 45F;
            this.ElGroupBox3.BackgroundStyle.GradientEndColor = System.Drawing.Color.Silver;
            this.ElGroupBox3.BackgroundStyle.GradientStartColor = System.Drawing.Color.Gray;
            this.ElGroupBox3.BorderStyle.SolidColor = System.Drawing.Color.Yellow;
            this.ElGroupBox3.CaptionStyle.BackgroundStyle.GradientEndColor = System.Drawing.Color.Gray;
            this.ElGroupBox3.CaptionStyle.BackgroundStyle.GradientStartColor = System.Drawing.Color.Black;
            this.ElGroupBox3.CaptionStyle.BackgroundStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox3.CaptionStyle.BackgroundStyle.SolidColor = System.Drawing.Color.Black;
            this.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.BottomLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.BottomRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.TopLeft = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox3.CaptionStyle.BorderStyle.BorderShape.TopRight = Klik.Windows.Forms.v1.Common.BorderShapes.Circle;
            this.ElGroupBox3.CaptionStyle.BorderStyle.BorderType = Klik.Windows.Forms.v1.Common.BorderTypes.None;
            this.ElGroupBox3.CaptionStyle.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElGroupBox3.CaptionStyle.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElGroupBox3.CaptionStyle.Office2003Scheme = Klik.Windows.Forms.v1.Common.Office2003Schemes.ClientArea;
            this.ElGroupBox3.CaptionStyle.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ModernBlack;
            this.ElGroupBox3.CaptionStyle.Size = new System.Drawing.Size(200, 20);
            this.ElGroupBox3.CaptionStyle.TextStyle.BackColor = System.Drawing.SystemColors.ControlText;
            this.ElGroupBox3.CaptionStyle.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ElGroupBox3.CaptionStyle.TextStyle.ForeColor = System.Drawing.SystemColors.Window;
            this.ElGroupBox3.CaptionStyle.TextStyle.Text = "View Options";
            this.ElGroupBox3.CaptionStyle.TextStyle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ElGroupBox3.CaptionStyle.TextStyle.TextType = Klik.Windows.Forms.v1.Common.TextTypes.BlockShadow;
            this.ElGroupBox3.CaptionStyle.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            this.ElGroupBox3.Controls.Add(this.ElRadioButton7);
            this.ElGroupBox3.Controls.Add(this.ElRadioButton5);
            this.ElGroupBox3.Controls.Add(this.ElRadioButton6);
            this.ElGroupBox3.Location = new System.Drawing.Point(1, 486);
            this.ElGroupBox3.Name = "ElGroupBox3";
            this.ElGroupBox3.Padding = new System.Windows.Forms.Padding(4, 23, 4, 3);
            this.ElGroupBox3.Size = new System.Drawing.Size(730, 61);
            this.ElGroupBox3.TabIndex = 16;
            this.ElGroupBox3.VisualStyle = Klik.Windows.Forms.v1.Common.ControlVisualStyles.Custom;
            // 
            // ElRadioButton7
            // 
            this.ElRadioButton7.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton7.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton7.Location = new System.Drawing.Point(369, 26);
            this.ElRadioButton7.Name = "ElRadioButton7";
            this.ElRadioButton7.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton7.TabIndex = 20;
            this.ElRadioButton7.TabStop = false;
            this.ElRadioButton7.TextStyle.Text = "View By Publisher Host";
            this.ElRadioButton7.Value = false;
            // 
            // ElRadioButton5
            // 
            this.ElRadioButton5.Checked = true;
            this.ElRadioButton5.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton5.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton5.Location = new System.Drawing.Point(12, 26);
            this.ElRadioButton5.Name = "ElRadioButton5";
            this.ElRadioButton5.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton5.TabIndex = 18;
            this.ElRadioButton5.TextStyle.Text = "View By publication Name";
            this.ElRadioButton5.Value = true;
            // 
            // ElRadioButton6
            // 
            this.ElRadioButton6.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.ElRadioButton6.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.ElRadioButton6.Location = new System.Drawing.Point(190, 26);
            this.ElRadioButton6.Name = "ElRadioButton6";
            this.ElRadioButton6.Size = new System.Drawing.Size(163, 23);
            this.ElRadioButton6.TabIndex = 17;
            this.ElRadioButton6.TabStop = false;
            this.ElRadioButton6.TextStyle.Text = "View By Publisher";
            this.ElRadioButton6.Value = false;
            // 
            // TabPage15
            // 
            this.TabPage15.Controls.Add(this.btnClearLog);
            this.TabPage15.Controls.Add(this.lstSTXEventLog);
            this.TabPage15.Location = new System.Drawing.Point(4, 28);
            this.TabPage15.Name = "TabPage15";
            this.TabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage15.Size = new System.Drawing.Size(936, 456);
            this.TabPage15.TabIndex = 3;
            this.TabPage15.Text = "STX Event Log";
            this.TabPage15.UseVisualStyleBackColor = true;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.BorderStyle.EdgeRadius = 7;
            this.btnClearLog.BorderStyle.SmoothingMode = Klik.Windows.Forms.v1.Common.SmoothingModes.AntiAlias;
            this.btnClearLog.FlashStyle.PaintType = Klik.Windows.Forms.v1.Common.PaintTypes.Solid;
            this.btnClearLog.FlashStyle.SolidColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(240)))), ((int)(((byte)(191)))));
            this.btnClearLog.ForegroundImageStyle.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClearLog.Location = new System.Drawing.Point(805, 421);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Office2007Scheme = Klik.Windows.Forms.v1.Common.Office2007Schemes.ClassicBlue;
            this.btnClearLog.Size = new System.Drawing.Size(128, 32);
            this.btnClearLog.TabIndex = 7;
            this.btnClearLog.TextStyle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.TextStyle.Text = "Clear Log";
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // lstSTXEventLog
            // 
            this.lstSTXEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSTXEventLog.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSTXEventLog.FormattingEnabled = true;
            this.lstSTXEventLog.ItemHeight = 16;
            this.lstSTXEventLog.Location = new System.Drawing.Point(0, 0);
            this.lstSTXEventLog.Name = "lstSTXEventLog";
            this.lstSTXEventLog.Size = new System.Drawing.Size(936, 404);
            this.lstSTXEventLog.TabIndex = 0;
            this.lstSTXEventLog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSTXEventLog_MouseDoubleClick);
            // 
            // TabPage20
            // 
            this.TabPage20.Controls.Add(this.SplitContainer11);
            this.TabPage20.Location = new System.Drawing.Point(4, 28);
            this.TabPage20.Name = "TabPage20";
            this.TabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage20.Size = new System.Drawing.Size(936, 456);
            this.TabPage20.TabIndex = 4;
            this.TabPage20.Text = "Networking Statistics";
            this.TabPage20.UseVisualStyleBackColor = true;
            // 
            // SplitContainer11
            // 
            this.SplitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer11.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SplitContainer11.IsSplitterFixed = true;
            this.SplitContainer11.Location = new System.Drawing.Point(3, 3);
            this.SplitContainer11.Name = "SplitContainer11";
            this.SplitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer11.Panel1
            // 
            this.SplitContainer11.Panel1.Controls.Add(this.TabControl5);
            // 
            // SplitContainer11.Panel2
            // 
            this.SplitContainer11.Panel2.Controls.Add(this.btnUpdate);
            this.SplitContainer11.Size = new System.Drawing.Size(930, 450);
            this.SplitContainer11.SplitterDistance = 404;
            this.SplitContainer11.TabIndex = 8;
            // 
            // TabControl5
            // 
            this.TabControl5.Controls.Add(this.TabPage21);
            this.TabControl5.Controls.Add(this.TabPage22);
            this.TabControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl5.Location = new System.Drawing.Point(0, 0);
            this.TabControl5.Name = "TabControl5";
            this.TabControl5.SelectedIndex = 0;
            this.TabControl5.Size = new System.Drawing.Size(930, 404);
            this.TabControl5.TabIndex = 7;
            // 
            // TabPage21
            // 
            this.TabPage21.Controls.Add(this.dgrdNetworkStatisticsIPv4);
            this.TabPage21.Location = new System.Drawing.Point(4, 25);
            this.TabPage21.Name = "TabPage21";
            this.TabPage21.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage21.Size = new System.Drawing.Size(922, 375);
            this.TabPage21.TabIndex = 0;
            this.TabPage21.Text = "IPv4";
            this.TabPage21.UseVisualStyleBackColor = true;
            // 
            // dgrdNetworkStatisticsIPv4
            // 
            this.dgrdNetworkStatisticsIPv4.AllowUserToAddRows = false;
            this.dgrdNetworkStatisticsIPv4.AllowUserToDeleteRows = false;
            this.dgrdNetworkStatisticsIPv4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdNetworkStatisticsIPv4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdNetworkStatisticsIPv4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNetworkStatisticsIPv4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdNetworkStatisticsIPv4.Location = new System.Drawing.Point(3, 3);
            this.dgrdNetworkStatisticsIPv4.MultiSelect = false;
            this.dgrdNetworkStatisticsIPv4.Name = "dgrdNetworkStatisticsIPv4";
            this.dgrdNetworkStatisticsIPv4.ReadOnly = true;
            this.dgrdNetworkStatisticsIPv4.Size = new System.Drawing.Size(916, 369);
            this.dgrdNetworkStatisticsIPv4.TabIndex = 0;
            // 
            // TabPage22
            // 
            this.TabPage22.Controls.Add(this.dgrdNetworkStatisticsIPv6);
            this.TabPage22.Location = new System.Drawing.Point(4, 25);
            this.TabPage22.Name = "TabPage22";
            this.TabPage22.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage22.Size = new System.Drawing.Size(922, 375);
            this.TabPage22.TabIndex = 1;
            this.TabPage22.Text = "IPv6";
            this.TabPage22.UseVisualStyleBackColor = true;
            // 
            // dgrdNetworkStatisticsIPv6
            // 
            this.dgrdNetworkStatisticsIPv6.AllowUserToAddRows = false;
            this.dgrdNetworkStatisticsIPv6.AllowUserToDeleteRows = false;
            this.dgrdNetworkStatisticsIPv6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgrdNetworkStatisticsIPv6.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgrdNetworkStatisticsIPv6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdNetworkStatisticsIPv6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgrdNetworkStatisticsIPv6.Location = new System.Drawing.Point(3, 3);
            this.dgrdNetworkStatisticsIPv6.MultiSelect = false;
            this.dgrdNetworkStatisticsIPv6.Name = "dgrdNetworkStatisticsIPv6";
            this.dgrdNetworkStatisticsIPv6.ReadOnly = true;
            this.dgrdNetworkStatisticsIPv6.Size = new System.Drawing.Size(916, 369);
            this.dgrdNetworkStatisticsIPv6.TabIndex = 0;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(784, 4);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(140, 33);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.Location = new System.Drawing.Point(127, 665);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(133, 23);
            this.btnConnectToServer.TabIndex = 2;
            this.btnConnectToServer.Text = "Connect to server";
            this.btnConnectToServer.UseVisualStyleBackColor = true;
            this.btnConnectToServer.Visible = false;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.spltMainSplitContainer);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(944, 525);
            this.Panel1.TabIndex = 4;
            // 
            // spltMainSplitContainer
            // 
            this.spltMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltMainSplitContainer.IsSplitterFixed = true;
            this.spltMainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.spltMainSplitContainer.Name = "spltMainSplitContainer";
            this.spltMainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMainSplitContainer.Panel1
            // 
            this.spltMainSplitContainer.Panel1.Controls.Add(this.spltrPublicationsTreeViewMainSpliter);
            // 
            // spltMainSplitContainer.Panel2
            // 
            this.spltMainSplitContainer.Panel2.Controls.Add(this.spltStatusBarLikeSpliter);
            this.spltMainSplitContainer.Size = new System.Drawing.Size(944, 525);
            this.spltMainSplitContainer.SplitterDistance = 488;
            this.spltMainSplitContainer.TabIndex = 2;
            // 
            // spltStatusBarLikeSpliter
            // 
            this.spltStatusBarLikeSpliter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltStatusBarLikeSpliter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spltStatusBarLikeSpliter.IsSplitterFixed = true;
            this.spltStatusBarLikeSpliter.Location = new System.Drawing.Point(0, 0);
            this.spltStatusBarLikeSpliter.Name = "spltStatusBarLikeSpliter";
            // 
            // spltStatusBarLikeSpliter.Panel1
            // 
            this.spltStatusBarLikeSpliter.Panel1.Controls.Add(this.txtConnectionStatusLabel);
            // 
            // spltStatusBarLikeSpliter.Panel2
            // 
            this.spltStatusBarLikeSpliter.Panel2.Controls.Add(this.btnUpdateStatus);
            this.spltStatusBarLikeSpliter.Size = new System.Drawing.Size(944, 33);
            this.spltStatusBarLikeSpliter.SplitterDistance = 625;
            this.spltStatusBarLikeSpliter.TabIndex = 0;
            // 
            // txtConnectionStatusLabel
            // 
            this.txtConnectionStatusLabel.BackColor = System.Drawing.Color.Red;
            this.txtConnectionStatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConnectionStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionStatusLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectionStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.txtConnectionStatusLabel.Multiline = true;
            this.txtConnectionStatusLabel.Name = "txtConnectionStatusLabel";
            this.txtConnectionStatusLabel.ReadOnly = true;
            this.txtConnectionStatusLabel.Size = new System.Drawing.Size(625, 33);
            this.txtConnectionStatusLabel.TabIndex = 7;
            this.txtConnectionStatusLabel.Text = "Not Connected to DSS Service";
            this.txtConnectionStatusLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(136)))), ((int)(((byte)(202)))));
            this.btnUpdateStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUpdateStatus.FlatAppearance.BorderSize = 0;
            this.btnUpdateStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateStatus.ForeColor = System.Drawing.Color.White;
            this.btnUpdateStatus.Image = global::My.Resources.Resources.reload;
            this.btnUpdateStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateStatus.Location = new System.Drawing.Point(0, 0);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(315, 33);
            this.btnUpdateStatus.TabIndex = 6;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdateStatus.UseVisualStyleBackColor = false;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // imgLstClientConnections
            // 
            this.imgLstClientConnections.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLstClientConnections.ImageSize = new System.Drawing.Size(24, 24);
            this.imgLstClientConnections.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmDPEServerClientAppMainForm
            // 
            this.C1SizerLight1.SetAutoResize(this, true);
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 525);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnConnectToServer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDPEServerClientAppMainForm";
            this.Text = "Publications Server Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSTXDataSocketClient_FormClosing);
            this.Load += new System.EventHandler(this.STXDataSocketClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.C1SizerLight1)).EndInit();
            this.spltrPublicationsTreeViewMainSpliter.ResumeLayout(false);
            this.tapgae1.ResumeLayout(false);
            this.spltrServerParameters.Panel1.ResumeLayout(false);
            this.spltrServerParameters.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrServerParameters)).EndInit();
            this.spltrServerParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdServerParameters)).EndInit();
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel3)).EndInit();
            this.ElPanel3.ResumeLayout(false);
            this.tabClientConnections.ResumeLayout(false);
            this.tabpConnectedClients.ResumeLayout(false);
            this.TabSubscibedClients.ResumeLayout(false);
            this.TabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel5)).EndInit();
            this.ElPanel5.ResumeLayout(false);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.spltrClientCnnTableviewMainSpliter.Panel1.ResumeLayout(false);
            this.spltrClientCnnTableviewMainSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnTableviewMainSpliter)).EndInit();
            this.spltrClientCnnTableviewMainSpliter.ResumeLayout(false);
            this.spltrClientCnnTableviewHeaderSpliter.Panel1.ResumeLayout(false);
            this.spltrClientCnnTableviewHeaderSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnTableviewHeaderSpliter)).EndInit();
            this.spltrClientCnnTableviewHeaderSpliter.ResumeLayout(false);
            this.splAllClientsViewPublicationsCnnStatus.Panel1.ResumeLayout(false);
            this.splAllClientsViewPublicationsCnnStatus.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splAllClientsViewPublicationsCnnStatus)).EndInit();
            this.splAllClientsViewPublicationsCnnStatus.ResumeLayout(false);
            this.spltrClientsAllViewPostedPubsMain.Panel1.ResumeLayout(false);
            this.spltrClientsAllViewPostedPubsMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPostedPubsMain)).EndInit();
            this.spltrClientsAllViewPostedPubsMain.ResumeLayout(false);
            this.spltrClientsAllViewPostedPubsMainHeader.Panel1.ResumeLayout(false);
            this.spltrClientsAllViewPostedPubsMainHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPostedPubsMainHeader)).EndInit();
            this.spltrClientsAllViewPostedPubsMainHeader.ResumeLayout(false);
            this.spltrClientsAllViewPubsConnectionsMain.Panel1.ResumeLayout(false);
            this.spltrClientsAllViewPubsConnectionsMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPubsConnectionsMain)).EndInit();
            this.spltrClientsAllViewPubsConnectionsMain.ResumeLayout(false);
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel1.ResumeLayout(false);
            this.spltrClientsAllViewPubsConnectionsMainHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientsAllViewPubsConnectionsMainHeader)).EndInit();
            this.spltrClientsAllViewPubsConnectionsMainHeader.ResumeLayout(false);
            this.TabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel6)).EndInit();
            this.ElPanel6.ResumeLayout(false);
            this.spltrClientCnnsTreeViewMain.Panel1.ResumeLayout(false);
            this.spltrClientCnnsTreeViewMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTreeViewMain)).EndInit();
            this.spltrClientCnnsTreeViewMain.ResumeLayout(false);
            this.spltrClientCnnsTreeViewAndHeader.Panel1.ResumeLayout(false);
            this.spltrClientCnnsTreeViewAndHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTreeViewAndHeader)).EndInit();
            this.spltrClientCnnsTreeViewAndHeader.ResumeLayout(false);
            this.spltrClientCnnsTitleAndButtons.Panel1.ResumeLayout(false);
            this.spltrClientCnnsTitleAndButtons.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientCnnsTitleAndButtons)).EndInit();
            this.spltrClientCnnsTitleAndButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel26)).EndInit();
            this.SplitContainer4.Panel1.ResumeLayout(false);
            this.SplitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer4)).EndInit();
            this.SplitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel15)).EndInit();
            this.ElPanel15.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPostedPublications.Panel1.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPostedPublications.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPostedPublications)).EndInit();
            this.spltrClienCnnsTreeViewPostedPublications.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPostedHeader.Panel1.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPostedHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPostedHeader)).EndInit();
            this.spltrClienCnnsTreeViewPostedHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel16)).EndInit();
            this.ElPanel16.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel1.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPublicationsConnsMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPublicationsConnsMain)).EndInit();
            this.spltrClienCnnsTreeViewPublicationsConnsMain.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel1.ResumeLayout(false);
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClienCnnsTreeViewPubsConnectionsHeader)).EndInit();
            this.spltrClienCnnsTreeViewPubsConnectionsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton7)).EndInit();
            this.tabpPublisherClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel4)).EndInit();
            this.ElPanel4.ResumeLayout(false);
            this.TabControl4.ResumeLayout(false);
            this.TabPage7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel7)).EndInit();
            this.ElPanel7.ResumeLayout(false);
            this.SplitContainer5.Panel1.ResumeLayout(false);
            this.SplitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer5)).EndInit();
            this.SplitContainer5.ResumeLayout(false);
            this.spltrPublisherClientsListMain.Panel1.ResumeLayout(false);
            this.spltrPublisherClientsListMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherClientsListMain)).EndInit();
            this.spltrPublisherClientsListMain.ResumeLayout(false);
            this.spltrPublisherClientsListHeader.Panel1.ResumeLayout(false);
            this.spltrPublisherClientsListHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherClientsListHeader)).EndInit();
            this.spltrPublisherClientsListHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel17)).EndInit();
            this.ElPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox1)).EndInit();
            this.ElGroupBox1.ResumeLayout(false);
            this.SplitContainer10.Panel1.ResumeLayout(false);
            this.SplitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer10)).EndInit();
            this.SplitContainer10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel20)).EndInit();
            this.ElPanel20.ResumeLayout(false);
            this.spltrPublicationsPostedPublishersTableView.Panel1.ResumeLayout(false);
            this.spltrPublicationsPostedPublishersTableView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsPostedPublishersTableView)).EndInit();
            this.spltrPublicationsPostedPublishersTableView.ResumeLayout(false);
            this.SplitContainer16.Panel1.ResumeLayout(false);
            this.SplitContainer16.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer16)).EndInit();
            this.SplitContainer16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel21)).EndInit();
            this.ElPanel21.ResumeLayout(false);
            this.SplitContainer12.Panel1.ResumeLayout(false);
            this.SplitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer12)).EndInit();
            this.SplitContainer12.ResumeLayout(false);
            this.SplitContainer56.Panel1.ResumeLayout(false);
            this.SplitContainer56.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer56)).EndInit();
            this.SplitContainer56.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton8)).EndInit();
            this.TabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel8)).EndInit();
            this.ElPanel8.ResumeLayout(false);
            this.SplitContainer6.Panel1.ResumeLayout(false);
            this.SplitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer6)).EndInit();
            this.SplitContainer6.ResumeLayout(false);
            this.spltrPublisherstreeView.Panel1.ResumeLayout(false);
            this.spltrPublisherstreeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublisherstreeView)).EndInit();
            this.spltrPublisherstreeView.ResumeLayout(false);
            this.spltrClientConnsPublishersTreeViewHEader.Panel1.ResumeLayout(false);
            this.spltrClientConnsPublishersTreeViewHEader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrClientConnsPublishersTreeViewHEader)).EndInit();
            this.spltrClientConnsPublishersTreeViewHEader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox8)).EndInit();
            this.ElGroupBox8.ResumeLayout(false);
            this.SplitContainer7.Panel1.ResumeLayout(false);
            this.SplitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer7)).EndInit();
            this.SplitContainer7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel19)).EndInit();
            this.ElPanel19.ResumeLayout(false);
            this.SplitContainer8.Panel1.ResumeLayout(false);
            this.SplitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer8)).EndInit();
            this.SplitContainer8.ResumeLayout(false);
            this.SplitContainer57.Panel1.ResumeLayout(false);
            this.SplitContainer57.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer57)).EndInit();
            this.SplitContainer57.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel18)).EndInit();
            this.ElPanel18.ResumeLayout(false);
            this.SplitContainer9.Panel1.ResumeLayout(false);
            this.SplitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer9)).EndInit();
            this.SplitContainer9.ResumeLayout(false);
            this.SplitContainer58.Panel1.ResumeLayout(false);
            this.SplitContainer58.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer58)).EndInit();
            this.SplitContainer58.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElButton9)).EndInit();
            this.TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel11)).EndInit();
            this.ElPanel11.ResumeLayout(false);
            this.tabPublicationsStatus.ResumeLayout(false);
            this.TabPage9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel9)).EndInit();
            this.ElPanel9.ResumeLayout(false);
            this.SplitContainer13.Panel1.ResumeLayout(false);
            this.SplitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer13)).EndInit();
            this.SplitContainer13.ResumeLayout(false);
            this.spltrPublicationsREsumeMainSpliter.Panel1.ResumeLayout(false);
            this.spltrPublicationsREsumeMainSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsREsumeMainSpliter)).EndInit();
            this.spltrPublicationsREsumeMainSpliter.ResumeLayout(false);
            this.spltrPublicationsREsumeHeaderSplitter.Panel1.ResumeLayout(false);
            this.spltrPublicationsREsumeHeaderSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsREsumeHeaderSplitter)).EndInit();
            this.spltrPublicationsREsumeHeaderSplitter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel22)).EndInit();
            this.SplitContainer14.Panel1.ResumeLayout(false);
            this.SplitContainer14.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer14)).EndInit();
            this.SplitContainer14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel12)).EndInit();
            this.ElPanel12.ResumeLayout(false);
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel1.ResumeLayout(false);
            this.spltCtnrPublicationVariablesHEaderResumeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCtnrPublicationVariablesHEaderResumeView)).EndInit();
            this.spltCtnrPublicationVariablesHEaderResumeView.ResumeLayout(false);
            this.SplitContainer17.Panel1.ResumeLayout(false);
            this.SplitContainer17.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer17)).EndInit();
            this.SplitContainer17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox9)).EndInit();
            this.ElGroupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel22)).EndInit();
            this.ElPanel22.ResumeLayout(false);
            this.SplitContainer15.Panel1.ResumeLayout(false);
            this.SplitContainer15.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer15)).EndInit();
            this.SplitContainer15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel23)).EndInit();
            this.ElPanel23.ResumeLayout(false);
            this.spltCntrConnectedClientsResumeView.Panel1.ResumeLayout(false);
            this.spltCntrConnectedClientsResumeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCntrConnectedClientsResumeView)).EndInit();
            this.spltCntrConnectedClientsResumeView.ResumeLayout(false);
            this.SplitContainer49.Panel1.ResumeLayout(false);
            this.SplitContainer49.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer49)).EndInit();
            this.SplitContainer49.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox11)).EndInit();
            this.ElGroupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel24)).EndInit();
            this.ElPanel24.ResumeLayout(false);
            this.spltrPublicationsTableStatsMainSpliter.Panel1.ResumeLayout(false);
            this.spltrPublicationsTableStatsMainSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTableStatsMainSpliter)).EndInit();
            this.spltrPublicationsTableStatsMainSpliter.ResumeLayout(false);
            this.splitCtnrStatisticsHeader.Panel1.ResumeLayout(false);
            this.splitCtnrStatisticsHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitCtnrStatisticsHeader)).EndInit();
            this.splitCtnrStatisticsHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel7)).EndInit();
            this.SplitContainer50.Panel1.ResumeLayout(false);
            this.SplitContainer50.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer50)).EndInit();
            this.SplitContainer50.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumtStatisticsUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumtStatisticsReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPublicationDataUpdateStatisticsListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox12)).EndInit();
            this.ElGroupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox10)).EndInit();
            this.ElGroupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton9)).EndInit();
            this.TabPage10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel10)).EndInit();
            this.ElPanel10.ResumeLayout(false);
            this.SplitContainer19.Panel1.ResumeLayout(false);
            this.SplitContainer19.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer19)).EndInit();
            this.SplitContainer19.ResumeLayout(false);
            this.spltrPublicationsTreeViewSpliter.Panel1.ResumeLayout(false);
            this.spltrPublicationsTreeViewSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTreeViewSpliter)).EndInit();
            this.spltrPublicationsTreeViewSpliter.ResumeLayout(false);
            this.spltrPublicationsTreeViewHeaderSpliter.Panel1.ResumeLayout(false);
            this.spltrPublicationsTreeViewHeaderSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltrPublicationsTreeViewHeaderSpliter)).EndInit();
            this.spltrPublicationsTreeViewHeaderSpliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel23)).EndInit();
            this.SplitContainer20.Panel1.ResumeLayout(false);
            this.SplitContainer20.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer20)).EndInit();
            this.SplitContainer20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel25)).EndInit();
            this.ElPanel25.ResumeLayout(false);
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel1.ResumeLayout(false);
            this.spltCtnrPublicationVariablesHEadrTreeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCtnrPublicationVariablesHEadrTreeView)).EndInit();
            this.spltCtnrPublicationVariablesHEadrTreeView.ResumeLayout(false);
            this.SplitContainer52.Panel1.ResumeLayout(false);
            this.SplitContainer52.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer52)).EndInit();
            this.SplitContainer52.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel17)).EndInit();
            this.TabControl2.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel26)).EndInit();
            this.ElPanel26.ResumeLayout(false);
            this.SplitContainer22.Panel1.ResumeLayout(false);
            this.SplitContainer22.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer22)).EndInit();
            this.SplitContainer22.ResumeLayout(false);
            this.SplitContainer23.Panel1.ResumeLayout(false);
            this.SplitContainer23.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer23)).EndInit();
            this.SplitContainer23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel27)).EndInit();
            this.ElPanel27.ResumeLayout(false);
            this.SplitContainer24.Panel1.ResumeLayout(false);
            this.SplitContainer24.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer24)).EndInit();
            this.SplitContainer24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox13)).EndInit();
            this.ElGroupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel28)).EndInit();
            this.ElPanel28.ResumeLayout(false);
            this.SplitContainer25.Panel1.ResumeLayout(false);
            this.SplitContainer25.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer25)).EndInit();
            this.SplitContainer25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel29)).EndInit();
            this.ElPanel29.ResumeLayout(false);
            this.SplitContainer26.Panel1.ResumeLayout(false);
            this.SplitContainer26.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer26)).EndInit();
            this.SplitContainer26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox14)).EndInit();
            this.ElGroupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel30)).EndInit();
            this.ElPanel30.ResumeLayout(false);
            this.SplitContainer27.Panel1.ResumeLayout(false);
            this.SplitContainer27.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer27)).EndInit();
            this.SplitContainer27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox15)).EndInit();
            this.ElGroupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox16)).EndInit();
            this.ElGroupBox16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton27)).EndInit();
            this.TabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel31)).EndInit();
            this.ElPanel31.ResumeLayout(false);
            this.SplitContainer28.Panel1.ResumeLayout(false);
            this.SplitContainer28.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer28)).EndInit();
            this.SplitContainer28.ResumeLayout(false);
            this.SplitContainer29.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer29)).EndInit();
            this.SplitContainer29.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer30)).EndInit();
            this.SplitContainer30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox17)).EndInit();
            this.ElGroupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton30)).EndInit();
            this.SplitContainer21.Panel1.ResumeLayout(false);
            this.SplitContainer21.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer21)).EndInit();
            this.SplitContainer21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel32)).EndInit();
            this.ElPanel32.ResumeLayout(false);
            this.spltCntrConnectedClientsTreeView.Panel1.ResumeLayout(false);
            this.spltCntrConnectedClientsTreeView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltCntrConnectedClientsTreeView)).EndInit();
            this.spltCntrConnectedClientsTreeView.ResumeLayout(false);
            this.SplitContainer53.Panel1.ResumeLayout(false);
            this.SplitContainer53.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer53)).EndInit();
            this.SplitContainer53.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel18)).EndInit();
            this.TabControl3.ResumeLayout(false);
            this.TabPage11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel33)).EndInit();
            this.ElPanel33.ResumeLayout(false);
            this.SplitContainer31.Panel1.ResumeLayout(false);
            this.SplitContainer31.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer31)).EndInit();
            this.SplitContainer31.ResumeLayout(false);
            this.SplitContainer32.Panel1.ResumeLayout(false);
            this.SplitContainer32.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer32)).EndInit();
            this.SplitContainer32.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel34)).EndInit();
            this.ElPanel34.ResumeLayout(false);
            this.SplitContainer33.Panel1.ResumeLayout(false);
            this.SplitContainer33.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer33)).EndInit();
            this.SplitContainer33.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox18)).EndInit();
            this.ElGroupBox18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel35)).EndInit();
            this.ElPanel35.ResumeLayout(false);
            this.SplitContainer34.Panel1.ResumeLayout(false);
            this.SplitContainer34.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer34)).EndInit();
            this.SplitContainer34.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel36)).EndInit();
            this.ElPanel36.ResumeLayout(false);
            this.SplitContainer35.Panel1.ResumeLayout(false);
            this.SplitContainer35.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer35)).EndInit();
            this.SplitContainer35.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox19)).EndInit();
            this.ElGroupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel37)).EndInit();
            this.ElPanel37.ResumeLayout(false);
            this.SplitContainer36.Panel1.ResumeLayout(false);
            this.SplitContainer36.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer36)).EndInit();
            this.SplitContainer36.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox20)).EndInit();
            this.ElGroupBox20.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox21)).EndInit();
            this.ElGroupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton41)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton42)).EndInit();
            this.TabPage12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel38)).EndInit();
            this.ElPanel38.ResumeLayout(false);
            this.SplitContainer37.Panel1.ResumeLayout(false);
            this.SplitContainer37.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer37)).EndInit();
            this.SplitContainer37.ResumeLayout(false);
            this.SplitContainer38.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer38)).EndInit();
            this.SplitContainer38.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer39)).EndInit();
            this.SplitContainer39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox22)).EndInit();
            this.ElGroupBox22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton43)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton44)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton45)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel39)).EndInit();
            this.ElPanel39.ResumeLayout(false);
            this.SplitContainer51.Panel1.ResumeLayout(false);
            this.SplitContainer51.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer51)).EndInit();
            this.SplitContainer51.ResumeLayout(false);
            this.SplitContainer54.Panel1.ResumeLayout(false);
            this.SplitContainer54.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer54)).EndInit();
            this.SplitContainer54.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel5)).EndInit();
            this.SplitContainer55.Panel1.ResumeLayout(false);
            this.SplitContainer55.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer55)).EndInit();
            this.SplitContainer55.ResumeLayout(false);
            this.SplitContainer3.Panel1.ResumeLayout(false);
            this.SplitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer3)).EndInit();
            this.SplitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumTreeViewStatisticsUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPublicationsResumTreeViewStatisticsReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrPublicationDataUpdateStatisticsTreeView)).EndInit();
            this.TabControl6.ResumeLayout(false);
            this.TabPage13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel40)).EndInit();
            this.ElPanel40.ResumeLayout(false);
            this.SplitContainer40.Panel1.ResumeLayout(false);
            this.SplitContainer40.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer40)).EndInit();
            this.SplitContainer40.ResumeLayout(false);
            this.SplitContainer41.Panel1.ResumeLayout(false);
            this.SplitContainer41.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer41)).EndInit();
            this.SplitContainer41.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel41)).EndInit();
            this.ElPanel41.ResumeLayout(false);
            this.SplitContainer42.Panel1.ResumeLayout(false);
            this.SplitContainer42.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer42)).EndInit();
            this.SplitContainer42.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox23)).EndInit();
            this.ElGroupBox23.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton46)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton47)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton48)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel42)).EndInit();
            this.ElPanel42.ResumeLayout(false);
            this.SplitContainer43.Panel1.ResumeLayout(false);
            this.SplitContainer43.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer43)).EndInit();
            this.SplitContainer43.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel43)).EndInit();
            this.ElPanel43.ResumeLayout(false);
            this.SplitContainer44.Panel1.ResumeLayout(false);
            this.SplitContainer44.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer44)).EndInit();
            this.SplitContainer44.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox24)).EndInit();
            this.ElGroupBox24.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton50)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton51)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel44)).EndInit();
            this.ElPanel44.ResumeLayout(false);
            this.SplitContainer45.Panel1.ResumeLayout(false);
            this.SplitContainer45.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer45)).EndInit();
            this.SplitContainer45.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox25)).EndInit();
            this.ElGroupBox25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton52)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton53)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton54)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox26)).EndInit();
            this.ElGroupBox26.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton55)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton57)).EndInit();
            this.TabPage14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElPanel45)).EndInit();
            this.ElPanel45.ResumeLayout(false);
            this.SplitContainer46.Panel1.ResumeLayout(false);
            this.SplitContainer46.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer46)).EndInit();
            this.SplitContainer46.ResumeLayout(false);
            this.SplitContainer47.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer47)).EndInit();
            this.SplitContainer47.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer48)).EndInit();
            this.SplitContainer48.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox27)).EndInit();
            this.ElGroupBox27.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton58)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton59)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton60)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElGroupBox3)).EndInit();
            this.ElGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ElRadioButton6)).EndInit();
            this.TabPage15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnClearLog)).EndInit();
            this.TabPage20.ResumeLayout(false);
            this.SplitContainer11.Panel1.ResumeLayout(false);
            this.SplitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer11)).EndInit();
            this.SplitContainer11.ResumeLayout(false);
            this.TabControl5.ResumeLayout(false);
            this.TabPage21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv4)).EndInit();
            this.TabPage22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdNetworkStatisticsIPv6)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.spltMainSplitContainer.Panel1.ResumeLayout(false);
            this.spltMainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMainSplitContainer)).EndInit();
            this.spltMainSplitContainer.ResumeLayout(false);
            this.spltStatusBarLikeSpliter.Panel1.ResumeLayout(false);
            this.spltStatusBarLikeSpliter.Panel1.PerformLayout();
            this.spltStatusBarLikeSpliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltStatusBarLikeSpliter)).EndInit();
            this.spltStatusBarLikeSpliter.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		internal C1.Win.C1Sizer.C1SizerLight C1SizerLight1;
		internal System.Windows.Forms.TabControl spltrPublicationsTreeViewMainSpliter;
		internal System.Windows.Forms.TabPage tapgae1;
		internal System.Windows.Forms.TabPage TabPage2;
        internal System.Windows.Forms.Button btnConnectToServer;
		internal System.Windows.Forms.DataGridView dgrdServerParameters;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel3;
		internal System.Windows.Forms.TabControl tabClientConnections;
		internal System.Windows.Forms.TabPage tabpConnectedClients;
        internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabControl TabSubscibedClients;
		internal System.Windows.Forms.TabPage TabPage5;
		internal System.Windows.Forms.TabPage TabPage6;
		internal System.Windows.Forms.TabPage tabpPublisherClients;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel4;
		internal System.Windows.Forms.TabControl TabControl4;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.TabPage TabPage8;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel5;
		internal System.Windows.Forms.ListView lstvClientSubscriptors;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel6;
		internal System.Windows.Forms.TreeView tvwClientSubscriptors;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel7;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel8;
		internal System.Windows.Forms.ListView lsvPublisherClients;
		internal System.Windows.Forms.TreeView tvwPublisherClients;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel11;
		internal System.Windows.Forms.TabControl tabPublicationsStatus;
		internal System.Windows.Forms.TabPage TabPage9;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel9;
		internal System.Windows.Forms.ListView lstAvailablePublications;
		internal System.Windows.Forms.TabPage TabPage10;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel10;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox3;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton5;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton6;
        internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton7;
		internal System.Windows.Forms.SplitContainer SplitContainer1;
		internal System.Windows.Forms.SplitContainer splAllClientsViewPublicationsCnnStatus;
		internal System.Windows.Forms.SplitContainer spltrClientCnnsTreeViewMain;
		internal System.Windows.Forms.SplitContainer SplitContainer4;
        internal System.Windows.Forms.ListView lsvAllConnectionsPostedPublications;
        internal System.Windows.Forms.ListView lsvAllConnectionsConnectionToPublications;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel15;
		internal System.Windows.Forms.ListView lsvAllConnectionsByHostPublicationsPosted;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton6;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel16;
		internal System.Windows.Forms.ListView lsvAllConnectionsByHostConnectionToPublications;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton7;
		internal System.Windows.Forms.SplitContainer SplitContainer5;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel17;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox1;
		internal System.Windows.Forms.ListView lsvPublisherConnectionsAllPublicationsPosted;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton8;
		internal System.Windows.Forms.SplitContainer SplitContainer6;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox8;
		internal System.Windows.Forms.ListView lsvPublisherClientsViewByHostPostedPublications;
		internal System.Windows.Forms.SplitContainer SplitContainer7;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel18;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton9;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel19;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel1;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton10;
		internal System.Windows.Forms.SplitContainer SplitContainer8;
		internal System.Windows.Forms.SplitContainer SplitContainer9;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel2;
		internal System.Windows.Forms.ListView lsvPublisherClientsViewByHostPostedPublicationsVariablesList;
		internal System.Windows.Forms.SplitContainer spltrPublicationsPostedPublishersTableView;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel3;
		internal System.Windows.Forms.SplitContainer SplitContainer10;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel20;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton11;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel21;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton ElButton12;
		internal System.Windows.Forms.SplitContainer SplitContainer12;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel4;
		internal System.Windows.Forms.ListView lsvPublisherConnectionsAllPublicationsPostedVariablesList;
		internal System.Windows.Forms.SplitContainer SplitContainer13;
		internal System.Windows.Forms.SplitContainer SplitContainer14;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel12;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox9;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton1;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton2;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton3;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel22;
		internal System.Windows.Forms.SplitContainer SplitContainer15;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel23;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox11;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton10;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton11;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton12;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel24;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox12;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton13;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton14;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton15;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox10;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton4;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton8;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton9;
		internal System.Windows.Forms.SplitContainer spltCtnrPublicationVariablesHEaderResumeView;
		internal System.Windows.Forms.SplitContainer spltCntrConnectedClientsResumeView;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel6;
		internal System.Windows.Forms.ListView lsvPublicationsREsumeConnectedCLientsList;
		internal System.Windows.Forms.SplitContainer spltrPublicationsTableStatsMainSpliter;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel7;
		internal System.Windows.Forms.SplitContainer SplitContainer19;
		internal System.Windows.Forms.TreeView tvwPublicationsREsumeTreeView;
		internal System.Windows.Forms.SplitContainer SplitContainer20;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel25;
		internal System.Windows.Forms.SplitContainer spltCtnrPublicationVariablesHEadrTreeView;
		internal System.Windows.Forms.TabControl TabControl2;
		internal System.Windows.Forms.TabPage TabPage3;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel26;
		internal System.Windows.Forms.SplitContainer SplitContainer22;
		internal System.Windows.Forms.ListView ListView1;
		internal System.Windows.Forms.SplitContainer SplitContainer23;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel27;
		internal System.Windows.Forms.SplitContainer SplitContainer24;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel8;
		internal System.Windows.Forms.ListView ListView2;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox13;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton16;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton17;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton18;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel28;
		internal System.Windows.Forms.SplitContainer SplitContainer25;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel29;
		internal System.Windows.Forms.SplitContainer SplitContainer26;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel9;
		internal System.Windows.Forms.ListView ListView3;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox14;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton19;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton20;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton21;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel30;
		internal System.Windows.Forms.SplitContainer SplitContainer27;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel10;
		internal System.Windows.Forms.DataGridView DataGridView1;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox15;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton22;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton23;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton24;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox16;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton25;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton26;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton27;
		internal System.Windows.Forms.TabPage TabPage4;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel31;
		internal System.Windows.Forms.SplitContainer SplitContainer28;
		internal System.Windows.Forms.TreeView TreeView2;
		internal System.Windows.Forms.SplitContainer SplitContainer29;
		internal System.Windows.Forms.SplitContainer SplitContainer30;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox17;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton28;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton29;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton30;
		internal System.Windows.Forms.SplitContainer SplitContainer21;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel32;
		internal System.Windows.Forms.SplitContainer spltCntrConnectedClientsTreeView;
		internal System.Windows.Forms.TabControl TabControl3;
		internal System.Windows.Forms.TabPage TabPage11;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel33;
		internal System.Windows.Forms.SplitContainer SplitContainer31;
		internal System.Windows.Forms.ListView ListView4;
		internal System.Windows.Forms.SplitContainer SplitContainer32;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel34;
		internal System.Windows.Forms.SplitContainer SplitContainer33;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel11;
		internal System.Windows.Forms.ListView ListView5;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox18;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton31;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton32;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton33;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel35;
		internal System.Windows.Forms.SplitContainer SplitContainer34;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel36;
		internal System.Windows.Forms.SplitContainer SplitContainer35;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel12;
		internal System.Windows.Forms.ListView ListView6;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox19;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton34;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton35;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton36;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel37;
		internal System.Windows.Forms.SplitContainer SplitContainer36;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel13;
		internal System.Windows.Forms.DataGridView DataGridView2;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox20;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton37;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton38;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton39;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox21;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton40;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton41;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton42;
		internal System.Windows.Forms.TabPage TabPage12;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel38;
		internal System.Windows.Forms.SplitContainer SplitContainer37;
		internal System.Windows.Forms.TreeView TreeView3;
		internal System.Windows.Forms.SplitContainer SplitContainer38;
		internal System.Windows.Forms.SplitContainer SplitContainer39;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox22;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton43;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton44;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton45;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel39;
		internal System.Windows.Forms.SplitContainer SplitContainer51;
		internal System.Windows.Forms.TabControl TabControl6;
		internal System.Windows.Forms.TabPage TabPage13;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel40;
		internal System.Windows.Forms.SplitContainer SplitContainer40;
		internal System.Windows.Forms.ListView ListView7;
		internal System.Windows.Forms.SplitContainer SplitContainer41;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel41;
		internal System.Windows.Forms.SplitContainer SplitContainer42;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel14;
		internal System.Windows.Forms.ListView ListView8;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox23;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton46;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton47;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton48;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel42;
		internal System.Windows.Forms.SplitContainer SplitContainer43;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel43;
		internal System.Windows.Forms.SplitContainer SplitContainer44;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel15;
		internal System.Windows.Forms.ListView ListView9;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox24;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton49;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton50;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton51;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel44;
		internal System.Windows.Forms.SplitContainer SplitContainer45;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel16;
		internal System.Windows.Forms.DataGridView DataGridView3;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox25;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton52;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton53;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton54;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox26;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton55;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton56;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton57;
		internal System.Windows.Forms.TabPage TabPage14;
		internal Klik.Windows.Forms.v1.EntryLib.ELPanel ElPanel45;
		internal System.Windows.Forms.SplitContainer SplitContainer46;
		internal System.Windows.Forms.TreeView TreeView4;
		internal System.Windows.Forms.SplitContainer SplitContainer47;
		internal System.Windows.Forms.SplitContainer SplitContainer48;
		internal Klik.Windows.Forms.v1.EntryLib.ELGroupBox ElGroupBox27;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton58;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton59;
		internal Klik.Windows.Forms.v1.EntryLib.ELRadioButton ElRadioButton60;
		internal System.Windows.Forms.ListView lsvPublicationsREsumeTreeviewConnectedClients;
		internal System.Windows.Forms.SplitContainer splitCtnrStatisticsHeader;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnPublicationsResumtStatisticsUpdate;
		internal System.Windows.Forms.TabPage TabPage15;
		internal System.Windows.Forms.ListBox lstSTXEventLog;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnClearLog;
		internal System.Windows.Forms.ImageList imglstClientConnectionsRegistry;
		internal System.Windows.Forms.ImageList imglstPublisherClientConnectionsRegistry;
		internal System.Windows.Forms.ImageList imgLstClientPublicatiosRegistry;
		internal System.Windows.Forms.ImageList imgLstPublicationsREgistry;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel17;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel18;
		internal System.Windows.Forms.ImageList imgViewsImagesList;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel20;
		internal System.Windows.Forms.ListView lsvPublicationREsumeTableViewVariablesList;
		internal System.Windows.Forms.ListView lsvPublicationTreeViewVariablesList;
		internal System.Windows.Forms.ImageList imgLstClientConnections;
		internal System.Windows.Forms.TabPage TabPage20;
		internal System.Windows.Forms.TabControl TabControl5;
		internal System.Windows.Forms.TabPage TabPage21;
		internal System.Windows.Forms.DataGridView dgrdNetworkStatisticsIPv4;
		internal System.Windows.Forms.TabPage TabPage22;
		internal System.Windows.Forms.DataGridView dgrdNetworkStatisticsIPv6;
		internal System.Windows.Forms.Button btnUpdate;
		internal System.Windows.Forms.SplitContainer SplitContainer11;
		internal System.Windows.Forms.SplitContainer SplitContainer17;
		internal System.Windows.Forms.Button btnZoomPubsVariablesListView;
		internal System.Windows.Forms.SplitContainer SplitContainer49;
		internal System.Windows.Forms.Button btnZoomPubsClientsListView;
		internal System.Windows.Forms.SplitContainer SplitContainer50;
		internal System.Windows.Forms.Button btnZoomPubsStatisticsListView;
		internal System.Windows.Forms.SplitContainer SplitContainer53;
		internal System.Windows.Forms.Button btnZoomPubsClientsTreeView;
		internal System.Windows.Forms.SplitContainer SplitContainer52;
		internal System.Windows.Forms.Button btnZoomPubsVariablesTreeView;
		internal System.Windows.Forms.SplitContainer SplitContainer54;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel5;
		internal System.Windows.Forms.SplitContainer SplitContainer55;
		internal System.Windows.Forms.Button btnZoomPubsStatisticsTreeView;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnPublicationsResumTreeViewStatisticsUpdate;
		internal System.Windows.Forms.SplitContainer spltMainSplitContainer;
		internal System.Windows.Forms.TextBox txtConnectionStatusLabel;
		internal System.Windows.Forms.Button btnAllPublihsersPubliationsListZoomView;
		internal System.Windows.Forms.Button btnAllPublishersPublicationVariablesZoom;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		internal System.Windows.Forms.SplitContainer SplitContainer16;
		internal System.Windows.Forms.SplitContainer SplitContainer56;
		internal System.Windows.Forms.SplitContainer SplitContainer57;
		internal System.Windows.Forms.SplitContainer SplitContainer58;
		internal System.Windows.Forms.SplitContainer spltrPublisherstreeView;
		internal System.Windows.Forms.SplitContainer spltStatusBarLikeSpliter;
		internal System.Windows.Forms.SplitContainer spltrClientsAllViewPostedPubsMain;
		internal System.Windows.Forms.SplitContainer spltrClientsAllViewPubsConnectionsMain;
        internal System.Windows.Forms.SplitContainer spltrClientsAllViewPostedPubsMainHeader;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.Button btnZoomAllClientsTableViewPostedPubsList;
        internal System.Windows.Forms.SplitContainer spltrClientsAllViewPubsConnectionsMainHeader;
		internal System.Windows.Forms.Button btnZoomAllClientsTableViewPubsConnectionsList;
		internal System.Windows.Forms.SplitContainer spltrPublicationsREsumeMainSpliter;
		internal System.Windows.Forms.SplitContainer spltrPublicationsREsumeHeaderSplitter;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel22;
		internal System.Windows.Forms.Button btnZoomAvailablePublications;
		internal System.Windows.Forms.SplitContainer spltrPublicationsTreeViewSpliter;
		internal System.Windows.Forms.SplitContainer spltrPublicationsTreeViewHeaderSpliter;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel23;
		internal System.Windows.Forms.Button btnAvaibalePublicationsTreeViewTreeCollapse;
		internal System.Windows.Forms.Button btnAvaibalePublicationsTreeViewTreeExpand;
		internal System.Windows.Forms.Button btnPublicationsTreeViewZoomView;
		internal System.Windows.Forms.ImageList imgLstPublicationsTreeView;
		internal System.Windows.Forms.SplitContainer spltrClientCnnTableviewMainSpliter;
        internal System.Windows.Forms.SplitContainer spltrClientCnnTableviewHeaderSpliter;
		internal System.Windows.Forms.Button btnClientsCnnListViewZoom;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnPublicationsResumtStatisticsReset;
		internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal System.Windows.Forms.SplitContainer spltrServerParameters;
		internal System.Windows.Forms.SplitContainer spltrClientCnnsTreeViewAndHeader;
		internal System.Windows.Forms.SplitContainer spltrClientCnnsTitleAndButtons;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel26;
		internal System.Windows.Forms.Button btnClientConnsTreeViewZoom;
		internal System.Windows.Forms.Button btnClientConnsTreeViewCollapseNode;
		internal System.Windows.Forms.Button btnClientConnsTreeViewCollapseAll;
		internal System.Windows.Forms.Button btnClientConnsTreeViewExpandAll;
		internal System.Windows.Forms.SplitContainer spltrClienCnnsTreeViewPostedPublications;
		internal System.Windows.Forms.SplitContainer spltrClienCnnsTreeViewPostedHeader;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel27;
		internal System.Windows.Forms.Button btnClientCnnsTreeViewPostedPubsZoom;
		internal System.Windows.Forms.SplitContainer spltrClienCnnsTreeViewPublicationsConnsMain;
		internal System.Windows.Forms.SplitContainer spltrClienCnnsTreeViewPubsConnectionsHeader;
		internal System.Windows.Forms.Button btnClienCnnsTreeViewPubcConnsZoom;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel28;
		internal System.Windows.Forms.SplitContainer spltrPublisherClientsListMain;
		internal System.Windows.Forms.SplitContainer spltrPublisherClientsListHeader;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel29;
		internal System.Windows.Forms.Button Button3;
		internal System.Windows.Forms.Button btnClientCnnsListViewAdjustCols;
		internal System.Windows.Forms.SplitContainer spltrClientConnsPublishersTreeViewHEader;
		internal Klik.Windows.Forms.v1.EntryLib.ELLabel ElLabel30;
		internal System.Windows.Forms.Button btnClientCnnsPublishersTreeViewNodeCollapse;
		internal System.Windows.Forms.Button btnClientCnnsPublishersTreeViewCollapseAll;
		internal System.Windows.Forms.Button btnClientCnnsPublishersTreeViewExpandAll;
		internal System.Windows.Forms.Button btnClientCnnsPublishersTreeViewZoom;
		internal System.Windows.Forms.Button btnAvaibalePublicationsTreeViewTreeNodeCollapse;
		internal System.Windows.Forms.SplitContainer SplitContainer3;
		internal Klik.Windows.Forms.v1.EntryLib.ELButton btnPublicationsResumTreeViewStatisticsReset;
		internal System.Windows.Forms.Button Button4;
		internal System.Windows.Forms.Button Button5;
		internal System.Windows.Forms.Button Button6;
		internal System.Windows.Forms.Button Button7;
		internal System.Windows.Forms.Button Button8;
		internal System.Windows.Forms.DataGridView dgrPublicationDataUpdateStatisticsListView;
		internal System.Windows.Forms.DataGridView dgrPublicationDataUpdateStatisticsTreeView;
        internal Button btnUpdateStatus;
        private System.ComponentModel.IContainer components;
        internal Label Label6;
        internal Label label1;
        internal Label label2;
        internal Label label3;
		
	}
	
}
