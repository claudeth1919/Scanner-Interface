using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;



namespace CommunicationsLibrary
{
	namespace Services.BroadCasting
	{
		
		
		public class DataBroadCastWaitReplyException : ApplicationException
		{
			
#region  < CONSTRUCTORS >
			
			internal DataBroadCastWaitReplyException() : base("No such reply received from a data broad cast operation over network")
			{
			}
#endregion
		}
		
		
	}
	
	
	
	
}
