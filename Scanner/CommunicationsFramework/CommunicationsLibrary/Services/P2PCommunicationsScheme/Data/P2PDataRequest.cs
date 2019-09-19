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
		
		[Serializable()]public class P2PDataRequest : IXMLDataString, IP2PData
		{
			
#region  < DATAMEMBERS >
			
			private string _DataNameToRequest;
			private CustomHashTable _parametersTable;
			private string _XMLDataString;
			private string _operationID;
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public P2PDataRequest(string dataNameToRequest)
			{
				this._DataNameToRequest = dataNameToRequest.ToUpper();
				this._operationID = Guid.NewGuid().ToString();
				this._parametersTable = new CustomHashTable();
                this._XMLDataString = "";
			}
			
			private P2PDataRequest(string dataNameToRequest, CustomHashTable parametersTable)
			{
				this._DataNameToRequest = dataNameToRequest.ToUpper();
				this._operationID = Guid.NewGuid().ToString();
				this._parametersTable = parametersTable;
				this._XMLDataString = "";
			}
			
#endregion
			
#region  < PROPERTIES >
			
public string RequestedDataName
			{
				get
				{
					return this._DataNameToRequest;
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AddRequestParameter(string ParameterName, string parameterValue)
			{
				ParameterName = ParameterName.ToUpper();
				if (!this._parametersTable.ContainsKey(ParameterName))
				{
					this._parametersTable.Add(ParameterName, parameterValue);
				}
				else
				{
					throw (new Exception("The parameter \'" + ParameterName + "\' is already included on the parameters table."));
				}
			}
			
			public void RemoveRequestParameter(string ParameterName)
			{
				ParameterName = ParameterName.ToUpper();
				if (this._parametersTable.ContainsKey(ParameterName))
				{
					this._parametersTable.Remove(ParameterName);
				}
			}
			
			public bool ContainsRequestParameter(string ParameterName)
			{
				ParameterName = ParameterName.ToUpper();
				return this._parametersTable.ContainsKey(ParameterName);
			}
			
			public string GetRequestParameter(string ParameterName)
			{
				ParameterName = ParameterName.ToUpper();
				return this._parametersTable.Item(ParameterName);
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION  >
			
#region  < IXMLDataString >
			
			public string GetXMLString()
			{
				string XMLString = "";
				
				string attrListXMLSection = "";
				if (this._parametersTable.Count > 0)
				{
					string attrListAsXML = XMLDataFormatting.GetDataVariableXMLString("DATA_REQUEST_PARAMETERS_TABLE", this._parametersTable);
					attrListXMLSection = "<DATA_REQUEST_PARAMETERS  ParametersCount=" + "\"" + System.Convert.ToString(this._parametersTable.Count) + "\"" + ">" + attrListAsXML + "</DATA_REQUEST_PARAMETERS>";
				}
				else
				{
					attrListXMLSection = "<DATA_REQUEST_PARAMETERS  ParametersCount=\"0\"></DATA_REQUEST_PARAMETERS>";
					
				}
				XMLString = "<P2P_DATAREQUEST datanameToRequest=" + "\"" + this._DataNameToRequest + "\"" + ">" + attrListXMLSection + "</P2P_DATAREQUEST>";
				return XMLString;
			}
			
public string XMLDataString
			{
				get
				{
					if ((this._XMLDataString == null) || (this._XMLDataString.Length <=0))
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
			
#region  <  SHARED METHODS >
			
			internal static P2PDataRequest ParseAndGet_P2PDataRequest_FromXMLDataString(string XMLString)
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
				
				if (HeaderIdentifier != "P2P_DATAREQUEST")
				{
					throw (new System.Xml.XmlException("Invalid P2PDataRequest header " + HeaderIdentifier + ". Must be \'P2P_DATAREQUEST\'"));
				}
				else
				{
					string datanameToRequest = m_xmlr.GetAttribute("datanameToRequest");
					if (datanameToRequest == null)
					{
						throw (new Exception("No dataname to retrieve attribute found in the P2PDataRequest XML String"));
					}
					
					m_xmlr.Read();
					string AttributesSectionName = m_xmlr.Name;
					
					if (AttributesSectionName != "DATA_REQUEST_PARAMETERS")
					{
						throw (new Exception("Invalid section name \'" + AttributesSectionName + "\'"));
					}
					string parametersCountStr = m_xmlr.GetAttribute("ParametersCount");
					int numOfParameters = 0;
					CustomHashTable parametersTable = null;
					
					if (!(parametersCountStr == null))
					{
						numOfParameters = System.Convert.ToInt32(parametersCountStr);
						if (numOfParameters > 0)
						{
							string attrTableXMLString = m_xmlr.ReadInnerXml();
							DataVariable tableVar = default(DataVariable);
							tableVar = XMLDataFormatting.RetrieveDataVariableFromXMLString(attrTableXMLString);
                            parametersTable = (CustomHashTable)tableVar.Data;
						}
					}
					else
					{
						throw (new Exception("The parameter \'AttrCount\' is missing on the XML string of the section \'REQUEST_ATTRIBUTES\'"));
					}
					
					
					P2PDataRequest dataRq = default(P2PDataRequest);
					if (numOfParameters > 0)
					{
						if (!(parametersTable == null))
						{
							dataRq = new P2PDataRequest(datanameToRequest, parametersTable);
						}
						else
						{
							dataRq = new P2PDataRequest(datanameToRequest);
						}
					}
					else
					{
						dataRq = new P2PDataRequest(datanameToRequest);
					}
					return dataRq;
				}
			}
			
			public static P2PDataRequest Deserialize(byte[] requestAsByte)
			{
				return ((P2PDataRequest) (ObjectSerializer.DeserializeObjectFromByte(requestAsByte)));
			}
			
#endregion
			
		}
		
		
	}
	
	
}
