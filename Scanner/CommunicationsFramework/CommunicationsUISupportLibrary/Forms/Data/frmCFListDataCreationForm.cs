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
	public partial class frmCFListDataCreationForm
	{
		public frmCFListDataCreationForm()
		{
			InitializeComponent();
		}
		
		private CustomList _List = new CustomList();
		
		
public CustomList Data
		{
			get
			{
				return _List;
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
		
		public void Button3_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				string element = Interaction.InputBox("Insert a new element to the collection", "", "", -1, -1);
				if (element.Length > 0)
				{
					this.lstCollection.Items.Add(element);
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
				if (this.lstCollection.SelectedIndex >= 0)
				{
					this.lstCollection.Items.Remove(this.lstCollection.SelectedItem);
				}
				else
				{
					MessageBox.Show("Nothing to remove");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
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
				
				if (this.lstCollection.Items.Count <= 0)
				{
					MessageBox.Show("No elements in the collection");
					this.DialogResult = System.Windows.Forms.DialogResult.None;
					return;
				}
				
				IEnumerator enumm = this.lstCollection.Items.GetEnumerator();
				while (enumm.MoveNext())
				{
					this._List.Add(enumm.Current);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			
		}
	}
}
