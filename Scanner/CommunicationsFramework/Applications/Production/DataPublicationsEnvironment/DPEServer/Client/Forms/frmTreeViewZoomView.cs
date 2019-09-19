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
	public partial class frmTreeViewZoomView
	{
		
#region  < DATA MEMBERS >
		
		private System.Windows.Forms.Control _controlParentContainer;
		private System.Windows.Forms.TreeView _treeViewControl;
		private System.Windows.Forms.DockStyle _previousControlDockStatus;
		private string _caption;
		
#endregion
		
#region  < CONSTUCTORS>
		
		public frmTreeViewZoomView(string caption, System.Windows.Forms.TreeView treeViewControl)
		{
			
			this._treeViewControl = treeViewControl;
			this._controlParentContainer = _treeViewControl.Parent;
			this._previousControlDockStatus = _treeViewControl.Dock;
			this._caption = caption;
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this.lblHEaderLabelTExt.Text = caption;
			this.Visible = false;
			
			
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmZoomView_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Text = this._caption;
				this._treeViewControl.Dock = DockStyle.Fill;
				this.spltrMain.Panel2.Controls.Add(this._treeViewControl);
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._treeViewControl.Dock = this._previousControlDockStatus;
				this.spltrMain.Panel1.Controls.Remove(this._treeViewControl);
				this._controlParentContainer.Controls.Add(this._treeViewControl);
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
		
		public void frmZoomView_Resize(object sender, System.EventArgs e)
		{
			try
			{
				if (this.WindowState != FormWindowState.Maximized)
				{
					this.WindowState = FormWindowState.Maximized;
				}
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientConnsTreeViewExpandAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._treeViewControl.ExpandAll();
			}
			catch (Exception)
			{
			}
		}
		
		public void btnClientConnsTreeViewCollapseAll_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._treeViewControl.CollapseAll();
			}
			catch (Exception)
			{
			}
		}
		
	}
}
