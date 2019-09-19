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
using System.Windows.Forms;



namespace CommunicationsUISupportLibrary
{
	public partial class frmCFSortedListDataCreationForm
	{
		public frmCFSortedListDataCreationForm()
		{
			InitializeComponent();
		}
		
		private CustomSortedList _sortedList = new CustomSortedList();
		
		
public CustomSortedList Data
		{
			get
			{
				return _sortedList;
			}
		}
		
public string DataName
		{
			get
			{
				return this.txtDataName.Text;
			}
		}
		
		
		public void frmIntegerDataCreationForm_Load(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void btnOk_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtDataName.Text.Length <= 0)
				{
					MessageBox.Show("No dataname specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
				if (this.lstSortedList.Items.Count <= 0)
				{
					MessageBox.Show("No data specified");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
				IEnumerator enumm = this.lstSortedList.Items.GetEnumerator();
				string keysString = "";
				string[] keyParts = null;
				while (enumm.MoveNext())
				{
					keysString = System.Convert.ToString(enumm.Current);
					keyParts = keysString.Split(',');
					keyParts[0] = keyParts[0].TrimStart();
					keyParts[0] = keyParts[0].TrimEnd();
					keyParts[1] = keyParts[1].TrimStart();
					keyParts[1] = keyParts[1].TrimEnd();
					this._sortedList.Add(keyParts[0], keyParts[1]);
				}
				
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string key = Interaction.InputBox("Enter the KEY of the element", "", "", -1, -1);
				if (key.Length > 0)
				{
					string value = Interaction.InputBox("Enter a VALUE for the element", "", "", -1, -1);
					if (value.Length > 0)
					{
						string str = key + " , " + value;
						this._sortedList.Add(key, value);
						this.lstSortedList.Items.Add(str);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button4_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.lstSortedList.SelectedIndex >= 0)
				{
					string element = System.Convert.ToString(this.lstSortedList.SelectedItem);
					string[] keys = element.Split(new char[] {','});
					string key = keys[0];
					this.lstSortedList.Items.Remove(this.lstSortedList.SelectedItem);
					this._sortedList.Remove(key);
				}
				
			}
			catch (Exception)
			{
				
			}
		}
	}
}
