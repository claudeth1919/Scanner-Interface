using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.CNDCommunicationsEnvironment.ComponentNetworkDirectoryService;
using UtilitiesLibrary.EventLoging;


namespace CNDServerService
{
	public partial class CNDServerWinService
	{
		
		//static void Main()
		//{
			//System.Windows.Forms.Application.Run(new CNDServerService());
			//}
			
			
#region  < DATA MEMBERS >
			
			private CNDService _CNDService;
			
#endregion
			
			
			protected override void OnStart(string[] args)
			{
				// Add code here to start your service. This method should set things
				// in motion so your service can do its work.
				try
				{
					this._CNDService = CNDService.GetInstance();
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				
			}
			
			protected override void OnStop()
			{
				// Add code here to perform any tear-down necessary to stop your service.
				try
				{
					this._CNDService.Dispose();
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
			}
			
			protected override void OnShutdown()
			{
				try
				{
					base.OnShutdown();
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
				try
				{
					this._CNDService.Dispose();
				}
				catch (Exception ex)
				{
					CustomEventLog.WriteEntry(EventLogEntryType.Error, ex.ToString());
				}
			}
			
		}
		
	}
