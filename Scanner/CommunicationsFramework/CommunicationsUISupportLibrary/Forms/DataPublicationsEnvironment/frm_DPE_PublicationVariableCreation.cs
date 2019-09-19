using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
	public partial class frm_DPE_PublicationVariableCreation
	{
		public frm_DPE_PublicationVariableCreation()
		{
			InitializeComponent();
		}
		
#region  < PROPERTIES  >
		
        public string PublicationVariableName
		{
			get
			{
				return this.txtVariableName.Text;
			}
		}

        public DPE_ServerDefs.PublicationVariableDataType PublicationVariableDataType
		{
			get
			{
				if (this.cboDataType.SelectedIndex >= 0)
				{
					return (DPE_ServerDefs.PublicationVariableDataType)this.cboDataType.SelectedItem;
				}
				else
				{
					throw new Exception("No selected asyncEvtArgs");
				}
			}
		}
		
#endregion
		
		
#region  < UI CALLBACKS >
		
		public void frmPublicationVariable_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFHashTable);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFList);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_CFSortedList);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataSet);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer);
                this.cboDataType.Items.Add(DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		public void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (this.txtVariableName.Text.Length <= 0)
				{
					this.txtVariableName.Focus();
					throw (new Exception("No variable name specified"));
				}
				
				if (this.cboDataType.SelectedIndex < 0)
				{
					this.cboDataType.Focus();
					throw (new Exception("No data type specified fot the publication variable"));
				}
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}
		
#endregion
		
		
	}
}
