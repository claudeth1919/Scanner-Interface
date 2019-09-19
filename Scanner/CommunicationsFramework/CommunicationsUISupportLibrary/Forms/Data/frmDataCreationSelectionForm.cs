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


namespace CommunicationsUISupportLibrary
{
	public partial class frmDataCreationSelectionForm
	{
		public frmDataCreationSelectionForm()
		{
			InitializeComponent();
		}
		
		private Data _dataObject;
		
		
public Data Data
		{
			get
			{
				return this._dataObject;
			}
		}
		
		
		public void Button1_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.rbtnBoolean.Checked)
				{
					frmBooleanDataCreationForm frm = new frmBooleanDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnDataTable.Checked)
				{
					frmDataTableDataCreationForm frm = new frmDataTableDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnDecimal.Checked)
				{
					frmDecimalDataCreationForm frm = new frmDecimalDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnHash.Checked)
				{
					frmCFHashTableDataCreationForm frm = new frmCFHashTableDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnInteger.Checked)
				{
					frmIntegerDataCreationForm frm = new frmIntegerDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnSortedList.Checked)
				{
					frmCFSortedListDataCreationForm frm = new frmCFSortedListDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnString.Checked)
				{
					frmStringDataCreationForm frm = new frmStringDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnCFList.Checked)
				{
					frmCFListDataCreationForm frm = new frmCFListDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
					frm.Dispose();
				}
				else if (this.rbtnDataSet.Checked)
				{
					frmDataSetDataCreationForm frm = new frmDataSetDataCreationForm();
					if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						this._dataObject = new Data(frm.DataName, frm.Data);
					}
					else
					{
						this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
					}
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public void Button2_Click(System.Object sender, System.EventArgs e)
		{
			
		}
		
		public void rbtnHash_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			
		}
	}
	
	
}
