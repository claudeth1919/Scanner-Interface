// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
// End of VB project level imports

using UtilitiesLibrary.Data;


namespace CommunicationsUISupportLibrary
{
	public partial class CFDataDisplayCtrl
	{
		public CFDataDisplayCtrl()
		{
			InitializeComponent();
		}
		
#region  < PROPERTIES >
		
#endregion
		
#region  < EVENTS  >
		
		public delegate void DataClearedEventHandler();
		private DataClearedEventHandler DataClearedEvent;
		
		public event DataClearedEventHandler DataCleared
		{
			add
			{
				DataClearedEvent = (DataClearedEventHandler) System.Delegate.Combine(DataClearedEvent, value);
			}
			remove
			{
				DataClearedEvent = (DataClearedEventHandler) System.Delegate.Remove(DataClearedEvent, value);
			}
		}
		
		
		
#endregion
		
#region  < PRIVATE METHODS >
		
		
		
		
		private void ResetDataVisualization()
		{
			this.txtIntDecStringBol.Text = "";
			this.dgrDataTable.DataSource = null;
			this.lstCollectionsDataType.Items.Clear();
			this.txtIntDecStringBol.Visible = false;
			this.lstCollectionsDataType.Visible = false;
			this.dgrDataTable.Visible = false;
			
		}
		
#endregion
		
#region  < PUBLIC METHODS >
		
		public void ShowData(object data)
		{
			this.ResetDataVisualization();
			string strType = data.GetType().ToString();
			switch (strType)
			{
				case "System.String":
				case "System.Int32":
				case "System.Decimal":
					this.txtIntDecStringBol.Visible = true;
					this.txtIntDecStringBol.Text = System.Convert.ToString(data);
					break;
				case "System.Boolean":
					this.txtIntDecStringBol.Visible = true;
					if (System.Convert.ToBoolean(data) == true)
					{
						this.txtIntDecStringBol.Text = "TRUE";
					}
					else if (System.Convert.ToBoolean(data) == false)
					{
						this.txtIntDecStringBol.Text = "FALSE";
					}
					break;
				case "System.Data.DataTable":
					this.dgrDataTable.Visible = true;
					this.dgrDataTable.DataSource = (DataTable) data;
					break;
					
				case "UtilitiesLibrary.Data.CustomHashTable":
					this.lstCollectionsDataType.Visible = true;
					string strElem_1 = "";
					DictionaryEntry dicentry_1 = new DictionaryEntry();
					IEnumerator enumm_1 = ((CustomHashTable) data).GetEnumerator();
					while (enumm_1.MoveNext())
					{
						dicentry_1 = (DictionaryEntry)enumm_1.Current;
						strElem_1 = "Key = " + System.Convert.ToString(dicentry_1.Key) + System.Convert.ToString(dicentry_1.Key) + "  ,  Value = " + System.Convert.ToString(dicentry_1.Value);
						this.lstCollectionsDataType.Items.Add(strElem_1);
					}
					break;
					
				case "UtilitiesLibrary.Data.CustomList":
					this.lstCollectionsDataType.Visible = true;
					IEnumerator enumm_2 = ((CustomList) data).GetEnumerator();
					while (enumm_2.MoveNext())
					{
						this.lstCollectionsDataType.Items.Add(enumm_2.Current);
					}
					break;
					
				case "UtilitiesLibrary.Data.CustomSortedList":
					this.lstCollectionsDataType.Visible = true;
					string strElem = "";
					DictionaryEntry dicentry = new DictionaryEntry();
					IEnumerator enumm = ((CustomSortedList) data).GetEnumerator();
					while (enumm.MoveNext())
					{
						dicentry = (DictionaryEntry)enumm.Current;
						strElem = "Key = " + System.Convert.ToString(dicentry.Key) + System.Convert.ToString(dicentry.Key) + "  ,  Value = " + System.Convert.ToString(dicentry.Value);
						this.lstCollectionsDataType.Items.Add(strElem);
					}
					break;
			}
		}
		
		public void ClearData()
		{
			this.txtIntDecStringBol.Text = "";
			this.dgrDataTable.DataSource = null;
			this.lstCollectionsDataType.Items.Clear();
			if (DataClearedEvent != null)
				DataClearedEvent();
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void btnClear_Click(System.Object sender, System.EventArgs e)
		{
			this.ClearData();
			this.ResetDataVisualization();
		}
		
#endregion
		
		
		
	}
	
}
