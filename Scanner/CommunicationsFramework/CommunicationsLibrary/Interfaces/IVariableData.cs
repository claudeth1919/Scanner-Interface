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
	internal interface IEnvironmentVariable
	{
		
		string DataName {get;}
		dynamic Value {get;}
		
	}
	
	
}
