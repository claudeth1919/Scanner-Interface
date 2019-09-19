using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using System.Text;
using UtilitiesLibrary.Data;
using UtilitiesLibrary.Parametrization;
using UtilitiesLibrary.Services.Serialization;




namespace CommunicationsLibrary
{
	namespace Services.SocketsDataDistribution.Data
	{
		
		[Serializable()]public class SocketData : IXMLDataString, IEnvironmentVariable, IDisposable
		{
			
			
#region  < DATAMEMBERS >
			//Private _headerIdentifier As String
			private object _data;
			private string _dataName;
			private string _XMLString;
			private byte[] _dataBytes;
			private AttributesTable _dataAttributesTable;
#endregion
			
#region  <  CONSTRUCTORS >
			
			private SocketData(string dataname, object data)
			{
				this._dataName = dataname;
				this._data = data;
				//Me._dataAttributesTable = New CustomHashTable
				this._dataAttributesTable = new AttributesTable();
			}
			
			public SocketData(string dataname, string data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, int data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, decimal data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, bool data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, DataTable data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, DataSet data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, CustomHashTable data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, CustomList data) : this(dataname, (object) data)
			{
			}
			
			public SocketData(string dataname, CustomSortedList data) : this(dataname, (object) data)
			{
			}
			
#endregion
			
#region  < PROPERTIES >
			
public int DataLenght
			{
				get
				{
					return this.DataBytes.Length;
				}
			}
			
internal byte[] DataBytes
			{
				get
				{
					if (this._dataBytes == null)
					{
						this._dataBytes = Encoding.ASCII.GetBytes(this.XMLDataString);
					}
					return this._dataBytes;
				}
			}
			
public AttributesTable AttributesTable
			{
				get
				{
					return this._dataAttributesTable;
				}
			}
			
#endregion
			
#region  < private METHODS >
			
			//Private Sub AttachAttributesTable(ByVal table As CustomHashTable)
			//    Me._dataAttributesTable = table
			//End Sub
			
			private void AttachAttributesTable(AttributesTable table)
			{
				this._dataAttributesTable.SetAttributesFromSource(table);
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			public static SocketData ParseAndGet_SocketData_FromXMLDataString(string XMLString)
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
					msg = "Error trying to get XML format from data socket data string [" + XMLString + "]";
				}
				catch (Exception ex)
				{
					string msg = "";
					msg = "Error trying to parse data socket XML string : " + ex.Message;
					throw (new Exception(msg));
				}
				m_xmlr.Read();
				string HeaderIdentifier = m_xmlr.Name;
				
				if (HeaderIdentifier != "SD")
				{
					throw (new System.Xml.XmlException("Invalid data socket header " + HeaderIdentifier + ". Must be \'SD\'"));
				}
				else
				{
					
					//**********************************************************
					//retrieves the data transported on the XML
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
					AttributesTable attributesTable = null;
					int AttrCount = 0;
					
					if (dataAttributesSectionName == "SDAS")
					{
						string attributesCount = m_xmlr.GetAttribute("cn");
						if (!(attributesCount == null))
						{
							AttrCount = System.Convert.ToInt32(attributesCount);
							if (AttrCount > 0)
							{
								string attrTableXMLString = m_xmlr.ReadInnerXml();
								DataVariable tableVar = default(DataVariable);
								tableVar = XMLDataFormatting.RetrieveDataVariableFromXMLString(attrTableXMLString);
								CustomHashTable table = default(CustomHashTable);
								table = (CustomHashTable) tableVar.Data;
								attributesTable = new AttributesTable(table);
							}
						}
						else
						{
							throw (new Exception("The parameter \'cn\' is missing on the XML string in te section \'SDAS\'"));
						}
					}
					else
					{
						throw (new Exception("Invalid data attributes XML section name \'" + dataSectionName + "\'. Is expected to be \'SD_ATTRS\'"));
					}
					
					SocketData data = default(SocketData);
					data = new SocketData(System.Convert.ToString(variable.Name), variable.Data);
					if (AttrCount > 0)
					{
						data.AttachAttributesTable(attributesTable);
					}
					return data;
				}
			}
			
			public static SocketData GetSocketData(string dataname, object data)
			{
				string dataType = "";
				dataType = data.GetType().ToString();
				switch (dataType)
				{
					case "System.Int32":
						return new SocketData(dataname, System.Convert.ToInt32(data));
					case "System.Decimal":
						return new SocketData(dataname, System.Convert.ToDecimal(data));
					case "System.Boolean":
						return new SocketData(dataname, System.Convert.ToBoolean(data));
					case "System.String":
						return new SocketData(dataname, System.Convert.ToString(data));
					case "System.Data.DataTable":
						return new SocketData(dataname, (DataTable) data);
					case "System.Data.DataSet":
						return new SocketData(dataname, (DataSet) data);
					case "UtilitiesLibrary.Data.CustomHashTable":
						return new SocketData(dataname, (UtilitiesLibrary.Data.CustomHashTable) data);
					case "UtilitiesLibrary.Data.CustomList":
						return new SocketData(dataname, (CustomList) data);
					case "UtilitiesLibrary.Data.CustomSortedList":
						return new SocketData(dataname, (CustomSortedList) data);
					default:
						throw (new Exception("Unsupported data type \'" + dataType + "\' for Socket Data"));
				}
			}
			
			public static SocketData Deserialize(byte[] data)
			{
				return ((SocketData) (ObjectSerializer.DeserializeObjectFromByte(data)));
			}
			
#endregion
			
#region  < INTERFACE IMPLEMENTATION >
			
#region  < IXMLDataString >
			
			public string GetXMLString()
			{
				string dataXMLSection = "";
				string XMLString = "";
				
				string attrListXMLSection = "";
				if (this._dataAttributesTable.Count > 0)
				{
					string attrListAsXML = XMLDataFormatting.GetDataVariableXMLString("SDAT", this._dataAttributesTable.ToSTXHashTable());
					attrListXMLSection = "<SDAS  cn=" + "\"" + System.Convert.ToString(this._dataAttributesTable.Count) + "\"" + ">" + attrListAsXML + "</SDAS>";
				}
				else
				{
					attrListXMLSection = "<SDAS  cn=\"0\"></SDAS>";
				}
				dataXMLSection = XMLDataFormatting.GetDataVariableXMLString(this.DataName, this.Value);
				XMLString = "<SD>" + dataXMLSection + attrListXMLSection + "</SD>";
				return XMLString;
			}
			
public string XMLDataString
			{
				get
				{
					if (this._XMLString == null)
					{
						this._XMLString = this.GetXMLString();
					}
					return this._XMLString;
				}
			}
			
			
#endregion
			
#region  < IEnvironmentVariable >
			
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
			
#region  < IDisposable>
			
			private bool disposedValue = false; // To detect redundant calls
			
			// IDisposable
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						// TODO: free other state (managed objects).
					}
					try
					{
						this._dataAttributesTable = null;
					}
					catch (Exception)
					{
					}
					try
					{
						this._data = null;
					}
					catch (Exception)
					{
					}
					try
					{
						this._dataBytes = null;
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._XMLString = null;
					}
					catch (Exception)
					{
					}
					
					try
					{
						this._dataName = null;
					}
					catch (Exception)
					{
					}
					// TODO: free your own state (unmanaged objects).
					// TODO: set large fields to null.
				}
				this.disposedValue = true;
			}
			
			
			// This code added by Visual Basic to correctly implement the disposable pattern.
			public void Dispose()
			{
				// Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
				Dispose(true);
				GC.SuppressFinalize(this);
			}
			
			
			
#endregion
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public override string ToString()
			{
				return this._dataName;
			}
			
			public byte[] Serialize()
			{
				return ObjectSerializer.SerializeObjectToByte(this);
			}
			
#endregion
			
			
		}
		
	}
	
	
	
}
