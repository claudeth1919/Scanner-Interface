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

using CommunicationsLibrary.Services.SocketsDataDistribution.Data;



namespace SocketsServerTestApp
{
	public partial class frmDataReceivedView
	{
		
		public frmDataReceivedView(SocketData data)
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this.CfDataDisplayCtrl1.ShowData(data.Value);
			this.txtXML.Text = data.XMLDataString;
		}
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			this.Dispose();
		}
		
		public void frmDataReceivedView_Load(System.Object sender, System.EventArgs e)
		{
			
		}
	}
}
