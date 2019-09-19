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

using System.ServiceProcess;


namespace CNDServerService
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class CNDServerWinService : System.ServiceProcess.ServiceBase
	{
		
		//UserService overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		// The main entry point for the process
		[MTAThread()][System.Diagnostics.DebuggerNonUserCode()]static public void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun = null;
			
			// More than one NT Service may run within the same process. To add
			// another service to this process, change the following line to
			// create a second service object. For example,
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] {new CNDServerWinService()};
			
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}
		
		//Required by the Component Designer
		private System.ComponentModel.Container components = null;
		
		// NOTE: The following procedure is required by the Component Designer
		// It can be modified using the Component Designer.
		// Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            // 
            // CNDServerWinService
            // 
            this.CanHandlePowerEvent = true;
            this.ServiceName = "CNDServer";

		}
		
	}
	
}
