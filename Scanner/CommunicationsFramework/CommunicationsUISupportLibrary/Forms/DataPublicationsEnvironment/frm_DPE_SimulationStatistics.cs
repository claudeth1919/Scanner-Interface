using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Windows.Forms;

namespace CommunicationsUISupportLibrary
{
	public partial class frm_DPE_SimulationStatistics
	{
		
		private CF_DPE_PublicationPostHandler _publicationsHandler;
		
#region  < CONSTRUCTORS >
		
		public frm_DPE_SimulationStatistics(CF_DPE_PublicationPostHandler publicationsHandler)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._publicationsHandler = publicationsHandler;
			
		}
		
#endregion
		
		private void adjustGrid(C1.Win.C1FlexGrid.C1FlexGrid grid)
		{
			try
			{
				int colWidth = (int) (((double) grid.Width / grid.Cols.Count) - 5);
				
				int index = 0;
				index = 0;
				for (index = 0; index <= grid.Cols.Count; index++)
				{
					grid.Cols[index].Width = colWidth;
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		
		public void frmSTXDSS_SimulationStatistics_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.dgrdUPDATEStatisticsTable.DataSource = this._publicationsHandler.DSSClient.Statistics.PublicationUpdateWriteStatistics(this._publicationsHandler.PublicationName);
				this.dgrdRESETStatiticsTAble.DataSource = this._publicationsHandler.DSSClient.Statistics.PublicationResetWriteStatistics(this._publicationsHandler.PublicationName);
				this.adjustGrid(this.dgrdUPDATEStatisticsTable);
				this.adjustGrid(this.dgrdRESETStatiticsTAble);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
