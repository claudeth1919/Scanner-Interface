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
using UtilitiesLibrary.Parametrization;
using CommunicationsLibrary.Services.SocketsDataDistribution.Data;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
	public partial class CF_SocketsSErver_DataManagerContainer : IEnumerable
	{
		
		
		
#region  < DATAMEMBERS  >
		
		private Hashtable _dataTable;
		private const string DATA_CONTAINER_FILE_NAME = "DATA_CONTAINER_DATA.dat";
#endregion
		
#region  < EVENTS >
		
		public delegate void DataSelectionChangedEventHandler(SocketData newDataSelected);
		private DataSelectionChangedEventHandler DataSelectionChangedEvent;
		
		public event DataSelectionChangedEventHandler DataSelectionChanged
		{
			add
			{
				DataSelectionChangedEvent = (DataSelectionChangedEventHandler) System.Delegate.Combine(DataSelectionChangedEvent, value);
			}
			remove
			{
				DataSelectionChangedEvent = (DataSelectionChangedEventHandler) System.Delegate.Remove(DataSelectionChangedEvent, value);
			}
		}
		
		
#endregion
		
#region  < COSNTRUCTORS  >
		
		public CF_SocketsSErver_DataManagerContainer()
		{
			
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this.LoadDataFromFileIfExists();
			
			this.ResetDataVisualization();
		}
		
#endregion
		
#region  <  PROPERTIES >

        public SocketData SelectedData
		{
			get
			{
				if (this.lstAvailableData.Items.Count > 0)
				{
					if (this.lstAvailableData.SelectedIndex >= 0)
					{
						return (SocketData)this.lstAvailableData.SelectedItem;
					}
					else
					{
						return null;
					}
				}
				else
				{
					return null;
				}
			}
		}
		
        public int DataCount
		{
			get
			{
				return this._dataTable.Count;
			}
		}
		
		public Data DataItem(string dataName) 
		{
			dataName = dataName.ToUpper();
			if (this._dataTable.ContainsKey(dataName))
			{
				return (Data)this._dataTable[dataName];
			}
			else
			{
				throw (new Exception("The asyncEvtArgs " + dataName + " doesn\'t in the container"));
			}
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private void SetSelectedData()
		{
			if (this.lstAvailableData.Items.Count > 0)
			{
				if (this.lstAvailableData.SelectedIndex >= 0)
				{
                    SocketData dat = (SocketData)this.lstAvailableData.SelectedItem;
					ShowData(dat);
					try
					{
						if (DataSelectionChangedEvent != null)
							DataSelectionChangedEvent(dat);
					}
					catch (Exception)
					{
					}
				}
				else
				{
					ResetDataVisualization();
				}
			}
			else
			{
				this.ResetDataVisualization();
			}
		}
		
		private void ResetDataVisualization()
		{
			this.txtIntDecStringBol.Text = "";
			this.dgrDataTable.DataSource = null;
			this.lstCollectionsDataType.Items.Clear();
			this.txtIntDecStringBol.Visible = false;
			this.lstCollectionsDataType.Visible = false;
			this.dgrDataTable.Visible = false;
			this.pnlPanelToSize.Visible = true;
			this.lstDataAttributes.Items.Clear();
		}

        private void ShowData(SocketData data)
		{
			this.ResetDataVisualization();
			
			string strType = System.Convert.ToString(data.Value );
			switch (strType)
			{
				case "System.String":
				case "System.Int32":
				case "System.Decimal":
					this.txtIntDecStringBol.Visible = true;
					this.pnlPanelToSize.Visible = false;
                    this.txtIntDecStringBol.Text = System.Convert.ToString(data.Value);
					break;
				case "System.Boolean":
					this.txtIntDecStringBol.Visible = true;
					this.pnlPanelToSize.Visible = false;
					if (System.Convert.ToBoolean(data.Value) == true)
					{
						this.txtIntDecStringBol.Text = "TRUE";
					}
					else if (System.Convert.ToBoolean(data.Value) == false)
					{
						this.txtIntDecStringBol.Text = "FALSE";
					}
					break;
				case "System.Data.DataTable":
					this.dgrDataTable.Visible = true;
					this.pnlPanelToSize.Visible = false;
					this.dgrDataTable.DataSource = (DataTable) data.Value;
					break;
					
					
				case "System.Data.DataSet":
					this.dgrDataTable.Visible = true;
					this.pnlPanelToSize.Visible = false;
					this.dgrDataTable.DataSource = (DataSet) data.Value;
					break;
					
					
				case "UtilitiesLibrary.Data.CustomHashTable":
					this.lstCollectionsDataType.Visible = true;
					this.pnlPanelToSize.Visible = false;
					string strElem_1 = "";
					DictionaryEntry dicentry_1 = new DictionaryEntry();
					IEnumerator enumm_1 = ((CustomHashTable) data.Value).GetEnumerator();
					while (enumm_1.MoveNext())
					{
                        dicentry_1 = (DictionaryEntry)enumm_1.Current;
						strElem_1 = "Key = " + System.Convert.ToString(dicentry_1.Key) + "  ,  Value = " + System.Convert.ToString(dicentry_1.Value);
						this.lstCollectionsDataType.Items.Add(strElem_1);
					}
					break;
					
				case "UtilitiesLibrary.Data.CustomList":
					this.lstCollectionsDataType.Visible = true;
					this.pnlPanelToSize.Visible = false;
					IEnumerator enumm_2 = ((CustomList) data.Value).GetEnumerator();
					while (enumm_2.MoveNext())
					{
						this.lstCollectionsDataType.Items.Add(enumm_2.Current);
					}
					break;
					
				case "UtilitiesLibrary.Data.CustomSortedList":
					this.lstCollectionsDataType.Visible = true;
					this.pnlPanelToSize.Visible = false;
					string strElem = "";
					DictionaryEntry dicentry = new DictionaryEntry();
					IEnumerator enumm = ((CustomSortedList) data.Value).GetEnumerator();
					while (enumm.MoveNext())
					{
                        dicentry = (DictionaryEntry)enumm.Current;
						strElem = "Key = " + System.Convert.ToString(dicentry.Key) + "  ,  Value = " + System.Convert.ToString(dicentry.Value);
						this.lstCollectionsDataType.Items.Add(strElem);
					}
					break;
					
			}
			
			IEnumerator attrEnumm = data.AttributesTable.GetEnumerator();
			UtilitiesLibrary.Parametrization.Attribute attr;
			string attrStr = "";
			while (attrEnumm.MoveNext())
			{
                attr = (UtilitiesLibrary.Parametrization.Attribute)attrEnumm.Current;
				attrStr = attr.Name + "  -  " + attr.Value;
				this.lstDataAttributes.Items.Add(attrStr);
			}
			
		}
		
		private void SaveDataToFile()
		{
			try
			{
				ObjectSerializer.SerializeObjectToFile(this._dataTable, DATA_CONTAINER_FILE_NAME);
			}
			catch (Exception)
			{
			}
		}
		
		private void LoadDataFromFileIfExists()
		{
			try
			{
				_dataTable = (Hashtable) (ObjectSerializer.DeserializeObjectFromFile(DATA_CONTAINER_FILE_NAME));
				Data dat = null;
				IEnumerator enumm = _dataTable.GetEnumerator();
				while (enumm.MoveNext())
				{
					dat = (Data) (((DictionaryEntry) enumm.Current).Value);
					this.lstAvailableData.Items.Add(dat);
				}
				try
				{
					this.SetSelectedData();
				}
				catch (Exception)
				{
				}
				
			}
			catch (Exception)
			{
				_dataTable = new Hashtable();
			}
			
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public bool ContainsData(string DataName)
		{
			DataName = DataName.ToUpper();
			return this._dataTable.ContainsKey(DataName);
		}
		
#endregion
		
#region  < UI CALLBACKS  >
		
		public void btnAddDataToBroadCast_Click(System.Object sender, System.EventArgs e)
		{
			frmDataCreationSelectionForm frm = new frmDataCreationSelectionForm();
			if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (!this._dataTable.ContainsKey(frm.Data.DataName))
				{
					SocketData sd = SocketData.GetSocketData(frm.Data.DataName, frm.Data.data);
					this.lstAvailableData.Items.Add(sd);
					this._dataTable.Add(sd.DataName, sd);
					this.SetSelectedData();
					this.SaveDataToFile();
				}
				else
				{
					MessageBox.Show("The data " + frm.Data.DataName + " is already contained in the list");
				}
			}
			frm.Dispose();
		}
		
		public void lstAvailableData_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.SetSelectedData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnRemove_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstAvailableData.Items.Count > 0)
				{
					if (this.lstAvailableData.SelectedIndex >= 0)
					{
						Data dat = (Data)this.lstAvailableData.SelectedItem;
						this.lstAvailableData.Items.Remove(this.lstAvailableData.SelectedItem);
						this._dataTable.Remove(dat.DataName);
						this.SetSelectedData();
						this.SaveDataToFile();
					}
					else
					{
						throw (new Exception("No data selected from list to remove"));
					}
				}
				else
				{
					throw (new Exception("No data in the list to remove"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
                SocketData data = (SocketData)this.SelectedData;
				if (!(data == null))
				{
					string attrName = Interaction.InputBox("Attribute Name", "", "", -1, -1);
					if (attrName.Length > 0)
					{
						string attrValue = Interaction.InputBox("Attribute Value", "", "", -1, -1);
						if (attrValue.Length > 0)
						{
							data.AttributesTable.AddAttribute(attrName, attrValue);
							this.SetSelectedData();
						}
					}
				}
				else
				{
					throw (new Exception("No selected data"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				
				if (this.lstDataAttributes.SelectedIndex >= 0)
				{

                    SocketData data = (SocketData)this.SelectedData;
					if (!(data == null))
					{
						
						string str = System.Convert.ToString(this.lstDataAttributes.SelectedItem);
						string[] attrAsString = str.Split(' ');
						string AttrName = attrAsString[0];
						data.AttributesTable.RemoveAttribute(AttrName);
						
						this.SetSelectedData();
					}
				}
				else
				{
					throw (new Exception("No selected data attribute"));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
#endregion
		
#region  < INTERFACE IMPLEMENTATION >
		
#region  < IEnumerable >
		
		public System.Collections.IEnumerator GetEnumerator()
		{
			ArrayList list = new ArrayList();
			IEnumerator enumm = default(IEnumerator);
			enumm = this.lstAvailableData.Items.GetEnumerator();
			while (enumm.MoveNext())
			{
				list.Add(enumm.Current);
			}
			return list.GetEnumerator();
		}
		
#endregion
		
#endregion
		
		
		
		
		
	}
	
}
