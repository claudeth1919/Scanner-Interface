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

using System.ComponentModel;
using System.Configuration.Install;


namespace CNDServerService
{
	public partial class ProjectInstaller
	{
		
		public ProjectInstaller()
		{
			
			//This call is required by the Component Designer.
			InitializeComponent();
			
			//Add initialization code after the call to InitializeComponent
			
		}
		
		public void ServiceInstaller_AfterInstall(System.Object sender, System.Configuration.Install.InstallEventArgs e)
		{
			
		}
	}
	
}
