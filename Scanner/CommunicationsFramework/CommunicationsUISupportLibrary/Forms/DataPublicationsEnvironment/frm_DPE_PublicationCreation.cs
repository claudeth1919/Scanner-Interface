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
	public partial class frm_DPE_PublicationCreation
	{
		
#region  < DATAMEMBERS >
		
		private DPE_DataPublicationsClient _client;
		private Hashtable _publicationVariables;
		private publicationsPosting.PostedPublicationDefinitionData _publicationsPostingData;
		
#endregion
		
#region  < COSNTRUCTORS >
		
		public frm_DPE_PublicationCreation(DPE_DataPublicationsClient client)
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			
			// Add any initialization after the InitializeComponent() call.
			this._client = client;
			this._publicationVariables = new Hashtable();
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
		
#region  < UI CALLBACKS >
		
		public void frmPublicationCreation_Load(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.txtSTXDSSCName.Text = _client.ClientName;
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
				
				if (this.lstBoxPublicationVariables.Items.Count <= 0)
				{
					throw (new Exception("No variables specified for the publication"));
				}
				
				DPE_ClientPublicationDefinition publication = default(DPE_ClientPublicationDefinition);
				
				if (this.txtPublicationsGroup.Text.Length > 0)
				{
					publication = new DPE_ClientPublicationDefinition(this.txtPublicationsGroup.Text, this.txtPublicationName.Text);
				}
				else
				{
					publication = new DPE_ClientPublicationDefinition(this.txtPublicationName.Text);
				}
				
				string varName = "";
                DPE_ServerDefs.PublicationVariableDataType varType = default(DPE_ServerDefs.PublicationVariableDataType);
				IEnumerator enumm = this._publicationVariables.GetEnumerator();
				while (enumm.MoveNext())
				{
					varName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
                    varType = (DPE_ServerDefs.PublicationVariableDataType)(((DictionaryEntry)enumm.Current).Value);
					publication.AddVaribleToPublication(varName, varType);
				}
				
				this._client.CreateDataPublication(publication);
				
				//creation of support object to serialize publicatio creation data
				this._publicationsPostingData = new publicationsPosting.PostedPublicationDefinitionData(publication.PublicationName);
				enumm = this._publicationVariables.GetEnumerator();
				while (enumm.MoveNext())
				{
					varName = System.Convert.ToString(((DictionaryEntry) enumm.Current).Key);
                    varType = (DPE_ServerDefs.PublicationVariableDataType)(((DictionaryEntry)enumm.Current).Value);
					publicationsPosting.PublicationVariableDefinitionData def = new publicationsPosting.PublicationVariableDefinitionData(varName, varType);
					this._publicationsPostingData.AddVariableDefinition(def);
				}
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				this.DialogResult = System.Windows.Forms.DialogResult.None;
			}
		}
		
		public void btnAddVariable_Click(System.Object sender, System.EventArgs e)
		{
			frm_DPE_PublicationVariableCreation frm = null;
			try
			{
				frm = new frm_DPE_PublicationVariableCreation();
				if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				{
					if (!this._publicationVariables.ContainsKey(frm.PublicationVariableName))
					{
						this._publicationVariables.Add(frm.PublicationVariableName, frm.PublicationVariableDataType);
						string typeStr = System.Convert.ToString(DPE_ServerDefs.Get_String_FromPublicationVariableDataType(frm.PublicationVariableDataType));
						string str = frm.PublicationVariableName + " , " + typeStr;
						this.lstBoxPublicationVariables.Items.Add(str);
					}
				}
				frm.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				try
				{
					frm.Dispose();
				}
				catch (Exception)
				{
				}
			}
		}
		
#endregion
		
		
	}
}
