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

using DPEClientTestApplication.publicationsPosting.containers;
using DPEClientTestApplication.publicationsPosting;


namespace DPEClientTestApplication
{
	[Serializable()]public class ClientHandlerData
	{
		
		
		
		
#region  < DATA MEMBERS >
		
		private string _clientName;
		private bool _statisticHandling;
		private PostedPublicationsDefinitionsDataContainer _PublicationsPostedDataContainer;
		private Hashtable _publicationsConnectionTable;
		
#endregion
		
#region  < CONSTRUCTORS >
		
		public ClientHandlerData(string name, bool statisticsHandling)
		{
			this._statisticHandling = statisticsHandling;
			this._clientName = name;
			this._publicationsConnectionTable = new Hashtable();
			this._PublicationsPostedDataContainer = new PostedPublicationsDefinitionsDataContainer();
		}
		
#endregion
		
#region  < PROPERTIES >
		
public string ClientName
		{
			get
			{
				return this._clientName;
			}
		}
		
public bool StatisticsHandling
		{
			get
			{
				return this._statisticHandling;
			}
		}
		
		
		
#endregion
		
#region  < PUBLIC METHODS >
		
		
#region  < PUBLICATIONS  POSTING DATA  >
		
		public void AddPublicationPostDefinition(PostedPublicationDefinitionData data)
		{
			this._PublicationsPostedDataContainer.AddPublicationData(data);
		}
		
		public void RemovePublicationPostDefinition(PostedPublicationDefinitionData data)
		{
			this._PublicationsPostedDataContainer.RemovePublicationData(data);
		}
		
#endregion
		
#region  < PUBLICATIONS CONNECTION >
		
#endregion
		
		
		
		
#endregion
		
	}
	
}
