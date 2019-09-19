using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.DiscoverableServiceHandling;


namespace CommunicationsLibrary
{
	public interface IDiscoverableService
	{
		
		DiscoverableServiceDefinitionHandlingServer ServiceHandlerServer {get;}
		string ServiceName {get;}
		
	}
	
	
}
