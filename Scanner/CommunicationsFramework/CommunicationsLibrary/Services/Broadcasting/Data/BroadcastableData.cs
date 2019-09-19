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
	namespace Services.BroadCasting.Data
	{
		
		[Serializable()]public class BroadcastableData : IXMLDataString, IEnvironmentVariable
		{
			
			
#region  < STRUCTURES >
			
			[Serializable()]public struct BroadCasterInfo
			{
				public string Host;
				public int ReplyListeningPort;
				public string BroadcasterName;
			}
			
#endregion
			
#region  < DATAMEMBERS >
			
			private BroadCasterInfo _broadCasterInfo;
			private object _data;
			private string _dataName;
			private string _XMLDataString;
			
#endregion
			
#region  < PROPERTIES >
			
public BroadCasterInfo BroadCasterInformation
			{
				get
				{
					return this._broadCasterInfo;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
#region  < PRIVATE CONSTRUCTORS >
			
			private BroadcastableData(DataBroadcastClient broadCaster, string dataName, object data)
			{
				this._broadCasterInfo.BroadcasterName = broadCaster.Name;
				this._broadCasterInfo.ReplyListeningPort = broadCaster.ReplyListeningPort;
				this._broadCasterInfo.Host = broadCaster.HostName;
				this._dataName = dataName;
				this._data = data;
				this._XMLDataString = this.GetXMLString();
			}
			
#endregion
			
#region  < FRIEND CONSTRUCTORS >
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, string data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, int data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, decimal data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, bool data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, DataTable data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, DataSet data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, CustomHashTable data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, CustomList data) : this(broadCaster, dataName, (object) data)
			{
			}
			
			internal BroadcastableData(DataBroadcastClient broadCaster, string dataName, CustomSortedList data) : this(broadCaster, dataName, (object) data)
			{
			}
			
#endregion
			
#region  < PRIVATE CONSTRUCTORS USED TO CREATE LOCALLY FROM xml CONVERTION >
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, object data)
			{
				this._broadCasterInfo.BroadcasterName = BroadCasterName;
				this._broadCasterInfo.ReplyListeningPort = broadCasterListeningPort;
				this._broadCasterInfo.Host = broadcasterHost;
				this._data = data;
				this._dataName = dataName;
				this._XMLDataString = this.GetXMLString();
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, string data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, int data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, decimal data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, bool data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, DataTable data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, DataSet data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, CustomHashTable data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, CustomList data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			private BroadcastableData(string BroadCasterName, string broadcasterHost, int broadCasterListeningPort, string dataName, CustomSortedList data) : this(BroadCasterName, broadcasterHost, broadCasterListeningPort, dataName, (object) data)
			{
			}
			
			
#endregion
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static BroadcastableData ParseAndGet_BroadcastableData_FromXMLDataString(string XMLDataString)
			{
				System.IO.StringReader sr = null;
				System.Xml.XmlTextReader m_xmlr = null;
				
				string broadCasterName = "";
				string broadCasterHost = "";
				int broadCasterListeningPort = 0;
				
				try
				{
					sr = new System.IO.StringReader(XMLDataString);
					m_xmlr = new System.Xml.XmlTextReader(sr);
					m_xmlr.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
				}
				catch (System.Xml.XmlException)
				{
					string msg;
					msg = "Error trying to get XML format from broadcasted data string [" + XMLDataString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse broadcasted XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				m_xmlr.Read();
				string HeaderIdentifier = m_xmlr.Name;
				
				if (HeaderIdentifier != "BROADCASTED_DATA")
				{
					throw (new System.Xml.XmlException("Invalid data header " + HeaderIdentifier + ". Must be \'BROADCASTED_DATA\'"));
				}
				else
				{
					m_xmlr.Read();
					string broadCasterHeader = m_xmlr.Name;
					if (broadCasterHeader != "BROADCASTER_INFO")
					{
						throw (new System.Xml.XmlException("Invalid XML structure was expected a <BROADCASTER_INFO> and was found " + broadCasterHeader));
					}
					else
					{
						//*******************************************************
						//gets the data broadcaster information
						//*******************************************************
						broadCasterName = m_xmlr.GetAttribute("name");
						if (broadCasterName == null)
						{
							throw (new Exception("Can\'t determine the attribute NAME of the section <BROADCASTER_INFO> from XML String  [" + XMLDataString + "]"));
						}
						
						broadCasterHost = m_xmlr.GetAttribute("host");
						if (broadCasterHost == null)
						{
							throw (new Exception("Can\'t determine the attribute HOST of the section <BROADCASTER_INFO> from XML String  [" + XMLDataString + "]"));
						}
						
						string PORT = m_xmlr.GetAttribute("listeningPort");
						
						if (PORT == null)
						{
							throw (new Exception("Can\'t determine the attribute LISTENINGPORT of the section <BROADCASTER_INFO> from XML String  [" + XMLDataString + "]"));
						}
						broadCasterListeningPort = System.Convert.ToInt32(PORT);
						
						
						//*******************************************************
						//gets the data from the XML string
						//*******************************************************
						string dataValueAsString = "";
						m_xmlr.Read();
						m_xmlr.Read();
						dataValueAsString = m_xmlr.ReadOuterXml();
						DataVariable var = XMLDataFormatting.RetrieveDataVariableFromXMLString(dataValueAsString);
						BroadcastableData broadCastedData = new BroadcastableData(broadCasterName, broadCasterHost, broadCasterListeningPort, System.Convert.ToString(var.Name), var.Data);
						return broadCastedData;
					}
				}
			}
			
			public static BroadcastableData Deserialize(byte[] BroadcastableDataAsByte)
			{
				return ((BroadcastableData) (ObjectSerializer.DeserializeObjectFromByte(BroadcastableDataAsByte)));
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IXMLDataString>
			
			public string GetXMLString()
			{
				string XMLstring = "";
				string headerString = "";
				string dataString = "";
				//prepares the
				headerString = "<BROADCASTER_INFO name=" + "\"" + this._broadCasterInfo.BroadcasterName + "\"" + " host=" + "\"" + this._broadCasterInfo.Host + "\"" + "  listeningPort=" + "\"" + System.Convert.ToString(this._broadCasterInfo.ReplyListeningPort) + "\"" + "></BROADCASTER_INFO>";
				dataString = XMLDataFormatting.GetDataVariableXMLString(this.DataName, this._data);
				XMLstring = "<BROADCASTED_DATA>" + headerString + dataString + "</BROADCASTED_DATA>";
				return XMLstring;
			}
			
public string XMLDataString
			{
				get
				{
					return this._XMLDataString;
				}
			}
			
#endregion
			
#region  <  IVariableData >
			
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
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
			
			
		}
		
		
	}
	
	
	
}
