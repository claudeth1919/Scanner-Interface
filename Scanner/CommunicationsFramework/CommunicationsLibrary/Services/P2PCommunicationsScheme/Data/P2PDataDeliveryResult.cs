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
		
		[Serializable()]public class P2PDataDeliveryResult : IP2PData, IXMLDataString
		{
			
			
#region  < DATA MEMBERS >
			
			[Serializable()]internal enum DeliveryResultType
			{
				DeliverySucceed,
				DeliveryFailure
			}
			
			private string _P2PDataOperationID;
			private string _XMLDataString;
			private DeliveryResultType _resultType;
			private string _messageError;
			
			
#endregion
			
#region  < PROPERTIES >
			
internal DeliveryResultType ResultType
			{
				get
				{
					return this._resultType;
				}
			}
			
public string ResultMessage
			{
				get
				{
					return this._messageError;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			private P2PDataDeliveryResult(P2PData data, string ErrorMEssage)
			{
				this._P2PDataOperationID = data.P2PDataOperationID;
				this._resultType = DeliveryResultType.DeliveryFailure;
				this._messageError = ErrorMEssage;
			}
			
			private P2PDataDeliveryResult(P2PData data)
			{
				this._P2PDataOperationID = data.P2PDataOperationID;
				this._resultType = DeliveryResultType.DeliverySucceed;
				this._messageError = "Data Delivery Succeed";
			}
			
			private P2PDataDeliveryResult(string P2PDataOperationID, string ErrorMEssage)
			{
				this._P2PDataOperationID = P2PDataOperationID;
				this._resultType = DeliveryResultType.DeliveryFailure;
				this._messageError = ErrorMEssage;
			}
			
			private P2PDataDeliveryResult(string P2PDataOperationID)
			{
				this._P2PDataOperationID = P2PDataOperationID;
				this._resultType = DeliveryResultType.DeliverySucceed;
				this._messageError = "Data Delivery Succeed";
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static P2PDataDeliveryResult GetSucceedDeliveryResult(P2PData data)
			{
				P2PDataDeliveryResult result = new P2PDataDeliveryResult(data);
				return result;
			}
			
			internal static P2PDataDeliveryResult GetSucceedDeliveryResult(string P2PDataOperationID)
			{
				P2PDataDeliveryResult result = new P2PDataDeliveryResult(P2PDataOperationID);
				return result;
			}
			
			internal static P2PDataDeliveryResult GetFailureDeliveryResult(P2PData data, string errorMessage)
			{
				P2PDataDeliveryResult result = new P2PDataDeliveryResult(data, errorMessage);
				return result;
			}
			
			internal static P2PDataDeliveryResult GetFailureDeliveryResult(string P2PDataOperationID, string errorMessage)
			{
				P2PDataDeliveryResult result = new P2PDataDeliveryResult(P2PDataOperationID, errorMessage);
				return result;
			}
			
			
			internal static P2PDataDeliveryResult ParseAndGet_P2PDataDeliveryResult_FromXMLDataString(string XMLString)
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
					msg = "Error trying to get XML format from  P2P Data string [" + XMLString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse P2P socket XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				m_xmlr.Read();
				string HeaderIdentifier = m_xmlr.Name;
				
				if (HeaderIdentifier != "P2P_DATA_DELIVERY_RESULT")
				{
					throw (new System.Xml.XmlException("Invalid data header " + HeaderIdentifier + ". It was expected to be \'P2P_DATA_DELIVERY_RESULT\'"));
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
					
					string DeliveryResultType = "";
					DeliveryResultType = m_xmlr.GetAttribute("DeliveryResultType");
					if (DeliveryResultType == null)
					{
						DeliveryResultType = "DeliverySucceed";
					}
					
					//**********************************************************
					//retrieves the data itself
					//**********************************************************
					m_xmlr.Read();
					string dataSectionName = m_xmlr.Name;
                    DataVariable variable;
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
					
					P2PDataDeliveryResult result = null;
					switch (DeliveryResultType)
					{
						case "DeliveryFailure":
							result = P2PDataDeliveryResult.GetFailureDeliveryResult(P2PDataOperationID, errorMEssage);
							break;
						case "DeliverySucceed":
							result = P2PDataDeliveryResult.GetSucceedDeliveryResult(P2PDataOperationID);
							break;
					}
					return result;
				}
			}
			
			internal static P2PDataDeliveryResult Deserialize(byte[] data)
			{
				return ((P2PDataDeliveryResult) (ObjectSerializer.DeserializeObjectFromByte(data)));
			}
			
			
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < IP2PData >
			
public string P2PDataOperationID
			{
				get
				{
					return this._P2PDataOperationID;
				}
			}
			
#endregion
			
#region  < IXMLDataString >
			
			public string GetXMLString()
			{
				string dataXMLSection = "";
				string XMLString = "";
				
				dataXMLSection = XMLDataFormatting.GetDataVariableXMLString("RESULT_MESSAGE", this._messageError);
				
				switch (this._resultType)
				{
					case DeliveryResultType.DeliveryFailure:
						XMLString = "<P2P_DATA_DELIVERY_RESULT P2PDataOperationID=\"" + this._P2PDataOperationID + "\" DeliveryResultType=\"DeliveryFailure\">" + dataXMLSection + "</P2P_DATA_DELIVERY_RESULT>";
						break;
					case DeliveryResultType.DeliverySucceed:
						XMLString = "<P2P_DATA_DELIVERY_RESULT P2PDataOperationID=\"" + this._P2PDataOperationID + "\" DeliveryResultType=\"DeliverySucceed\">" + dataXMLSection + "</P2P_DATA_DELIVERY_RESULT>";
						break;
				}
				return XMLString;
			}
			
public string XMLDataString
			{
				get
				{
					if (this._XMLDataString == null)
					{
						this._XMLDataString = this.GetXMLString();
					}
					return this._XMLDataString;
				}
			}
			
#endregion
			
#endregion
			
			
			
		}
		
		
	}
	
}
