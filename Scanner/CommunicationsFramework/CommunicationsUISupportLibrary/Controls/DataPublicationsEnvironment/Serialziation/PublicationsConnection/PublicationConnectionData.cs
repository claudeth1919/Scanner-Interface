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

//using CommunicationsLibrary.STXDataSocketServer.Definitions.STXDataSocketServerDefs;


namespace CommunicationsUISupportLibrary
{
	namespace publicationsConnection
	{
		
		[Serializable()]public class PublicationConnectionData
		{
			
#region  < DATAMEMBERS  >
			
			private string _publicationName;
			private CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.DPE_PublicationConnectionMode _connectionMode;
			
#endregion
			
#region  < CONSTRUCTORS  >
			
			public PublicationConnectionData(string publicationName, CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.DPE_PublicationConnectionMode connectionMode)
			{
				this._publicationName = publicationName;
				this._connectionMode = connectionMode;
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string PublicationName
			{
				get
				{
					return this._publicationName;
				}
			}
			
public CommunicationsLibrary.DataPublicationsEnvironment.Definitions.DPE_ServerDefs.DPE_PublicationConnectionMode ConnectionMode
			{
				get
				{
					return this._connectionMode;
				}
			}
			
#endregion
			
		}
		
	}
	
	
	
}
