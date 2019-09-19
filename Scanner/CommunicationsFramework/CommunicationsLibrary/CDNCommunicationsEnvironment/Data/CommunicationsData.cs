using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using UtilitiesLibrary.Data;
using CommunicationsLibrary.Services.P2PCommunicationsScheme.Data;




namespace CommunicationsLibrary
{
	namespace CNDCommunicationsEnvironment.Data
	{
		
		
		public class CommunicationsData
		{
			
#region  < DATAMEMBERS >
			
			private string _senderComponentName;
			private string _addresseComponentName;
			private P2PData _p2pData;
			
#endregion
			
#region  < PROPERTIES >
			
internal P2PData P2PData
			{
				get
				{
					return this._p2pData;
				}
			}
			
			
public string AddresseComponentName
			{
				get
				{
					return this._addresseComponentName;
				}
			}
			
public string SenderComponentName
			{
				get
				{
					return this._senderComponentName;
				}
			}
			
public string DataName
			{
				get
				{
					return this._p2pData.DataName;
				}
			}
			
public dynamic Value
			{
				get
				{
					return this._p2pData.Value;
				}
			}
			
			
#endregion
			
#region  < CONSTRUCTORS >
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, string data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, int data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, decimal data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, bool data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, DataTable data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, DataSet data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, CustomHashTable data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, CustomList data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
			public CommunicationsData(string addresseComponentName, string senderComponentName, string dataName, CustomSortedList data)
			{
				dataName = dataName.ToUpper();
				this._senderComponentName = senderComponentName;
				this._addresseComponentName = addresseComponentName;
				this._p2pData = new P2PData(dataName, data);
				this._p2pData.DataAttributesTable.AddAttribute("DATA_TYPE", "CommunicationsData");
				this._p2pData.DataAttributesTable.AddAttribute("SENDER_COMPONENT", senderComponentName);
				this._p2pData.DataAttributesTable.AddAttribute("ADDRESSE_COMPONENT", addresseComponentName);
			}
			
#endregion
			
#region  < PUBLIC METHODS >
			
			public override string ToString()
			{
				return this._p2pData.DataName;
			}
			
			public void AddDataAttribute(string AttributeName, string value)
			{
				AttributeName = AttributeName.ToUpper();
				this._p2pData.DataAttributesTable.AddAttribute(AttributeName, value);
			}
			
			public void RemoveDataAttribute(string AttributeName)
			{
				AttributeName = AttributeName.ToUpper();
				this._p2pData.DataAttributesTable.RemoveAttribute(AttributeName);
			}
			
			public bool ContainsAttribute(string AttributeName)
			{
				AttributeName = AttributeName.ToUpper();
				return this._p2pData.DataAttributesTable.ContainsAttribute(AttributeName);
			}
			
			public string GetAttributeValue(string AttributeName)
			{
				AttributeName = AttributeName.ToUpper();
				P2PDataAttributesTable.P2PDataAttribute attr = new P2PDataAttributesTable.P2PDataAttribute();
				attr = this._p2pData.DataAttributesTable.GetAttribute(AttributeName);
				return attr.AttrValue;
			}
			
#endregion
			
#region  < SHARED METHODS >
			
			public static CommunicationsData GetCommunicationsDataObject(string addresseComponentName, string senderComponentName, string dataName, object data)
			{
				string type = data.GetType().ToString();
				CommunicationsData commsData = default(CommunicationsData);
				switch (type)
				{
					case "System.String":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, System.Convert.ToString(data));
						break;
					case "System.Int32":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, System.Convert.ToInt32(data));
						break;
					case "System.Decimal":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, System.Convert.ToDecimal(data));
						break;
					case "System.Boolean":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, System.Convert.ToString(System.Convert.ToBoolean(data)));
						break;
					case "System.Data.DataTable":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, (DataTable) data);
						break;
					case "System.Data.DataSet":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, (DataSet) data);
						break;
					case "UtilitiesLibrary.Data.CustomHashTable":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, System.Convert.ToString((CustomHashTable) data));
						break;
					case "UtilitiesLibrary.Data.CustomList":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, (CustomList) data);
						break;
					case "UtilitiesLibrary.Data.CustomSortedList":
						commsData = new CommunicationsData(addresseComponentName, senderComponentName, dataName, (CustomSortedList) data);
						break;
					default:
						throw (new Exception("Unsupported data type \'" + type + "\' for \'CommunicationsData\' data type "));
				}
				return commsData;
			}
			
#endregion
			
		}
		
		
	}
	
}
