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
	namespace CNDCommunicationsEnvironment.ComponentNetworkDirectoryService
	{
		
		
		public sealed class CNDServiceDefinitions
		{
			
					
			internal const int CND_SERVICE_DEFAULT_PORT = 9258;
			internal const int CND_SERVICE_MULTICAST_PORT = 9259;
			internal const string CND_SERVICE_MULTICAST_IP_ADDRESS = "234.95.234.255";
			internal const string CND_SERVICE_SERVICE_PARAMETERS_TABLE_FILENAME = "CND_SERVICE_SERVICE_PARAMETERS_TABLE.dat ";
					
			
			
			
			internal const string CND_TABLE_FILE_NAME = "CNDTable.CNDDat";
			internal const string CND_TABLE_DATA_NAME = "CND_SERVICE_TABLE";
			
			internal const string CND_NEW_REGISTRATION_INSERT = "CND_REGISTER_INSERT";
			internal const string CND_EXISTING_REGISTRATION_REMOVE = "CND_REGISTER_DELETE";
			
			internal const string CNDSERVICE_P2PPORT_OWNERNAME = "CND_SERVICE";
            internal const string CND_SERVICE_NAME = "CND_DSH_SERVICE_NAME";
			internal const string CNDSERVICE_PUBLIC_NAME = "COMPONENT NETWORK DIRECTORY SERVICE";
			
			internal const string CND_SERVICE_HOSTNAME = "CND_SERVICE_HOSTNAME";
            internal const string CND_SERVICE_IP_ADDRESS = "CND_SERVICE_IP_ADDRESS";

			internal const string CND_SERVICE_P2PPORT_PORTNUMBER = "CND_SERVICE_P2PPORT_PORTNUMBER";
			internal const string CND_SERVICE_SOCKETSSERVER_PORTNUMBER = "CND_SERVICE_SOCKETSSERVER_PORTNUMBER";
			internal const string CND_SERVICE_MULTICASTSERVER_IP_ADDRESS = "CND_SERVICE_MULTICASTSERVER_IP_ADDRESS";
			internal const string CND_SERVICE_MULTICASTSERVER_PORTNUMBER = "CND_SERVICE_MULTICASTSERVER_PORTNUMBER";
			
			internal const string CND_SERVICE_PORT_CONNECTION_CHECK_DATA = "CND_SERVICE_PORT_CONNECTION_CHECK_COMMAND";
			
			
			internal const string CND_COMPONENT_REGISTRATION_CMD = "CND_COMPONENT_REGISTRATION_CMD";
			internal const string CND_COMPONENT_REGISTRATION_REMOVAL_CMD = "CND_COMPONENT_REGISTRATION_REMOVAL_CMD";
			
			internal const string CND_GET_COMPONENT_CND_REGISTRY_CMD = "CND_GET_COMPONENT_CND_REGISTRY_CMD";
			
			internal const string COMPONENT_NAME = "COMPONENT_NAME";
			public const string HOST_NAME = "Hostname";
			public const string P2P_PORT_NUMBER = "P2PPortNumber";
			public const string IP_ADDRESS = "IPAddress";
			public const string APPLICATION_NAME = "Application Name";
			public const string APPLICATION_PROCESS_ID = "Application Process ID";
			public const string REGISTRATION_DATETIME = "Registration Date Time";
			
			//CND TABLE FIELD NAMES
			public const string CND_TABLE_COMPONENT_NAME = "Component Name";
			public const string CND_TABLE_HOST_NAME = "Hostname";
			public const string CND_TABLE_P2P_PORT_NUMBER = "P2PPortNumber";
			public const string CND_TABLE_IP_ADDRESS = "IPAddress";
			public const string CND_TABLE_APPLICATION_NAME = "Application Name";
			public const string CND_TABLE_APPLICATION_PROCESS_ID = "Application Process ID";
			public const string CND_TABLE_REGISTRATION_DATETIME = "Registration Date Time";
			
		}
		
		
	}
	
}
