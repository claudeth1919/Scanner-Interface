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


namespace DPEServerClientApp
{
	internal class DPE_ClientIdentificationCredential
	{
		public string ClientName;
		public string ClientID;
		
		public DPE_ClientIdentificationCredential(string STXDDSClientName, string STXDssClientID)
		{
			this.ClientName = STXDDSClientName;
			this.ClientID = STXDssClientID;
		}
	}
}
