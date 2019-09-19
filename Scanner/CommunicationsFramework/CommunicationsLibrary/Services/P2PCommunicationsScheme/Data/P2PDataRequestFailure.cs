using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Services.Serialization;


namespace CommunicationsLibrary
{
	namespace Services.P2PCommunicationsScheme.Data
	{
		
		[Serializable()]public class P2PDataRequestFailure : IXMLDataString, IP2PData
		{
			
#region  < DATAMEMBERS >
			
			private string _XMLDataString;
			private string _operationID;
			private string _errorMessage;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			private P2PDataRequestFailure(P2PDataRequest P2PDataRequest, string errorMessage)
			{
				this._operationID = P2PDataRequest.P2PDataOperationID;
				this._errorMessage = errorMessage;
			}
			
			private P2PDataRequestFailure(string P2PDataOperationID, string errorMessage)
			{
				this._operationID = P2PDataOperationID;
				this._errorMessage = errorMessage;
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string ErrorMessage
			{
				get
				{
					return this._errorMessage;
				}
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < IXMLDataString >
			
			public string GetXMLString()
			{
				string dataXMLSection = "";
				dataXMLSection = System.Convert.ToString(UtilitiesLibrary.Data.XMLDataFormatting.GetDataVariableXMLString("ERROR_MESSAGE", this._errorMessage));
				
				string XMLString = "";
				XMLString = "<P2P_DATA_REQUEST_FAILURE P2PDataOperationID =" + "\"" + this.P2PDataOperationID + "\"" + ">" + dataXMLSection + "</P2P_DATA_REQUEST_FAILURE>";
				return XMLString;
			}
			
public string XMLDataString
			{
				get
				{
					if (this._XMLDataString == null)
					{
						this._XMLDataString = GetXMLString();
					}
					return this._XMLDataString;
				}
			}
			
#endregion
			
#region  < IP2PData>
			
public string P2PDataOperationID
			{
				get
				{
					return this._operationID;
				}
			}
			
#endregion
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
#region  <  SHARED METHODS >
			
			internal static P2PDataRequestFailure ParseAndGet_P2PDataRequestFailure_FromXMLDataString(string XMLString)
			{
				System.IO.StringReader sr = null;
				System.Xml.XmlTextReader m_xmlr = null;
				
				try
				{
					sr = new System.IO.StringReader(XMLString);
					m_xmlr = new System.Xml.XmlTextReader(sr);
					m_xmlr.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
				}
				catch (System.Xml.XmlException)
				{
					string msg;
					msg = "Error trying to get XML format from  P2PDataRequest Data string [" + XMLString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse P2PDataRequest  XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				m_xmlr.Read();
				string HeaderIdentifier = m_xmlr.Name;
				
				if (HeaderIdentifier != "P2P_DATA_REQUEST_FAILURE")
				{
					throw (new System.Xml.XmlException("Invalid P2PDataRequestFailure header \'" + HeaderIdentifier + "\'. It was expected to be \'P2P_DATA_REQUEST_FAILURE\'"));
				}
				else
				{
					//**********************************************************
					//retrieves the data operation type
					//**********************************************************
					string P2PDataOperationID = "";
					P2PDataOperationID = m_xmlr.GetAttribute("P2PDataOperationID");
					if (P2PDataOperationID == null)
					{
						P2PDataOperationID = Guid.NewGuid().ToString();
					}
					
					//**********************************************************
					//retrieves the data that holds the error message
					//**********************************************************
					m_xmlr.Read();
					string dataSectionName = m_xmlr.Name;
					DataVariable variable = default(DataVariable);
					if (dataSectionName == "DATA")
					{
						string variableXMLstring = m_xmlr.ReadOuterXml();
						variable = XMLDataFormatting.RetrieveDataVariableFromXMLString(variableXMLstring);
					}
					else
					{
						throw (new Exception("Invalid data XML section name \'" + dataSectionName + "\'. Is expected to be \'DATA\'"));
					}
					string errorMEssage = System.Convert.ToString(variable.Data);
					
					//creates the object to return to caller
					P2PDataRequestFailure reqFailure = new P2PDataRequestFailure(P2PDataOperationID, errorMEssage);
					return reqFailure;
				}
			}
			
			internal static dynamic GetP2PDataRequestFailure(P2PDataRequest request, string errorMessage)
			{
				P2PDataRequestFailure p2pdatREqFail = new P2PDataRequestFailure(request, errorMessage);
				return p2pdatREqFail;
			}
			
			internal static P2PDataRequestFailure Deserialize(byte[] data)
			{
				return ((P2PDataRequestFailure) (ObjectSerializer.DeserializeObjectFromByte(data)));
			}
			
#endregion
			
		}
		
		
	}
	
	
}
