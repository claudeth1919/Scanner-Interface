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
		
		[Serializable()]public class P2PData : IXMLDataString, IEnvironmentVariable, IP2PData
		{
			
#region  < DATAMEMBERS >
			
			
			private object _data;
			private string _dataName;
			private string _XMLDataString;
			private P2PDataAttributesTable _dataAttributesTable;
			private string _P2PDataOperationID;
			
			
#endregion
			
#region  < PROPERTIES >
			
			
        public P2PDataAttributesTable DataAttributesTable
		{
			get
			{
				return this._dataAttributesTable;
			}
		}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			private P2PData(string P2PDataOperationID, string dataName, object data)
			{
				this._data = data;
				this._dataName = dataName.ToUpper();
				this._dataAttributesTable = new P2PDataAttributesTable();
				this._P2PDataOperationID = P2PDataOperationID;
			}
			
			private P2PData(string dataName, object data)
			{
				this._data = data;
				this._dataName = dataName.ToUpper();
				this._dataAttributesTable = new P2PDataAttributesTable();
				this._P2PDataOperationID = Guid.NewGuid().ToString();
			}
			
			public P2PData(string dataname, int data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, decimal data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, bool data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, string data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, DataTable data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, DataSet data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, CustomHashTable data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, CustomList data) : this(dataname, (object) data)
			{
			}
			
			public P2PData(string dataname, CustomSortedList data) : this(dataname, (object) data)
			{
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IXMLDataString  >
			
			public string GetXMLString()
			{
				string dataXMLSection = "";
				string XMLString = "";
				dataXMLSection = XMLDataFormatting.GetDataVariableXMLString(this.DataName, this.Value);
				
				string attrListXMLSection = "";
				if (this._dataAttributesTable.count > 0)
				{
					string attrListAsXML = XMLDataFormatting.GetDataVariableXMLString("DATA_ATTRIBUTES_TABLE", this._dataAttributesTable.Table);
					attrListXMLSection = "<DATA_ATTRIBUTES  DataAttrCount=" + "\"" + System.Convert.ToString(this._dataAttributesTable.count) + "\"" + ">" + attrListAsXML + "</DATA_ATTRIBUTES>";
				}
				else
				{
					attrListXMLSection = "<DATA_ATTRIBUTES  DataAttrCount=\"0\"></DATA_ATTRIBUTES>";
				}
				XMLString = "<P2P_DATA P2PDataOperationID=" + "\"" + this.P2PDataOperationID + "\"" + ">" + dataXMLSection + attrListXMLSection + "</P2P_DATA>";
				
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
			
#region  < IVariableData  >
			
public dynamic Value
			{
				get
				{
					return this._data;
				}
			}
			
public string DataName
			{
				get
				{
					return this._dataName;
				}
			}
			
#endregion
			
#region  < IP2PData>
			
public string P2PDataOperationID
			{
				get
				{
					return this._P2PDataOperationID;
				}
			}
			
#endregion
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static P2PData ParseAndGet_P2PData_FromXMLDataString(string XMLString)
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
				
				if (HeaderIdentifier != "P2P_DATA")
				{
					throw (new System.Xml.XmlException("Invalid P2P data header " + HeaderIdentifier + ". Must be \'P2P_DATA\'"));
				}
				else
				{
					//**********************************************************
					//retrieves the data operation type
					//**********************************************************
					
					string operationID = "";
					operationID = m_xmlr.GetAttribute("P2PDataOperationID");
					if (operationID == null)
					{
						operationID = Guid.NewGuid().ToString();
					}
					
					//**********************************************************
					//retrieves the data itself
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
					
					//**********************************************************
					//retrieves the attributes table and its XML attributes
					//**********************************************************
					string dataAttributesSectionName = m_xmlr.Name;
					P2PDataAttributesTable attrTAble = null;
					int AttrCount = 0;
					
					if (dataAttributesSectionName == "DATA_ATTRIBUTES")
					{
						string attributesCount = m_xmlr.GetAttribute("DataAttrCount");
						if (!(attributesCount == null))
						{
							AttrCount = System.Convert.ToInt32(attributesCount);
							if (AttrCount > 0)
							{
								string attrTableXMLString = m_xmlr.ReadInnerXml();
								DataVariable tableVar = default(DataVariable);
								tableVar = XMLDataFormatting.RetrieveDataVariableFromXMLString(attrTableXMLString);
                                attrTAble = new P2PDataAttributesTable((CustomHashTable)tableVar.Data);
							}
						}
						else
						{
							throw (new Exception("The parameter \'AttrCount\' is missing on the XML string in te section \'DATA_ATTRIBUTES\'"));
						}
					}
					else
					{
						throw (new Exception("Invalid data attributes XML section name \'" + dataSectionName + "\'. Is expected to be \'DATA_ATTRIBUTES\'"));
					}
					
					P2PData data = default(P2PData);
					data = new P2PData(operationID, System.Convert.ToString(variable.Name), variable.Data);
					if (AttrCount > 0)
					{
						data.AttachAttributesTable(attrTAble);
					}
					return data;
				}
			}
			
			public static P2PData GetP2PDataObject(string dataName, object data)
			{
				string type = data.GetType().ToString();
				P2PData _p2pData = default(P2PData);
				switch (type)
				{
					case "System.String":
						_p2pData = new P2PData(dataName, System.Convert.ToString(data));
						break;
					case "System.Int32":
						_p2pData = new P2PData(dataName, System.Convert.ToInt32(data));
						break;
					case "System.Decimal":
						_p2pData = new P2PData(dataName, System.Convert.ToDecimal(data));
						break;
					case "System.Boolean":
						_p2pData = new P2PData(dataName, System.Convert.ToBoolean(data));
						break;
					case "System.Data.DataTable":
						_p2pData = new P2PData(dataName, (DataTable) data);
						break;
					case "System.Data.DataSet":
						_p2pData = new P2PData(dataName, (DataSet) data);
						break;
					case "UtilitiesLibrary.Data.CustomHashTable":
						_p2pData = new P2PData(dataName, (CustomHashTable) data);
						break;
					case "UtilitiesLibrary.Data.CustomList":
						_p2pData = new P2PData(dataName, (CustomList) data);
						break;
					case "UtilitiesLibrary.Data.CustomSortedList":
						_p2pData = new P2PData(dataName, (CustomSortedList) data);
						break;
					default:
						throw (new Exception("Unsupported data type \'" + type + "\' for \'P2PData\' data type "));
				}
				return _p2pData;
			}
			
			public static P2PData Deserialize(byte[] P2PDataAsByte)
			{
				return ((P2PData) (ObjectSerializer.DeserializeObjectFromByte(P2PDataAsByte)));
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public void AttachAttributesTable(P2PDataAttributesTable table)
			{
				this._dataAttributesTable = table;
			}
			
			public override string ToString()
			{
				return this.DataName;
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
		}
		
	}
	
	
}
