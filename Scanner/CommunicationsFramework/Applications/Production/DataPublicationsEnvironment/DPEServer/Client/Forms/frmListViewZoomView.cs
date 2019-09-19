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
	public partial class frmListViewZoomView
	{
		
#region  < DATA MEMBERS >
		
		private System.Windows.Forms.Control _controlParentContainer;
		private System.Windows.Forms.Control _controlToView;
		private System.Windows.Forms.DockStyle _previousControlDockStatus;
		private string _caption;
#endregion
		
#region  < CONSTUCTORS>
		
		public frmListViewZoomView(string caption, System.Windows.Forms.ListView controlToView)
		{
			
			this._controlToView = controlToView;
			this._controlParentContainer = controlToView.Parent;
			this._previousControlDockStatus = controlToView.Dock;
			this._caption = caption;
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this.lblHEaderLabelTExt.Text = caption;
			this.Visible = false;
			
			
		}
		
		public frmListViewZoomView(string caption, System.Windows.Forms.DataGridView controlToView)
		{
			
			this._controlToView = controlToView;
			this._controlParentContainer = controlToView.Parent;
			this._previousControlDockStatus = controlToView.Dock;
			this._caption = caption;
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this.lblHEaderLabelTExt.Text = caption;
			this.Visible = false;
			
			
		}
#endregion
		
#region  < PRIVATE METHODS >
		
		private void AdjustListViewTableViewColSize(Control ctrl)
		{
			try
			{
				string controlString = ctrl.ToString();
				int colWidth = 0;
				
				switch (controlString)
				{
					case "System.Windows.Forms.DataGridView":
						DataGridView ListView_1 = (DataGridView) ctrl;
						colWidth = (int) ((double) ListView_1.Width / ListView_1.Columns.Count);
						DataGridViewColumn col_1;
						IEnumerator enumm_1 = ListView_1.Columns.GetEnumerator();
						while (enumm_1.MoveNext())
						{
							col_1 = (System.Windows.Forms.DataGridViewColumn) enumm_1.Current;
							col_1.Width = colWidth;
						}
						break;
						
					case "System.Windows.Forms.ListView":
						ListView ListView = (ListView) ctrl;
						colWidth = (int) ((double) ListView.Width / ListView.Columns.Count);
						ColumnHeader col;
						IEnumerator enumm = ListView.Columns.GetEnumerator();
						while (enumm.MoveNext())
						{
							col = (System.Windows.Forms.ColumnHeader) enumm.Current;
							col.Width = colWidth;
						}
						break;
				}
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmZoomView_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Text = this._caption;
				this._controlToView.Dock = DockStyle.Fill;
				this.spltrMain.Panel2.Controls.Add(this._controlToView);
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this._controlToView.Dock = this._previousControlDockStatus;
				this.spltrMain.Panel1.Controls.Remove(this._controlToView);
				this._controlParentContainer.Controls.Add(this._controlToView);
				this.Dispose();
			}
			catch (Exception)
			{
			}
		}
		
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
		
		public void btnAdjustColumns_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.AdjustListViewTableViewColSize(this._controlToView);
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
		
		
		
	}
}
