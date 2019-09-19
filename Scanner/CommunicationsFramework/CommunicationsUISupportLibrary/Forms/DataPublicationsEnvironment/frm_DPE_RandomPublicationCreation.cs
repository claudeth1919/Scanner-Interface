using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Linq;
using CommunicationsLibrary.DataPublicationsEnvironment;
using CommunicationsLibrary.DataPublicationsEnvironment.Client;
using CommunicationsLibrary.DataPublicationsEnvironment.Definitions;
using CommunicationsUISupportLibrary.publicationsPosting;
using System.Windows.Forms;


namespace CommunicationsUISupportLibrary
{
    public partial class frm_DPE_RandomPublicationCreation
	{
		
#region  < DATAMEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private publicationsPosting.PostedPublicationDefinitionData _publicationsPostingData;
		private int _variablesCount;
		
#endregion
		
#region  < COSNTRUCTORS >
		
		public frm_DPE_RandomPublicationCreation(DPE_DataPublicationsClient client)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._client = client;
			this._variablesCount = 0;
			
		}
		
#endregion
		
#region  < PROPERTIES >
		
public publicationsPosting.PostedPublicationDefinitionData PublicationPostingData
		{
			get
			{
				return this._publicationsPostingData;
			}
		}
		
#endregion
		
#region  < PRIVATE METHODS >
		
		private  DPE_ServerDefs.PublicationVariableDataType GetRandomDataType()
		{
            DPE_ServerDefs.PublicationVariableDataType varType = default(DPE_ServerDefs.PublicationVariableDataType);
			
			int typeByIndex = 0;
			bool typeFound = false;
			
			while ((typeByIndex < 1 & typeByIndex > 5) || !typeFound)
			{
				Random random = new Random();
				typeByIndex = random.Next(1, 5);
				
				switch (typeByIndex)
				{
					case 1:
						if (this.chkInteger.Checked)
						{
                            varType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Integer;
							typeFound = true;
						}
						break;
					case 2:
						if (this.chkDEcimal.Checked)
						{
                            varType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Decimal;
							typeFound = true;
						}
						break;
					case 3:
						if (this.chkBoolean.Checked)
						{
                            varType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_Boolean;
							typeFound = true;
						}
						break;
					case 4:
						if (this.chkString.Checked)
						{
                            varType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_String;
							typeFound = true;
						}
						break;
					case 5:
						if (this.chkDataTable.Checked)
						{
                            varType = DPE_ServerDefs.PublicationVariableDataType.DPE_DT_DataTable;
							typeFound = true;
						}
						break;
					default:
						typeFound = false;
						break;
				}
				
			}
			
			return varType;
			
			
		}
		
		private void ValidateSelectedType()
		{
			int count = 0;
			
			if (this.chkBoolean.Checked)
			{
				count++;
			}
			if (this.chkDataTable.Checked)
			{
				count++;
			}
			if (this.chkDEcimal.Checked)
			{
				count++;
			}
			if (this.chkInteger.Checked)
			{
				count++;
			}
			if (this.chkString.Checked)
			{
				count++;
			}
			
			if (count <= 0)
			{
				throw (new Exception("No data types selected from list"));
			}
			
		}
		
#endregion
		
#region  < UI CALLBACKS >
		
		public void frmPublicationCreation_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.txtSTXDSSCName.Text = _client.ClientName;
				this.txtPublicationName.Text = _client.ClientName + "_PUB" + System.Convert.ToString(this._client.PublicationsPostCount + 1);
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
				if (this.txtPublicationName.Text.Length <= 0)
				{
					this.txtPublicationName.Focus();
					throw (new Exception("No Publication Name specified"));
				}
				
				
				this.ValidateSelectedType();
				
				DPE_ClientPublicationDefinition publication = default(DPE_ClientPublicationDefinition);
				
				if (this.txtPublicationsGroup.Text.Length > 0)
				{
					publication = new DPE_ClientPublicationDefinition(this.txtPublicationsGroup.Text, this.txtPublicationName.Text);
				}
				else
				{
					publication = new DPE_ClientPublicationDefinition(this.txtPublicationName.Text);
				}
				
				
				
				
				this._publicationsPostingData = new publicationsPosting.PostedPublicationDefinitionData(publication.PublicationName);
				
				
				string variableName = "";
                DPE_ServerDefs.PublicationVariableDataType varType = default(DPE_ServerDefs.PublicationVariableDataType);
				
				for (this._variablesCount = 1; this._variablesCount <= this.nudNumberOfVariables.Value; this._variablesCount++)
				{
					varType = this.GetRandomDataType();
					variableName = this.txtPublicationName.Text + "_VAR_" + System.Convert.ToString(this._variablesCount);
					publication.AddVaribleToPublication(variableName, varType);
					
					publicationsPosting.PublicationVariableDefinitionData def = new publicationsPosting.PublicationVariableDefinitionData(variableName, varType);
					this._publicationsPostingData.AddVariableDefinition(def);
					
				}
				
				this._client.CreateDataPublication(publication);
				
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
