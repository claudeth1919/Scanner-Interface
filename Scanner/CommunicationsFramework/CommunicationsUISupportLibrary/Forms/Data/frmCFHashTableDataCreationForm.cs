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
	public partial class frmCFHashTableDataCreationForm
	{
		public frmCFHashTableDataCreationForm()
		{
			InitializeComponent();
		}
		
		private CustomHashTable _hashTable = new CustomHashTable();
		
		
public CustomHashTable Data
		{
			get
			{
				return _hashTable;
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
				
				if (this._hashTable.Count <= 0)
				{
					MessageBox.Show("No elements on the hash table");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string key = "";
				string value = "";
				
				key = Interaction.InputBox("Insert a Key value", "", "", -1, -1);
				if (key.Length > 0)
				{
					value = Interaction.InputBox("Insert a Value", "", "", -1, -1);
					if (value.Length > 0)
					{
						if (this._hashTable.ContainsKey(key))
						{
							throw (new Exception("The key specified is already in the hashtable"));
						}
						else
						{
							this._hashTable.Add(key, value);
							this.lstHashTable.Items.Add(key + " , " + value);
						}
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
				if (this.lstHashTable.SelectedIndex >= 0)
				{
					string element = System.Convert.ToString(this.lstHashTable.SelectedItem);
					string[] keys = element.Split(new char[] {','});
					string key = keys[0];
					this.lstHashTable.Items.Remove(this.lstHashTable.SelectedItem);
					this._hashTable.Remove(key);
				}
			}
			catch (Exception)
			{
				
			}
		}
	}
}
