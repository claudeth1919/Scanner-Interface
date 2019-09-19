using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;


namespace CommunicationsUISupportLibrary
{
	public partial class CF_DPE_ConnectionMode
	{
        public DPE_ServerDefs.DPE_PublicationConnectionMode ConnectionMode
		{
			get
			{
				if (this.rbtnREceiveLastStatus.Checked)
				{
                    return DPE_ServerDefs.DPE_PublicationConnectionMode.ReceiveLastPublicationStatus;
				}
				else
				{
                    return DPE_ServerDefs.DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus;
				}
			}
		}
		
	}
}
