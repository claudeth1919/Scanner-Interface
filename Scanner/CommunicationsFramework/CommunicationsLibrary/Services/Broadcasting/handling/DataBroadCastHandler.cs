using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Net.Sockets;
using CommunicationsLibrary.Services.BroadCasting.Data;
using UtilitiesLibrary.Services.DataCompression;
using UtilitiesLibrary.Services.Serialization;


namespace CommunicationsLibrary
{
	namespace Services.BroadCasting.Handling
	{
		
		[Serializable()]public class DataBroadCastHandler : IXMLDataString
		{
			
#region  < DATAMEMBERS  >
			
			[Serializable()]public enum BroadCastMode
			{
				BroadCasterIsNotWaitingReply,
				BroadCasterIsWaitingReply,
				undefined
			}
			
			private string _XMLDataString;
			private BroadcastableData _broadCastableData;
			private BroadCastMode _mode;
			private string _broadcastIDName;
			
#endregion
			
#region  < PROPERTIES >
			
public BroadcastableData BroadCastedData
			{
				get
				{
					return this._broadCastableData;
				}
			}
			
public BroadCastMode BroadcastingMode
			{
				get
				{
					return this._mode;
				}
			}
			
public string broadcastIDName
			{
				get
				{
					return this._broadcastIDName;
				}
			}
			
#endregion
			
#region  <  CONSTRUCTORS >
			
			internal DataBroadCastHandler(BroadCastMode BroadCastMode, string BroadcastIDName, BroadcastableData data)
			{
				this._broadCastableData = data;
				this._mode = BroadCastMode;
				this._broadcastIDName = BroadcastIDName.ToUpper();
				this._XMLDataString = this.GetXMLString();
			}
			
#endregion
			
#region  < FRIEND METHODS >
			
			internal static DataBroadCastHandler ParseAndGet_DataBroadCastHandler_FromXMLDataString(string XMLDataString)
			{
				System.IO.StringReader sr = null;
				System.Xml.XmlTextReader m_xmlr = null;
				
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
				
				if (HeaderIdentifier != "BROADCAST_HANDLER")
				{
					throw (new System.Xml.XmlException("Invalid data header " + HeaderIdentifier + ". Must be \'BROADCAST_HANDLER\'"));
				}
				else
				{
					//read the mode attribute from the current section "BROADCAST_HANDLER"
					BroadCastMode mode = default(BroadCastMode);
					string modeStr = m_xmlr.GetAttribute("broadcastMode");
					switch (modeStr)
					{
						case "BroadCasterIsWaitingReply":
							mode = BroadCastMode.BroadCasterIsWaitingReply;
							break;
						case "BroadCasterIsNotWaitingReply":
							mode = BroadCastMode.BroadCasterIsNotWaitingReply;
							break;
						default:
							mode = BroadCastMode.undefined;
							break;
					}
					
					string broadCastIDName = "";
					broadCastIDName = m_xmlr.GetAttribute("broadcastIDName");
					if (broadCastIDName == null)
					{
						throw (new Exception("No attribute \'broadcastIDName\' in XML data string [" + XMLDataString + "]"));
					}
					
					//retrieves all the xml string of the broadcastable data section
					m_xmlr.Read();
					string broadCastedXMLString = m_xmlr.ReadOuterXml();
					BroadcastableData data = BroadcastableData.ParseAndGet_BroadcastableData_FromXMLDataString(broadCastedXMLString);
					DataBroadCastHandler handler = new DataBroadCastHandler(mode, broadCastIDName, data);
					return handler;
				}
			}
			
#endregion
			
#region  < PUBLIC METHODS  >
			
			public void SendReplyToBroadcaster(BroadCastReply replyData)
			{
				try
				{
					switch (this._mode)
					{
						case BroadCastMode.BroadCasterIsNotWaitingReply:
							throw (new Exception("Can\'t send a reply to Broad Caster because it distributed without waiting a reply from listeners"));
						case BroadCastMode.BroadCasterIsWaitingReply:
							string host = this._broadCastableData.BroadCasterInformation.Host;
							int listeningTCPPortNumber = this.BroadCastedData.BroadCasterInformation.ReplyListeningPort;
							TcpClient _tcpClient = new TcpClient(host, listeningTCPPortNumber);
							NetworkStream stream = _tcpClient.GetStream();
							
							//transforms the replyw response objetct from its xml representation into byte
							byte[] handlerAsByte = replyData.Serialize();
							
							//sends the data to the broad cast listener client
							stream.Write(handlerAsByte, 0, handlerAsByte.Length);
							stream.Close();
							_tcpClient.Close();
							break;
							
						case BroadCastMode.undefined:
							throw (new Exception("Can\'t send a reply to Broad Caster because of a undefined behavior"));
						default:
							throw (new Exception("Can\'t send a reply to Broad Caster because of a undefined behavior"));
					}
					
				}
				catch (Exception ex)
				{
					string msg = "Error sending a broad cast reply to broad caster : [" + ex.Message + "]";
					throw (new Exception(msg));
				}
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			public static DataBroadCastHandler Deserialize(byte[] DataBroadCastHandlerAsByte)
			{
				return ((DataBroadCastHandler) (ObjectSerializer.DeserializeObjectFromByte(DataBroadCastHandlerAsByte)));
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IXMLDataString >
			
			public string GetXMLString()
			{
				string xmlString = "";
				
				switch (this._mode)
				{
					case BroadCastMode.BroadCasterIsWaitingReply:
						xmlString = "<BROADCAST_HANDLER broadcastMode=\"BroadCasterIsWaitingReply\" broadcastIDName=" + "\"" + this.broadcastIDName + "\"" + ">" + this._broadCastableData.XMLDataString + "</BROADCAST_HANDLER>";
						break;
					case BroadCastMode.BroadCasterIsNotWaitingReply:
						xmlString = "<BROADCAST_HANDLER broadcastMode=\"BroadCasterIsNotWaitingReply\" broadcastIDName=" + "\"" + this.broadcastIDName + "\"" + ">" + this._broadCastableData.XMLDataString + "</BROADCAST_HANDLER>";
						break;
					default:
						xmlString = "<BROADCAST_HANDLER broadcastMode=\"undefined\" broadcastIDName=" + "\"" + this.broadcastIDName + "\"" + ">" + this._broadCastableData.XMLDataString + "</BROADCAST_HANDLER>";
						break;
				}
				return xmlString;
			}
			
public string XMLDataString
			{
				get
				{
					return _XMLDataString;
				}
			}
			
#endregion
			
#endregion
			
			
			
		}
		
		
	}
	
}
