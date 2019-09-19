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
		
		[Serializable()]public class BroadCastReply : IXMLDataString, IEnvironmentVariable
		{
			
			
#region  < DATAMEMBERS >
			
			private string _XMLDataString;
			private object _data;
			private string _DataName;
			private string _replyNameID;
			
#endregion
			
#region  < PROPERTIES >
			
public string ReplyIDName
			{
				get
				{
					return this._replyNameID;
				}
			}
			
#endregion
			
#region  < CONSTRUCTORS >
			
			private BroadCastReply(string ReplyNameID, string dataname, object data)
			{
				this._data = data;
				this._DataName = dataname;
				this._replyNameID = ReplyNameID.ToUpper();
				this._XMLDataString = this.GetXMLString();
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, string data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, int data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, decimal data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, bool data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, DataSet data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, DataTable data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, CustomHashTable data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, CustomList data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			public BroadCastReply(string ReplyNameID, string dataname, CustomSortedList data) : this(ReplyNameID, dataname, (object) data)
			{
			}
			
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IXMLDataString >
			
			
			public string GetXMLString()
			{
				string XMLstring = "";
				string dataString = "";
				//prepares the
				dataString = XMLDataFormatting.GetDataVariableXMLString(this._DataName, this._data);
				XMLstring = "<BROADCAST_REPLY replyIDName=" + "\"" + this._replyNameID + "\"" + ">" + dataString + "</BROADCAST_REPLY>";
				return XMLstring;
			}
			
public string XMLDataString
			{
				get
				{
					if (this._XMLDataString == null || this._XMLDataString.Length <= 0)
					{
						this._XMLDataString = this.GetXMLString();
					}
					return this._XMLDataString;
				}
			}
			
#endregion
			
#region  < IVariableData >
			
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
					return this._DataName;
				}
			}
			
#endregion
			
#endregion
			
#region  < SHARED METHODS >
			
			internal static BroadCastReply ParseAndGet_BroadCastReply_FromXMLDataString(string XMLString)
			{
				System.IO.StringReader sr = null;
				System.Xml.XmlTextReader m_xmlr = null;
				BroadCastReply parsedBroadCartReplyfromXMLString = default(BroadCastReply);
				
				try
				{
					sr = new System.IO.StringReader(XMLString);
					m_xmlr = new System.Xml.XmlTextReader(sr);
					m_xmlr.WhitespaceHandling = System.Xml.WhitespaceHandling.None;
				}
				catch (System.Xml.XmlException)
				{
					string msg;
					msg = "Error trying to get XML format from Broad Cast Reply data string [" + XMLString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse Broad Cast Reply XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				m_xmlr.Read();
				string HeaderIdentifier = m_xmlr.Name;
				
				if (HeaderIdentifier != "BROADCAST_REPLY")
				{
					throw (new System.Xml.XmlException("Invalid data socket header " + HeaderIdentifier + ". Must be \'BROADCAST_REPLY\'"));
				}
				else
				{
					string replyIDName = "";
					replyIDName = m_xmlr.GetAttribute("replyIDName");
					if (replyIDName == null)
					{
						throw (new Exception("Invalid XML string for a BroadCastReply, the attribute replyIDName is missing. Can´t parse the string"));
					}
					
					string dataXMLString = "";
					dataXMLString = m_xmlr.ReadInnerXml();
					DataVariable var = default(DataVariable);
					var = XMLDataFormatting.RetrieveDataVariableFromXMLString(dataXMLString);
					parsedBroadCartReplyfromXMLString = new BroadCastReply(replyIDName, System.Convert.ToString(var.Name), var.Data);
				}
				return parsedBroadCartReplyfromXMLString;
			}
			
			public static BroadCastReply Deserialize(byte[] BroadCastReplyAsByte)
			{
				return ((BroadCastReply) (ObjectSerializer.DeserializeObjectFromByte(BroadCastReplyAsByte)));
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public override string ToString()
			{
				string str = this._replyNameID + " - " + this._DataName;
				return str;
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
			
		}
		
		
		
	}
	
}
