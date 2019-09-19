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
	public partial class frmListViewItemZoomView
	{
		
#region  < DATA MEMBERS >
		
		private ListViewItem _itemToDisplay;
		private string _caption;
#endregion
		
#region  < CONSTUCTORS>
		
		public frmListViewItemZoomView(string caption, ListViewItem item)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._itemToDisplay = item;
			this._caption = caption;
			
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private void adjustGrid()
		{
			try
			{
				this.c1FlxGrdListview.Cols[0].Width = (int) (((double) this.c1FlxGrdListview.Width / 2) - 2);
				this.c1FlxGrdListview.Cols[1].Width = (int) (((double) this.c1FlxGrdListview.Width / 2) - 2);
			}
			catch (Exception)
			{
				
			}
		}
		
		private void FillTableWithItem()
		{
			try
			{
				this.c1FlxGrdListview.Rows.Count = this._itemToDisplay.ListView.Columns.Count;
				
				int index = 0;
				
				
				//fills all the first column
				for (index = 0; index <= this._itemToDisplay.ListView.Columns.Count - 1; index++)
				{
					this.c1FlxGrdListview[index, 0] = this._itemToDisplay.ListView.Columns[index].Text;
				}
				
				//fills all the second column
				this.c1FlxGrdListview[0, 1] = this._itemToDisplay.Text;
				
				for (index = 1; index <= this._itemToDisplay.ListView.Columns.Count - 1; index++)
				{
					this.c1FlxGrdListview[index, 1] = this._itemToDisplay.SubItems[index].Text;
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
				this.FillTableWithItem();
				this.adjustGrid();
			}
			catch (Exception)
			{
			}
		}
		
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
			}
			catch (Exception)
			{
			}
		}
		
		public void frmListViewItemZoomView_Resize(object sender, System.EventArgs e)
		{
			try
			{
				this.adjustGrid();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
		
		
	}
}
