using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.Services.DiscoverableServiceHandling.Data;


namespace CommunicationsLibrary
{
	namespace Services.DiscoverableServiceHandling.Definitions
	{
		
		public sealed class DiscoverableServiceHandlingOperativeDefs
		{
			
			
			public enum DiscoverableServiceMode
			{
				singletonInstanceNetworkService,
				multipleNetworkInstancesService,
				undefined
			}
			
			public struct DiscoverableServiceDefinition
			{
				internal string ServiceIDString;
				public string ServiceName;
				public DiscoverableServiceMode ServiceOperationMode;
				public DiscoverableServiceDefinitionParametersContainer ServiceParameters;
			}
			
			
			internal const int DSH_SERVICE_HANDLER_BROADCAST_TCP_PORT = 4000;
			internal const string DHS_SERVICE_HANDLER_BROADCAST_IP_ADDRESS = "224.5.6.7";
			
			internal const int MAX_TIMEOUT_FOR_STX_NETWORK_REPLY = 5;
			internal const string SERVICE_NAME_QUERY_BROADCAST_ID_NAME_STRING = "SERVICE_QUERING";
			internal const string SERVICE_NAME = "SERVICE_NAME";
			internal const string SERVICE_ID = "SERVICE_ID";
			internal const string SERVICE_NAME_QUERY_REPLYIDNAME_STRING = "SERVICE_QUERING_REPLY";
			internal const string SERVICE_PARAMETERS_TABLE = "SERVICE_PARAMETERS_TABLE";
			internal const string SERVICE_OPERATION_MODE = "SERVICE_MODE";
			internal const string STX_SERVICE_BROADCAST_CLIENT_NAME = "SERVICE_BROADCAST_CLIENT_NAME";
			
			
			internal const string MULTIPLE_NETWORK_INSTANCES_SERVICE_TYPE = "MULTIPLE_NETWORK_INSTANCES_SERVICE_TYPE";
			internal const string SINGLE_NETWORK_INSTANCE_SERVICE_TYPE = "SINGLE_NETWORK_INSTANCE_SERVICE_TYPE";
			internal const string UNDEFINED_NETWORK_SERVICE_TYPE = "UNDEFINED_NETWORK_SERVICE_TYPE";
			
#region  < FRIEND METHODS >
			
			internal static string GetServiceOperationModeAsString(DiscoverableServiceMode mode)
			{
				switch (mode)
				{
					case DiscoverableServiceMode.multipleNetworkInstancesService:
						return MULTIPLE_NETWORK_INSTANCES_SERVICE_TYPE;
					case DiscoverableServiceMode.singletonInstanceNetworkService:
						return SINGLE_NETWORK_INSTANCE_SERVICE_TYPE;
					case DiscoverableServiceMode.undefined:
						return UNDEFINED_NETWORK_SERVICE_TYPE;
					default:
						return UNDEFINED_NETWORK_SERVICE_TYPE;
				}
			}
			
			internal static DiscoverableServiceMode GetServiceOperationModeFromString(string mode)
			{
				switch (mode)
				{
					case MULTIPLE_NETWORK_INSTANCES_SERVICE_TYPE:
						return DiscoverableServiceMode.multipleNetworkInstancesService;
					case SINGLE_NETWORK_INSTANCE_SERVICE_TYPE:
						return DiscoverableServiceMode.singletonInstanceNetworkService;
					case UNDEFINED_NETWORK_SERVICE_TYPE:
						return DiscoverableServiceMode.undefined;
					default:
						return DiscoverableServiceMode.undefined;
				}
			}
			
#endregion
			
		}
		
	}
	
	
	
}
