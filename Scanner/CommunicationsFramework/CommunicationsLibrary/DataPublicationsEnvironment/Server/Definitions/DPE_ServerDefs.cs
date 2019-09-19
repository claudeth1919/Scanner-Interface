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
	namespace DataPublicationsEnvironment.Definitions
	{
		
		
		
		public sealed class DPE_ServerDefs
		{
			
#region  < DEFINITION OF THE AVAILABLE TCP PORTS RANGE FOR ALL THE RESOURCES OF THIS SERVICE >
			
			//************************************************************************
            //DEFINES A RANGE OF TCP PORTS WHERE THE STX DATA PUBLICATIONS SERVICE WILL WORK AS RESERVED
			
			internal const int INITIAL_TCP_PORT_DPE_SERVICE = 7251;
			internal const int FINAL_TCP_PORT_DPE_SERVICE = 27251;


            internal const string DPE_SERVER_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME = "DPE_SERVER_SERVICE_CONNECTION_PARAMETERS_TABLE_FILE_NAME.dat";
			
			//for fixed parameters
			internal const int DPE_SERVER_DEFAULT_CONNECTION_PORTNUMBER = 8253;
			internal const int DPE_SERVER_PUBLICATIONS_POSTING_PORTNUMBER = 8254;
			internal const int DPE_SERVER_PUBLICATIONS_INFORMATION_PORTNUMBER = 8255;
			internal const int DPE_SERVER_PUBLICATIONS_CLENTS_REGISTRATION_PORTNUMBER = 8256;
			
#endregion
			
#region  < SERVICE PARAMETERS CONSTANT DEFINITIONS >
			
			internal const string DATA_PUBLICATIONS_SERVICE_P2P_PORT = "DATA_PUBLICATIONS_SERVICE_P2P_PORT";
			internal const string DATA_PUBLICATIONS_SERVICE_HOSTNAME = "DATA_PUBLICATIONS_SERVICE_HOSTNAME";
			internal const string DATA_PUBLICATIONS_SERVICE_NAME = "DATA_PUBLICATIONS_SERVICE";
			internal const string DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING = "DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_DATABASE_CONNECTION_STRING";
			
			internal const string DATA_PUBLICATIONS_SERVICE_CLIENT_ID = "DATA_PUBLICATIONS_SERVICE_CLIENT_ID";
			internal const string DATA_PUBLICATIONS_SERVICE_SERVER_NAME = "DATA_PUBLICATIONS_SERVICE";
			
			
			
			internal const string DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT = "DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_POSTING_P2PPORT";
			internal const string DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT = "DATA_PUBLICATIONS_SERVICE_PUBLICATIONS_INFORMATION_RETRIEVE_P2PPORT";
			internal const string DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT = "DATA_PUBLICATIONS_SERVICE_CLIENT_REGISTRATION_DATA_P2PPORT";
			
			
			
#endregion
			
#region  < SERVICE CONFORMATION KEY COMMAND >
			
			internal const string DPE_PUBLICATIONS_SERVICE_PORT_CONNECTION_CHECK_DATA = "STX_DATA_SOCKET_SERVICE_PORT_CONNECTION_CHECK_COMMAND";
			
#endregion
			
#region  < CLIENT COMMANDS >
			
			internal const string DPE_CMD_CREATE_PUBLICATION = "DPE_CMD_CREATE_PUBLICATION";
			internal const string DPE_CMD_DISPOSE_PUBLICATION = "DPE_CMD_DISPOSE_PUBLICATION";
			internal const string DPE_CMD_ADD_PUBLICATION_VARIABLE = "DPE_CMD_ADD_PUBLICATION_VARIABLE";
			internal const string DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES = "DPE_CMD_ADD_PUBLICATION_GROUP_OF_VARIABLES";
			
			internal const string DPE_CMD_REMOVE_PUBLICATION_VARIABLE = "DPE_CMD_REMOVE_PUBLICATION_VARIABLE";
			internal const string DPE_CMD_SET_PUBLICATION_GROUP = "DPE_CMD_SET_PUBLICATION_GROUP";
			
			internal const string DPE_CMD_CLIENT_REGISTRATION_DATA = "DPE_CMD_CLIENT_REGISTRATION_DATA";
			internal const string DPE_CMD_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY = "DPE_CMD_CLIENT_SOCKETSERVER_PUBLICATION_CONNECTION_INQUIRY";
			
			internal const string DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION = "DPE_CMD_CLIENT_PUBLICATION_CONNECTION_REGISTRATION";
			internal const string DPE_CMD_PUBLICATION_SUBSCRIPTION_DATA = "DPE_CMD_PUBLICATION_SUBSCRIPTION_DATA";
			internal const string DME_CMD_SERVICE_PARAMETERS = "DME_CMD_SERVICE_PARAMETERS";
			internal const string DPE_CMD_CLIENTS_REGISTRY_TABLE = "DPE_CMD_CLIENTS_REGISTRY_TABLE";
			internal const string DPE_CMD_PUBLISHER_CLIENTS_REGISTRY_TABLE = "DPE_CMD_PUBLISHER_CLIENTS_REGISTRY_TABLE";
			internal const string DPE_CMD_PUBLICATIONS_REGISTRY_TABLE = "DPE_CMD_PUBLICATIONS_REGISTRY_TABLE";
			internal const string DPE_CMD_PUBLICATION_PUBLISHED_VARIABLES_TABLE = "DPE_CMD_PUBLICATION_PUBLISHED_VARIABLES_TABLE";
			internal const string DPE_CMD_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST = "DPE_CMD_CLIENT_SUBSCRIPTIONS_TO_PUBLICATIONS_LIST";
			internal const string DPE_CMD_CLIENT_POSTED_PUBLICATIONS_LIST = "DPE_CMD_CLIENT_POSTED_PUBLICATIONS_LIST";
			internal const string DPE_CMD_PUBLICATION_ATTACHED_CLIENTS_TABLE = "DPE_CMD_PUBLICATION_ATTACHED_CLIENTS_TABLE";
			internal const string DPE_CMD_CLIENT_DEDICATED_PORT_PARAMETERS = "DPE_CMD_CLIENT_DEDICATED_PORT_PARAMETERS";
            internal const string DPE_CMD_CLIENT_POSTED_PUBLICATIONS_TABLE = "DPE_CMD_CLIENT_POSTED_PUBLICATIONS_TABLE";
			internal const string DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS = "DPE_CMD_PUBLICATION_RESET_PUBLICATION_STATISTICS";			
			internal const string DPE_CMD_MULITCASTSERVER_CONNECTION_INFORMATION_DATA_TABLE = "DPE_CMD_MULITCASTSERVER_CONNECTION_INFORMATION_DATA_TABLE";
			
			
			internal const string DPE_CLIENT_NETWORK_ID = "DPE_CLIENT_NETWORK_ID";
			internal const string DPE_CLIENT_NAME = "DPE_CLIENT_NAME";
			internal const string DPE_CLIENT_HOST_NAME = "DPE_CLIENT_HOST_NAME";
			internal const string DPE_CLIENT_TYPE = "DPE_CLIENT_TYPE";
			internal const string DPE_CLIENT_APPDOMAIN_NAME = "DPE_CLIENT_APPDOMAIN_NAME";
			
			
			
#endregion
			
#region  < DEFINITIONS RELATED TO THE CLIENTS REGISTRY DATATABLE  CLASS (DPE_ClientsManager)>
			
			
			public const string DPE_ClientsManager_CLIENT_HOSTNAME = "Client HostName";
			public const string DPE_ClientsManager_CLIENT_APPDOMAIN = "Client AppDomain";
			public const string DPE_ClientsManager_CLIENT_NAME = "Client Name";
			
#endregion
			
#region  < SERVICE STATUS BROADCAST >
			
			//CLIENT CONNECTIONS
			internal const string DPE_NEW_CLIENT_CONNECTED = "DPE_NEW_CLIENT_CONNECTED";
			internal const string DPE_CLIENT_DISCONNECTED = "DPE_CLIENT_DISCONNECTED";
			
			//PUBLICATIONS
			internal const string DPE_PUBLICATION_CREATED = "DPE_PUBLICATION_CREATED";
			internal const string DPE_PUBLICATION_DISPOSED = "DPE_PUBLICATION_DISPOSED";
			internal const string DPE_PUBLICATION_VARIABLE_ADDED = "DPE_PUBLICATION_VARIABLE_ADDED";
			internal const string DPE_PUBLICATION_VARIABLE_REMOVED = "DPE_PUBLICATION_VARIABLE_REMOVED";
			internal const string DPE_PUBLICATION_CLIENT_CONNECTION = "DPE_PUBLICATION_CLIENT_CONNECTION";
			internal const string DPE_PUBLICATION_CLIENT_DISCONNECTION = "DPE_PUBLICATION_CLIENT_DISCONNECTION";
			
#endregion
			
			
#region  < PUBLICATION CONNECTION MODE  >
			
			[Serializable()]public enum DPE_PublicationConnectionMode
			{
				ReceiveLastPublicationStatus,
				NotReceiveLastPublicationStatus
			}
			
			public static DPE_PublicationConnectionMode Get_STXDSS_PublicationConnectionMode_FromString(string STXDSS_PublicationConnectionModeAsString)
			{
				switch (STXDSS_PublicationConnectionModeAsString)
				{
					case "ReceiveLastPublicationStatus":
						return DPE_PublicationConnectionMode.ReceiveLastPublicationStatus;
					case "NotReceiveLastPublicationStatus":
						return DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus;
					default:
						return DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus;
				}
			}
			
			public static string Get_STXDSS_PublicationConnectionMode_ToAString(DPE_PublicationConnectionMode mode)
			{
				switch (mode)
				{
					case DPE_PublicationConnectionMode.ReceiveLastPublicationStatus:
						return "ReceiveLastPublicationStatus";
					case DPE_PublicationConnectionMode.NotReceiveLastPublicationStatus:
						return "NotReceiveLastPublicationStatus";
					default:
						return "NotReceiveLastPublicationStatus";
				}
			}
			
#endregion
			
#region  < PUBLICATIONS RELATED FLAGS >
			
			internal const string DPE_PUBLICATION_UPDATE_FLAG = "DPE_PUBLICATION_UPDATE_FLAG";
			internal const string DPE_PUBLICATION_DATA_UPDATE = "DPE_PUBLICATION_DATA_UPDATE";
			internal const string DPE_PUBLICATION_DATA_RESET = "STXDSSPUBLICATION_DATA_CLEAR";			
			internal const string DPE_PUBLICATION_NAME = "DPE_PUBLICATION_NAME";
			
#endregion
			
#region  < PUBLICATION DEFINITION OF VARIABLES GROUP TABLE CONSTANTS >
			
			public const string VARIBLE_NAME_TABLE_COLUMN_NAME = "VARIBLE_NAME";
			public const string DATATYPE_TABLE_COLUMN_NAME = "DATA_TYPE";
			
#endregion
			
			[Serializable()]public enum PublicationVariableDataType
			{
				DPE_DT_String,
				DPE_DT_Integer,
				DPE_DT_Decimal,
				DPE_DT_Boolean,
				DPE_DT_DataTable,
				DPE_DT_DataSet,
				DPE_DT_CFHashTable,
				DPE_DT_CFList,
				DPE_DT_CFSortedList,
				DPE_DT_Undefined
			}
			
			
#region  < DATA CONVERTION >
			
			public static PublicationVariableDataType Get_PublicationVariableDataType_FromString(string variableDataType)
			{
				switch (variableDataType)
				{
                    case "DPE_DT_String":
						return PublicationVariableDataType.DPE_DT_String;

                    case "DPE_DT_Integer":
						return PublicationVariableDataType.DPE_DT_Integer;

                    case "DPE_DT_Decimal":					
						return PublicationVariableDataType.DPE_DT_Decimal;

                    case "DPE_DT_Boolean":
					    return PublicationVariableDataType.DPE_DT_Boolean;

                    case "DPE_DT_DataTable":
					
						return PublicationVariableDataType.DPE_DT_DataTable;
                    case "DPE_DT_DataSet":
					
						return PublicationVariableDataType.DPE_DT_DataSet;
					case "DPE_DT_CFHashTable":
					
						return PublicationVariableDataType.DPE_DT_CFHashTable;
					case "DPE_DT_CFList":
					
						return PublicationVariableDataType.DPE_DT_CFList;
					case "DPE_DT_CFSortedList":
					
						return PublicationVariableDataType.DPE_DT_CFSortedList;
					default:
						throw (new Exception("Invalid data type \'" + variableDataType + "\'"));
				}
			}
			
			public static string Get_String_FromPublicationVariableDataType(PublicationVariableDataType PublicationVariableDataType)
			{
				switch (PublicationVariableDataType)
				{
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean:
						return "DPE_DT_Boolean";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFHashTable:
						return "DPE_DT_CFHashTable";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFList:
						return "DPE_DT_CFList";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFSortedList:
						return "DPE_DT_CFSortedList";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataSet:
						return "DPE_DT_DataSet";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable:
						return "DPE_DT_DataTable";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal:
						return "DPE_DT_Decimal";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer:
						return "DPE_DT_Integer";
					case DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String:
						return "DPE_DT_String";
					default:
						return "unknown";
				}
			}
			
#endregion
			
			
			
		}
		
		
	}
	
}
