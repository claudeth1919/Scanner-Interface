using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.DataStatistics;
using UtilitiesLibrary.Services.Serialization;
using CommunicationsLibrary.DataPublicationsEnvironment.Server.Handling.Publications;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;



namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_PublicationSubscriptionHandler
	{
		
#region  < DATA MEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private string _publicationName;
		
#endregion
		
#region  < COSNTRUCTORS  >
		
		public CF_DPE_PublicationSubscriptionHandler(DPE_DataPublicationsClient client, string publicationName)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._client = client;
			this._publicationName = publicationName;
		}
		
#endregion
		
#region  < PRIVATE METHODS>
		
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
		
#endregion
		
		
#region  < FRIEND METHODS >
		
		internal void UpdateStatistics()
		{
			this.dgrdUPDATEStatistics.DataSource = this._client.Statistics.PublicationUpdateReadStatisticsTable(this._publicationName);
			this.dgrdResetStatistics.DataSource = this._client.Statistics.PublicationResetReadStatisticsTable(this._publicationName);
			this.adjustGrid(this.dgrdUPDATEStatistics);
			this.adjustGrid(this.dgrdResetStatistics);
		}
		
#endregion
		
#region  <  UI CALLBACKS >
		
		public void CFSTXDSS_PublicationConnectionHandler_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.UpdateStatistics();
			}
			catch (Exception)
			{
			}
		}
		
#endregion
		
		
	}
	
}
